using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine3D
{
    public class PointD
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointD() { X = 0; Y = 0; }
        public PointD(double x, double y) { X = x; Y = y; }
        public PointD(int x, int y) { X = x; Y = y; }
        public PointD(Point p) { X = p.X; Y = p.Y; }

        public Point ToPoint() { return new Point((int)X, (int)Y); }

        static public bool operator ==(PointD p1, PointD p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        static public bool operator !=(PointD p1, PointD p2)
        {
            return p1.X != p2.X || p1.Y != p2.Y;
        }
    }

    /// <summary>
    /// Класс трехмерной точки с координатами типа double
    /// </summary>
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D() { X = 0; Y = 0; Z = 0; }
        public Point3D(double x, double y, double z) { X = x; Y = y; Z = z; }
        public Point3D(int x, int y, int z) { X = x; Y = y; Z = z; }

        static public bool operator ==(Point3D p1, Point3D p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z;
        }

        static public bool operator !=(Point3D p1, Point3D p2)
        {
            return p1.X != p2.X || p1.Y != p2.Y || p1.Z != p2.Z;
        }

        static public Point3D operator +(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }

        static public Point3D operator -(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }
    }

    // абстрактный класс фигуры, которая может быть нарисована
    public abstract class Figure { }

    // класс двумерного ребра (линии)
    public class Line : Figure
    {
        public PointD From { get; set; }
        public PointD To { get; set; }

        public Line() { From = new PointD(); To = new PointD(); }
        public Line(PointD p1, PointD p2) { From = p1; To = p2; }
        public Line(Point p1, Point p2) { From = new PointD(p1); To = new PointD(p2); }
        public Line(double x1, double y1, double x2, double y2) { From = new PointD(x1, y1); To = new PointD(x2, y2); }
        public Line(int x1, int y1, int x2, int y2) { From = new PointD(x1, y1); To = new PointD(x2, y2); }
    }

    // класс трехмерного ребра (линии)
    public class Line3
    {
        public Point3D From { get; set; }
        public Point3D To { get; set; }

        public Line3() { From = new Point3D(); To = new Point3D(); }
        public Line3(Point3D p1, Point3D p2) { From = p1; To = p2; }
        public Line3(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            From = new Point3D(x1, y1, z1); To = new Point3D(x2, y2, z2);
        }
        public Line3(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            From = new Point3D(x1, y1, z1); To = new Point3D(x2, y2, z2);
        }
    }

    // класс многоугольника (грани)
    public class Polygon : Figure
    {
        public List<PointD> Points { get; set; } = new List<PointD>();

        public Polygon() { }
        public Polygon(List<PointD> points) { Points = points; }
        public Polygon(List<Point> points) { Points = points.Select(point => new PointD(point)).ToList(); }

        public void AddPoint(PointD point) { Points.Add(point); }
        public void AddPoint(Point point) { Points.Add(new PointD(point)); }
        public void AddPoint(int x, int y) { Points.Add(new PointD(x, y)); }
        public void AddPoint(double x, double y) { Points.Add(new PointD(x, y)); }
    }

    // класс многогранника
    public class Polyhedron
    {
        // список вершин
        public List<Point3D> Vertices { get; set; } = new List<Point3D>();
        // список ребер
        public List<Line3> Edges { get; } = new List<Line3>();
        // матрица смежности
        public Dictionary<Point3D, List<Point3D>> AdjacencyMatrix { get; } = new Dictionary<Point3D, List<Point3D>>();

        public Point3D Center
        {
            get
            {
                double x = Vertices.Select(point => point.X).Average();
                double y = Vertices.Select(point => point.Y).Average();
                double z = Vertices.Select(point => point.Z).Average();
                return new Point3D(x, y, z);
            }
        }

        public Polyhedron() { }
        public Polyhedron(List<Point3D> points)
        {
            Vertices = points;
            foreach (var point in points) AdjacencyMatrix.Add(point, new List<Point3D>());
        }

        public void AddVertex(Point3D point)
        {
            Vertices.Add(point);
            AdjacencyMatrix.Add(point, new List<Point3D>());
        }

        public void AddVertex(int x, int y, int z) { AddVertex(new Point3D(x, y, z)); }

        public void AddVertex(double x, double y, double z) { AddVertex(new Point3D(x, y, z)); }

        public void AddEdge(Point3D p1, Point3D p2)
        {
            Edges.Add(new Line3(p1, p2));
            Point3D point1 = Vertices.Find(p => p == p1);
            Point3D point2 = Vertices.Find(p => p == p2);
            if (!AdjacencyMatrix.ContainsKey(point1)) AdjacencyMatrix.Add(point1, new List<Point3D> { p2 });
            else AdjacencyMatrix[point1].Add(p2);
            if (!AdjacencyMatrix.ContainsKey(point2)) AdjacencyMatrix.Add(point2, new List<Point3D> { p1 });
            else AdjacencyMatrix[point2].Add(p1);
        }

        // добавить семейство ребер из точки from в каждую точку списка to
        public void AddEdges(Point3D from, List<Point3D> to)
        {
            foreach (var p2 in to) AddEdge(from, p2);
        }
    }
}