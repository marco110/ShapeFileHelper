using System.Drawing;
using System.Collections.Generic;

namespace Thinkgeo.ShapeFileHelper
{
    public abstract class Canvas
    {
        public BoundingBox BoundingBox { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        protected Canvas(int width, int height, BoundingBox boundingBox)
        {
            this.Width = width;
            this.Height = height;
            this.BoundingBox = boundingBox;
        }

        protected Canvas(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract void DrawPoint(PointShape point, Style style);

        public abstract void DrawPoints(IEnumerable<PointShape> points, Style style);

        public abstract void DrawBoundingBox(Point startpoint, Point endpoint, Style style);

        public abstract void DrawBoundingBox(BoundingBox boundingBox, Style style);

        public abstract void DrawPolyline(PolylineShape polyline, Style style);

        public abstract void DrawPolygon(PolygonShape polygon, Style style);

        public abstract void DrawShapes(IEnumerable<Shape> shapes, Style style);
    }
}
