using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChickInvaders
{
    public partial class Foes2
    {
        public static readonly int FULLCHARGE = 1000;   // Charge maximale de la batterie
        private int _charge;                            // La charge actuelle de la batterie
        private string _name;                           // Un nom
        private int fx;                                 // Position en X depuis la gauche de l'espace aérien
        private int fy;
        private List<Image> images = new List<Image>();
        private Image foeImage2;
        private int speedF2;
        public Rectangle foeHitbox2 { get; private set; }
        private int foeWidth2;
        private int foeHeight2;

        // Constructeur
        public Foes2(int x, int y, string name)
        {
            fx = x;
            fy = y;
            _name = name;
            speedF2 = GlobalHelpers.alea.Next(1, 8);
            _charge = FULLCHARGE;
            foeWidth2 = 55;
            foeHeight2 = 35;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\foe2.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            foeImage2 = Image.FromFile(imagePath);
        }
        public int X { get { return fx; } }
        public int Y { get { return fy; } }
        public string Name { get { return _name; } }

        private void UpdateHitbox()
        {
            foeHitbox2 = new Rectangle(fx + 20, fy + 35, foeWidth2, foeHeight2);
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void UpdateF2(int interval)
        {
            if (fx > 0)
            {
                fx -= speedF2;
            }
            else
            {
                fx = 1100;
                speedF2 = GlobalHelpers.alea.Next(1, 8);
                fy = GlobalHelpers.alea.Next(1, 150);
            }

            UpdateHitbox();
        }
    }
}