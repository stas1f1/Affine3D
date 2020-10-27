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
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public InputBox(string message, string title = "", string defaultValue = "")
        {
            InitializeComponent();
            Text = title;
            label.Text = message;
            textBox.Text = defaultValue;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ResultText = textBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string ResultText { get; private set; } = "";

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                buttonOK_Click(null, null);
        }
    }
}
