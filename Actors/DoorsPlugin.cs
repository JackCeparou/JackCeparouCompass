namespace Turbo.Plugins.Jack.Actors
{
    using SharpDX.DirectInput;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class DoorsPlugin : BasePlugin, IInGameWorldPainter, IKeyEventHandler
    {
        public WorldDecoratorCollection DoorsDecorators { get; set; }
        public WorldDecoratorCollection BreakablesDoorsDecorators { get; set; }
        public WorldDecoratorCollection BridgesDecorators { get; set; }

        public WorldDecoratorCollection DebugDecorators { get; set; }

        public string GroundSymbol { get; set; }

        public bool ShowInTown { get; set; }
        public bool GroundLabelsOnScreen { get; set; }

        public bool Debug { get; set; }
        public IKeyEvent ToggleKeyEvent { get; set; }

        public Key HotKey
        {
            get { return ToggleKeyEvent.Key; }
            set { ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, value, false, false, false); }
        }

        private readonly HashSet<uint> bridgesIds = new HashSet<uint> { 309432, 54850, 404043, 198125 };
        private readonly HashSet<uint> breakableDoorsIds = new HashSet<uint> { 55325, 427495, 5792, 95481, 379048, 95481, 230324, }; // 258064 };

        private readonly HashSet<uint> doorsIdsBlackList = new HashSet<uint>() {
            197939, 169502, 214333, 181195, 190236, // A2 to belial
            167185, // A2 Alcarnus
            200371, 5503, // A2 City
            198977, 52685, // A3 rakkis crossing
            112316, // A3 stonefort
            210433, // A3 battlefields
            356879, 182636, 165415,
            432258,
            341214, 370187,
            178161, // check this one, maybe a bounty
            217285, // leoric manor

        };

        //170245
        private readonly HashSet<uint> doorsDebugWhiteList = new HashSet<uint>() {
            309222, 308241, 454, // ??
            309812, // X1 ??
            104888,
            258595,
            4267,
            362651,
            447673,
            162386,
            415665,
            4393,
            219702,
            250031,
            153752,
            //102711
            343582,
            230324,
        };

        public DoorsPlugin()
        {
            Enabled = true;
            Debug = false;
            ShowInTown = false;
            GroundLabelsOnScreen = false;
            GroundSymbol = "\uD83D\uDEAA"; //🚪
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            DoorsDecorators = CreateDecorators(255, 216, 0);
            BreakablesDoorsDecorators = CreateDecorators(250, 0, 0);
            BridgesDecorators = CreateDecorators(0, 195, 255);
            DebugDecorators = CreateDecorators(255, 255, 255, 255, 10);
            HotKey = Key.End;
        }

        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            if (keyEvent.IsPressed && ToggleKeyEvent.Matches(keyEvent))
            {
                Debug = !Debug;
            }
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (Hud.Game.IsInTown && !ShowInTown) return;

            Hud.Game.Actors
                .Where(a => a.GizmoType == GizmoType.Door || a.GizmoType == GizmoType.BreakableDoor)
                .ForEach(door =>
                {
                    if (breakableDoorsIds.Contains(door.SnoActor.Sno))
                    {
                        PaintActor(layer, door, BreakablesDoorsDecorators);
                    }
                    else if (door.GizmoType == GizmoType.Door && door.DisplayOnOverlay && !doorsIdsBlackList.Contains(door.SnoActor.Sno))
                    {
                        PaintActor(layer, door, bridgesIds.Contains(door.SnoActor.Sno) ? BridgesDecorators : DoorsDecorators);
                        //if (!doorsDebugWhiteList.Contains(door.SnoActor.Sno)) Says.Debug(string.Format("DOOR?? {0} {1} {2} {3} {4} {5} {6}", door.SnoActor.Sno, door.SnoActor.NameLocalized, door.IsOperated, door.IsClickable, door.IsDisabled, door.SnoActor.Kind, door.SnoActor.Code));/**/
                    }

                    //if (!doorsDebugWhiteList.Contains(door.SnoActor.Sno)) Says.Debug(string.Format("DOOR?? {0} {1} {2} {3} {4} {5} {6}", door.SnoActor.Sno, door.SnoActor.NameLocalized, door.IsOperated, door.IsClickable, door.IsDisabled, door.SnoActor.Kind, door.SnoActor.Code));/**/
                });
        }

        public WorldDecoratorCollection CreateDecorators(int r, int g, int b, int a = 200, int size = 18)
        {
            return new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    TextFont = Hud.Render.CreateFont("tahoma", size, a, r, g, b, false, false, true),
                },
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new DoorShapePainter(Hud),
                    Radius = 6f,
                    Brush = Hud.Render.CreateBrush(a, r, g, b, 1),
                }
            );
        }

        private void PaintActor(WorldLayer layer, IActor actor, WorldDecoratorCollection decorator)
        {
            if (GroundLabelsOnScreen)
                decorator.ToggleDecorators<GroundLabelDecorator>(!actor.IsOnScreen);

            if (Debug)
            {
                var text = string.Format("{0} : {1}\n{2} {3} {4} {5}\n{6}",
                    actor.SnoActor.Sno,
                    actor.SnoActor.NameLocalized,
                    actor.SnoActor.Kind,
                    actor.IsOperated ? "Operated" : "Not Operated",
                    actor.IsClickable ? "Clickable" : "Not Clickable",
                    actor.IsDisabled ? "Disabled" : "Not Disabled",
                    actor.SnoActor.Code);
                DebugDecorators.Paint(layer, actor, actor.FloorCoordinate, text);
            }
            else
            {
                decorator.Paint(layer, actor, actor.FloorCoordinate, GroundSymbol);
            }
        }
    }
}