using System.Collections;
using System.Collections.Generic;

namespace ShapeFileHelper {
    public class Polygon : Shape {
        public Polygon(List<Point> points) {
            this.points = points;
            this.shapeType = ShapeType.Polygon;
        }

        public static BoundingBox GetPolygonsBoundingBox(List<Polygon> polygons) {
            BoundingBox boundingBox = new BoundingBox(0, 0, 0, 0);
            double polygonXmin = Point.GetPointsBoundingBox(polygons[0].points).XMin;
            double polygonYmin = Point.GetPointsBoundingBox(polygons[0].points).YMin;
            double polygonXmax = Point.GetPointsBoundingBox(polygons[0].points).XMax;
            double polygonYmax = Point.GetPointsBoundingBox(polygons[0].points).YMax;
            foreach (Polygon polygon in polygons) {
                if (Point.GetPointsBoundingBox(polygon.points).XMin < polygonXmin) { polygonXmin = Point.GetPointsBoundingBox(polygon.points).XMin; }
                if (Point.GetPointsBoundingBox(polygon.points).YMin < polygonYmin) { polygonYmin = Point.GetPointsBoundingBox(polygon.points).YMin; }
                if (Point.GetPointsBoundingBox(polygon.points).XMax > polygonXmax) { polygonXmax = Point.GetPointsBoundingBox(polygon.points).XMax; }
                if (Point.GetPointsBoundingBox(polygon.points).YMax > polygonYmax) { polygonYmax = Point.GetPointsBoundingBox(polygon.points).YMax; }
            }
            boundingBox.XMin = polygonXmin;
            boundingBox.YMin = polygonYmin;
            boundingBox.XMax = polygonXmax;
            boundingBox.YMax = polygonYmax;
            return boundingBox;
        }
    }
}
