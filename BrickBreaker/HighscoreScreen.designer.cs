namespace BrickBreaker.Screens
{
    partial class HighscoreScreen
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
            this.scoreTitle = new System.Windows.Forms.Label();
            this.top10Output = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scoreTitle
            // 
            this.scoreTitle.BackColor = System.Drawing.Color.Transparent;
            this.scoreTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.scoreTitle.Location = new System.Drawing.Point(198, 24);
            this.scoreTitle.Name = "scoreTitle";
            this.scoreTitle.Size = new System.Drawing.Size(410, 90);
            this.scoreTitle.TabIndex = 0;
            this.scoreTitle.Text = "High Scores";
            // 
            // top10Output
            // 
            this.top10Output.BackColor = System.Drawing.Color.Transparent;
            this.top10Output.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.top10Output.ForeColor = System.Drawing.Color.White;
            this.top10Output.Location = new System.Drawing.Point(109, 138);
            this.top10Output.Name = "top10Output";
            this.top10Output.Size = new System.Drawing.Size(582, 362);
            this.top10Output.TabIndex = 1;
            // 
            // HighscoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.mainScreenBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.top10Output);
            this.Controls.Add(this.scoreTitle);
            this.Name = "HighscoreScreen";
            this.Size = new System.Drawing.Size(800, 550);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HighscoreScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label scoreTitle;
        private System.Windows.Forms.Label top10Output;
    }
}
