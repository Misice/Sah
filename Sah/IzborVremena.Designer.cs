namespace Sah
{
    partial class IzborVremena
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
            this.label1 = new System.Windows.Forms.Label();
            this.Competitive_btn = new System.Windows.Forms.Button();
            this.Classic_btn = new System.Windows.Forms.Button();
            this.Exit_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14F);
            this.label1.Location = new System.Drawing.Point(229, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please choose your PLAYSTYLE";
            // 
            // Competitive_btn
            // 
            this.Competitive_btn.Font = new System.Drawing.Font("Monotype Corsiva", 12F);
            this.Competitive_btn.Location = new System.Drawing.Point(183, 110);
            this.Competitive_btn.Name = "Competitive_btn";
            this.Competitive_btn.Size = new System.Drawing.Size(127, 52);
            this.Competitive_btn.TabIndex = 1;
            this.Competitive_btn.TabStop = false;
            this.Competitive_btn.Text = "Competitive";
            this.Competitive_btn.UseVisualStyleBackColor = true;
            this.Competitive_btn.Click += new System.EventHandler(this.Competitive_btn_Click);
            // 
            // Classic_btn
            // 
            this.Classic_btn.Font = new System.Drawing.Font("Monotype Corsiva", 12F);
            this.Classic_btn.Location = new System.Drawing.Point(419, 110);
            this.Classic_btn.Name = "Classic_btn";
            this.Classic_btn.Size = new System.Drawing.Size(127, 52);
            this.Classic_btn.TabIndex = 2;
            this.Classic_btn.TabStop = false;
            this.Classic_btn.Text = "Classic";
            this.Classic_btn.UseVisualStyleBackColor = true;
            this.Classic_btn.Click += new System.EventHandler(this.Classic_btn_Click);
            // 
            // Exit_btn
            // 
            this.Exit_btn.Font = new System.Drawing.Font("Monotype Corsiva", 12F);
            this.Exit_btn.Location = new System.Drawing.Point(613, 165);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(149, 39);
            this.Exit_btn.TabIndex = 3;
            this.Exit_btn.TabStop = false;
            this.Exit_btn.Text = "Exit The Game";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 12F);
            this.label2.Location = new System.Drawing.Point(204, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "3 minutes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 12F);
            this.label3.Location = new System.Drawing.Point(436, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "15 minutes";
            // 
            // IzborVremena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(774, 216);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Classic_btn);
            this.Controls.Add(this.Competitive_btn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IzborVremena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WELCOME";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Competitive_btn;
        private System.Windows.Forms.Button Classic_btn;
        private System.Windows.Forms.Button Exit_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}