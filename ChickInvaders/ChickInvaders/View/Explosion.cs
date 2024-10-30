using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChickInvaders
{
    public partial class Explosion
    {
        public int exploX;
        public int exploY;
        private Image explosion;
        public int duree = 0;

        // Constructeur
        public Explosion(int x, int y)
        {
            exploX = x;
            exploY = y;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\ex1.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            explosion = Image.FromFile(imagePath);
        }
        public int X { get { return exploX; } }
        public int Y { get { return exploY; } }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdateExplo(int interval)
        {
            duree++;

            if (duree == 5)
            {
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\ex2.png");
                explosion = Image.FromFile(imagePath);
            }
            if (duree == 8)
            {
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\ex3.png");
                explosion = Image.FromFile(imagePath);
            }
            if (duree == 10)
            {
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\ex4.png");
                explosion = Image.FromFile(imagePath);
            }
            if (duree == 12)
            {
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\ex5.png");
                explosion = Image.FromFile(imagePath);
            }
            if (duree == 15)
            {
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\ex6.png");
                explosion = Image.FromFile(imagePath);
            }
        }
    }
}
