namespace Sah
{
    partial class FormaPromocije
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaPromocije));
            this.Naslov_lb = new System.Windows.Forms.Label();
            this.ZaKraljicu_btn = new System.Windows.Forms.Button();
            this.ZaTopa_btn = new System.Windows.Forms.Button();
            this.ZaLovca_btn = new System.Windows.Forms.Button();
            this.ZaKonja_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Naslov_lb
            // 
            this.Naslov_lb.AutoSize = true;
            this.Naslov_lb.Font = new System.Drawing.Font("Monotype Corsiva", 20F);
            this.Naslov_lb.Location = new System.Drawing.Point(122, 10);
            this.Naslov_lb.Name = "Naslov_lb";
            this.Naslov_lb.Size = new System.Drawing.Size(410, 41);
            this.Naslov_lb.TabIndex = 0;
            this.Naslov_lb.Text = "LAW of CHESS PROMOTION";
            // 
            // ZaKraljicu_btn
            // 
            this.ZaKraljicu_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ZaKraljicu_btn.Location = new System.Drawing.Point(122, 182);
            this.ZaKraljicu_btn.Name = "ZaKraljicu_btn";
            this.ZaKraljicu_btn.Size = new System.Drawing.Size(104, 94);
            this.ZaKraljicu_btn.TabIndex = 1;
            this.ZaKraljicu_btn.TabStop = false;
            this.ZaKraljicu_btn.UseVisualStyleBackColor = true;
            this.ZaKraljicu_btn.Click += new System.EventHandler(this.ZaKraljicu_btn_Click_1);
            // 
            // ZaTopa_btn
            // 
            this.ZaTopa_btn.Location = new System.Drawing.Point(232, 182);
            this.ZaTopa_btn.Name = "ZaTopa_btn";
            this.ZaTopa_btn.Size = new System.Drawing.Size(104, 94);
            this.ZaTopa_btn.TabIndex = 2;
            this.ZaTopa_btn.TabStop = false;
            this.ZaTopa_btn.UseVisualStyleBackColor = true;
            this.ZaTopa_btn.Click += new System.EventHandler(this.ZaTopa_btn_Click);
            // 
            // ZaLovca_btn
            // 
            this.ZaLovca_btn.Location = new System.Drawing.Point(342, 182);
            this.ZaLovca_btn.Name = "ZaLovca_btn";
            this.ZaLovca_btn.Size = new System.Drawing.Size(104, 94);
            this.ZaLovca_btn.TabIndex = 3;
            this.ZaLovca_btn.TabStop = false;
            this.ZaLovca_btn.UseVisualStyleBackColor = true;
            this.ZaLovca_btn.Click += new System.EventHandler(this.ZaLovca_btn_Click);
            // 
            // ZaKonja_btn
            // 
            this.ZaKonja_btn.Location = new System.Drawing.Point(452, 182);
            this.ZaKonja_btn.Name = "ZaKonja_btn";
            this.ZaKonja_btn.Size = new System.Drawing.Size(104, 94);
            this.ZaKonja_btn.TabIndex = 4;
            this.ZaKonja_btn.TabStop = false;
            this.ZaKonja_btn.UseVisualStyleBackColor = true;
            this.ZaKonja_btn.Click += new System.EventHandler(this.ZaKonja_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 12F);
            this.label1.Location = new System.Drawing.Point(26, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(627, 48);
            this.label1.TabIndex = 5;
            this.label1.Text = "Promotion is not limited to pieces that have already been captured (Schiller 2003" +
    ":18–19).\r\n Every pawn that reaches its eighth rank must be promoted.";
            // 
            // FormaPromocije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(710, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ZaKonja_btn);
            this.Controls.Add(this.ZaLovca_btn);
            this.Controls.Add(this.ZaTopa_btn);
            this.Controls.Add(this.ZaKraljicu_btn);
            this.Controls.Add(this.Naslov_lb);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormaPromocije";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormaPromocije";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Naslov_lb;
        private System.Windows.Forms.Button ZaKraljicu_btn;
        private System.Windows.Forms.Button ZaTopa_btn;
        private System.Windows.Forms.Button ZaLovca_btn;
        private System.Windows.Forms.Button ZaKonja_btn;
        private System.Windows.Forms.Label label1;
    }
}