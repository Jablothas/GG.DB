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
    // This class creates scorebars to rate each game by several categories
    internal class RatingSystem
    {
        public void Draw(string name, int score, int xPos, int yPos, Panel panel)
        {
            Label Lbl_Category = new Label();
            Lbl_Category.Text = name;
            Lbl_Category.Location = new Point(xPos, (yPos - 4));
            panel.Controls.Add(Lbl_Category);

            Label Lbl_ScoreDigit = new Label();
            Lbl_ScoreDigit.Text = "" + score;
            Lbl_ScoreDigit.Location = new Point((xPos + 275), (yPos - 4));
            Lbl_ScoreDigit.Size = new Size(25, 20); 
            panel.Controls.Add(Lbl_ScoreDigit);

            for (int i = 0; i < score; i++)
            {
                PictureBox PicBox = new PictureBox();
                PicBox.Location = new Point((xPos + 100), yPos);
                PicBox.Image = Image.FromFile("img/score/score_background_white.png");
                PicBox.Size = new Size(15, 10);
                PicBox.SizeMode = PictureBoxSizeMode.CenterImage;
                panel.Controls.Add(PicBox);
                xPos += 17;
            }
            for (int i = score; i < 10; i++)
            {
                PictureBox PicBox = new PictureBox();
                PicBox.Location = new Point((xPos + 100), yPos);
                PicBox.Image = Image.FromFile("img/score/score_background_gray.png");
                PicBox.Size = new Size(15, 10);
                PicBox.SizeMode = PictureBoxSizeMode.CenterImage;
                panel.Controls.Add(PicBox);
                xPos += 17;
            }
        }
    }
}
