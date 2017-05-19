using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrickBreaker.Screens;
//multiplayer lose screen by Daniel C
namespace BrickBreaker
{
    public partial class LoseScreenMulti : UserControl
    {
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown, vDown, bDown, nDown;

        int selected, lastSelected;

        int index, lastIndex;

        public LoseScreenMulti()
        {
            InitializeComponent();
            onStart();
        }

        public void onStart()
        {
            if (GameScreenMulti.player1Won)
            {
                winnerLabel.Text = "Player 1 wins";
            }
            if (GameScreenMulti.player2Won)
            {
                winnerLabel.Text = "Player 2 wins";
            }
        }

        private void LoseScreenMulti_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lastIndex = index;

            if (e.KeyCode == Keys.Escape)
            {
                MenuScreen ms = new MenuScreen();
                Form form = this.FindForm();

                form.Controls.Add(ms);
                form.Controls.Remove(this);

                ms.Location = new Point((form.Width - ms.Width) / 2, (form.Height - ms.Height) / 2);
            }

            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (index != 0)
                        index--;
                    else
                    {
                        index = 1;
                    }
                    break;
                case Keys.Left:
                    if (index != 1)
                        index++;
                    else
                    {
                        index = 0;
                    }
                    break;

                case Keys.Space:
                    switch (index)
                    {
                        case 0:
                            Form f = this.FindForm();
                            MenuScreen ms = new MenuScreen();

                            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);

                            f.Controls.Add(ms);
                            f.Controls.Remove(this);

                            break;
                        case 1:
                            Form form = this.FindForm();
                            GameScreenMulti gsm = new GameScreenMulti();

                            gsm.Location = new Point((form.Width - gsm.Width) / 2, (form.Height - gsm.Height) / 2);

                            form.Controls.Add(gsm);
                            form.Controls.Remove(this);

                            break;
                    }
                    break;
            }


            switch (lastIndex)
            {
                case 0:
                    returnToMenuLabel.ForeColor = Color.White;
                    break;
                case 1:
                    playAgainLabel.ForeColor = Color.White;
                    break;

            }

            switch (index)
            {
                case 0:
                    returnToMenuLabel.ForeColor = Color.Red;
                    break;
                case 1:
                    playAgainLabel.ForeColor = Color.Red;
                    break;
            }
        }
    }
}
