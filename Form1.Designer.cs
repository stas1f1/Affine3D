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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            this.clearButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.moreButton = new System.Windows.Forms.Button();
            this.pointsTextBox = new System.Windows.Forms.TextBox();
            this.axisTextBox = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.addAxisButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.drawRotationButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.createDodehedron.Click += new System.EventHandler(this.createDodehedron_Click);
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
            this.createIcohedron.Click += new System.EventHandler(this.createIcohedron_Click);
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
            this.createTetrahedron.Click += new System.EventHandler(this.createTetrahedron_Click);
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
            this.createOctahedron.Click += new System.EventHandler(this.createOctahedron_Click);
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
            this.createHexahedron.Click += new System.EventHandler(this.createHexahedron_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(307, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(842, 717);
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
            this.turnAroundLineRadioButton.Click += new System.EventHandler(this.transformationRadioButton_Click);
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
            this.rotateAroundLineRadioButton.Click += new System.EventHandler(this.transformationRadioButton_Click);
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
            this.scaleAroundCenterRadioButton.Click += new System.EventHandler(this.transformationRadioButton_Click);
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
            this.reflectionRadioButton.Click += new System.EventHandler(this.transformationRadioButton_Click);
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
            this.scaleRadioButton.Click += new System.EventHandler(this.transformationRadioButton_Click);
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
            this.turnRadioButton.Click += new System.EventHandler(this.transformationRadioButton_Click);
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
            this.moveRadioButton.Click += new System.EventHandler(this.transformationRadioButton_Click);
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
            this.ortographRadioButton.Click += new System.EventHandler(this.proectionRadioButton_Click);
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
            this.perspectiveRadioButton.Click += new System.EventHandler(this.proectionRadioButton_Click);
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
            this.izometrRadioButton.Click += new System.EventHandler(this.proectionRadioButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Transparent;
            this.clearButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.clearButton.ForeColor = System.Drawing.Color.Black;
            this.clearButton.Location = new System.Drawing.Point(11, 607);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(283, 52);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.countTextBox);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.groupBox4.Location = new System.Drawing.Point(1163, 274);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(232, 68);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Разбиения:";
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(13, 24);
            this.countTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(209, 32);
            this.countTextBox.TabIndex = 10;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.moreButton);
            this.groupBox5.Controls.Add(this.pointsTextBox);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.groupBox5.Location = new System.Drawing.Point(1163, 142);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(232, 130);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Вращаемая ломаная:";
            // 
            // moreButton
            // 
            this.moreButton.Location = new System.Drawing.Point(13, 75);
            this.moreButton.Margin = new System.Windows.Forms.Padding(2);
            this.moreButton.Name = "moreButton";
            this.moreButton.Size = new System.Drawing.Size(209, 45);
            this.moreButton.TabIndex = 27;
            this.moreButton.Text = "Добавить еще";
            this.moreButton.UseVisualStyleBackColor = true;
            this.moreButton.Click += new System.EventHandler(this.moreButton_Click);
            // 
            // pointsTextBox
            // 
            this.pointsTextBox.Location = new System.Drawing.Point(13, 29);
            this.pointsTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.pointsTextBox.Multiline = true;
            this.pointsTextBox.Name = "pointsTextBox";
            this.pointsTextBox.ReadOnly = true;
            this.pointsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pointsTextBox.Size = new System.Drawing.Size(209, 39);
            this.pointsTextBox.TabIndex = 27;
            this.pointsTextBox.Text = "Добавьте точки";
            // 
            // axisTextBox
            // 
            this.axisTextBox.Location = new System.Drawing.Point(13, 28);
            this.axisTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.axisTextBox.Multiline = true;
            this.axisTextBox.Name = "axisTextBox";
            this.axisTextBox.ReadOnly = true;
            this.axisTextBox.Size = new System.Drawing.Size(209, 34);
            this.axisTextBox.TabIndex = 27;
            this.axisTextBox.Text = "{0, 0, 0}";
            this.axisTextBox.TextChanged += new System.EventHandler(this.axisTextBox_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.axisTextBox);
            this.groupBox6.Controls.Add(this.addAxisButton);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.groupBox6.Location = new System.Drawing.Point(1163, 12);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(232, 128);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ось вращения:";
            // 
            // addAxisButton
            // 
            this.addAxisButton.Location = new System.Drawing.Point(13, 69);
            this.addAxisButton.Margin = new System.Windows.Forms.Padding(2);
            this.addAxisButton.Name = "addAxisButton";
            this.addAxisButton.Size = new System.Drawing.Size(209, 48);
            this.addAxisButton.TabIndex = 0;
            this.addAxisButton.Text = "Добавить точку оси вращения";
            this.addAxisButton.UseVisualStyleBackColor = true;
            this.addAxisButton.Click += new System.EventHandler(this.addAxisButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.saveButton.ForeColor = System.Drawing.Color.Black;
            this.saveButton.Location = new System.Drawing.Point(11, 665);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(135, 52);
            this.saveButton.TabIndex = 29;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.Transparent;
            this.loadButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.loadButton.ForeColor = System.Drawing.Color.Black;
            this.loadButton.Location = new System.Drawing.Point(162, 665);
            this.loadButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(132, 52);
            this.loadButton.TabIndex = 30;
            this.loadButton.Text = "Загрузить";
            this.loadButton.UseVisualStyleBackColor = false;
            // 
            // drawRotationButton
            // 
            this.drawRotationButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.drawRotationButton.Location = new System.Drawing.Point(1163, 346);
            this.drawRotationButton.Margin = new System.Windows.Forms.Padding(2);
            this.drawRotationButton.Name = "drawRotationButton";
            this.drawRotationButton.Size = new System.Drawing.Size(232, 45);
            this.drawRotationButton.TabIndex = 28;
            this.drawRotationButton.Text = "Отрисовать фигуру";
            this.drawRotationButton.UseVisualStyleBackColor = true;
            this.drawRotationButton.Click += new System.EventHandler(this.drawRotationButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 741);
            this.Controls.Add(this.drawRotationButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.clearButton);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button moreButton;
        private System.Windows.Forms.TextBox pointsTextBox;
        private System.Windows.Forms.TextBox axisTextBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button addAxisButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button drawRotationButton;
    }
}

