namespace Affine3D
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createDodehedron = new System.Windows.Forms.Button();
            this.createIcohedron = new System.Windows.Forms.Button();
            this.createTetrahedron = new System.Windows.Forms.Button();
            this.createOctahedron = new System.Windows.Forms.Button();
            this.createHexahedron = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.turnAroundLineRadioButton = new System.Windows.Forms.RadioButton();
            this.rotateAroundLineRadioButton = new System.Windows.Forms.RadioButton();
            this.scaleAroundCenterRadioButton = new System.Windows.Forms.RadioButton();
            this.reflectionRadioButton = new System.Windows.Forms.RadioButton();
            this.scaleRadioButton = new System.Windows.Forms.RadioButton();
            this.turnRadioButton = new System.Windows.Forms.RadioButton();
            this.moveRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ortographRadioButton = new System.Windows.Forms.RadioButton();
            this.perspectiveRadioButton = new System.Windows.Forms.RadioButton();
            this.izometrRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createDodehedron);
            this.groupBox1.Controls.Add(this.createIcohedron);
            this.groupBox1.Controls.Add(this.createTetrahedron);
            this.groupBox1.Controls.Add(this.createOctahedron);
            this.groupBox1.Controls.Add(this.createHexahedron);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(283, 151);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить";
            // 
            // createDodehedron
            // 
            this.createDodehedron.Location = new System.Drawing.Point(151, 66);
            this.createDodehedron.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.createDodehedron.Name = "createDodehedron";
            this.createDodehedron.Size = new System.Drawing.Size(128, 32);
            this.createDodehedron.TabIndex = 4;
            this.createDodehedron.Text = "Додекаэдр";
            this.createDodehedron.UseVisualStyleBackColor = true;
            // 
            // createIcohedron
            // 
            this.createIcohedron.Location = new System.Drawing.Point(151, 28);
            this.createIcohedron.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.createIcohedron.Name = "createIcohedron";
            this.createIcohedron.Size = new System.Drawing.Size(128, 32);
            this.createIcohedron.TabIndex = 3;
            this.createIcohedron.Text = "Икосаэдр";
            this.createIcohedron.UseVisualStyleBackColor = true;
            // 
            // createTetrahedron
            // 
            this.createTetrahedron.Location = new System.Drawing.Point(7, 28);
            this.createTetrahedron.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.createTetrahedron.Name = "createTetrahedron";
            this.createTetrahedron.Size = new System.Drawing.Size(128, 32);
            this.createTetrahedron.TabIndex = 0;
            this.createTetrahedron.Text = "Тетраэдр";
            this.createTetrahedron.UseVisualStyleBackColor = true;
            // 
            // createOctahedron
            // 
            this.createOctahedron.Location = new System.Drawing.Point(7, 104);
            this.createOctahedron.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.createOctahedron.Name = "createOctahedron";
            this.createOctahedron.Size = new System.Drawing.Size(128, 32);
            this.createOctahedron.TabIndex = 2;
            this.createOctahedron.Text = "Октаэдр";
            this.createOctahedron.UseVisualStyleBackColor = true;
            // 
            // createHexahedron
            // 
            this.createHexahedron.Location = new System.Drawing.Point(7, 66);
            this.createHexahedron.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.createHexahedron.Name = "createHexahedron";
            this.createHexahedron.Size = new System.Drawing.Size(128, 32);
            this.createHexahedron.TabIndex = 1;
            this.createHexahedron.Text = "Гексаэдр";
            this.createHexahedron.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(307, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(957, 717);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.turnAroundLineRadioButton);
            this.groupBox2.Controls.Add(this.rotateAroundLineRadioButton);
            this.groupBox2.Controls.Add(this.scaleAroundCenterRadioButton);
            this.groupBox2.Controls.Add(this.reflectionRadioButton);
            this.groupBox2.Controls.Add(this.scaleRadioButton);
            this.groupBox2.Controls.Add(this.turnRadioButton);
            this.groupBox2.Controls.Add(this.moveRadioButton);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.groupBox2.Location = new System.Drawing.Point(11, 169);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(283, 286);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Преобразовать";
            // 
            // turnAroundLineRadioButton
            // 
            this.turnAroundLineRadioButton.AutoSize = true;
            this.turnAroundLineRadioButton.Location = new System.Drawing.Point(12, 241);
            this.turnAroundLineRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.turnAroundLineRadioButton.Name = "turnAroundLineRadioButton";
            this.turnAroundLineRadioButton.Size = new System.Drawing.Size(240, 29);
            this.turnAroundLineRadioButton.TabIndex = 11;
            this.turnAroundLineRadioButton.TabStop = true;
            this.turnAroundLineRadioButton.Text = "Поворот вокруг прямой";
            this.turnAroundLineRadioButton.UseVisualStyleBackColor = true;
            // 
            // rotateAroundLineRadioButton
            // 
            this.rotateAroundLineRadioButton.AutoSize = true;
            this.rotateAroundLineRadioButton.Location = new System.Drawing.Point(12, 206);
            this.rotateAroundLineRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rotateAroundLineRadioButton.Name = "rotateAroundLineRadioButton";
            this.rotateAroundLineRadioButton.Size = new System.Drawing.Size(254, 29);
            this.rotateAroundLineRadioButton.TabIndex = 10;
            this.rotateAroundLineRadioButton.TabStop = true;
            this.rotateAroundLineRadioButton.Text = "Вращение вокруг прямой";
            this.rotateAroundLineRadioButton.UseVisualStyleBackColor = true;
            // 
            // scaleAroundCenterRadioButton
            // 
            this.scaleAroundCenterRadioButton.AutoSize = true;
            this.scaleAroundCenterRadioButton.Location = new System.Drawing.Point(12, 136);
            this.scaleAroundCenterRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.scaleAroundCenterRadioButton.Name = "scaleAroundCenterRadioButton";
            this.scaleAroundCenterRadioButton.Size = new System.Drawing.Size(235, 29);
            this.scaleAroundCenterRadioButton.TabIndex = 9;
            this.scaleAroundCenterRadioButton.TabStop = true;
            this.scaleAroundCenterRadioButton.Text = "Масштаб относ. центра";
            this.scaleAroundCenterRadioButton.UseVisualStyleBackColor = true;
            // 
            // reflectionRadioButton
            // 
            this.reflectionRadioButton.AutoSize = true;
            this.reflectionRadioButton.Location = new System.Drawing.Point(12, 171);
            this.reflectionRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.reflectionRadioButton.Name = "reflectionRadioButton";
            this.reflectionRadioButton.Size = new System.Drawing.Size(261, 29);
            this.reflectionRadioButton.TabIndex = 8;
            this.reflectionRadioButton.TabStop = true;
            this.reflectionRadioButton.Text = "Отражение относ. к плоск.";
            this.reflectionRadioButton.UseVisualStyleBackColor = true;
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
            this.groupBox3.Location = new System.Drawing.Point(11, 461);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(283, 140);
            this.groupBox3.TabIndex = 9;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(11, 607);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(283, 122);
            this.button1.TabIndex = 5;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 741);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button createDodehedron;
        private System.Windows.Forms.Button createIcohedron;
        private System.Windows.Forms.Button createTetrahedron;
        private System.Windows.Forms.Button createOctahedron;
        private System.Windows.Forms.Button createHexahedron;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton turnAroundLineRadioButton;
        private System.Windows.Forms.RadioButton rotateAroundLineRadioButton;
        private System.Windows.Forms.RadioButton scaleAroundCenterRadioButton;
        private System.Windows.Forms.RadioButton reflectionRadioButton;
        private System.Windows.Forms.RadioButton scaleRadioButton;
        private System.Windows.Forms.RadioButton turnRadioButton;
        private System.Windows.Forms.RadioButton moveRadioButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton ortographRadioButton;
        private System.Windows.Forms.RadioButton perspectiveRadioButton;
        private System.Windows.Forms.RadioButton izometrRadioButton;
        private System.Windows.Forms.Button button1;
    }
}

