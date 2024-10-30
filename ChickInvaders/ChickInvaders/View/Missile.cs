using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChickInvaders
{
    public partial class Missile
    {
        private int mx;
        private int my;
        public Image missileImage;
        private int speedM;
        public Rectangle mHitbox { get; private set; }
        private int mWidth;
        private int mHeight;

        // Constructeur
        public Missile(int x, int y)
        {
            mx = x;
            my = y;
            speedM = GlobalHelpers.alea.Next(1, 8);
            mWidth = 50;
            mHeight = 35;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\missile.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            missileImage = Image.FromFile(imagePath);
        }
        public int X { get { return mx; } }
        public int Y { get { return my; } }

        private void UpdateHitbox()
        {
            mHitbox = new Rectangle(mx, my, mWidth, mHeight);
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdateF(int interval)
        {
            if (mx < 1100)
            {
                mx += speedM;
                mx++;
            }
            else
            {
                mx = 0;
                speedM = GlobalHelpers.alea.Next(1, 8);
                my = GlobalHelpers.alea.Next(1, 150);
            }
            UpdateHitbox();
        }
    }
}
