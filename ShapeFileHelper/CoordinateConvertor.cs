using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ShapeFileHelper {
    public static class CoordinateConvertor {
        public static List<Point> ConvertPointsToScreen(List<Point> points, BitmapCanvas canvas) {
            List<Point> newPoints = new List<Point>();
            BoundingBox boundingBox = Point.GetPointsBoundingBox(points);
            var bitmap = canvas.GetBitmap();
            foreach (Point p in points) {
                double X = (p.X - boundingBox.XMin) * (bitmap.Width / (boundingBox.XMax - boundingBox.XMin));
                double Y = (p.Y - boundingBox.YMin) * (bitmap.Height / (boundingBox.YMax - boundingBox.YMin));
                Point point = new Point(X, Y);
                newPoints.Add(point);
            }
            return newPoints;
        }

        public static List<Polyline> ConvertPolylinesToScreen(List<Polyline> polylines, BitmapCanvas canvas) {
            List<Polyline> newPolylines = new List<Polyline>();
            var bitmap = canvas.GetBitmap();
            BoundingBox boundingBox = Polyline.GetPolylinesBoundingBox(polylines);
            for (int i = 0; i < polylines.Count; i++) {
                List<Point> newPoints = new List<Point>();
                foreach (Point p in polylines[i].points) {
                    double X = (float)(p.X - boundingBox.XMin) * (bitmap.Width / (boundingBox.XMax - boundingBox.XMin));
                    double Y = (float)(p.Y - boundingBox.YMin) * (bitmap.Height / (boundingBox.YMax - boundingBox.YMin));
                    Point point = new Point(X, Y);
                    newPoints.Add(point);
                }
                Polyline polyline = new Polyline(newPoints);
                newPolylines.Add(polyline);
            }
            return newPolylines;
        }

        public static List<Polygon> ConvertPolygonsToScreen(List<Polygon> polygons, BitmapCanvas canvas) {
            List<Polygon> newPolygons = new List<Polygon>();
            var bitmap = canvas.GetBitmap();
            BoundingBox boundingBox = Polygon.GetPolygonsBoundingBox(polygons);
            for (int i = 0; i < polygons.Count; i++) {
                List<Point> newPoints = new List<Point>();
                foreach (Point p in polygons[i].points) {
                    double X = (float)(p.X - boundingBox.XMin) * (bitmap.Width / (boundingBox.XMax - boundingBox.XMin));
                    double Y = (float)(p.Y - boundingBox.YMin) * (bitmap.Height / (boundingBox.YMax - boundingBox.YMin));
                    Point point = new Point(X, Y);
                    newPoints.Add(point);
                }
                Polygon polygon = new Polygon(newPoints);
                newPolygons.Add(polygon);
            }
            return newPolygons;
        }

        public static List<Shape> ConvertShapesToScreen(List<Shape> shapes, BitmapCanvas canvas) {
            List<Shape> newShapes = new List<Shape>();
            switch (shapes[0].shapeType) {
                case ShapeType.Point:
                    List<Point> points = new List<Point>();
                    foreach (var point in shapes) {
                        Point p = point as Point;
                        points.Add(p);
                    }
                    var pointList = ConvertPointsToScreen(points, canvas);
                    foreach (var point in pointList) {
                        newShapes.Add(point);
                    }
                    break;
                case ShapeType.Polyline:
                    List<Polyline> polylines = new List<Polyline>();
                    foreach (var polyline in shapes) {
                        Polyline p = polyline as Polyline;
                        polylines.Add(p);
                    }
                    var polylineList = ConvertPolylinesToScreen(polylines, canvas);
                    foreach (var polyline in polylineList) {
                        newShapes.Add(polyline);
                    }
                    break;
                case ShapeType.Polygon:
                    List<Polygon> polygons = new List<Polygon>();
                    foreach (var polygon in shapes) {
                        Polygon p = polygon as Polygon;
                        polygons.Add(p);
                    }
                    var polygonList = ConvertPolygonsToScreen(polygons, canvas);
                    foreach (var polygon in polygonList) {
                        newShapes.Add(polygon);
                    }
                    break;
            }
            return newShapes;
        }
    }
}
