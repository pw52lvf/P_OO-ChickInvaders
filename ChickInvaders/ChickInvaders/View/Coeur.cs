using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChickInvaders
{
    public partial class Coeur
    {
        private int cx;                                 // Position en X depuis la gauche de l'espace aérien
        private int cy;
        private Image coeurImage;
        public Rectangle coeurHitbox { get; private set; }
        private int coeurWidth;
        private int coeurHeight;

        // Constructeur
        public Coeur(int x, int y)
        {
            cx = x;
            cy = y;
            coeurWidth = 26;
            coeurHeight = 26;
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\coeur.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            coeurImage = Image.FromFile(imagePath);
        }
        public int X { get { return cx; } }
        public int Y { get { return cy; } }

        private void UpdateHitbox()
        {
            coeurHitbox = new Rectangle(cx + 2, cy + 2, coeurWidth, coeurHeight);
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdateC(int interval)
        {
            //cx = GlobalHelpers.alea.Next(20, 1180);
            //cy = GlobalHelpers.alea.Next(200, 535);

            UpdateHitbox();
        }
    }
}
