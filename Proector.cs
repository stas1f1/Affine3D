using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine3D
{
    class Proector
    {
        private Matrix isometric_projection = new Matrix(new double[4] { Math.Sqrt(0.5), 0, -Math.Sqrt(0.5), 0 },
                                                         new double[4] { 1 / Math.Sqrt(6), 2 / Math.Sqrt(6), 1 / Math.Sqrt(6), 0 },
                                                         new double[4] { 1 / Math.Sqrt(3), -1 / Math.Sqrt(3), 1 / Math.Sqrt(3), 0 },
                                                         new double[4] { 0, 0, 0, 1 }
                                                    );
        private Matrix orthographic_projection_X = new Matrix(new double[4] { 0, 0, 0, 0 },
                                                              new double[4] { 0, 1, 0, 0 },
                                                              new double[4] { 0, 0, 1, 0 },
                                                              new double[4] { 0, 0, 0, 1 });
        private Matrix orthographic_projection_Y = new Matrix(new double[4] { 1, 0, 0, 0 },
                                                              new double[4] { 0, 0, 0, 0 },
                                                              new double[4] { 0, 0, 1, 0 },
                                                              new double[4] { 0, 0, 0, 1 });
        private Matrix orthographic_projection_Z = new Matrix(new double[4] { 1, 0, 0, 0 },
                                                              new double[4] { 0, 1, 0, 0 },
                                                              new double[4] { 0, 0, 0, 0 },
                                                              new double[4] { 0, 0, 0, 1 });
        private Matrix perspective_projection = new Matrix(new double[4] { 1, 0, 0, 0 },
                                                           new double[4] { 0, 1, 0, 0 },
                                                           new double[4] { 0, 0, 0, -0.00157 },
                                                           new double[4] { 0, 0, 0, 1 });

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
                case 4:
                    dM = perspective_projection;
                    break;
                default:
                    break;
            }
            List<Line> edges = new List<Line>();
            List<PointD> vertices2D = new List<PointD>();

            foreach (var p in polyhedron.Vertices)
            {
                var temp = Matrix.getMatrixFromPoint(p) * dM;
                var temp2d = new PointD(temp[0, 0] / temp[0, 3], temp[0, 1] / temp[0, 3]);
                if (dM == orthographic_projection_X)
                    temp2d = new PointD(temp[0, 1] / temp[0, 3], temp[0, 2] / temp[0, 3]);
                else if (dM == orthographic_projection_Y)
                    temp2d = new PointD(temp[0, 0] / temp[0, 3], temp[0, 2] / temp[0, 3]);
                vertices2D.Add(temp2d);
                foreach (var t in polyhedron.AdjacencyMatrix[p])
                {
                    var t1 = Matrix.getMatrixFromPoint(t) * dM;
                    if (dM == isometric_projection || dM == perspective_projection || dM == orthographic_projection_Z)
                        vertices2D.Add(new PointD(t1[0, 0] / t1[0,3], t1[0, 1]/t1[0,3]));
                    else if (dM == orthographic_projection_X)
                        vertices2D.Add(new PointD(t1[0, 1] / t1[0, 3], t1[0, 2] / t1[0, 3]));
                    else
                        vertices2D.Add(new PointD(t1[0, 0] / t1[0, 3], t1[0, 2] / t1[0, 3]));
                    edges.Add(new Line(temp2d, vertices2D.Last()));
                }
            }

            return edges;
        }
    }
}
