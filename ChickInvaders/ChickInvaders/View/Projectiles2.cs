using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChickInvaders
{
    public partial class Projectile2
    {
        private int px;                                         // Position en X depuis la gauche de l'espace aérien
        private int py;                                         // Position en Y depuis le haut de l'espace aérien
        private int pNum;                                       // Numéro du projectile pour savoir sa trajectoire
        private Image projImage2;                               // Image du projectile
        public Rectangle projHitbox2 { get; private set; }      // Hitbox du projectile
        private int projHeight2;                                // Hauteur de l'image du projectile
        private int projWidth2;                                 // Largeur de l'image du projectile

        // Constructeur
        public Projectile2(int x, int y, int num)
        {
            px = x;
            py = y;
            pNum = num;
            projHeight2 = 15;
            projWidth2 = 15;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\projectile2.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            projImage2 = Image.FromFile(imagePath);
        }
        public int X { get { return px; } }
        public int Y { get { return py; } }

        // Méthode qui met à jour la Hitbox selon l'emplacement du projectile
        private void UpdateHitbox()
        {
            projHitbox2 = new Rectangle(px + 10, py + 10, projWidth2, projHeight2); // Placement de la Hitbox
        }

        // Méthode qui définit la trajectoire du projectile selon son numéro
        public void UpdateP2(int interval)
        {
            if (pNum == 1)
            {
                py = py + 8;
                px = px - 3;
                py++;
            }
            if (pNum == 2)
            {
                py = py + 8;
                py++;
            }
            if (pNum == 3)
            {
                py = py + 8;
                px = px + 3;
                py++;
            }

            UpdateHitbox();
        }
    }
}
