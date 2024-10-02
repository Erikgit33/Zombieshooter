namespace Zombieshooter
{
    public partial class Form1 : Form
    {
        // lista som innehåller alla levande zombies
        List<Zombie> zombieList = new List<Zombie>();

        // vapen med olika egenskaper
        Weapon revolver = new Weapon(50, TimeSpan.FromMilliseconds(200));
        Weapon shotgun = new Weapon(200, TimeSpan.FromMilliseconds(1500));

        // ljudeffekt för shotgun
        System.Media.SoundPlayer shotgunSound =
            new System.Media.SoundPlayer(Properties.Resources.shotgun_sound);

        // ljudeffekt för revolver
        System.Media.SoundPlayer revolverSound =
            new System.Media.SoundPlayer(Properties.Resources.revolver_sound);

        // ljudeffekt för när spelaren dör
        System.Media.SoundPlayer deathSound =
            new System.Media.SoundPlayer(Properties.Resources.wilhelm_scream);

        // ljudeffekt för när zombie dör
        System.Media.SoundPlayer zombieDeathSound =
            new System.Media.SoundPlayer(Properties.Resources.zombie_death);

        public Form1()
        {
            InitializeComponent();
        }

        int score;
        int highScore;

        /// <summary>
        /// 1. Avfyra shotgunen om den inte överskrider "firing rate"
        /// 2. Den närmase zombien skadas
        /// 3. Om den skadade zombien förlorar alla sina HP dör den och spelaren får poäng
        /// </summary>

        private void picShotgun_Click(object sender, EventArgs e)
        {
            ShootWeapon(shotgun, shotgunSound);
        }

        /// <summary>
        /// 1. Avfyra revolvern om den inte överskrider "firing rate"
        /// 2. Den närmase zombien skadas
        /// 3. Om den skadade zombien förlorar alla sina HP dör den och spelaren får poäng
        /// </summary>

        private void picRevolver_Click(object sender, EventArgs e)
        {
            ShootWeapon(revolver, revolverSound);
        }


        private void ShootWeapon(Weapon weapon, System.Media.SoundPlayer sound)
        {
            bool didFire = weapon.Fire();
            if (didFire && zombieList.Count != 0)
            {
                sound.Play();
                if (weapon.Equals(shotgun) == false)
                {
                    zombieList[0].Shot(weapon);
                }
                else
                {
                    double dmgModifier = 1.15 + (zombieList[0].GetLocationPercent()/100.0);
                    zombieList[0].Shot(weapon, dmgModifier);
                }

                if (zombieList[0].NoHitpoints())
                {
                    score++;
                    labelScore.Text = "SCORE: " + score.ToString();
                    RemoveControls(zombieList[0].GetControls());
                    zombieDeathSound.Play();
                    if (zombieList[0] != null)
                    {
                        zombieList.RemoveAt(0);
                    }
                    else
                    {
                        zombieList.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Flytta alla zombies. Kontrollera om någon kommit ända fram.
        /// </summary>
        private void timerMove_Tick(object sender, EventArgs e)
        { 
            foreach (Zombie zombie in zombieList)
            {
                zombie.Move(timerMove.Interval);
            }

            // flytta fram all UI så inte zombien överlappar den
            labelScore.BringToFront();
            buttonStart.BringToFront();
            loseGameIfZombieIsBiting();
        }

        /// <summary>
        /// Kontrollera om en zombie kommit hela vägen fram. Kommer en zombie hela vägen fram
        /// förlorar man spelet.
        /// </summary>
        private void loseGameIfZombieIsBiting()
        {
            if (zombieList.Count > 0)
            {
                if (zombieList[0].IsBiting())
                {
                    timerMove.Stop();
                    timerSpawn.Stop();
                    deathSound.Play();
                    labelDead.BringToFront();
                    labelDead.Visible = true;
                    if (score > highScore)
                    {
                        highScore = score;
                    }
                    labelHighScore.Text = "HIGHSCORE: " + highScore;
                    labelHighScore.BringToFront();
                    labelHighScore.Visible = true;
                }
            }
        }

        /// <summary>
        /// Skapa (eng. spawn) en ny zombie och lägg till i listan.
        /// </summary>
        private void timerSpawn_Tick(object sender, EventArgs e)
        {
            AddZombie();
        }

        /// <summary>
        /// Skapa och lägg till en ny zombie.
        /// </summary>
        private void AddZombie()
        { 
            Random rng = new Random();
            int random = rng.Next(1, 5);

            if (random == 1)
            {
                int hitPointsPowerful = rng.Next(800, 1501);
  
                Zombie zombiePowerful = new Zombie(hitPointsPowerful, 12, 0);
                AddControls(zombiePowerful.GetControls());
                zombieList.Add(zombiePowerful);
            }
            else if (random != 1)
            {
                int hitPoints = rng.Next(400, 801);
             
                Zombie zombie = new Zombie(hitPoints, 12, 0);
                AddControls(zombie.GetControls());
                zombieList.Add(zombie);
            }
        }

        /// <summary>
        /// Lägg till alla kontroller i en lista till formuläret
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
        /// Ta bort alla kontroller i en lista från formuläret
        /// </summary>
        private void RemoveControls(List<Control> controls)
        {
            foreach (Control c in controls)
            {
                Controls.Remove(c);
            }
        }

        /// <summary>
        /// Starta spelet när man klickar på knappen.
        /// </summary>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (zombieList.Count > 0)
            {
                foreach (Zombie zombie in zombieList)
                {
                    RemoveControls(zombie.GetControls());
                }
                zombieList.Clear();
                labelDead.Visible = false;
                labelHighScore.Visible = false;
                score = 0;
                labelScore.Text = "SCORE: " + score.ToString();

                timerMove.Start();
                timerSpawn.Start();
                AddZombie();
            }
            else
            {
                timerMove.Start();
                timerSpawn.Start();
                AddZombie();
            }
        }
    }
}