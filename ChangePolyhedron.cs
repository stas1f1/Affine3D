using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Affine3D
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Масштабирование многогранника 
        /// </summary>
        /// <param name="scaleInProcents">Значение нового масштаба в процентах относительно старого</param>
        void ScaleFromCenter(int scaleInProcents)
        {
            Point3D center = currentPolyhedron.Center;
            double newScale = scaleInProcents / 100.0;
            Polyhedron res;
            res = AffineTransform.getMoved(currentPolyhedron, -(int)center.X, -(int)center.Y, -(int)center.Z);
            res = AffineTransform.getScaled(res, newScale, newScale, newScale);
            res = AffineTransform.getMoved(res, (int)center.X, (int)center.Y, (int)center.Z);

            currentPolyhedron = res;
        }

        /// <summary>
        /// Отображение относительно некоторой плоскости
        /// </summary>
        /// <param name="surface">Имя плоскости - xy/xz/yz</param>
        void ReflectionFromSurface(string surface)
        {
            int x = 1, y = 1, z = 1;
            if (surface == "xy")
                z = -1;
            else if (surface == "xz")
                y = -1;
            else if (surface == "yz")
                x = -1;

            for (int i = 0;i < currentPolyhedron.Vertices.Count; i++)
            {
                Point3D temp = currentPolyhedron.Vertices[i];
                temp.X *= x;
                temp.Y *= y;
                temp.Z *= z;
            }
        }

        /// <summary>
        /// Вращение многогранника вокруг прямой, проходящей через центр, параллельно выбранно координатной оси
        /// </summary>
        /// <param name="surface">Координатная ось</param>
        /// <param name="angle">Угол поворота</param>
        void RotateWithLine(string surface, int angle)
        {
            var cos = Math.Cos(angle * 0.017);
            var sin = Math.Sin(angle * 0.017);
            Point3D center = currentPolyhedron.Center;

            for (int i = 0; i < currentPolyhedron.Vertices.Count; i++)
            {
                Point3D old = currentPolyhedron.Vertices[i] - center;
                Point3D changed = new Point3D();

                if (surface == "x")
                {
                    changed.X = old.X;
                    changed.Y = old.Y * cos - old.Z * sin;
                    changed.Z = old.Z * cos + old.Y * sin;
                }
                else if (surface == "y")
                {
                    changed.X = old.X * cos - old.Z * sin;
                    changed.Y = old.Y;
                    changed.Z = old.Z * cos + old.X * sin;
                }
                else if (surface == "z")
                {
                    changed.X = old.X * cos - old.Y * sin;
                    changed.Y = old.Y * cos + old.X * sin;
                    changed.Z = old.Z;
                }

                changed = changed + center;
                currentPolyhedron.Vertices[i].X = changed.X;
                currentPolyhedron.Vertices[i].Y = changed.Y;
                currentPolyhedron.Vertices[i].Z = changed.Z;
            }
        }

        /// <summary>
        /// Вращение вокруг прямой, заданной двумя точками на заданный угол
        /// </summary>
        void RotateAroundLine(Line3D line, int angle)
        {
            currentPolyhedron = AffineTransform.getRotatedAroundLine(currentPolyhedron, line, angle);
        }
        
    }
}
