namespace GoodGameDB
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Panel_Title = new System.Windows.Forms.Panel();
            this.Label_Application_Version = new System.Windows.Forms.Label();
            this.PicBox_Application_Minimize = new System.Windows.Forms.PictureBox();
            this.PicBox_Application_Shutdown = new System.Windows.Forms.PictureBox();
            this.Label_Application_Title = new System.Windows.Forms.Label();
            this.PicBox_Logo = new System.Windows.Forms.PictureBox();
            this.Panel_Title_Spacer = new System.Windows.Forms.Panel();
            this.Panel_Bottom = new System.Windows.Forms.Panel();
            this.Panel_Content = new System.Windows.Forms.Panel();
            this.Panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Application_Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Application_Shutdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Title
            // 
            this.Panel_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Panel_Title.Controls.Add(this.Label_Application_Version);
            this.Panel_Title.Controls.Add(this.PicBox_Application_Minimize);
            this.Panel_Title.Controls.Add(this.PicBox_Application_Shutdown);
            this.Panel_Title.Controls.Add(this.Label_Application_Title);
            this.Panel_Title.Controls.Add(this.PicBox_Logo);
            this.Panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Title.Location = new System.Drawing.Point(0, 0);
            this.Panel_Title.Name = "Panel_Title";
            this.Panel_Title.Size = new System.Drawing.Size(1200, 42);
            this.Panel_Title.TabIndex = 0;
            this.Panel_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_Title_MouseMove);
            // 
            // Label_Application_Version
            // 
            this.Label_Application_Version.AutoSize = true;
            this.Label_Application_Version.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Application_Version.ForeColor = System.Drawing.Color.Gray;
            this.Label_Application_Version.Location = new System.Drawing.Point(120, 14);
            this.Label_Application_Version.Name = "Label_Application_Version";
            this.Label_Application_Version.Size = new System.Drawing.Size(38, 16);
            this.Label_Application_Version.TabIndex = 4;
            this.Label_Application_Version.Text = "x.x.x";
            // 
            // PicBox_Application_Minimize
            // 
            this.PicBox_Application_Minimize.Image = ((System.Drawing.Image)(resources.GetObject("PicBox_Application_Minimize.Image")));
            this.PicBox_Application_Minimize.Location = new System.Drawing.Point(1140, 9);
            this.PicBox_Application_Minimize.Name = "PicBox_Application_Minimize";
            this.PicBox_Application_Minimize.Size = new System.Drawing.Size(24, 24);
            this.PicBox_Application_Minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBox_Application_Minimize.TabIndex = 3;
            this.PicBox_Application_Minimize.TabStop = false;
            this.PicBox_Application_Minimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBox_Application_Minimize_MouseDown);
            // 
            // PicBox_Application_Shutdown
            // 
            this.PicBox_Application_Shutdown.Image = ((System.Drawing.Image)(resources.GetObject("PicBox_Application_Shutdown.Image")));
            this.PicBox_Application_Shutdown.Location = new System.Drawing.Point(1170, 9);
            this.PicBox_Application_Shutdown.Name = "PicBox_Application_Shutdown";
            this.PicBox_Application_Shutdown.Size = new System.Drawing.Size(24, 24);
            this.PicBox_Application_Shutdown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBox_Application_Shutdown.TabIndex = 2;
            this.PicBox_Application_Shutdown.TabStop = false;
            this.PicBox_Application_Shutdown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBox_Application_Shutdown_MouseDown);
            // 
            // Label_Application_Title
            // 
            this.Label_Application_Title.AutoSize = true;
            this.Label_Application_Title.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Application_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.Label_Application_Title.Location = new System.Drawing.Point(43, 10);
            this.Label_Application_Title.Name = "Label_Application_Title";
            this.Label_Application_Title.Size = new System.Drawing.Size(75, 23);
            this.Label_Application_Title.TabIndex = 1;
            this.Label_Application_Title.Text = "GG.DB";
            // 
            // PicBox_Logo
            // 
            this.PicBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("PicBox_Logo.Image")));
            this.PicBox_Logo.Location = new System.Drawing.Point(6, 6);
            this.PicBox_Logo.Name = "PicBox_Logo";
            this.PicBox_Logo.Size = new System.Drawing.Size(32, 32);
            this.PicBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBox_Logo.TabIndex = 0;
            this.PicBox_Logo.TabStop = false;
            // 
            // Panel_Title_Spacer
            // 
            this.Panel_Title_Spacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.Panel_Title_Spacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Title_Spacer.Location = new System.Drawing.Point(0, 42);
            this.Panel_Title_Spacer.Name = "Panel_Title_Spacer";
            this.Panel_Title_Spacer.Size = new System.Drawing.Size(1200, 3);
            this.Panel_Title_Spacer.TabIndex = 1;
            // 
            // Panel_Bottom
            // 
            this.Panel_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Bottom.Location = new System.Drawing.Point(0, 970);
            this.Panel_Bottom.Name = "Panel_Bottom";
            this.Panel_Bottom.Size = new System.Drawing.Size(1200, 10);
            this.Panel_Bottom.TabIndex = 2;
            // 
            // Panel_Content
            // 
            this.Panel_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.Panel_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Content.Location = new System.Drawing.Point(0, 45);
            this.Panel_Content.Name = "Panel_Content";
            this.Panel_Content.Size = new System.Drawing.Size(1200, 925);
            this.Panel_Content.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1200, 980);
            this.Controls.Add(this.Panel_Content);
            this.Controls.Add(this.Panel_Bottom);
            this.Controls.Add(this.Panel_Title_Spacer);
            this.Controls.Add(this.Panel_Title);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GG.DB";
            this.Panel_Title.ResumeLayout(false);
            this.Panel_Title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Application_Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Application_Shutdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Title;
        private System.Windows.Forms.Panel Panel_Title_Spacer;
        private System.Windows.Forms.PictureBox PicBox_Logo;
        private System.Windows.Forms.Label Label_Application_Title;
        private System.Windows.Forms.Panel Panel_Bottom;
        private System.Windows.Forms.Panel Panel_Content;
        private System.Windows.Forms.PictureBox PicBox_Application_Minimize;
        private System.Windows.Forms.PictureBox PicBox_Application_Shutdown;
        private System.Windows.Forms.Label Label_Application_Version;
    }
}

