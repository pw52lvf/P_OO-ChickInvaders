using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
            coeurImage = Image.FromFile("coeur.png");
            coeurWidth = 26;
            coeurHeight = 26;
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
