using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickInvaders
{
    public partial class Foes3
    {
        public static readonly int FULLCHARGE = 3;   // Charge maximale de la batterie
        private int _charge;                            // La charge actuelle de la batterie
        private string _name;                           // Un nom
        private int fx;                                 // Position en X depuis la gauche de l'espace aérien
        private int fy;
        private List<Image> images = new List<Image>();
        private Image foeImage3;
        private int speedF;
        public Rectangle foeHitbox3 { get; private set; }
        private int foeWidth3;
        private int foeHeight3;

        // Constructeur
        public Foes3(int x, int y, string name)
        {
            fx = x;
            fy = y;
            _name = name;
            speedF = GlobalHelpers.alea.Next(1, 8);
            _charge = FULLCHARGE;
            foeWidth3 = 50;
            foeHeight3 = 35;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\foe3.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            foeImage3 = Image.FromFile(imagePath);
        }
        public int X { get { return fx; } }
        public int Y { get { return fy; } }
        public string Name { get { return _name; } }

        private void UpdateHitbox()
        {
            foeHitbox3 = new Rectangle(fx + 25, fy + 32, foeWidth3, foeHeight3);
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdateF3(int interval)
        {
            if (fx < 1100)
            {
                fx += speedF;
                fx++;
                fy += GlobalHelpers.alea.Next(-5, 5);
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
