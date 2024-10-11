using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChickInvaders
{
    public partial class Perdu
    {
        public int perduX;
        public int perduY;
        private Image gameOver;

        // Constructeur
        public Perdu(int x, int y)
        {
            perduX = x;
            perduY = y;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\gameover1.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            gameOver = Image.FromFile(imagePath);
        }
        public int X { get { return perduX; } }
        public int Y { get { return perduY; } }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdatePerdu(int interval)
        {
        }
    }
}
