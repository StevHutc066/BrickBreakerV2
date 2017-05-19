namespace BrickBreaker
{
    partial class LoseScreen
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
            this.nameText1 = new System.Windows.Forms.Label();
            this.nameText2 = new System.Windows.Forms.Label();
            this.nameText3 = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Label();
            this.scoreOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameText1
            // 
            this.nameText1.AutoSize = true;
            this.nameText1.BackColor = System.Drawing.Color.Transparent;
            this.nameText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameText1.ForeColor = System.Drawing.Color.Red;
            this.nameText1.Location = new System.Drawing.Point(231, 93);
            this.nameText1.Name = "nameText1";
            this.nameText1.Size = new System.Drawing.Size(109, 108);
            this.nameText1.TabIndex = 2;
            this.nameText1.Text = "A";
            this.nameText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameText2
            // 
            this.nameText2.AutoSize = true;
            this.nameText2.BackColor = System.Drawing.Color.Transparent;
            this.nameText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameText2.ForeColor = System.Drawing.Color.White;
            this.nameText2.Location = new System.Drawing.Point(346, 93);
            this.nameText2.Name = "nameText2";
            this.nameText2.Size = new System.Drawing.Size(109, 108);
            this.nameText2.TabIndex = 4;
            this.nameText2.Text = "A";
            this.nameText2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameText3
            // 
            this.nameText3.AutoSize = true;
            this.nameText3.BackColor = System.Drawing.Color.Transparent;
            this.nameText3.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameText3.ForeColor = System.Drawing.Color.White;
            this.nameText3.Location = new System.Drawing.Point(461, 93);
            this.nameText3.Name = "nameText3";
            this.nameText3.Size = new System.Drawing.Size(109, 108);
            this.nameText3.TabIndex = 5;
            this.nameText3.Text = "A";
            this.nameText3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuButton
            // 
            this.menuButton.AutoSize = true;
            this.menuButton.BackColor = System.Drawing.Color.Transparent;
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.ForeColor = System.Drawing.Color.White;
            this.menuButton.Location = new System.Drawing.Point(461, 446);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(262, 55);
            this.menuButton.TabIndex = 6;
            this.menuButton.Text = "Main Menu";
            // 
            // playButton
            // 
            this.playButton.AutoSize = true;
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.White;
            this.playButton.Location = new System.Drawing.Point(78, 446);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(253, 55);
            this.playButton.TabIndex = 7;
            this.playButton.Text = "Play Again";
            // 
            // scoreOutput
            // 
            this.scoreOutput.BackColor = System.Drawing.Color.Transparent;
            this.scoreOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreOutput.ForeColor = System.Drawing.Color.White;
            this.scoreOutput.Location = new System.Drawing.Point(3, 242);
            this.scoreOutput.Name = "scoreOutput";
            this.scoreOutput.Size = new System.Drawing.Size(794, 40);
            this.scoreOutput.TabIndex = 8;
            this.scoreOutput.Text = "You scored 0 points!";
            this.scoreOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.texture4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.scoreOutput);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.nameText3);
            this.Controls.Add(this.nameText2);
            this.Controls.Add(this.nameText1);
            this.DoubleBuffered = true;
            this.Name = "LoseScreen";
            this.Size = new System.Drawing.Size(800, 550);
            this.Load += new System.EventHandler(this.LoseScreen_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoseScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.LoseScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nameText1;
        private System.Windows.Forms.Label nameText2;
        private System.Windows.Forms.Label nameText3;
        private System.Windows.Forms.Label menuButton;
        private System.Windows.Forms.Label playButton;
        private System.Windows.Forms.Label scoreOutput;
    }
}
