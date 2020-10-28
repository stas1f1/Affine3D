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
    public partial class InputBoxWithRadioBut : Form
    {
        public InputBoxWithRadioBut()
        {
            InitializeComponent();
        }

        public int ResultText { get; private set; } = 0;

        private void OK_button_Click(object sender, EventArgs e)
        {
            if (radioButtonX.Checked) 
                ResultText = 1;
            else if (radioButtonY.Checked)
                ResultText = 2;
            else if (radioButtonZ.Checked)
                ResultText = 3;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
