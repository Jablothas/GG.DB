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
    static internal class TotalScore
    {
        public static void Draw(int total_score, int xPos, int yPos, Panel panel)
        {
            PictureBox PicBox = new PictureBox();
            if (total_score >= 80)
            {
                PicBox.Image = Image.FromFile(Main.ScoreBackground_Green);
            }
            else if (total_score >= 70)
            {
                PicBox.Image = Image.FromFile(Main.ScoreBackground_Yellow);
            }
            else if (total_score >= 60)
            {
                PicBox.Image = Image.FromFile(Main.ScoreBackground_Orange);
            }
            else if (total_score <= 59)
            {
                PicBox.Image = Image.FromFile(Main.ScoreBackground_Red);
            }
            if (total_score == 0)
            {
                PicBox.Image = Image.FromFile(Main.ScoreBackground_Gray);
            }
            PicBox.Location = new Point(xPos, yPos);
            PicBox.SizeMode = PictureBoxSizeMode.Zoom;
            PicBox.Size = new Size(50, 22);
            panel.Controls.Add(PicBox);

            Label Label_TotalScore = new Label();
            if (total_score == 0)
            {
                Label_TotalScore.Text = "R";
            }
            else
            {
                Label_TotalScore.Text = "" + total_score;
            }
            Label_TotalScore.ForeColor = Color.FromArgb(32, 33, 36);
            Label_TotalScore.BackColor = Color.Transparent;
            Label_TotalScore.Size = new Size(36, 19);
            Label_TotalScore.Font = new Font(panel.Font, FontStyle.Bold);
            Label_TotalScore.TextAlign = ContentAlignment.MiddleCenter;
            Label_TotalScore.Location = new Point(8, 1);
            PicBox.Controls.Add(Label_TotalScore);

            PictureBox PicBox_Medal = new PictureBox();
            if (total_score >= 95)
            {
                PicBox_Medal.Visible = true;
                PicBox_Medal.Image = Image.FromFile(Main.Medal_Gold);
            }
            else if (total_score >= 90)
            {
                PicBox_Medal.Visible = true;
                PicBox_Medal.Image = Image.FromFile(Main.Medal_Silver);
            }
            else if (total_score >= 85)
            {
                PicBox_Medal.Visible = true;
                PicBox_Medal.Image = Image.FromFile(Main.Medal_Bronze);
            }
            else
            {
                PicBox_Medal.Visible = false;
            }
            PicBox_Medal.Location = new Point((xPos + 55), yPos);
            PicBox_Medal.Size = new Size(23, 23);
            PicBox_Medal.SizeMode = PictureBoxSizeMode.Zoom;
            panel.Controls.Add(PicBox_Medal);
        }
    }
}
