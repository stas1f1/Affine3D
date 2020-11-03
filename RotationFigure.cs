using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine3D
{
    static class RotationFigure
    {
        public static Polyhedron getRotationFigure(List<Point3D> startPoints, Line3D axis, int count)
        {
            float angle = 360f / count;

            int rings = startPoints.Count;

            List<Point3D> points = new List<Point3D>();

            for (int i = 0; i < count; ++i)
            {
                for (int j = 0; j < rings; ++j)
                    points.Add(AffineTransform.getRotatedAroundLine(startPoints[j], axis, i * angle));
            }

            Polyhedron rf = new Polyhedron(points);


            rf.AddEdges(points[0], new List<Point3D> { points[(count-1) * rings]});

            for (int j = 1; j < rings; ++j)
                rf.AddEdges(points[j], new List<Point3D> { points[j - 1], points[(count - 1) * rings + j] });

            for (int i = 1; i < count; ++i)
            {
                rf.AddEdges(points[i * rings], new List<Point3D> { points[(i-1) * rings]});

                for (int j = 1; j < rings; ++j)
                    rf.AddEdges(points[i * rings + j], new List<Point3D> { points[i * rings + j - 1], points[(i-1) * rings + j] });
                
            }

            return rf;

        }
        

    
    }
}
