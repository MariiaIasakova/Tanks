namespace Pacman
{
    partial class BegginerForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BegginerForm));
            this.ctl_panelBegginerForm = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblApples = new System.Windows.Forms.Label();
            this.lblGhost = new System.Windows.Forms.Label();
            this.ctlApples = new System.Windows.Forms.ComboBox();
            this.ctlSpeed = new System.Windows.Forms.ComboBox();
            this.ctlGhost = new System.Windows.Forms.ComboBox();
            this.ctl_panelBegginerForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctl_panelBegginerForm
            // 
            this.ctl_panelBegginerForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctl_panelBegginerForm.BackgroundImage")));
            this.ctl_panelBegginerForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctl_panelBegginerForm.Controls.Add(this.btnStart);
            this.ctl_panelBegginerForm.Controls.Add(this.lblSpeed);
            this.ctl_panelBegginerForm.Controls.Add(this.lblApples);
            this.ctl_panelBegginerForm.Controls.Add(this.lblGhost);
            this.ctl_panelBegginerForm.Controls.Add(this.ctlApples);
            this.ctl_panelBegginerForm.Controls.Add(this.ctlSpeed);
            this.ctl_panelBegginerForm.Controls.Add(this.ctlGhost);
            this.ctl_panelBegginerForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctl_panelBegginerForm.Location = new System.Drawing.Point(0, 0);
            this.ctl_panelBegginerForm.Name = "ctl_panelBegginerForm";
            this.ctl_panelBegginerForm.Size = new System.Drawing.Size(634, 412);
            this.ctl_panelBegginerForm.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStart.Location = new System.Drawing.Point(421, 338);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(121, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSpeed.Location = new System.Drawing.Point(355, 318);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(38, 13);
            this.lblSpeed.TabIndex = 0;
            this.lblSpeed.Text = "Speed";
            // 
            // lblApples
            // 
            this.lblApples.AutoSize = true;
            this.lblApples.BackColor = System.Drawing.Color.Transparent;
            this.lblApples.ForeColor = System.Drawing.SystemColors.Control;
            this.lblApples.Location = new System.Drawing.Point(79, 346);
            this.lblApples.Name = "lblApples";
            this.lblApples.Size = new System.Drawing.Size(39, 13);
            this.lblApples.TabIndex = 0;
            this.lblApples.Text = "Apples";
            // 
            // lblGhost
            // 
            this.lblGhost.AutoSize = true;
            this.lblGhost.BackColor = System.Drawing.Color.Transparent;
            this.lblGhost.ForeColor = System.Drawing.SystemColors.Control;
            this.lblGhost.Location = new System.Drawing.Point(79, 314);
            this.lblGhost.Name = "lblGhost";
            this.lblGhost.Size = new System.Drawing.Size(40, 13);
            this.lblGhost.TabIndex = 0;
            this.lblGhost.Text = "Ghosts";
            // 
            // ctlApples
            // 
            this.ctlApples.FormattingEnabled = true;
            this.ctlApples.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.ctlApples.Location = new System.Drawing.Point(164, 338);
            this.ctlApples.Name = "ctlApples";
            this.ctlApples.Size = new System.Drawing.Size(121, 21);
            this.ctlApples.TabIndex = 2;
            // 
            // ctlSpeed
            // 
            this.ctlSpeed.FormattingEnabled = true;
            this.ctlSpeed.Location = new System.Drawing.Point(421, 311);
            this.ctlSpeed.Name = "ctlSpeed";
            this.ctlSpeed.Size = new System.Drawing.Size(121, 21);
            this.ctlSpeed.TabIndex = 3;
            // 
            // ctlGhost
            // 
            this.ctlGhost.FormattingEnabled = true;
            this.ctlGhost.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.ctlGhost.Location = new System.Drawing.Point(164, 311);
            this.ctlGhost.Name = "ctlGhost";
            this.ctlGhost.Size = new System.Drawing.Size(121, 21);
            this.ctlGhost.TabIndex = 1;
            // 
            // BegginerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 412);
            this.Controls.Add(this.ctl_panelBegginerForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(650, 450);
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "BegginerForm";
            this.Text = "Pacman";
            this.ctl_panelBegginerForm.ResumeLayout(false);
            this.ctl_panelBegginerForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ctl_panelBegginerForm;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblApples;
        private System.Windows.Forms.Label lblGhost;
        private System.Windows.Forms.ComboBox ctlApples;
        private System.Windows.Forms.ComboBox ctlSpeed;
        private System.Windows.Forms.ComboBox ctlGhost;
        private System.Windows.Forms.Button btnStart;
    }
}

