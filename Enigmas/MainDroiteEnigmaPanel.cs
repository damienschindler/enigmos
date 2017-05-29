using System;
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
            Panel pnlMains = new Panel();
            //Image.FromFile(open.FileName);
            pnlMains.BackgroundImage = Image.FromFile("C:\\Users\\schindlerda\\Desktop\\Main_gauche_droite.bmp");
        }
    }
}