using System.Collections;
using System.Collections.Generic;

namespace ShapeFileHelper {
    public class Polyline : Shape {
        public Polyline(List<Point> points) {
            this.points = points;
            this.shapeType = ShapeType.Polyline;
        }

        public static BoundingBox GetPolylinesBoundingBox(List<Polyline> polylines) {
            BoundingBox boundingBox = new BoundingBox(0, 0, 0, 0);
            double polylineXmin = Point.GetPointsBoundingBox(polylines[0].points).XMin;
            double polylineYmin = Point.GetPointsBoundingBox(polylines[0].points).YMin;
            double polylineXmax = Point.GetPointsBoundingBox(polylines[0].points).XMax;
            double polylineYmax = Point.GetPointsBoundingBox(polylines[0].points).YMax;
            foreach (Polyline polyline in polylines) {
                if (Point.GetPointsBoundingBox(polyline.points).XMin < polylineXmin) { polylineXmin = Point.GetPointsBoundingBox(polyline.points).XMin; }
                if (Point.GetPointsBoundingBox(polyline.points).YMin < polylineYmin) { polylineYmin = Point.GetPointsBoundingBox(polyline.points).YMin; }
                if (Point.GetPointsBoundingBox(polyline.points).XMax > polylineXmax) { polylineXmax = Point.GetPointsBoundingBox(polyline.points).XMax; }
                if (Point.GetPointsBoundingBox(polyline.points).YMax > polylineYmax) { polylineYmax = Point.GetPointsBoundingBox(polyline.points).YMax; }
            }
            boundingBox.XMin = polylineXmin;
            boundingBox.YMin = polylineYmin;
            boundingBox.XMax = polylineXmax;
            boundingBox.YMax = polylineYmax;
            return boundingBox;
        }
    }
}
