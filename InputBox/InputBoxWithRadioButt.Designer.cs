namespace Affine3D
{
    partial class InputBoxWithRadioButt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonY = new System.Windows.Forms.RadioButton();
            this.radioButtonZ = new System.Windows.Forms.RadioButton();
            this.radioButtonX = new System.Windows.Forms.RadioButton();
            this.OK_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButtonY
            // 
            this.radioButtonY.AutoSize = true;
            this.radioButtonY.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.radioButtonY.Location = new System.Drawing.Point(11, 44);
            this.radioButtonY.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonY.Name = "radioButtonY";
            this.radioButtonY.Size = new System.Drawing.Size(340, 29);
            this.radioButtonY.TabIndex = 10;
            this.radioButtonY.TabStop = true;
            this.radioButtonY.Text = "изометрическая проекция по оси Y";
            this.radioButtonY.UseVisualStyleBackColor = true;
            // 
            // radioButtonZ
            // 
            this.radioButtonZ.AutoSize = true;
            this.radioButtonZ.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.radioButtonZ.Location = new System.Drawing.Point(11, 77);
            this.radioButtonZ.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonZ.Name = "radioButtonZ";
            this.radioButtonZ.Size = new System.Drawing.Size(340, 29);
            this.radioButtonZ.TabIndex = 9;
            this.radioButtonZ.TabStop = true;
            this.radioButtonZ.Text = "изометрическая проекция по оси Z";
            this.radioButtonZ.UseVisualStyleBackColor = true;
            // 
            // radioButtonX
            // 
            this.radioButtonX.AutoSize = true;
            this.radioButtonX.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.radioButtonX.Location = new System.Drawing.Point(11, 11);
            this.radioButtonX.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonX.Name = "radioButtonX";
            this.radioButtonX.Size = new System.Drawing.Size(340, 29);
            this.radioButtonX.TabIndex = 8;
            this.radioButtonX.TabStop = true;
            this.radioButtonX.Text = "изометрическая проекция по оси X";
            this.radioButtonX.UseVisualStyleBackColor = true;
            // 
            // OK_button
            // 
            this.OK_button.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.OK_button.Location = new System.Drawing.Point(11, 110);
            this.OK_button.Margin = new System.Windows.Forms.Padding(2);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(340, 53);
            this.OK_button.TabIndex = 7;
            this.OK_button.Text = "OK";
            this.OK_button.UseVisualStyleBackColor = true;
            this.OK_button.Click += new System.EventHandler(this.OK_button_Click);
            // 
            // InputBoxWithRadioButt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 177);
            this.Controls.Add(this.radioButtonY);
            this.Controls.Add(this.radioButtonZ);
            this.Controls.Add(this.radioButtonX);
            this.Controls.Add(this.OK_button);
            this.Name = "InputBoxWithRadioButt";
            this.Text = "InputBoxWithRadioButt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonY;
        private System.Windows.Forms.RadioButton radioButtonZ;
        private System.Windows.Forms.RadioButton radioButtonX;
        private System.Windows.Forms.Button OK_button;
    }
}