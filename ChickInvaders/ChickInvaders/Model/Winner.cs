using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChickInvaders
{
    public partial class Winner
    {
        public int winnerX;
        public int winnerY;
        private Image winner;

        // Constructeur
        public Winner(int x, int y)
        {
            winnerX = x;
            winnerY = y;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\winner.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            winner = Image.FromFile(imagePath);
        }
        public int X { get { return winnerX; } }
        public int Y { get { return winnerY; } }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdateWinner(int interval)
        {
        }
    }
}
