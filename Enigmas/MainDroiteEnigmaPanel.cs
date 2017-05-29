﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    public class MainDroiteEnigmaPanel : EnigmaPanel
    {
        public MainDroiteEnigmaPanel()
        {
            //Panel pnlMainDroite = new Panel();
            //pnlMainDroite.BackgroundImage = Image.FromFile("C:/Users/schindlerda/Desktop/Main_gauche_droite.bmp");
            //pnlMains.BackgroundImage = Properties.Resources.image;


            Image test = Properties.Resources.Main_droite;
            PictureBox pbxMainDroite = new PictureBox();
            //pbxMainDroite.Parent = GameBoard;
            pbxMainDroite.Image = test;
            pbxMainDroite.Width = test.Width * 2;
            pbxMainDroite.Height = test.Height * 2;
            pbxMainDroite.Location = new Point(0, 90);
            pbxMainDroite.BackColor = Color.Transparent;
            pbxMainDroite.BringToFront();
        }
        public void pbxMainDroite_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La réponse est : Main droite");
        }
    }
}