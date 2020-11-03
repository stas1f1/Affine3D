using System;
using System.Collections.Generic;
using System.Linq;

namespace Affine3D
{
    class Proector
    {
        private Matrix isometric_projection = new Matrix(new[] {Math.Sqrt(0.5), 0, -Math.Sqrt(0.5), 0},
            new [] {1 / Math.Sqrt(6), 2 / Math.Sqrt(6), 1 / Math.Sqrt(6), 0},
            new double[] {1 / Math.Sqrt(3), -1 / Math.Sqrt(3), 1 / Math.Sqrt(3), 0},
            new double[] {0, 0, 0, 1}
        );

        private Matrix orthographic_projection_X = new Matrix(new double[] {0, 0, 0, 0},
            new double[] {0, 1, 0, 0},
            new double[] {0, 0, 1, 0},
            new double[] {0, 0, 0, 1});

        private Matrix orthographic_projection_Y = new Matrix(new double[] {1, 0, 0, 0},
            new double[] {0, 0, 0, 0},
            new double[] {0, 0, 1, 0},
            new double[] {0, 0, 0, 1});

        private Matrix orthographic_projection_Z = new Matrix(new double[] {1, 0, 0, 0},
            new double[] {0, 1, 0, 0},
            new double[] {0, 0, 0, 0},
            new double[] {0, 0, 0, 1});

        private Matrix perspective_projection = new Matrix(new double[] {1, 0, 0, 0},
            new double[] {0, 1, 0, 0},
            new[] {0, 0, 0, -0.00157},
            new double[] {0, 0, 0, 1});

        public void Setup()
        {
            float k = 1000;
            //if (Math.Abs(Z - k) < 1e-10)
            //  k += 1;

            var perspective_projection = new Matrix(new double[4] {1, 0, 0, 0},
                new double[] {0, 1, 0, 0},
                new double[] {0, 0, 0, -1 / k},
                new double[] {0, 0, 0, 1});

            double r_phi = Math.Asin(Math.Tan(Math.PI * 30 / 180));
            double r_psi = Math.PI * 45 / 180;
            float cos_phi = (float) Math.Cos(r_phi);
            float sin_phi = (float) Math.Sin(r_phi);
            float cos_psi = (float) Math.Cos(r_psi);
            float sin_psi = (float) Math.Sin(r_psi);

            isometric_projection = new Matrix(new double[4] {cos_psi, sin_phi * sin_psi, 0, 0},
                new double[] {0, cos_phi, 0, 0,},
                new double[] {sin_psi, -sin_phi * cos_psi, 0, 0},
                new double[] {0, 0, 0, 1});
        }

        public List<Line> Display(Polyhedron polyhedron, int proc)
        {
            Matrix dM = new Matrix(4, 4);

            switch (proc)
            {
                case 0:
                    dM = isometric_projection;
                    break;
                case 1:
                    dM = orthographic_projection_X;
                    break;
                case 2:
                    dM = orthographic_projection_Y;
                    break;
                case 3:
                    dM = orthographic_projection_Z;
                    break;
            }

            List<Line> edges = new List<Line>();
            List<PointD> vertices2D = new List<PointD>();

            foreach (var p in polyhedron.Vertices)
            {

                var temp = Matrix.kostylify(Matrix.getMatrixFromPoint(p)) * dM;
                if (proc == 4)
                {
                    var z = p.Z == 0 ? 0.0001 : 1 / p.Z;

                    var perspective_projection = new Matrix(
                        new double[] {1, 0, 0, 0},
                        new double[] {0, 1, 0, 0},
                        new double[] {0, 0, 0, z},
                        new double[] {0, 0, 0, 1});
                    temp = Matrix.getMatrixFromPoint(p) * perspective_projection;
                }


                var temp2d = new PointD(temp[0, 0] / temp[0, 3], temp[0, 1] / temp[0, 3]);

                if (dM == orthographic_projection_X)
                    temp2d = new PointD(temp[0, 1] / temp[0, 3], temp[0, 2] / temp[0, 3]);
                else if (dM == orthographic_projection_Y)
                    temp2d = new PointD(temp[0, 0] / temp[0, 3], temp[0, 2] / temp[0, 3]);
                vertices2D.Add(temp2d);
                foreach (var t in polyhedron.AdjacencyMatrix[p])
                {
                    var t1 = Matrix.kostylify(Matrix.getMatrixFromPoint(t)) * dM;
                    if (proc == 4)
                    {
                        var z = t.Z == 0 ? 0.0001 : 1 / t.Z;

                        var perspective_projection = new Matrix(
                            new double[] {1, 0, 0, 0},
                            new double[] {0, 1, 0, 0},
                            new double[] {0, 0, 0, z},
                            new double[] {0, 0, 0, 1});
                        t1 = Matrix.getMatrixFromPoint(t) * perspective_projection;
                    }


                    if (dM == isometric_projection || proc == 4 || dM == orthographic_projection_Z)
                        vertices2D.Add(new PointD(t1[0, 0] / t1[0, 3], t1[0, 1] / t1[0, 3]));
                    else if (dM == orthographic_projection_X)
                        vertices2D.Add(new PointD(t1[0, 1] / t1[0, 3], t1[0, 2] / t1[0, 3]));
                    else
                        vertices2D.Add(new PointD(t1[0, 0] / t1[0, 3], t1[0, 2] / t1[0, 3]));
                    edges.Add(new Line(temp2d, vertices2D.Last()));
                }
            }

            return edges;
        }

        public Line Axis(Point3D p, int proc)
        {
            Matrix dM = new Matrix(4, 4);

            switch (proc)
            {
                case 0:
                    dM = isometric_projection;
                    break;
                case 1:
                    dM = orthographic_projection_X;
                    break;
                case 2:
                    dM = orthographic_projection_Y;
                    break;
                case 3:
                    dM = orthographic_projection_Z;
                    break;
                case 4:
                    dM = perspective_projection;
                    break;
            }

            PointD center;
            Line axis;


            var temp = Matrix.kostylify(Matrix.getMatrixFromPoint(p)) * dM;

            var t1 = Matrix.kostylify(Matrix.getMatrixFromPoint(new Point3D(0, 0, 0))) * dM;

            var temp2d = new PointD(temp[0, 0] / temp[0, 3], temp[0, 1] / temp[0, 3]);
            if (dM == orthographic_projection_X)
                temp2d = new PointD(temp[0, 1] / temp[0, 3], temp[0, 2] / temp[0, 3]);
            else if (dM == orthographic_projection_Y)
                temp2d = new PointD(temp[0, 0] / temp[0, 3], temp[0, 2] / temp[0, 3]);

            if (dM == isometric_projection || proc == 4 || dM == orthographic_projection_Z)
                center = new PointD(t1[0, 0] / t1[0, 3], t1[0, 1] / t1[0, 3]);
            else if (dM == orthographic_projection_X)
                center = new PointD(t1[0, 1] / t1[0, 3], t1[0, 2] / t1[0, 3]);
            else
                center = new PointD(t1[0, 0] / t1[0, 3], t1[0, 2] / t1[0, 3]);

            axis = new Line(center, temp2d);

            return axis;
        }
    }
}
