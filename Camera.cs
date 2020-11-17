using System.Drawing;

namespace Affine3D
{
    class Camera
    {
        public Edge view = new Edge(new Point3D(0, 0, 300), new Point3D(0, 0, 250));
        public double dX, dY, dZ, aX, aY, aZ;


        public Camera()
        {
            dX = dY = dZ = aX = aY = aZ = 0;
        }

        public Camera(Point3D p1, Point3D p2)
        {
            view.First = p1;
            view.Second = p2;
            dX = dY = dZ = aX = aY = aZ = 0;
        }

        public void show(Graphics g, Polyhedron figure)
        {
            Polyhedron tfFigure = figure;
            tfFigure.Rotate(aX, aY, aZ);
            tfFigure.Translate(dX, dY, dZ);
            tfFigure.Show(g, view);
        }

        public void showClipping(Graphics g, Polyhedron figure)
        {
            Polyhedron tfFigure = figure;
            tfFigure.Rotate(-aX, -aY, -aZ);
            tfFigure.Translate(dX, dY, dZ);
            tfFigure.ShowClipping(g, view);
        }

        public void translate(double x, double y, double z)
        {
            //view.translate(x, y, z);
            dX = x;
            dY = y;
            dZ = z;
        }

        public void rotate(double x, double y, double z)
        {
            //view.rotate(x,y,z);
            aX = x;
            aY = y;
            aZ = z;
        }
        

        public void reset()
        {
            dX = dY = dZ = aX = aY = aZ = 0;
        }
    }
}
