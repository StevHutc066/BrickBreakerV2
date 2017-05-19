
//Copy of brick breaker game
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrickBreaker.Screens;
using System.Xml;
using System.Media;
using BrickBreaker;
using System.IO;

/// <summary>
///  Long paddle 
///  More balls
///  Backup floor
///  additional life
///  double point
///  isMagnet
/// strongball
/// another comment   
/// another comment again
/// </summary>
namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        // add a global value here

        //static menu sound library       
        public static SoundPlayer appearPlayer = new SoundPlayer(Properties.Resources.Alert_Appear);
        public static SoundPlayer back_A_Player = new SoundPlayer(Properties.Resources.Back_A);
        public static SoundPlayer back_B_Player = new SoundPlayer(Properties.Resources.Back_B);

        //dynamic sound library
        public static System.Windows.Media.MediaPlayer powerUp;
        public static System.Windows.Media.MediaPlayer brickBounce;
        public static System.Windows.Media.MediaPlayer paddleBounce;
        public static System.Windows.Media.MediaPlayer wallBounce;
        public static System.Windows.Media.MediaPlayer pick;
        public static System.Windows.Media.MediaPlayer gameOver;
        public static System.Windows.Media.MediaPlayer backroundMusic;
        public static System.Windows.Media.MediaPlayer select;
        public static System.Windows.Media.MediaPlayer levelpassed;

        //public static SoundPlayer player = new SoundPlayer(Properties.)

        public static List<Highscore> highscoreList = new List<Highscore>();
        public static int currentScore, paddleSpeed, lives, xSpeed, ySpeed;
       

        // add a new comment

        //test comment

        public Form1()
        {
            InitializeComponent();

            if (BrickBreaker.OptionScreen.difficulty == 0) {
                lives = 3;
                paddleSpeed = 10;
                xSpeed = ySpeed = 6;
            }

            powerUp = new System.Windows.Media.MediaPlayer();
            powerUp.Open(new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources/Select_A.wav")));
            powerUp.Volume = 1;

            brickBounce = new System.Windows.Media.MediaPlayer();
            brickBounce.Open(new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources/brickBounce.wav")));
            brickBounce.Volume = 1;

            paddleBounce = new System.Windows.Media.MediaPlayer();
            paddleBounce.Open(new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources/paddleBounce.wav")));
            paddleBounce.Volume = 1;

            gameOver = new System.Windows.Media.MediaPlayer();
            gameOver.Open(new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources/Alert_Error.wav")));
            gameOver.Volume = 1;

            wallBounce = new System.Windows.Media.MediaPlayer();
            wallBounce.Open(new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources/wallBounce.wav")));
            wallBounce.Volume = 1;

            pick = new System.Windows.Media.MediaPlayer();
            pick.Open(new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources/Pick.wav")));
            pick.Volume = 1;

            backroundMusic = new System.Windows.Media.MediaPlayer();
            backroundMusic.Open(new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources/backroundmusic.mp3")));
            backroundMusic.Volume = 1;

            select = new System.Windows.Media.MediaPlayer();
            select.Open(new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources/Select_B.wav")));
            select.Volume = 1;

            levelpassed = new System.Windows.Media.MediaPlayer();
            levelpassed.Open(new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources/Alert_Dissappear.wav")));
            levelpassed.Volume = 1;




        }


        public static PictureBox heartImage1 = new PictureBox();
        public static PictureBox heartImage2 = new PictureBox();
        public static PictureBox heartImage3 = new PictureBox();
        public static PictureBox heartImage4 = new PictureBox();
        public static PictureBox heartImage5 = new PictureBox();
        public static Label levelLabel = new Label();
        public static Label scoreLabel = new Label();



        private void pictureBoxes(PictureBox x)
        {
            Controls.Add(x);
            x.Size = new Size(50, 45);
            x.BackColor = Color.White;
            x.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void labels (Label x)
        {
            Controls.Add(x);
            x.Font = new Font("Kozuka Gothic Pro", 20, FontStyle.Bold);
            x.Size = new Size(400, 40);
            x.BackColor = Color.Transparent;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            labels(levelLabel);
            labels(scoreLabel);
            levelLabel.Location = new Point(960, 670);
            scoreLabel.Location = new Point(800, 60);

            pictureBoxes(heartImage1);
            pictureBoxes(heartImage2);
            pictureBoxes(heartImage3);
            pictureBoxes(heartImage4);
            pictureBoxes(heartImage5);

            heartImage1.Location = new Point(300, 55);
            heartImage2.Location = new Point(360, 55);
            heartImage3.Location = new Point(420, 55);
            heartImage4.Location = new Point(480, 55);
            heartImage5.Location = new Point(540, 55);


            // Start the program centred on the Menu Screen
            MenuScreen ps = new MenuScreen();
            this.Controls.Add(ps);
            
            ps.Location = new Point((this.Width - ps.Width) / 2, (this.Height - ps.Height) /2);
            loadHighscores();
        }

        private void loadHighscores() //method for loading any saved highscores in the highscoreDB xml file
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("highscoreDB.xml");

            XmlNode parent;
            parent = doc.DocumentElement;
            foreach (XmlNode child in parent.ChildNodes)
            {
                Highscore hs = new Highscore(null, null, null);
                foreach (XmlNode grandChild in child.ChildNodes)
                {
                    if (grandChild.Name == "name")
                    {
                        hs.name = grandChild.InnerText;
                    }
                    if (grandChild.Name == "level")
                    {
                        hs.level = grandChild.InnerText;
                    }
                    if (grandChild.Name == "score")
                    {
                        hs.score = grandChild.InnerText;
                    }
                }
                highscoreList.Add(hs);
            }
        }

        SolidBrush boxBrush = new SolidBrush(Color.White);
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           e.Graphics.FillRectangle(boxBrush, (this.Width - 925) / 2, (this.Height - 675) /2, 925,675);
        }
    }
}
