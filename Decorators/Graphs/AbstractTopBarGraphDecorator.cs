using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Turbo.Plugins.Jack.Decorators.Graphs
{
    public interface ITopBarGraphDecorator
    {
        bool Enabled { get; set; }

        void AddData();

        void Paint();
    }

    public abstract class AbstractTopBarGraphDecorator<T> : ITopBarGraphDecorator
    {
        public WorldLayer Layer { get; private set; }
        public IController Hud { get; private set; }
        public bool Enabled { get; set; }

        public IBrush BarBrush { get; set; }
        public IBrush BackgroundBrush { get; set; }

        public Func<T> GetData { get; set; }

        public T ForcedMax { get; set; }

        private List<T> data;

        private ushort maxEntries;

        public ushort MaxEntries
        {
            get { return maxEntries; }
            set { maxEntries = value; }
        }

        public float X { get; set; }
        public float Y { get; set; }

        public float Height { get; set; }

        public ushort Width
        {
            get { return maxEntries; }
            set { maxEntries = value; }
        }

        protected AbstractTopBarGraphDecorator(IController hud)
        {
            Enabled = true;
            Hud = hud;
            Layer = WorldLayer.Ground;
            BackgroundBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 0);

            Height = 100;
            maxEntries = Width = 250; //1px by bar for testing.

            data = new List<T>(maxEntries);
        }

        public void AddData(T value)
        {
            if (data.Count >= maxEntries)
            {
                data = data.Skip(Math.Max(0, data.Count() - maxEntries + 1)).ToList();
            }

            data.Add(value);
        }

        public void AddData()
        {
            if (null == GetData) return;

            AddData(GetData.Invoke());
        }

        public void Paint()
        {
            Paint(X, Y);
        }

        public void Paint(float x, float y)
        {
            if (!Enabled) return;
            if (BarBrush == null) return;
            if (data.Count == 0) return;

            using (var pg = Hud.Render.CreateGeometry())
            {
                using (var gs = pg.Open())
                {
                    BackgroundBrush.DrawRectangle(x, y, Width, Height);

                    var max = Equals(ForcedMax, 0) ? data.Max() : ForcedMax;
                    var startPoint = new Vector2(x, y);
                    gs.BeginFigure(startPoint, FigureBegin.Filled);

                    var vect = new Vector2(x, y + Height);
                    gs.AddLine(vect);

                    for (var xx = 0; xx < data.Count; xx++)
                    {
                        var yy = Height * GetHeight(data[xx], max);

                        if (yy < 0)
                        {
                            yy = 0;
                        }

                        vect = new Vector2(x + xx, y + Height - yy);
                        gs.AddLine(vect);
                    }

                    gs.AddLine(new Vector2(x + data.Count - 1, y + Height));
                    gs.AddLine(new Vector2(x, y + Height));

                    gs.EndFigure(FigureEnd.Closed);
                    gs.Close();
                }
                BarBrush.DrawGeometry(pg);
            }
        }

        protected abstract float GetHeight(T entry, T max);

        protected abstract bool Equals(T lastEntry, T entry);
    }
}