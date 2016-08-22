using System.Collections.Generic;
namespace ShapeFileHelper
{
    public class Point : Shape
    {
        private double x;
        private double y;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point(double X,double Y)
        {
            this.X = X;
            this.Y = Y;
            this.ShapeType = ShapeType.Point;
        }

        public static BoundingBox GetPointsBoundingBox(List<Point> points)
        {
            BoundingBox boundingBox = new BoundingBox(0, 0, 0, 0);
            double pointXmin = points[0].X, pointXmax = points[0].X, pointYmin = points[0].Y, pointYmax = points[0].Y;
            foreach (Point point in points)
            {
                if (point.X < pointXmin) { pointXmin = point.X; }
                if (point.Y < pointYmin) { pointYmin = point.Y; }
                if (point.X > pointXmax) { pointXmax = point.X; }
                if (point.Y > pointYmax) { pointYmax = point.Y; }
            }
            boundingBox.XMin = pointXmin;
            boundingBox.YMin = pointYmin;
            boundingBox.XMax = pointXmax;
            boundingBox.YMax = pointYmax;
            return boundingBox;
        }

    }
}
