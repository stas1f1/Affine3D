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
    public enum Axis { AXIS_X, AXIS_Y, AXIS_Z, LINE };
    public enum Projection { PERSPECTIVE = 0, ISOMETRIC, ORTHOGR_X, ORTHOGR_Y, ORTHOGR_Z };
    public enum RenderMode { Clipp = 0, Noclip = 1};

    public partial class Form1 : Form
    {
        Graphics g;
        Projection projection = 0;
        Axis rotateLineMode = 0;
        Polyhedron figure = null;
        int revertId = -1;

        RenderMode renderMode = RenderMode.Noclip;

        Camera camera = new Camera(50, 50);

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            g.TranslateTransform(pictureBox1.ClientSize.Width / 2, pictureBox1.ClientSize.Height / 2);
            g.ScaleTransform(1, -1);
        }

        void Draw()
        {
            g.Clear(Color.White);
            if (renderMode == 0)
                camera.showClipping(g, figure);
            //figure.ShowClipping(g, projection);
            else
                //figure.Show(g, projection);
                camera.show(g, figure);
        }

        //TRANSLATION ROTATION SCALE
        private void transformButton_Click(object sender, EventArgs e)
        {
            if (figure == null)
            {
                MessageBox.Show("Неодбходимо выбрать фигуру!", "Ошибка!", MessageBoxButtons.OK);
            }
            else
            {
                //TRANSLATE
                int offsetX = (int)numericUpDown1.Value, offsetY = (int)numericUpDown2.Value, offsetZ = (int)numericUpDown3.Value;
                figure.Translate(offsetX, offsetY, offsetZ);

                //ROTATE
                int rotateAngleX = (int)numericUpDown4.Value, rotateAngleY = (int)numericUpDown5.Value, rotateAngleZ = (int)numericUpDown6.Value;
                figure.Rotate(rotateAngleX, 0);
                figure.Rotate(rotateAngleY, Axis.AXIS_Y);
                figure.Rotate(rotateAngleZ, Axis.AXIS_Z);

                //SCALE
                if (checkBox1.Checked)
                {
                    float old_x = figure.Center.X, old_y = figure.Center.Y, old_z = figure.Center.Z;
                    figure.Translate(-old_x, -old_y, -old_z);

                    float kx = (float)numericUpDown7.Value, ky = (float)numericUpDown8.Value, kz = (float)numericUpDown9.Value;
                    figure.Scale(kx, ky, kz);

                    figure.Translate(old_x, old_y, old_z);
                }
                else
                {
                    float kx = (float)numericUpDown7.Value, ky = (float)numericUpDown8.Value, kz = (float)numericUpDown9.Value;
                    figure.Scale(kx, ky, kz);
                }
            }

            Draw();

        }

        //CREATION OF POLYHEDRONS
        private void createTetrahedron_Click(object sender, EventArgs e)
        {
            figure = new Polyhedron();
            figure.Tetrahedron();
            Draw();
        }

        private void createIcohedron_Click(object sender, EventArgs e)
        {
            figure = new Polyhedron();
            figure.Icosahedron();
            Draw();
        }

        private void createHexahedron_Click(object sender, EventArgs e)
        {
            figure = new Polyhedron();
            figure.Hexahedron();
            Draw();
        }

        private void createDodehedron_Click(object sender, EventArgs e)
        {
            figure = new Polyhedron();
            figure.Dodecahedron();
            Draw();
        }

        private void createOctahedron_Click(object sender, EventArgs e)
        {
            figure = new Polyhedron();
            figure.Octahedron();
            Draw();
        }


        //CLIPPING
        private void clippingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (clippingCheckBox.Checked)
                renderMode = 0;
            else
                renderMode = RenderMode.Noclip;
            Draw();
        }

        //Z-BUFFER

        private void bufferButton_Click(object sender, EventArgs e)
        {
            int[] buff = new int[pictureBox1.Width * pictureBox1.Height];

            figure.calculateZBuffer(pictureBox1.Width, pictureBox1.Height, out buff);

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;

            g.Clear(Color.White);

            for (int i = 0; i < pictureBox1.Width; ++i)
                for (int j = 0; j < pictureBox1.Height; ++j)
                {
                    Color c = Color.FromArgb(buff[i * pictureBox1.Height + j], buff[i * pictureBox1.Height + j], buff[i * pictureBox1.Height + j]);
                    bmp.SetPixel(i, j, c);
                }

            pictureBox1.Refresh();
        }

        //CAMERA
        private void transformCameraButton_Click(object sender, EventArgs e)
        {
            cameraTransform();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.T:
                    cameraTransform();
                    break;
            }
        }

        void cameraTransform()
        { 
            if (figure == null)
            {
                MessageBox.Show("Сначала создайте фигуру", "Нет фигуры", MessageBoxButtons.OK);
            }
            else
            {
                int dx = (int)numericUpDown18.Value,
                        dy = (int)numericUpDown17.Value,
                        dz = (int)numericUpDown16.Value;
                //figure.Translate(-dx, -dy, -dz);

                camera.translate(dx, dy, dz);

                float old_x_camera = figure.Center.X,
                        old_y_camera = figure.Center.Y,
                        old_z_camera = figure.Center.Z;
                //figure.Translate(-old_x_camera, -old_y_camera, -old_z_camera);
                camera.translate(-old_x_camera, -old_y_camera, -old_z_camera);

                double angleOX = (int)numericUpDown15.Value;
                //figure.Rotate(-angleOX, Axis.AXIS_X);
                camera.rotate(angleOX, Axis.AXIS_X);

                double angleOY = (int)numericUpDown14.Value;
                //figure.Rotate(-angleOY, Axis.AXIS_Y);
                camera.rotate(angleOY, Axis.AXIS_Y);

                double angleOZ = (int)numericUpDown13.Value;
                //figure.Rotate(-angleOZ, Axis.AXIS_Z);
                camera.rotate(angleOZ, Axis.AXIS_Z);

                //figure.Translate(old_x_camera, old_y_camera, old_z_camera);
                camera.translate(old_x_camera, old_y_camera, old_z_camera);
            }

            g.Clear(Color.White);
            
            if (renderMode == 0)
                camera.showClipping(g, figure);
            else
                camera.show(g, figure);
        }

        private void defaultCameraButton_Click(object sender, EventArgs e)
        {

        }

        private void drawRotationButton_Click(object sender, EventArgs e)
        {
            List<Point3D> points = new List<Point3D>();
            var lines = textBox1.Text.Split('\n');

            foreach (var p in lines)
            {
                var arr = ((string)p).Split(',');
                points.Add(new Point3D(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2])));
            }

            Axis axis = 0;
            switch (comboBox6.SelectedItem.ToString())
            {
                case "OX":
                    axis = 0;
                    break;
                case "OY":
                    axis = Axis.AXIS_Y;
                    break;
                case "OZ":
                    axis = Axis.AXIS_Z;
                    break;
                default:
                    axis = 0;
                    break;
            }

            RotationFigure rotateFigure = new RotationFigure(points, axis, (int)numericUpDown10.Value);

            figure = rotateFigure;

            Draw();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Polyhedron figure = null;
        }

        
    }
}
