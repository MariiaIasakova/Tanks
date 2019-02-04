namespace Pacman
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.ctlStatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblX = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblValueX = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblY = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblValueY = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblValueScore = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctlScore = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctlPanel = new System.Windows.Forms.Panel();
            this.ctlStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlStatusStrip
            // 
            this.ctlStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctlStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblX,
            this.lblValueX,
            this.lblY,
            this.lblValueY,
            this.lblValueScore,
            this.ctlScore});
            this.ctlStatusStrip.Location = new System.Drawing.Point(0, 282);
            this.ctlStatusStrip.Name = "ctlStatusStrip";
            this.ctlStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ctlStatusStrip.Size = new System.Drawing.Size(835, 25);
            this.ctlStatusStrip.TabIndex = 1;
            this.ctlStatusStrip.Text = "X:";
            // 
            // lblX
            // 
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(21, 20);
            this.lblX.Text = "X:";
            // 
            // lblValueX
            // 
            this.lblValueX.Name = "lblValueX";
            this.lblValueX.Size = new System.Drawing.Size(13, 20);
            this.lblValueX.Text = " ";
            // 
            // lblY
            // 
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(20, 20);
            this.lblY.Text = "Y:";
            // 
            // lblValueY
            // 
            this.lblValueY.Name = "lblValueY";
            this.lblValueY.Size = new System.Drawing.Size(13, 20);
            this.lblValueY.Text = " ";
            // 
            // lblValueScore
            // 
            this.lblValueScore.Name = "lblValueScore";
            this.lblValueScore.Size = new System.Drawing.Size(57, 20);
            this.lblValueScore.Text = "Score:  ";
            // 
            // ctlScore
            // 
            this.ctlScore.Name = "ctlScore";
            this.ctlScore.Size = new System.Drawing.Size(13, 20);
            this.ctlScore.Text = " ";
            // 
            // ctlPanel
            // 
            this.ctlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctlPanel.Location = new System.Drawing.Point(0, 0);
            this.ctlPanel.Name = "ctlPanel";
            this.ctlPanel.Size = new System.Drawing.Size(835, 282);
            this.ctlPanel.TabIndex = 2;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(835, 307);
            this.Controls.Add(this.ctlPanel);
            this.Controls.Add(this.ctlStatusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameForm";
            this.Text = "Tanks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ctlStatusStrip.ResumeLayout(false);
            this.ctlStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip ctlStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblX;
        private System.Windows.Forms.ToolStripStatusLabel lblValueX;
        private System.Windows.Forms.ToolStripStatusLabel lblY;
        private System.Windows.Forms.ToolStripStatusLabel lblValueY;
        private System.Windows.Forms.ToolStripStatusLabel lblValueScore;
        private System.Windows.Forms.ToolStripStatusLabel ctlScore;
        private System.Windows.Forms.Panel ctlPanel;
    }
}