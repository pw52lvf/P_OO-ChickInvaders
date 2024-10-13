using ChickInvaders;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.IO;
using System.Linq;

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
        private List<Perdu> gameover;
        private List<Winner> winner;
        private List<Foes3> ufo3;
        private List<Round2> rounds;

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;

        private Image background;

        public bool removeEgg;
        public bool removeEgg2;
        public bool heartIsRemoved = true;
        public bool noMoreFoes1Left;
        public bool noMoreFoes2Left;
        public bool round2Finished = false;
        public bool _nextRound;
        public bool eggUp;
        public bool eggDown;
        public bool eggRight;
        public bool eggLeft;

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public Land(List<Chick> coop, List<Foes> ufo, List<Foes2> ufo2, List<Projectile> projectiles, List<Eggs> eggs, List<Coeur> coeurs,
            List<Beetle> beets, List<Perdu> gameover, List<Winner> winner, List<Foes3> ufo3, List<Round2> rounds) : base()
        {
            InitializeComponent();
            this.Size = new Size(WIDTH, HEIGHT);
            // Gets a reference to the current BufferedGraphicsContext
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Move);
            this.KeyUp += new KeyEventHandler(NextRound);
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
            this.gameover = gameover;
            this.winner = winner;
            this.ufo3 = ufo3;
            this.rounds = rounds;

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
            foreach (Perdu perdu in gameover)
            {
                perdu.Render(airspace);
            }
            foreach (Winner winners in winner)
            {
                winners.Render(airspace);
            }
            foreach (Foes3 foes3 in ufo3)
            {
                foes3.Render(airspace);
            }
            foreach (Round2 round2 in rounds)
            {
                round2.Render(airspace);
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
                        break;s
                    case Keys.Escape:
                        Environment.Exit(0);
                        break;
                    case Keys.D1:
                        foreach (Foes foes in ufo)
                        {
                            ufo.Clear();
                            break;
                        }
                        break;
                    case Keys.D2:
                        foreach (Foes2 foes2 in ufo2)
                        {
                            ufo2.Clear();
                            break;
                        }
                        break;
                    case Keys.Up:
                        if (eggs.Count == 0)
                        {
                            foreach (Chick c in coop)
                            {
                                if (eggs.Count == 0)
                                {
                                    eggs.Add(new Eggs(c.X, c.Y));
                                    eggUp = true;
                                }
                            }
                        }
                        break;
                    case Keys.Down:
                        if (eggs.Count == 0)
                        {
                            foreach (Chick c in coop)
                            {
                                if (eggs.Count == 0)
                                {
                                    eggs.Add(new Eggs(c.X, c.Y));
                                    eggDown = true;
                                }
                            }
                        }
                        break;
                    case Keys.Left:
                        if (eggs.Count == 0)
                        {
                            foreach (Chick c in coop)
                            {
                                if (eggs.Count == 0)
                                {
                                    eggs.Add(new Eggs(c.X, c.Y));
                                    eggLeft = true;
                                }
                            }
                        }
                        break;
                    case Keys.Right:
                        if (eggs.Count == 0)
                        {
                            foreach (Chick c in coop)
                            {
                                if (eggs.Count == 0)
                                {
                                    eggs.Add(new Eggs(c.X, c.Y));
                                    eggRight = true;
                                }
                            }
                        }
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

        public void NextRound(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            foreach (Round2 round2 in rounds)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        rounds.Remove(round2);
                        _nextRound = true;
                        break;
                }
                break;
            }
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (Chick chick in coop)
            {
                chick.Update(interval);
                int randomB = GlobalHelpers.alea.Next(0, 200);
                int randomC = GlobalHelpers.alea.Next(1, 500);
                if (round2Finished == false)
                {
                    if (randomB == 1)
                    {
                        beets.Add(new Beetle(0, GlobalHelpers.alea.Next(200, 500)));
                    }
                }
                if (heartIsRemoved)
                {
                    if (randomC == 1)
                    {
                        coeurs.Add(new Coeur(GlobalHelpers.alea.Next(20, 1180), GlobalHelpers.alea.Next(200, 535)));
                        heartIsRemoved = false;
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

            foreach (Foes3 foes3 in ufo3)
            {
                foes3.UpdateF3(interval);
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
                        Console.WriteLine("Perdu !");
                        coop.Remove(chick);
                        gameover.Add(new Perdu(400, 150));
                        break;
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
                if (eggUp)
                {
                    egg.UpdateEU(interval);
                }
                if (eggDown)
                {
                    egg.UpdateED(interval);
                }
                if (eggRight)
                {
                    egg.UpdateER(interval);
                }
                if (eggLeft)
                {
                    egg.UpdateEL(interval);
                }
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
                foreach (Beetle beetle in beets)
                {
                    if (beetle.beetleHitbox.IntersectsWith(egg.eggHitbox))
                    {
                        removeEgg = true;
                        break;
                    }
                    if (removeEgg)
                    {
                        eggs.Remove(egg);
                    }
                    removeEgg = false;
                }
                if (egg.Y <= 0 || egg.X <= 0 || egg.X >= 1200 || egg.Y >= 600)
                {
                    eggs.Remove(egg);
                    eggUp = false;
                    eggDown = false;
                    eggRight = false;
                    eggLeft = false;
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
                        heartIsRemoved = true;
                        if (chick.vie > 3)
                        {
                            chick.vie++;
                        }
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
                        coop.Remove(chick);
                        gameover.Add(new Perdu(400, 150));
                        break;
                    }
                }
                if (beetle.X >= 1200)
                {
                    beets.Remove(beetle);
                    break;
                }
            }
            foreach (Perdu perdu in gameover)
            {
                perdu.UpdatePerdu(interval);
            }
            foreach (Winner winners in winner)
            {
                winners.UpdateWinner(interval);
            }
            foreach (Round2 round2 in rounds)
            {
                round2.UpdateRound2(interval);
            }

            if (ufo.Count < 1 && ufo2.Count < 1 && winner.Count == 0)
            {
                if (round2Finished == false)
                {
                    Console.WriteLine("Vous avez atteint le deuxième round ! Faites Enter pour passer au prochain round.");
                    rounds.Add(new Round2(400, 150));
                    beets.Clear();
                    round2Finished = true;
                }
            }

            if (_nextRound == true)
            {
                ufo3.Add(new Foes3(0, GlobalHelpers.alea.Next(0, 150), "Mairlaim"));
                
                _nextRound = false;
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