
namespace PodkladexApp.Zaopatrzenie
{
    partial class Form_Zamowienie
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
            textBox_Nazwisko = new TextBox();
            button_Klient_prywatny = new Button();
            button_klient_z_firmy = new Button();
            panel1 = new Panel();
            textBox_email = new TextBox();
            textBox_Numer_telefonu = new TextBox();
            textBox_imie = new TextBox();
            textBox_Miejscowosc = new TextBox();
            textBox_kod_pocztowy = new TextBox();
            textBox_ulica = new TextBox();
            textBox_numer = new TextBox();
            textBox_PESEL = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_Nazwisko
            // 
            textBox_Nazwisko.Location = new Point(51, 108);
            textBox_Nazwisko.Name = "textBox_Nazwisko";
            textBox_Nazwisko.Size = new Size(100, 23);
            textBox_Nazwisko.TabIndex = 0;
            textBox_Nazwisko.TextChanged += textBox_Nazwisko_TextChanged;
            // 
            // button_Klient_prywatny
            // 
            button_Klient_prywatny.Location = new Point(171, 48);
            button_Klient_prywatny.Name = "button_Klient_prywatny";
            button_Klient_prywatny.Size = new Size(121, 23);
            button_Klient_prywatny.TabIndex = 1;
            button_Klient_prywatny.Text = "Klient prywatny";
            button_Klient_prywatny.UseVisualStyleBackColor = true;
            // 
            // button_klient_z_firmy
            // 
            button_klient_z_firmy.Location = new Point(457, 48);
            button_klient_z_firmy.Name = "button_klient_z_firmy";
            button_klient_z_firmy.Size = new Size(121, 23);
            button_klient_z_firmy.TabIndex = 2;
            button_klient_z_firmy.Text = "Firma";
            button_klient_z_firmy.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox_PESEL);
            panel1.Controls.Add(textBox_numer);
            panel1.Controls.Add(textBox_ulica);
            panel1.Controls.Add(textBox_kod_pocztowy);
            panel1.Controls.Add(textBox_Miejscowosc);
            panel1.Controls.Add(textBox_email);
            panel1.Controls.Add(textBox_Numer_telefonu);
            panel1.Controls.Add(textBox_imie);
            panel1.Controls.Add(textBox_Nazwisko);
            panel1.Location = new Point(126, 154);
            panel1.Name = "panel1";
            panel1.Size = new Size(651, 494);
            panel1.TabIndex = 3;
            panel1.Paint += this.panel1_Paint;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(51, 225);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(100, 23);
            textBox_email.TabIndex = 3;
            // 
            // textBox_Numer_telefonu
            // 
            textBox_Numer_telefonu.Location = new Point(51, 169);
            textBox_Numer_telefonu.Name = "textBox_Numer_telefonu";
            textBox_Numer_telefonu.Size = new Size(100, 23);
            textBox_Numer_telefonu.TabIndex = 2;
            // 
            // textBox_imie
            // 
            textBox_imie.Location = new Point(51, 44);
            textBox_imie.Name = "textBox_imie";
            textBox_imie.Size = new Size(100, 23);
            textBox_imie.TabIndex = 1;
            // 
            // textBox_Miejscowosc
            // 
            textBox_Miejscowosc.Location = new Point(51, 282);
            textBox_Miejscowosc.Name = "textBox_Miejscowosc";
            textBox_Miejscowosc.Size = new Size(100, 23);
            textBox_Miejscowosc.TabIndex = 4;
            // 
            // textBox_kod_pocztowy
            // 
            textBox_kod_pocztowy.Location = new Point(51, 343);
            textBox_kod_pocztowy.Name = "textBox_kod_pocztowy";
            textBox_kod_pocztowy.Size = new Size(100, 23);
            textBox_kod_pocztowy.TabIndex = 5;
            // 
            // textBox_ulica
            // 
            textBox_ulica.Location = new Point(51, 408);
            textBox_ulica.Name = "textBox_ulica";
            textBox_ulica.Size = new Size(100, 23);
            textBox_ulica.TabIndex = 6;
            // 
            // textBox_numer
            // 
            textBox_numer.Location = new Point(222, 408);
            textBox_numer.Name = "textBox_numer";
            textBox_numer.Size = new Size(100, 23);
            textBox_numer.TabIndex = 7;
            // 
            // textBox_PESEL
            // 
            textBox_PESEL.Location = new Point(51, 468);
            textBox_PESEL.Name = "textBox_PESEL";
            textBox_PESEL.Size = new Size(100, 23);
            textBox_PESEL.TabIndex = 8;
            // 
            // Form_Zamowienie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 754);
            Controls.Add(button_Klient_prywatny);
            Controls.Add(panel1);
            Controls.Add(button_klient_z_firmy);
            Name = "Form_Zamowienie";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private void textBox_Nazwisko_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox textBox_Nazwisko;
        private Button button_Klient_prywatny;
        private Button button_klient_z_firmy;
        private Panel panel1;
        private TextBox textBox_email;
        private TextBox textBox_Numer_telefonu;
        private TextBox textBox_imie;
        private TextBox textBox_PESEL;
        private TextBox textBox_numer;
        private TextBox textBox_ulica;
        private TextBox textBox_kod_pocztowy;
        private TextBox textBox_Miejscowosc;
    }
}