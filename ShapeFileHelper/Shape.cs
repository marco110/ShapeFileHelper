using System.Collections.Generic;

namespace ShapeFileHelper {

    public abstract class Shape {

        public List<Point> points = new List<Point>();
        public BoundingBox boundingBox;
        public ShapeType shapeType;

    }
}
