using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Affine3D
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Polyhedron currentPolyhedron;
        int currentProectionMode = 4;
        Proector proector = new Proector();
        Point3D axisLine;
        /// <summary>
        /// Точки для вращения
        /// </summary>
        List<Point3D> points;
        /// <summary>
        /// Угол 1 поворота
        /// </summary>
        int turnSubs = 0;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
            points = new List<Point3D>();
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



            pictureBox1.Refresh();

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
            points = new List<Point3D>();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
            points.Clear();
            pointsTextBox.Text = "{0, 0, 0}";
            axisTextBox.Text = "Добавьте точку!";

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

        private void moreButton_Click(object sender, EventArgs e)
        {

            try
            {
                var dialog = new CoordinateBox("Введите координаты точек для вращения");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Point3D p = new Point3D(dialog.X, dialog.Y, dialog.Z);
                    points.Add(p);
                    if (points.Count == 1)
                        pointsTextBox.Text = p.ToString();
                    else
                        pointsTextBox.Text += ", " + p.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Попробуйте еще раз!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addAxisButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new CoordinateBox("Координаты точки оси вращения");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    axisLine = new Point3D(dialog.X, dialog.Y, dialog.Z);
                    axisTextBox.Text = "{0, 0, 0}" + axisLine.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Попробуйте еще раз!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Ввод количества поворотов во вращении
        /// </summary>
        private void countTextBox_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(countTextBox.Text, out turnSubs);
        }


        private void axisTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void drawRotationButton_Click(object sender, EventArgs e)
        {
            int.TryParse(countTextBox.Text, out turnSubs);
            currentPolyhedron = RotationFigure.getRotationFigure(points, new Line3D(new Point3D(0, 0, 0), axisLine), turnSubs);
            drawFigure();
        }



        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.Filter = "Текстовый файл|*.txt";
            dialog.DefaultExt = "txt";
            dialog.InitialDirectory = Directory.GetCurrentDirectory().Replace("bin\\Debug", "");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fname = dialog.FileName;
                Polyhedron polyhedron = new Polyhedron();
                try //обратотка возможных ошибок
                {
                    foreach (var line in File.ReadAllLines(fname))
                    {
                        if (line.Split(' ').Length == 3) //это точка
                        {
                            var coords = line.Split(' ').Select(s => double.Parse(s)).ToArray();
                            polyhedron.AddVertex(coords[0], coords[1], coords[2]);
                        }
                        else //это ребро
                        {
                            var vertexNumbers = line.Split(' ').Select(s => int.Parse(s)).ToArray();
                            polyhedron.AddEdge(polyhedron.Vertices[vertexNumbers[0]], polyhedron.Vertices[vertexNumbers[1]]);
                        }
                    }
                    currentPolyhedron = polyhedron;
                    drawFigure();
                    MessageBox.Show("Файл загружен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка чтения файла!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (currentPolyhedron == null)
            {
                MessageBox.Show("Ничего не нарисовано!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.CheckPathExists = true;
            dialog.Filter = "Текстовый файл|*.txt";
            dialog.DefaultExt = "txt";
            dialog.InitialDirectory = Directory.GetCurrentDirectory().Replace("bin\\Debug", "");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fname = dialog.FileName;
                using (var streamWriter = File.CreateText(fname))
                {
                    //записываем вершины с координатами
                    foreach (var vertex in currentPolyhedron.Vertices)
                        streamWriter.WriteLine($"{vertex.X} {vertex.Y} {vertex.Z}");

                    //записываем список ребер
                    foreach (var edge in currentPolyhedron.Edges)
                        streamWriter.WriteLine($"{currentPolyhedron.Vertices.IndexOf(edge.From)} {currentPolyhedron.Vertices.IndexOf(edge.To)}");
                }
                MessageBox.Show("Файл сохранен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clearPointsButton_Click(object sender, EventArgs e)
        {
            points.Clear();
            pointsTextBox.Text = "{0, 0, 0}";
            axisTextBox.Text = "Добавьте точку!";
        }

        private void drawGraphicButton_Click(object sender, EventArgs e)
        {
            Graphic Graph = new Graphic((int)numericUpDown18.Value, (int)numericUpDown20.Value, (int)numericUpDown19.Value,
                (int)numericUpDown21.Value, (int)numericUpDown1.Value, comboBox6.SelectedIndex);

            currentPolyhedron = Graph.getGraphic();

            drawFigure();
        }
    }
}
