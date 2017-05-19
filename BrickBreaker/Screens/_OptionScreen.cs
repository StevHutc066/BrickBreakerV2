using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperSnakeGame
{
    public partial class menuButton : UserControl
    {
        public static int difficulty = 0;
        
        public menuButton()
        {
            InitializeComponent();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            difficultyLabel.Text = " -5 lives \n\n -Slower ball speed \n\n -faster paddle speed ";
            easyButton.BackColor = Color.Yellow;
            mediumButton.BackColor = Color.White;
            hardButton.BackColor = Color.White;
            impossibleButton.BackColor = Color.White;
            difficulty = 1;
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            difficultyLabel.Text = " -3 lives \n\n -Medium ball speed \n\n -medium paddle speed";
            
            mediumButton.BackColor = Color.Orange;
            easyButton.BackColor = Color.White;
            hardButton.BackColor = Color.White;
            impossibleButton.BackColor = Color.White;
            difficulty = 2;
            
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
         
            difficultyLabel.Text = " -2 life \n\n -fast ball speed \n\n -slow paddle speed";
            hardButton.BackColor = Color.Red;
            easyButton.BackColor = Color.White;
            mediumButton.BackColor = Color.White;
            impossibleButton.BackColor = Color.White;
            difficulty = 3;
        }

        private void impossibleButton_Click(object sender, EventArgs e)
        {
            difficultyLabel.Text = " -1 life \n\n -fastest ball speed \n\n -slowest paddle speed";
            impossibleButton.BackColor = Color.Purple;
            easyButton.BackColor = Color.White;
            mediumButton.BackColor = Color.White;
            hardButton.BackColor = Color.White;
            
            difficulty = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            BrickBreaker.Screens.MenuScreen ms = new BrickBreaker.Screens.MenuScreen();
            f.Controls.Add(ms);
        }
        public static void Easy()
        {
            BrickBreaker.Screens.GameScreen.lives = 5;
            BrickBreaker.Screens.GameScreen.paddleSpeed = 12;
            BrickBreaker.Screens.GameScreen.xSpeed = 4;
            BrickBreaker.Screens.GameScreen.ySpeed = 4;
        }
        public static void Medium()
        {
            BrickBreaker.Screens.GameScreen.lives = 3;
            BrickBreaker.Screens.GameScreen.paddleSpeed = 8;
            BrickBreaker.Screens.GameScreen.xSpeed = 6;
            BrickBreaker.Screens.GameScreen.ySpeed = 6;
        }
        public static void Hard()
        {
            BrickBreaker.Screens.GameScreen.lives = 2;
            BrickBreaker.Screens.GameScreen.paddleSpeed = 6;
            BrickBreaker.Screens.GameScreen.xSpeed = 8;
            BrickBreaker.Screens.GameScreen.ySpeed = 8;
        }
        public static void Impossible()
        {
            BrickBreaker.Screens.GameScreen.lives = 1;
            BrickBreaker.Screens.GameScreen.paddleSpeed = 4;
            BrickBreaker.Screens.GameScreen.xSpeed = 10;
            BrickBreaker.Screens.GameScreen.ySpeed = 10;
        }


        private void acceptButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            BrickBreaker.Screens.MenuScreen ms = new BrickBreaker.Screens.MenuScreen();
            f.Controls.Add(ms);
        }

        
    }
}