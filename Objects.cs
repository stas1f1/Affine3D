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

        static public PointD operator +(PointD p1, PointD p2)
        {
            return new PointD(p1.X + p2.X, p1.Y + p2.Y);
        }

        static public PointD operator -(PointD p1, PointD p2)
        {
            return new PointD(p1.X - p2.X, p1.Y - p2.Y);
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
        public Point3D(Point3D p) { X = p.X; Y = p.Y; Z = p.Z; }
        public Point3D(double x, double y, double z) { X = x; Y = y; Z = z; }
        public Point3D(int x, int y, int z) { X = x; Y = y; Z = z; }

        public List<Point3D> Neighbours = new List<Point3D>();

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

        public override string ToString()
        {
            return "{"+ X + ", " + Y + ", " + Z + "}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point3D)) 
                return false;
            return this == (obj as Point3D);
        }

        public PointD ToD()
        {
            return new PointD(X, Y);
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
    public class Line3D
    {
        public Point3D From { get; set; }
        public Point3D To { get; set; }

        public Line3D() { From = new Point3D(); To = new Point3D(); }
        public Line3D(Point3D p1, Point3D p2) { From = p1; To = p2; }
        public Line3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            From = new Point3D(x1, y1, z1); To = new Point3D(x2, y2, z2);
        }
        public Line3D(int x1, int y1, int z1, int x2, int y2, int z2)
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

        public List<List<Point3D>> Facets { get; private set; } = new List<List<Point3D>>();

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
        public List<Line3D> Edges { get; } = new List<Line3D>();

        public List<List<Point3D>> Facets { get; private set; } = new List<List<Point3D>>();

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

        public Polyhedron(List<List<Point3D>> facets)
        {
            facets.ForEach(facet => AddFacet(facet));
        }

        public void AddVertex(Point3D point)
        {
            /*Vertices.Add(point);
            if (!AdjacencyMatrix.Keys.Contains(point))
                AdjacencyMatrix.Add(point, new List<Point3D>());*/

            if (Vertices.Exists(p => p == point)) 
                return;
            Vertices.Add(point);
            AdjacencyMatrix.Add(point, new List<Point3D>());
        }

        public void AddVertex(int x, int y, int z) { AddVertex(new Point3D(x, y, z)); }

        public void AddVertex(double x, double y, double z) { AddVertex(new Point3D(x, y, z)); }

        private void ChangePolyhedronByMatrix(Matrix matrix)
        {
            Edges.Clear();
            Vertices = Vertices.Select(point => (Matrix.getMatrixFromPoint(point) * matrix).ToPoint()).ToList();
            foreach (var edge in Edges)
            {
                int p1Index = Vertices.FindIndex(point => point == edge.From);
                int p2Index = Vertices.FindIndex(point => point == edge.To);
                AddEdge(Vertices[p1Index], Vertices[p2Index]);
            }
        }

        public void AddEdge(Point3D p1, Point3D p2)
        {
            if (Edges.Exists(line => line.From == p1 && line.To == p2)) 
                return;
            if (Edges.Exists(line => line.To == p1 && line.From == p2)) 
                return;

            Edges.Add(new Line3D(p1, p2));
            Point3D point1 = Vertices.Find(p => p == p1);
            Point3D point2 = Vertices.Find(p => p == p2);

            if (!AdjacencyMatrix.ContainsKey(point1)) 
                AdjacencyMatrix.Add(point1, new List<Point3D> { p2 });
            else 
                AdjacencyMatrix[point1].Add(p2);

            if (!AdjacencyMatrix.ContainsKey(point2)) 
                AdjacencyMatrix.Add(point2, new List<Point3D> { p1 });
            else 
                AdjacencyMatrix[point2].Add(p1);
        }

        // добавить семейство ребер из точки from в каждую точку списка to
        public void AddEdges(Point3D from, List<Point3D> to)
        {
            foreach (var p2 in to) AddEdge(from, p2);
        }
        /// <summary>
        /// Добавить грань
        /// </summary>
        /// <param name="facet">Грань</param>
        public void AddFacet(List<Point3D> facet)
        {
            Facets.Add(facet);
            foreach (var p in facet) AddVertex(p);
            for (int i = 1; i < facet.Count; i++) AddEdge(facet[i - 1], facet[i]);
            AddEdge(facet[0], facet.Last());
        }


        public void Transform(int dx, int dy, int dz)
        {
            Matrix moveMatrix = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { dx, dy, dz, 1 }
            );
            ChangePolyhedronByMatrix(moveMatrix);
        }

        public void Scale(double dx, double dy, double dz)
        {
            Matrix scaleMatrix = new Matrix(
                new double[4] { dx, 0, 0, 0 },
                new double[4] { 0, dy, 0, 0 },
                new double[4] { 0, 0, dz, 0 },
                new double[4] { 0, 0, 0, 1 }
            );
            ChangePolyhedronByMatrix(scaleMatrix);
        }

        public void ScaleFromCenter(double dx, double dy, double dz)
        {
            Matrix moveMatrix = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { -Center.X, -Center.Y, -Center.Y, 1 }
            );
            Matrix moveMatrix2 = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { Center.X, Center.Y, Center.Z, 1 }
            );
            Matrix scaleMatrix = new Matrix(
                new double[4] { dx, 0, 0, 0 },
                new double[4] { 0, dy, 0, 0 },
                new double[4] { 0, 0, dz, 0 },
                new double[4] { 0, 0, 0, 1 }
            );
            ChangePolyhedronByMatrix(moveMatrix * scaleMatrix * moveMatrix2);
        }


        public void Rotate(int ax, int ay, int az)
        {
            double mx = Center.X, my = Center.Y, mz = Center.Z;
            Matrix moveMatrix = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { -mx, -my, -mz, 1 }
            );
            Matrix moveMatrix2 = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { mx, my, mz, 1 }
            );
            double cos = Math.Cos(ax * Math.PI / 180), sin = Math.Sin(ax * Math.PI / 180);
            Matrix rotateAMatrix = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, cos, -sin, 0 },
                new double[4] { 0, sin, cos, 0 },
                new double[4] { 0, 0, 0, 1 }
            );
            cos = Math.Cos(ay * Math.PI / 180); sin = Math.Sin(ay * Math.PI / 180);
            Matrix rotateBMatrix = new Matrix(
                new double[4] { cos, 0, sin, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { -sin, 0, cos, 0 },
                new double[4] { 0, 0, 0, 1 }
            );
            cos = Math.Cos(az * Math.PI / 180); sin = Math.Sin(az * Math.PI / 180);
            Matrix rotateCMatrix = new Matrix(
                new double[4] { cos, -sin, 0, 0 },
                new double[4] { sin, cos, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { 0, 0, 0, 1 }
            );
            ChangePolyhedronByMatrix( moveMatrix * rotateAMatrix * rotateBMatrix * rotateCMatrix * moveMatrix2);
        }

    }
}