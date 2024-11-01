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
        private string _name;                                       // Nom de l'ufo
        private int fx;                                             // Position en X depuis la gauche de l'espace aérien
        private int fy;                                             // Position en Y depuis le haut de l'espace aérien
        private Image foeImage2;                                    // Image de l'ufo                                                
        private int speedF2;                                        // Vitesse de l'ufo
        public Rectangle foeHitbox2 { get; private set; }           // Hitbox de l'ufo
        private int foeWidth2;                                      // Largeur de l'image de l'ufo
        private int foeHeight2;                                     // Taille de l'image de l'ufo

        // Constructeur
        public Foes2(int x, int y, string name)
        {
            fx = x;
            fy = y;
            _name = name;
            speedF2 = GlobalHelpers.alea.Next(1, 8);                // La vitesse de l'ufo est choisie aléatoirement à son apparition
            foeWidth2 = 55;
            foeHeight2 = 35;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\foe2.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            foeImage2 = Image.FromFile(imagePath);
        }
        public int X { get { return fx; } }
        public int Y { get { return fy; } }
        public string Name { get { return _name; } }

        // Méthode qui met à jour la Hitbox selon l'emplacement de l'ufo
        private void UpdateHitbox()
        {
            foeHitbox2 = new Rectangle(fx + 20, fy + 35, foeWidth2, foeHeight2);
        }

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