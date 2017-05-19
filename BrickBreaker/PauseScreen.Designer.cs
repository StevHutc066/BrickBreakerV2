namespace BrickBreaker.Screens
{
    partial class PauseScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.yesLabel = new System.Windows.Forms.Label();
            this.noLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Kozuka Gothic Pro B", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(28, 47);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(242, 41);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "QUIT THE GAME?";
            // 
            // yesLabel
            // 
            this.yesLabel.AutoSize = true;
            this.yesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesLabel.ForeColor = System.Drawing.Color.Red;
            this.yesLabel.Location = new System.Drawing.Point(61, 105);
            this.yesLabel.Name = "yesLabel";
            this.yesLabel.Size = new System.Drawing.Size(64, 31);
            this.yesLabel.TabIndex = 3;
            this.yesLabel.Text = "Yes";
            // 
            // noLabel
            // 
            this.noLabel.AutoSize = true;
            this.noLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noLabel.ForeColor = System.Drawing.Color.Black;
            this.noLabel.Location = new System.Drawing.Point(165, 105);
            this.noLabel.Name = "noLabel";
            this.noLabel.Size = new System.Drawing.Size(51, 31);
            this.noLabel.TabIndex = 4;
            this.noLabel.Text = "No";
            // 
            // PauseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 163);
            this.Controls.Add(this.noLabel);
            this.Controls.Add(this.yesLabel);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PauseScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PauseScreen";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PauseScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label yesLabel;
        private System.Windows.Forms.Label noLabel;
    }
}