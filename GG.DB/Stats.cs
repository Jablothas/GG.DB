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
    public partial class Stats : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private bool Replays = false;
        private int Total_Games = 0;
        private int Total_Games_Replays = 0;
        private int Year1_Games = 0;
        private int Year1_Games_Replays = 0;
        private int Year2_Games = 0;
        private int Year2_Games_Replays = 0;
        private int Year3_Games = 0;
        private int Year3_Games_Replays = 0;
        private int Year4_Games = 0;
        private int Year4_Games_Replays = 0;

        private int Total_Gold = 0;
        private int Total_Silver = 0;
        private int Total_Bronze = 0;
        

        public Stats()
        {
            InitializeComponent();
            CreateStats_Total();
        }

        public void CreateStats_Total()
        {
            int Year1 = DateTime.Now.Year;
            int Year2 = Year1 - 1;
            int Year3 = Year1 - 2;
            int Year4 = Year1 - 3;
            int temp_loc_y = 70;
            SQLiteConnection sql_connect;
            sql_connect = new SQLiteConnection("Data source = " + Main.SQLink);
            sql_connect.Open();
            SQLiteCommand sql_cmd;
            sql_cmd = sql_connect.CreateCommand();

            sql_cmd.CommandText = "SELECT * FROM games ORDER BY score_total DESC LIMIT 5";

            SQLiteDataAdapter sql_dadapter = new SQLiteDataAdapter(sql_cmd);
            DataTable datatable = new DataTable();
            sql_dadapter.Fill(datatable);

            foreach (DataRow entry in datatable.Rows)
            {
                TotalScore.Draw(Convert.ToInt32(entry["score_total"]), 10, temp_loc_y, Panel_Total);
                Label Title = new Label();
                Title.Text = entry["game_title"].ToString();
                Title.Location = new Point(100, (temp_loc_y + 1));
                Title.Size = new Size(300, 23);
                Title.ForeColor = Color.White;
                Panel_Total.Controls.Add(Title);
                temp_loc_y += 33;
            }

            sql_cmd.CommandText = "SELECT * FROM games ORDER BY score_total";

            DataTable datatable2 = new DataTable();
            sql_dadapter.Fill(datatable2);

            foreach (DataRow entry in datatable2.Rows)
            {
                if (entry["replay"].ToString().Contains("n"))
                {
                    Total_Games++;
                    if (Convert.ToInt32(entry["score_total"]) >= 95)
                    {
                        Total_Gold++;
                    }
                    if (Convert.ToInt32(entry["score_total"]) >= 90 && Convert.ToInt32(entry["score_total"]) <= 94)
                    {
                        Total_Silver++;
                    }
                    if (Convert.ToInt32(entry["score_total"]) >= 85 && Convert.ToInt32(entry["score_total"]) <= 89)
                    {
                        Total_Bronze++;
                    }
                    if (entry["date"].ToString().Contains("" + Year1))
                    {
                        Year1_Games++;
                    }
                    if (entry["date"].ToString().Contains("" + Year2))
                    {
                        Year2_Games++;
                    }
                    if (entry["date"].ToString().Contains("" + Year3))
                    {
                        Year3_Games++;
                    }
                    if (entry["date"].ToString().Contains("" + Year4))
                    {
                        Year4_Games++;
                    }


                }
                if (entry["replay"].ToString().Contains("y"))
                {
                    Total_Games_Replays++;
                    if (entry["date"].ToString().Contains("" + Year1))
                    {
                        Year1_Games_Replays++;
                    }
                    if (entry["date"].ToString().Contains("" + Year2))
                    {
                        Year2_Games_Replays++;
                    }
                    if (entry["date"].ToString().Contains("" + Year3))
                    {
                        Year3_Games_Replays++;
                    }
                    if (entry["date"].ToString().Contains("" + Year4))
                    {
                        Year4_Games_Replays++;
                    }
                }
            }

            sql_connect.Close();
            int temp = Total_Games + Total_Games_Replays;
            Label_Fin_Total.Text = temp + " total games completed.";
            Label_Fin_Total2.Text = " (" + Total_Games + " unique, " + Total_Games_Replays + " replays)";
            Label_Medals_Gold.Text = "" + Total_Gold;
            Label_Medals_Silver.Text = "" + Total_Silver;
            Label_Medals_Bronze.Text = "" + Total_Bronze;
            Label_Year1.Text = "" + Year1;
            Label_Year2.Text = "" + Year2;
            Label_Year3.Text = "" + Year3;
            Label_Year4.Text = "" + "" + Year4;
            Label_Fin_Year1.Text = Year1_Games + " games";
            Label_Fin_Year1B.Text = " (" + Year1_Games + " unique, " + Year1_Games_Replays + " replays)";
            Label_Fin_Year2.Text = Year2_Games + " games";
            Label_Fin_Year2B.Text = " (" + Year2_Games + " unique, " + Year2_Games_Replays + " replays)";
            Label_Fin_Year3.Text = Year3_Games + " games";
            Label_Fin_Year3B.Text = " (" + Year3_Games + " unique, " + Year3_Games_Replays + " replays)";
            Label_Fin_Year4.Text = Year4_Games + " games";
            Label_Fin_Year4B.Text = " (" + Year4_Games + " unique, " + Year4_Games_Replays + " replays)";

        }

        private void Stats_Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PicBox_Stats_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckReplays_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckReplays.Checked == false)
            {
                Replays = false;
                CreateStats_Total();
            }
            if (CheckReplays.Checked == true)
            {
                Replays = true;
                CreateStats_Total();
            }
        }
    }
}
