namespace BrickBreaker
{
    partial class LoseScreenMulti
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.winnerLabel = new System.Windows.Forms.Label();
            this.returnToMenuLabel = new System.Windows.Forms.Label();
            this.playAgainLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // winnerLabel
            // 
            this.winnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnerLabel.ForeColor = System.Drawing.Color.White;
            this.winnerLabel.Location = new System.Drawing.Point(3, 111);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(792, 108);
            this.winnerLabel.TabIndex = 0;
            this.winnerLabel.Text = "PLAYER 1 WINS";
            this.winnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // returnToMenuLabel
            // 
            this.returnToMenuLabel.AutoSize = true;
            this.returnToMenuLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.returnToMenuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnToMenuLabel.ForeColor = System.Drawing.Color.Red;
            this.returnToMenuLabel.Location = new System.Drawing.Point(142, 373);
            this.returnToMenuLabel.Name = "returnToMenuLabel";
            this.returnToMenuLabel.Size = new System.Drawing.Size(149, 55);
            this.returnToMenuLabel.TabIndex = 1;
            this.returnToMenuLabel.Text = "Menu";
            // 
            // playAgainLabel
            // 
            this.playAgainLabel.AutoSize = true;
            this.playAgainLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playAgainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAgainLabel.ForeColor = System.Drawing.Color.White;
            this.playAgainLabel.Location = new System.Drawing.Point(453, 373);
            this.playAgainLabel.Name = "playAgainLabel";
            this.playAgainLabel.Size = new System.Drawing.Size(258, 55);
            this.playAgainLabel.TabIndex = 2;
            this.playAgainLabel.Text = "Play again";
            // 
            // LoseScreenMulti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.playAgainLabel);
            this.Controls.Add(this.returnToMenuLabel);
            this.Controls.Add(this.winnerLabel);
            this.Name = "LoseScreenMulti";
            this.Size = new System.Drawing.Size(800, 550);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.LoseScreenMulti_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label winnerLabel;
        private System.Windows.Forms.Label returnToMenuLabel;
        private System.Windows.Forms.Label playAgainLabel;
    }
}
