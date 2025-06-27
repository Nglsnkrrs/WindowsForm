namespace Questionnaire
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
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_Surname = new System.Windows.Forms.TextBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.listBox_Info = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_ExpotTXT = new System.Windows.Forms.Button();
            this.button_ImportTXT = new System.Windows.Forms.Button();
            this.button_ImportXML = new System.Windows.Forms.Button();
            this.button_ExpotXML = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBox_Name.Location = new System.Drawing.Point(14, 79);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(352, 38);
            this.textBox_Name.TabIndex = 0;
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBox_Phone.Location = new System.Drawing.Point(14, 502);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(352, 38);
            this.textBox_Phone.TabIndex = 1;
            // 
            // textBox_Email
            // 
            this.textBox_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBox_Email.Location = new System.Drawing.Point(14, 361);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(352, 38);
            this.textBox_Email.TabIndex = 2;
            // 
            // textBox_Surname
            // 
            this.textBox_Surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBox_Surname.Location = new System.Drawing.Point(14, 220);
            this.textBox_Surname.Name = "textBox_Surname";
            this.textBox_Surname.Size = new System.Drawing.Size(352, 38);
            this.textBox_Surname.TabIndex = 3;
            // 
            // button_Add
            // 
            this.button_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button_Add.Location = new System.Drawing.Point(45, 566);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(274, 55);
            this.button_Add.TabIndex = 4;
            this.button_Add.Text = "Добавить";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // listBox_Info
            // 
            this.listBox_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.listBox_Info.FormattingEnabled = true;
            this.listBox_Info.ItemHeight = 31;
            this.listBox_Info.Location = new System.Drawing.Point(399, 12);
            this.listBox_Info.Name = "listBox_Info";
            this.listBox_Info.ScrollAlwaysVisible = true;
            this.listBox_Info.Size = new System.Drawing.Size(846, 624);
            this.listBox_Info.TabIndex = 5;
            this.listBox_Info.SelectedIndexChanged += new System.EventHandler(this.listBox_Info_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(14, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(14, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "E-mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(14, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "Телефон";
            // 
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button_Delete.Location = new System.Drawing.Point(46, 144);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(274, 55);
            this.button_Delete.TabIndex = 10;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button_Edit.Location = new System.Drawing.Point(46, 55);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(274, 55);
            this.button_Edit.TabIndex = 11;
            this.button_Edit.Text = "Редактировать";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_ImportTXT);
            this.groupBox1.Controls.Add(this.button_ExpotTXT);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.groupBox1.Location = new System.Drawing.Point(442, 657);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 233);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TXT Файл";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_ImportXML);
            this.groupBox2.Controls.Add(this.button_ExpotXML);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.groupBox2.Location = new System.Drawing.Point(858, 657);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 233);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "XML Файл";
            // 
            // button_ExpotTXT
            // 
            this.button_ExpotTXT.Location = new System.Drawing.Point(28, 53);
            this.button_ExpotTXT.Name = "button_ExpotTXT";
            this.button_ExpotTXT.Size = new System.Drawing.Size(296, 57);
            this.button_ExpotTXT.TabIndex = 0;
            this.button_ExpotTXT.Text = "Экспорт в файл";
            this.button_ExpotTXT.UseVisualStyleBackColor = true;
            this.button_ExpotTXT.Click += new System.EventHandler(this.button_ExpotTXT_Click);
            // 
            // button_ImportTXT
            // 
            this.button_ImportTXT.Location = new System.Drawing.Point(28, 143);
            this.button_ImportTXT.Name = "button_ImportTXT";
            this.button_ImportTXT.Size = new System.Drawing.Size(296, 57);
            this.button_ImportTXT.TabIndex = 1;
            this.button_ImportTXT.Text = "Импорт из файла";
            this.button_ImportTXT.UseVisualStyleBackColor = true;
            this.button_ImportTXT.Click += new System.EventHandler(this.button_ImportTXT_Click);
            // 
            // button_ImportXML
            // 
            this.button_ImportXML.Location = new System.Drawing.Point(48, 143);
            this.button_ImportXML.Name = "button_ImportXML";
            this.button_ImportXML.Size = new System.Drawing.Size(296, 57);
            this.button_ImportXML.TabIndex = 3;
            this.button_ImportXML.Text = "Импорт из файла";
            this.button_ImportXML.UseVisualStyleBackColor = true;
            this.button_ImportXML.Click += new System.EventHandler(this.button_ImportXML_Click);
            // 
            // button_ExpotXML
            // 
            this.button_ExpotXML.Location = new System.Drawing.Point(48, 53);
            this.button_ExpotXML.Name = "button_ExpotXML";
            this.button_ExpotXML.Size = new System.Drawing.Size(296, 57);
            this.button_ExpotXML.TabIndex = 2;
            this.button_ExpotXML.Text = "Экспорт в файл";
            this.button_ExpotXML.UseVisualStyleBackColor = true;
            this.button_ExpotXML.Click += new System.EventHandler(this.button_ExpotXML_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_Edit);
            this.groupBox3.Controls.Add(this.button_Delete);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.groupBox3.Location = new System.Drawing.Point(26, 657);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 233);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Работа с пользователем";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 902);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_Info);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.textBox_Surname);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.textBox_Phone);
            this.Controls.Add(this.textBox_Name);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.TextBox textBox_Surname;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.ListBox listBox_Info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_ImportTXT;
        private System.Windows.Forms.Button button_ExpotTXT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_ImportXML;
        private System.Windows.Forms.Button button_ExpotXML;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

