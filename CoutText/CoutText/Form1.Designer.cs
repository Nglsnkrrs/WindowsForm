namespace CoutText
{
    partial class Form1
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
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.buttonGetProgress = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.textBox_FileName.Location = new System.Drawing.Point(19, 86);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(415, 45);
            this.textBox_FileName.TabIndex = 0;
            // 
            // buttonGetProgress
            // 
            this.buttonGetProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonGetProgress.Location = new System.Drawing.Point(480, 42);
            this.buttonGetProgress.Name = "buttonGetProgress";
            this.buttonGetProgress.Size = new System.Drawing.Size(263, 72);
            this.buttonGetProgress.TabIndex = 1;
            this.buttonGetProgress.Text = "Получить количество текста";
            this.buttonGetProgress.UseVisualStyleBackColor = true;
            this.buttonGetProgress.Click += new System.EventHandler(this.buttonGetProgress_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(19, 216);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(724, 34);
            this.progressBar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите название файла";
            // 
            // label_Progress
            // 
            this.label_Progress.AutoSize = true;
            this.label_Progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label_Progress.Location = new System.Drawing.Point(12, 160);
            this.label_Progress.Name = "label_Progress";
            this.label_Progress.Size = new System.Drawing.Size(0, 39);
            this.label_Progress.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 302);
            this.Controls.Add(this.label_Progress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonGetProgress);
            this.Controls.Add(this.textBox_FileName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.Button buttonGetProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Progress;
    }
}

