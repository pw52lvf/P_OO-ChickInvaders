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
        public Rectangle perduHitbox { get; private set; }
        private int perduWidth;
        private int perduHeight;

        // Constructeur
        public Perdu(int x, int y)
        {
            perduX = x;
            perduY = y;
            perduWidth = 100;
            perduHeight = 60;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\gameover.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            gameOver = Image.FromFile(imagePath);
        }
        public int X { get { return perduX; } }
        public int Y { get { return perduY; } }

        private void UpdateHitbox()
        {
            perduHitbox = new Rectangle(perduX, perduY + 22, perduWidth, perduHeight);
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdatePerdu(int interval)
        {
            UpdateHitbox();
        }
    }
}
