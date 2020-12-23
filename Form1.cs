﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Affine3D
{
    public enum Axis { AXIS_X, AXIS_Y, AXIS_Z, LINE };
    public enum Projection { PERSPECTIVE = 0, ISOMETRIC, ORTHOGR_X, ORTHOGR_Y, ORTHOGR_Z };
    public enum RenderMode { Clipp = 0, Noclip = 1, ZBuff, Gouraud, Texturing};

    public partial class Form1 : Form
    {
        Graphics g;
        Projection projection = 0;
        bool showZBuf = false;
        bool multiitem = false;
        Polyhedron figure = null;
        List<Polyhedron> figures;
        Graphic Graph = null;

        Color fill_color = Color.Red; // для гуро
        byte[] rgbValuesTexture; // для picturebox и текстурирования
        Bitmap texture;
        public Bitmap bmp;
        BitmapData bmpDataTexture; // для picturebox и текстурирования
        byte[] rgbValues;
        public BitmapData bmpData;
        public IntPtr ptr; // указатель на rgbValues
        public int bytes; // длина rgbValues

        RenderMode renderMode = 0;

        Camera camera = new Camera();

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            g.TranslateTransform(pictureBox1.ClientSize.Width / 2, pictureBox1.ClientSize.Height / 2);
            g.ScaleTransform(1, -1);

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = pictureBox1.CreateGraphics();
            g.TranslateTransform(pictureBox1.ClientSize.Width / 2, pictureBox1.ClientSize.Height / 2);
            g.ScaleTransform(1, -1);

            texture = Image.FromFile("../../texture_2.jpg") as Bitmap;
            Rectangle rectTexture = new Rectangle(0, 0, texture.Width, texture.Height);
            bmpDataTexture = texture.LockBits(rectTexture, ImageLockMode.ReadWrite, texture.PixelFormat);
            int bytesTexture = Math.Abs(bmpDataTexture.Stride) * texture.Height;
            rgbValuesTexture = new byte[bytesTexture];
            System.Runtime.InteropServices.Marshal.Copy(bmpDataTexture.Scan0, rgbValuesTexture, 0, bytesTexture);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            figures = new List<Polyhedron>();
        }

        void Draw()
        {
            g.Clear(Color.White);
            if (showZBuf)
                show_z_buf();
            else
            {
                if (renderMode == 0)
                    //camera.showClipping(g, figure);
                    figure.Show(g, projection);
                else if (renderMode == RenderMode.Noclip)
                    figure.Show(g, projection);
                    //camera.show(g, figure);
                else if (renderMode == RenderMode.Gouraud)
                    show_gouraud();
                else if (renderMode == RenderMode.Texturing)
                    show_texture();
            }
        }

        private void show_gouraud()
        {
            float[] intensive = new float[pictureBox1.Width * pictureBox1.Height];

            figure.calc_gouraud(camera.view, pictureBox1.Width, pictureBox1.Height, out intensive, new Point3D(int.Parse(light_x.Text), int.Parse(light_y.Text), int.Parse(light_z.Text)));
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g.Clear(Color.White);

            for (int i = 0; i < pictureBox1.Width; ++i)
                for (int j = 0; j < pictureBox1.Height; ++j)
                {
                    Color c;
                    if (intensive[i * pictureBox1.Height + j] < 1E-6f)
                        c = Color.White;
                    else
                    {
                        float intsv = intensive[i * pictureBox1.Height + j];
                        if (intsv > 1)
                            intsv = 1;
                        c = Color.FromArgb((int)(fill_color.R * intsv) % 256, (int)(fill_color.G * intsv) % 256, (int)(fill_color.B * intsv) % 256);
                    }
                    bmp.SetPixel(i, j, c);
                }

            pictureBox1.Refresh();
        }

        private void show_texture()
        {
            if (bmp != null)
                bmp.Dispose();
            rgbValues = getRGBValues(out bmp, out bmpData, out ptr, out bytes);
            figure.ApplyTexture(bmp, bmpData, rgbValues, texture, bmpDataTexture, rgbValuesTexture);
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            bmp.UnlockBits(bmpData);
            pictureBox1.Image = bmp;
        }

        private byte[] getRGBValues(out Bitmap bmp, out BitmapData bmpData,
            out IntPtr ptr, out int bytes)
        {
            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height, PixelFormat.Format24bppRgb);

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            bmpData =
                bmp.LockBits(rect, ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgb_values = new byte[bytes];

            // Create rgb array with background color
            for (int i = 0; i < bytes - 3; i += 3)
            {
                rgb_values[i] = pictureBox1.BackColor.R;
                rgb_values[i + 1] = pictureBox1.BackColor.G;
                rgb_values[i + 2] = pictureBox1.BackColor.B;
            }

            return rgb_values;
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
                int rotateAngleX = (int)numericUpDown4.Value, 
                    rotateAngleY = (int)numericUpDown5.Value, 
                    rotateAngleZ = (int)numericUpDown6.Value;
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
            if (multiitem)
                figures.Add(figure);
            figure = new Polyhedron();
            figure.Tetrahedron();
            Draw();
        }

        private void createIcohedron_Click(object sender, EventArgs e)
        {
            if (multiitem)
                figures.Add(figure);
            figure = new Polyhedron();
            figure.Icosahedron();
            Draw();
        }

        private void createHexahedron_Click(object sender, EventArgs e)
        {
            if (multiitem)
                figures.Add(figure);
            figure = new Polyhedron();
            figure.Hexahedron();
            Draw();
        }

        private void createDodehedron_Click(object sender, EventArgs e)
        {
            if (multiitem)
                figures.Add(figure);
            figure = new Polyhedron();
            figure.Dodecahedron();
            Draw();
        }

        private void createOctahedron_Click(object sender, EventArgs e)
        {
            if (multiitem)
                figures.Add(figure);
            figure = new Polyhedron();
            figure.Octahedron();
            Draw();
        }

        

        //Z-BUFFER
        private void show_z_buf()
        {
            int[] buff = new int[pictureBox1.Width * pictureBox1.Height];
            figure.calculateZBuffer(pictureBox1.Width, pictureBox1.Height, out buff);

            if (multiitem)
            {
                foreach (var f in figures)
                {
                    f.addOnZBuffer(pictureBox1.Width, pictureBox1.Height, ref buff);
                }
            }

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
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.T:
                    break;
            }
        }

        

        private void defaultCameraButton_Click(object sender, EventArgs e)
        {
            camera.reset();
            numericUpDown13.Value = numericUpDown14.Value = numericUpDown15.Value =
            numericUpDown16.Value = numericUpDown17.Value = numericUpDown18.Value = 0;
        }

        //private void drawRotationButton_Click(object sender, EventArgs e)
        //{
        //    List<Point3D> points = new List<Point3D>();
        //    var lines = textBox1.Text.Split('\n');

        //    foreach (var p in lines)
        //    {
        //        var arr = ((string)p).Split(',');
        //        points.Add(new Point3D(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2])));
        //    }

        //    Axis axis = 0;
        //    switch (comboBox6.SelectedItem.ToString())
        //    {
        //        case "OX":
        //            axis = 0;
        //            break;
        //        case "OY":
        //            axis = Axis.AXIS_Y;
        //            break;
        //        case "OZ":
        //            axis = Axis.AXIS_Z;
        //            break;
        //        default:
        //            axis = 0;
        //            break;
        //    }

        //    RotationFigure rotateFigure = new RotationFigure(points, axis, (int)numericUpDown10.Value);

        //    figure = rotateFigure;

        //    Draw();
        //}

        private void clearButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            figures.Clear();
            Polyhedron figure = null;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            multiitem = !multiitem;
        }

        private void bufferCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            showZBuf = !showZBuf;
            Draw();
        }

        static public List<float> mul_matrix2(List<float> matr1, int m1, int n1, List<float> matr2, int m2, int n2)
        {
            if (n1 != m2)
                return new List<float>();
            int l = m1;
            int m = n1;
            int n = n2;

            List<float> c = new List<float>();
            for (int i = 0; i < l * n; ++i)
                c.Add(0f);

            for (int i = 0; i < l; ++i)
                for (int j = 0; j < n; ++j)
                {
                    for (int r = 0; r < m; ++r)
                        c[i * l + j] += matr1[i * m1 + r] * matr2[r * n2 + j];
                }
            return c;
        }

        private void texturingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (renderMode != RenderMode.Texturing)
                renderMode = RenderMode.Texturing;
            else renderMode = 0;
            Draw();
        }

        private void gouraudCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (renderMode != RenderMode.Gouraud)
                renderMode = RenderMode.Gouraud;
            else renderMode = 0;
            Draw();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            Graph = new Graphic(comboBox2.SelectedIndex);

            figure = Graph;

            g.Clear(Color.White);
            Graph.isGraph = true;
            //Graph.Show(g, 0);
            Graph.picture = pictureBox1;
            Graph.DrawGraphic();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                if (Graph != null)
                {
                    Graph.psi += 4;
                    Graph.DrawGraphic();
                }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Graph != null)
            {
                Graph.psi += 4;
                Graph.DrawGraphic();
            }
        }
    }
}
