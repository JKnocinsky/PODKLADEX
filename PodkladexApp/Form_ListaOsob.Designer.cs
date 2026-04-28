namespace PodkladexApp
{
    partial class Form_ListaOsob
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
            comboBox_idosoby = new ComboBox();
            button_ArrowL = new Button();
            btn_usuwanie = new Button();
            label_idosoby = new Label();
            button_Wyczysc = new Button();
            button_Edytuj = new Button();
            button_ArrowR = new Button();
            button_Dodaj = new Button();
            panel_daneosoby = new Panel();
            textBox_pesel = new TextBox();
            textBox_numer = new TextBox();
            textBox_ulica = new TextBox();
            textBox_kodpocztowy = new TextBox();
            textBox_miejscowosc = new TextBox();
            textBox_email = new TextBox();
            textBox_numertelefonu = new TextBox();
            textBox_nazwisko = new TextBox();
            textBox_imie = new TextBox();
            label_pesel = new Label();
            label_numer = new Label();
            label_ulica = new Label();
            label_kodpocztowy = new Label();
            label_miejscowosc = new Label();
            label_email = new Label();
            label_nrtelefonu = new Label();
            label_nazwisko = new Label();
            label_imie = new Label();
            panel_daneosoby.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox_idosoby
            // 
            comboBox_idosoby.FormattingEnabled = true;
            comboBox_idosoby.Location = new Point(244, 47);
            comboBox_idosoby.Name = "comboBox_idosoby";
            comboBox_idosoby.Size = new Size(554, 23);
            comboBox_idosoby.TabIndex = 4;
            comboBox_idosoby.SelectedIndexChanged += comboBox_idosoby_SelectedIndexChanged;
            comboBox_idosoby.TextUpdate += comboBox_idosoby_TextUpdate;
            // 
            // button_ArrowL
            // 
            button_ArrowL.BackgroundImage = Properties.Resources.Arrow_left;
            button_ArrowL.BackgroundImageLayout = ImageLayout.Zoom;
            button_ArrowL.Location = new Point(7, 647);
            button_ArrowL.Name = "button_ArrowL";
            button_ArrowL.Size = new Size(130, 50);
            button_ArrowL.TabIndex = 12;
            button_ArrowL.UseVisualStyleBackColor = true;
            // 
            // btn_usuwanie
            // 
            btn_usuwanie.BackColor = SystemColors.ControlLight;
            btn_usuwanie.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btn_usuwanie.Location = new Point(697, 522);
            btn_usuwanie.Name = "btn_usuwanie";
            btn_usuwanie.Size = new Size(147, 46);
            btn_usuwanie.TabIndex = 8;
            btn_usuwanie.Text = "Usuń osobę";
            btn_usuwanie.UseVisualStyleBackColor = false;
            // 
            // label_idosoby
            // 
            label_idosoby.AutoSize = true;
            label_idosoby.Location = new Point(111, 50);
            label_idosoby.Name = "label_idosoby";
            label_idosoby.Size = new Size(41, 15);
            label_idosoby.TabIndex = 6;
            label_idosoby.Text = "Osoba";
            // 
            // button_Wyczysc
            // 
            button_Wyczysc.BackColor = SystemColors.ControlLight;
            button_Wyczysc.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            button_Wyczysc.Location = new Point(469, 522);
            button_Wyczysc.Margin = new Padding(3, 2, 3, 2);
            button_Wyczysc.Name = "button_Wyczysc";
            button_Wyczysc.Size = new Size(167, 46);
            button_Wyczysc.TabIndex = 9;
            button_Wyczysc.Text = "Wyczyść dane";
            button_Wyczysc.UseVisualStyleBackColor = false;
            // 
            // button_Edytuj
            // 
            button_Edytuj.BackColor = SystemColors.ControlLight;
            button_Edytuj.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            button_Edytuj.Location = new Point(311, 522);
            button_Edytuj.Margin = new Padding(3, 2, 3, 2);
            button_Edytuj.Name = "button_Edytuj";
            button_Edytuj.Size = new Size(97, 46);
            button_Edytuj.TabIndex = 10;
            button_Edytuj.Text = "Edytuj";
            button_Edytuj.UseVisualStyleBackColor = false;
            // 
            // button_ArrowR
            // 
            button_ArrowR.BackgroundImage = Properties.Resources.Arrow_right;
            button_ArrowR.BackgroundImageLayout = ImageLayout.Zoom;
            button_ArrowR.ImageAlign = ContentAlignment.TopCenter;
            button_ArrowR.Location = new Point(779, 647);
            button_ArrowR.Name = "button_ArrowR";
            button_ArrowR.Size = new Size(130, 50);
            button_ArrowR.TabIndex = 13;
            button_ArrowR.UseVisualStyleBackColor = true;
            // 
            // button_Dodaj
            // 
            button_Dodaj.BackColor = SystemColors.ControlLight;
            button_Dodaj.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            button_Dodaj.Location = new Point(108, 522);
            button_Dodaj.Margin = new Padding(3, 2, 3, 2);
            button_Dodaj.Name = "button_Dodaj";
            button_Dodaj.Size = new Size(142, 46);
            button_Dodaj.TabIndex = 11;
            button_Dodaj.Text = "Dodaj rekord";
            button_Dodaj.UseVisualStyleBackColor = false;
            // 
            // panel_daneosoby
            // 
            panel_daneosoby.BorderStyle = BorderStyle.FixedSingle;
            panel_daneosoby.Controls.Add(textBox_pesel);
            panel_daneosoby.Controls.Add(textBox_numer);
            panel_daneosoby.Controls.Add(textBox_ulica);
            panel_daneosoby.Controls.Add(textBox_kodpocztowy);
            panel_daneosoby.Controls.Add(textBox_miejscowosc);
            panel_daneosoby.Controls.Add(textBox_email);
            panel_daneosoby.Controls.Add(textBox_numertelefonu);
            panel_daneosoby.Controls.Add(textBox_nazwisko);
            panel_daneosoby.Controls.Add(textBox_imie);
            panel_daneosoby.Controls.Add(label_pesel);
            panel_daneosoby.Controls.Add(label_numer);
            panel_daneosoby.Controls.Add(label_ulica);
            panel_daneosoby.Controls.Add(label_kodpocztowy);
            panel_daneosoby.Controls.Add(label_miejscowosc);
            panel_daneosoby.Controls.Add(label_email);
            panel_daneosoby.Controls.Add(label_nrtelefonu);
            panel_daneosoby.Controls.Add(label_nazwisko);
            panel_daneosoby.Controls.Add(label_imie);
            panel_daneosoby.Location = new Point(7, 85);
            panel_daneosoby.Name = "panel_daneosoby";
            panel_daneosoby.Size = new Size(902, 400);
            panel_daneosoby.TabIndex = 7;
            // 
            // textBox_pesel
            // 
            textBox_pesel.Location = new Point(236, 336);
            textBox_pesel.Name = "textBox_pesel";
            textBox_pesel.Size = new Size(554, 23);
            textBox_pesel.TabIndex = 1;
            // 
            // textBox_numer
            // 
            textBox_numer.Location = new Point(236, 298);
            textBox_numer.Name = "textBox_numer";
            textBox_numer.Size = new Size(554, 23);
            textBox_numer.TabIndex = 1;
            // 
            // textBox_ulica
            // 
            textBox_ulica.Location = new Point(236, 260);
            textBox_ulica.Name = "textBox_ulica";
            textBox_ulica.Size = new Size(554, 23);
            textBox_ulica.TabIndex = 1;
            // 
            // textBox_kodpocztowy
            // 
            textBox_kodpocztowy.Location = new Point(236, 222);
            textBox_kodpocztowy.Name = "textBox_kodpocztowy";
            textBox_kodpocztowy.Size = new Size(554, 23);
            textBox_kodpocztowy.TabIndex = 1;
            // 
            // textBox_miejscowosc
            // 
            textBox_miejscowosc.Location = new Point(236, 185);
            textBox_miejscowosc.Name = "textBox_miejscowosc";
            textBox_miejscowosc.Size = new Size(554, 23);
            textBox_miejscowosc.TabIndex = 1;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(236, 146);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(554, 23);
            textBox_email.TabIndex = 1;
            // 
            // textBox_numertelefonu
            // 
            textBox_numertelefonu.Location = new Point(236, 108);
            textBox_numertelefonu.Name = "textBox_numertelefonu";
            textBox_numertelefonu.Size = new Size(554, 23);
            textBox_numertelefonu.TabIndex = 1;
            // 
            // textBox_nazwisko
            // 
            textBox_nazwisko.Location = new Point(236, 70);
            textBox_nazwisko.Name = "textBox_nazwisko";
            textBox_nazwisko.Size = new Size(554, 23);
            textBox_nazwisko.TabIndex = 1;
            // 
            // textBox_imie
            // 
            textBox_imie.Location = new Point(236, 31);
            textBox_imie.Name = "textBox_imie";
            textBox_imie.Size = new Size(554, 23);
            textBox_imie.TabIndex = 1;
            // 
            // label_pesel
            // 
            label_pesel.AutoSize = true;
            label_pesel.Location = new Point(100, 340);
            label_pesel.Name = "label_pesel";
            label_pesel.Size = new Size(38, 15);
            label_pesel.TabIndex = 0;
            label_pesel.Text = "PESEL";
            // 
            // label_numer
            // 
            label_numer.AutoSize = true;
            label_numer.Location = new Point(100, 302);
            label_numer.Name = "label_numer";
            label_numer.Size = new Size(44, 15);
            label_numer.TabIndex = 0;
            label_numer.Text = "Numer";
            // 
            // label_ulica
            // 
            label_ulica.AutoSize = true;
            label_ulica.Location = new Point(100, 264);
            label_ulica.Name = "label_ulica";
            label_ulica.Size = new Size(33, 15);
            label_ulica.TabIndex = 0;
            label_ulica.Text = "Ulica";
            // 
            // label_kodpocztowy
            // 
            label_kodpocztowy.AutoSize = true;
            label_kodpocztowy.Location = new Point(100, 226);
            label_kodpocztowy.Name = "label_kodpocztowy";
            label_kodpocztowy.Size = new Size(82, 15);
            label_kodpocztowy.TabIndex = 0;
            label_kodpocztowy.Text = "Kod pocztowy";
            // 
            // label_miejscowosc
            // 
            label_miejscowosc.AutoSize = true;
            label_miejscowosc.Location = new Point(100, 189);
            label_miejscowosc.Name = "label_miejscowosc";
            label_miejscowosc.Size = new Size(75, 15);
            label_miejscowosc.TabIndex = 0;
            label_miejscowosc.Text = "Miejscowość";
            // 
            // label_email
            // 
            label_email.AutoSize = true;
            label_email.Location = new Point(100, 150);
            label_email.Name = "label_email";
            label_email.Size = new Size(74, 15);
            label_email.TabIndex = 0;
            label_email.Text = "Adres E-mail";
            // 
            // label_nrtelefonu
            // 
            label_nrtelefonu.AutoSize = true;
            label_nrtelefonu.Location = new Point(100, 112);
            label_nrtelefonu.Name = "label_nrtelefonu";
            label_nrtelefonu.Size = new Size(67, 15);
            label_nrtelefonu.TabIndex = 0;
            label_nrtelefonu.Text = "Nr telefonu";
            // 
            // label_nazwisko
            // 
            label_nazwisko.AutoSize = true;
            label_nazwisko.Location = new Point(100, 74);
            label_nazwisko.Name = "label_nazwisko";
            label_nazwisko.Size = new Size(57, 15);
            label_nazwisko.TabIndex = 0;
            label_nazwisko.Text = "Nazwisko";
            // 
            // label_imie
            // 
            label_imie.AutoSize = true;
            label_imie.Location = new Point(100, 35);
            label_imie.Name = "label_imie";
            label_imie.Size = new Size(30, 15);
            label_imie.TabIndex = 0;
            label_imie.Text = "Imię";
            // 
            // Form_ListaOsob
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(934, 711);
            Controls.Add(button_ArrowL);
            Controls.Add(btn_usuwanie);
            Controls.Add(label_idosoby);
            Controls.Add(button_Wyczysc);
            Controls.Add(button_Edytuj);
            Controls.Add(button_ArrowR);
            Controls.Add(button_Dodaj);
            Controls.Add(panel_daneosoby);
            Controls.Add(comboBox_idosoby);
            Name = "Form_ListaOsob";
            Padding = new Padding(2);
            Text = "Lista osób  ";
            panel_daneosoby.ResumeLayout(false);
            panel_daneosoby.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox_idosoby;
        private Button button_ArrowL;
        private Button btn_usuwanie;
        private Label label_idosoby;
        private Button button_Wyczysc;
        private Button button_Edytuj;
        private Button button_ArrowR;
        private Button button_Dodaj;
        private Panel panel_daneosoby;
        private TextBox textBox_pesel;
        private TextBox textBox_numer;
        private TextBox textBox_ulica;
        private TextBox textBox_kodpocztowy;
        private TextBox textBox_miejscowosc;
        private TextBox textBox_email;
        private TextBox textBox_numertelefonu;
        private TextBox textBox_nazwisko;
        private TextBox textBox_imie;
        private Label label_pesel;
        private Label label_numer;
        private Label label_ulica;
        private Label label_kodpocztowy;
        private Label label_miejscowosc;
        private Label label_email;
        private Label label_nrtelefonu;
        private Label label_nazwisko;
        private Label label_imie;
    }
}