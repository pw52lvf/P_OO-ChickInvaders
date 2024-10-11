using ChickInvaders;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.IO;

namespace ChickInvaders
{
    // La classe Land représente le territoire au dessus duquel les entités peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class Land : Form
    {
        public static readonly int WIDTH = 1200;        // Dimensions de Land
        public static readonly int HEIGHT = 600;

        // La flotte est l'ensemble des drones qui évoluent dans notre espace aérien
        private List<Chick> coop;
        private List<Foes> ufo;
        private List<Foes2> ufo2;
        private List<Projectile> projectiles;
        private List<Eggs> eggs;
        private List<Coeur> coeurs;
        private List<Beetle> beets;

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;

        private Image background;

        public bool removeEgg;
        public bool removeEgg2;
        public bool eggIsRemoved = true;

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public Land(List<Chick> coop, List<Foes> ufo, List<Foes2> ufo2, List<Projectile> projectiles, List<Eggs> eggs, List<Coeur> coeurs, List<Beetle> beets) : base()
        {
            InitializeComponent();
            this.Size = new Size(WIDTH, HEIGHT);
            // Gets a reference to the current BufferedGraphicsContext
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Move);
            this.KeyUp += new KeyEventHandler(StopMove);
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this.coop = coop;
            this.ufo = ufo;
            this.ufo2 = ufo2;
            this.projectiles = projectiles;
            this.eggs = eggs;
            this.coeurs = coeurs;
            this.beets = beets;

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\background.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            SetBackgroundImage(imagePath);
        }

        public void SetBackgroundImage(string filePath)
        {
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
            string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\background.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
            background = Image.FromFile(imagePath);
            BackgroundImage = background;
            //this.Invalidate();
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            Graphics g = airspace.Graphics;
            g.DrawImage(background, 0, 0, WIDTH, HEIGHT);

            // draw chicks
            foreach (Chick chick in coop)
            {
                chick.Render(airspace);
            }
            foreach (Foes foes in ufo)
            {
                foes.Render(airspace);
            }
            foreach (Foes2 foes2 in ufo2)
            {
                foes2.Render(airspace);
            }
            foreach (Projectile projectile in projectiles)
            {
                projectile.Render(airspace);
            }
            foreach (Eggs eggs in eggs)
            {
                eggs.Render(airspace);
            }
            foreach (Coeur coeur in coeurs)
            {
                coeur.Render(airspace);
            }
            foreach (Beetle beetle in beets)
            {
                beetle.Render(airspace);
            }

            airspace.Render();
        }

        public void Move(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            foreach (Chick chick in coop)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        chick.GoUp(5);
                        break;
                    case Keys.S:
                        chick.GoDown(5);
                        break;
                    case Keys.D:
                        chick.GoRight(5);
                        break;
                    case Keys.A:
                        chick.GoLeft(5);
                        break;
                    case Keys.Space:
                        if (eggs.Count == 0)
                        {
                            foreach (Chick c in coop)
                            {
                                eggs.Add(new Eggs(c.X, c.Y));
                            }
                        }
                        break;
                    case Keys.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void StopMove(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            foreach (Chick chick in coop)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        chick.GoUp(0);
                        break;
                    case Keys.S:
                        chick.GoDown(0);
                        break;
                    case Keys.D:
                        chick.GoRight(0);
                        break;
                    case Keys.A:
                        chick.GoLeft(0);
                        break;
                }
            }
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (Chick chick in coop)
            {
                chick.Update(interval);
                int randomC = GlobalHelpers.alea.Next(1, 200);
                if (randomC == 2)
                {
                    beets.Add(new Beetle(0, GlobalHelpers.alea.Next(200, 500)));
                }
                if (eggIsRemoved)
                {
                    if (randomC == 1)
                    {
                        coeurs.Add(new Coeur(GlobalHelpers.alea.Next(20, 1180), GlobalHelpers.alea.Next(200, 535)));
                        eggIsRemoved = false;
                    }
                }
            }
            List<Projectile> projectilesToRemove = new List<Projectile>();
            foreach (Foes foes in ufo)
            {
                foes.UpdateF(interval);
                // Ceci donne 1 chance sur 200 pour qu'un ufo lache un projectile par seconde
                int randomX = GlobalHelpers.alea.Next(1, 200);
                if (randomX == 1)
                {
                    projectiles.Add(new Projectile(foes.X + 40, foes.Y + 30));
                }
            }
            foreach (Foes2 foes2 in ufo2)
            {
                foes2.UpdateF2(interval);
                // Ceci donne 1 chance sur 200 pour qu'un ufo lache un projectile par seconde
                int randomX = GlobalHelpers.alea.Next(1, 200);
                if (randomX == 1)
                {
                    projectiles.Add(new Projectile(foes2.X + 20, foes2.Y + 30));
                }
            }
            foreach (Projectile projectile in projectiles)
            {
                projectile.UpdateP(interval);
                foreach (Chick chick in coop)
                {
                    if (chick.chickHitbox.IntersectsWith(projectile.projHitbox))
                    {
                        chick.vie--;
                        Console.WriteLine(chick.vie);
                        projectilesToRemove.Add(projectile);
                        break;
                    }
                    if (chick.vie == 0)
                    {
                        Environment.Exit(0);
                        Console.WriteLine("Perdu !");
                        return;
                    }
                }
                if (projectile.Y > 550)
                {
                    projectilesToRemove.Add(projectile);
                    break;
                }
            }
            foreach (Projectile projectile in projectilesToRemove)
            {
                projectiles.Remove(projectile);
            }
            foreach (Eggs egg in eggs)
            {
                egg.UpdateE(interval);
                foreach (Foes foes in ufo)
                {
                    if (foes.foeHitbox1.IntersectsWith(egg.eggHitbox))
                    {
                        removeEgg = true;
                        ufo.Remove(foes);
                        break;
                    }
                    if (removeEgg)
                    {
                        eggs.Remove(egg);
                    }
                    removeEgg = false;
                }
                foreach (Foes2 foes2 in ufo2)
                {
                    if (foes2.foeHitbox2.IntersectsWith(egg.eggHitbox))
                    {
                        removeEgg = true;
                        ufo2.Remove(foes2);
                        break;
                    }
                    if (removeEgg)
                    {
                        eggs.Remove(egg);
                    }
                    removeEgg = false;
                }
                if (egg.Y <= 0)
                {
                    eggs.Remove(egg);
                    break;
                }
                break;
            }
            foreach (Coeur coeur in coeurs)
            {
                coeur.UpdateC(interval);
                foreach (Chick chick in coop)
                {
                    if (chick.chickHitbox.IntersectsWith(coeur.coeurHitbox))
                    {
                        eggIsRemoved = true;
                        chick.vie++;
                        Console.WriteLine(chick.vie);
                        coeurs.Remove(coeur);
                        break;
                    }
                }
                break;
            }
            foreach (Beetle beetle in beets)
            {
                beetle.UpdateB(interval);
                foreach (Chick chick in coop)
                {
                    if (chick.chickHitbox.IntersectsWith(beetle.beetleHitbox))
                    {
                        Console.WriteLine("Vous êtes rentré en contact avec une bestiole, dommage !");
                        Environment.Exit(0);
                        return;
                    }
                }
                if (beetle.X >= 1200)
                {
                    beets.Remove(beetle);
                    break;
                }
            }
        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }
    }
}