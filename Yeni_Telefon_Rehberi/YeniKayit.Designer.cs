namespace Yeni_Telefon_Rehberi
{
    partial class YeniKayit
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
            this.button1 = new System.Windows.Forms.Button();
            this.yeniadrestxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.yeniteltxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.yenisoytxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.yeniisimtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(286, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // yeniadrestxt
            // 
            this.yeniadrestxt.Location = new System.Drawing.Point(82, 103);
            this.yeniadrestxt.Multiline = true;
            this.yeniadrestxt.Name = "yeniadrestxt";
            this.yeniadrestxt.Size = new System.Drawing.Size(169, 58);
            this.yeniadrestxt.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(33, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 45;
            this.label5.Text = "Adres";
            // 
            // yeniteltxt
            // 
            this.yeniteltxt.Location = new System.Drawing.Point(82, 77);
            this.yeniteltxt.Name = "yeniteltxt";
            this.yeniteltxt.Size = new System.Drawing.Size(169, 20);
            this.yeniteltxt.TabIndex = 44;
            this.yeniteltxt.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(33, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 43;
            this.label4.Text = "Telefon";
            // 
            // yenisoytxt
            // 
            this.yenisoytxt.Location = new System.Drawing.Point(82, 51);
            this.yenisoytxt.Name = "yenisoytxt";
            this.yenisoytxt.Size = new System.Drawing.Size(169, 20);
            this.yenisoytxt.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(33, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 41;
            this.label3.Text = "Soyisim";
            // 
            // yeniisimtxt
            // 
            this.yeniisimtxt.Location = new System.Drawing.Point(82, 25);
            this.yeniisimtxt.Name = "yeniisimtxt";
            this.yeniisimtxt.Size = new System.Drawing.Size(169, 20);
            this.yeniisimtxt.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(33, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "İsim";
            // 
            // YeniKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(379, 202);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.yeniadrestxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.yeniteltxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yenisoytxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yeniisimtxt);
            this.Controls.Add(this.label2);
            this.Name = "YeniKayit";
            this.Text = "YENİ KİŞİ OLUŞTUR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox yeniadrestxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox yeniteltxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox yenisoytxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox yeniisimtxt;
        private System.Windows.Forms.Label label2;
    }
}