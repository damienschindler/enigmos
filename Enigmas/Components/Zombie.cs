﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class Zombie : PictureBox
    {
        private bool bZombieStop = false;//definit si le zombie est arreter
        private Direction direction;//définit la direction du zombie
        private PictureBox pbxBatiment;//image du batiment
        private ZombieInvasionEnigmaPanel parent;//déclaration du parent

        /// <summary>
        /// C'est le constructeur par défaut de la classe zombie
        /// </summary>
        /// <param name="parent">on lui envoie le panel</param>
        /// <param name="direction">on lui envoie la direction du zombie</param>
        /// <param name="pbxBatiment">on lui envoie le batiment central</param>
        public Zombie(ZombieInvasionEnigmaPanel parent, Direction direction, PictureBox pbxBatiment)
        {
            this.Size = Properties.Resources.ZombieDroite.Size; //on définit la taille de l'image
            this.direction = direction;
            this.pbxBatiment = pbxBatiment;
            this.parent = parent;

            //on affecte différent paramétre selon la position du zombie
            if (direction == Direction.GAUCHE)
            {
                this.Location = new Point(parent.Width - this.Width, parent.Height - this.Height);//place les zombies sur le panel
                this.Image = Properties.Resources.ZombieDroite;//définit une image
            }
            else
            {
                this.Location = new Point(0, parent.Height - this.Height);//place les zombies sur le panel
                this.Image = Properties.Resources.ZombieGauche;//définit une image
            }

            MouseClick += new MouseEventHandler(ZombieClick);//crée un evenement de clique sur le zombie
        }

        /// <summary>
        /// permet de faire avancer le zombie
        /// </summary>
        public void Avancer()
        {
            //teste s'il n'y a pas de collison
            if (Collision())
            {
                throw new ArreterException();
                ////s'il y a collision on arrete le zombie
            }

            //teste que le zombie ne soit pas stopper
            if (!bZombieStop)
            {
                //si il avance en direction de la gauche
                if(direction == Direction.GAUCHE)
                {
                    this.Left -= 2;//on fais avancer l'objet
                }
                else
                {
                    this.Left += 2;//on fais avancer l'objet
                }
            }
        }

        /// <summary>
        /// permet de stopper le zombie
        /// </summary>
        private void Arreter()
        {
            bZombieStop = true;
        }


        /// <summary>
        /// permet de tester s'il y a une collision entre le zombie et le batiment
        /// </summary>
        /// <returns>retorune 'false' s'il n'y a pas de collision retourne 'true' dans le cas contraire</returns>
        public bool Collision()
        {
            if(bZombieStop)
            {
                return false;
            }

            if(this.Right < pbxBatiment.Left)
            {
                return false;
            }
            
            if(this.Left > pbxBatiment.Right)
            {
                return false;
            }

            if(this.Bottom < pbxBatiment.Top)
            {
                return false;
            }

            if(this.Top > pbxBatiment.Bottom)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Evenement de clique sur le zombie
        /// </summary>
        private void ZombieClick(object sender, MouseEventArgs e)
        {
            //on envoie différent parametres au parent
            parent.PanelClick(sender, e);
            parent.TuerZombie(this);

        }
    }

    /// <summary>
    /// Lancement d'un exeption
    /// </summary>
    class ArreterException : Exception
    {

    }
}
