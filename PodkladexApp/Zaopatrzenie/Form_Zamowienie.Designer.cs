
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
            label_numer = new Label();
            label_ulica = new Label();
            label_kodpozc = new Label();
            label_miejscowosc = new Label();
            label_email = new Label();
            label_numer_tel = new Label();
            label_nazwisko = new Label();
            label_imie = new Label();
            textBox_numer = new TextBox();
            textBox_ulica = new TextBox();
            textBox_kod_pocztowy = new TextBox();
            textBox_Miejscowosc = new TextBox();
            textBox_email = new TextBox();
            textBox_Numer_telefonu = new TextBox();
            textBox_imie = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_Nazwisko
            // 
            textBox_Nazwisko.Font = new Font("Segoe UI", 13.8F);
            textBox_Nazwisko.Location = new Point(473, 59);
            textBox_Nazwisko.Margin = new Padding(3, 4, 3, 4);
            textBox_Nazwisko.Name = "textBox_Nazwisko";
            textBox_Nazwisko.Size = new Size(172, 38);
            textBox_Nazwisko.TabIndex = 0;
            textBox_Nazwisko.TextChanged += textBox_Nazwisko_TextChanged;
            // 
            // button_Klient_prywatny
            // 
            button_Klient_prywatny.Font = new Font("Segoe UI", 14F);
            button_Klient_prywatny.Location = new Point(355, 98);
            button_Klient_prywatny.Margin = new Padding(3, 4, 3, 4);
            button_Klient_prywatny.Name = "button_Klient_prywatny";
            button_Klient_prywatny.Size = new Size(150, 50);
            button_Klient_prywatny.TabIndex = 1;
            button_Klient_prywatny.Text = "Klient prywatny";
            button_Klient_prywatny.UseVisualStyleBackColor = true;
            // 
            // button_klient_z_firmy
            // 
            button_klient_z_firmy.Font = new Font("Segoe UI", 14F);
            button_klient_z_firmy.Location = new Point(659, 98);
            button_klient_z_firmy.Margin = new Padding(3, 4, 3, 4);
            button_klient_z_firmy.Name = "button_klient_z_firmy";
            button_klient_z_firmy.Size = new Size(150, 50);
            button_klient_z_firmy.TabIndex = 2;
            button_klient_z_firmy.Text = "Firma";
            button_klient_z_firmy.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label_numer);
            panel1.Controls.Add(label_ulica);
            panel1.Controls.Add(label_kodpozc);
            panel1.Controls.Add(label_miejscowosc);
            panel1.Controls.Add(label_email);
            panel1.Controls.Add(label_numer_tel);
            panel1.Controls.Add(label_nazwisko);
            panel1.Controls.Add(label_imie);
            panel1.Controls.Add(textBox_numer);
            panel1.Controls.Add(textBox_ulica);
            panel1.Controls.Add(textBox_kod_pocztowy);
            panel1.Controls.Add(textBox_Miejscowosc);
            panel1.Controls.Add(textBox_email);
            panel1.Controls.Add(textBox_Numer_telefonu);
            panel1.Controls.Add(textBox_imie);
            panel1.Controls.Add(textBox_Nazwisko);
            panel1.Location = new Point(255, 202);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1014, 827);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // label_numer
            // 
            label_numer.AutoSize = true;
            label_numer.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_numer.Location = new Point(462, 398);
            label_numer.Name = "label_numer";
            label_numer.Size = new Size(86, 31);
            label_numer.TabIndex = 15;
            label_numer.Text = "Numer";
            // 
            // label_ulica
            // 
            label_ulica.AutoSize = true;
            label_ulica.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_ulica.Location = new Point(115, 398);
            label_ulica.Name = "label_ulica";
            label_ulica.Size = new Size(67, 31);
            label_ulica.TabIndex = 14;
            label_ulica.Text = "Ulica";
            // 
            // label_kodpozc
            // 
            label_kodpozc.AutoSize = true;
            label_kodpozc.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_kodpozc.Location = new Point(391, 319);
            label_kodpozc.Name = "label_kodpozc";
            label_kodpozc.Size = new Size(157, 31);
            label_kodpozc.TabIndex = 13;
            label_kodpozc.Text = "Kod pocztowy";
            // 
            // label_miejscowosc
            // 
            label_miejscowosc.AutoSize = true;
            label_miejscowosc.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_miejscowosc.Location = new Point(41, 319);
            label_miejscowosc.Name = "label_miejscowosc";
            label_miejscowosc.Size = new Size(141, 31);
            label_miejscowosc.TabIndex = 12;
            label_miejscowosc.Text = "Miejscowość";
            // 
            // label_email
            // 
            label_email.AutoSize = true;
            label_email.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_email.Location = new Point(100, 240);
            label_email.Name = "label_email";
            label_email.Size = new Size(82, 31);
            label_email.TabIndex = 11;
            label_email.Text = "E-mail";
            label_email.Click += label1_Click;
            // 
            // label_numer_tel
            // 
            label_numer_tel.AutoSize = true;
            label_numer_tel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_numer_tel.Location = new Point(12, 161);
            label_numer_tel.Name = "label_numer_tel";
            label_numer_tel.Size = new Size(178, 31);
            label_numer_tel.TabIndex = 10;
            label_numer_tel.Text = "Numer telefonu";
            // 
            // label_nazwisko
            // 
            label_nazwisko.AutoSize = true;
            label_nazwisko.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_nazwisko.Location = new Point(352, 66);
            label_nazwisko.Name = "label_nazwisko";
            label_nazwisko.Size = new Size(115, 31);
            label_nazwisko.TabIndex = 9;
            label_nazwisko.Text = "Nazwisko";
            // 
            // label_imie
            // 
            label_imie.AutoSize = true;
            label_imie.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_imie.Location = new Point(57, 66);
            label_imie.Name = "label_imie";
            label_imie.Size = new Size(60, 31);
            label_imie.TabIndex = 8;
            label_imie.Text = "Imię";
            // 
            // textBox_numer
            // 
            textBox_numer.Font = new Font("Segoe UI", 13.8F);
            textBox_numer.Location = new Point(554, 394);
            textBox_numer.Margin = new Padding(3, 4, 3, 4);
            textBox_numer.Name = "textBox_numer";
            textBox_numer.Size = new Size(172, 38);
            textBox_numer.TabIndex = 7;
            // 
            // textBox_ulica
            // 
            textBox_ulica.Font = new Font("Segoe UI", 13.8F);
            textBox_ulica.Location = new Point(196, 394);
            textBox_ulica.Margin = new Padding(3, 4, 3, 4);
            textBox_ulica.Name = "textBox_ulica";
            textBox_ulica.Size = new Size(172, 38);
            textBox_ulica.TabIndex = 6;
            // 
            // textBox_kod_pocztowy
            // 
            textBox_kod_pocztowy.Font = new Font("Segoe UI", 13.8F);
            textBox_kod_pocztowy.Location = new Point(554, 315);
            textBox_kod_pocztowy.Margin = new Padding(3, 4, 3, 4);
            textBox_kod_pocztowy.Name = "textBox_kod_pocztowy";
            textBox_kod_pocztowy.Size = new Size(172, 38);
            textBox_kod_pocztowy.TabIndex = 5;
            textBox_kod_pocztowy.TextChanged += textBox_kod_pocztowy_TextChanged;
            // 
            // textBox_Miejscowosc
            // 
            textBox_Miejscowosc.Font = new Font("Segoe UI", 13.8F);
            textBox_Miejscowosc.Location = new Point(196, 315);
            textBox_Miejscowosc.Margin = new Padding(3, 4, 3, 4);
            textBox_Miejscowosc.Name = "textBox_Miejscowosc";
            textBox_Miejscowosc.Size = new Size(172, 38);
            textBox_Miejscowosc.TabIndex = 4;
            textBox_Miejscowosc.TextChanged += textBox_Miejscowosc_TextChanged;
            // 
            // textBox_email
            // 
            textBox_email.Font = new Font("Segoe UI", 13.8F);
            textBox_email.Location = new Point(196, 236);
            textBox_email.Margin = new Padding(3, 4, 3, 4);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(172, 38);
            textBox_email.TabIndex = 3;
            textBox_email.TextChanged += textBox_email_TextChanged;
            // 
            // textBox_Numer_telefonu
            // 
            textBox_Numer_telefonu.Font = new Font("Segoe UI", 13.8F);
            textBox_Numer_telefonu.Location = new Point(196, 157);
            textBox_Numer_telefonu.Margin = new Padding(3, 4, 3, 4);
            textBox_Numer_telefonu.Name = "textBox_Numer_telefonu";
            textBox_Numer_telefonu.Size = new Size(172, 38);
            textBox_Numer_telefonu.TabIndex = 2;
            textBox_Numer_telefonu.TextChanged += textBox_Numer_telefonu_TextChanged;
            // 
            // textBox_imie
            // 
            textBox_imie.Font = new Font("Segoe UI", 13.8F);
            textBox_imie.Location = new Point(136, 59);
            textBox_imie.Margin = new Padding(3, 4, 3, 4);
            textBox_imie.Name = "textBox_imie";
            textBox_imie.Size = new Size(172, 38);
            textBox_imie.TabIndex = 1;
            textBox_imie.TextChanged += textBox_imie_TextChanged;
            // 
            // Form_Zamowienie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1153);
            Controls.Add(button_Klient_prywatny);
            Controls.Add(panel1);
            Controls.Add(button_klient_z_firmy);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_Zamowienie";
            Text = "Zamówienia";
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
        private TextBox textBox_numer;
        private TextBox textBox_ulica;
        private TextBox textBox_kod_pocztowy;
        private TextBox textBox_Miejscowosc;
        private Label label_nazwisko;
        private Label label_imie;
        private Label label_numer_tel;
        private Label label_email;
        private Label label_kodpozc;
        private Label label_miejscowosc;
        private Label label_numer;
        private Label label_ulica;
    }
}