using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace ShapeFileHelper
{
    public class MainFile
    {
        private string fileName, filePath;
        private int fileLength;
        List<Shape> shapes = new List<Shape>();

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        
        public int FileLength
        {
            get { return fileLength; }
            set { fileLength = value; }
        }
        public MainFile(string fileName)
        {
            this.FileName = fileName;
        }
      
        public List<Shape> ReadShapes() 
        {
            using (FileStream File = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(File);
                br.ReadBytes(32);
                int ShapeType = br.ReadInt32();
                br.Close();
                switch (ShapeType)
                {
                    case 1:
                        ReadPoints();
                        break;
                    case 3:
                        ReadPolylines();
                        break;
                    case 5:
                        ReadPolygons();
                        break;
                }
            }
            return shapes;
        }

        public List<Shape> ReadPoints() 
        {
            shapes.Clear();
            using (FileStream File = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(File);
                br.ReadBytes(100);
                shapes.Clear();
                while (br.PeekChar() != -1)
                {                    
                    br.ReadBytes(8);
                    br.ReadInt32();
                    double X = br.ReadDouble();
                    double Y = br.ReadDouble();
                    Point point = new Point(X,Y);
                    shapes.Add(point);
                }
                br.Close();
            }
            return shapes;
        }

        public List<Shape> ReadPolylines() 
        {
            using (FileStream File = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(File);
                br.ReadBytes(100);
                shapes.Clear();
                while (br.PeekChar() != -1)
                {  
                    List<Point> points = new List<Point>();
                    List<Point> newPoints = new List<Point>();
                    br.ReadBytes(44);
                    int Numparts = br.ReadInt32();
                    int Numpoints = br.ReadInt32();
                    for (int i = 0; i < Numparts; i++)
                    {
                       br.ReadInt32();
                    }
                    for (int i = 0; i < Numpoints; i++)
                    {
                        double X = br.ReadDouble();
                        double Y = br.ReadDouble();
                        Point point = new Point(X, Y);
                        points.Add(point);
                    }
                    foreach (var p in points)
                    {
                        Point point = p as Point;
                        if (point != null)
                        {
                            newPoints.Add(point);
                        }
                    }
                    Polyline polyline = new Polyline(newPoints);
                    polyline.points = points;
                    shapes.Add(polyline);
                }
                br.Close();
            }            
            return shapes;
        }

        public List<Shape> ReadPolygons()
        {
            using (FileStream File = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(File);
                br.ReadBytes(100);
                shapes.Clear();
                while (br.PeekChar() != -1)
                {                  
                    List<Point> points = new List<Point>();
                    List<Point> newPoints = new List<Point>();
                    br.ReadBytes(44);
                    int Numparts = br.ReadInt32();
                    int Numpoints = br.ReadInt32();
                    for (int i = 0; i < Numparts; i++)
                    {
                        br.ReadInt32();
                    }
                    for (int i = 0; i < Numpoints; i++)
                    {
                        double X = br.ReadDouble();
                        double Y = - br.ReadDouble();
                        Point point = new Point(X, Y);
                        points.Add(point);
                    }
                    foreach (var p in points)
                    {
                        Point point = p as Point;
                        if (point != null)
                        {
                            newPoints.Add(point);
                        }
                    }
                    Polygon polygon = new Polygon(newPoints);
                    polygon.points = points;
                    shapes.Add(polygon);
                }
                br.Close();
            }
            return shapes;
        }

        public void Write() { }
    }
}
