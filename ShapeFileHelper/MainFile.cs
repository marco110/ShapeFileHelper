using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace ShapeFileHelper {

    public class MainFile {

        List<Shape> shapes = new List<Shape>();

        public string FilePath { get; set; }

        public string FileName { get; set; }

        public int FileLength { get; set; }

        public MainFile(string fileName) {
            this.FileName = fileName;
        }

        public List<Shape> ReadShapes() {
            using (FileStream File = new FileStream(FileName, FileMode.Open)) {
                BinaryReader br = new BinaryReader(File);
                br.ReadBytes(32);
                int ShapeType = br.ReadInt32();
                br.Close();
                switch (ShapeType) {
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

        public List<Shape> ReadPoints() {
            shapes.Clear();
            using (FileStream File = new FileStream(FileName, FileMode.Open)) {
                BinaryReader br = new BinaryReader(File);
                br.ReadBytes(100);
                shapes.Clear();
                while (br.PeekChar() != -1) {
                    br.ReadBytes(8);
                    br.ReadInt32();
                    double X = br.ReadDouble();
                    double Y = br.ReadDouble();
                    Point point = new Point(X, Y);
                    shapes.Add(point);
                }
                br.Close();
            }
            return shapes;
        }

        public List<Shape> ReadPolylines() {
            using (FileStream File = new FileStream(FileName, FileMode.Open)) {
                BinaryReader br = new BinaryReader(File);
                br.ReadBytes(100);
                shapes.Clear();
                while (br.PeekChar() != -1) {
                    List<Point> points = new List<Point>();
                    br.ReadBytes(44);
                    int Numparts = br.ReadInt32();
                    int Numpoints = br.ReadInt32();
                    int[] a = new int[Numparts];
                    for (int i = 0; i < Numparts; i++) {
                        a[i] = br.ReadInt32();
                    }
                    for (int i = 0; i < Numpoints; i++) {
                        double X = br.ReadDouble();
                        double Y = -br.ReadDouble();
                        Point point = new Point(X, Y);
                        points.Add(point);
                    }
                    for (int i = 0; i < Numparts; i++) {
                        List<Point> newPoints = new List<Point>();
                        int startpoint, endpoint;
                        if (i != Numparts - 1) {
                            startpoint = (int)a[i];
                            endpoint = (int)a[i + 1];
                        }
                        else {
                            startpoint = (int)a[i];
                            endpoint = Numpoints;
                        }
                        for (int k = 0, j = startpoint; j < endpoint; j++, k++) {
                            newPoints.Add(points[j]);
                        }
                        Polyline polyline = new Polyline(newPoints);
                        polyline.points = points;
                        shapes.Add(polyline);
                    }
                }
                br.Close();
            }
            return shapes;
        }

        public List<Shape> ReadPolygons() {
            using (FileStream File = new FileStream(FileName, FileMode.Open)) {
                BinaryReader br = new BinaryReader(File);
                br.ReadBytes(100);
                shapes.Clear();
                while (br.PeekChar() != -1) {
                    List<Point> points = new List<Point>();
                    br.ReadBytes(44);
                    int Numparts = br.ReadInt32();
                    int Numpoints = br.ReadInt32();
                    int[] a = new int[Numparts];
                    for (int i = 0; i < Numparts; i++) {
                        a[i] = br.ReadInt32();
                    }
                    for (int i = 0; i < Numpoints; i++) {
                        double X = br.ReadDouble();
                        double Y = -br.ReadDouble();
                        Point point = new Point(X, Y);
                        points.Add(point);
                    }
                    for (int i = 0; i < Numparts; i++) {
                        List<Point> newPoints = new List<Point>();
                        int startpoint, endpoint;
                        if (i != Numparts - 1) {
                            startpoint = (int)a[i];
                            endpoint = (int)a[i + 1];
                        }
                        else {
                            startpoint = (int)a[i];
                            endpoint = Numpoints;
                        }
                        for (int k = 0, j = startpoint; j < endpoint; j++, k++) {
                            newPoints.Add(points[j]);
                        }
                        Polygon polygon = new Polygon(newPoints);
                        polygon.points = newPoints;
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
