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
    public partial class CoordinateBox : Form
    {
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;
        public int Z { get; private set; } = 0;

        public CoordinateBox()
        {
            InitializeComponent();
        }

        public CoordinateBox(string message, string title = "")
        {
            InitializeComponent();
            Text = title;
            label1.Text = message;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            X = int.Parse(textBox1.Text);
            Y = int.Parse(textBox2.Text);
            Z = int.Parse(textBox3.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void coordinateBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) buttonOK_Click(null, null);
        }
    }
}
