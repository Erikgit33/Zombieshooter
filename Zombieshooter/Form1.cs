namespace Zombieshooter
{
    public partial class Form1 : Form
    {
        // lista som inneh�ller alla levande zombies
        List<Zombie> zombieList = new List<Zombie>();

        // vapen med olika egenskaper
        Weapon revolver = new Weapon(50, TimeSpan.FromMilliseconds(200));
        Weapon shotgun = new Weapon(200, TimeSpan.FromMilliseconds(600));

        // ljudeffekt f�r shotgun
        System.Media.SoundPlayer shotgunSound =
            new System.Media.SoundPlayer(Properties.Resources.shotgun_sound);

        // ljudeffekt f�r revolver
        System.Media.SoundPlayer revolverSound =
            new System.Media.SoundPlayer(Properties.Resources.revolver_sound);

        // ljudeffekt f�r n�r spelaren d�r
        System.Media.SoundPlayer deathSound =
            new System.Media.SoundPlayer(Properties.Resources.wilhelm_scream);

        // ljudeffekt f�r n�r zombie d�r
        System.Media.SoundPlayer zombieDeathSound =
            new System.Media.SoundPlayer(Properties.Resources.zombie_death);

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 1. Avfyra shotgunen om det inte �verskrider "firing rate"
        /// 2. Den n�rmase zombien skadas
        /// 3. Om den skadade zombien f�rlorar alla sina HP d�r den och spelaren f�r po�ng
        /// </summary>
        private void picShotgun_Click(object sender, EventArgs e)
        {
            shotgunSound.Play();

            bool didFire = shotgun.Fire();
            if (didFire)
            {
                // TODO skada f�rsta zombien
            }
        }

        /// <summary>
        /// 1. Avfyra revolvern om det inte �verskrider "firing rate"
        /// 2. Den n�rmase zombien skadas
        /// 3. Om den skadade zombien f�rlorar alla sina HP d�r den och spelaren f�r po�ng
        /// </summary>
        private void picRevolver_Click(object sender, EventArgs e)
        {
            zombieDeathSound.Play();

            bool didFire = revolver.Fire();
            if (didFire)
            {
                // TODO skada f�rsta zombien
            }
        }

        /// <summary>
        /// Kontrollera om en zombie kommit hela v�gen fram. Kommer en zombie hela v�gen fram
        /// f�rlorar man spelet.
        /// </summary>
        private void loseGameIfZombieIsBiting()
        {
            // TODO om zombie kommit hela v�gen fram f�rlorar man spelet
        }

        /// <summary>
        /// Flytta alla zombies. Kontrollera om n�gon kommit �nda fram.
        /// </summary>
        private void timerMove_Tick(object sender, EventArgs e)
        {
            foreach (Zombie zombie in zombieList)
            {
                zombie.Move(timerMove.Interval);
            }
            loseGameIfZombieIsBiting();
        }

        /// <summary>
        /// Skapa (eng. spawn) en ny zombie och l�gg till i listan.
        /// </summary>
        private void timerSpawn_Tick(object sender, EventArgs e)
        {
            AddZombie();
        }

        /// <summary>
        /// Skapa och l�gg till en ny zombie.
        /// </summary>
        private void AddZombie()
        {
            // skapa ett nytt zombie-objekt
            Zombie zombie = new Zombie(100, 15, 0);
            // h�mta och l�gg till alla kontroller i zombien (picture, label m.m.)
            AddControls(zombie.GetControls());
            // l�gg till zombien i zombielistan
            zombieList.Add(zombie);
        }

        /// <summary>
        /// L�gg till alla kontroller i en lista till formul�ret
        /// </summary>
        private void AddControls(List<Control> controls)
        {
            foreach (Control c in controls)
            {
                Controls.Add(c);
                c.BringToFront();
            }
        }

        /// <summary>
        /// Ta bort alla kontroller i en lista fr�n formul�ret
        /// </summary>
        private void RemoveControls(List<Control> controls)
        {
            foreach (Control c in controls)
            {
                Controls.Remove(c);
            }
        }

        /// <summary>
        /// Starta spelet n�r man klickar p� knappen.
        /// </summary>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            timerMove.Start();
            timerSpawn.Start();
            AddZombie();
        }
    }
}