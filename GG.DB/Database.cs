using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GoodGameDB
{
    public partial class Database : Form
    {
        public SQLiteConnection sql_connect;
        public string SortBy = "DATE_ASC";
        public static string CurrentItem;

        public Database()
        {
            InitializeComponent();
            Database_Load();
        }

        public void Database_Load()
        {
            // Connect to SQLite DB and create datatable
            // --------------------------------------------------------------------------------------|
            SQLiteConnection sql_connect;
            sql_connect = new SQLiteConnection("Data source = " + Main.SQLink);
            sql_connect.Open();
            SQLiteCommand sql_cmd;
            sql_cmd = sql_connect.CreateCommand();

            if (SortBy == "SCORE_ASC")
            {
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY score_total ASC";
            }
            if (SortBy == "SCORE_DESC")
            {
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY score_total DESC";
            }
            if (SortBy == "GAME_ASC")
            {
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY game_title DESC";
            }
            if (SortBy == "GAME_DESC")
            {
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY game_title ASC";
            }
            if (SortBy == "PLAYTHROUGH_ASC")
            {
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY finish_counter ASC";
            }
            if (SortBy == "PLAYTHROUGH_DESC")
            {
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY finish_counter DESC";
            }
            if (SortBy == "LOC_ASC")
            {
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY location DESC";
            }
            if (SortBy == "LOC_DESC")
            {
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY location ASC";
            }
            if (SortBy == "DATE_ASC")
            {
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY date ASC";
            }
            if (SortBy == "DATE_DESC")
            {
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY date DESC";
            }

            SQLiteDataAdapter sql_dadapter = new SQLiteDataAdapter(sql_cmd);
            DataTable datatable = new DataTable();
            sql_dadapter.Fill(datatable);
            // --------------------------------------------------------------------------------------|

            foreach (DataRow entry in datatable.Rows)
            {
                // Draw Background Panel
                // --------------------------------------------------------------------------------------|
                Panel Panel_Entry = new Panel();
                Panel_Entry.Name = Convert.ToString(entry["game_title"]);
                Panel_Entry.Dock = DockStyle.Top;
                Panel_Entry.Size = new Size(200, 35);
                Panel_Entry.BackColor = Color.FromArgb(35, 35, 36);
                Panel_Entry.MouseEnter += new EventHandler(Panel_MouseEnter);
                Panel_Entry.MouseLeave += new EventHandler(Panel_MouseLeave);
                Panel_Entry.MouseClick += new MouseEventHandler(Panel_MouseClick);
                Panel_Database.Controls.Add(Panel_Entry);
                // --------------------------------------------------------------------------------------|

                // Draw splitter between panel
                // --------------------------------------------------------------------------------------|
                Panel Panel_Splitter = new Panel();
                Panel_Splitter.Dock = DockStyle.Bottom;
                Panel_Splitter.Size = new Size(200, 1);
                Panel_Splitter.BackColor = Color.DimGray;
                Panel_Entry.Controls.Add(Panel_Splitter);
                // --------------------------------------------------------------------------------------|

                // Place total_score from TotalScore.cs
                // --------------------------------------------------------------------------------------|
                TotalScore.Draw(Convert.ToInt32(entry["score_total"]), 10, 7, Panel_Entry);
                // --------------------------------------------------------------------------------------|

                // Write title of game from db
                // --------------------------------------------------------------------------------------|
                Label Game_Title = new Label();
                Game_Title.Text = Convert.ToString(entry["game_title"]);
                Game_Title.Location = new Point(110, 9);
                Game_Title.AutoSize = true;
                Panel_Entry.Controls.Add(Game_Title);
                // --------------------------------------------------------------------------------------|

                // Write location of game from db
                // --------------------------------------------------------------------------------------|
                Label Game_Location = new Label();
                Game_Location.Text = entry["location"].ToString();
                Game_Location.Location = new Point(940, 9);
                Game_Location.AutoSize = true;
                Panel_Entry.Controls.Add(Game_Location);
                // --------------------------------------------------------------------------------------|

                // Write date of game from db
                // --------------------------------------------------------------------------------------|
                Label Game_Date = new Label();
                Game_Date.Text = Convert.ToDateTime(entry["date"]).ToShortDateString();
                Game_Date.Location = new Point(1075, 9);
                Game_Date.AutoSize = true;
                Panel_Entry.Controls.Add(Game_Date);
                // --------------------------------------------------------------------------------------|

                // Write playthroughs of game from db
                // --------------------------------------------------------------------------------------|
                Label Game_Playthroughs = new Label();
                if (Convert.ToInt32(entry["finish_counter"]) == 1)
                {
                    Game_Playthroughs.Text = "" + entry["finish_counter"] + " time";
                }
                else
                {
                    Game_Playthroughs.Text = "" + entry["finish_counter"] + " times";
                }
                Game_Playthroughs.Location = new Point(800, 9);
                Game_Playthroughs.AutoSize = true;
                Panel_Entry.Controls.Add(Game_Playthroughs);
                // --------------------------------------------------------------------------------------|
            }

            sql_connect.Close();
        }

        public void Database_Search()
        {
            sql_connect = new SQLiteConnection("Data source = " + Main.SQLink);
            sql_connect.Open();

            SQLiteCommand sql_cmd;
            sql_cmd = sql_connect.CreateCommand();
            sql_cmd.CommandText = "SELECT * FROM games WHERE CHARINDEX(UPPER('" + SearchBar.Text + "'), UPPER(game_title)) > 0 ";

            SQLiteDataAdapter sql_dadapter = new SQLiteDataAdapter(sql_cmd);
            DataTable datatable = new DataTable();
            sql_dadapter.Fill(datatable);

            foreach (DataRow entry in datatable.Rows)
            {
                // Draw Background Panel
                // --------------------------------------------------------------------------------------|
                Panel Panel_Entry = new Panel();
                Panel_Entry.Name = Convert.ToString(entry["game_title"]);
                Panel_Entry.Dock = DockStyle.Top;
                Panel_Entry.Size = new Size(200, 35);
                Panel_Entry.BackColor = Color.FromArgb(35, 35, 36);
                Panel_Entry.MouseEnter += new EventHandler(Panel_MouseEnter);
                Panel_Entry.MouseLeave += new EventHandler(Panel_MouseLeave);
                Panel_Entry.MouseClick += new MouseEventHandler(Panel_MouseClick);
                Panel_Database.Controls.Add(Panel_Entry);
                // --------------------------------------------------------------------------------------|

                // Draw splitter between panel
                // --------------------------------------------------------------------------------------|
                Panel Panel_Splitter = new Panel();
                Panel_Splitter.Dock = DockStyle.Bottom;
                Panel_Splitter.Size = new Size(200, 1);
                Panel_Splitter.BackColor = Color.DimGray;
                Panel_Entry.Controls.Add(Panel_Splitter);
                // --------------------------------------------------------------------------------------|

                // Place total_score from TotalScore.cs
                // --------------------------------------------------------------------------------------|
                TotalScore.Draw(Convert.ToInt32(entry["score_total"]), 10, 7, Panel_Entry);
                // --------------------------------------------------------------------------------------|

                // Write title of game from db
                // --------------------------------------------------------------------------------------|
                Label Game_Title = new Label();
                Game_Title.Text = Convert.ToString(entry["game_title"]);
                Game_Title.Location = new Point(110, 9);
                Game_Title.AutoSize = true;
                Panel_Entry.Controls.Add(Game_Title);
                // --------------------------------------------------------------------------------------|

                // Write location of game from db
                // --------------------------------------------------------------------------------------|
                Label Game_Location = new Label();
                Game_Location.Text = entry["location"].ToString();
                Game_Location.Location = new Point(940, 9);
                Game_Location.AutoSize = true;
                Panel_Entry.Controls.Add(Game_Location);
                // --------------------------------------------------------------------------------------|

                // Write date of game from db
                // --------------------------------------------------------------------------------------|
                Label Game_Date = new Label();
                Game_Date.Text = Convert.ToDateTime(entry["date"]).ToShortDateString();
                Game_Date.Location = new Point(1075, 9);
                Game_Date.AutoSize = true;
                Panel_Entry.Controls.Add(Game_Date);
                // --------------------------------------------------------------------------------------|

                // Write playthroughs of game from db
                // --------------------------------------------------------------------------------------|
                Label Game_Playthroughs = new Label();
                if (Convert.ToInt32(entry["finish_counter"]) == 1)
                {
                    Game_Playthroughs.Text = "" + entry["finish_counter"] + " time";
                }
                else
                {
                    Game_Playthroughs.Text = "" + entry["finish_counter"] + " times";
                }
                Game_Playthroughs.Location = new Point(800, 9);
                Game_Playthroughs.AutoSize = true;
                Panel_Entry.Controls.Add(Game_Playthroughs);
                // --------------------------------------------------------------------------------------|
            }

            sql_connect.Close();            
        }

        public void Panel_MouseClick(object sender, EventArgs e)
        {
            int Score_Gameplay = 1;
            int Score_Presentation = 1;
            int Score_Narrative = 1;

            int Score_Quality = 1;
            int Score_Sound = 1;
            int Score_Content = 1;

            int Score_Pacing = 1;
            int Score_Balance = 1;
            int Score_Overall = 1;

            if (sender is Panel panel)
            {
                SQLiteConnection sql_connect;
                sql_connect = new SQLiteConnection("Data source = " + Main.SQLink);
                sql_connect.Open();
                SQLiteCommand sql_cmd;
                sql_cmd = sql_connect.CreateCommand();
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY date ASC";

                SQLiteDataAdapter sql_dadapter = new SQLiteDataAdapter(sql_cmd);
                DataTable datatable = new DataTable();
                sql_dadapter.Fill(datatable);
                // --------------------------------------------------------------------------------------|

                if (panel.Size.Height == 35)
                {
                    panel.Size = new Size(200, 130);
                    RatingSystem Gameplay = new RatingSystem();
                    RatingSystem Presentation = new RatingSystem();
                    RatingSystem Narrative = new RatingSystem();
                    RatingSystem Quality = new RatingSystem();
                    RatingSystem Sound = new RatingSystem();
                    RatingSystem Content = new RatingSystem();
                    RatingSystem Pacing = new RatingSystem();
                    RatingSystem Balance = new RatingSystem();
                    RatingSystem Overall = new RatingSystem();

                    foreach (DataRow entry in datatable.Rows)
                    {
                        if (entry["game_title"].ToString() == panel.Name)
                        {
                            Score_Gameplay = Convert.ToInt32(entry["score_gameplay"]);
                            Score_Presentation = Convert.ToInt32(entry["score_presentation"]);
                            Score_Narrative = Convert.ToInt32(entry["score_narrative"]);
                            Score_Quality = Convert.ToInt32(entry["score_quality"]);
                            Score_Sound = Convert.ToInt32(entry["score_sound"]);
                            Score_Content = Convert.ToInt32(entry["score_content"]);
                            Score_Pacing = Convert.ToInt32(entry["score_pacing"]);
                            Score_Balance = Convert.ToInt32(entry["score_balance"]);
                            Score_Overall = Convert.ToInt32(entry["score_overall"]);
                            CurrentItem = Convert.ToString(entry["game_title"]);
                        }
                    }

                    Gameplay.Draw("Gameplay", Score_Gameplay, 20, 50, panel);
                    Presentation.Draw("Presentation", Score_Presentation, 20, 75, panel);
                    Narrative.Draw("Narrative", Score_Narrative, 20, 100, panel);

                    Quality.Draw("Quality", Score_Quality, 355, 50, panel);
                    Sound.Draw("Sound", Score_Sound, 355, 75, panel);
                    Content.Draw("Content", Score_Content, 355, 100, panel);

                    Pacing.Draw("Pacing", Score_Pacing, 690, 50, panel);
                    Balance.Draw("Balance", Score_Balance, 690, 75, panel);
                    Overall.Draw("Overall", Score_Overall, 690, 100, panel);

                    PictureBox Btn_Edit = new PictureBox();
                    Btn_Edit.Click += new EventHandler(Edit);
                    Btn_Edit.Text = "  Edit";
                    Btn_Edit.Location = new Point(1100, 50);
                    Btn_Edit.Image = Image.FromFile(@"img/icons/edit_white.png");
                    Btn_Edit.BackColor = Color.Transparent;
                    Btn_Edit.Size = new Size(25, 25);
                    Btn_Edit.SizeMode = PictureBoxSizeMode.Zoom;
                    panel.Controls.Add(Btn_Edit);

                    PictureBox Btn_Delete = new PictureBox();
                    Btn_Delete.Click += new EventHandler(Delete);
                    Btn_Delete.Text = "  Edit";
                    Btn_Delete.Location = new Point(1100, 80);
                    Btn_Delete.Image = Image.FromFile(@"img/icons/delete_white.png");
                    Btn_Delete.BackColor = Color.Transparent;
                    Btn_Delete.Size = new Size(25, 25);
                    Btn_Delete.SizeMode = PictureBoxSizeMode.Zoom;
                    panel.Controls.Add(Btn_Delete);

                }
                else if (panel.Size.Height == 130)
                {
                    panel.Size = new Size(200, 35);
                }
            }
        }

        public void Panel_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                panel.BackColor = Color.FromArgb(1, 1, 1);
            }
        }

        public void Panel_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                panel.BackColor = Color.FromArgb(35, 35, 36);
            }
        }

        public void Edit(object sender, EventArgs e)
        {
            Input.EditMode = true;
            Input.EditItem = CurrentItem;
            new Input().Show();
        }
        
        public void Delete(object sender, EventArgs e)
        {
            sql_connect = new SQLiteConnection("Data source = " + Main.SQLink);
            sql_connect.Open();
            string Query = "DELETE FROM games WHERE game_title = '" + CurrentItem + "'";

            SQLiteCommand InsertSQL = new SQLiteCommand(Query, sql_connect);
            InsertSQL.ExecuteNonQuery();
            CleanDB();
        }

        private void Btn_Score_Click(object sender, EventArgs e)
        {
            if (SortBy != "SCORE_ASC")
            {
                SortBy = "SCORE_ASC";
                CleanDB();
            }
            else if (SortBy == "SCORE_ASC")
            {
                SortBy = "SCORE_DESC";
                CleanDB();
            }
        }

        private void Btn_Game_Click(object sender, EventArgs e)
        {
            if (SortBy != "GAME_ASC")
            {
                SortBy = "GAME_ASC";
                CleanDB();
            }
            else if (SortBy == "GAME_ASC")
            {
                SortBy = "GAME_DESC";
                CleanDB();
            }
        }

        private void Btn_Playthroughs_Click(object sender, EventArgs e)
        {
            if (SortBy != "PLAYTHROUGH_ASC")
            {
                SortBy = "PLAYTHROUGH_ASC";
                CleanDB();
            }
            else if (SortBy == "PLAYTHROUGH_ASC")
            {
                SortBy = "PLAYTHROUGH_DESC";
                CleanDB();
            }
        }

        private void Btn_Location_Click(object sender, EventArgs e)
        {
            if (SortBy != "LOC_ASC")
            {
                SortBy = "LOC_ASC";
                CleanDB();
            }
            else if (SortBy == "LOC_ASC")
            {
                SortBy = "LOC_DESC";
                CleanDB();
            }
        }

        private void Btn_Date_Click(object sender, EventArgs e)
        {
            if (SortBy != "DATE_ASC")
            {
                SortBy = "DATE_ASC";
                CleanDB();
            }
            else if (SortBy == "DATE_ASC")
            {
                SortBy = "DATE_DESC";
                CleanDB();
            }
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            Panel_Database.Visible = false;
            Panel_Database.Controls.Clear();
            Database_Search();
            Panel_Database.Visible = true;

            if (SearchBar.Text == "")
            {
                Panel_Database.Visible = false;
                Panel_Database.Controls.Clear();
                Database_Load();
                Panel_Database.Visible = true;
            }
        }

        public void CleanDB()
        {
            Panel_Database.Visible = false;
            Panel_Database.Controls.Clear();
            Database_Load();
            Panel_Database.Visible = true;
        }

        private void Btn_Input_Click(object sender, EventArgs e)
        {
            new Input().Show();
        }

        private void Btn_Reload_Click(object sender, EventArgs e)
        {
            CleanDB();
        }
    }
}
