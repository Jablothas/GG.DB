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
using System.Data.SQLite;

namespace GoodGameDB
{
    public partial class AddPlaythrough : Form
    {
        public static int Copy_ID = 0;
        public static string Copy_GameTitle = "";
        public static int Copy_PlaythroughCount = 0;
        public static string Copy_Location = "";
        public SQLiteConnection sql_connect;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public AddPlaythrough()
        {
            InitializeComponent();

            string temp = DateTime.Now.ToShortDateString();
            string[] temp_split = temp.Split('.');

            // Fill current date in textboxes
            DateBox_Year.Text = temp_split[2];
            DateBox_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            DateBox_Month.Text = temp_split[1];
            DateBox_Month.DropDownStyle = ComboBoxStyle.DropDownList;
            DateBox_Day.Text = temp_split[0];
            DateBox_Day.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Copy_PlaythroughCount += 1;
            string Date_Complete = DateBox_Year.Text + "-" + DateBox_Month.Text + "-" + DateBox_Day.Text;

            sql_connect = new SQLiteConnection("Data source = " + Main.SQLink);
            sql_connect.Open();
            string Query = "INSERT INTO games(game_title, comment, date, location, replay, finish_counter, " +
                            " score_gameplay, score_presentation, score_overall, score_quality, score_sound, score_content, score_narrative, score_pacing, score_balance, score_total) " +
                            "VALUES ('" + Copy_GameTitle + "', '" + TextBox_Note.Text + "', '" + Date_Complete + "', '" + Copy_Location + "','y', '" + Copy_PlaythroughCount + "', " +
                            "'0', '0', '0', '0', '0', '0', '0', '0', '0', '0')";
            SQLiteCommand InsertSQL = new SQLiteCommand(Query, sql_connect);
            InsertSQL.ExecuteNonQuery();

            string Query2 = "UPDATE games SET finish_counter = " + Copy_PlaythroughCount + " WHERE id = " + Copy_ID;
            SQLiteCommand InsertSQL2 = new SQLiteCommand(Query2, sql_connect);
            InsertSQL2.ExecuteNonQuery();
            sql_connect.Close();

            Btn_Save.Visible = false;
            Lbl_Confirm.Visible = true;
        }

        private void Input_Header_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PicBox_Input_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
