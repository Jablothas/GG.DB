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
    public partial class Input : Form
    {
        public static bool EditMode;
        public static int EditID;

        public SQLiteConnection sql_connect;
        public int PlaythroughCount;
        // White score image (y)es
        private const string y = @"img/score/score_background_white.png";
        // Gray score image (n)o
        private const string n = @"img/score/score_background_gray.png";

        // Make Panel Input dragable when click & hold
        // --------------------------------------------------------------------------------------|
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        // --------------------------------------------------------------------------------------|

        public Input()
        {
            InitializeComponent();

            // Generate current time and split by day/month/year for textboxes
            // --------------------------------------------------------------------------------------|
            string temp = DateTime.Now.ToShortDateString();
            string[] temp_split = temp.Split('.');

            // Fill current date in textboxes
            DateBox_Year.Text = temp_split[2];
            DateBox_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            DateBox_Month.Text = temp_split[1];
            DateBox_Month.DropDownStyle = ComboBoxStyle.DropDownList;
            DateBox_Day.Text = temp_split[0];
            DateBox_Day.DropDownStyle = ComboBoxStyle.DropDownList;
            // --------------------------------------------------------------------------------------|

            // This part triggers if the form will be open via edit button in database.cs
            // --------------------------------------------------------------------------------------|
            if (EditMode == true)
            {
                //Label_Title.Text = "Edit Mode";
                Btn_Reset.Visible = false;
                Label_EditMode.Visible = true;
                Btn_Save.Text = "  Save Changes";
                Btn_Save.Size = new Size(150, 36);
                Btn_Save.Image = Image.FromFile(@"img/icons/edit_item_white2.png");
                Btn_Save.BackColor = Color.DarkOrange;
                SQLiteConnection sql_connect;
                sql_connect = new SQLiteConnection("Data source = " + Main.SQLink);
                sql_connect.Open();
                SQLiteCommand sql_cmd;
                
                sql_cmd = sql_connect.CreateCommand();
                sql_cmd.CommandText = "SELECT * FROM games ORDER BY id ASC";

                SQLiteDataAdapter sql_dadapter = new SQLiteDataAdapter(sql_cmd);
                DataTable datatable = new DataTable();
                sql_dadapter.Fill(datatable);

                foreach (DataRow entry in datatable.Rows)
                {
                    if (Convert.ToInt32(entry["id"]) == EditID)
                    {
                        string[] DateTimeSplit = Convert.ToString(entry["date"]).Split('.', ' ');

                        TextBox_Game.Text = Convert.ToString(entry["game_title"]);
                        TextBox_Loc.Text = Convert.ToString(entry["location"]);
                        DateBox_Year.Text = DateTimeSplit[2];
                        DateBox_Month.Text = DateTimeSplit[1];
                        DateBox_Day.Text = DateTimeSplit[0];

                        Numeric_Gameplay.Value = Convert.ToDecimal(entry["score_gameplay"]);
                        Numeric_Presentation.Value = Convert.ToDecimal(entry["score_presentation"]);
                        Numeric_Narrative.Value = Convert.ToDecimal(entry["score_narrative"]);
                        Numeric_Quality.Value = Convert.ToDecimal(entry["score_quality"]);
                        Numeric_Sound.Value = Convert.ToDecimal(entry["score_sound"]);
                        Numeric_Content.Value = Convert.ToDecimal(entry["score_content"]);
                        Numeric_Pacing.Value = Convert.ToDecimal(entry["score_pacing"]);
                        Numeric_Balance.Value = Convert.ToDecimal(entry["score_balance"]);
                        Numeric_Overall.Value = Convert.ToDecimal(entry["score_overall"]);
                        PlaythroughCount = Convert.ToInt32(entry["finish_counter"]);
                        EditID = Convert.ToInt32(entry["id"]);
                    }
                }
                // --------------------------------------------------------------------------------------|
            }
        }
        private void Btn_Save_Click(object sender, EventArgs e)
        {

            if (EditMode == false)
            {
                if (TextBox_Game.Text == "")
                {
                    MessageBox.Show("Please enter a game title!");
                }
                else if (TextBox_Loc.Text == "")
                {
                    MessageBox.Show("Please enter a location where you finished the game!");
                }
                else if (DateBox_Day.Text == "")
                {
                    MessageBox.Show("Please enter a valid date!");
                }
                else if (DateBox_Month.Text == "")
                {
                    MessageBox.Show("Please enter a valid date!");
                }
                else if (DateBox_Year.Text == "")
                {
                    MessageBox.Show("Please enter a valid date!");
                }

                else
                {
                    if (Check_Gameplay.Checked == false)
                    {
                        Numeric_Gameplay.Value = 10;
                    }
                    if (Check_Presentation.Checked == false)
                    {
                        Numeric_Presentation.Value = 10;
                    }
                    if (Check_Narrative.Checked == false)
                    {
                        Numeric_Narrative.Value = 10;
                    }
                    if (Check_Quality.Checked == false)
                    {
                        Numeric_Quality.Value = 10;
                    }
                    if (Check_Sound.Checked == false)
                    {
                        Numeric_Sound.Value = 10;
                    }
                    if (Check_Content.Checked == false)
                    {
                        Numeric_Content.Value = 10;
                    }
                    if (Check_Pacing.Checked == false)
                    {
                        Numeric_Pacing.Value = 10;
                    }
                    if (Check_Balance.Checked == false)
                    {
                        Numeric_Balance.Value = 10;
                    }
                    if (Check_Overall.Checked == false)
                    {
                        Numeric_Overall.Value = 10;
                    }

                    string Date_Complete = DateBox_Year.Text + "-" + DateBox_Month.Text + "-" + DateBox_Day.Text;
                    decimal Numeric_Total = Numeric_Gameplay.Value + Numeric_Presentation.Value +
                    Numeric_Narrative.Value + Numeric_Quality.Value + Numeric_Sound.Value +
                    Numeric_Content.Value + Numeric_Pacing.Value + Numeric_Balance.Value +
                    Numeric_Overall.Value + 10;



                    SQLiteConnection sql_connect;
                    sql_connect = new SQLiteConnection("Data source = " + Main.SQLink);
                    sql_connect.Open();
                    string Query = "INSERT INTO games(game_title, comment, date, location, replay, finish_counter, " +
                                    " score_gameplay, score_presentation, score_overall, score_quality, score_sound, score_content, score_narrative, score_pacing, score_balance, score_total) " +
                                    "VALUES ('" + TextBox_Game.Text + "', '" + TextBox_Note.Text + "', '" + Date_Complete + "', '" + TextBox_Loc.Text + "','n', '1', '" +
                                            Numeric_Gameplay.Value + "', '" + Numeric_Presentation.Value + "', '" + Numeric_Overall.Value + "', '" + Numeric_Quality.Value + "', '" + Numeric_Sound.Value + "', '" +
                                            Numeric_Content.Value + "', '" + Numeric_Narrative.Value + "', '" + Numeric_Pacing.Value + "', '" + Numeric_Balance.Value + "', '" +
                                            Numeric_Total + "')";

                    SQLiteCommand InsertSQL = new SQLiteCommand(Query, sql_connect);
                    InsertSQL.ExecuteNonQuery();

                    sql_connect.Close();

                    TotalScore.Draw(Convert.ToInt32(Numeric_Total), 20, 730, Panel_Input_Form);
                    Label SaveConfirm = new Label();
                    SaveConfirm.Location = new Point(100, 732);
                    SaveConfirm.AutoSize = true;
                    SaveConfirm.ForeColor = Color.White;
                    SaveConfirm.Text = TextBox_Game.Text + " saved to database.";
                    Panel_Input_Form.Controls.Add(SaveConfirm);
                }
            }

            if (EditMode == true)
            {
                string Date_Complete = DateBox_Year.Text + "-" + DateBox_Month.Text + "-" + DateBox_Day.Text;
                decimal Numeric_Total = Numeric_Gameplay.Value + Numeric_Presentation.Value +
                Numeric_Narrative.Value + Numeric_Quality.Value + Numeric_Sound.Value +
                Numeric_Content.Value + Numeric_Pacing.Value + Numeric_Balance.Value +
                Numeric_Overall.Value + 10;

                sql_connect = new SQLiteConnection("Data source = " + Main.SQLink);
                sql_connect.Open();
                string Query = "UPDATE games " +
                               "SET " +
                               "game_title = '" + TextBox_Game.Text + "', " +
                               "location = '" + TextBox_Loc.Text + "', " +
                               "date = '" + Date_Complete + "', " +
                               "comment = '" + TextBox_Note.Text + "', " +
                               "score_gameplay = '" + Numeric_Gameplay.Value + "', " +
                               "score_presentation = '" + Numeric_Presentation.Value + "', " +
                               "score_narrative = '" + Numeric_Narrative.Value + "', " +
                               "score_quality = '" + Numeric_Quality.Value + "', " +
                               "score_sound = '" + Numeric_Sound.Value + "', " +
                               "score_content = '" + Numeric_Content.Value + "', " +
                               "score_pacing = '" + Numeric_Pacing.Value + "', " +
                               "score_balance = '" + Numeric_Balance.Value + "', " +
                               "score_overall = '" + Numeric_Overall.Value + "', " +
                               "score_total = '" + Numeric_Total + "', " +
                               "finish_counter = '" + PlaythroughCount + "' " +
                               "WHERE id = '" + EditID + "'";

                SQLiteCommand InsertSQL = new SQLiteCommand(Query, sql_connect);
                InsertSQL.ExecuteNonQuery();

                sql_connect.Close();

                TotalScore.Draw(Convert.ToInt32(Numeric_Total), 20, 730, Panel_Input_Form);
                Label SaveConfirm = new Label();
                SaveConfirm.Location = new Point(100, 732);
                SaveConfirm.AutoSize = true;
                SaveConfirm.ForeColor = Color.White;
                SaveConfirm.Text = TextBox_Game.Text + " succesfully edited!";
                Panel_Input_Form.Controls.Add(SaveConfirm);
            }
        }

        private void PicBox_Input_Close_Click(object sender, EventArgs e)
        {
            EditMode = false;
            this.Close();
        }

        private void Input_Header_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Numeric_Gameplay_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Numeric_Gameplay.Value))
            {
                case 0:
                    PicBox_Gameplay_Score1.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score2.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score3.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score4.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score5.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score6.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score7.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score8.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score9.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score10.Image = Image.FromFile(n);
                    break;
                case 1:
                    PicBox_Gameplay_Score1.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score2.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score3.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score4.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score5.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score6.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score7.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score8.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score9.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score10.Image = Image.FromFile(n);
                    break;
                case 2:
                    PicBox_Gameplay_Score1.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score2.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score3.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score4.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score5.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score6.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score7.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score8.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score9.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score10.Image = Image.FromFile(n);
                    break;
                case 3:
                    PicBox_Gameplay_Score1.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score2.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score3.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score4.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score5.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score6.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score7.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score8.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score9.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score10.Image = Image.FromFile(n);
                    break;
                case 4:
                    PicBox_Gameplay_Score1.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score2.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score3.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score4.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score5.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score6.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score7.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score8.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score9.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score10.Image = Image.FromFile(n);
                    break;
                case 5:
                    PicBox_Gameplay_Score1.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score2.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score3.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score4.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score5.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score6.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score7.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score8.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score9.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score10.Image = Image.FromFile(n);
                    break;
                case 6:
                    PicBox_Gameplay_Score1.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score2.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score3.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score4.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score5.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score6.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score7.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score8.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score9.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score10.Image = Image.FromFile(n);
                    break;
                case 7:
                    PicBox_Gameplay_Score1.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score2.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score3.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score4.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score5.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score6.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score7.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score8.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score9.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score10.Image = Image.FromFile(n);
                    break;
                case 8:
                    PicBox_Gameplay_Score1.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score2.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score3.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score4.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score5.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score6.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score7.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score8.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score9.Image = Image.FromFile(n);
                    PicBox_Gameplay_Score10.Image = Image.FromFile(n);
                    break;
                case 9:
                    PicBox_Gameplay_Score1.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score2.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score3.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score4.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score5.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score6.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score7.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score8.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score9.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score10.Image = Image.FromFile(n);
                    break;
                case 10:
                    PicBox_Gameplay_Score1.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score2.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score3.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score4.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score5.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score6.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score7.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score8.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score9.Image = Image.FromFile(y);
                    PicBox_Gameplay_Score10.Image = Image.FromFile(y);
                    break;
            }
        }

        private void Numeric_Presentation_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Numeric_Presentation.Value))
            {
                case 0:
                    PicBox_Design_Score1.Image = Image.FromFile(n);
                    PicBox_Design_Score2.Image = Image.FromFile(n);
                    PicBox_Design_Score3.Image = Image.FromFile(n);
                    PicBox_Design_Score4.Image = Image.FromFile(n);
                    PicBox_Design_Score5.Image = Image.FromFile(n);
                    PicBox_Design_Score6.Image = Image.FromFile(n);
                    PicBox_Design_Score7.Image = Image.FromFile(n);
                    PicBox_Design_Score8.Image = Image.FromFile(n);
                    PicBox_Design_Score9.Image = Image.FromFile(n);
                    PicBox_Design_Score10.Image = Image.FromFile(n);
                    break;
                case 1:
                    PicBox_Design_Score1.Image = Image.FromFile(y);
                    PicBox_Design_Score2.Image = Image.FromFile(n);
                    PicBox_Design_Score3.Image = Image.FromFile(n);
                    PicBox_Design_Score4.Image = Image.FromFile(n);
                    PicBox_Design_Score5.Image = Image.FromFile(n);
                    PicBox_Design_Score6.Image = Image.FromFile(n);
                    PicBox_Design_Score7.Image = Image.FromFile(n);
                    PicBox_Design_Score8.Image = Image.FromFile(n);
                    PicBox_Design_Score9.Image = Image.FromFile(n);
                    PicBox_Design_Score10.Image = Image.FromFile(n);
                    break;
                case 2:
                    PicBox_Design_Score1.Image = Image.FromFile(y);
                    PicBox_Design_Score2.Image = Image.FromFile(y);
                    PicBox_Design_Score3.Image = Image.FromFile(n);
                    PicBox_Design_Score4.Image = Image.FromFile(n);
                    PicBox_Design_Score5.Image = Image.FromFile(n);
                    PicBox_Design_Score6.Image = Image.FromFile(n);
                    PicBox_Design_Score7.Image = Image.FromFile(n);
                    PicBox_Design_Score8.Image = Image.FromFile(n);
                    PicBox_Design_Score9.Image = Image.FromFile(n);
                    PicBox_Design_Score10.Image = Image.FromFile(n);
                    break;
                case 3:
                    PicBox_Design_Score1.Image = Image.FromFile(y);
                    PicBox_Design_Score2.Image = Image.FromFile(y);
                    PicBox_Design_Score3.Image = Image.FromFile(y);
                    PicBox_Design_Score4.Image = Image.FromFile(n);
                    PicBox_Design_Score5.Image = Image.FromFile(n);
                    PicBox_Design_Score6.Image = Image.FromFile(n);
                    PicBox_Design_Score7.Image = Image.FromFile(n);
                    PicBox_Design_Score8.Image = Image.FromFile(n);
                    PicBox_Design_Score9.Image = Image.FromFile(n);
                    PicBox_Design_Score10.Image = Image.FromFile(n);
                    break;
                case 4:
                    PicBox_Design_Score1.Image = Image.FromFile(y);
                    PicBox_Design_Score2.Image = Image.FromFile(y);
                    PicBox_Design_Score3.Image = Image.FromFile(y);
                    PicBox_Design_Score4.Image = Image.FromFile(y);
                    PicBox_Design_Score5.Image = Image.FromFile(n);
                    PicBox_Design_Score6.Image = Image.FromFile(n);
                    PicBox_Design_Score7.Image = Image.FromFile(n);
                    PicBox_Design_Score8.Image = Image.FromFile(n);
                    PicBox_Design_Score9.Image = Image.FromFile(n);
                    PicBox_Design_Score10.Image = Image.FromFile(n);
                    break;
                case 5:
                    PicBox_Design_Score1.Image = Image.FromFile(y);
                    PicBox_Design_Score2.Image = Image.FromFile(y);
                    PicBox_Design_Score3.Image = Image.FromFile(y);
                    PicBox_Design_Score4.Image = Image.FromFile(y);
                    PicBox_Design_Score5.Image = Image.FromFile(y);
                    PicBox_Design_Score6.Image = Image.FromFile(n);
                    PicBox_Design_Score7.Image = Image.FromFile(n);
                    PicBox_Design_Score8.Image = Image.FromFile(n);
                    PicBox_Design_Score9.Image = Image.FromFile(n);
                    PicBox_Design_Score10.Image = Image.FromFile(n);
                    break;
                case 6:
                    PicBox_Design_Score1.Image = Image.FromFile(y);
                    PicBox_Design_Score2.Image = Image.FromFile(y);
                    PicBox_Design_Score3.Image = Image.FromFile(y);
                    PicBox_Design_Score4.Image = Image.FromFile(y);
                    PicBox_Design_Score5.Image = Image.FromFile(y);
                    PicBox_Design_Score6.Image = Image.FromFile(y);
                    PicBox_Design_Score7.Image = Image.FromFile(n);
                    PicBox_Design_Score8.Image = Image.FromFile(n);
                    PicBox_Design_Score9.Image = Image.FromFile(n);
                    PicBox_Design_Score10.Image = Image.FromFile(n);
                    break;
                case 7:
                    PicBox_Design_Score1.Image = Image.FromFile(y);
                    PicBox_Design_Score2.Image = Image.FromFile(y);
                    PicBox_Design_Score3.Image = Image.FromFile(y);
                    PicBox_Design_Score4.Image = Image.FromFile(y);
                    PicBox_Design_Score5.Image = Image.FromFile(y);
                    PicBox_Design_Score6.Image = Image.FromFile(y);
                    PicBox_Design_Score7.Image = Image.FromFile(y);
                    PicBox_Design_Score8.Image = Image.FromFile(n);
                    PicBox_Design_Score9.Image = Image.FromFile(n);
                    PicBox_Design_Score10.Image = Image.FromFile(n);
                    break;
                case 8:
                    PicBox_Design_Score1.Image = Image.FromFile(y);
                    PicBox_Design_Score2.Image = Image.FromFile(y);
                    PicBox_Design_Score3.Image = Image.FromFile(y);
                    PicBox_Design_Score4.Image = Image.FromFile(y);
                    PicBox_Design_Score5.Image = Image.FromFile(y);
                    PicBox_Design_Score6.Image = Image.FromFile(y);
                    PicBox_Design_Score7.Image = Image.FromFile(y);
                    PicBox_Design_Score8.Image = Image.FromFile(y);
                    PicBox_Design_Score9.Image = Image.FromFile(n);
                    PicBox_Design_Score10.Image = Image.FromFile(n);
                    break;
                case 9:
                    PicBox_Design_Score1.Image = Image.FromFile(y);
                    PicBox_Design_Score2.Image = Image.FromFile(y);
                    PicBox_Design_Score3.Image = Image.FromFile(y);
                    PicBox_Design_Score4.Image = Image.FromFile(y);
                    PicBox_Design_Score5.Image = Image.FromFile(y);
                    PicBox_Design_Score6.Image = Image.FromFile(y);
                    PicBox_Design_Score7.Image = Image.FromFile(y);
                    PicBox_Design_Score8.Image = Image.FromFile(y);
                    PicBox_Design_Score9.Image = Image.FromFile(y);
                    PicBox_Design_Score10.Image = Image.FromFile(n);
                    break;
                case 10:
                    PicBox_Design_Score1.Image = Image.FromFile(y);
                    PicBox_Design_Score2.Image = Image.FromFile(y);
                    PicBox_Design_Score3.Image = Image.FromFile(y);
                    PicBox_Design_Score4.Image = Image.FromFile(y);
                    PicBox_Design_Score5.Image = Image.FromFile(y);
                    PicBox_Design_Score6.Image = Image.FromFile(y);
                    PicBox_Design_Score7.Image = Image.FromFile(y);
                    PicBox_Design_Score8.Image = Image.FromFile(y);
                    PicBox_Design_Score9.Image = Image.FromFile(y);
                    PicBox_Design_Score10.Image = Image.FromFile(y);
                    break;
            }
        }

        private void Numeric_Narrative_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Numeric_Narrative.Value))
            {
                case 0:
                    PicBox_Narrative_Score1.Image = Image.FromFile(n);
                    PicBox_Narrative_Score2.Image = Image.FromFile(n);
                    PicBox_Narrative_Score3.Image = Image.FromFile(n);
                    PicBox_Narrative_Score4.Image = Image.FromFile(n);
                    PicBox_Narrative_Score5.Image = Image.FromFile(n);
                    PicBox_Narrative_Score6.Image = Image.FromFile(n);
                    PicBox_Narrative_Score7.Image = Image.FromFile(n);
                    PicBox_Narrative_Score8.Image = Image.FromFile(n);
                    PicBox_Narrative_Score9.Image = Image.FromFile(n);
                    PicBox_Narrative_Score10.Image = Image.FromFile(n);
                    break;
                case 1:
                    PicBox_Narrative_Score1.Image = Image.FromFile(y);
                    PicBox_Narrative_Score2.Image = Image.FromFile(n);
                    PicBox_Narrative_Score3.Image = Image.FromFile(n);
                    PicBox_Narrative_Score4.Image = Image.FromFile(n);
                    PicBox_Narrative_Score5.Image = Image.FromFile(n);
                    PicBox_Narrative_Score6.Image = Image.FromFile(n);
                    PicBox_Narrative_Score7.Image = Image.FromFile(n);
                    PicBox_Narrative_Score8.Image = Image.FromFile(n);
                    PicBox_Narrative_Score9.Image = Image.FromFile(n);
                    PicBox_Narrative_Score10.Image = Image.FromFile(n);
                    break;
                case 2:
                    PicBox_Narrative_Score1.Image = Image.FromFile(y);
                    PicBox_Narrative_Score2.Image = Image.FromFile(y);
                    PicBox_Narrative_Score3.Image = Image.FromFile(n);
                    PicBox_Narrative_Score4.Image = Image.FromFile(n);
                    PicBox_Narrative_Score5.Image = Image.FromFile(n);
                    PicBox_Narrative_Score6.Image = Image.FromFile(n);
                    PicBox_Narrative_Score7.Image = Image.FromFile(n);
                    PicBox_Narrative_Score8.Image = Image.FromFile(n);
                    PicBox_Narrative_Score9.Image = Image.FromFile(n);
                    PicBox_Narrative_Score10.Image = Image.FromFile(n);
                    break;
                case 3:
                    PicBox_Narrative_Score1.Image = Image.FromFile(y);
                    PicBox_Narrative_Score2.Image = Image.FromFile(y);
                    PicBox_Narrative_Score3.Image = Image.FromFile(y);
                    PicBox_Narrative_Score4.Image = Image.FromFile(n);
                    PicBox_Narrative_Score5.Image = Image.FromFile(n);
                    PicBox_Narrative_Score6.Image = Image.FromFile(n);
                    PicBox_Narrative_Score7.Image = Image.FromFile(n);
                    PicBox_Narrative_Score8.Image = Image.FromFile(n);
                    PicBox_Narrative_Score9.Image = Image.FromFile(n);
                    PicBox_Narrative_Score10.Image = Image.FromFile(n);
                    break;
                case 4:
                    PicBox_Narrative_Score1.Image = Image.FromFile(y);
                    PicBox_Narrative_Score2.Image = Image.FromFile(y);
                    PicBox_Narrative_Score3.Image = Image.FromFile(y);
                    PicBox_Narrative_Score4.Image = Image.FromFile(y);
                    PicBox_Narrative_Score5.Image = Image.FromFile(n);
                    PicBox_Narrative_Score6.Image = Image.FromFile(n);
                    PicBox_Narrative_Score7.Image = Image.FromFile(n);
                    PicBox_Narrative_Score8.Image = Image.FromFile(n);
                    PicBox_Narrative_Score9.Image = Image.FromFile(n);
                    PicBox_Narrative_Score10.Image = Image.FromFile(n);
                    break;
                case 5:
                    PicBox_Narrative_Score1.Image = Image.FromFile(y);
                    PicBox_Narrative_Score2.Image = Image.FromFile(y);
                    PicBox_Narrative_Score3.Image = Image.FromFile(y);
                    PicBox_Narrative_Score4.Image = Image.FromFile(y);
                    PicBox_Narrative_Score5.Image = Image.FromFile(y);
                    PicBox_Narrative_Score6.Image = Image.FromFile(n);
                    PicBox_Narrative_Score7.Image = Image.FromFile(n);
                    PicBox_Narrative_Score8.Image = Image.FromFile(n);
                    PicBox_Narrative_Score9.Image = Image.FromFile(n);
                    PicBox_Narrative_Score10.Image = Image.FromFile(n);
                    break;
                case 6:
                    PicBox_Narrative_Score1.Image = Image.FromFile(y);
                    PicBox_Narrative_Score2.Image = Image.FromFile(y);
                    PicBox_Narrative_Score3.Image = Image.FromFile(y);
                    PicBox_Narrative_Score4.Image = Image.FromFile(y);
                    PicBox_Narrative_Score5.Image = Image.FromFile(y);
                    PicBox_Narrative_Score6.Image = Image.FromFile(y);
                    PicBox_Narrative_Score7.Image = Image.FromFile(n);
                    PicBox_Narrative_Score8.Image = Image.FromFile(n);
                    PicBox_Narrative_Score9.Image = Image.FromFile(n);
                    PicBox_Narrative_Score10.Image = Image.FromFile(n);
                    break;
                case 7:
                    PicBox_Narrative_Score1.Image = Image.FromFile(y);
                    PicBox_Narrative_Score2.Image = Image.FromFile(y);
                    PicBox_Narrative_Score3.Image = Image.FromFile(y);
                    PicBox_Narrative_Score4.Image = Image.FromFile(y);
                    PicBox_Narrative_Score5.Image = Image.FromFile(y);
                    PicBox_Narrative_Score6.Image = Image.FromFile(y);
                    PicBox_Narrative_Score7.Image = Image.FromFile(y);
                    PicBox_Narrative_Score8.Image = Image.FromFile(n);
                    PicBox_Narrative_Score9.Image = Image.FromFile(n);
                    PicBox_Narrative_Score10.Image = Image.FromFile(n);
                    break;
                case 8:
                    PicBox_Narrative_Score1.Image = Image.FromFile(y);
                    PicBox_Narrative_Score2.Image = Image.FromFile(y);
                    PicBox_Narrative_Score3.Image = Image.FromFile(y);
                    PicBox_Narrative_Score4.Image = Image.FromFile(y);
                    PicBox_Narrative_Score5.Image = Image.FromFile(y);
                    PicBox_Narrative_Score6.Image = Image.FromFile(y);
                    PicBox_Narrative_Score7.Image = Image.FromFile(y);
                    PicBox_Narrative_Score8.Image = Image.FromFile(y);
                    PicBox_Narrative_Score9.Image = Image.FromFile(n);
                    PicBox_Narrative_Score10.Image = Image.FromFile(n);
                    break;
                case 9:
                    PicBox_Narrative_Score1.Image = Image.FromFile(y);
                    PicBox_Narrative_Score2.Image = Image.FromFile(y);
                    PicBox_Narrative_Score3.Image = Image.FromFile(y);
                    PicBox_Narrative_Score4.Image = Image.FromFile(y);
                    PicBox_Narrative_Score5.Image = Image.FromFile(y);
                    PicBox_Narrative_Score6.Image = Image.FromFile(y);
                    PicBox_Narrative_Score7.Image = Image.FromFile(y);
                    PicBox_Narrative_Score8.Image = Image.FromFile(y);
                    PicBox_Narrative_Score9.Image = Image.FromFile(y);
                    PicBox_Narrative_Score10.Image = Image.FromFile(n);
                    break;
                case 10:
                    PicBox_Narrative_Score1.Image = Image.FromFile(y);
                    PicBox_Narrative_Score2.Image = Image.FromFile(y);
                    PicBox_Narrative_Score3.Image = Image.FromFile(y);
                    PicBox_Narrative_Score4.Image = Image.FromFile(y);
                    PicBox_Narrative_Score5.Image = Image.FromFile(y);
                    PicBox_Narrative_Score6.Image = Image.FromFile(y);
                    PicBox_Narrative_Score7.Image = Image.FromFile(y);
                    PicBox_Narrative_Score8.Image = Image.FromFile(y);
                    PicBox_Narrative_Score9.Image = Image.FromFile(y);
                    PicBox_Narrative_Score10.Image = Image.FromFile(y);
                    break;
            }
        }

        private void Numeric_Quality_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Numeric_Quality.Value))
            {
                case 0:
                    PicBox_Tech_Score1.Image = Image.FromFile(n);
                    PicBox_Tech_Score2.Image = Image.FromFile(n);
                    PicBox_Tech_Score3.Image = Image.FromFile(n);
                    PicBox_Tech_Score4.Image = Image.FromFile(n);
                    PicBox_Tech_Score5.Image = Image.FromFile(n);
                    PicBox_Tech_Score6.Image = Image.FromFile(n);
                    PicBox_Tech_Score7.Image = Image.FromFile(n);
                    PicBox_Tech_Score8.Image = Image.FromFile(n);
                    PicBox_Tech_Score9.Image = Image.FromFile(n);
                    PicBox_Tech_Score10.Image = Image.FromFile(n);
                    break;
                case 1:
                    PicBox_Tech_Score1.Image = Image.FromFile(y);
                    PicBox_Tech_Score2.Image = Image.FromFile(n);
                    PicBox_Tech_Score3.Image = Image.FromFile(n);
                    PicBox_Tech_Score4.Image = Image.FromFile(n);
                    PicBox_Tech_Score5.Image = Image.FromFile(n);
                    PicBox_Tech_Score6.Image = Image.FromFile(n);
                    PicBox_Tech_Score7.Image = Image.FromFile(n);
                    PicBox_Tech_Score8.Image = Image.FromFile(n);
                    PicBox_Tech_Score9.Image = Image.FromFile(n);
                    PicBox_Tech_Score10.Image = Image.FromFile(n);
                    break;
                case 2:
                    PicBox_Tech_Score1.Image = Image.FromFile(y);
                    PicBox_Tech_Score2.Image = Image.FromFile(y);
                    PicBox_Tech_Score3.Image = Image.FromFile(n);
                    PicBox_Tech_Score4.Image = Image.FromFile(n);
                    PicBox_Tech_Score5.Image = Image.FromFile(n);
                    PicBox_Tech_Score6.Image = Image.FromFile(n);
                    PicBox_Tech_Score7.Image = Image.FromFile(n);
                    PicBox_Tech_Score8.Image = Image.FromFile(n);
                    PicBox_Tech_Score9.Image = Image.FromFile(n);
                    PicBox_Tech_Score10.Image = Image.FromFile(n);
                    break;
                case 3:
                    PicBox_Tech_Score1.Image = Image.FromFile(y);
                    PicBox_Tech_Score2.Image = Image.FromFile(y);
                    PicBox_Tech_Score3.Image = Image.FromFile(y);
                    PicBox_Tech_Score4.Image = Image.FromFile(n);
                    PicBox_Tech_Score5.Image = Image.FromFile(n);
                    PicBox_Tech_Score6.Image = Image.FromFile(n);
                    PicBox_Tech_Score7.Image = Image.FromFile(n);
                    PicBox_Tech_Score8.Image = Image.FromFile(n);
                    PicBox_Tech_Score9.Image = Image.FromFile(n);
                    PicBox_Tech_Score10.Image = Image.FromFile(n);
                    break;
                case 4:
                    PicBox_Tech_Score1.Image = Image.FromFile(y);
                    PicBox_Tech_Score2.Image = Image.FromFile(y);
                    PicBox_Tech_Score3.Image = Image.FromFile(y);
                    PicBox_Tech_Score4.Image = Image.FromFile(y);
                    PicBox_Tech_Score5.Image = Image.FromFile(n);
                    PicBox_Tech_Score6.Image = Image.FromFile(n);
                    PicBox_Tech_Score7.Image = Image.FromFile(n);
                    PicBox_Tech_Score8.Image = Image.FromFile(n);
                    PicBox_Tech_Score9.Image = Image.FromFile(n);
                    PicBox_Tech_Score10.Image = Image.FromFile(n);
                    break;
                case 5:
                    PicBox_Tech_Score1.Image = Image.FromFile(y);
                    PicBox_Tech_Score2.Image = Image.FromFile(y);
                    PicBox_Tech_Score3.Image = Image.FromFile(y);
                    PicBox_Tech_Score4.Image = Image.FromFile(y);
                    PicBox_Tech_Score5.Image = Image.FromFile(y);
                    PicBox_Tech_Score6.Image = Image.FromFile(n);
                    PicBox_Tech_Score7.Image = Image.FromFile(n);
                    PicBox_Tech_Score8.Image = Image.FromFile(n);
                    PicBox_Tech_Score9.Image = Image.FromFile(n);
                    PicBox_Tech_Score10.Image = Image.FromFile(n);
                    break;
                case 6:
                    PicBox_Tech_Score1.Image = Image.FromFile(y);
                    PicBox_Tech_Score2.Image = Image.FromFile(y);
                    PicBox_Tech_Score3.Image = Image.FromFile(y);
                    PicBox_Tech_Score4.Image = Image.FromFile(y);
                    PicBox_Tech_Score5.Image = Image.FromFile(y);
                    PicBox_Tech_Score6.Image = Image.FromFile(y);
                    PicBox_Tech_Score7.Image = Image.FromFile(n);
                    PicBox_Tech_Score8.Image = Image.FromFile(n);
                    PicBox_Tech_Score9.Image = Image.FromFile(n);
                    PicBox_Tech_Score10.Image = Image.FromFile(n);
                    break;
                case 7:
                    PicBox_Tech_Score1.Image = Image.FromFile(y);
                    PicBox_Tech_Score2.Image = Image.FromFile(y);
                    PicBox_Tech_Score3.Image = Image.FromFile(y);
                    PicBox_Tech_Score4.Image = Image.FromFile(y);
                    PicBox_Tech_Score5.Image = Image.FromFile(y);
                    PicBox_Tech_Score6.Image = Image.FromFile(y);
                    PicBox_Tech_Score7.Image = Image.FromFile(y);
                    PicBox_Tech_Score8.Image = Image.FromFile(n);
                    PicBox_Tech_Score9.Image = Image.FromFile(n);
                    PicBox_Tech_Score10.Image = Image.FromFile(n);
                    break;
                case 8:
                    PicBox_Tech_Score1.Image = Image.FromFile(y);
                    PicBox_Tech_Score2.Image = Image.FromFile(y);
                    PicBox_Tech_Score3.Image = Image.FromFile(y);
                    PicBox_Tech_Score4.Image = Image.FromFile(y);
                    PicBox_Tech_Score5.Image = Image.FromFile(y);
                    PicBox_Tech_Score6.Image = Image.FromFile(y);
                    PicBox_Tech_Score7.Image = Image.FromFile(y);
                    PicBox_Tech_Score8.Image = Image.FromFile(y);
                    PicBox_Tech_Score9.Image = Image.FromFile(n);
                    PicBox_Tech_Score10.Image = Image.FromFile(n);
                    break;
                case 9:
                    PicBox_Tech_Score1.Image = Image.FromFile(y);
                    PicBox_Tech_Score2.Image = Image.FromFile(y);
                    PicBox_Tech_Score3.Image = Image.FromFile(y);
                    PicBox_Tech_Score4.Image = Image.FromFile(y);
                    PicBox_Tech_Score5.Image = Image.FromFile(y);
                    PicBox_Tech_Score6.Image = Image.FromFile(y);
                    PicBox_Tech_Score7.Image = Image.FromFile(y);
                    PicBox_Tech_Score8.Image = Image.FromFile(y);
                    PicBox_Tech_Score9.Image = Image.FromFile(y);
                    PicBox_Tech_Score10.Image = Image.FromFile(n);
                    break;
                case 10:
                    PicBox_Tech_Score1.Image = Image.FromFile(y);
                    PicBox_Tech_Score2.Image = Image.FromFile(y);
                    PicBox_Tech_Score3.Image = Image.FromFile(y);
                    PicBox_Tech_Score4.Image = Image.FromFile(y);
                    PicBox_Tech_Score5.Image = Image.FromFile(y);
                    PicBox_Tech_Score6.Image = Image.FromFile(y);
                    PicBox_Tech_Score7.Image = Image.FromFile(y);
                    PicBox_Tech_Score8.Image = Image.FromFile(y);
                    PicBox_Tech_Score9.Image = Image.FromFile(y);
                    PicBox_Tech_Score10.Image = Image.FromFile(y);
                    break;
            }
        }

        private void Numeric_Sound_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Numeric_Sound.Value))
            {
                case 0:
                    PicBox_Sound_Score1.Image = Image.FromFile(n);
                    PicBox_Sound_Score2.Image = Image.FromFile(n);
                    PicBox_Sound_Score3.Image = Image.FromFile(n);
                    PicBox_Sound_Score4.Image = Image.FromFile(n);
                    PicBox_Sound_Score5.Image = Image.FromFile(n);
                    PicBox_Sound_Score6.Image = Image.FromFile(n);
                    PicBox_Sound_Score7.Image = Image.FromFile(n);
                    PicBox_Sound_Score8.Image = Image.FromFile(n);
                    PicBox_Sound_Score9.Image = Image.FromFile(n);
                    PicBox_Sound_Score10.Image = Image.FromFile(n);
                    break;
                case 1:
                    PicBox_Sound_Score1.Image = Image.FromFile(y);
                    PicBox_Sound_Score2.Image = Image.FromFile(n);
                    PicBox_Sound_Score3.Image = Image.FromFile(n);
                    PicBox_Sound_Score4.Image = Image.FromFile(n);
                    PicBox_Sound_Score5.Image = Image.FromFile(n);
                    PicBox_Sound_Score6.Image = Image.FromFile(n);
                    PicBox_Sound_Score7.Image = Image.FromFile(n);
                    PicBox_Sound_Score8.Image = Image.FromFile(n);
                    PicBox_Sound_Score9.Image = Image.FromFile(n);
                    PicBox_Sound_Score10.Image = Image.FromFile(n);
                    break;
                case 2:
                    PicBox_Sound_Score1.Image = Image.FromFile(y);
                    PicBox_Sound_Score2.Image = Image.FromFile(y);
                    PicBox_Sound_Score3.Image = Image.FromFile(n);
                    PicBox_Sound_Score4.Image = Image.FromFile(n);
                    PicBox_Sound_Score5.Image = Image.FromFile(n);
                    PicBox_Sound_Score6.Image = Image.FromFile(n);
                    PicBox_Sound_Score7.Image = Image.FromFile(n);
                    PicBox_Sound_Score8.Image = Image.FromFile(n);
                    PicBox_Sound_Score9.Image = Image.FromFile(n);
                    PicBox_Sound_Score10.Image = Image.FromFile(n);
                    break;
                case 3:
                    PicBox_Sound_Score1.Image = Image.FromFile(y);
                    PicBox_Sound_Score2.Image = Image.FromFile(y);
                    PicBox_Sound_Score3.Image = Image.FromFile(y);
                    PicBox_Sound_Score4.Image = Image.FromFile(n);
                    PicBox_Sound_Score5.Image = Image.FromFile(n);
                    PicBox_Sound_Score6.Image = Image.FromFile(n);
                    PicBox_Sound_Score7.Image = Image.FromFile(n);
                    PicBox_Sound_Score8.Image = Image.FromFile(n);
                    PicBox_Sound_Score9.Image = Image.FromFile(n);
                    PicBox_Sound_Score10.Image = Image.FromFile(n);
                    break;
                case 4:
                    PicBox_Sound_Score1.Image = Image.FromFile(y);
                    PicBox_Sound_Score2.Image = Image.FromFile(y);
                    PicBox_Sound_Score3.Image = Image.FromFile(y);
                    PicBox_Sound_Score4.Image = Image.FromFile(y);
                    PicBox_Sound_Score5.Image = Image.FromFile(n);
                    PicBox_Sound_Score6.Image = Image.FromFile(n);
                    PicBox_Sound_Score7.Image = Image.FromFile(n);
                    PicBox_Sound_Score8.Image = Image.FromFile(n);
                    PicBox_Sound_Score9.Image = Image.FromFile(n);
                    PicBox_Sound_Score10.Image = Image.FromFile(n);
                    break;
                case 5:
                    PicBox_Sound_Score1.Image = Image.FromFile(y);
                    PicBox_Sound_Score2.Image = Image.FromFile(y);
                    PicBox_Sound_Score3.Image = Image.FromFile(y);
                    PicBox_Sound_Score4.Image = Image.FromFile(y);
                    PicBox_Sound_Score5.Image = Image.FromFile(y);
                    PicBox_Sound_Score6.Image = Image.FromFile(n);
                    PicBox_Sound_Score7.Image = Image.FromFile(n);
                    PicBox_Sound_Score8.Image = Image.FromFile(n);
                    PicBox_Sound_Score9.Image = Image.FromFile(n);
                    PicBox_Sound_Score10.Image = Image.FromFile(n);
                    break;
                case 6:
                    PicBox_Sound_Score1.Image = Image.FromFile(y);
                    PicBox_Sound_Score2.Image = Image.FromFile(y);
                    PicBox_Sound_Score3.Image = Image.FromFile(y);
                    PicBox_Sound_Score4.Image = Image.FromFile(y);
                    PicBox_Sound_Score5.Image = Image.FromFile(y);
                    PicBox_Sound_Score6.Image = Image.FromFile(y);
                    PicBox_Sound_Score7.Image = Image.FromFile(n);
                    PicBox_Sound_Score8.Image = Image.FromFile(n);
                    PicBox_Sound_Score9.Image = Image.FromFile(n);
                    PicBox_Sound_Score10.Image = Image.FromFile(n);
                    break;
                case 7:
                    PicBox_Sound_Score1.Image = Image.FromFile(y);
                    PicBox_Sound_Score2.Image = Image.FromFile(y);
                    PicBox_Sound_Score3.Image = Image.FromFile(y);
                    PicBox_Sound_Score4.Image = Image.FromFile(y);
                    PicBox_Sound_Score5.Image = Image.FromFile(y);
                    PicBox_Sound_Score6.Image = Image.FromFile(y);
                    PicBox_Sound_Score7.Image = Image.FromFile(y);
                    PicBox_Sound_Score8.Image = Image.FromFile(n);
                    PicBox_Sound_Score9.Image = Image.FromFile(n);
                    PicBox_Sound_Score10.Image = Image.FromFile(n);
                    break;
                case 8:
                    PicBox_Sound_Score1.Image = Image.FromFile(y);
                    PicBox_Sound_Score2.Image = Image.FromFile(y);
                    PicBox_Sound_Score3.Image = Image.FromFile(y);
                    PicBox_Sound_Score4.Image = Image.FromFile(y);
                    PicBox_Sound_Score5.Image = Image.FromFile(y);
                    PicBox_Sound_Score6.Image = Image.FromFile(y);
                    PicBox_Sound_Score7.Image = Image.FromFile(y);
                    PicBox_Sound_Score8.Image = Image.FromFile(y);
                    PicBox_Sound_Score9.Image = Image.FromFile(n);
                    PicBox_Sound_Score10.Image = Image.FromFile(n);
                    break;
                case 9:
                    PicBox_Sound_Score1.Image = Image.FromFile(y);
                    PicBox_Sound_Score2.Image = Image.FromFile(y);
                    PicBox_Sound_Score3.Image = Image.FromFile(y);
                    PicBox_Sound_Score4.Image = Image.FromFile(y);
                    PicBox_Sound_Score5.Image = Image.FromFile(y);
                    PicBox_Sound_Score6.Image = Image.FromFile(y);
                    PicBox_Sound_Score7.Image = Image.FromFile(y);
                    PicBox_Sound_Score8.Image = Image.FromFile(y);
                    PicBox_Sound_Score9.Image = Image.FromFile(y);
                    PicBox_Sound_Score10.Image = Image.FromFile(n);
                    break;
                case 10:
                    PicBox_Sound_Score1.Image = Image.FromFile(y);
                    PicBox_Sound_Score2.Image = Image.FromFile(y);
                    PicBox_Sound_Score3.Image = Image.FromFile(y);
                    PicBox_Sound_Score4.Image = Image.FromFile(y);
                    PicBox_Sound_Score5.Image = Image.FromFile(y);
                    PicBox_Sound_Score6.Image = Image.FromFile(y);
                    PicBox_Sound_Score7.Image = Image.FromFile(y);
                    PicBox_Sound_Score8.Image = Image.FromFile(y);
                    PicBox_Sound_Score9.Image = Image.FromFile(y);
                    PicBox_Sound_Score10.Image = Image.FromFile(y);
                    break;
            }
        }

        private void Numeric_Content_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Numeric_Content.Value))
            {
                case 0:
                    PicBox_Content_Score1.Image = Image.FromFile(n);
                    PicBox_Content_Score2.Image = Image.FromFile(n);
                    PicBox_Content_Score3.Image = Image.FromFile(n);
                    PicBox_Content_Score4.Image = Image.FromFile(n);
                    PicBox_Content_Score5.Image = Image.FromFile(n);
                    PicBox_Content_Score6.Image = Image.FromFile(n);
                    PicBox_Content_Score7.Image = Image.FromFile(n);
                    PicBox_Content_Score8.Image = Image.FromFile(n);
                    PicBox_Content_Score9.Image = Image.FromFile(n);
                    PicBox_Content_Score10.Image = Image.FromFile(n);
                    break;
                case 1:
                    PicBox_Content_Score1.Image = Image.FromFile(y);
                    PicBox_Content_Score2.Image = Image.FromFile(n);
                    PicBox_Content_Score3.Image = Image.FromFile(n);
                    PicBox_Content_Score4.Image = Image.FromFile(n);
                    PicBox_Content_Score5.Image = Image.FromFile(n);
                    PicBox_Content_Score6.Image = Image.FromFile(n);
                    PicBox_Content_Score7.Image = Image.FromFile(n);
                    PicBox_Content_Score8.Image = Image.FromFile(n);
                    PicBox_Content_Score9.Image = Image.FromFile(n);
                    PicBox_Content_Score10.Image = Image.FromFile(n);
                    break;
                case 2:
                    PicBox_Content_Score1.Image = Image.FromFile(y);
                    PicBox_Content_Score2.Image = Image.FromFile(y);
                    PicBox_Content_Score3.Image = Image.FromFile(n);
                    PicBox_Content_Score4.Image = Image.FromFile(n);
                    PicBox_Content_Score5.Image = Image.FromFile(n);
                    PicBox_Content_Score6.Image = Image.FromFile(n);
                    PicBox_Content_Score7.Image = Image.FromFile(n);
                    PicBox_Content_Score8.Image = Image.FromFile(n);
                    PicBox_Content_Score9.Image = Image.FromFile(n);
                    PicBox_Content_Score10.Image = Image.FromFile(n);
                    break;
                case 3:
                    PicBox_Content_Score1.Image = Image.FromFile(y);
                    PicBox_Content_Score2.Image = Image.FromFile(y);
                    PicBox_Content_Score3.Image = Image.FromFile(y);
                    PicBox_Content_Score4.Image = Image.FromFile(n);
                    PicBox_Content_Score5.Image = Image.FromFile(n);
                    PicBox_Content_Score6.Image = Image.FromFile(n);
                    PicBox_Content_Score7.Image = Image.FromFile(n);
                    PicBox_Content_Score8.Image = Image.FromFile(n);
                    PicBox_Content_Score9.Image = Image.FromFile(n);
                    PicBox_Content_Score10.Image = Image.FromFile(n);
                    break;
                case 4:
                    PicBox_Content_Score1.Image = Image.FromFile(y);
                    PicBox_Content_Score2.Image = Image.FromFile(y);
                    PicBox_Content_Score3.Image = Image.FromFile(y);
                    PicBox_Content_Score4.Image = Image.FromFile(y);
                    PicBox_Content_Score5.Image = Image.FromFile(n);
                    PicBox_Content_Score6.Image = Image.FromFile(n);
                    PicBox_Content_Score7.Image = Image.FromFile(n);
                    PicBox_Content_Score8.Image = Image.FromFile(n);
                    PicBox_Content_Score9.Image = Image.FromFile(n);
                    PicBox_Content_Score10.Image = Image.FromFile(n);
                    break;
                case 5:
                    PicBox_Content_Score1.Image = Image.FromFile(y);
                    PicBox_Content_Score2.Image = Image.FromFile(y);
                    PicBox_Content_Score3.Image = Image.FromFile(y);
                    PicBox_Content_Score4.Image = Image.FromFile(y);
                    PicBox_Content_Score5.Image = Image.FromFile(y);
                    PicBox_Content_Score6.Image = Image.FromFile(n);
                    PicBox_Content_Score7.Image = Image.FromFile(n);
                    PicBox_Content_Score8.Image = Image.FromFile(n);
                    PicBox_Content_Score9.Image = Image.FromFile(n);
                    PicBox_Content_Score10.Image = Image.FromFile(n);
                    break;
                case 6:
                    PicBox_Content_Score1.Image = Image.FromFile(y);
                    PicBox_Content_Score2.Image = Image.FromFile(y);
                    PicBox_Content_Score3.Image = Image.FromFile(y);
                    PicBox_Content_Score4.Image = Image.FromFile(y);
                    PicBox_Content_Score5.Image = Image.FromFile(y);
                    PicBox_Content_Score6.Image = Image.FromFile(y);
                    PicBox_Content_Score7.Image = Image.FromFile(n);
                    PicBox_Content_Score8.Image = Image.FromFile(n);
                    PicBox_Content_Score9.Image = Image.FromFile(n);
                    PicBox_Content_Score10.Image = Image.FromFile(n);
                    break;
                case 7:
                    PicBox_Content_Score1.Image = Image.FromFile(y);
                    PicBox_Content_Score2.Image = Image.FromFile(y);
                    PicBox_Content_Score3.Image = Image.FromFile(y);
                    PicBox_Content_Score4.Image = Image.FromFile(y);
                    PicBox_Content_Score5.Image = Image.FromFile(y);
                    PicBox_Content_Score6.Image = Image.FromFile(y);
                    PicBox_Content_Score7.Image = Image.FromFile(y);
                    PicBox_Content_Score8.Image = Image.FromFile(n);
                    PicBox_Content_Score9.Image = Image.FromFile(n);
                    PicBox_Content_Score10.Image = Image.FromFile(n);
                    break;
                case 8:
                    PicBox_Content_Score1.Image = Image.FromFile(y);
                    PicBox_Content_Score2.Image = Image.FromFile(y);
                    PicBox_Content_Score3.Image = Image.FromFile(y);
                    PicBox_Content_Score4.Image = Image.FromFile(y);
                    PicBox_Content_Score5.Image = Image.FromFile(y);
                    PicBox_Content_Score6.Image = Image.FromFile(y);
                    PicBox_Content_Score7.Image = Image.FromFile(y);
                    PicBox_Content_Score8.Image = Image.FromFile(y);
                    PicBox_Content_Score9.Image = Image.FromFile(n);
                    PicBox_Content_Score10.Image = Image.FromFile(n);
                    break;
                case 9:
                    PicBox_Content_Score1.Image = Image.FromFile(y);
                    PicBox_Content_Score2.Image = Image.FromFile(y);
                    PicBox_Content_Score3.Image = Image.FromFile(y);
                    PicBox_Content_Score4.Image = Image.FromFile(y);
                    PicBox_Content_Score5.Image = Image.FromFile(y);
                    PicBox_Content_Score6.Image = Image.FromFile(y);
                    PicBox_Content_Score7.Image = Image.FromFile(y);
                    PicBox_Content_Score8.Image = Image.FromFile(y);
                    PicBox_Content_Score9.Image = Image.FromFile(y);
                    PicBox_Content_Score10.Image = Image.FromFile(n);
                    break;
                case 10:
                    PicBox_Content_Score1.Image = Image.FromFile(y);
                    PicBox_Content_Score2.Image = Image.FromFile(y);
                    PicBox_Content_Score3.Image = Image.FromFile(y);
                    PicBox_Content_Score4.Image = Image.FromFile(y);
                    PicBox_Content_Score5.Image = Image.FromFile(y);
                    PicBox_Content_Score6.Image = Image.FromFile(y);
                    PicBox_Content_Score7.Image = Image.FromFile(y);
                    PicBox_Content_Score8.Image = Image.FromFile(y);
                    PicBox_Content_Score9.Image = Image.FromFile(y);
                    PicBox_Content_Score10.Image = Image.FromFile(y);
                    break;
            }
        }

        private void Numeric_Pacing_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Numeric_Pacing.Value))
            {
                case 0:
                    PicBox_Pacing_Score1.Image = Image.FromFile(n);
                    PicBox_Pacing_Score2.Image = Image.FromFile(n);
                    PicBox_Pacing_Score3.Image = Image.FromFile(n);
                    PicBox_Pacing_Score4.Image = Image.FromFile(n);
                    PicBox_Pacing_Score5.Image = Image.FromFile(n);
                    PicBox_Pacing_Score6.Image = Image.FromFile(n);
                    PicBox_Pacing_Score7.Image = Image.FromFile(n);
                    PicBox_Pacing_Score8.Image = Image.FromFile(n);
                    PicBox_Pacing_Score9.Image = Image.FromFile(n);
                    PicBox_Pacing_Score10.Image = Image.FromFile(n);
                    break;
                case 1:
                    PicBox_Pacing_Score1.Image = Image.FromFile(y);
                    PicBox_Pacing_Score2.Image = Image.FromFile(n);
                    PicBox_Pacing_Score3.Image = Image.FromFile(n);
                    PicBox_Pacing_Score4.Image = Image.FromFile(n);
                    PicBox_Pacing_Score5.Image = Image.FromFile(n);
                    PicBox_Pacing_Score6.Image = Image.FromFile(n);
                    PicBox_Pacing_Score7.Image = Image.FromFile(n);
                    PicBox_Pacing_Score8.Image = Image.FromFile(n);
                    PicBox_Pacing_Score9.Image = Image.FromFile(n);
                    PicBox_Pacing_Score10.Image = Image.FromFile(n);
                    break;
                case 2:
                    PicBox_Pacing_Score1.Image = Image.FromFile(y);
                    PicBox_Pacing_Score2.Image = Image.FromFile(y);
                    PicBox_Pacing_Score3.Image = Image.FromFile(n);
                    PicBox_Pacing_Score4.Image = Image.FromFile(n);
                    PicBox_Pacing_Score5.Image = Image.FromFile(n);
                    PicBox_Pacing_Score6.Image = Image.FromFile(n);
                    PicBox_Pacing_Score7.Image = Image.FromFile(n);
                    PicBox_Pacing_Score8.Image = Image.FromFile(n);
                    PicBox_Pacing_Score9.Image = Image.FromFile(n);
                    PicBox_Pacing_Score10.Image = Image.FromFile(n);
                    break;
                case 3:
                    PicBox_Pacing_Score1.Image = Image.FromFile(y);
                    PicBox_Pacing_Score2.Image = Image.FromFile(y);
                    PicBox_Pacing_Score3.Image = Image.FromFile(y);
                    PicBox_Pacing_Score4.Image = Image.FromFile(n);
                    PicBox_Pacing_Score5.Image = Image.FromFile(n);
                    PicBox_Pacing_Score6.Image = Image.FromFile(n);
                    PicBox_Pacing_Score7.Image = Image.FromFile(n);
                    PicBox_Pacing_Score8.Image = Image.FromFile(n);
                    PicBox_Pacing_Score9.Image = Image.FromFile(n);
                    PicBox_Pacing_Score10.Image = Image.FromFile(n);
                    break;
                case 4:
                    PicBox_Pacing_Score1.Image = Image.FromFile(y);
                    PicBox_Pacing_Score2.Image = Image.FromFile(y);
                    PicBox_Pacing_Score3.Image = Image.FromFile(y);
                    PicBox_Pacing_Score4.Image = Image.FromFile(y);
                    PicBox_Pacing_Score5.Image = Image.FromFile(n);
                    PicBox_Pacing_Score6.Image = Image.FromFile(n);
                    PicBox_Pacing_Score7.Image = Image.FromFile(n);
                    PicBox_Pacing_Score8.Image = Image.FromFile(n);
                    PicBox_Pacing_Score9.Image = Image.FromFile(n);
                    PicBox_Pacing_Score10.Image = Image.FromFile(n);
                    break;
                case 5:
                    PicBox_Pacing_Score1.Image = Image.FromFile(y);
                    PicBox_Pacing_Score2.Image = Image.FromFile(y);
                    PicBox_Pacing_Score3.Image = Image.FromFile(y);
                    PicBox_Pacing_Score4.Image = Image.FromFile(y);
                    PicBox_Pacing_Score5.Image = Image.FromFile(y);
                    PicBox_Pacing_Score6.Image = Image.FromFile(n);
                    PicBox_Pacing_Score7.Image = Image.FromFile(n);
                    PicBox_Pacing_Score8.Image = Image.FromFile(n);
                    PicBox_Pacing_Score9.Image = Image.FromFile(n);
                    PicBox_Pacing_Score10.Image = Image.FromFile(n);
                    break;
                case 6:
                    PicBox_Pacing_Score1.Image = Image.FromFile(y);
                    PicBox_Pacing_Score2.Image = Image.FromFile(y);
                    PicBox_Pacing_Score3.Image = Image.FromFile(y);
                    PicBox_Pacing_Score4.Image = Image.FromFile(y);
                    PicBox_Pacing_Score5.Image = Image.FromFile(y);
                    PicBox_Pacing_Score6.Image = Image.FromFile(y);
                    PicBox_Pacing_Score7.Image = Image.FromFile(n);
                    PicBox_Pacing_Score8.Image = Image.FromFile(n);
                    PicBox_Pacing_Score9.Image = Image.FromFile(n);
                    PicBox_Pacing_Score10.Image = Image.FromFile(n);
                    break;
                case 7:
                    PicBox_Pacing_Score1.Image = Image.FromFile(y);
                    PicBox_Pacing_Score2.Image = Image.FromFile(y);
                    PicBox_Pacing_Score3.Image = Image.FromFile(y);
                    PicBox_Pacing_Score4.Image = Image.FromFile(y);
                    PicBox_Pacing_Score5.Image = Image.FromFile(y);
                    PicBox_Pacing_Score6.Image = Image.FromFile(y);
                    PicBox_Pacing_Score7.Image = Image.FromFile(y);
                    PicBox_Pacing_Score8.Image = Image.FromFile(n);
                    PicBox_Pacing_Score9.Image = Image.FromFile(n);
                    PicBox_Pacing_Score10.Image = Image.FromFile(n);
                    break;
                case 8:
                    PicBox_Pacing_Score1.Image = Image.FromFile(y);
                    PicBox_Pacing_Score2.Image = Image.FromFile(y);
                    PicBox_Pacing_Score3.Image = Image.FromFile(y);
                    PicBox_Pacing_Score4.Image = Image.FromFile(y);
                    PicBox_Pacing_Score5.Image = Image.FromFile(y);
                    PicBox_Pacing_Score6.Image = Image.FromFile(y);
                    PicBox_Pacing_Score7.Image = Image.FromFile(y);
                    PicBox_Pacing_Score8.Image = Image.FromFile(y);
                    PicBox_Pacing_Score9.Image = Image.FromFile(n);
                    PicBox_Pacing_Score10.Image = Image.FromFile(n);
                    break;
                case 9:
                    PicBox_Pacing_Score1.Image = Image.FromFile(y);
                    PicBox_Pacing_Score2.Image = Image.FromFile(y);
                    PicBox_Pacing_Score3.Image = Image.FromFile(y);
                    PicBox_Pacing_Score4.Image = Image.FromFile(y);
                    PicBox_Pacing_Score5.Image = Image.FromFile(y);
                    PicBox_Pacing_Score6.Image = Image.FromFile(y);
                    PicBox_Pacing_Score7.Image = Image.FromFile(y);
                    PicBox_Pacing_Score8.Image = Image.FromFile(y);
                    PicBox_Pacing_Score9.Image = Image.FromFile(y);
                    PicBox_Pacing_Score10.Image = Image.FromFile(n);
                    break;
                case 10:
                    PicBox_Pacing_Score1.Image = Image.FromFile(y);
                    PicBox_Pacing_Score2.Image = Image.FromFile(y);
                    PicBox_Pacing_Score3.Image = Image.FromFile(y);
                    PicBox_Pacing_Score4.Image = Image.FromFile(y);
                    PicBox_Pacing_Score5.Image = Image.FromFile(y);
                    PicBox_Pacing_Score6.Image = Image.FromFile(y);
                    PicBox_Pacing_Score7.Image = Image.FromFile(y);
                    PicBox_Pacing_Score8.Image = Image.FromFile(y);
                    PicBox_Pacing_Score9.Image = Image.FromFile(y);
                    PicBox_Pacing_Score10.Image = Image.FromFile(y);
                    break;
            }
        }

        private void Numeric_Balance_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Numeric_Balance.Value))
            {
                case 0:
                    PicBox_Balance_Score1.Image = Image.FromFile(n);
                    PicBox_Balance_Score2.Image = Image.FromFile(n);
                    PicBox_Balance_Score3.Image = Image.FromFile(n);
                    PicBox_Balance_Score4.Image = Image.FromFile(n);
                    PicBox_Balance_Score5.Image = Image.FromFile(n);
                    PicBox_Balance_Score6.Image = Image.FromFile(n);
                    PicBox_Balance_Score7.Image = Image.FromFile(n);
                    PicBox_Balance_Score8.Image = Image.FromFile(n);
                    PicBox_Balance_Score9.Image = Image.FromFile(n);
                    PicBox_Balance_Score10.Image = Image.FromFile(n);
                    break;
                case 1:
                    PicBox_Balance_Score1.Image = Image.FromFile(y);
                    PicBox_Balance_Score2.Image = Image.FromFile(n);
                    PicBox_Balance_Score3.Image = Image.FromFile(n);
                    PicBox_Balance_Score4.Image = Image.FromFile(n);
                    PicBox_Balance_Score5.Image = Image.FromFile(n);
                    PicBox_Balance_Score6.Image = Image.FromFile(n);
                    PicBox_Balance_Score7.Image = Image.FromFile(n);
                    PicBox_Balance_Score8.Image = Image.FromFile(n);
                    PicBox_Balance_Score9.Image = Image.FromFile(n);
                    PicBox_Balance_Score10.Image = Image.FromFile(n);
                    break;
                case 2:
                    PicBox_Balance_Score1.Image = Image.FromFile(y);
                    PicBox_Balance_Score2.Image = Image.FromFile(y);
                    PicBox_Balance_Score3.Image = Image.FromFile(n);
                    PicBox_Balance_Score4.Image = Image.FromFile(n);
                    PicBox_Balance_Score5.Image = Image.FromFile(n);
                    PicBox_Balance_Score6.Image = Image.FromFile(n);
                    PicBox_Balance_Score7.Image = Image.FromFile(n);
                    PicBox_Balance_Score8.Image = Image.FromFile(n);
                    PicBox_Balance_Score9.Image = Image.FromFile(n);
                    PicBox_Balance_Score10.Image = Image.FromFile(n);
                    break;
                case 3:
                    PicBox_Balance_Score1.Image = Image.FromFile(y);
                    PicBox_Balance_Score2.Image = Image.FromFile(y);
                    PicBox_Balance_Score3.Image = Image.FromFile(y);
                    PicBox_Balance_Score4.Image = Image.FromFile(n);
                    PicBox_Balance_Score5.Image = Image.FromFile(n);
                    PicBox_Balance_Score6.Image = Image.FromFile(n);
                    PicBox_Balance_Score7.Image = Image.FromFile(n);
                    PicBox_Balance_Score8.Image = Image.FromFile(n);
                    PicBox_Balance_Score9.Image = Image.FromFile(n);
                    PicBox_Balance_Score10.Image = Image.FromFile(n);
                    break;
                case 4:
                    PicBox_Balance_Score1.Image = Image.FromFile(y);
                    PicBox_Balance_Score2.Image = Image.FromFile(y);
                    PicBox_Balance_Score3.Image = Image.FromFile(y);
                    PicBox_Balance_Score4.Image = Image.FromFile(y);
                    PicBox_Balance_Score5.Image = Image.FromFile(n);
                    PicBox_Balance_Score6.Image = Image.FromFile(n);
                    PicBox_Balance_Score7.Image = Image.FromFile(n);
                    PicBox_Balance_Score8.Image = Image.FromFile(n);
                    PicBox_Balance_Score9.Image = Image.FromFile(n);
                    PicBox_Balance_Score10.Image = Image.FromFile(n);
                    break;
                case 5:
                    PicBox_Balance_Score1.Image = Image.FromFile(y);
                    PicBox_Balance_Score2.Image = Image.FromFile(y);
                    PicBox_Balance_Score3.Image = Image.FromFile(y);
                    PicBox_Balance_Score4.Image = Image.FromFile(y);
                    PicBox_Balance_Score5.Image = Image.FromFile(y);
                    PicBox_Balance_Score6.Image = Image.FromFile(n);
                    PicBox_Balance_Score7.Image = Image.FromFile(n);
                    PicBox_Balance_Score8.Image = Image.FromFile(n);
                    PicBox_Balance_Score9.Image = Image.FromFile(n);
                    PicBox_Balance_Score10.Image = Image.FromFile(n);
                    break;
                case 6:
                    PicBox_Balance_Score1.Image = Image.FromFile(y);
                    PicBox_Balance_Score2.Image = Image.FromFile(y);
                    PicBox_Balance_Score3.Image = Image.FromFile(y);
                    PicBox_Balance_Score4.Image = Image.FromFile(y);
                    PicBox_Balance_Score5.Image = Image.FromFile(y);
                    PicBox_Balance_Score6.Image = Image.FromFile(y);
                    PicBox_Balance_Score7.Image = Image.FromFile(n);
                    PicBox_Balance_Score8.Image = Image.FromFile(n);
                    PicBox_Balance_Score9.Image = Image.FromFile(n);
                    PicBox_Balance_Score10.Image = Image.FromFile(n);
                    break;
                case 7:
                    PicBox_Balance_Score1.Image = Image.FromFile(y);
                    PicBox_Balance_Score2.Image = Image.FromFile(y);
                    PicBox_Balance_Score3.Image = Image.FromFile(y);
                    PicBox_Balance_Score4.Image = Image.FromFile(y);
                    PicBox_Balance_Score5.Image = Image.FromFile(y);
                    PicBox_Balance_Score6.Image = Image.FromFile(y);
                    PicBox_Balance_Score7.Image = Image.FromFile(y);
                    PicBox_Balance_Score8.Image = Image.FromFile(n);
                    PicBox_Balance_Score9.Image = Image.FromFile(n);
                    PicBox_Balance_Score10.Image = Image.FromFile(n);
                    break;
                case 8:
                    PicBox_Balance_Score1.Image = Image.FromFile(y);
                    PicBox_Balance_Score2.Image = Image.FromFile(y);
                    PicBox_Balance_Score3.Image = Image.FromFile(y);
                    PicBox_Balance_Score4.Image = Image.FromFile(y);
                    PicBox_Balance_Score5.Image = Image.FromFile(y);
                    PicBox_Balance_Score6.Image = Image.FromFile(y);
                    PicBox_Balance_Score7.Image = Image.FromFile(y);
                    PicBox_Balance_Score8.Image = Image.FromFile(y);
                    PicBox_Balance_Score9.Image = Image.FromFile(n);
                    PicBox_Balance_Score10.Image = Image.FromFile(n);
                    break;
                case 9:
                    PicBox_Balance_Score1.Image = Image.FromFile(y);
                    PicBox_Balance_Score2.Image = Image.FromFile(y);
                    PicBox_Balance_Score3.Image = Image.FromFile(y);
                    PicBox_Balance_Score4.Image = Image.FromFile(y);
                    PicBox_Balance_Score5.Image = Image.FromFile(y);
                    PicBox_Balance_Score6.Image = Image.FromFile(y);
                    PicBox_Balance_Score7.Image = Image.FromFile(y);
                    PicBox_Balance_Score8.Image = Image.FromFile(y);
                    PicBox_Balance_Score9.Image = Image.FromFile(y);
                    PicBox_Balance_Score10.Image = Image.FromFile(n);
                    break;
                case 10:
                    PicBox_Balance_Score1.Image = Image.FromFile(y);
                    PicBox_Balance_Score2.Image = Image.FromFile(y);
                    PicBox_Balance_Score3.Image = Image.FromFile(y);
                    PicBox_Balance_Score4.Image = Image.FromFile(y);
                    PicBox_Balance_Score5.Image = Image.FromFile(y);
                    PicBox_Balance_Score6.Image = Image.FromFile(y);
                    PicBox_Balance_Score7.Image = Image.FromFile(y);
                    PicBox_Balance_Score8.Image = Image.FromFile(y);
                    PicBox_Balance_Score9.Image = Image.FromFile(y);
                    PicBox_Balance_Score10.Image = Image.FromFile(y);
                    break;
            }
        }

        private void Numeric_Overall_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Numeric_Overall.Value))
            {
                case 0:
                    PicBox_Additional_Score1.Image = Image.FromFile(n);
                    PicBox_Additional_Score2.Image = Image.FromFile(n);
                    PicBox_Additional_Score3.Image = Image.FromFile(n);
                    PicBox_Additional_Score4.Image = Image.FromFile(n);
                    PicBox_Additional_Score5.Image = Image.FromFile(n);
                    PicBox_Additional_Score6.Image = Image.FromFile(n);
                    PicBox_Additional_Score7.Image = Image.FromFile(n);
                    PicBox_Additional_Score8.Image = Image.FromFile(n);
                    PicBox_Additional_Score9.Image = Image.FromFile(n);
                    PicBox_Additional_Score10.Image = Image.FromFile(n);
                    break;
                case 1:
                    PicBox_Additional_Score1.Image = Image.FromFile(y);
                    PicBox_Additional_Score2.Image = Image.FromFile(n);
                    PicBox_Additional_Score3.Image = Image.FromFile(n);
                    PicBox_Additional_Score4.Image = Image.FromFile(n);
                    PicBox_Additional_Score5.Image = Image.FromFile(n);
                    PicBox_Additional_Score6.Image = Image.FromFile(n);
                    PicBox_Additional_Score7.Image = Image.FromFile(n);
                    PicBox_Additional_Score8.Image = Image.FromFile(n);
                    PicBox_Additional_Score9.Image = Image.FromFile(n);
                    PicBox_Additional_Score10.Image = Image.FromFile(n);
                    break;
                case 2:
                    PicBox_Additional_Score1.Image = Image.FromFile(y);
                    PicBox_Additional_Score2.Image = Image.FromFile(y);
                    PicBox_Additional_Score3.Image = Image.FromFile(n);
                    PicBox_Additional_Score4.Image = Image.FromFile(n);
                    PicBox_Additional_Score5.Image = Image.FromFile(n);
                    PicBox_Additional_Score6.Image = Image.FromFile(n);
                    PicBox_Additional_Score7.Image = Image.FromFile(n);
                    PicBox_Additional_Score8.Image = Image.FromFile(n);
                    PicBox_Additional_Score9.Image = Image.FromFile(n);
                    PicBox_Additional_Score10.Image = Image.FromFile(n);
                    break;
                case 3:
                    PicBox_Additional_Score1.Image = Image.FromFile(y);
                    PicBox_Additional_Score2.Image = Image.FromFile(y);
                    PicBox_Additional_Score3.Image = Image.FromFile(y);
                    PicBox_Additional_Score4.Image = Image.FromFile(n);
                    PicBox_Additional_Score5.Image = Image.FromFile(n);
                    PicBox_Additional_Score6.Image = Image.FromFile(n);
                    PicBox_Additional_Score7.Image = Image.FromFile(n);
                    PicBox_Additional_Score8.Image = Image.FromFile(n);
                    PicBox_Additional_Score9.Image = Image.FromFile(n);
                    PicBox_Additional_Score10.Image = Image.FromFile(n);
                    break;
                case 4:
                    PicBox_Additional_Score1.Image = Image.FromFile(y);
                    PicBox_Additional_Score2.Image = Image.FromFile(y);
                    PicBox_Additional_Score3.Image = Image.FromFile(y);
                    PicBox_Additional_Score4.Image = Image.FromFile(y);
                    PicBox_Additional_Score5.Image = Image.FromFile(n);
                    PicBox_Additional_Score6.Image = Image.FromFile(n);
                    PicBox_Additional_Score7.Image = Image.FromFile(n);
                    PicBox_Additional_Score8.Image = Image.FromFile(n);
                    PicBox_Additional_Score9.Image = Image.FromFile(n);
                    PicBox_Additional_Score10.Image = Image.FromFile(n);
                    break;
                case 5:
                    PicBox_Additional_Score1.Image = Image.FromFile(y);
                    PicBox_Additional_Score2.Image = Image.FromFile(y);
                    PicBox_Additional_Score3.Image = Image.FromFile(y);
                    PicBox_Additional_Score4.Image = Image.FromFile(y);
                    PicBox_Additional_Score5.Image = Image.FromFile(y);
                    PicBox_Additional_Score6.Image = Image.FromFile(n);
                    PicBox_Additional_Score7.Image = Image.FromFile(n);
                    PicBox_Additional_Score8.Image = Image.FromFile(n);
                    PicBox_Additional_Score9.Image = Image.FromFile(n);
                    PicBox_Additional_Score10.Image = Image.FromFile(n);
                    break;
                case 6:
                    PicBox_Additional_Score1.Image = Image.FromFile(y);
                    PicBox_Additional_Score2.Image = Image.FromFile(y);
                    PicBox_Additional_Score3.Image = Image.FromFile(y);
                    PicBox_Additional_Score4.Image = Image.FromFile(y);
                    PicBox_Additional_Score5.Image = Image.FromFile(y);
                    PicBox_Additional_Score6.Image = Image.FromFile(y);
                    PicBox_Additional_Score7.Image = Image.FromFile(n);
                    PicBox_Additional_Score8.Image = Image.FromFile(n);
                    PicBox_Additional_Score9.Image = Image.FromFile(n);
                    PicBox_Additional_Score10.Image = Image.FromFile(n);
                    break;
                case 7:
                    PicBox_Additional_Score1.Image = Image.FromFile(y);
                    PicBox_Additional_Score2.Image = Image.FromFile(y);
                    PicBox_Additional_Score3.Image = Image.FromFile(y);
                    PicBox_Additional_Score4.Image = Image.FromFile(y);
                    PicBox_Additional_Score5.Image = Image.FromFile(y);
                    PicBox_Additional_Score6.Image = Image.FromFile(y);
                    PicBox_Additional_Score7.Image = Image.FromFile(y);
                    PicBox_Additional_Score8.Image = Image.FromFile(n);
                    PicBox_Additional_Score9.Image = Image.FromFile(n);
                    PicBox_Additional_Score10.Image = Image.FromFile(n);
                    break;
                case 8:
                    PicBox_Additional_Score1.Image = Image.FromFile(y);
                    PicBox_Additional_Score2.Image = Image.FromFile(y);
                    PicBox_Additional_Score3.Image = Image.FromFile(y);
                    PicBox_Additional_Score4.Image = Image.FromFile(y);
                    PicBox_Additional_Score5.Image = Image.FromFile(y);
                    PicBox_Additional_Score6.Image = Image.FromFile(y);
                    PicBox_Additional_Score7.Image = Image.FromFile(y);
                    PicBox_Additional_Score8.Image = Image.FromFile(y);
                    PicBox_Additional_Score9.Image = Image.FromFile(n);
                    PicBox_Additional_Score10.Image = Image.FromFile(n);
                    break;
                case 9:
                    PicBox_Additional_Score1.Image = Image.FromFile(y);
                    PicBox_Additional_Score2.Image = Image.FromFile(y);
                    PicBox_Additional_Score3.Image = Image.FromFile(y);
                    PicBox_Additional_Score4.Image = Image.FromFile(y);
                    PicBox_Additional_Score5.Image = Image.FromFile(y);
                    PicBox_Additional_Score6.Image = Image.FromFile(y);
                    PicBox_Additional_Score7.Image = Image.FromFile(y);
                    PicBox_Additional_Score8.Image = Image.FromFile(y);
                    PicBox_Additional_Score9.Image = Image.FromFile(y);
                    PicBox_Additional_Score10.Image = Image.FromFile(n);
                    break;
                case 10:
                    PicBox_Additional_Score1.Image = Image.FromFile(y);
                    PicBox_Additional_Score2.Image = Image.FromFile(y);
                    PicBox_Additional_Score3.Image = Image.FromFile(y);
                    PicBox_Additional_Score4.Image = Image.FromFile(y);
                    PicBox_Additional_Score5.Image = Image.FromFile(y);
                    PicBox_Additional_Score6.Image = Image.FromFile(y);
                    PicBox_Additional_Score7.Image = Image.FromFile(y);
                    PicBox_Additional_Score8.Image = Image.FromFile(y);
                    PicBox_Additional_Score9.Image = Image.FromFile(y);
                    PicBox_Additional_Score10.Image = Image.FromFile(y);
                    break;
            }
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
        }
    }
}
