using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace GoodGameDB
{
    public partial class Main : Form
    {
        public const string ScoreBackground_Green = @"img/score/score_background_green.png";
        public const string ScoreBackground_Yellow = @"img/score/score_background_yellow.png";
        public const string ScoreBackground_Orange = @"img/score/score_background_orange.png";
        public const string ScoreBackground_Red = @"img/score/score_background_red.png";
        public const string ScoreBackground_Gray = @"img/score/score_background_gray.png";
        public const string Medal_Gold = @"img/score/medal_gold.png";
        public const string Medal_Silver = @"img/score/medal_silver.png";
        public const string Medal_Bronze = @"img/score/medal_bronze.png";
        public const string Medal_Gray = @"img/score/medal_gray.png";
        public const string SQLink = @"data.db";

        // Make Panel_Title dragable when click & hold
        // --------------------------------------------------------------------------------------|
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        // --------------------------------------------------------------------------------------|

        // Variables
        // --------------------------------------------------------------------------------------|
        public static bool DarkMode; // Prototype (WIP)
        public static bool AutoLogin; // Prototyoe (WIP)

        private Form activeForm = null;
        // --------------------------------------------------------------------------------------|

        // Main method
        // --------------------------------------------------------------------------------------|
        public Main()
        {
            InitializeComponent();
            AppSettings.Read();
            OpenChildForm(new Database());
            this.Icon = Properties.Resources.GGDB_Icon_w;
            Label_Application_Version.Text = "0.9.2";
        }

        // --------------------------------------------------------------------------------------|

        // Panel_Title MouseMove event
        // --------------------------------------------------------------------------------------|
        private void Panel_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // --------------------------------------------------------------------------------------|

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Panel_Content.Controls.Add(childForm);
            Panel_Content.Tag = childForm;
            Panel_Content.BringToFront();
            childForm.Show();
        }

        private void PicBox_Application_Shutdown_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void PicBox_Application_Minimize_MouseDown(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
