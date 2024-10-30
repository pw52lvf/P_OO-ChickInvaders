namespace ChickInvaders
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Création des listes des entités
            List<Chick> coop= new List<Chick>();
            List<Foes> ufo = new List<Foes>();
            List<Foes2> ufo2 = new List<Foes2>();
            List<Projectile> projectiles = new List<Projectile>();
            List<Eggs> eggs = new List<Eggs>();
            List<Coeur> coeurs = new List<Coeur>();
            List<Beetle> beets = new List<Beetle>();
            List<Perdu> gameover = new List<Perdu>();
            List<Winner> winners = new List<Winner>();
            List<Foes3> ufo3 = new List<Foes3>();
            List<Round2> rounds = new List<Round2>();
            List<Projectile2> projectiles2 = new List<Projectile2>();
            List<Explosion> explosions = new List<Explosion>();
            coop.Add(new Chick(Land.WIDTH / 2, Land.HEIGHT / 2, "Chick"));

            ufo.Add(new Foes(1200, 0, "Sajad"));
            ufo.Add(new Foes(1200, 0, "Arthur"));
            ufo.Add(new Foes(1200, 0, "Ricardo"));
            ufo.Add(new Foes(1200, 0, "Gabriel"));
            ufo.Add(new Foes(1200, 0, "Pubert"));
            ufo.Add(new Foes(1200, 0, "Arnold"));
            ufo2.Add(new Foes2(0, 0, "Sambi"));
            ufo2.Add(new Foes2(0, 0, "Miguel"));
            ufo2.Add(new Foes2(0, 0, "André"));
            ufo2.Add(new Foes2(0, 0, "Lucio"));
            ufo2.Add(new Foes2(0, 0, "Joe"));

            //gameover.Add(new Perdu(400, 150));

            // Démarrage
            Application.Run(new Land(coop, ufo, ufo2, projectiles, eggs, coeurs, beets, gameover, winners, ufo3, rounds, projectiles2, explosions));
        }
    }
}