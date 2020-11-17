using System;
using System.Collections.Generic;
using System.Drawing;

namespace Affine3D
{
    public class PointD
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public PointF topointf()
        {
            return new PointF((float)X, (float)Y);
        }
    }

        public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(Point3D p)
        {
            X = p.X;
            Y = p.Y;
            Z = p.Z;
        }

        public void reflectX()
        {
            X = -X;
        }

        public void reflectY()
        {
            Y = -Y;
        }

        public void reflectZ()
        {
            Z = -Z;
        }

        public static Point3D operator +(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }

        public static Point3D operator -(Point3D p1, Point3D p2)
        {
            return new Point3D ( p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z );
        }

        /*----------------------------- Projections -----------------------------*/

        public PointD make_perspective(double k = 1000)
        {
            if (Math.Abs(Z - k) < 1e-10)
                k += 1;

            List<double> P = new List<double> { 1, 0, 0, 0,
                                              0, 1, 0, 0,
                                              0, 0, 0, -1/k,
                                              0, 0, 0, 1 };

            List<double> xyz = new List<double> { X, Y, Z, 1 };
            List<double> c = mul_matrix(xyz, 1, 4, P, 4, 4);

            return new PointD(c[0] / c[3], c[1] / c[3]);
        }

        public PointD make_isometric()
        {
            double r_phi = Math.Asin(Math.Tan(Math.PI * 30 / 180));
            double r_psi = Math.PI * 45 / 180;
            double cos_phi = (double)Math.Cos(r_phi);
            double sin_phi = (double)Math.Sin(r_phi);
            double cos_psi = (double)Math.Cos(r_psi);
            double sin_psi = (double)Math.Sin(r_psi);

            List<double> M = new List<double> { cos_psi,  sin_phi * sin_psi,   0,  0,
                                                 0,          cos_phi,        0,  0,
                                              sin_psi,  -sin_phi * cos_psi,  0,  0,
                                                 0,              0,          0,  1 };

            List<double> xyz = new List<double> { X, Y, Z, 1 };
            List<double> c = mul_matrix(xyz, 1, 4, M, 4, 4);

            return new PointD(c[0], c[1]);
        }

        public PointD make_orthographic(Axis a)
        {
            List<double> P = new List<double>();
            for (int i = 0; i < 16; ++i)
            {
                if (i % 5 == 0)
                    P.Add(1);
                else
                    P.Add(0);
            }

            if (a == Axis.AXIS_X)
                P[0] = 0;
            else if (a == Axis.AXIS_Y)
                P[5] = 0;
            else
                P[10] = 0;

            List<double> xyz = new List<double> { X, Y, Z, 1 };
            List<double> c = mul_matrix(xyz, 1, 4, P, 4, 4);
            if (a == Axis.AXIS_X)
                return new PointD(c[1], c[2]);
            else if (a == Axis.AXIS_Y)
                return new PointD(c[0], c[2]);
            else
                return new PointD(c[0], c[1]); 
        }

        public void Show(Graphics g, Projection pr = 0, Pen pen = null)
        {
            if (pen == null)
                pen = Pens.Black;

            PointD p;
            switch (pr)
            {
                case Projection.ISOMETRIC:
                    p = make_isometric();
                    break;
                case Projection.ORTHOGR_X:
                    p = make_orthographic(Axis.AXIS_X);
                    break;
                case Projection.ORTHOGR_Y:
                    p = make_orthographic(Axis.AXIS_Y);
                    break;
                case Projection.ORTHOGR_Z:
                    p = make_orthographic(Axis.AXIS_Z);
                    break;
                default:
                    p = make_perspective();
                    break;
            }
            g.DrawRectangle(pen, (float)p.X, (float)p.Y, 2, 2);
        }

        /*----------------------------- Affine transformations -----------------------------*/

        static public List<double> mul_matrix(List<double> matr1, int m1, int n1, List<double> matr2, int m2, int n2)
        {
            if (n1 != m2)
                return new List<double>();
            int l = m1;
            int m = n1;
            int n = n2;

            List<double> c = new List<double>();
            for (int i = 0; i < l * n; ++i)
                c.Add(0f);

            for (int i = 0; i < l; ++i)
                for (int j = 0; j < n; ++j)
                {
                    for (int r = 0; r < m; ++r)
                        c[i * l + j] += matr1[i * m1 + r] * matr2[r * n2 + j];
                }
            return c;
        }

        public void translate(double x, double y, double z)
        {
            List<double> T = new List<double> { 1, 0, 0, 0,
                                              0, 1, 0, 0,
                                              0, 0, 1, 0,
                                              x, y, z, 1 };
            List<double> xyz = new List<double> { X, Y, Z, 1 };
            List<double> c = mul_matrix(xyz, 1, 4, T, 4, 4);

            X = c[0];
            Y = c[1];
            Z = c[2];
        }

        public void rotate(double angle, Axis a, Edge line = null)
        {
            double rangle = Math.PI * angle / 180;

            List<double> R = null;

            double sin = (double)Math.Sin(rangle);
            double cos = (double)Math.Cos(rangle);
            switch (a)
            {
                case Axis.AXIS_X:
                    R = new List<double> { 1,   0,     0,   0,
                                          0,  cos,   sin,  0,
                                          0,  -sin,  cos,  0,
                                          0,   0,     0,   1 };
                    break;
                case Axis.AXIS_Y:
                    R = new List<double> { cos,  0,  -sin,  0,
                                           0,   1,   0,    0,
                                          sin,  0,  cos,   0,
                                           0,   0,   0,    1 };
                    break;
                case Axis.AXIS_Z:
                    R = new List<double> { cos,   sin,  0,  0,
                                          -sin,  cos,  0,  0,
                                           0,     0,   1,  0,
                                           0,     0,   0,  1 };
                    break;
                case Axis.LINE:
                    double l = Math.Sign(line.Second.X - line.First.X);
                    double m = Math.Sign(line.Second.Y - line.First.Y);
                    double n = Math.Sign(line.Second.Z - line.First.Z);
                    double length = (double)Math.Sqrt(l * l + m * m + n * n);
                    l /= length; m /= length; n /= length;

                    R = new List<double> {  l * l + cos * (1 - l * l),   l * (1 - cos) * m + n * sin,   l * (1 - cos) * n - m * sin,  0,
                                          l * (1 - cos) * m - n * sin,   m * m + cos * (1 - m * m),    m * (1 - cos) * n + l * sin,  0,
                                          l * (1 - cos) * n + m * sin,  m * (1 - cos) * n - l * sin,    n * n + cos * (1 - n * n),   0,
                                                       0,                            0,                             0,               1 };

                    break;
            }
            List<double> xyz = new List<double> { X, Y, Z, 1 };
            List<double> c = mul_matrix(xyz, 1, 4, R, 4, 4);

            X = c[0];
            Y = c[1];
            Z = c[2];
        }

        public Point3D rotateNewPoint(Point3D Point, double angle, Axis a, Edge line = null)
        {
            double rangle = Math.PI * angle / 180;

            List<double> R = null;

            double sin = (double)Math.Sin(rangle);
            double cos = (double)Math.Cos(rangle);
            switch (a)
            {
                case Axis.AXIS_X:
                    R = new List<double> { 1,   0,     0,   0,
                                          0,  cos,   sin,  0,
                                          0,  -sin,  cos,  0,
                                          0,   0,     0,   1 };
                    break;
                case Axis.AXIS_Y:
                    R = new List<double> { cos,  0,  -sin,  0,
                                           0,   1,   0,    0,
                                          sin,  0,  cos,   0,
                                           0,   0,   0,    1 };
                    break;
                case Axis.AXIS_Z:
                    R = new List<double> { cos,   sin,  0,  0,
                                          -sin,  cos,  0,  0,
                                           0,     0,   1,  0,
                                           0,     0,   0,  1 };
                    break;
                case Axis.LINE:
                    double l = Math.Sign(line.Second.X - line.First.X);
                    double m = Math.Sign(line.Second.Y - line.First.Y);
                    double n = Math.Sign(line.Second.Z - line.First.Z);
                    double length = (double)Math.Sqrt(l * l + m * m + n * n);
                    l /= length; m /= length; n /= length;

                    R = new List<double> {  l * l + cos * (1 - l * l),   l * (1 - cos) * m + n * sin,   l * (1 - cos) * n - m * sin,  0,
                                          l * (1 - cos) * m - n * sin,   m * m + cos * (1 - m * m),    m * (1 - cos) * n + l * sin,  0,
                                          l * (1 - cos) * n + m * sin,  m * (1 - cos) * n - l * sin,    n * n + cos * (1 - n * n),   0,
                                                       0,                            0,                             0,               1 };

                    break;
            }
            List<double> xyz = new List<double> { Point.X, Point.Y, Point.Z, 1 };
            List<double> c = mul_matrix(xyz, 1, 4, R, 4, 4);

            return new Point3D(c[0], c[1], c[2]);
        }

        public void Scale(double kx, double ky, double kz)
        {
            List<double> D = new List<double> { kx, 0,  0,  0,
                                              0,  ky, 0,  0,
                                              0,  0,  kz, 0,
                                              0,  0,  0,  1 };
            List<double> xyz = new List<double> { X, Y, Z, 1 };
            List<double> c = mul_matrix(xyz, 1, 4, D, 4, 4);

            X = c[0];
            Y = c[1];
            Z = c[2];
        }
    }
}
