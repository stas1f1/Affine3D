using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Affine3D
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Polyhedron currentPolyhedron;
        int currentProectionMode = 4;
        Proector proector = new Proector();

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

            Polyhedron icohedrone = new Polyhedron(points);

            icohedrone.AddEdges(points[0], new List<Point3D> { points[1], points[3], points[4], points[5], points[6] });
            icohedrone.AddEdges(points[1], new List<Point3D> { points[2], points[3], points[6], points[7] });
            icohedrone.AddEdges(points[2], new List<Point3D> { points[3], points[7], points[8], points[11] });
            icohedrone.AddEdges(points[3], new List<Point3D> { points[4], points[8] });
            icohedrone.AddEdges(points[4], new List<Point3D> { points[5], points[8], points[10] });
            icohedrone.AddEdges(points[5], new List<Point3D> { points[6], points[9], points[10] });
            icohedrone.AddEdges(points[6], new List<Point3D> { points[7], points[9] });
            icohedrone.AddEdges(points[7], new List<Point3D> { points[9], points[11] });
            icohedrone.AddEdges(points[8], new List<Point3D> { points[10], points[11] });
            icohedrone.AddEdges(points[9], new List<Point3D> { points[10], points[11] });
            icohedrone.AddEdges(points[10], new List<Point3D> { points[11] });

            currentPolyhedron = AffineTransform.getMoved(icohedrone, 200, 200, 0);

            foreach (var control in groupBox2.Controls)
                (control as RadioButton).Checked = false;
            drawFigure();
        }

        private void createHexahedron_Click(object sender, EventArgs e)
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
            currentPolyhedron = hexahedrone;
            foreach (var control in groupBox2.Controls)
                (control as RadioButton).Checked = false;
            drawFigure();
        }

        private void createDodehedron_Click(object sender, EventArgs e)
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

            currentPolyhedron = AffineTransform.getMoved(dodehedron, 200, 200, 0);
            foreach (var control in groupBox2.Controls)
                (control as RadioButton).Checked = false;
            drawFigure();
        }

        private void createOctahedron_Click(object sender, EventArgs e)
        {
            double x = 200, y = 150, z = 0;
            int r = 100;

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
            currentPolyhedron = octahedrone;
            foreach (var control in groupBox2.Controls)
                (control as RadioButton).Checked = false;
            drawFigure();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
        }

        private void transformationRadioButton_Click(object sender, EventArgs e)
        {
            if (moveRadioButton.Checked)
            {
                var dialogX = new InputBox("Введите смещение по X");
                var dialogY = new InputBox("Введите смещение по Y");
                var dialogZ = new InputBox("Введите смещение по Z");
                if (dialogX.ShowDialog() == DialogResult.OK && dialogY.ShowDialog() == DialogResult.OK && dialogZ.ShowDialog() == DialogResult.OK)
                    currentPolyhedron = AffineTransform.getMoved(
                        currentPolyhedron,
                        int.Parse(dialogX.ResultText),
                        int.Parse(dialogY.ResultText),
                        int.Parse(dialogZ.ResultText)
                    );
            }
            else if (turnRadioButton.Checked)
            {
                var dialogX = new InputBox("Введите поворот по оси X (градусы)");
                var dialogY = new InputBox("Введите поворот по оси Y (градусы)");
                var dialogZ = new InputBox("Введите поворот по оси Z (градусы)");
                if (dialogX.ShowDialog() == DialogResult.OK && dialogY.ShowDialog() == DialogResult.OK && dialogZ.ShowDialog() == DialogResult.OK)
                    currentPolyhedron = AffineTransform.getRotated(
                        currentPolyhedron,
                        int.Parse(dialogX.ResultText),
                        int.Parse(dialogY.ResultText),
                        int.Parse(dialogZ.ResultText)
                    );
            }
            else if (scaleRadioButton.Checked)
            {
                var dialogX = new InputBox("Введите увеличение по X");
                var dialogY = new InputBox("Введите увеличение по Y");
                var dialogZ = new InputBox("Введите увеличение по Z");
                if (dialogX.ShowDialog() == DialogResult.OK && dialogY.ShowDialog() == DialogResult.OK && dialogZ.ShowDialog() == DialogResult.OK)
                    currentPolyhedron = AffineTransform.getScaled(
                        currentPolyhedron,
                        double.Parse(dialogX.ResultText.Replace('.', ',')),
                        double.Parse(dialogY.ResultText.Replace('.', ',')),
                        double.Parse(dialogZ.ResultText.Replace('.', ','))
                    );
            }
        }
    }
}
