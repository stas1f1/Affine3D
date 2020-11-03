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
            proector.Setup();
        }

        private void drawFigure()
        {
            int offsetX = pictureBox1.Width / 2;
            int offsetY = pictureBox1.Height / 2;
            PointD offset = new PointD(offsetX, offsetY);

            graphics.Clear(Color.White);
            // drawing axis
            Line axis;
            //OX
            axis = proector.Axis(new Point3D(500, 0, 0), currentProectionMode);
            graphics.DrawLine(new Pen(Color.Red), (axis.From + offset).ToPoint(), (axis.To + offset).ToPoint());
            //OY
            axis = proector.Axis(new Point3D(0, 500, 0), currentProectionMode);
            graphics.DrawLine(new Pen(Color.Green), (axis.From + offset).ToPoint(), (axis.To + offset).ToPoint());

            //OZ
            axis = proector.Axis(new Point3D(0, 0, 500), currentProectionMode);
            graphics.DrawLine(new Pen(Color.Blue), (axis.From + offset).ToPoint(), (axis.To + offset).ToPoint());

            List<Line> lines = proector.Display(currentPolyhedron, currentProectionMode);
            foreach (var line in lines)
                graphics.DrawLine(new Pen(Color.Black), (line.From + offset).ToPoint() , (line.To + offset).ToPoint());
            
            pictureBox1.Invalidate();
        }
        
        private void createTetrahedron_Click(object sender, EventArgs e)
        {
            double x = 200, y = 150, z = 0;
            int r = 150;
            double bz = z - r * Math.Sqrt(6) / 3.0;

            Polyhedron tetrahedron = Polyhedrons.getTetrahedron();

            currentPolyhedron = AffineTransform.getMoved(tetrahedron, 0, 0, (int)-bz / 2);
            foreach (var control in groupBox2.Controls)
                (control as RadioButton).Checked = false;
            drawFigure();
        }

        private void createHexahedron_Click(object sender, EventArgs e)
        {
            int edgeLength = 100;

            Polyhedron hexahedrone = Polyhedrons.getHexahedron();

            currentPolyhedron = AffineTransform.getMoved(hexahedrone, 0, 0, -edgeLength/2);
            foreach (var control in groupBox2.Controls)
                (control as RadioButton).Checked = false;
            drawFigure();
        }

        private void createOctahedron_Click(object sender, EventArgs e)
        {
            Polyhedron octahedrone = Polyhedrons.getOctahedron();

            currentPolyhedron = AffineTransform.getMoved(octahedrone, 0, 0, (int)(150 * Math.Sqrt(2)/2));
            foreach (var control in groupBox2.Controls)
                (control as RadioButton).Checked = false;
            drawFigure();
        }

        private void createIcohedron_Click(object sender, EventArgs e)
        {
            Polyhedron icohedron = Polyhedrons.getIcohedron();

            currentPolyhedron = AffineTransform.getMoved(icohedron, 200, 200, 0);

            foreach (var control in groupBox2.Controls)
                (control as RadioButton).Checked = false;
            drawFigure();
        }

        private void createDodehedron_Click(object sender, EventArgs e)
        {
            Polyhedron dodehedron = Polyhedrons.getDodehedron();

            currentPolyhedron = AffineTransform.getMoved(dodehedron, 200, 200, 0);
            foreach (var control in groupBox2.Controls)
                (control as RadioButton).Checked = false;
            drawFigure();
        }

        

        private void clearButton_Click(object sender, EventArgs e)
        {
            currentPolyhedron = null;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);

        }

        private void transformationRadioButton_Click(object sender, EventArgs e)
        {
            if (currentPolyhedron == null)
            {
                MessageBox.Show("Задайте фигуру", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                if (moveRadioButton.Checked)
                {

                    var dialogFirst = new CoordinateBox("Введите смещение по координатам:");
                    if (dialogFirst.ShowDialog() == DialogResult.OK)
                    {
                        currentPolyhedron = AffineTransform.getMoved(
                        currentPolyhedron,
                        dialogFirst.X,
                        dialogFirst.Y,
                        dialogFirst.Z
                    );
                    }
                }
                else if (turnRadioButton.Checked)
                {
                    var dialogX = new InputBox("Введите поворот по оси X \n(градусы)");
                    var dialogY = new InputBox("Введите поворот по оси Y \n(градусы)");
                    var dialogZ = new InputBox("Введите поворот по оси Z \n(градусы)");
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
                else if (scaleAroundCenterRadioButton.Checked)
                {
                    var dialogScale = new InputBox("Введите целое значение для  \nмасштабирования в процентах");
                    if (dialogScale.ShowDialog() == DialogResult.OK)
                    {
                        int scale;
                        if (int.TryParse(dialogScale.ResultText, out scale))
                            ScaleFromCenter(scale);
                        else
                            MessageBox.Show("Было введено неверное значение. \nПожалуйста, попробуйте еще раз.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (reflectionRadioButton.Checked)
                {
                    var dialog = new InputBox("Введите плоскость, относительно \nкоторой будет происходить \nотражение. Например, xy или yz");
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var surface = dialog.ResultText.ToLower();
                        if (surface.Length == 2 && (surface.Contains("x") || surface.Contains("y") || surface.Contains("z")))
                            if (surface == "xy" || surface == "yx")
                                surface = "xy";
                            else if (surface == "xz" || surface == "zx")
                                surface = "xz";
                            else if (surface == "yz" || surface == "zy")
                                surface = "yz";
                            else
                                MessageBox.Show("Было введено неверное значение. \nПожалуйста, попробуйте еще раз.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ReflectionFromSurface(surface);
                    }
                }
                else if (rotateAroundLineRadioButton.Checked)
                {
                    var dialog = new InputBox("Введите название координатной \nоси, параллельно которой \nбудет проходит ось вращения. \nНапример, Oy.");
                    string surface;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        surface = dialog.ResultText.ToLower();
                        if (surface.Length == 2 && (surface.Contains("x") || surface.Contains("y") || surface.Contains("z")))
                        {
                            if (surface == "ox" || surface == "xo")
                                surface = "x";
                            else if (surface == "oy" || surface == "yo")
                                surface = "y";
                            else if (surface == "oz" || surface == "zo")
                                surface = "z";
                            else
                                MessageBox.Show("Было введено неверное значение. \nПожалуйста, попробуйте еще раз.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        dialog = new InputBox("Введите целое значение угла \nповорота в градусах");
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            int angle;
                            if (int.TryParse(dialog.ResultText, out angle))
                                RotateWithLine(surface, angle);
                            else
                                MessageBox.Show("Было введено неверное значение. \nПожалуйста, попробуйте еще раз.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (turnAroundLineRadioButton.Checked)
                {
                    var dialogFirst = new CoordinateBox("Введите координаты первой точки прямой:");
                    if (dialogFirst.ShowDialog() == DialogResult.OK)
                    {
                        var first = new Point3D(dialogFirst.X, dialogFirst.Y, dialogFirst.Z);
                        var dialogSecond = new CoordinateBox("Введите координаты второй точки прямой:");
                        if (dialogSecond.ShowDialog() == DialogResult.OK)
                        {
                            var second = new Point3D(dialogSecond.X, dialogSecond.Y, dialogSecond.Z);
                            var dialogAngle = new InputBox("Введите целое значение угла поворота в градусах:");
                            if (dialogAngle.ShowDialog() == DialogResult.OK)
                            {
                                int angle;
                                if (int.TryParse(dialogAngle.ResultText, out angle))
                                    RotateAroundLine(new Line3D(first, second), angle);
                                else
                                    MessageBox.Show("Было введено неверное значение. \n Пожалуйста, попробуйте еще раз.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                drawFigure();
            }
        }

        /// <summary>
        /// Смена проекции
        /// </summary>
        private void proectionRadioButton_Click(object sender, EventArgs e)
        {
            if (izometrRadioButton.Checked)
            {
                currentProectionMode = 0;
            }
            else if (perspectiveRadioButton.Checked)
            {
                currentProectionMode = 4;
            }
            else if (ortographRadioButton.Checked)
            {
                var dialog = new InputBoxWithRadioBut();
                if (dialog.ShowDialog() == DialogResult.OK)
                    currentProectionMode = dialog.ResultText;
            }
            drawFigure();
        }

        public Line makeRay(PointD from, PointD to)
        {
            PointD vec = to - from;
            if (to == from) return new Line(from, to);
            while (to.X > 0 && to.X < pictureBox1.Width && to.Y > 0 && to.Y < pictureBox1.Height)
                to += vec;

            return new Line(from, to);
        }
    }
}
