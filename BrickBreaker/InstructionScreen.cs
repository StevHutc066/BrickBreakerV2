using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker.Screens
{
    public partial class InstructionScreen : UserControl
    {

        int index = 0;
        int lastIndex = 0;

        public InstructionScreen()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void InstructionScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lastIndex = index;

            if (e.KeyCode == Keys.Escape)
            {
                //play sound
                Form1.pick.Stop();
                Form1.pick.Play();

                MenuScreen ms = new MenuScreen();
                Form form = this.FindForm();

                form.Controls.Add(ms);
                form.Controls.Remove(this);

                ms.Location = new Point((form.Width - ms.Width) / 2, (form.Height - ms.Height) / 2);
            }

            //so you can select the options by going left and right
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

                    //so you can select the option that is selected
                case Keys.Space:
                    switch (index)
                    {
                        case 0:
                            //play sound
                            Form1.select.Stop();
                            Form1.select.Play();

                            GameScreen gs = new GameScreen();
                            Form form = this.FindForm();

                            form.Controls.Add(gs);
                            form.Controls.Remove(this);

                            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
                            break;
                        case 1:

                            //play sound
                            Form1.select.Stop();
                            Form1.select.Play();

                            //multiplayer screen but for now it is exit
                            GameScreenMulti gsm = new GameScreenMulti();
                            Form f = this.FindForm();

                            f.Controls.Add(gsm);
                            f.Controls.Remove(this);

                            gsm.Location = new Point((f.Width - gsm.Width) / 2, (f.Height - gsm.Height) / 2);
                            break;
                            
                    }
                break;                 
            }

            //sets labels color to white if not selected
            switch(lastIndex)
            {
                case 0:
                    onePlayerLabel.ForeColor = Color.White;
                    break;
                case 1:
                    secondPlayerLabel.ForeColor = Color.White;
                    break;
            }

            //sets labels color to red if selected    
            switch(index)
            {
                case 0:
                    onePlayerLabel.ForeColor = Color.Red;
                    break;
                case 1:
                    secondPlayerLabel.ForeColor = Color.Red;
                    break;
            }
        }
    }
}
