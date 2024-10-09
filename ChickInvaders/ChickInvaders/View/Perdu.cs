using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders.View
{
    public partial class Perdu
    {
        public int perduX;
        public int perduY;
        private List<Image> images = new List<Image>();
        private Image gameOver;
        private int beetleWidth;
        private int beetleHeight;

        // Constructeur
        public Beetle(int x, int y)
        {
            bx = x;
            by = y;
            speedB = GlobalHelpers.alea.Next(1, 3);
            beetleImage = Image.FromFile("beetle.png");
            beetleWidth = 100;
            beetleHeight = 60;
        }
        public int X { get { return bx; } }
        public int Y { get { return by; } }

        private void UpdateHitbox()
        {
            beetleHitbox = new Rectangle(bx, by + 22, beetleWidth, beetleHeight);
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdateB(int interval)
        {
            if (bx < 1250)
            {
                bx += speedB;
                bx++;
            }
            else
            {
                speedB = GlobalHelpers.alea.Next(1, 3);
                by = GlobalHelpers.alea.Next(150, 500);
            }
            UpdateHitbox();
        }
    }
}
