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
        // получить сдвинутый многогранник относительно начала координат
        static public Polyhedron getMoved(Polyhedron polyhedron, int dx, int dy, int dz)
        {
            Matrix moveMatrix = new Matrix(
                new double[4] { 1, 0, 0, 0 },
                new double[4] { 0, 1, 0, 0 },
                new double[4] { 0, 0, 1, 0 },
                new double[4] { dx, dy, dz, 1 }
            );
            return TransformHelper.ChangePolyhedronByMatrix(polyhedron, moveMatrix);
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
    }
}