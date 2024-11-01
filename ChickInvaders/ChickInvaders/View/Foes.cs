using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChickInvaders
{
    public partial class Foes
    {
        private string _name;                                   // Nom de l'ufo
        private int fx;                                         // Position en X depuis la gauche de l'espace aérien
        private int fy;                                         // Position en Y depuis le haut de l'espace aérien
        public Image foeImage1;                                 // Image de l'ufo
        private int speedF;                                     // Vitesse de l'ufo
        public Rectangle foeHitbox1 { get; private set; }       // Hitbox de l'ufo
        private int foeWidth1;                                  // Largeur de l'image de l'ufo
        private int foeHeight1;                                 // Taille de l'image de l'ufo

        // Constructeur
        public Foes(int x, int y, string name)
        {
            fx = x;
            fy = y;
            _name = name;
            speedF = GlobalHelpers.alea.Next(1, 8);             // La vitesse de l'ufo est choisie aléatoirement à son apparition
            foeWidth1 = 50;
            foeHeight1 = 35;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\foe1.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            foeImage1 = Image.FromFile(imagePath);
        }
        public int X { get { return fx; } }
        public int Y { get { return fy; } }
        public string Name { get { return _name; } }

        // Méthode qui met à jour la Hitbox selon l'emplacement de l'ufo
        private void UpdateHitbox()
        {
            foeHitbox1 = new Rectangle(fx + 25, fy + 32, foeWidth1, foeHeight1);
        }

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
                speedF = GlobalHelpers.alea.Next(1, 8); // La vitesse de l'ufo est choisie aléatoirement à sa réaparition
                fy = GlobalHelpers.alea.Next(1, 150);   // L'emplacement vertical de l'ufo est choisi aléatoirement à sa réaparition
            }
            UpdateHitbox();
        }
    }
}
