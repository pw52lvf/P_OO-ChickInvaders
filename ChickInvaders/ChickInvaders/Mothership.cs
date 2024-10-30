using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Mothership
    {
        private int motherx;                                 // Position en X depuis la gauche de l'espace aérien
        private int mothery;
        public Image mothershipImage;
        private int speedM;
        public Rectangle motherHitbox { get; private set; }
        private int motherWidth;
        private int motherHeight;
        public int waitingtime = 0;
        //public bool waitingTime;

        // Constructeur
        public Mothership(int x, int y)
        {
            motherx = x;
            mothery = y;
            speedM = GlobalHelpers.alea.Next(1, 8);
            motherWidth = 50;
            motherHeight = 35;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\greenship1.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            mothershipImage = Image.FromFile(imagePath);
        }
        public int X { get { return motherx; } }
        public int Y { get { return mothery; } }

        private void UpdateHitbox()
        {
            motherHitbox = new Rectangle(motherx + 25, mothery + 32, motherWidth, motherHeight);
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdateMother(int interval)
        {
            if (mothery < 100 && waitingtime < 100)
            {
                mothery = mothery + 2;
            }
            if (mothery == 100)
            {
                waitingtime++;
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
                string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\greenship2.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
                mothershipImage = Image.FromFile(imagePath);
                //waitingTime = true;
            }
            if (waitingtime == 100)
            {
                mothery = mothery - 2;
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
                string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\greenship1.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
                mothershipImage = Image.FromFile(imagePath);
                //waitingTime = false;
            }

            UpdateHitbox();
        }
    }
}
