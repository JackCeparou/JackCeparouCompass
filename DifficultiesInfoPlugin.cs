namespace Turbo.Plugins.Jack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Decorators.TopTables;

    public class DifficultiesInfoPlugin : BasePlugin, IInGameTopPainter
    {
        public Func<int, string> TormentLabelFunc { get; set; } = (pos) => string.Format("T{0}", pos - 3);
        public Dictionary<int, string> LowerDifficultiesLabels { get; set; } = new Dictionary<int, string>() {
            { 0, "Normal" },
            { 1, "Hard" },
            { 2, "Expert" },
            { 3, "Master" },
        };
        public Dictionary<int, string> LineHeaders { get; set; } = new Dictionary<int, string>()
        {
            { 0, "Greater Rift equivalent" },
            { 1, "Monster health" },
            { 2, "Monster damage" },
            { 3, "+ XP" },
            { 4, "+ Gold Find" },
            { 5, "Legendary drop" },
            { 6, "Legendary drop (rift)" },
            { 7, "Death's Breath" },
            { 8, "Greater Rift key" },
            { 9, "Horadric Cache materials" },
            { 10, "Horadric Cache legendaries" },
            { 11, "Keywarden Machine drop" },
            { 12, "Uber Organ drop" },
        };

        public TopTable Table { get; private set; }

        // updated by Silkdog569 for T14-T16 data
        private readonly string[,] difficultiesData = new string[,]
        {
            {   "-",        "GR1",      "GR4",      "GR7",      "GR10",     "GR13",     "GR16",     "GR19",     "GR22",     "GR25",     "GR30",     "GR35",     "GR40",     "GR45",     "GR50",     "GR55",     "GR60",        "GR65",        "GR70",          "GR75",         },
            {   "100%",     "200%",     "320%",     "512%",     "819%",     "1311%",    "2097%",    "3355%",    "5369%",    "8590%",    "18985%",   "41625%",   "91260%",   "200082%",  "438669%",  "961759%",  "2108607%",    "2889383%",    "6334823%",      "13888770%",    },
            {   "100%",     "130",      "189%",     "273%",     "396%",     "575%",     "833%",     "1208%",    "1752%",    "2540%",    "3604%",    "5097%",    "7208%",    "10194%",   "14416%",   "20387%",   "28832%",      "40774%" ,     "57664%",        "64725%",       },
            {   "0%",       "75%",      "100%",     "200%",     "300%",     "400%",     "550%",     "800%",     "1150%",    "1600%",    "1900%",    "2425%",    "3100%",    "4000%",    "5000%",    "6400%",    "8200%",       "10500%",      "13400%",        "17000%",       },
            {   "0%",       "75%",      "100%",     "200%",     "300%",     "400%",     "550%",     "800%",     "1150%",    "1600%",    "1850%",    "2150%",    "2500%",    "2900%",    "3350%",    "3900%",    "4500%",       "5200%",       "6050%",         "7000%",        },
            {   "0%",       "0%",       "0%",       "0%",       "15%",      "32%",      "52%",      "75%",      "101%",     "131%",     "164%",     "205%",     "256%",     "320%",     "400%",     "500%",     "625%",        "781%",        "977%",          "1221%",        },
            {   "25%",      "25%",      "25%",      "25%",      "44%",      "65%",      "90%",      "119%",     "151%",     "189%",     "236%",     "295%",     "369%",     "461%",     "577%",     "721%",     "901%",        "1126%",       "1408%",         "1760%",        },
            {   "15%",      "18%",      "21%",      "25%",      "31%",      "37%",      "44%",      "53%",      "64%",      "75%",      "90%",      "2nd 15%",  "2nd 25%",  "2nd 50%",  "2nd 90%",  "3rd 12%",  "3rd 25%",     "3rd 60%",     "3",             "4th 50%",      },
            {   "1",        "2nd 5%",   "2nd 10%",  "2nd 15%",  "2nd 20%",  "2nd 25%",  "2nd 31%",  "2nd 38%",  "2nd 44%",  "2nd 51%",  "2nd 60%",  "2nd 70%",  "2nd 80%",  "2nd 90%",  "2",        "3rd 12%",  "3rd 25%",     "3rd 38%",     "3rd 51%",       "3rd 66%",      },
            {   "3",        "3",        "3",        "3",        "6",        "6",        "6",        "6",        "6",        "6",        "8",        "8",        "8",        "10",       "12",       "14",       "16",          "18",          "20",            "22",           },
            {   "10%",      "10%",      "10%",      "10%",      "10%",      "50%",      "60%",      "75%",      "90%",      "100%",     "2nd 5%",   "2nd 15%",  "2nd 25%",  "2nd 50%",  "2nd 65%",  "2nd 80%",  "2",           "3rd 25%",     "3rd 50%",       "3rd 80%",      },
            {   "-",        "-",        "-",        "-",        "50%",      "75%",      "90%",      "100%",     "2nd 10%",  "2nd 20%",  "2nd 30%",  "2nd 40%",  "2nd 50%",  "2nd 60%",  "2nd 70%",  "2nd 80%",  "2nd 90%",     "2",           "3rd 10%",       "3rd 20%",      },
            {   "-",        "-",        "-",        "-",        "1",        "2nd 10%",  "2nd 25%",  "2nd 50%",  "2nd 75%",  "2nd 90%",  "200%",     "3rd 10%",  "3rd 25%",  "3rd 50%",  "3rd 75%",  "3rd 90%",  "3",           "4th 12%",     "4th 25%",       "4th 50%",      },
        };

        private TopTableHeader HeaderTemplate => new TopTableHeader(Hud, (pos, curPos) => GetColumnHeaderText(pos))
        {
            RatioHeight = 22 / 1080f,
            RatioWidth = 0.075f,
            HighlightFunc = (pos, curPos) => (int)Hud.Game.GameDifficulty == pos,
            TextAlign = HorizontalAlign.Center,
        };

        private TopTableCell[] LineCellsTemplate => Enumerable
            .Range(0, difficultiesData.GetLength(1))
            .Select(x => new TopTableCell(Hud, (line, column, lineSorted, columnSorted) => difficultiesData[line, column]) { TextAlign = HorizontalAlign.Center }).ToArray();

        private TopTableHeader LineHeaderTemplate => new TopTableHeader(Hud, (pos, curPos) => GetLineHeaderText(pos))
        {
            RatioWidth = 62 / 1080f, // define only once on first line, value on other will be ignored
            RatioHeight = 22 / 1080f,
            HighlightFunc = (pos, curPos) => false,
            TextAlign = HorizontalAlign.Right,
            HighlightDecorator = new TopTableCellDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, true, false, true),
            },
            CellHighlightDecorator = new TopTableCellDecorator(Hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, true, false, true),
            },
        };

        public DifficultiesInfoPlugin()
        {
            Enabled = true;
            Order = int.MaxValue;
        }

        private void InitTable()
        {
            Table = new TopTable(Hud)
            {
                RatioPositionX = 0.5f,
                RatioPositionY = 0.2f,
                HorizontalCenter = true,
                VerticalCenter = false,
                PositionFromRight = false,
                PositionFromBottom = false,
                ShowHeaderLeft = true,
                ShowHeaderTop = true,
                ShowHeaderRight = false,
                ShowHeaderBottom = false,
                DefaultCellDecorator = new TopTableCellDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, false, false, true),
                },
                DefaultHighlightDecorator = new TopTableCellDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 242, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, -1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, false, false, true),
                },
                DefaultHeaderDecorator = new TopTableCellDecorator(Hud)
                {
                    //BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    //BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 255, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, false, false, true),
                }
            };

            var columnCount = difficultiesData.GetLength(1);
            var headers = Enumerable.Range(0, columnCount).Select(x => HeaderTemplate).ToArray();
            Table.DefineColumns(headers);

            var lineCount = difficultiesData.GetLength(0);
            for (var i = 0; i < lineCount; i++)
            {
                Table.AddLine(
                    LineHeaderTemplate,
                    LineCellsTemplate
                );
            }
        }

        private string GetColumnHeaderText(int pos)
        {
            if (LowerDifficultiesLabels.ContainsKey(pos))
                return LowerDifficultiesLabels[pos];

            return TormentLabelFunc?.Invoke(pos) ?? "???";
        }

        private string GetLineHeaderText(int pos)
        {
            if (LineHeaders.ContainsKey(pos))
                return LineHeaders[pos];

            return string.Empty;
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (!Hud.Game.IsInTown) return;
            if (clipState != ClipState.AfterClip) return;

            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.BoostWrapper.BoostsDifficultyStackPanel.clock");
            if (!Hud.Window.CursorInsideRect(uiRect.Rectangle.X, uiRect.Rectangle.Y, uiRect.Rectangle.Width, uiRect.Rectangle.Height)) return;
            // if (!Hud.Window.CursorInsideRect(Hud.Window.Size.Width * 0.9f, Hud.Window.Size.Height * 0.02f, Hud.Window.Size.Width * 0.1f, Hud.Window.Size.Height * 0.02f)) return;

            if (Table == null)
                InitTable();
            else
                Table.Paint();
        }
    }
}