using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Thinkgeo.ShapeFileHelper {

    public class MainFile {

        List<Shape> shapes = new List<Shape>();

        public string FilePath { get; set; }

        public string FileName { get; set; }

        public int FileLength { get; set; }

        public MainFile(string fileName) {
            this.FileName = fileName;
        }

        public List<Shape> ReadShapes() {
            using (FileStream file = new FileStream(FileName, FileMode.Open)) {
                BinaryReader br = new BinaryReader(file);
                br.ReadBytes(32);
                int shapeType = br.ReadInt32();
                br.Close();
                switch (shapeType) {
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
            using (FileStream file = new FileStream(FileName, FileMode.Open)) {
                BinaryReader br = new BinaryReader(file);
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
            using (FileStream file = new FileStream(FileName, FileMode.Open)) {
                BinaryReader br = new BinaryReader(file);
                br.ReadBytes(100);
                shapes.Clear();
                while (br.PeekChar() != -1) {
                    List<Point> points = new List<Point>();
                    br.ReadBytes(44);
                    int numParts = br.ReadInt32();
                    int numPoints = br.ReadInt32();
                    int[] newNumParts = new int[numParts];
                    for (int i = 0; i < numParts; i++) {
                        newNumParts[i] = br.ReadInt32();
                    }
                    for (int i = 0; i < numPoints; i++) {
                        double X = br.ReadDouble();
                        double Y = -br.ReadDouble();
                        Point point = new Point(X, Y);
                        points.Add(point);
                    }
                    for (int i = 0; i < numParts; i++) {
                        List<Point> newPoints = new List<Point>();
                        int startPoint, endPoint;
                        if (i != numParts - 1) {
                            startPoint = (int)newNumParts[i];
                            endPoint = (int)newNumParts[i + 1];
                        }
                        else {
                            startPoint = (int)newNumParts[i];
                            endPoint = numPoints;
                        }
                        for (int k = 0, j = startPoint; j < endPoint; j++, k++) {
                            newPoints.Add(points[j]);
                        }
                        Polyline polyline = new Polyline(newPoints);
                        polyline.points = newPoints;
                        shapes.Add(polyline);
                    }
                }
                br.Close();
            }
            return shapes;
        }

        public List<Shape> ReadPolygons() {
            using (FileStream file = new FileStream(FileName, FileMode.Open)) {
                BinaryReader br = new BinaryReader(file);
                br.ReadBytes(100);
                shapes.Clear();
                while (br.PeekChar() != -1) {
                    List<Point> points = new List<Point>();
                    br.ReadBytes(44);
                    int numParts = br.ReadInt32();
                    int numPoints = br.ReadInt32();
                    int[] newNumParts = new int[numParts];
                    for (int i = 0; i < numParts; i++) {
                        newNumParts[i] = br.ReadInt32();
                    }
                    for (int i = 0; i < numPoints; i++) {
                        double X = br.ReadDouble();
                        double Y = -br.ReadDouble();
                        Point point = new Point(X, Y);
                        points.Add(point);
                    }
                    for (int i = 0; i < numParts; i++) {
                        List<Point> newPoints = new List<Point>();
                        int startpoint, endpoint;
                        if (i != numParts - 1) {
                            startpoint = (int)newNumParts[i];
                            endpoint = (int)newNumParts[i + 1];
                        }
                        else {
                            startpoint = (int)newNumParts[i];
                            endpoint = numPoints;
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
