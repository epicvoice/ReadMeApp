namespace Rejestracja_użytkownika
{
    partial class Rejestracja
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.text_Name = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Text_sName = new System.Windows.Forms.TextBox();
            this.text_eMail = new System.Windows.Forms.TextBox();
            this.text_password = new System.Windows.Forms.TextBox();
            this.Zapisz = new System.Windows.Forms.Button();
            this.text_repPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_TypeUser = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text_Name
            // 
            this.text_Name.Location = new System.Drawing.Point(267, 102);
            this.text_Name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_Name.Name = "text_Name";
            this.text_Name.Size = new System.Drawing.Size(218, 20);
            this.text_Name.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(197, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Imię";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(187, 173);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "E-Mail";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(187, 212);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hasło ";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(167, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nazwisko";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(184, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(324, 70);
            this.label5.TabIndex = 11;
            this.label5.Text = "Rejestracja";
            // 
            // Text_sName
            // 
            this.Text_sName.Location = new System.Drawing.Point(267, 141);
            this.Text_sName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Text_sName.Name = "Text_sName";
            this.Text_sName.Size = new System.Drawing.Size(218, 20);
            this.Text_sName.TabIndex = 12;
            // 
            // text_eMail
            // 
            this.text_eMail.Location = new System.Drawing.Point(267, 176);
            this.text_eMail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_eMail.Name = "text_eMail";
            this.text_eMail.Size = new System.Drawing.Size(218, 20);
            this.text_eMail.TabIndex = 13;
            // 
            // text_password
            // 
            this.text_password.Location = new System.Drawing.Point(267, 212);
            this.text_password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_password.Name = "text_password";
            this.text_password.Size = new System.Drawing.Size(218, 20);
            this.text_password.TabIndex = 14;
            // 
            // Zapisz
            // 
            this.Zapisz.Location = new System.Drawing.Point(434, 311);
            this.Zapisz.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Zapisz.Name = "Zapisz";
            this.Zapisz.Size = new System.Drawing.Size(155, 44);
            this.Zapisz.TabIndex = 5;
            this.Zapisz.Text = "Zapisz";
            this.Zapisz.UseVisualStyleBackColor = true;
            this.Zapisz.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_repPass
            // 
            this.text_repPass.Location = new System.Drawing.Point(267, 249);
            this.text_repPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_repPass.Name = "text_repPass";
            this.text_repPass.Size = new System.Drawing.Size(218, 20);
            this.text_repPass.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(141, 246);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Powtórz hasło";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // comboBox_TypeUser
            // 
            this.comboBox_TypeUser.FormattingEnabled = true;
            this.comboBox_TypeUser.Location = new System.Drawing.Point(267, 275);
            this.comboBox_TypeUser.Name = "comboBox_TypeUser";
            this.comboBox_TypeUser.Size = new System.Drawing.Size(121, 21);
            this.comboBox_TypeUser.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(136, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Typ użytkownika";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Rejestracja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_TypeUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.text_repPass);
            this.Controls.Add(this.text_password);
            this.Controls.Add(this.text_eMail);
            this.Controls.Add(this.Text_sName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Zapisz);
            this.Controls.Add(this.text_Name);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Rejestracja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_Name;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Text_sName;
        private System.Windows.Forms.TextBox text_eMail;
        private System.Windows.Forms.TextBox text_password;
        private System.Windows.Forms.Button Zapisz;
        private System.Windows.Forms.TextBox text_repPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_TypeUser;
        private System.Windows.Forms.Label label7;
    }
}

