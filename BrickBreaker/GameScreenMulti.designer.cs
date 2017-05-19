namespace BrickBreaker
{
    partial class GameScreenMulti
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.hpLabelp2 = new System.Windows.Forms.Label();
            this.hpLabelp1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // hpLabelp2
            // 
            this.hpLabelp2.AutoSize = true;
            this.hpLabelp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hpLabelp2.ForeColor = System.Drawing.SystemColors.Control;
            this.hpLabelp2.Location = new System.Drawing.Point(365, 0);
            this.hpLabelp2.Name = "hpLabelp2";
            this.hpLabelp2.Size = new System.Drawing.Size(45, 16);
            this.hpLabelp2.TabIndex = 0;
            this.hpLabelp2.Text = "label1";
            // 
            // hpLabelp1
            // 
            this.hpLabelp1.AutoSize = true;
            this.hpLabelp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hpLabelp1.ForeColor = System.Drawing.SystemColors.Control;
            this.hpLabelp1.Location = new System.Drawing.Point(365, 534);
            this.hpLabelp1.Name = "hpLabelp1";
            this.hpLabelp1.Size = new System.Drawing.Size(45, 16);
            this.hpLabelp1.TabIndex = 1;
            this.hpLabelp1.Text = "label1";
            // 
            // GameScreenMulti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.hpLabelp1);
            this.Controls.Add(this.hpLabelp2);
            this.DoubleBuffered = true;
            this.Name = "GameScreenMulti";
            this.Size = new System.Drawing.Size(796, 550);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreenMulti_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreenMulti_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label hpLabelp2;
        private System.Windows.Forms.Label hpLabelp1;
    }
}
