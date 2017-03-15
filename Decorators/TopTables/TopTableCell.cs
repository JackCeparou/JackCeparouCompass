namespace Turbo.Plugins.Jack.Decorators.TopTables
{
    using System;
    using Turbo.Plugins.Default;

    public class TopTableCell
    {
        public IController Hud { get; set; }

        public TopTable Table { get; set; }
        public TopTableHeader Column { get; set; }
        public TopTableHeader Line { get; set; }

        public float Height { get { return Line.Height; } }
        public float Width { get { return Column.Width; } }

        private TopTableCellDecorator _decorator;
        public TopTableCellDecorator Decorator
        {
            get { return _decorator ?? Column.CellDecorator ?? Line.CellDecorator ?? Table.DefaultCellDecorator; }
            set { _decorator = value; }
        }

        private TopTableCellDecorator _hightLightDecorator;
        public TopTableCellDecorator HighlightDecorator
        {
            get { return _hightLightDecorator; }
            set { _hightLightDecorator = value; }
        }

        public HorizontalAlign? TextAlign { get; set; }
        public Func<int, int, int, int, string> TextFunc { get; set; }
        public Func<int, int, int, int, bool> HighlightFunc { get; set; }

        public TopTableCell(IController hud, Func<int, int, int, int, string> textFunc = null)
        {
            Hud = hud;

            HighlightFunc = (line, column, lineSorted, columnSorted) => false;

            if (textFunc == null)
                TextFunc = (line, column, lineSorted, columnSorted) => string.Empty;
            else
                TextFunc = textFunc;
        }

        public void Paint(float x, float y, int line, int column)
        {
            var decorator = Decorator;
            var highlight = HighlightFunc(Line.Position, Column.Position, line, column);
            var lineHighlight = Line.HighlightFunc(Line.Position, Line.CurrentPosition);
            var columnHighlight = Column.HighlightFunc(Column.Position, Column.CurrentPosition);
            if (highlight || columnHighlight || lineHighlight)
            {
                if (highlight)
                {
                    decorator = HighlightDecorator ?? Table.DefaultHighlightDecorator;
                }
                else if (columnHighlight)
                {
                    decorator = HighlightDecorator ?? Column.HighlightDecorator ?? Table.DefaultHighlightDecorator;
                }
                else
                {
                    decorator = HighlightDecorator ?? Line.HighlightDecorator ?? Table.DefaultHighlightDecorator;
                }
            }

            if (decorator == null) return;

            var text = TextFunc(Line.Position, Column.Position, line, column);
            decorator.Paint(x, y, Width, Height, text, TextAlign ?? HorizontalAlign.Center);
        }
    }
}