namespace Turbo.Plugins.Jack.Decorators.TopTables
{
    using System;

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

        public Func<string> TextFunc { get; set; }

        public TopTableCell(IController hud)
        {
            Hud = hud;
            TextFunc = () => string.Empty;
        }

        public void Paint(float x, float y)
        {
            Decorator.Paint(x, y, Width, Height, TextFunc());
        }
    }
}