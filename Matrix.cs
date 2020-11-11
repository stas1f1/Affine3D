using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine3D
{
    public class Matrix
    {
        private double[,] matr;
        public virtual int GetLength(int i) => matr.GetLength(i);

        public Matrix(int w, int h)
        {
            matr = new double[w, h];
        }

        public Matrix(double[,] m)
        {
            matr = m;
        }

        public Matrix(params double[][] m)
        {
            matr = new double[m.Length, m[0].Length];
            for (int i = 0; i < m.Length; i++)
                for (int j = 0; j < m[i].Length; j++)
                    matr[i, j] = m[i][j];
        }

        public double this[int i, int j]
        {
            get { return matr[i, j]; }
            set { matr[i, j] = value; }
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix res = new Matrix(m1.GetLength(0), m2.GetLength(1));
            for (int i = 0; i < m1.GetLength(0); i++)
                for (int j = 0; j < m2.GetLength(1); j++)
                    for (int k = 0; k < m2.GetLength(0); k++)
                        res[i, j] += m1[i, k] * m2[k, j];
            return res;
        }

        public Point3D ToPoint()
        {
            return new Point3D(matr[0, 0] / matr[0, 3], matr[0, 1] / matr[0, 3], matr[0, 2] / matr[0, 3]);
        }

        static public Matrix getMatrixFromPoint(Point3D point)
        {
            return new Matrix(new double[4] { point.X, point.Y, point.Z, 1 });
        }

        static public Matrix kostylify(Matrix src)
        {
            return new Matrix(new double[4] { src[0, 0], -src[0, 2], -src[0, 1], 1 });
        }
    }
}