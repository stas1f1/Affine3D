using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine3D
{
    class Graphic
    {
        public Func<double, double, double> F;
        public int X0 { get; }
        public int X1 { get; }
        public int Y0 { get; }
        public int Y1 { get; }
        public int CountOfSplits { get; }

        private Polyhedron graphic;


        private int xx1, xx2, yy1, yy2;
        private int[] xx = new int[4];
        private int[] yy = new int[4];
        public int left = 20;
        public int top = 20;
        public int width = 300;
        public int height = 300;

        public double alfa = 10, beta = 12;
        public double x0 = 0, y0 = 0, z0 = 0;
        public double A = 8;
        public bool f_show = false;

        public Graphic(int x0, int x1, int y0, int y1, int count, int func)
        {
            X0 = x0;
            X1 = x1;
            Y0 = y0;
            Y1 = y1;
            CountOfSplits = count;

            float dx = (Math.Abs(x0) + Math.Abs(x1)) / (float)count;
            float dy = (Math.Abs(y0) + Math.Abs(y1)) / (float)count;
            
            List<Point3D> points = new List<Point3D>();

            switch (func)
            {
                case 0:
                    F = (x, y) => x + y;
                    break;
                case 1:
                    F = (x, y) => (float)(x * x + y * y);
                    break;
                case 2:
                    F = (x, y) => (float)Math.Sin(x) * 3f + (float)Math.Cos(y) * 3f;
                    break;
                case 3:
                    F = (x, y) => (float)Math.Sin(x) * 5f;
                    break;
                default:
                    F = (x, y) => x + y;
                    break;
            }

            for (float x = x0; x < x1; x += dx)
            {
                for (float y = y0; y < y1; y += dy)
                {
                    var z = F(x, y);
                    points.Add(new Point3D(x, y, (float)z));
                }

            }

            graphic = new Polyhedron(points);

            for (int j = 1; j < count; ++j)
                graphic.AddEdges(points[j], new List<Point3D> { points[j - 1] });

            for (int i = 1; i < count; ++i)
            {
                graphic.AddEdges(points[i * count], new List<Point3D> { points[(i - 1) * count] });

                for (int j = 1; j < count; ++j)
                    graphic.AddEdges(points[i * count + j], new List<Point3D> { points[i * count + j - 1], points[(i - 1) * count + j] });


            }
        }
        public Polyhedron getGraphic()
        {
            return graphic;
        }

    }
}
