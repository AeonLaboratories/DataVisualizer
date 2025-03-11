using System;
using System.Collections.Generic;
using System.Drawing;

namespace Data_Visualizer
{
    public class Series
    {
        public string Name { get; set; }

        public Pen Pen { get; set; }

        public bool IsVisible { get; set; } = true;

        List<WorldPoint> data = [];
        public IReadOnlyList<WorldPoint> Data => data.AsReadOnly();

        public double xMin { get; protected set; }
        public double xMax { get; protected set; }
        public double yMin { get; protected set; }
        public double yMax { get; protected set; }

        public void Add(WorldPoint wp)
        {
            if (Data.Count == 0)
            {
                xMin = xMax = wp.X;
                yMin = yMax = wp.Y;
            }
            else
            {
                xMin = Math.Min(xMin, wp.X);
                xMax = Math.Max(xMax, wp.X);
                yMin = Math.Min(yMin, wp.Y);
                yMax = Math.Max(yMax, wp.Y);
            }
            data.Add(wp);
        }
    }
}
