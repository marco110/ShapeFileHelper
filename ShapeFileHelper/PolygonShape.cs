using System.Collections;
using System.Collections.Generic;

namespace Thinkgeo.ShapeFileHelper
{

    public class PolygonShape : Shape
    {
        private List<PointShape> points;

        public List<PointShape> Points
        {
            get { return points; }
        }

        public PolygonShape()
        {
            this.points = new List<PointShape>();
        }

        public override ShapeType GetShapeType
        {
            get
            {
                return ShapeType.Polygon;
            }
        }

        public override BoundingBox GetBoundingBox()
        {
            double xMin = double.MaxValue;
            double xMax = double.MinValue;
            double yMin = double.MaxValue;
            double yMax = double.MinValue;

            foreach (var point in this.points)
            {
                if (point.X < xMin)
                {
                    xMin = point.X;
                }
                if (point.X > xMax)
                {
                    xMax = point.X;
                }
                if (point.Y < yMin)
                {
                    yMin = point.Y;
                }
                if (point.Y > yMax)
                {
                    yMax = point.Y;
                }
            }
            return new BoundingBox(xMin, xMax, yMin, yMax);
        }

        public override bool Intersects(Shape targetShape, BoundingBox boundingBox)
        {
            bool intersects = false;
            PolygonShape polygon = targetShape as PolygonShape;
            for (int i = 0; i < polygon.points.Count; i++)
            {
                if (polygon.points[i].Intersects(polygon.points[i], boundingBox))
                {
                    intersects = true;
                    break;
                }
            }
            return intersects;
        }

        public override bool Contains(Shape targetShape, BoundingBox boundingBox)
        {
            throw new System.NotImplementedException();
        }
    }
}
