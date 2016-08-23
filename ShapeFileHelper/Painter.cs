using System;
using System.Drawing;
using System.Collections.Generic;

namespace ShapeFileHelper
{
    public class Painter
    {       
        public Style Style;        
        public BitmapCanvas Canvas;
               
        public Painter(BitmapCanvas canvas, Style style)
        {
            this.Style = style;
            this.Canvas = canvas;
        }

        public void DrawBoundingBox(BoundingBox boundingBox)
        {
            
            var bitmap = Canvas.GetBitmap();
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.Transparent);
            Rectangle Rectangle = new Rectangle();
            Rectangle = new Rectangle(Math.Min((int)boundingBox.XMin, (int)boundingBox.XMax), Math.Min((int)boundingBox.YMin, (int)boundingBox.YMax),
                Math.Max((int)boundingBox.XMin, (int)boundingBox.XMax) - Math.Min((int)boundingBox.XMin, (int)boundingBox.XMax),
                Math.Max((int)boundingBox.YMin, (int)boundingBox.YMax) - Math.Min((int)boundingBox.YMin, (int)boundingBox.YMax));
            g.DrawRectangle(new Pen(Style.PenColor, 1), Rectangle);
        }

        public void DrawPoints(List<Point> points)
        {            
            var bitmap = Canvas.GetBitmap();
            foreach (Point p in points)
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawEllipse(new Pen(Style.PenColor, Style.PenWidth), (float)p.X, (float)p.Y, 3, 3);                
            }
        }

        public void DrawPolylines(List<Polyline> polylines)
        {
            var bitmap = Canvas.GetBitmap();
            List<Point> points = new List<Point>();
            for (int i = 0; i < polylines.Count; i++)
            {
                PointF[] newPoint = new PointF[polylines[i].points.Count];
                for (int j = 0; j < polylines[i].points.Count; j++)
                {
                    newPoint[j].X = (float)(polylines[i].points[j].X);
                    newPoint[j].Y = (float)(polylines[i].points[j].Y);
                }
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawLines(new Pen(Style.PenColor, Style.PenWidth), newPoint);
            }
        }

        public void DrawPolygons(List<Polygon> polygons)
        {
            var bitmap = Canvas.GetBitmap();
            List<Point> points = new List<Point>();
            for (int i = 0; i < polygons.Count; i++)
            {
                PointF[] newPoint = new PointF[polygons[i].points.Count];
                for (int j = 0; j < polygons[i].points.Count; j++)
                {
                    newPoint[j].X = (float)(polygons[i].points[j].X);
                    newPoint[j].Y = (float)(polygons[i].points[j].Y);
                }
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawPolygon(new Pen(Style.PenColor, Style.PenWidth), newPoint);
            }
        }

        public void DrawShapes(List<Shape> shapes)
        {
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
                        DrawPoints(points);
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
                        DrawPolylines(polylines);
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
                        DrawPolygons(polygons);
                        break;
                }
            }
        }
    }
}
