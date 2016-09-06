using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Thinkgeo.ShapeFileHelper
{

    public class BitmapCanvas : Canvas
    {
        private Bitmap bitmap;
        private Graphics g;

        public Bitmap Bitmap { get { return bitmap; } }

        public BitmapCanvas(int width, int height, BoundingBox boundingBox)
            : base(width, height, boundingBox)
        {
            bitmap = new Bitmap(width, height);
            g = Graphics.FromImage(bitmap);
        }

        public BitmapCanvas(int width, int height)
            : base(width, height)
        {
            bitmap = new Bitmap(width, height);
            g = Graphics.FromImage(bitmap);
        }

        public override void DrawPoint(PointShape point, Style style)
        {
            List<PointShape> pointShapes = new List<PointShape>();
            pointShapes.Add(point);
            DrawPoints(pointShapes, style);
        }

        public override void DrawPoints(IEnumerable<PointShape> points, Style style)
        {
            IEnumerable<Point> screenPoints = CoordinateConvertor.ToScreenCoordinates(points, this.Width, this.Height, this.BoundingBox);
            foreach (var screenPoint in screenPoints)
            {
                g.DrawEllipse(new Pen(style.PenColor, style.LineWidth), screenPoint.X, screenPoint.Y, 2, 2);
            }
        }

        public override void DrawBoundingBox(Point startpoint, Point endpoint, Style style)
        {
            Rectangle rectangle = new Rectangle(startpoint.X, startpoint.Y, endpoint.X - startpoint.X, endpoint.Y - startpoint.Y);
            g.DrawRectangle(new Pen(style.PenColor, style.LineWidth), rectangle);
        }

        public override void DrawBoundingBox(BoundingBox boundingBox, Style style)
        {
            Rectangle rectangle = new Rectangle((int)boundingBox.XMin, (int)boundingBox.YMin, (int)boundingBox.Width, (int)boundingBox.Height);
            g.DrawRectangle(new Pen(style.PenColor, style.LineWidth), rectangle);
        }

        public override void DrawPolyline(PolylineShape polyline, Style style)
        {
            List<Point> screenPoints = CoordinateConvertor.ToScreenCoordinates(polyline.Points, this.Width, this.Height, this.BoundingBox);
            g.DrawLines(new Pen(style.PenColor, style.LineWidth), screenPoints.ToArray());
        }

        public override void DrawPolygon(PolygonShape polygon, Style style)
        {
            List<Point> screenPoints = CoordinateConvertor.ToScreenCoordinates(polygon.Points, this.Width, this.Height, this.BoundingBox);
            g.DrawLines(new Pen(style.PenColor, style.LineWidth), screenPoints.ToArray());
        }

        public override void DrawShapes(IEnumerable<Shape> shapes, Style style)
        {
            var groups = shapes.GroupBy(s => s.GetShapeType);
            foreach (var group in groups)
            {
                switch (group.Key)
                {
                    case ShapeType.Point:
                        foreach (PointShape pointShape in group)
                        {
                            DrawPoint(pointShape, style);
                        }
                        break;
                    case ShapeType.Polyline:
                        foreach (PolylineShape polylineshape in group)
                        {
                            DrawPolyline(polylineshape, style);
                        }
                        break;
                    case ShapeType.Polygon:
                        foreach (PolygonShape polygonshape in group)
                        {
                            DrawPolygon(polygonshape, style);
                        }
                        break;
                }
            }
        }
    }
}
