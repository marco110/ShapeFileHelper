using System.Collections.Generic;

namespace Thinkgeo.ShapeFileHelper
{
    public abstract class Shape
    {
        public abstract ShapeType GetShapeType
        {
            get;
        }
        public abstract BoundingBox GetBoundingBox();
        public abstract bool Intersects(Shape targetShape, BoundingBox boundingBox);
        public abstract bool Contains(Shape targetShape, BoundingBox boundingBox);
    }
}
