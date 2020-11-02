namespace Affine3D
{
    partial class Loader
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
            this.task3Button = new System.Windows.Forms.Button();
            this.task2Button = new System.Windows.Forms.Button();
            this.task1Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // task3Button
            // 
            this.task3Button.Location = new System.Drawing.Point(31, 164);
            this.task3Button.Margin = new System.Windows.Forms.Padding(2);
            this.task3Button.Name = "task3Button";
            this.task3Button.Size = new System.Drawing.Size(213, 68);
            this.task3Button.TabIndex = 5;
            this.task3Button.Text = "Построение графика двух переменных";
            this.task3Button.UseVisualStyleBackColor = true;
            this.task3Button.Click += new System.EventHandler(this.task3Button_Click);
            // 
            // task2Button
            // 
            this.task2Button.Location = new System.Drawing.Point(31, 86);
            this.task2Button.Margin = new System.Windows.Forms.Padding(2);
            this.task2Button.Name = "task2Button";
            this.task2Button.Size = new System.Drawing.Size(213, 64);
            this.task2Button.TabIndex = 4;
            this.task2Button.Text = "Построение фигуры вращения";
            this.task2Button.UseVisualStyleBackColor = true;
            this.task2Button.Click += new System.EventHandler(this.task2Button_Click);
            // 
            // task1Button
            // 
            this.task1Button.Location = new System.Drawing.Point(31, 11);
            this.task1Button.Margin = new System.Windows.Forms.Padding(2);
            this.task1Button.Name = "task1Button";
            this.task1Button.Size = new System.Drawing.Size(213, 64);
            this.task1Button.TabIndex = 3;
            this.task1Button.Text = "Модель многогранника из файла";
            this.task1Button.UseVisualStyleBackColor = true;
            this.task1Button.Click += new System.EventHandler(this.task1Button_Click);
            // 
            // Loader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 263);
            this.Controls.Add(this.task3Button);
            this.Controls.Add(this.task2Button);
            this.Controls.Add(this.task1Button);
            this.Name = "Loader";
            this.Text = "Loader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button task3Button;
        private System.Windows.Forms.Button task2Button;
        private System.Windows.Forms.Button task1Button;
    }
}