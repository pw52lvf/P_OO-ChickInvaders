using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Round2
    {
        public int round2X;
        public int round2Y;
        private Image round2;

        // Constructeur
        public Round2(int x, int y)
        {
            round2X = x;
            round2Y = y;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\round2.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            round2 = Image.FromFile(imagePath);
        }
        public int X { get { return round2X; } }
        public int Y { get { return round2Y; } }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdateRound2(int interval)
        {
        }
    }
}
