using System.Collections.Generic;

namespace ShapeFileHelper
{
    public abstract class Shape
    {
        public List<Point> points = new List<Point>();
        public BoundingBox newBoundingBox;        
        public ShapeType ShapeType;

        /*public static BoundingBox GetShapesBoundingBox(List<Shape> shapes)
        {
            BoundingBox boundingBox = new BoundingBox(0, 0, 0, 0);
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
                    boundingBox = Point.GetPointsBoundingBox(points);
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
                    boundingBox = Polyline.GetPolylinesBoundingBox(polylines);
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
                    boundingBox = Polygon.GetPolygonsBoundingBox(polygons);
                    break;
            }
            return boundingBox;
        }      */ 
    }
}
