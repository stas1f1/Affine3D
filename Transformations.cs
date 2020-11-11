using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine3D
{
    static class TransformHelper
    {
        // применяет к многограннику матричное преобразование
        static public Polyhedron ChangePolyhedronByMatrix(Polyhedron polyhedron, Matrix matrix)
        {
            List<Point3D> newPoints = polyhedron.Vertices.Select(point => (Matrix.getMatrixFromPoint(point) * matrix).ToPoint()).ToList();
            Polyhedron res = new Polyhedron(newPoints);
            foreach (var edge in polyhedron.Edges)
            {
                int p1Index = polyhedron.Vertices.FindIndex(point => point == edge.From);
                int p2Index = polyhedron.Vertices.FindIndex(point => point == edge.To);
                res.AddEdge(newPoints[p1Index], newPoints[p2Index]);
            }
            return res;
        }
    }

    static class AffineTransform
    {
        static public void Transform(Polyhedron polyhedron, int dx, int dy, int dz)
        {
            polyhedron = getTransformed(polyhedron, dx, dy, dz);
        }

        // получить сдвинутый многогранник относительно начала координат
        static public Polyhedron getTransformed(Polyhedron polyhedron, int dx, int dy, int dz)
        {
            Matrix moveMatrix = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { dx, dy, dz, 1 }
            );
            return TransformHelper.ChangePolyhedronByMatrix(polyhedron, moveMatrix);
        }

        static public void Scale(Polyhedron polyhedron, double dx, double dy, double dz)
        {
            polyhedron = getScaled(polyhedron, dx, dy, dz);
        }

        // получить масштабированный многогранник относительно начала координат
        static public Polyhedron getScaled(Polyhedron polyhedron, double dx, double dy, double dz)
        {
            Matrix scaleMatrix = new Matrix(
                new double[4] { dx, 0, 0, 0 },
                new double[4] { 0, dy, 0, 0 },
                new double[4] { 0, 0, dz, 0 },
                new double[4] { 0, 0, 0, 1 }
            );
            return TransformHelper.ChangePolyhedronByMatrix(polyhedron, scaleMatrix);
        }

        static public void ScaleFromCenter(Polyhedron polyhedron, double dx, double dy, double dz)
        {
            polyhedron = getScaledFromCenter(polyhedron, dx, dy, dz);
        }

        // получить масштабированный многогранник относительно начала координат
        static public Polyhedron getScaledFromCenter(Polyhedron polyhedron, double dx, double dy, double dz)
        {

            Point3D center = polyhedron.Center;
            Matrix moveMatrix = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { -center.X, -center.Y, -center.Y, 1 }
            );
            Matrix moveMatrix2 = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { center.X, center.Y, center.Z, 1 }
            );
            Matrix scaleMatrix = new Matrix(
                new double[4] { dx, 0, 0, 0 },
                new double[4] { 0, dy, 0, 0 },
                new double[4] { 0, 0, dz, 0 },
                new double[4] { 0, 0, 0, 1 }
            );
            return TransformHelper.ChangePolyhedronByMatrix(polyhedron, moveMatrix * scaleMatrix * moveMatrix2);
            
        }


        static public void Rotate(Polyhedron polyhedron, int dx, int dy, int dz)
        {
            polyhedron = getRotated(polyhedron, dx, dy, dz);
        }

        static public Polyhedron getRotated(Polyhedron polyhedron, int ax, int ay, int az)
        {
            double dx = polyhedron.Center.X, dy = polyhedron.Center.Y, dz = polyhedron.Center.Z;
            Matrix moveMatrix = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { -dx, -dy, -dz, 1 }
            );
            Matrix moveMatrix2 = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { dx, dy, dz, 1 }
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
            return TransformHelper.ChangePolyhedronByMatrix(polyhedron, moveMatrix * rotateAMatrix * rotateBMatrix * rotateCMatrix * moveMatrix2);
        }


        static public void RotateAroundLine(Polyhedron polyhedron, Line3D line, int angle)
        {
            polyhedron = getRotatedAroundLine(polyhedron, line, angle);
        }

        static public Polyhedron getRotatedAroundLine(Polyhedron polyhedron, Line3D line, int angle)
        {
            double rangle = Math.PI * angle / 180;
            float sin = (float)Math.Sin(rangle);
            float cos = (float)Math.Cos(rangle);
            float l = Math.Sign(line.To.X - line.From.X);
            float m = Math.Sign(line.To.Y - line.From.Y);
            float n = Math.Sign(line.To.Z - line.From.Z);
            float length = (float)Math.Sqrt(l * l + m * m + n * n);
            l /= length; m /= length; n /= length;

            Matrix rotateMatrix =  new Matrix(
                new double[4] { l * l + cos * (1 - l * l),   l * (1 - cos) * m + n * sin,   l * (1 - cos) * n - m * sin,  0 },
                new double[4] {l * (1 - cos) * m - n * sin,   m * m + cos * (1 - m * m),    m * (1 - cos) * n + l * sin,  0 },
                new double[4] {l * (1 - cos) * n + m * sin,  m * (1 - cos) * n - l * sin,    n * n + cos * (1 - n * n),   0 },
                new double[4] {0, 0, 0, 1 }
                 );

            return TransformHelper.ChangePolyhedronByMatrix(polyhedron, rotateMatrix);
        }

        static public Point3D getRotatedAroundLine(Point3D point, Line3D line, float angle)
        {
            double rangle = Math.PI * angle / 180;
            float sin = (float)Math.Sin(rangle);
            float cos = (float)Math.Cos(rangle);
            float l = Math.Sign(line.To.X - line.From.X);
            float m = Math.Sign(line.To.Y - line.From.Y);
            float n = Math.Sign(line.To.Z - line.From.Z);
            float length = (float)Math.Sqrt(l * l + m * m + n * n);
            l /= length; m /= length; n /= length;

            Matrix rotateMatrix = new Matrix(
                new double[4] { l * l + cos * (1 - l * l), l * (1 - cos) * m + n * sin, l * (1 - cos) * n - m * sin, 0 },
                new double[4] { l * (1 - cos) * m - n * sin, m * m + cos * (1 - m * m), m * (1 - cos) * n + l * sin, 0 },
                new double[4] { l * (1 - cos) * n + m * sin, m * (1 - cos) * n - l * sin, n * n + cos * (1 - n * n), 0 },
                new double[4] { 0, 0, 0, 1 }
                 );

            
            return (Matrix.getMatrixFromPoint(point) * rotateMatrix).ToPoint();
        }
    }
}