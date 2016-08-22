using System;
using System.Collections.Generic;

namespace ShapeFileHelper
{
    public class SplitTool
    {
        public List<List<Shape>> SplitShapes(BoundingBox boundingBox, List<Shape> shapes, Canvas canvas)
        {
            List<List<Shape>> newShapes = new List<List<Shape>>();
            if (shapes.Count != 0)
            {
                switch (shapes[0].ShapeType)
                {
                    case ShapeType.Point:
                        List<Point> points = new List<Point>();
                        foreach (var point in shapes)
                        {
                            Point p = point as Point;
                            if (p != null)
                            {
                                points.Add(p);
                            }
                        }
                        var pointList = SplitPoints(boundingBox, points, canvas);
                        List<Shape> ps = new List<Shape>();
                        foreach (var point in pointList[0])
                        {
                            ps.Add(point);
                        }
                        List<Shape> ps1 = new List<Shape>();
                        foreach (var point in pointList[1])
                        {
                            ps1.Add(point);
                        }
                        newShapes.Add(ps);
                        newShapes.Add(ps1);
                        break;
                    case ShapeType.Polyline:
                        List<Polyline> polylines = new List<Polyline>();
                        foreach (var polyline in shapes)
                        {
                            Polyline p = polyline as Polyline;
                            if (p != null)
                            {
                                polylines.Add(p);
                            }
                        }
                        var polylineList = SplitPolylines(boundingBox, polylines, canvas);
                        List<Shape> ps2 = new List<Shape>();
                        foreach (var point in polylineList[0])
                        {
                            ps2.Add(point);
                        }
                        List<Shape> ps3 = new List<Shape>();
                        foreach (var point in polylineList[1])
                        {
                            ps3.Add(point);
                        }
                        newShapes.Add(ps2);
                        newShapes.Add(ps3);
                        break;
                    case ShapeType.Polygon:
                        List<Polygon> polygons = new List<Polygon>();
                        foreach (var polygon in shapes)
                        {
                            Polygon p = polygon as Polygon;
                            if (p != null)
                            {
                                polygons.Add(p);
                            }
                        }
                        var polygonList = SplitPolygons(boundingBox, polygons, canvas);
                        List<Shape> ps4 = new List<Shape>();
                        foreach (var point in polygonList[0])
                        {
                            ps4.Add(point);
                        }
                        List<Shape> ps5 = new List<Shape>();
                        foreach (var point in polygonList[1])
                        {
                            ps5.Add(point);
                        }
                        newShapes.Add(ps4);
                        newShapes.Add(ps5);
                        break;
                }
            }
            return newShapes;
        }

        public List<List<Point>> SplitPoints(BoundingBox boundingBox, List<Point> pointList, Canvas canvas)
        {
            List<List<Point>> points = new List<List<Point>>();
            List<Point> inBox = new List<Point>();
            List<Point> outBox = new List<Point>();
            foreach (Point point in pointList)
            {
                if ((point.X) > Math.Min((int)boundingBox.XMin, (int)boundingBox.XMax) &&
                    (point.X) < Math.Max((int)boundingBox.XMin, (int)boundingBox.XMax) &&
                    (point.Y) > Math.Min((int)boundingBox.YMin, (int)boundingBox.YMax) &&
                    (point.Y) < Math.Max((int)boundingBox.YMin, (int)boundingBox.YMax))
                {
                    inBox.Add(point);
                }
                else
                {
                    outBox.Add(point);
                }
            }
            points.Add(inBox);
            points.Add(outBox);
            return points;
        }

        public List<List<Polyline>> SplitPolylines(BoundingBox boundingBox, List<Polyline> polylineList, Canvas canvas)
        {
            List<List<Polyline>> polylines = new List<List<Polyline>>();
            List<Polyline> inBox = new List<Polyline>();
            List<Polyline> outBox = new List<Polyline>();
            foreach (Polyline polyline in polylineList)
            {
                var polylineBounding = Point.GetPointsBoundingBox(polyline.points);
                if (polylineBounding.XMin > Math.Min((int)boundingBox.XMin, (int)boundingBox.XMax) &&
                        (polylineBounding.XMin) < Math.Max((int)boundingBox.XMin, (int)boundingBox.XMax) &&
                    (polylineBounding.YMin) > Math.Min((int)boundingBox.YMin, (int)boundingBox.YMax) &&
                    (polylineBounding.YMin) < Math.Max((int)boundingBox.YMin, (int)boundingBox.YMax))
                {
                    inBox.Add(polyline);
                }
                else
                {
                    outBox.Add(polyline);
                }
            }
            polylines.Add(inBox);
            polylines.Add(outBox);
            return polylines;
        }

        public List<List<Polygon>> SplitPolygons(BoundingBox boundingBox, List<Polygon> polygonList, Canvas canvas)
        {
            List<List<Polygon>> polygons = new List<List<Polygon>>();
            List<Polygon> inBox = new List<Polygon>();
            List<Polygon> outBox = new List<Polygon>();
            foreach (Polygon polygon in polygonList)
            {
                var polygonBounding = Point.GetPointsBoundingBox(polygon.points);
                if (polygonBounding.XMin > Math.Min((int)boundingBox.XMin, (int)boundingBox.XMax) &&
                        (polygonBounding.XMin) < Math.Max((int)boundingBox.XMin, (int)boundingBox.XMax) &&
                    (polygonBounding.YMin) > Math.Min((int)boundingBox.YMin, (int)boundingBox.YMax) &&
                    (polygonBounding.YMin) < Math.Max((int)boundingBox.YMin, (int)boundingBox.YMax))
                {
                    inBox.Add(polygon);
                }
                else
                {
                    outBox.Add(polygon);
                }
            }
            polygons.Add(inBox);
            polygons.Add(outBox);
            return polygons;
        }
    }
}
