using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BrickBreaker.Screens
{
    public partial class MenuScreen : UserControl
    {
        //indexs for the button clicks
        int index = 0;
        int lastIndex = 0;

        public MenuScreen()
        {
            InitializeComponent();
            OnStart();
        }
        
        //added by mr. t
        public void OnStart()
        {
            Form1.backroundMusic.Stop();
            Form1.backroundMusic.Play();
        }

        private void MenuScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lastIndex = index;
            Form form = this.FindForm();
            //to make sure that if you click to the bottom or top you will go to the other end instead of just stopping
            switch (e.KeyCode)
            {
                case Keys.Up:
                    
                    //play sound
                    Form1.pick.Stop();
                    Form1.pick.Play();

                    if (index != 0)
                        index--;
                    else
                    {
                        index = 3;
                    }
                    break;
                case Keys.Down:

                    //play sound
                    Form1.pick.Stop();
                    Form1.pick.Play();

                    if (index != 3)
                        index++;
                    else
                    {
                        index = 0;
                    }
                    break;

                //clicking on the screen with space key
                case Keys.Space:
                    switch (index)
                    {
                        //start button
                        case 0:

                            //play sound
                            Form1.select.Stop();
                            Form1.select.Play();


                            InstructionScreen si = new InstructionScreen();
                            si.Location = new Point((form.Width - si.Width) / 2, (form.Height - si.Height) / 2);

                            form.Controls.Add(si);
                            form.Controls.Remove(this);

                            break;

                        //highscore button
                        case 1:

                            //play sound
                            Form1.select.Stop();
                            Form1.select.Play();

                            HighscoreScreen hs = new HighscoreScreen();
                            form.Controls.Add(hs);
                            form.Controls.Remove(this);

                            hs.Location = new Point((form.Width - hs.Width) / 2, (form.Height - hs.Height) / 2);

                            break;

                        //option button
                        case 2:

                            //play sound
                            Form1.select.Stop();
                            Form1.select.Play();

                            OptionScreen os = new OptionScreen();

                            form.Controls.Add(os);
                            form.Controls.Remove(this);

                            os.Location = new Point((form.Width - os.Width) / 2, (form.Height - os.Height) / 2);
                            break;

                        //exit button
                        case 3:

                            //play sound
                            Form1.gameOver.Stop();
                            Form1.gameOver.Play();
                            Thread.Sleep(1000);

                            Application.Exit();
                            break;
                    }
                    break;
            }

            //set button to white if not clicked on
            switch (lastIndex)
            {
                case 0:
                    startLabel.ForeColor = Color.White;
                    break;
                case 1:
                    highScoreLabel.ForeColor = Color.White;
                    break;
                case 2:
                    optionLabel.ForeColor = Color.White;
                    break;
                case 3:
                    exitLabel.ForeColor = Color.White;
                    break;
            }

            //set selected button to red
            switch (index)
            {
                case 0:
                    startLabel.ForeColor = Color.Red;
                    break;
                case 1:
                    highScoreLabel.ForeColor = Color.Red;
                    break;
                case 2:
                    optionLabel.ForeColor = Color.Red;
                    break;
                case 3:
                    exitLabel.ForeColor = Color.Red;
                    break;
            }
        }

        private void optionLabel_Click(object sender, EventArgs e)
        {
            BrickBreaker.OptionScreen os = new BrickBreaker.OptionScreen();
            Form form = this.FindForm();

            form.Controls.Add(os);
            form.Controls.Remove(this);

        }
    }
}
