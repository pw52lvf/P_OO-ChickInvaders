using System.IO;

namespace ChickInvaders
{
    public partial class Chick
    {
        public static readonly int vieMax = 3;              // Vie maximale de l'objet
        public int vie;                                     // Vie actuelle de l'objet
        private string _name;                               // Un nom
        public int _x;                                      // Position en X depuis la gauche de l'espace aérien
        public int _y;                                      // Position en Y depuis le haut de l'espace aérien
        public Image chickImage;                            // Image de l'objet
        private int _speedX = 0;                            // Vitesse de l'objet en vertical
        private int _speedY = 0;                            // Vitesse de l'objet en horisontal
        public bool isFacingLeft;                           // Pour savoir si l'objet regarde la droite ou la gauche
        public Rectangle chickHitbox { get; private set; }  // Hitbox de l'objet
        private int chickWidth;                             // Largeur de l'image de l'objet
        private int chickHeight;                            // Hauteur de l'image de l'objet

        // Constructeur
        public Chick(int x, int y, string name)
        {
            _x = x;
            _y = y;
            _name = name;
            vie = vieMax;
            chickWidth = 50;
            chickHeight = 50;
        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public string Name { get { return _name; } }

        private void UpdateHitbox()
        {
            chickHitbox = new Rectangle(_x - 25, _y - 25, chickWidth, chickHeight);
        }

        public void GoLeft(int speed)
        {
            _speedX = -speed;
            isFacingLeft = true;
        }
        public void GoRight(int speed)
        {
            _speedX = +speed;
        }
        public void GoUp(int speed)
        {
            _speedY = -speed;
        }
        public void GoDown(int speed)
        {
            _speedY = +speed;
        }
        public void MoveUp()
        {
            _y -= _speedY;
        }
        public void MoveDown()
        {
            _y += _speedY;
        }
        public void MoveLeft()
        {
            _x -= _speedX;
        }
        public void MoveRight()
        {
            _x += _speedX;
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            if (_x > 20 && _x < 1180)
            {
                _x += _speedX;
            }
            else if (_x <= 20)
            {
                _x = 22;
            }
            else if (_x >= 1180)
            {
                _x = 1178;
            }

            if (_y > 200 && _y < 535)
            {
                _y += _speedY;
            }
            else if (_y <= 200)
            {
                _y = 202;
            }
            else if (_y >= 535)
            {
                _y = 533;
            }

            UpdateHitbox();
        }
    }
}
