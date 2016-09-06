using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Thinkgeo.ShapeFileHelper
{

    public static class CoordinateConvertor
    {

        public static List<Point> ToScreenCoordinates(IEnumerable<PointShape> points, int width, int height, BoundingBox boundingBox)
        {
            List<Point> screenPoints = new List<Point>();
            foreach (PointShape p in points)
            {
                double X = (p.X - boundingBox.XMin) * width / (boundingBox.Width);
                double Y = (boundingBox.YMax - p.Y) * height / (boundingBox.Height);
                Point point = new Point((int)X, (int)Y);
                screenPoints.Add(point);
            }
            return screenPoints;
        }

        public static PointShape ToShapeFileCoordinates(Point point, int width, int height, BoundingBox boundingBox)
        {
            double X = boundingBox.XMin + point.X * boundingBox.Width / width;
            double Y = boundingBox.YMax - boundingBox.Height * point.Y / height;
            PointShape newPoint = new PointShape(X, Y);
            return newPoint;
        }
    }
}