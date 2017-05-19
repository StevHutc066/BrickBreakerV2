using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//comment

namespace BrickBreaker.Screens
{
    public partial class PauseScreen : Form
    {
        int index = 0;
        int lastIndex = 0;
        public PauseScreen()
        {
            InitializeComponent();
        }

        static PauseScreen pause;
        static public DialogResult result;

        public static DialogResult Show(string Text, string btnYes, string btnNo)
        {
            pause = new PauseScreen();
            pause.titleLabel.Text = Text;
            pause.yesLabel.Text = btnYes;
            pause.noLabel.Text = btnNo;
            pause.ShowDialog();
            return result;
        }

        private void PauseScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lastIndex = index;
            Form form = this.FindForm();

            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        if (index != 0)
                        {
                            index--;
                        }

                        if (index == 0)
                        {
                            index = 2;
                        }
                        break;
                    }

                case Keys.Right:
                    {
                        if (index != 2)
                        {
                            index++;
                        }

                        else
                        {
                            index = 1;
                        }
                        break;
                    }


                //clicking on the screen with space key
                case Keys.Space:
                    switch (index)
                    {
                        //yes button

                        case 1:
                            result = DialogResult.No;
                            this.Close();
                            break;

                        //no button
                        case 2:
                            result = DialogResult.Yes;
                            this.Close();
                            break;
                    }
                    break;
            }

            //set button to white if not clicked on
            switch (lastIndex)
            {
                case 1:
                    noLabel.ForeColor = Color.Black;
                    break;
                case 2:
                    yesLabel.ForeColor = Color.Black;
                    break;
            }

            //set selected button to red
            switch (index)
            {
                case 1:
                    noLabel.ForeColor = Color.Red;
                    break;
                case 2:
                    yesLabel.ForeColor = Color.Red;
                    break;
            }
        }
    }
}
