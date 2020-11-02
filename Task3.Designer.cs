namespace Affine3D
{
    partial class Task3
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.formula1 = new System.Windows.Forms.Button();
            this.formula3 = new System.Windows.Forms.Button();
            this.formula2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.StepTextBox = new System.Windows.Forms.TextBox();
            this.Y1_textBox = new System.Windows.Forms.TextBox();
            this.Y0_textBox = new System.Windows.Forms.TextBox();
            this.X1_textBox = new System.Windows.Forms.TextBox();
            this.X0_textBox = new System.Windows.Forms.TextBox();
            this.Step_label = new System.Windows.Forms.Label();
            this.Ylabel = new System.Windows.Forms.Label();
            this.Xlabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.scaleRadioButton = new System.Windows.Forms.RadioButton();
            this.turnRadioButton = new System.Windows.Forms.RadioButton();
            this.moveRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ortographRadioButton = new System.Windows.Forms.RadioButton();
            this.perspectiveRadioButton = new System.Windows.Forms.RadioButton();
            this.izometrRadioButton = new System.Windows.Forms.RadioButton();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(307, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(957, 717);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.formula1);
            this.groupBox1.Controls.Add(this.formula3);
            this.groupBox1.Controls.Add(this.formula2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(292, 176);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить";
            // 
            // formula1
            // 
            this.formula1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.formula1.Location = new System.Drawing.Point(8, 19);
            this.formula1.Margin = new System.Windows.Forms.Padding(2);
            this.formula1.Name = "formula1";
            this.formula1.Size = new System.Drawing.Size(265, 40);
            this.formula1.TabIndex = 0;
            this.formula1.Text = "x^2 + y^2 = z";
            this.formula1.UseVisualStyleBackColor = true;
            // 
            // formula3
            // 
            this.formula3.Location = new System.Drawing.Point(8, 124);
            this.formula3.Margin = new System.Windows.Forms.Padding(2);
            this.formula3.Name = "formula3";
            this.formula3.Size = new System.Drawing.Size(265, 38);
            this.formula3.TabIndex = 2;
            this.formula3.Text = "x^2 - y^2 = z";
            this.formula3.UseVisualStyleBackColor = true;
            // 
            // formula2
            // 
            this.formula2.Location = new System.Drawing.Point(8, 71);
            this.formula2.Margin = new System.Windows.Forms.Padding(2);
            this.formula2.Name = "formula2";
            this.formula2.Size = new System.Drawing.Size(265, 40);
            this.formula2.TabIndex = 1;
            this.formula2.Text = "1/(1+x^2) + 1/(1+y^2) = z";
            this.formula2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.button1.Location = new System.Drawing.Point(178, 272);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 40);
            this.button1.TabIndex = 36;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // StepTextBox
            // 
            this.StepTextBox.Location = new System.Drawing.Point(253, 248);
            this.StepTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.StepTextBox.Name = "StepTextBox";
            this.StepTextBox.Size = new System.Drawing.Size(50, 20);
            this.StepTextBox.TabIndex = 35;
            // 
            // Y1_textBox
            // 
            this.Y1_textBox.Location = new System.Drawing.Point(134, 247);
            this.Y1_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.Y1_textBox.Name = "Y1_textBox";
            this.Y1_textBox.Size = new System.Drawing.Size(51, 20);
            this.Y1_textBox.TabIndex = 34;
            // 
            // Y0_textBox
            // 
            this.Y0_textBox.Location = new System.Drawing.Point(19, 246);
            this.Y0_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.Y0_textBox.Name = "Y0_textBox";
            this.Y0_textBox.Size = new System.Drawing.Size(50, 20);
            this.Y0_textBox.TabIndex = 33;
            // 
            // X1_textBox
            // 
            this.X1_textBox.Location = new System.Drawing.Point(134, 211);
            this.X1_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.X1_textBox.Name = "X1_textBox";
            this.X1_textBox.Size = new System.Drawing.Size(51, 20);
            this.X1_textBox.TabIndex = 32;
            // 
            // X0_textBox
            // 
            this.X0_textBox.Location = new System.Drawing.Point(19, 211);
            this.X0_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.X0_textBox.Name = "X0_textBox";
            this.X0_textBox.Size = new System.Drawing.Size(50, 20);
            this.X0_textBox.TabIndex = 31;
            // 
            // Step_label
            // 
            this.Step_label.AutoSize = true;
            this.Step_label.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Step_label.Location = new System.Drawing.Point(190, 243);
            this.Step_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Step_label.Name = "Step_label";
            this.Step_label.Size = new System.Drawing.Size(67, 25);
            this.Step_label.TabIndex = 30;
            this.Step_label.Text = "Шаг = ";
            // 
            // Ylabel
            // 
            this.Ylabel.AutoSize = true;
            this.Ylabel.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Ylabel.Location = new System.Drawing.Point(73, 242);
            this.Ylabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Ylabel.Name = "Ylabel";
            this.Ylabel.Size = new System.Drawing.Size(56, 25);
            this.Ylabel.TabIndex = 29;
            this.Ylabel.Text = "< Y <";
            // 
            // Xlabel
            // 
            this.Xlabel.AutoSize = true;
            this.Xlabel.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.Xlabel.Location = new System.Drawing.Point(73, 209);
            this.Xlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Xlabel.Name = "Xlabel";
            this.Xlabel.Size = new System.Drawing.Size(57, 25);
            this.Xlabel.TabIndex = 28;
            this.Xlabel.Text = "< X <";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.scaleRadioButton);
            this.groupBox2.Controls.Add(this.turnRadioButton);
            this.groupBox2.Controls.Add(this.moveRadioButton);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.groupBox2.Location = new System.Drawing.Point(11, 317);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(283, 149);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Преобразовать";
            // 
            // scaleRadioButton
            // 
            this.scaleRadioButton.AutoSize = true;
            this.scaleRadioButton.Location = new System.Drawing.Point(12, 101);
            this.scaleRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scaleRadioButton.Name = "scaleRadioButton";
            this.scaleRadioButton.Size = new System.Drawing.Size(110, 29);
            this.scaleRadioButton.TabIndex = 7;
            this.scaleRadioButton.TabStop = true;
            this.scaleRadioButton.Text = "Масштаб";
            this.scaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // turnRadioButton
            // 
            this.turnRadioButton.AutoSize = true;
            this.turnRadioButton.Location = new System.Drawing.Point(12, 66);
            this.turnRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.turnRadioButton.Name = "turnRadioButton";
            this.turnRadioButton.Size = new System.Drawing.Size(106, 29);
            this.turnRadioButton.TabIndex = 6;
            this.turnRadioButton.TabStop = true;
            this.turnRadioButton.Text = "Поворот";
            this.turnRadioButton.UseVisualStyleBackColor = true;
            // 
            // moveRadioButton
            // 
            this.moveRadioButton.AutoSize = true;
            this.moveRadioButton.Location = new System.Drawing.Point(12, 31);
            this.moveRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.moveRadioButton.Name = "moveRadioButton";
            this.moveRadioButton.Size = new System.Drawing.Size(123, 29);
            this.moveRadioButton.TabIndex = 5;
            this.moveRadioButton.TabStop = true;
            this.moveRadioButton.Text = "Смещение";
            this.moveRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ortographRadioButton);
            this.groupBox3.Controls.Add(this.perspectiveRadioButton);
            this.groupBox3.Controls.Add(this.izometrRadioButton);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.groupBox3.Location = new System.Drawing.Point(11, 472);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(283, 140);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Проекция";
            // 
            // ortographRadioButton
            // 
            this.ortographRadioButton.AutoSize = true;
            this.ortographRadioButton.Location = new System.Drawing.Point(12, 101);
            this.ortographRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ortographRadioButton.Name = "ortographRadioButton";
            this.ortographRadioButton.Size = new System.Drawing.Size(185, 29);
            this.ortographRadioButton.TabIndex = 10;
            this.ortographRadioButton.Text = "Ортографическая";
            this.ortographRadioButton.UseVisualStyleBackColor = true;
            // 
            // perspectiveRadioButton
            // 
            this.perspectiveRadioButton.AutoSize = true;
            this.perspectiveRadioButton.Checked = true;
            this.perspectiveRadioButton.Location = new System.Drawing.Point(12, 31);
            this.perspectiveRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.perspectiveRadioButton.Name = "perspectiveRadioButton";
            this.perspectiveRadioButton.Size = new System.Drawing.Size(164, 29);
            this.perspectiveRadioButton.TabIndex = 8;
            this.perspectiveRadioButton.TabStop = true;
            this.perspectiveRadioButton.Text = "Перспективная";
            this.perspectiveRadioButton.UseVisualStyleBackColor = true;
            // 
            // izometrRadioButton
            // 
            this.izometrRadioButton.AutoSize = true;
            this.izometrRadioButton.Location = new System.Drawing.Point(12, 66);
            this.izometrRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.izometrRadioButton.Name = "izometrRadioButton";
            this.izometrRadioButton.Size = new System.Drawing.Size(175, 29);
            this.izometrRadioButton.TabIndex = 9;
            this.izometrRadioButton.Text = "Изометрическая";
            this.izometrRadioButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.loadButton.Location = new System.Drawing.Point(7, 617);
            this.loadButton.Margin = new System.Windows.Forms.Padding(2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(139, 42);
            this.loadButton.TabIndex = 39;
            this.loadButton.Text = "Загрузить";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.saveButton.Location = new System.Drawing.Point(150, 617);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(144, 42);
            this.saveButton.TabIndex = 40;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Transparent;
            this.clearButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.clearButton.ForeColor = System.Drawing.Color.Black;
            this.clearButton.Location = new System.Drawing.Point(7, 664);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(287, 64);
            this.clearButton.TabIndex = 41;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = false;
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 741);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StepTextBox);
            this.Controls.Add(this.Y1_textBox);
            this.Controls.Add(this.Y0_textBox);
            this.Controls.Add(this.X1_textBox);
            this.Controls.Add(this.X0_textBox);
            this.Controls.Add(this.Step_label);
            this.Controls.Add(this.Ylabel);
            this.Controls.Add(this.Xlabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Task3";
            this.Text = "Task3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button formula1;
        private System.Windows.Forms.Button formula3;
        private System.Windows.Forms.Button formula2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox StepTextBox;
        private System.Windows.Forms.TextBox Y1_textBox;
        private System.Windows.Forms.TextBox Y0_textBox;
        private System.Windows.Forms.TextBox X1_textBox;
        private System.Windows.Forms.TextBox X0_textBox;
        private System.Windows.Forms.Label Step_label;
        private System.Windows.Forms.Label Ylabel;
        private System.Windows.Forms.Label Xlabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton scaleRadioButton;
        private System.Windows.Forms.RadioButton turnRadioButton;
        private System.Windows.Forms.RadioButton moveRadioButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton ortographRadioButton;
        private System.Windows.Forms.RadioButton perspectiveRadioButton;
        private System.Windows.Forms.RadioButton izometrRadioButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button clearButton;
    }
}