using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zombieshooter
{
    public partial class FormMenu : Form
    {
        public int normalHigh;
        public int hardHigh;

        public FormMenu()
        {
            InitializeComponent();
            UpdateHighscore();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormMenu));
            buttonStartHard = new Button();
            labelMenuText = new Label();
            buttonStartNormal = new Button();
            labelHighscoreNormal = new Label();
            labelHighscoreHard = new Label();
            SuspendLayout();
            // 
            // buttonStartHard
            // 
            buttonStartHard.BackColor = Color.Black;
            buttonStartHard.Cursor = Cursors.Hand;
            buttonStartHard.Font = new Font("Stencil", 22F, FontStyle.Regular, GraphicsUnit.Point);
            buttonStartHard.ForeColor = Color.White;
            buttonStartHard.Location = new Point(216, 370);
            buttonStartHard.Margin = new Padding(6, 4, 6, 4);
            buttonStartHard.Name = "buttonStartHard";
            buttonStartHard.Size = new Size(396, 69);
            buttonStartHard.TabIndex = 6;
            buttonStartHard.Text = "BEGIN - HARD";
            buttonStartHard.UseVisualStyleBackColor = false;
            buttonStartHard.Click += buttonStartHard_Click;
            // 
            // labelMenuText
            // 
            labelMenuText.AutoSize = true;
            labelMenuText.BackColor = Color.Black;
            labelMenuText.BorderStyle = BorderStyle.Fixed3D;
            labelMenuText.Font = new Font("Stencil", 44F, FontStyle.Bold, GraphicsUnit.Point);
            labelMenuText.ForeColor = Color.DarkRed;
            labelMenuText.Location = new Point(27, 23);
            labelMenuText.Margin = new Padding(5, 0, 5, 0);
            labelMenuText.Name = "labelMenuText";
            labelMenuText.Size = new Size(769, 106);
            labelMenuText.TabIndex = 8;
            labelMenuText.Text = "ZOMBIESHOOTER";
            // 
            // buttonStartNormal
            // 
            buttonStartNormal.BackColor = Color.Black;
            buttonStartNormal.Cursor = Cursors.Hand;
            buttonStartNormal.Font = new Font("Stencil", 22F, FontStyle.Regular, GraphicsUnit.Point);
            buttonStartNormal.ForeColor = Color.White;
            buttonStartNormal.Location = new Point(216, 253);
            buttonStartNormal.Margin = new Padding(6, 4, 6, 4);
            buttonStartNormal.Name = "buttonStartNormal";
            buttonStartNormal.Size = new Size(396, 69);
            buttonStartNormal.TabIndex = 9;
            buttonStartNormal.Text = "BEGIN - NORMAL";
            buttonStartNormal.UseVisualStyleBackColor = false;
            buttonStartNormal.Click += buttonStartNormal_Click;
            // 
            // labelHighscoreNormal
            // 
            labelHighscoreNormal.AutoSize = true;
            labelHighscoreNormal.BackColor = Color.Black;
            labelHighscoreNormal.BorderStyle = BorderStyle.Fixed3D;
            labelHighscoreNormal.Font = new Font("Stencil", 15F, FontStyle.Bold, GraphicsUnit.Point);
            labelHighscoreNormal.ForeColor = Color.White;
            labelHighscoreNormal.Location = new Point(301, 327);
            labelHighscoreNormal.Margin = new Padding(5, 0, 5, 0);
            labelHighscoreNormal.Name = "labelHighscoreNormal";
            labelHighscoreNormal.Size = new Size(207, 37);
            labelHighscoreNormal.TabIndex = 10;
            labelHighscoreNormal.Text = "HIGHSCORE:";
            // 
            // labelHighscoreHard
            // 
            labelHighscoreHard.AutoSize = true;
            labelHighscoreHard.BackColor = Color.Black;
            labelHighscoreHard.BorderStyle = BorderStyle.Fixed3D;
            labelHighscoreHard.Font = new Font("Stencil", 15F, FontStyle.Bold, GraphicsUnit.Point);
            labelHighscoreHard.ForeColor = Color.White;
            labelHighscoreHard.Location = new Point(301, 442);
            labelHighscoreHard.Margin = new Padding(5, 0, 5, 0);
            labelHighscoreHard.Name = "labelHighscoreHard";
            labelHighscoreHard.Size = new Size(207, 37);
            labelHighscoreHard.TabIndex = 11;
            labelHighscoreHard.Text = "HIGHSCORE:";
            // 
            // FormMenu
            // 
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(820, 487);
            Controls.Add(labelHighscoreHard);
            Controls.Add(labelHighscoreNormal);
            Controls.Add(buttonStartNormal);
            Controls.Add(labelMenuText);
            Controls.Add(buttonStartHard);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonStartHard;
        private Button buttonStartNormal;
        private Label labelHighscoreNormal;
        private Label labelHighscoreHard;
        private Label labelMenuText;

        public void UpdateHighscore()
        {
            labelHighscoreHard.Text = "HIGHSCORE: " + hardHigh;
            labelHighscoreNormal.Text = "HIGHSCORE: " + normalHigh;
        }

        private void buttonStartNormal_Click(object sender, EventArgs e)
        {
            new Form1(false, this).Show();
            this.Hide();
        }

        private void buttonStartHard_Click(object sender, EventArgs e)
        {
            new Form1(true, this).Show();
            this.Hide();
        }
    }
}




