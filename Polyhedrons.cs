using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine3D
{
    static class Polyhedrons
    {
        public static Polyhedron getTetrahedron()
        {
            double x = 200, y = 150, z = 0;
            int r = 150;
            double bz = z - r * Math.Sqrt(6) / 3.0;
            List<Point3D> points = new List<Point3D>
                    {
                        new Point3D(x, y, z),
                        new Point3D(x - r * Math.Sqrt(3) / 6.0, y - r / 2.0, bz),
                        new Point3D(x - r * Math.Sqrt(3) / 6.0, y + r / 2.0, bz),
                        new Point3D(x + r * Math.Sqrt(3) / 3.0, y, bz),
                    };
            Polyhedron tetrahedron = new Polyhedron(points);
            tetrahedron.AddEdges(points[0], new List<Point3D> { points[1], points[2], points[3] });
            tetrahedron.AddEdges(points[1], new List<Point3D> { points[2], points[3] });
            tetrahedron.AddEdge(points[2], points[3]);
            
            return tetrahedron;
        }

        public static Polyhedron getHexahedron()
        {
            Point3D bottomLeftFrontPoint = new Point3D(100, 150, 0);
            int edgeLength = 100;
            List<Point3D> points = new List<Point3D>
                    {
                        bottomLeftFrontPoint,
                        bottomLeftFrontPoint + new Point3D(0, edgeLength, 0),
                        bottomLeftFrontPoint + new Point3D(edgeLength, 0, 0),
                        bottomLeftFrontPoint + new Point3D(edgeLength, edgeLength, 0),
                        bottomLeftFrontPoint + new Point3D(0, 0, edgeLength),
                        bottomLeftFrontPoint + new Point3D(0, edgeLength, edgeLength),
                        bottomLeftFrontPoint + new Point3D(edgeLength, 0, edgeLength),
                        bottomLeftFrontPoint + new Point3D(edgeLength, edgeLength, edgeLength),
                    };
            Polyhedron hexahedrone = new Polyhedron(points);
            hexahedrone.AddEdges(points[0], new List<Point3D> { points[1], points[2], points[4] });
            hexahedrone.AddEdges(points[4], new List<Point3D> { points[5], points[6] });
            hexahedrone.AddEdges(points[7], new List<Point3D> { points[3], points[5], points[6] });
            hexahedrone.AddEdges(points[2], new List<Point3D> { points[3], points[6] });
            hexahedrone.AddEdges(points[1], new List<Point3D> { points[3], points[5] });

            return hexahedrone;
        }

        public static Polyhedron getOctahedron()
        {
            double x = 200, y = 150, z = 0;
            int r = 150;

            List<Point3D> points = new List<Point3D>
                    {
                        new Point3D(x, y, z),
                        new Point3D(x, y - r / Math.Sqrt(2), z - r / Math.Sqrt(2)),
                        new Point3D(x - r / Math.Sqrt(2), y, z - r / Math.Sqrt(2)),
                        new Point3D(x, y + r / Math.Sqrt(2), z - r / Math.Sqrt(2)),
                        new Point3D(x + r / Math.Sqrt(2), y, z - r / Math.Sqrt(2)),
                        new Point3D(x, y, z - r * Math.Sqrt(2))
                    };

            Polyhedron octahedrone = new Polyhedron(points);
            octahedrone.AddEdges(points[0], new List<Point3D> { points[1], points[2], points[3], points[4] });
            octahedrone.AddEdges(points[5], new List<Point3D> { points[1], points[2], points[3], points[4] });
            octahedrone.AddEdges(points[1], new List<Point3D> { points[2], points[4] });
            octahedrone.AddEdges(points[3], new List<Point3D> { points[2], points[4] });

            return octahedrone;
        }

        public static Polyhedron getIcohedron()
        {
            double r = 100 * (1 + Math.Sqrt(5)) / 4; // радиус полувписанной окружности 

            List<Point3D> points = new List<Point3D>
            {
                new Point3D(0, -50, -r),
                new Point3D(0, 50, -r),
                new Point3D(50, r, 0),
                new Point3D(r, 0, -50),
                new Point3D(50, -r, 0),
                new Point3D(-50, -r, 0),
                new Point3D(-r, 0, -50),
                new Point3D(-50, r, 0),
                new Point3D(r, 0, 50),
                new Point3D(-r, 0, 50),
                new Point3D(0, -50, r),
                new Point3D(0, 50, r)
            };

            Polyhedron icohedron = new Polyhedron(points);

            icohedron.AddEdges(points[0], new List<Point3D> { points[1], points[3], points[4], points[5], points[6] });
            icohedron.AddEdges(points[1], new List<Point3D> { points[2], points[3], points[6], points[7] });
            icohedron.AddEdges(points[2], new List<Point3D> { points[3], points[7], points[8], points[11] });
            icohedron.AddEdges(points[3], new List<Point3D> { points[4], points[8] });
            icohedron.AddEdges(points[4], new List<Point3D> { points[5], points[8], points[10] });
            icohedron.AddEdges(points[5], new List<Point3D> { points[6], points[9], points[10] });
            icohedron.AddEdges(points[6], new List<Point3D> { points[7], points[9] });
            icohedron.AddEdges(points[7], new List<Point3D> { points[9], points[11] });
            icohedron.AddEdges(points[8], new List<Point3D> { points[10], points[11] });
            icohedron.AddEdges(points[9], new List<Point3D> { points[10], points[11] });
            icohedron.AddEdges(points[10], new List<Point3D> { points[11] });

            return icohedron;
        }

        public static Polyhedron getDodehedron()
        {
            double r = 100 * (3 + Math.Sqrt(5)) / 4; // радиус полувписанной окружности 
            double x = 100 * (1 + Math.Sqrt(5)) / 4; // половина стороны пятиугольника в сечении 

            List<Point3D> points = new List<Point3D>
            {
                new Point3D(0, -50, -r),
                new Point3D(0, 50, -r),
                new Point3D(x, x, -x),
                new Point3D(r, 0, -50),
                new Point3D(x, -x, -x),
                new Point3D(50, -r, 0),
                new Point3D(-50, -r, 0),
                new Point3D(-x, -x, -x),
                new Point3D(-r, 0, -50),
                new Point3D(-x, x, -x),
                new Point3D(-50, r, 0),
                new Point3D(50, r, 0),
                new Point3D(-x, -x, x),
                new Point3D(0, -50, r),
                new Point3D(x, -x, x),
                new Point3D(0, 50, r),
                new Point3D(-x, x, x),
                new Point3D(x, x, x),
                new Point3D(-r, 0, 50),
                new Point3D(r, 0, 50)
            };

            Polyhedron dodehedron = new Polyhedron(points);

            dodehedron.AddEdges(points[0], new List<Point3D> { points[1], points[4], points[7] });
            dodehedron.AddEdges(points[1], new List<Point3D> { points[2], points[9] });
            dodehedron.AddEdges(points[2], new List<Point3D> { points[3], points[11] });
            dodehedron.AddEdges(points[3], new List<Point3D> { points[4], points[19] });
            dodehedron.AddEdges(points[4], new List<Point3D> { points[5] });
            dodehedron.AddEdges(points[5], new List<Point3D> { points[6], points[14] });
            dodehedron.AddEdges(points[6], new List<Point3D> { points[7], points[12] });
            dodehedron.AddEdges(points[7], new List<Point3D> { points[8] });
            dodehedron.AddEdges(points[8], new List<Point3D> { points[9], points[18] });
            dodehedron.AddEdges(points[9], new List<Point3D> { points[10] });
            dodehedron.AddEdges(points[10], new List<Point3D> { points[11], points[16] });
            dodehedron.AddEdges(points[11], new List<Point3D> { points[17] });
            dodehedron.AddEdges(points[12], new List<Point3D> { points[13], points[18] });
            dodehedron.AddEdges(points[13], new List<Point3D> { points[14], points[15] });
            dodehedron.AddEdges(points[14], new List<Point3D> { points[19] });
            dodehedron.AddEdges(points[15], new List<Point3D> { points[16], points[17] });
            dodehedron.AddEdges(points[16], new List<Point3D> { points[18] });
            dodehedron.AddEdges(points[17], new List<Point3D> { points[19] });

            return dodehedron;
        }
    }
}
