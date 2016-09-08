using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ShapeFileHelper
{

    public static class SplitTool
    {

        public static List<List<Shape>> SplitShapes(BoundingBox boundingBox, IEnumerable<Shape> shapes)
        {
            List<List<Shape>> newShapes = new List<List<Shape>>();
            List<Shape> outBox = new List<Shape>();
            List<Shape> inBox = new List<Shape>();
            var groups = shapes.GroupBy(s => s.ShapeType);
            foreach (var group in groups)
            {
                switch (group.Key)
                {
                    case ShapeType.Point:
                        List<PointShape> points = new List<PointShape>();
                        foreach (PointShape point in group)
                        {
                            points.Add(point);
                        }
                        var pointList = SplitPoints(boundingBox, points);
                        foreach (var point in pointList[0])
                        {
                            inBox.Add(point);
                        }
                        foreach (var point in pointList[1])
                        {
                            outBox.Add(point);
                        }
                        newShapes.Add(inBox);
                        newShapes.Add(outBox);
                        break;
                    case ShapeType.Polyline:
                        List<PolylineShape> polylines = new List<PolylineShape>();
                        foreach (PolylineShape polyline in group)
                        {
                            polylines.Add(polyline);
                        }
                        var polylineList = SplitPolylines(boundingBox, polylines);
                        foreach (var point in polylineList[0])
                        {
                            inBox.Add(point);
                        }
                        foreach (var point in polylineList[1])
                        {
                            outBox.Add(point);
                        }
                        newShapes.Add(inBox);
                        newShapes.Add(outBox);
                        break;
                    case ShapeType.Polygon:
                        List<PolygonShape> polygons = new List<PolygonShape>();
                        foreach (PolygonShape polygon in group)
                        {
                            polygons.Add(polygon);
                        }
                        var polygonList = SplitPolygons(boundingBox, polygons);
                        foreach (var point in polygonList[0])
                        {
                            inBox.Add(point);
                        }
                        foreach (var point in polygonList[1])
                        {
                            outBox.Add(point);
                        }
                        newShapes.Add(inBox);
                        newShapes.Add(outBox);
                        break;
                }
            }
            return newShapes;
        }

        public static List<List<PointShape>> SplitPoints(BoundingBox boundingBox, IEnumerable<PointShape> pointList)
        {
            List<List<PointShape>> points = new List<List<PointShape>>();
            List<PointShape> inBox = new List<PointShape>();
            List<PointShape> outBox = new List<PointShape>();
            foreach (PointShape point in pointList)
            {
                if (point.Intersects(point, boundingBox))
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

        public static List<List<PolylineShape>> SplitPolylines(BoundingBox boundingBox, IEnumerable<PolylineShape> polylineList)
        {
            List<List<PolylineShape>> polylines = new List<List<PolylineShape>>();
            List<PolylineShape> inBox = new List<PolylineShape>();
            List<PolylineShape> outBox = new List<PolylineShape>();
            foreach (PolylineShape polyline in polylineList)
            {
                if (polyline.Intersects(polyline, boundingBox))
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

        public static List<List<PolygonShape>> SplitPolygons(BoundingBox boundingBox, IEnumerable<PolygonShape> polygonList)
        {
            List<List<PolygonShape>> polygons = new List<List<PolygonShape>>();
            List<PolygonShape> inBox = new List<PolygonShape>();
            List<PolygonShape> outBox = new List<PolygonShape>();
            foreach (PolygonShape polygon in polygonList)
            {
                if (polygon.Intersects(polygon, boundingBox))
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
