namespace Sah
{
    partial class WinnerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinnerForm));
            this.Ghost_lb = new System.Windows.Forms.Label();
            this.Play_Again_btn = new System.Windows.Forms.Button();
            this.Izadji_btn = new System.Windows.Forms.Button();
            this.Pobednik_lb = new System.Windows.Forms.Label();
            this.NaslovZavrsetka_lb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Ghost_lb
            // 
            this.Ghost_lb.AutoSize = true;
            this.Ghost_lb.BackColor = System.Drawing.SystemColors.Control;
            this.Ghost_lb.Font = new System.Drawing.Font("Monotype Corsiva", 20F);
            this.Ghost_lb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Ghost_lb.Location = new System.Drawing.Point(58, 178);
            this.Ghost_lb.Name = "Ghost_lb";
            this.Ghost_lb.Size = new System.Drawing.Size(499, 369);
            this.Ghost_lb.TabIndex = 0;
            this.Ghost_lb.Text = "WOWWWW  UR  SOO GOOOD!!   :O\r\n\r\n     .-\"\"\"\"-.\r\n    / -   - \\\r\n  |  .-. .- |\r\n  | " +
    " \\o| |o \r\n   \\     ^    \\\r\n   |\'.  )--\'  /|\r\n  / / \'-. .-\'`\\ \\\r\n";
            // 
            // Play_Again_btn
            // 
            this.Play_Again_btn.Font = new System.Drawing.Font("Monotype Corsiva", 10F);
            this.Play_Again_btn.Location = new System.Drawing.Point(12, 35);
            this.Play_Again_btn.Name = "Play_Again_btn";
            this.Play_Again_btn.Size = new System.Drawing.Size(163, 54);
            this.Play_Again_btn.TabIndex = 1;
            this.Play_Again_btn.TabStop = false;
            this.Play_Again_btn.Text = "Play Another Game";
            this.Play_Again_btn.UseVisualStyleBackColor = true;
            this.Play_Again_btn.Click += new System.EventHandler(this.Play_Again_btn_Click);
            // 
            // Izadji_btn
            // 
            this.Izadji_btn.Font = new System.Drawing.Font("Monotype Corsiva", 10F);
            this.Izadji_btn.Location = new System.Drawing.Point(512, 36);
            this.Izadji_btn.Name = "Izadji_btn";
            this.Izadji_btn.Size = new System.Drawing.Size(164, 53);
            this.Izadji_btn.TabIndex = 2;
            this.Izadji_btn.TabStop = false;
            this.Izadji_btn.Text = "Enough for today";
            this.Izadji_btn.UseVisualStyleBackColor = true;
            this.Izadji_btn.Click += new System.EventHandler(this.Izadji_btn_Click);
            // 
            // Pobednik_lb
            // 
            this.Pobednik_lb.AutoSize = true;
            this.Pobednik_lb.Font = new System.Drawing.Font("Monotype Corsiva", 20F);
            this.Pobednik_lb.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Pobednik_lb.Location = new System.Drawing.Point(58, 112);
            this.Pobednik_lb.Name = "Pobednik_lb";
            this.Pobednik_lb.Size = new System.Drawing.Size(117, 41);
            this.Pobednik_lb.TabIndex = 3;
            this.Pobednik_lb.Text = "Hii ^_^";
            // 
            // NaslovZavrsetka_lb
            // 
            this.NaslovZavrsetka_lb.AutoSize = true;
            this.NaslovZavrsetka_lb.Font = new System.Drawing.Font("Monotype Corsiva", 20F);
            this.NaslovZavrsetka_lb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NaslovZavrsetka_lb.Location = new System.Drawing.Point(241, 37);
            this.NaslovZavrsetka_lb.Name = "NaslovZavrsetka_lb";
            this.NaslovZavrsetka_lb.Size = new System.Drawing.Size(96, 41);
            this.NaslovZavrsetka_lb.TabIndex = 4;
            this.NaslovZavrsetka_lb.Text = "naslov";
            // 
            // WinnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(688, 547);
            this.Controls.Add(this.NaslovZavrsetka_lb);
            this.Controls.Add(this.Pobednik_lb);
            this.Controls.Add(this.Izadji_btn);
            this.Controls.Add(this.Play_Again_btn);
            this.Controls.Add(this.Ghost_lb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WinnerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WinnerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Ghost_lb;
        private System.Windows.Forms.Button Play_Again_btn;
        private System.Windows.Forms.Button Izadji_btn;
        private System.Windows.Forms.Label Pobednik_lb;
        private System.Windows.Forms.Label NaslovZavrsetka_lb;
    }
}