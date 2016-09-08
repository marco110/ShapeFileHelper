using System.Collections.Generic;

namespace ShapeFileHelper
{
    public class PointShape : Shape
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


        public PointShape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override ShapeType ShapeType
        {
            get
            {
                return ShapeType.Point;
            }
        }

        public override BoundingBox GetBoundingBox()
        {
            double e = 0.0000001;
            return new BoundingBox(this.x - e, this.x + e, this.y - e, this.y + e);
        }

        public override bool Intersects(Shape targetShape, BoundingBox boundingBox)
        {
            PointShape point = targetShape as PointShape;
            if (point.x >= boundingBox.XMin && point.x <= boundingBox.XMax && point.y >= boundingBox.YMin && point.y <= boundingBox.YMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Contains(Shape targetShape, BoundingBox boundingBox)
        {
            throw new System.NotImplementedException();
        }
    }
}
