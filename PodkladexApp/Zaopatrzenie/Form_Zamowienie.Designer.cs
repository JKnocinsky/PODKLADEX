
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
            button_czyszczenie = new Button();
            button_zapisz = new Button();
            label_nazwa_firmy = new Label();
            textBox_nazwa_firmy = new TextBox();
            label_NIP = new Label();
            textBox_NIP = new TextBox();
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
            button_Wroc = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_Nazwisko
            // 
            textBox_Nazwisko.Font = new Font("Segoe UI", 13.8F);
            textBox_Nazwisko.Location = new Point(644, 62);
            textBox_Nazwisko.Margin = new Padding(3, 4, 3, 4);
            textBox_Nazwisko.Name = "textBox_Nazwisko";
            textBox_Nazwisko.Size = new Size(298, 38);
            textBox_Nazwisko.TabIndex = 0;
            textBox_Nazwisko.TextChanged += textBox_Nazwisko_TextChanged;
            // 
            // button_Klient_prywatny
            // 
            button_Klient_prywatny.Font = new Font("Segoe UI", 14F);
            button_Klient_prywatny.Location = new Point(201, 13);
            button_Klient_prywatny.Margin = new Padding(3, 4, 3, 4);
            button_Klient_prywatny.Name = "button_Klient_prywatny";
            button_Klient_prywatny.Size = new Size(150, 50);
            button_Klient_prywatny.TabIndex = 1;
            button_Klient_prywatny.Text = "Klient";
            button_Klient_prywatny.UseVisualStyleBackColor = true;
            button_Klient_prywatny.Click += button_Klient_prywatny_Click;
            // 
            // button_klient_z_firmy
            // 
            button_klient_z_firmy.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_klient_z_firmy.Location = new Point(407, 13);
            button_klient_z_firmy.Margin = new Padding(3, 4, 3, 4);
            button_klient_z_firmy.Name = "button_klient_z_firmy";
            button_klient_z_firmy.Size = new Size(150, 50);
            button_klient_z_firmy.TabIndex = 2;
            button_klient_z_firmy.Text = "Firma";
            button_klient_z_firmy.UseVisualStyleBackColor = true;
            button_klient_z_firmy.Click += button_klient_z_firmy_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button_czyszczenie);
            panel1.Controls.Add(button_zapisz);
            panel1.Controls.Add(label_nazwa_firmy);
            panel1.Controls.Add(textBox_nazwa_firmy);
            panel1.Controls.Add(label_NIP);
            panel1.Controls.Add(textBox_NIP);
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
            panel1.Location = new Point(76, 88);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1467, 977);
            panel1.TabIndex = 3;
            // 
            // button_czyszczenie
            // 
            button_czyszczenie.Font = new Font("Segoe UI", 14F);
            button_czyszczenie.Location = new Point(462, 586);
            button_czyszczenie.Margin = new Padding(3, 4, 3, 4);
            button_czyszczenie.Name = "button_czyszczenie";
            button_czyszczenie.Size = new Size(185, 69);
            button_czyszczenie.TabIndex = 20;
            button_czyszczenie.Text = "Wyczyść dane";
            button_czyszczenie.UseVisualStyleBackColor = true;
            button_czyszczenie.Click += button_czyszczenie_Click;
            // 
            // button_zapisz
            // 
            button_zapisz.Font = new Font("Segoe UI", 14F);
            button_zapisz.Location = new Point(213, 586);
            button_zapisz.Margin = new Padding(3, 4, 3, 4);
            button_zapisz.Name = "button_zapisz";
            button_zapisz.Size = new Size(185, 69);
            button_zapisz.TabIndex = 4;
            button_zapisz.Text = "Zatwierdź";
            button_zapisz.UseVisualStyleBackColor = true;
            button_zapisz.Click += button_zapisz_Click;
            // 
            // label_nazwa_firmy
            // 
            label_nazwa_firmy.AutoSize = true;
            label_nazwa_firmy.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_nazwa_firmy.Location = new Point(42, 466);
            label_nazwa_firmy.Name = "label_nazwa_firmy";
            label_nazwa_firmy.Size = new Size(148, 31);
            label_nazwa_firmy.TabIndex = 19;
            label_nazwa_firmy.Text = "Nazwa firmy";
            // 
            // textBox_nazwa_firmy
            // 
            textBox_nazwa_firmy.Font = new Font("Segoe UI", 13.8F);
            textBox_nazwa_firmy.Location = new Point(196, 462);
            textBox_nazwa_firmy.Margin = new Padding(3, 4, 3, 4);
            textBox_nazwa_firmy.Name = "textBox_nazwa_firmy";
            textBox_nazwa_firmy.Size = new Size(285, 38);
            textBox_nazwa_firmy.TabIndex = 18;
            // 
            // label_NIP
            // 
            label_NIP.AutoSize = true;
            label_NIP.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_NIP.Location = new Point(626, 466);
            label_NIP.Name = "label_NIP";
            label_NIP.Size = new Size(53, 31);
            label_NIP.TabIndex = 17;
            label_NIP.Text = "NIP";
            // 
            // textBox_NIP
            // 
            textBox_NIP.Font = new Font("Segoe UI", 13.8F);
            textBox_NIP.Location = new Point(685, 462);
            textBox_NIP.Margin = new Padding(3, 4, 3, 4);
            textBox_NIP.Name = "textBox_NIP";
            textBox_NIP.Size = new Size(259, 38);
            textBox_NIP.TabIndex = 16;
            textBox_NIP.KeyDown += textBox_NIP_KeyDown;
            textBox_NIP.Leave += textBox_NIP_Leave;
            // 
            // label_numer
            // 
            label_numer.AutoSize = true;
            label_numer.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_numer.Location = new Point(593, 385);
            label_numer.Name = "label_numer";
            label_numer.Size = new Size(86, 31);
            label_numer.TabIndex = 15;
            label_numer.Text = "Numer";
            // 
            // label_ulica
            // 
            label_ulica.AutoSize = true;
            label_ulica.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_ulica.Location = new Point(123, 385);
            label_ulica.Name = "label_ulica";
            label_ulica.Size = new Size(67, 31);
            label_ulica.TabIndex = 14;
            label_ulica.Text = "Ulica";
            // 
            // label_kodpozc
            // 
            label_kodpozc.AutoSize = true;
            label_kodpozc.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_kodpozc.Location = new Point(522, 306);
            label_kodpozc.Name = "label_kodpozc";
            label_kodpozc.Size = new Size(157, 31);
            label_kodpozc.TabIndex = 13;
            label_kodpozc.Text = "Kod pocztowy";
            // 
            // label_miejscowosc
            // 
            label_miejscowosc.AutoSize = true;
            label_miejscowosc.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_miejscowosc.Location = new Point(49, 306);
            label_miejscowosc.Name = "label_miejscowosc";
            label_miejscowosc.Size = new Size(141, 31);
            label_miejscowosc.TabIndex = 12;
            label_miejscowosc.Text = "Miejscowość";
            // 
            // label_email
            // 
            label_email.AutoSize = true;
            label_email.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_email.Location = new Point(108, 226);
            label_email.Name = "label_email";
            label_email.Size = new Size(82, 31);
            label_email.TabIndex = 11;
            label_email.Text = "E-mail";
            // 
            // label_numer_tel
            // 
            label_numer_tel.AutoSize = true;
            label_numer_tel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_numer_tel.Location = new Point(12, 146);
            label_numer_tel.Name = "label_numer_tel";
            label_numer_tel.Size = new Size(178, 31);
            label_numer_tel.TabIndex = 10;
            label_numer_tel.Text = "Numer telefonu";
            // 
            // label_nazwisko
            // 
            label_nazwisko.AutoSize = true;
            label_nazwisko.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_nazwisko.Location = new Point(523, 66);
            label_nazwisko.Name = "label_nazwisko";
            label_nazwisko.Size = new Size(115, 31);
            label_nazwisko.TabIndex = 9;
            label_nazwisko.Text = "Nazwisko";
            label_nazwisko.Click += label_nazwisko_Click;
            // 
            // label_imie
            // 
            label_imie.AutoSize = true;
            label_imie.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_imie.Location = new Point(130, 66);
            label_imie.Name = "label_imie";
            label_imie.Size = new Size(60, 31);
            label_imie.TabIndex = 8;
            label_imie.Text = "Imię";
            label_imie.Click += label_imie_Click;
            // 
            // textBox_numer
            // 
            textBox_numer.Font = new Font("Segoe UI", 13.8F);
            textBox_numer.Location = new Point(685, 381);
            textBox_numer.Margin = new Padding(3, 4, 3, 4);
            textBox_numer.Name = "textBox_numer";
            textBox_numer.Size = new Size(259, 38);
            textBox_numer.TabIndex = 7;
            // 
            // textBox_ulica
            // 
            textBox_ulica.Font = new Font("Segoe UI", 13.8F);
            textBox_ulica.Location = new Point(196, 382);
            textBox_ulica.Margin = new Padding(3, 4, 3, 4);
            textBox_ulica.Name = "textBox_ulica";
            textBox_ulica.Size = new Size(285, 38);
            textBox_ulica.TabIndex = 6;
            // 
            // textBox_kod_pocztowy
            // 
            textBox_kod_pocztowy.Font = new Font("Segoe UI", 13.8F);
            textBox_kod_pocztowy.Location = new Point(685, 302);
            textBox_kod_pocztowy.Margin = new Padding(3, 4, 3, 4);
            textBox_kod_pocztowy.Name = "textBox_kod_pocztowy";
            textBox_kod_pocztowy.Size = new Size(172, 38);
            textBox_kod_pocztowy.TabIndex = 5;
            textBox_kod_pocztowy.TextChanged += textBox_kod_pocztowy_TextChanged;
            // 
            // textBox_Miejscowosc
            // 
            textBox_Miejscowosc.Font = new Font("Segoe UI", 13.8F);
            textBox_Miejscowosc.Location = new Point(196, 302);
            textBox_Miejscowosc.Margin = new Padding(3, 4, 3, 4);
            textBox_Miejscowosc.Name = "textBox_Miejscowosc";
            textBox_Miejscowosc.Size = new Size(285, 38);
            textBox_Miejscowosc.TabIndex = 4;
            // 
            // textBox_email
            // 
            textBox_email.Font = new Font("Segoe UI", 13.8F);
            textBox_email.Location = new Point(196, 222);
            textBox_email.Margin = new Padding(3, 4, 3, 4);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(366, 38);
            textBox_email.TabIndex = 3;
            textBox_email.KeyDown += textBox_email_KeyDown;
            textBox_email.Leave += textBox_email_Leave;
            // 
            // textBox_Numer_telefonu
            // 
            textBox_Numer_telefonu.Font = new Font("Segoe UI", 13.8F);
            textBox_Numer_telefonu.Location = new Point(196, 142);
            textBox_Numer_telefonu.Margin = new Padding(3, 4, 3, 4);
            textBox_Numer_telefonu.Name = "textBox_Numer_telefonu";
            textBox_Numer_telefonu.Size = new Size(366, 38);
            textBox_Numer_telefonu.TabIndex = 2;
            textBox_Numer_telefonu.TextChanged += textBox_Numer_telefonu_TextChanged;
            // 
            // textBox_imie
            // 
            textBox_imie.Font = new Font("Segoe UI", 13.8F);
            textBox_imie.Location = new Point(196, 62);
            textBox_imie.Margin = new Padding(3, 4, 3, 4);
            textBox_imie.Name = "textBox_imie";
            textBox_imie.Size = new Size(283, 38);
            textBox_imie.TabIndex = 1;
            // 
            // button_Wroc
            // 
            button_Wroc.Font = new Font("Segoe UI", 14F);
            button_Wroc.Location = new Point(615, 13);
            button_Wroc.Margin = new Padding(3, 4, 3, 4);
            button_Wroc.Name = "button_Wroc";
            button_Wroc.Size = new Size(150, 50);
            button_Wroc.TabIndex = 4;
            button_Wroc.Text = "Powrót";
            button_Wroc.UseVisualStyleBackColor = true;
            button_Wroc.Click += button_Wroc_Click;
            // 
            // Form_Zamowienie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1055);
            Controls.Add(button_Wroc);
            Controls.Add(button_Klient_prywatny);
            Controls.Add(panel1);
            Controls.Add(button_klient_z_firmy);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_Zamowienie";
            Text = "Zamówienia";
            Load += Form_Zamowienie_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private void textBox_Nazwisko_TextChanged(object sender, EventArgs e)
        {

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
        private Label label_NIP;
        private TextBox textBox_NIP;
        private Label label_nazwa_firmy;
        private TextBox textBox_nazwa_firmy;
        private Button button_zapisz;
        private Button button_czyszczenie;
        private Button button_Wroc;
    }
}