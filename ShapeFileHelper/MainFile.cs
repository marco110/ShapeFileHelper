using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace ShapeFileHelper
{

    public class MainFile
    {
        public string FilePath { get; set; }

        public string FileName { get; set; }

        public int FileLength { get; set; }

        public MainFile(string fileName)
        {
            this.FileName = fileName;
        }

        public BoundingBox GetBoundingBox()
        {
            using (FileStream file = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(file);
                br.ReadBytes(36);
                double xMin = br.ReadDouble();
                double yMin = br.ReadDouble();
                double xMax = br.ReadDouble();
                double yMax = br.ReadDouble();
                br.Close();
                return new BoundingBox(xMin, yMin, xMax, yMax);
            }
        }

        public List<Shape> ReadShapes()
        {
            List<Shape> shapes = new List<Shape>();
            using (FileStream file = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(file);
                br.ReadBytes(32);
                int shapeType = br.ReadInt32();
                br.Close();
                switch (shapeType)
                {
                    case 1:
                        var pointShapes = ReadPoints();
                        foreach (var point in pointShapes)
                        {
                            shapes.Add(point);
                        }
                        break;
                    case 3:
                        var polylineShapes = ReadPolylines();
                        foreach (var polyline in polylineShapes)
                        {
                            shapes.Add(polyline);
                        }
                        break;
                    case 5:
                        var polygonShapes = ReadPolygons();
                        foreach (var polygon in polygonShapes)
                        {
                            shapes.Add(polygon);
                        }
                        break;
                }
            }
            return shapes;
        }

        public List<PointShape> ReadPoints()
        {
            List<PointShape> shapes = new List<PointShape>();
            using (FileStream file = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(file);
                br.ReadBytes(100);
                while (br.PeekChar() != -1)
                {
                    br.ReadBytes(12);
                    double X = br.ReadDouble();
                    double Y = br.ReadDouble();
                    PointShape point = new PointShape(X, Y);
                    shapes.Add(point);
                }
                br.Close();
            }
            return shapes;
        }

        public List<PolylineShape> ReadPolylines()
        {
            List<PolylineShape> shapes = new List<PolylineShape>();
            using (FileStream file = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(file);
                br.ReadBytes(100);
                while (br.PeekChar() != -1)
                {
                    List<PointShape> points = new List<PointShape>();
                    br.ReadBytes(44);
                    int numParts = br.ReadInt32();
                    int numPoints = br.ReadInt32();
                    int[] newNumParts = new int[numParts];
                    for (int i = 0; i < numParts; i++)
                    {
                        newNumParts[i] = br.ReadInt32();
                    }
                    for (int i = 0; i < numPoints; i++)
                    {
                        double X = br.ReadDouble();
                        double Y = br.ReadDouble();
                        PointShape point = new PointShape(X, Y);
                        points.Add(point);
                    }
                    for (int i = 0; i < numParts; i++)
                    {
                        PolylineShape polyline = new PolylineShape();
                        int startpoint, endpoint;
                        if (i != numParts - 1)
                        {
                            startpoint = (int)newNumParts[i];
                            endpoint = (int)newNumParts[i + 1];
                        }
                        else
                        {
                            startpoint = (int)newNumParts[i];
                            endpoint = numPoints;
                        }
                        for (int j = startpoint; j < endpoint; j++)
                        {
                            polyline.Points.Add(points[j]);
                        }
                        shapes.Add(polyline);
                    }
                }
                br.Close();
            }
            return shapes;
        }

        public List<PolygonShape> ReadPolygons()
        {
            List<PolygonShape> shapes = new List<PolygonShape>();
            using (FileStream file = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(file);
                br.ReadBytes(100);
                while (br.PeekChar() != -1)
                {
                    List<PointShape> points = new List<PointShape>();
                    br.ReadBytes(44);
                    int numParts = br.ReadInt32();
                    int numPoints = br.ReadInt32();
                    int[] newNumParts = new int[numParts];
                    for (int i = 0; i < numParts; i++)
                    {
                        newNumParts[i] = br.ReadInt32();
                    }
                    for (int i = 0; i < numPoints; i++)
                    {
                        double X = br.ReadDouble();
                        double Y = br.ReadDouble();
                        PointShape point = new PointShape(X, Y);
                        points.Add(point);
                    }

                    for (int i = 0; i < numParts; i++)
                    {
                        PolygonShape polygon = new PolygonShape();
                        int startpoint, endpoint;
                        if (i != numParts - 1)
                        {
                            startpoint = (int)newNumParts[i];
                            endpoint = (int)newNumParts[i + 1];
                        }
                        else
                        {
                            startpoint = (int)newNumParts[i];
                            endpoint = numPoints;
                        }
                        for (int j = startpoint; j < endpoint; j++)
                        {
                            polygon.Points.Add(points[j]);
                        }
                        shapes.Add(polygon);
                    }
                }
                br.Close();
            }
            return shapes;
        }

        public void WriteMainFile() { }

        public void SaveMainFile() { }
    }
}
