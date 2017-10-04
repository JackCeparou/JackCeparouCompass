using System;
using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;
// original idea by seadragon (glq)
namespace Turbo.Plugins.Jack.Game
{
    public class UberRunsPlugin : BasePlugin, IInGameWorldPainter, INewAreaHandler, IInGameTopPainter
    {
        public GroundLabelDecorator MarkerDecorator { get; set; }
        public IFont CompletedFont { get; set; }
        public IFont CompletedCounterFont { get; set; }

        public string CompletedLabel { get; set; }
        public string CompletedCounterLabel { get; set; }
        public string Portal1Label { get { return uberEncounterStates[areaSno1].Label; } set { uberEncounterStates[areaSno1].Label = value; } }
        public string Portal2Label { get { return uberEncounterStates[areaSno2].Label; } set { uberEncounterStates[areaSno2].Label = value; } }
        public string Portal3Label { get { return uberEncounterStates[areaSno3].Label; } set { uberEncounterStates[areaSno3].Label = value; } }
        public string Portal4Label { get { return uberEncounterStates[areaSno4].Label; } set { uberEncounterStates[areaSno4].Label = value; } }

        private Dictionary<uint, UberAreaDefinition> uberEncounterStates;
        private HashSet<uint> uberPortalSnos;
        private int gameRunCompletedCounter;
        private bool gameRunCompleted;

        private const uint portalAreaSno = 257116;
        private const uint portalSno1 = 258384;
        private const uint portalSno2 = 258385;
        private const uint portalSno3 = 258386;
        private const uint portalSno4 = 366533;
        private const uint areaSno1 = 256767;
        private const uint areaSno2 = 256106;
        private const uint areaSno3 = 256742;
        private const uint areaSno4 = 374239;

        public UberRunsPlugin()
        {
            Enabled = true;
            uberEncounterStates = new Dictionary<uint, UberAreaDefinition>();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            MarkerDecorator = new GroundLabelDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
                BorderBrush = Hud.Render.CreateBrush(192, 255, 255, 255, 1),
                TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 255, 255, 255, true, false, false),
            };

            CompletedFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 0, 0, true, false, true);
            CompletedCounterFont = Hud.Render.CreateFont("tahoma", 8, 255, 239, 220, 129, false, false, true);

            CompletedLabel = "Uber game done!";
            CompletedCounterLabel = "Uber runs ：";

            uberEncounterStates.Add(areaSno1, new UberAreaDefinition(areaSno1, portalSno1, "A1 done"));
            uberEncounterStates.Add(areaSno2, new UberAreaDefinition(areaSno2, portalSno2, "A2 done"));
            uberEncounterStates.Add(areaSno3, new UberAreaDefinition(areaSno3, portalSno3, "A3 done"));
            uberEncounterStates.Add(areaSno4, new UberAreaDefinition(areaSno4, portalSno4, "A4 done"));

            uberPortalSnos = new HashSet<uint>(uberEncounterStates.Select(a => a.Value.PortalSno));
        }

        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
            {
                foreach (var state in uberEncounterStates)
                {
                    state.Value.Visited = false;
                }
                gameRunCompleted = false;
            }
            else if (!gameRunCompleted)
            {
                if (uberEncounterStates.ContainsKey(area.Sno))
                {
                    uberEncounterStates[area.Sno].Visited = true;
                }

                if (uberEncounterStates.All(a => a.Value.Visited))
                {
                    gameRunCompletedCounter++;
                    gameRunCompleted = true;
                }
            }
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (layer != WorldLayer.Ground) return;
            if (Hud.Game.Me.SnoArea.Sno != portalAreaSno) return;

            foreach (var portal in Hud.Game.Actors.Where(a => uberPortalSnos.Contains(a.SnoActor.Sno)))
            {
                var encounterState = uberEncounterStates.Where(a => a.Value.PortalSno == portal.SnoActor.Sno).Select(a => a.Value).FirstOrDefault();
                if (encounterState != null && encounterState.Visited)
                {
                    MarkerDecorator.Paint(portal, portal.FloorCoordinate.Offset(0, 0, 6f), encounterState.Label);
                }
            }
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;

            var ui = Hud.Render.MinimapUiElement.Rectangle;

            if (gameRunCompleted && !string.IsNullOrEmpty(CompletedLabel))
            {
                CompletedFont.DrawText(CompletedLabel, ui.Left, ui.Top);
            }

            if (gameRunCompletedCounter != 0 && !string.IsNullOrEmpty(CompletedCounterLabel))
            {
                CompletedCounterFont.DrawText(CompletedCounterLabel + gameRunCompletedCounter, ui.Left, ui.Top / 2f);
            }
        }

        private class UberAreaDefinition
        {
            public bool Visited { get; set; }
            public string Label { get; set; }
            public uint AreaSno { get; private set; }
            public uint PortalSno { get; private set; }

            public UberAreaDefinition(uint areaSno, uint portalSno, string label)
            {
                Label = label;
                AreaSno = areaSno;
                PortalSno = portalSno;
            }
        }
    }
}