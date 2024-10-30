using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChickInvaders
{
    public partial class Projectile2
    {
        private int px;                                 // Position en X depuis la gauche de l'espace aérien
        private int py;
        private int pNum;
        private Image projImage2;
        public Rectangle projHitbox2 { get; private set; }
        private int projHeight2;
        private int projWidth2;

        // Constructeur
        public Projectile2(int x, int y, int num)
        {
            px = x;
            py = y;
            pNum = num;
            //_charge = GlobalHelpers.alea.Next(FULLCHARGE); // La charge initiale de la batterie est choisie aléatoirement
            projHeight2 = 15;
            projWidth2 = 15;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\projectile2.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            projImage2 = Image.FromFile(imagePath);
        }
        public int X { get { return px; } }
        public int Y { get { return py; } }

        private void UpdateHitbox()
        {
            projHitbox2 = new Rectangle(px + 10, py + 10, projWidth2, projHeight2);
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdateP2(int interval)
        {
            if (pNum == 1)
            {
                py = py + 8;
                px = px - 3;
                py++;
            }
            if (pNum == 2)
            {
                py = py + 8;
                py++;
            }
            if (pNum == 3)
            {
                py = py + 8;
                px = px + 3;
                py++;
            }

            UpdateHitbox();
        }
    }
}
