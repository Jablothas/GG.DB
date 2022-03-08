namespace GoodGameDB
{
    partial class Database
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Database));
            this.Panel_Database_Header = new System.Windows.Forms.Panel();
            this.Btn_Settings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckReplays = new System.Windows.Forms.CheckBox();
            this.Btn_Reload = new System.Windows.Forms.PictureBox();
            this.Btn_Numbers = new System.Windows.Forms.Button();
            this.Btn_Input = new System.Windows.Forms.Button();
            this.Btn_Date = new System.Windows.Forms.Button();
            this.Btn_Location = new System.Windows.Forms.Button();
            this.Btn_Playthroughs = new System.Windows.Forms.Button();
            this.Btn_Game = new System.Windows.Forms.Button();
            this.Btn_Score = new System.Windows.Forms.Button();
            this.Label_Search = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.Panel_Database_Header_Splitter = new System.Windows.Forms.Panel();
            this.Panel_Database = new System.Windows.Forms.Panel();
            this.Panel_Delete_Confirm = new System.Windows.Forms.Panel();
            this.Label_Delete_Confirm = new System.Windows.Forms.Label();
            this.Btn_Delete_Confirm = new System.Windows.Forms.Button();
            this.Btn_Delete_No = new System.Windows.Forms.Button();
            this.Panel_Database_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Reload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Panel_Database.SuspendLayout();
            this.Panel_Delete_Confirm.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Database_Header
            // 
            this.Panel_Database_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.Panel_Database_Header.Controls.Add(this.Btn_Settings);
            this.Panel_Database_Header.Controls.Add(this.label2);
            this.Panel_Database_Header.Controls.Add(this.label1);
            this.Panel_Database_Header.Controls.Add(this.CheckReplays);
            this.Panel_Database_Header.Controls.Add(this.Btn_Reload);
            this.Panel_Database_Header.Controls.Add(this.Btn_Numbers);
            this.Panel_Database_Header.Controls.Add(this.Btn_Input);
            this.Panel_Database_Header.Controls.Add(this.Btn_Date);
            this.Panel_Database_Header.Controls.Add(this.Btn_Location);
            this.Panel_Database_Header.Controls.Add(this.Btn_Playthroughs);
            this.Panel_Database_Header.Controls.Add(this.Btn_Game);
            this.Panel_Database_Header.Controls.Add(this.Btn_Score);
            this.Panel_Database_Header.Controls.Add(this.Label_Search);
            this.Panel_Database_Header.Controls.Add(this.pictureBox1);
            this.Panel_Database_Header.Controls.Add(this.SearchBar);
            this.Panel_Database_Header.Controls.Add(this.Panel_Database_Header_Splitter);
            this.Panel_Database_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Database_Header.Location = new System.Drawing.Point(0, 0);
            this.Panel_Database_Header.Name = "Panel_Database_Header";
            this.Panel_Database_Header.Size = new System.Drawing.Size(1200, 93);
            this.Panel_Database_Header.TabIndex = 1;
            // 
            // Btn_Settings
            // 
            this.Btn_Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.Btn_Settings.FlatAppearance.BorderSize = 0;
            this.Btn_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Settings.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Settings.ForeColor = System.Drawing.Color.White;
            this.Btn_Settings.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Settings.Image")));
            this.Btn_Settings.Location = new System.Drawing.Point(1085, 7);
            this.Btn_Settings.Name = "Btn_Settings";
            this.Btn_Settings.Size = new System.Drawing.Size(103, 40);
            this.Btn_Settings.TabIndex = 20;
            this.Btn_Settings.Text = "Settings";
            this.Btn_Settings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Settings.UseVisualStyleBackColor = false;
            this.Btn_Settings.Click += new System.EventHandler(this.Btn_Settings_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(390, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "refresh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(245, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "include replays";
            // 
            // CheckReplays
            // 
            this.CheckReplays.AutoSize = true;
            this.CheckReplays.Location = new System.Drawing.Point(224, 40);
            this.CheckReplays.Name = "CheckReplays";
            this.CheckReplays.Size = new System.Drawing.Size(15, 14);
            this.CheckReplays.TabIndex = 17;
            this.CheckReplays.UseVisualStyleBackColor = true;
            this.CheckReplays.CheckedChanged += new System.EventHandler(this.CheckReplays_CheckedChanged);
            // 
            // Btn_Reload
            // 
            this.Btn_Reload.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Reload.Image")));
            this.Btn_Reload.Location = new System.Drawing.Point(368, 38);
            this.Btn_Reload.Name = "Btn_Reload";
            this.Btn_Reload.Size = new System.Drawing.Size(16, 16);
            this.Btn_Reload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Btn_Reload.TabIndex = 16;
            this.Btn_Reload.TabStop = false;
            this.Btn_Reload.Click += new System.EventHandler(this.Btn_Reload_Click);
            // 
            // Btn_Numbers
            // 
            this.Btn_Numbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.Btn_Numbers.FlatAppearance.BorderSize = 0;
            this.Btn_Numbers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Numbers.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Numbers.ForeColor = System.Drawing.Color.White;
            this.Btn_Numbers.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Numbers.Image")));
            this.Btn_Numbers.Location = new System.Drawing.Point(897, 7);
            this.Btn_Numbers.Name = "Btn_Numbers";
            this.Btn_Numbers.Size = new System.Drawing.Size(90, 40);
            this.Btn_Numbers.TabIndex = 15;
            this.Btn_Numbers.Text = "Stats";
            this.Btn_Numbers.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Numbers.UseVisualStyleBackColor = false;
            this.Btn_Numbers.Click += new System.EventHandler(this.Btn_Numbers_Click);
            // 
            // Btn_Input
            // 
            this.Btn_Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.Btn_Input.FlatAppearance.BorderSize = 0;
            this.Btn_Input.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Input.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Input.ForeColor = System.Drawing.Color.White;
            this.Btn_Input.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Input.Image")));
            this.Btn_Input.Location = new System.Drawing.Point(993, 7);
            this.Btn_Input.Name = "Btn_Input";
            this.Btn_Input.Size = new System.Drawing.Size(90, 40);
            this.Btn_Input.TabIndex = 14;
            this.Btn_Input.Text = "New";
            this.Btn_Input.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Input.UseVisualStyleBackColor = false;
            this.Btn_Input.Click += new System.EventHandler(this.Btn_Input_Click);
            // 
            // Btn_Date
            // 
            this.Btn_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.Btn_Date.FlatAppearance.BorderSize = 0;
            this.Btn_Date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Date.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.Btn_Date.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Date.Image")));
            this.Btn_Date.Location = new System.Drawing.Point(1075, 60);
            this.Btn_Date.Name = "Btn_Date";
            this.Btn_Date.Size = new System.Drawing.Size(66, 25);
            this.Btn_Date.TabIndex = 13;
            this.Btn_Date.Text = "Date";
            this.Btn_Date.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Date.UseVisualStyleBackColor = false;
            this.Btn_Date.Click += new System.EventHandler(this.Btn_Date_Click);
            // 
            // Btn_Location
            // 
            this.Btn_Location.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.Btn_Location.FlatAppearance.BorderSize = 0;
            this.Btn_Location.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Location.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Location.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.Btn_Location.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Location.Image")));
            this.Btn_Location.Location = new System.Drawing.Point(940, 60);
            this.Btn_Location.Name = "Btn_Location";
            this.Btn_Location.Size = new System.Drawing.Size(106, 25);
            this.Btn_Location.TabIndex = 12;
            this.Btn_Location.Text = "Location";
            this.Btn_Location.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Location.UseVisualStyleBackColor = false;
            this.Btn_Location.Click += new System.EventHandler(this.Btn_Location_Click);
            // 
            // Btn_Playthroughs
            // 
            this.Btn_Playthroughs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.Btn_Playthroughs.FlatAppearance.BorderSize = 0;
            this.Btn_Playthroughs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Playthroughs.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Playthroughs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.Btn_Playthroughs.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Playthroughs.Image")));
            this.Btn_Playthroughs.Location = new System.Drawing.Point(798, 60);
            this.Btn_Playthroughs.Name = "Btn_Playthroughs";
            this.Btn_Playthroughs.Size = new System.Drawing.Size(129, 25);
            this.Btn_Playthroughs.TabIndex = 11;
            this.Btn_Playthroughs.Text = "Playthroughs";
            this.Btn_Playthroughs.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Playthroughs.UseVisualStyleBackColor = false;
            this.Btn_Playthroughs.Click += new System.EventHandler(this.Btn_Playthroughs_Click);
            // 
            // Btn_Game
            // 
            this.Btn_Game.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.Btn_Game.FlatAppearance.BorderSize = 0;
            this.Btn_Game.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Game.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Game.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.Btn_Game.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Game.Image")));
            this.Btn_Game.Location = new System.Drawing.Point(104, 60);
            this.Btn_Game.Name = "Btn_Game";
            this.Btn_Game.Size = new System.Drawing.Size(74, 25);
            this.Btn_Game.TabIndex = 10;
            this.Btn_Game.Text = "Game";
            this.Btn_Game.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Game.UseVisualStyleBackColor = false;
            this.Btn_Game.Click += new System.EventHandler(this.Btn_Game_Click);
            // 
            // Btn_Score
            // 
            this.Btn_Score.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.Btn_Score.FlatAppearance.BorderSize = 0;
            this.Btn_Score.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Score.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Score.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.Btn_Score.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Score.Image")));
            this.Btn_Score.Location = new System.Drawing.Point(10, 60);
            this.Btn_Score.Name = "Btn_Score";
            this.Btn_Score.Size = new System.Drawing.Size(74, 25);
            this.Btn_Score.TabIndex = 9;
            this.Btn_Score.Text = "Score";
            this.Btn_Score.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Btn_Score.UseVisualStyleBackColor = false;
            this.Btn_Score.Click += new System.EventHandler(this.Btn_Score_Click);
            // 
            // Label_Search
            // 
            this.Label_Search.AutoSize = true;
            this.Label_Search.ForeColor = System.Drawing.Color.White;
            this.Label_Search.Location = new System.Drawing.Point(12, 12);
            this.Label_Search.Name = "Label_Search";
            this.Label_Search.Size = new System.Drawing.Size(53, 16);
            this.Label_Search.TabIndex = 3;
            this.Label_Search.Text = "Search";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(447, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // SearchBar
            // 
            this.SearchBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchBar.Location = new System.Drawing.Point(71, 8);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(370, 23);
            this.SearchBar.TabIndex = 1;
            this.SearchBar.TextChanged += new System.EventHandler(this.SearchBar_TextChanged);
            // 
            // Panel_Database_Header_Splitter
            // 
            this.Panel_Database_Header_Splitter.BackColor = System.Drawing.Color.DimGray;
            this.Panel_Database_Header_Splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Database_Header_Splitter.Location = new System.Drawing.Point(0, 88);
            this.Panel_Database_Header_Splitter.Name = "Panel_Database_Header_Splitter";
            this.Panel_Database_Header_Splitter.Size = new System.Drawing.Size(1200, 5);
            this.Panel_Database_Header_Splitter.TabIndex = 0;
            // 
            // Panel_Database
            // 
            this.Panel_Database.AutoScroll = true;
            this.Panel_Database.Controls.Add(this.Panel_Delete_Confirm);
            this.Panel_Database.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Database.Location = new System.Drawing.Point(0, 93);
            this.Panel_Database.Name = "Panel_Database";
            this.Panel_Database.Size = new System.Drawing.Size(1200, 752);
            this.Panel_Database.TabIndex = 2;
            // 
            // Panel_Delete_Confirm
            // 
            this.Panel_Delete_Confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Panel_Delete_Confirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Delete_Confirm.Controls.Add(this.Btn_Delete_No);
            this.Panel_Delete_Confirm.Controls.Add(this.Btn_Delete_Confirm);
            this.Panel_Delete_Confirm.Controls.Add(this.Label_Delete_Confirm);
            this.Panel_Delete_Confirm.Location = new System.Drawing.Point(886, 6);
            this.Panel_Delete_Confirm.Name = "Panel_Delete_Confirm";
            this.Panel_Delete_Confirm.Size = new System.Drawing.Size(302, 89);
            this.Panel_Delete_Confirm.TabIndex = 0;
            this.Panel_Delete_Confirm.Visible = false;
            // 
            // Label_Delete_Confirm
            // 
            this.Label_Delete_Confirm.AutoSize = true;
            this.Label_Delete_Confirm.Location = new System.Drawing.Point(13, 11);
            this.Label_Delete_Confirm.Name = "Label_Delete_Confirm";
            this.Label_Delete_Confirm.Size = new System.Drawing.Size(265, 16);
            this.Label_Delete_Confirm.TabIndex = 0;
            this.Label_Delete_Confirm.Text = "Do you really want to delete this item?";
            // 
            // Btn_Delete_Confirm
            // 
            this.Btn_Delete_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Delete_Confirm.Location = new System.Drawing.Point(31, 45);
            this.Btn_Delete_Confirm.Name = "Btn_Delete_Confirm";
            this.Btn_Delete_Confirm.Size = new System.Drawing.Size(75, 30);
            this.Btn_Delete_Confirm.TabIndex = 1;
            this.Btn_Delete_Confirm.Text = "Yes";
            this.Btn_Delete_Confirm.UseVisualStyleBackColor = true;
            this.Btn_Delete_Confirm.Click += new System.EventHandler(this.Btn_Delete_Confirm_Click);
            // 
            // Btn_Delete_No
            // 
            this.Btn_Delete_No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Delete_No.Location = new System.Drawing.Point(112, 45);
            this.Btn_Delete_No.Name = "Btn_Delete_No";
            this.Btn_Delete_No.Size = new System.Drawing.Size(75, 30);
            this.Btn_Delete_No.TabIndex = 2;
            this.Btn_Delete_No.Text = "No";
            this.Btn_Delete_No.UseVisualStyleBackColor = true;
            this.Btn_Delete_No.Click += new System.EventHandler(this.Btn_Delete_No_Click);
            // 
            // Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1200, 845);
            this.Controls.Add(this.Panel_Database);
            this.Controls.Add(this.Panel_Database_Header);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Database";
            this.Text = "Database";
            this.Panel_Database_Header.ResumeLayout(false);
            this.Panel_Database_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Reload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Panel_Database.ResumeLayout(false);
            this.Panel_Delete_Confirm.ResumeLayout(false);
            this.Panel_Delete_Confirm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Panel_Database_Header;
        private System.Windows.Forms.Panel Panel_Database_Header_Splitter;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Panel_Database;
        private System.Windows.Forms.Label Label_Search;
        private System.Windows.Forms.Button Btn_Score;
        private System.Windows.Forms.Button Btn_Game;
        private System.Windows.Forms.Button Btn_Playthroughs;
        private System.Windows.Forms.Button Btn_Date;
        private System.Windows.Forms.Button Btn_Location;
        private System.Windows.Forms.Button Btn_Input;
        private System.Windows.Forms.Button Btn_Numbers;
        private System.Windows.Forms.PictureBox Btn_Reload;
        private System.Windows.Forms.CheckBox CheckReplays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Settings;
        private System.Windows.Forms.Panel Panel_Delete_Confirm;
        private System.Windows.Forms.Button Btn_Delete_No;
        private System.Windows.Forms.Button Btn_Delete_Confirm;
        private System.Windows.Forms.Label Label_Delete_Confirm;
    }
}