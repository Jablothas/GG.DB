namespace GoodGameDB
{
    partial class AddPlaythrough
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPlaythrough));
            this.Panel_Input_Form = new System.Windows.Forms.Panel();
            this.Lbl_Confirm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_Note = new System.Windows.Forms.TextBox();
            this.DateBox_Year = new System.Windows.Forms.ComboBox();
            this.DateBox_Month = new System.Windows.Forms.ComboBox();
            this.DateBox_Day = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Panel_Border_Bottom = new System.Windows.Forms.Panel();
            this.Panel_Border_Left = new System.Windows.Forms.Panel();
            this.Panel_Border_Right = new System.Windows.Forms.Panel();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PicBox_Input_Close = new System.Windows.Forms.PictureBox();
            this.Playthrough_Header = new System.Windows.Forms.Panel();
            this.Label_Title = new System.Windows.Forms.Label();
            this.Panel_Input_Form.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Input_Close)).BeginInit();
            this.Playthrough_Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Input_Form
            // 
            this.Panel_Input_Form.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.Panel_Input_Form.Controls.Add(this.Lbl_Confirm);
            this.Panel_Input_Form.Controls.Add(this.label1);
            this.Panel_Input_Form.Controls.Add(this.TextBox_Note);
            this.Panel_Input_Form.Controls.Add(this.DateBox_Year);
            this.Panel_Input_Form.Controls.Add(this.DateBox_Month);
            this.Panel_Input_Form.Controls.Add(this.DateBox_Day);
            this.Panel_Input_Form.Controls.Add(this.label4);
            this.Panel_Input_Form.Controls.Add(this.Panel_Border_Bottom);
            this.Panel_Input_Form.Controls.Add(this.Panel_Border_Left);
            this.Panel_Input_Form.Controls.Add(this.Panel_Border_Right);
            this.Panel_Input_Form.Controls.Add(this.Btn_Save);
            this.Panel_Input_Form.Controls.Add(this.label6);
            this.Panel_Input_Form.Controls.Add(this.pictureBox2);
            this.Panel_Input_Form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Input_Form.Location = new System.Drawing.Point(0, 37);
            this.Panel_Input_Form.Name = "Panel_Input_Form";
            this.Panel_Input_Form.Size = new System.Drawing.Size(296, 224);
            this.Panel_Input_Form.TabIndex = 16;
            // 
            // Lbl_Confirm
            // 
            this.Lbl_Confirm.AutoSize = true;
            this.Lbl_Confirm.ForeColor = System.Drawing.Color.White;
            this.Lbl_Confirm.Location = new System.Drawing.Point(19, 182);
            this.Lbl_Confirm.Name = "Lbl_Confirm";
            this.Lbl_Confirm.Size = new System.Drawing.Size(262, 16);
            this.Lbl_Confirm.TabIndex = 229;
            this.Lbl_Confirm.Text = "Replay succesfully saved to database!";
            this.Lbl_Confirm.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 228;
            this.label1.Text = "Note";
            // 
            // TextBox_Note
            // 
            this.TextBox_Note.Location = new System.Drawing.Point(15, 126);
            this.TextBox_Note.Name = "TextBox_Note";
            this.TextBox_Note.Size = new System.Drawing.Size(218, 23);
            this.TextBox_Note.TabIndex = 227;
            // 
            // DateBox_Year
            // 
            this.DateBox_Year.FormattingEnabled = true;
            this.DateBox_Year.Items.AddRange(new object[] {
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.DateBox_Year.Location = new System.Drawing.Point(166, 64);
            this.DateBox_Year.Name = "DateBox_Year";
            this.DateBox_Year.Size = new System.Drawing.Size(117, 24);
            this.DateBox_Year.TabIndex = 66;
            // 
            // DateBox_Month
            // 
            this.DateBox_Month.FormattingEnabled = true;
            this.DateBox_Month.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.DateBox_Month.Location = new System.Drawing.Point(89, 64);
            this.DateBox_Month.Name = "DateBox_Month";
            this.DateBox_Month.Size = new System.Drawing.Size(70, 24);
            this.DateBox_Month.TabIndex = 65;
            // 
            // DateBox_Day
            // 
            this.DateBox_Day.FormattingEnabled = true;
            this.DateBox_Day.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.DateBox_Day.Location = new System.Drawing.Point(13, 64);
            this.DateBox_Day.Name = "DateBox_Day";
            this.DateBox_Day.Size = new System.Drawing.Size(70, 24);
            this.DateBox_Day.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 67;
            this.label4.Text = "Date";
            // 
            // Panel_Border_Bottom
            // 
            this.Panel_Border_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Panel_Border_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Border_Bottom.Location = new System.Drawing.Point(3, 221);
            this.Panel_Border_Bottom.Name = "Panel_Border_Bottom";
            this.Panel_Border_Bottom.Size = new System.Drawing.Size(290, 3);
            this.Panel_Border_Bottom.TabIndex = 63;
            // 
            // Panel_Border_Left
            // 
            this.Panel_Border_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Panel_Border_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_Border_Left.Location = new System.Drawing.Point(0, 0);
            this.Panel_Border_Left.Name = "Panel_Border_Left";
            this.Panel_Border_Left.Size = new System.Drawing.Size(3, 224);
            this.Panel_Border_Left.TabIndex = 63;
            // 
            // Panel_Border_Right
            // 
            this.Panel_Border_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Panel_Border_Right.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel_Border_Right.Location = new System.Drawing.Point(293, 0);
            this.Panel_Border_Right.Name = "Panel_Border_Right";
            this.Panel_Border_Right.Size = new System.Drawing.Size(3, 224);
            this.Panel_Border_Right.TabIndex = 62;
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.Btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Save.ForeColor = System.Drawing.Color.White;
            this.Btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Save.Image")));
            this.Btn_Save.Location = new System.Drawing.Point(17, 172);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(89, 36);
            this.Btn_Save.TabIndex = 15;
            this.Btn_Save.Text = "  Save";
            this.Btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(44, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Playthrough information";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // PicBox_Input_Close
            // 
            this.PicBox_Input_Close.Image = ((System.Drawing.Image)(resources.GetObject("PicBox_Input_Close.Image")));
            this.PicBox_Input_Close.Location = new System.Drawing.Point(265, 6);
            this.PicBox_Input_Close.Name = "PicBox_Input_Close";
            this.PicBox_Input_Close.Size = new System.Drawing.Size(24, 24);
            this.PicBox_Input_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBox_Input_Close.TabIndex = 3;
            this.PicBox_Input_Close.TabStop = false;
            this.PicBox_Input_Close.Click += new System.EventHandler(this.PicBox_Input_Close_Click);
            // 
            // Playthrough_Header
            // 
            this.Playthrough_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Playthrough_Header.Controls.Add(this.Label_Title);
            this.Playthrough_Header.Controls.Add(this.pictureBox1);
            this.Playthrough_Header.Controls.Add(this.PicBox_Input_Close);
            this.Playthrough_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Playthrough_Header.Location = new System.Drawing.Point(0, 0);
            this.Playthrough_Header.Margin = new System.Windows.Forms.Padding(4);
            this.Playthrough_Header.Name = "Playthrough_Header";
            this.Playthrough_Header.Size = new System.Drawing.Size(296, 37);
            this.Playthrough_Header.TabIndex = 15;
            this.Playthrough_Header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Playthrough_Header_MouseMove);
            // 
            // Label_Title
            // 
            this.Label_Title.AutoSize = true;
            this.Label_Title.ForeColor = System.Drawing.Color.White;
            this.Label_Title.Location = new System.Drawing.Point(34, 10);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(115, 16);
            this.Label_Title.TabIndex = 5;
            this.Label_Title.Text = "Add Playthrough";
            // 
            // AddPlaythrough
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 261);
            this.Controls.Add(this.Panel_Input_Form);
            this.Controls.Add(this.Playthrough_Header);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddPlaythrough";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPlaythrough";
            this.Panel_Input_Form.ResumeLayout(false);
            this.Panel_Input_Form.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Input_Close)).EndInit();
            this.Playthrough_Header.ResumeLayout(false);
            this.Playthrough_Header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Input_Form;
        private System.Windows.Forms.Panel Panel_Border_Bottom;
        private System.Windows.Forms.Panel Panel_Border_Left;
        private System.Windows.Forms.Panel Panel_Border_Right;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PicBox_Input_Close;
        private System.Windows.Forms.Panel Playthrough_Header;
        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.ComboBox DateBox_Year;
        private System.Windows.Forms.ComboBox DateBox_Month;
        private System.Windows.Forms.ComboBox DateBox_Day;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_Note;
        private System.Windows.Forms.Label Lbl_Confirm;
    }
}