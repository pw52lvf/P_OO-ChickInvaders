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
        private List<Projectile2> projectiles2;
        private List<Explosion> explosions;
        private List<Missile> missiles;
        private List<Mothership> motherships;

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
        public bool chickIsFlipped = false;
        public bool canRestart;
        public bool chickwinner = false;
        public bool wexplosions;
        public bool droppedMother;

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public Land(List<Chick> coop, List<Foes> ufo, List<Foes2> ufo2, List<Projectile> projectiles, List<Eggs> eggs, List<Coeur> coeurs,
            List<Beetle> beets, List<Perdu> gameover, List<Winner> winner, List<Foes3> ufo3, List<Round2> rounds, List<Projectile2> projectiles2,
            List<Explosion> explosions, List<Missile> missiles, List<Mothership> motherships) : base()
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
            this.projectiles2 = projectiles2;
            this.explosions = explosions;
            this.missiles = missiles;
            this.motherships = motherships;

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
            foreach (Projectile2 projectile2 in projectiles2)
            {
                projectile2.Render(airspace);
            }
            foreach (Missile missile in missiles)
            {
                missile.Render(airspace);
            }
            foreach (Explosion explosion in explosions)
            {
                explosion.Render(airspace);
            }
            foreach (Mothership mship in motherships)
            {
                mship.Render(airspace);
            }
            airspace.Render();
        }

        public void Move(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            foreach (Perdu perdu in gameover)
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        Environment.Exit(0);
                        break;
                    case Keys.Return:
                        if (canRestart)
                        {
                            foreach (Foes3 foes3 in ufo3)
                            {
                                foes3.foes3vie = 4;
                            }
                            coop.Add(new Chick(Land.WIDTH / 2, Land.HEIGHT / 2, "Chick"));
                            gameover.Remove(perdu);
                            canRestart = false;
                        }
                        break;
                }
                break;
            }
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
                        chickIsFlipped = false;
                        break;
                    case Keys.A:
                        chick.GoLeft(5);
                        chickIsFlipped = true;
                        break;
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
                    case Keys.D3:
                        foreach (Foes3 foes3 in ufo3)
                        {
                            ufo3.Clear();
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
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
                string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\chick.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
                string imagePathFlipped = Path.Combine(projectRoot, @"..\..\..\Images\chick-flipped.png");
                chick.Update(interval);
                int randomB = GlobalHelpers.alea.Next(0, 200);
                int randomC = GlobalHelpers.alea.Next(1, 500);
                int randomD = GlobalHelpers.alea.Next(1, 500);
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
                if (chickIsFlipped)
                {
                    chick.chickImage = Image.FromFile(imagePathFlipped);
                }
                else
                {
                    chick.chickImage = Image.FromFile(imagePath);
                }
                foreach (Missile missile in missiles)
                {
                    if (chick.chickHitbox.IntersectsWith(missile.mHitbox))
                    {
                        missiles.Remove(missile);
                    }
                }
                if ((ufo.Count == 0 || ufo2.Count == 0) && droppedMother != true)
                {
                    motherships.Add(new Mothership(560, 0));
                    droppedMother = true;
                    foreach (Mothership mship in motherships) ;
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

                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;  // Chemin de sortie (bin/Debug)
                string imagePath = Path.Combine(projectRoot, @"..\..\..\Images\foe3.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
                string imagePathDamaged = Path.Combine(projectRoot, @"..\..\..\Images\foe3damaged.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
                string imagePathDamagedA = Path.Combine(projectRoot, @"..\..\..\Images\foe3damagedA.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
                string imagePathDamagedB = Path.Combine(projectRoot, @"..\..\..\Images\foe3damagedB.png");  // Remonter de 3 niveaux pour atteindre la racine du projet
                foes3.foeImage3 = Image.FromFile(imagePath);

                if (foes3.foes3vie == 3)
                {
                    foes3.foeImage3 = Image.FromFile(imagePathDamaged);
                }
                else if (foes3.foes3vie == 2)
                {
                    foes3.foeImage3 = Image.FromFile(imagePathDamagedA);
                }
                else if (foes3.foes3vie == 1)
                {
                    foes3.foeImage3 = Image.FromFile(imagePathDamagedB);
                }
                else
                {
                    foes3.foeImage3 = Image.FromFile(imagePath);
                }

                int randomX = GlobalHelpers.alea.Next(1, 80);
                if (randomX == 1)
                {
                    projectiles2.Add(new Projectile2(foes3.X + 20, foes3.Y + 30, 1));
                    projectiles2.Add(new Projectile2(foes3.X + 20, foes3.Y + 30, 2));
                    projectiles2.Add(new Projectile2(foes3.X + 20, foes3.Y + 30, 3));
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
                        explosions.Add(new Explosion(foes.X + 20, foes.Y + 20));
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
                        explosions.Add(new Explosion(foes2.X + 20, foes2.Y + 20));
                        break;
                    }
                    if (removeEgg)
                    {
                        eggs.Remove(egg);
                    }
                    removeEgg = false;
                }
                foreach (Foes3 foes3 in ufo3)
                {
                    if (foes3.foeHitbox3.IntersectsWith(egg.eggHitbox))
                    {
                        removeEgg = true;
                        foes3.foes3vie--;
                    }

                    if (foes3.foes3vie < 1)
                    {
                        removeEgg = true;
                        ufo3.Remove(foes3);
                        explosions.Add(new Explosion(foes3.X + 20, foes3.Y + 20));
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
                        if (chick.vie < 3)
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
            List<Projectile2> projectilesToRemove2 = new List<Projectile2>();
            foreach (Projectile2 projectile2 in projectiles2)
            {
                projectile2.UpdateP2(interval);
                foreach (Chick chick in coop)
                {
                    if (chick.chickHitbox.IntersectsWith(projectile2.projHitbox2))
                    {
                        chick.vie--;
                        Console.WriteLine(chick.vie);
                        projectilesToRemove2.Add(projectile2);
                        break;
                    }
                    if (chick.vie < 1)
                    {
                        Console.WriteLine("Perdu !");
                        coop.Remove(chick);
                        gameover.Add(new Perdu(400, 150));
                        break;
                    }
                }
                if (projectile2.Y > 550)
                {
                    projectilesToRemove2.Add(projectile2);
                    break;
                }
            }
            foreach (Projectile2 projectile2 in projectilesToRemove2)
            {
                projectiles2.Remove(projectile2);
            }
            foreach (Explosion explosion in explosions)
            {
                explosion.UpdateExplo(interval);
                if (explosion.duree > 15)
                {
                    explosions.Remove(explosion);
                    break;
                }
            }
            foreach (Mothership mship in motherships)
            {
                mship.UpdateMother(interval);

                switch (mship.waitingtime)
                {
                    case 2:
                    case 10:
                    case 20:
                    case 30:
                    case 40:
                    case 50:
                        ufo.Add(new Foes(mship.X, mship.Y, "Arthur"));
                        Console.WriteLine("Ship dropped: Arthur");
                        break;
                    case 60:
                    case 70:
                    case 80:
                    case 90:
                    case 98:
                        ufo2.Add(new Foes2(mship.X, mship.Y, "Arthur"));
                        Console.WriteLine("Ship dropped: Arthur (UFO2)");
                        break;
                }
            }

            if (_nextRound)
            {
                ufo3.Add(new Foes3(0, GlobalHelpers.alea.Next(0, 150), "Donny"));
                ufo3.Add(new Foes3(100, GlobalHelpers.alea.Next(0, 150), "Christ"));
                ufo3.Add(new Foes3(200, GlobalHelpers.alea.Next(0, 150), "Jonny"));
                //missiles.Add(new Missile(GlobalHelpers.alea.Next(200, 1000), GlobalHelpers.alea.Next(200, 400)));

                foreach (Chick chick in coop)
                {
                    chick.vie = 3;
                }

                canRestart = true;
                _nextRound = false;
            }
            if (ufo3.Count < 1 && ufo.Count < 1 && ufo2.Count < 1 && rounds.Count < 1 && chickwinner == false)
            {
                winner.Add(new Winner(400, 150));
                Console.WriteLine("Winner!!!");
                chickwinner = true;
                wexplosions = true;
            }
            if (wexplosions)
            {
                int randomX = GlobalHelpers.alea.Next(1, 3);
                if (randomX == 1)
                {
                    explosions.Add(new Explosion(GlobalHelpers.alea.Next(1, 1200), GlobalHelpers.alea.Next(1, 600)));
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