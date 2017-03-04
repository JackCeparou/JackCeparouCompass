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

        public TopTable Table { get; set; }
        public List<TopTableCell> Cells { get; set; }
        private TopTableCellDecorator _decorator;

        public TopTableCellDecorator Decorator
        {
            get { return _decorator ?? Table.DefaultHeaderDecorator; }
            set { _decorator = value; }
        }

        private TopTableCellDecorator _cellDecorator;

        public TopTableCellDecorator CellDecorator
        {
            get { return _cellDecorator; }
            set { _cellDecorator = value; }
        }

        public Func<string> TextFunc { get; set; }

        public TopTableHeader(IController hud)
        {
            Hud = hud;
            Cells = new List<TopTableCell>();
            TextFunc = () => string.Empty;
        }

        public void Paint(float x, float y, HorizontalAlign align = HorizontalAlign.Center)
        {
            var decorator = Decorator ?? Table.DefaultCellDecorator;

            decorator.Paint(x, y, Width, Height, TextFunc(), align);
        }
    }
}