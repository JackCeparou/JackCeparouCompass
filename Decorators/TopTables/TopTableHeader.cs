namespace Turbo.Plugins.Jack.Decorators.TopTables
{
    using System;
    using System.Collections.Generic;
    using Turbo.Plugins.Default;

    public class TopTableHeader
    {
        public IController Hud { get; set; }

        public float RatioHeight { get; set; }
        public float RatioWidth { get; set; }

        public float Height { get { return (float)Math.Floor(RatioHeight * Hud.Window.Size.Height); } }
        public float Width { get { return (float)Math.Floor(RatioWidth * Hud.Window.Size.Height); } }

        public int Position { get; set; }
        public int CurrentPosition { get { return Siblings.FindIndex(x => x == this); } }

        public TopTable Table { get; set; }
        public List<TopTableHeader> Siblings { get; set; }
        public List<TopTableCell> Cells { get; set; }

        private TopTableCellDecorator _decorator;
        public TopTableCellDecorator Decorator
        {
            get { return _decorator ?? Table.DefaultHeaderDecorator; }
            set { _decorator = value; }
        }

        private TopTableCellDecorator _hightLightDecorator;
        public TopTableCellDecorator HighlightDecorator
        {
            get { return _hightLightDecorator ?? Table.DefaultHighlightDecorator; }
            set { _hightLightDecorator = value; }
        }

        private TopTableCellDecorator _cellDecorator;
        public TopTableCellDecorator CellDecorator
        {
            get { return _cellDecorator; }
            set { _cellDecorator = value; }
        }

        private TopTableCellDecorator _cellHightLightDecorator;
        public TopTableCellDecorator CellHighlightDecorator
        {
            get { return _cellHightLightDecorator; }
            set { _cellHightLightDecorator = value; }
        }

        public HorizontalAlign? TextAlign { get; set; }
        public Func<int, int, string> TextFunc { get; set; }
        public Func<int, int, bool> HighlightFunc { get; set; }

        public TopTableHeader(IController hud, Func<int, int, string> textFunc = null)
        {
            Hud = hud;
            Cells = new List<TopTableCell>();
            HighlightFunc = (pos, curPos) => false;

            if (textFunc == null)
                TextFunc = (pos, curPos) => string.Empty;
            else
                TextFunc = textFunc;
        }

        public void Paint(float x, float y, HorizontalAlign textAlign)
        {
            var decorator = HighlightFunc(Position, CurrentPosition)
                ? HighlightDecorator
                : Decorator;
            if (decorator == null) return;

            var text = TextFunc(Position, CurrentPosition);
            decorator.Paint(x, y, Width, Height, text, TextAlign ?? textAlign);
        }
    }
}