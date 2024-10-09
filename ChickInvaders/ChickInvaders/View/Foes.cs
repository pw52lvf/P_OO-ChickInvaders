using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Foes
    {
        public static readonly int FULLCHARGE = 1000;   // Charge maximale de la batterie
        private int _charge;                            // La charge actuelle de la batterie
        private string _name;                           // Un nom
        private int fx;                                 // Position en X depuis la gauche de l'espace aérien
        private int fy;
        private List<Image> images = new List<Image>();
        private Image foeImage1;
        private int speedF;
        public Rectangle foeHitbox1 { get; private set; }
        private int foeWidth1;
        private int foeHeight1;

        // Constructeur
        public Foes(int x, int y, string name)
        {
            fx = x;
            fy = y;
            _name = name;
            speedF = GlobalHelpers.alea.Next(1, 8);
            _charge = FULLCHARGE;
            foeImage1 = Image.FromFile("foe1.png");
            foeWidth1 = 50;
            foeHeight1 = 35;
        }
        public int X { get { return fx; } }
        public int Y { get { return fy; } }
        public string Name { get { return _name; } }

        private void UpdateHitbox()
        {
            foeHitbox1 = new Rectangle(fx + 25, fy + 32, foeWidth1, foeHeight1);
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdateF(int interval)
        {
            if (fx < 1100)
            {
                fx += speedF;
                fx++;
            }
            else
            {
                fx = 0;
                speedF = GlobalHelpers.alea.Next(1, 8);
                fy = GlobalHelpers.alea.Next(1, 150);
            }
            UpdateHitbox();
        }
    }
}
