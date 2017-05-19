using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrickBreaker;
using System.Media;

namespace BrickBreaker
{
    public partial class OptionScreen : UserControl
    {
        public static int difficulty = 0;
        int index = 0;
        int lastIndex = 0;
        public OptionScreen()
        {
            InitializeComponent();
            difficultyLabel.ForeColor = Color.Orange;
            difficultyLabel.Text = " -3 lives \n\n -Medium ball speed \n\n -medium paddle speed";
            acceptLabel.Text = " Click the 'Accept Button'\n to confirm difficulty";
            
                
            #region remembers previous difficulty
            if (difficulty == 1)
            {
                difficultyLabel.ForeColor = Color.Yellow;
                difficultyLabel.Text = " -5 lives \n\n -Slower ball speed \n\n -faster paddle speed ";
                easyButton.BackColor = Color.Yellow;
                mediumButton.BackColor = Color.White;
                hardButton.BackColor = Color.White;
                impossibleButton.BackColor = Color.White;
            }
            if (difficulty ==2)
            {
                difficultyLabel.ForeColor = Color.Orange;
                difficultyLabel.Text = " -3 lives \n\n -Medium ball speed \n\n -medium paddle speed";
                mediumButton.BackColor = Color.Orange;
                easyButton.BackColor = Color.White;
                hardButton.BackColor = Color.White;
                impossibleButton.BackColor = Color.White;
            }
            if (difficulty == 3)
            {
                difficultyLabel.ForeColor = Color.Red;
                difficultyLabel.Text = " -2 life \n\n -fast ball speed \n\n -slow paddle speed";
                hardButton.BackColor = Color.Red;
                easyButton.BackColor = Color.White;
                mediumButton.BackColor = Color.White;
                impossibleButton.BackColor = Color.White;
            }
            if (difficulty == 4)
            {
                difficultyLabel.ForeColor = Color.Purple;
                difficultyLabel.Text = " -1 life \n\n -fastest ball speed \n\n -slowest paddle speed";
                impossibleButton.BackColor = Color.Purple;
                easyButton.BackColor = Color.White;
                mediumButton.BackColor = Color.White;
                hardButton.BackColor = Color.White;
            }
            #endregion
        }
        #region select difficulty
        private void easyButton_Click(object sender, EventArgs e)
        {

            //play sound
            Form1.select.Stop();
            Form1.select.Play();
            difficultyLabel.Text = " -5 lives \n\n -Slower ball speed \n\n -faster paddle speed ";          
            difficultyLabel.ForeColor = Color.Yellow;


            easyButton.BackColor = Color.Yellow;
            mediumButton.BackColor = Color.White;
            hardButton.BackColor = Color.White;
            impossibleButton.BackColor = Color.White;
            difficulty = 1;
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {

            //play sound
            Form1.select.Stop();
            Form1.select.Play();

            difficultyLabel.Text = " -3 lives \n\n -Medium ball speed \n\n -medium paddle speed";
            

            difficultyLabel.ForeColor = Color.Orange;

            mediumButton.BackColor = Color.Orange;
            easyButton.BackColor = Color.White;
            hardButton.BackColor = Color.White;
            impossibleButton.BackColor = Color.White;
            difficulty = 2;

        }

        private void hardButton_Click(object sender, EventArgs e)
        {

            //play sound
            Form1.select.Stop();
            Form1.select.Play();

            difficultyLabel.ForeColor = Color.Red;
            difficultyLabel.Text = " -2 life \n\n -Fast ball speed \n\n -Slow paddle speed";

            hardButton.BackColor = Color.Red;
            easyButton.BackColor = Color.White;
            mediumButton.BackColor = Color.White;
            impossibleButton.BackColor = Color.White;
            difficulty = 3;
        }

        private void impossibleButton_Click(object sender, EventArgs e)
        {

            //play sound
            Form1.select.Stop();
            Form1.select.Play();

            difficultyLabel.ForeColor = Color.Purple;
            difficultyLabel.Text = " -1 life \n\n -Fastest ball speed \n\n -Slowest paddle speed";

            impossibleButton.BackColor = Color.Purple;
            easyButton.BackColor = Color.White;
            mediumButton.BackColor = Color.White;
            hardButton.BackColor = Color.White;
            
            difficulty = 4;
        }
        #endregion

        #region diffiulty methods
        public static void Easy()
        {
            Form1.lives = 5;
            Form1.paddleSpeed = 12;
            Form1.xSpeed = 4;
            Form1.ySpeed = 4;
        }
        public static void Medium()
        {
            Form1.lives = 3;
            Form1.paddleSpeed = 8;
            Form1.xSpeed = 6;
            Form1.ySpeed = 6;
        }
        public static void Hard()
        {
            Form1.lives = 2;
            Form1.paddleSpeed = 6;
            Form1.xSpeed = 8;
            Form1.ySpeed = 8;
        }
        public static void Impossible()
        {
            Form1.lives = 1;
            Form1.paddleSpeed = 4;
            Form1.xSpeed = 10;
            Form1.ySpeed = 10;
        }
        #endregion



        private void acceptButton_Click(object sender, EventArgs e)
        {   
            switch (difficulty)
            {
                case 0:
                    break;
                case 1:
                    
                    Easy();

                    break;
                case 2:
                    Medium();
                    break;
                case 3:
                    Hard();
                    break;
                case 4:
                    Impossible();
                    break;
            }

            Form f = this.FindForm();

            BrickBreaker.Screens.MenuScreen ms = new BrickBreaker.Screens.MenuScreen();

            f.Controls.Add(ms);
            f.Controls.Remove(this);

            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
        }

    
        
        private void OptionScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lastIndex = index;
            switch (lastIndex)
            {
                case 0:
                    easyButton.ForeColor = Color.White;
                    break;
                case 1:
                    mediumButton.ForeColor = Color.White;
                    break;
                case 2:
                    hardButton.ForeColor = Color.White;
                    break;
                case 3:
                    impossibleButton.ForeColor = Color.White;
                    break;
            }

            //set selected button to red
            switch (index)
            {
                case 0:
                    easyButton.ForeColor = Color.Red;
                    break;
                case 1:
                    mediumButton.ForeColor = Color.Red;
                    break;
                case 2:
                    hardButton.ForeColor = Color.Red;
                    break;
                case 3:
                    impossibleButton.ForeColor = Color.Red;
                    break;
            }
        }

