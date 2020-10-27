using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Affine3D
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Polyhedron currentPolyhedron;
        int currentProectionMode = 4;
        Proector proector = new Proector();

        // need field for projection

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
        }

        private void drawFigure()
        {
            graphics.Clear(Color.White);
            List<Line> lines = proector.Display(currentPolyhedron, currentProectionMode);
            foreach (var line in lines)
                graphics.DrawLine(new Pen(Color.Black), line.From.ToPoint(), line.To.ToPoint());
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Создание тетраэдра по вершине и ребру
        /// </summary>
        private void createTetrahedron_Click(object sender, EventArgs e)
        {
            double x = 200, y = 150, z = 0;
            int r = 100;
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

            currentPolyhedron = tetrahedron;
            foreach (var control in groupBox2.Controls)
                (control as RadioButton).Checked = false;
            drawFigure();
        }

        private void createIcohedron_Click(object sender, EventArgs e)
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

            currentPolyhedron = AffineTransform.getMoved(icohedron, 200, 200, 0);

            foreach (var control in groupBox2.Controls)
                (control as RadioButton).Checked = false;
            drawFigure();
        }

        private void createHexahedron_Click(object sender, EventArgs e)
        {

        }

        private void createDodehedron_Click(object sender, EventArgs e)
        {

        }

        private void createOctahedron_Click(object sender, EventArgs e)
        {

        }
    }
}
