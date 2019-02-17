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
        public bool DebugEnabled { get; set; }
        public IKeyEvent ToggleKeyEvent { get; set; }

        public Key HotKey
        {
            get { return ToggleKeyEvent.Key; }
            set { ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, value, false, false, false); }
        }

        // TODO: replace with the real enum value (no cast)
        public readonly HashSet<ActorSnoEnum> BridgesIds = new HashSet<ActorSnoEnum>
        {
            (ActorSnoEnum)309432,
            (ActorSnoEnum)54850,
            (ActorSnoEnum)404043,
            (ActorSnoEnum)198125
        };
        public readonly HashSet<ActorSnoEnum> BreakableDoorsIds = new HashSet<ActorSnoEnum>
        {
            (ActorSnoEnum)55325,
            (ActorSnoEnum)427495,
            (ActorSnoEnum)5792,
            (ActorSnoEnum)95481,
            (ActorSnoEnum)379048,
            (ActorSnoEnum)95481,
            (ActorSnoEnum)230324,
        }; // 258064 };
        public readonly HashSet<ActorSnoEnum> DoorsIdsBlackList = new HashSet<ActorSnoEnum>() {
            (ActorSnoEnum)197939, (ActorSnoEnum)169502, (ActorSnoEnum)214333, (ActorSnoEnum)181195, (ActorSnoEnum)190236, // A2 to belial
            (ActorSnoEnum)167185, // A2 Alcarnus
            (ActorSnoEnum)200371, (ActorSnoEnum)5503, // A2 City
            (ActorSnoEnum)198977, (ActorSnoEnum)52685, // A3 rakkis crossing
            (ActorSnoEnum)112316, // A3 stonefort
            (ActorSnoEnum)210433, // A3 battlefields
            (ActorSnoEnum)356879, (ActorSnoEnum)182636, (ActorSnoEnum)165415,
            (ActorSnoEnum)432258,
            (ActorSnoEnum)341214, (ActorSnoEnum)370187,
            (ActorSnoEnum)178161, // check this one, maybe a bounty
            (ActorSnoEnum)217285, // leoric manor
            (ActorSnoEnum)193248, // 3462,  Holy Sanctum
            (ActorSnoEnum)153752, // a3 catapult event
            (ActorSnoEnum)102711, // a1dun_Leor_Jail_Door_SuperLocked_A_Fake
            (ActorSnoEnum)447641, // cos_pet_mimic_01
            (ActorSnoEnum)5288, // shoulderPads_norm_base_flippy ???
            (ActorSnoEnum)291717, // x1_Abattoir_Barricade_Solid
            (ActorSnoEnum)365503, // X1_Fortress_FloatRubble_A
            (ActorSnoEnum)211456, // a3dun_Keep_Barrel_Snow_No_Skirt	Sturdy Barrel
            (ActorSnoEnum)377253, // x1_Fortress_Crystal_Prison_Shield
            (ActorSnoEnum)319797, // x1_westm_Railing_A_01_piece1
            (ActorSnoEnum)289804, // x1_Pand_HexMaze_Corpse  Corpse
            (ActorSnoEnum)159098, // DH_Companion_RuneC
            (ActorSnoEnum)187436, // LootType2_tristramVillager_Male_C_Corpse_01 Dead Villager
        };

        public DoorsPlugin()
        {
            Enabled = true;
            Debug = false;
            DebugEnabled = true;
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
                    if (BreakableDoorsIds.Contains(door.SnoActor.Sno))
                    {
                        PaintActor(layer, door, BreakablesDoorsDecorators);
                    }
                    else if (door.GizmoType == GizmoType.Door && door.DisplayOnOverlay && !DoorsIdsBlackList.Contains(door.SnoActor.Sno))
                    {
                        PaintActor(layer, door, BridgesIds.Contains(door.SnoActor.Sno) ? BridgesDecorators : DoorsDecorators);
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

            if (DebugEnabled && Debug)
            {
                var text = string.Format("{0} : {1} {2}\n{3} {4} {5} {6}\n{7}",
                    actor.SnoActor.Sno,
                    actor.SnoActor.NameLocalized,
                    actor.SnoActor.Kind,
                    actor.GizmoType,
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

/*

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
            //102711
            343582,
            230324,
        };*/