        private void easyButton_Enter(object sender, EventArgs e)
        {
            if (difficulty != 1)
            {
                easyButton.BackColor = Color.Red;
            }
        }

        private void easyButton_Leave(object sender, EventArgs e)
        {
            if (difficulty != 1)
            {
                easyButton.BackColor = Color.White;
            }
        }

        private void mediumButton_Enter(object sender, EventArgs e)
        {
            if (difficulty != 2)
            {
                mediumButton.BackColor = Color.Red;
            }
        }

        private void mediumButton_Leave(object sender, EventArgs e)
        {
            if (difficulty != 2)
            {
                mediumButton.BackColor = Color.White;
            }
        }

        private void hardButton_Enter(object sender, EventArgs e)
        {
            if (difficulty != 3)
            {
                hardButton.BackColor = Color.Red;
            }
        }

        private void hardButton_Leave(object sender, EventArgs e)
        {
            if (difficulty != 3)
            {
                hardButton.BackColor = Color.White;
            }
        }

        private void impossibleButton_Enter(object sender, EventArgs e)
        {
            if (difficulty != 4)
            {
                impossibleButton.BackColor = Color.Red;
            }
        }

        private void impossibleButton_Leave(object sender, EventArgs e)
        {
            if (difficulty != 4)
            {
                impossibleButton.BackColor = Color.White;
            }
        }

        private void acceptButton_Enter(object sender, EventArgs e)
        {
            acceptButton.BackColor = Color.Red;
        }

        private void acceptButton_Leave(object sender, EventArgs e)
        {
            acceptButton.BackColor = Color.White;
        }
    }
}