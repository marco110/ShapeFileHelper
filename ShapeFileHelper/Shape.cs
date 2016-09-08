using System.Collections.Generic;

namespace ShapeFileHelper
{
    public abstract class Shape
    {
        public abstract ShapeType ShapeType { get; }
        public abstract BoundingBox GetBoundingBox();
        public abstract bool Intersects(Shape targetShape, BoundingBox boundingBox);
        public abstract bool Contains(Shape targetShape, BoundingBox boundingBox);
    }
}
