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
            label_imie = new Label();
            textBox_imie = new TextBox();
            label_nazwisko = new Label();
            label_nrtelefonu = new Label();
            label_email = new Label();
            label_miejscowosc = new Label();
            label_kodpocztowy = new Label();
            label_ulica = new Label();
            label_numer = new Label();
            label_pesel = new Label();
            textBox_nazwisko = new TextBox();
            textBox_numertelefonu = new TextBox();
            textBox_email = new TextBox();
            textBox_miejscowosc = new TextBox();
            textBox_kodpocztowy = new TextBox();
            textBox_ulica = new TextBox();
            textBox_numer = new TextBox();
            textBox_pesel = new TextBox();
            panel_daneosoby = new Panel();
            label_idosoby = new Label();
            btn_dodawanie = new Button();
            btn_usuwanie = new Button();
            comboBox_idosoby = new ComboBox();
            button_Dodaj = new Button();
            button_Edytuj = new Button();
            button_ArrowR = new Button();
            button_ArrowL = new Button();
            panel1 = new Panel();
            label1 = new Label();
            button_Wyczysc = new Button();
            panel_daneosoby.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label_imie
            // 
            label_imie.AutoSize = true;
            label_imie.Location = new Point(32, 32);
            label_imie.Name = "label_imie";
            label_imie.Size = new Size(38, 20);
            label_imie.TabIndex = 0;
            label_imie.Text = "Imię";
            // 
            // textBox_imie
            // 
            textBox_imie.Location = new Point(187, 27);
            textBox_imie.Margin = new Padding(3, 4, 3, 4);
            textBox_imie.Name = "textBox_imie";
            textBox_imie.Size = new Size(633, 27);
            textBox_imie.TabIndex = 1;
            // 
            // label_nazwisko
            // 
            label_nazwisko.AutoSize = true;
            label_nazwisko.Location = new Point(32, 84);
            label_nazwisko.Name = "label_nazwisko";
            label_nazwisko.Size = new Size(72, 20);
            label_nazwisko.TabIndex = 0;
            label_nazwisko.Text = "Nazwisko";
            // 
            // label_nrtelefonu
            // 
            label_nrtelefonu.AutoSize = true;
            label_nrtelefonu.Location = new Point(32, 135);
            label_nrtelefonu.Name = "label_nrtelefonu";
            label_nrtelefonu.Size = new Size(84, 20);
            label_nrtelefonu.TabIndex = 0;
            label_nrtelefonu.Text = "Nr telefonu";
            // 
            // label_email
            // 
            label_email.AutoSize = true;
            label_email.Location = new Point(32, 185);
            label_email.Name = "label_email";
            label_email.Size = new Size(94, 20);
            label_email.TabIndex = 0;
            label_email.Text = "Adres E-mail";
            // 
            // label_miejscowosc
            // 
            label_miejscowosc.AutoSize = true;
            label_miejscowosc.Location = new Point(32, 237);
            label_miejscowosc.Name = "label_miejscowosc";
            label_miejscowosc.Size = new Size(93, 20);
            label_miejscowosc.TabIndex = 0;
            label_miejscowosc.Text = "Miejscowość";
            // 
            // label_kodpocztowy
            // 
            label_kodpocztowy.AutoSize = true;
            label_kodpocztowy.Location = new Point(32, 287);
            label_kodpocztowy.Name = "label_kodpocztowy";
            label_kodpocztowy.Size = new Size(104, 20);
            label_kodpocztowy.TabIndex = 0;
            label_kodpocztowy.Text = "Kod pocztowy";
            // 
            // label_ulica
            // 
            label_ulica.AutoSize = true;
            label_ulica.Location = new Point(32, 337);
            label_ulica.Name = "label_ulica";
            label_ulica.Size = new Size(42, 20);
            label_ulica.TabIndex = 0;
            label_ulica.Text = "Ulica";
            // 
            // label_numer
            // 
            label_numer.AutoSize = true;
            label_numer.Location = new Point(32, 388);
            label_numer.Name = "label_numer";
            label_numer.Size = new Size(54, 20);
            label_numer.TabIndex = 0;
            label_numer.Text = "Numer";
            // 
            // label_pesel
            // 
            label_pesel.AutoSize = true;
            label_pesel.Location = new Point(32, 439);
            label_pesel.Name = "label_pesel";
            label_pesel.Size = new Size(48, 20);
            label_pesel.TabIndex = 0;
            label_pesel.Text = "PESEL";
            // 
            // textBox_nazwisko
            // 
            textBox_nazwisko.Location = new Point(187, 79);
            textBox_nazwisko.Margin = new Padding(3, 4, 3, 4);
            textBox_nazwisko.Name = "textBox_nazwisko";
            textBox_nazwisko.Size = new Size(633, 27);
            textBox_nazwisko.TabIndex = 1;
            // 
            // textBox_numertelefonu
            // 
            textBox_numertelefonu.Location = new Point(187, 129);
            textBox_numertelefonu.Margin = new Padding(3, 4, 3, 4);
            textBox_numertelefonu.Name = "textBox_numertelefonu";
            textBox_numertelefonu.Size = new Size(633, 27);
            textBox_numertelefonu.TabIndex = 1;
            textBox_numertelefonu.TextChanged += textBox_numertelefonu_TextChanged;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(187, 180);
            textBox_email.Margin = new Padding(3, 4, 3, 4);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(633, 27);
            textBox_email.TabIndex = 1;
            // 
            // textBox_miejscowosc
            // 
            textBox_miejscowosc.Location = new Point(187, 232);
            textBox_miejscowosc.Margin = new Padding(3, 4, 3, 4);
            textBox_miejscowosc.Name = "textBox_miejscowosc";
            textBox_miejscowosc.Size = new Size(633, 27);
            textBox_miejscowosc.TabIndex = 1;
            // 
            // textBox_kodpocztowy
            // 
            textBox_kodpocztowy.Location = new Point(187, 281);
            textBox_kodpocztowy.Margin = new Padding(3, 4, 3, 4);
            textBox_kodpocztowy.Name = "textBox_kodpocztowy";
            textBox_kodpocztowy.Size = new Size(633, 27);
            textBox_kodpocztowy.TabIndex = 1;
            // 
            // textBox_ulica
            // 
            textBox_ulica.Location = new Point(187, 332);
            textBox_ulica.Margin = new Padding(3, 4, 3, 4);
            textBox_ulica.Name = "textBox_ulica";
            textBox_ulica.Size = new Size(633, 27);
            textBox_ulica.TabIndex = 1;
            // 
            // textBox_numer
            // 
            textBox_numer.Location = new Point(187, 383);
            textBox_numer.Margin = new Padding(3, 4, 3, 4);
            textBox_numer.Name = "textBox_numer";
            textBox_numer.Size = new Size(633, 27);
            textBox_numer.TabIndex = 1;
            // 
            // textBox_pesel
            // 
            textBox_pesel.Location = new Point(187, 433);
            textBox_pesel.Margin = new Padding(3, 4, 3, 4);
            textBox_pesel.Name = "textBox_pesel";
            textBox_pesel.Size = new Size(633, 27);
            textBox_pesel.TabIndex = 1;
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
            panel_daneosoby.Location = new Point(47, 129);
            panel_daneosoby.Margin = new Padding(3, 4, 3, 4);
            panel_daneosoby.Name = "panel_daneosoby";
            panel_daneosoby.Size = new Size(841, 533);
            panel_daneosoby.TabIndex = 2;
            // 
            // label_idosoby
            // 
            label_idosoby.AutoSize = true;
            label_idosoby.Location = new Point(82, 63);
            label_idosoby.Name = "label_idosoby";
            label_idosoby.Size = new Size(52, 20);
            label_idosoby.TabIndex = 0;
            label_idosoby.Text = "Osoba";
            // 
            // btn_dodawanie
            // 
            btn_dodawanie.Location = new Point(49, 695);
            btn_dodawanie.Margin = new Padding(3, 4, 3, 4);
            btn_dodawanie.Name = "btn_dodawanie";
            btn_dodawanie.Size = new Size(86, 31);
            btn_dodawanie.TabIndex = 3;
            btn_dodawanie.Text = "Dodawanie";
            btn_dodawanie.UseVisualStyleBackColor = true;
            btn_dodawanie.Click += btn_dodawanie_Click;
            // 
            // btn_usuwanie
            // 
            btn_usuwanie.BackColor = SystemColors.ControlLight;
            btn_usuwanie.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btn_usuwanie.Location = new Point(804, 695);
            btn_usuwanie.Margin = new Padding(3, 4, 3, 4);
            btn_usuwanie.Name = "btn_usuwanie";
            btn_usuwanie.Size = new Size(83, 45);
            btn_usuwanie.TabIndex = 3;
            btn_usuwanie.Text = "Usuń";
            btn_usuwanie.UseVisualStyleBackColor = false;
            btn_usuwanie.Click += btn_usuwanie_Click;
            // 
            // comboBox_idosoby
            // 
            comboBox_idosoby.FormattingEnabled = true;
            comboBox_idosoby.Location = new Point(237, 55);
            comboBox_idosoby.Margin = new Padding(3, 4, 3, 4);
            comboBox_idosoby.Name = "comboBox_idosoby";
            comboBox_idosoby.Size = new Size(633, 28);
            comboBox_idosoby.TabIndex = 4;
            comboBox_idosoby.SelectedIndexChanged += comboBox_idosoby_SelectedIndexChanged;
            // 
            // button_Dodaj
            // 
            button_Dodaj.BackColor = SystemColors.ControlLight;
            button_Dodaj.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            button_Dodaj.Location = new Point(49, 695);
            button_Dodaj.Margin = new Padding(3, 4, 3, 4);
            button_Dodaj.Name = "button_Dodaj";
            button_Dodaj.Size = new Size(185, 45);
            button_Dodaj.TabIndex = 3;
            button_Dodaj.Text = "Dodaj rekord";
            button_Dodaj.UseVisualStyleBackColor = false;
            button_Dodaj.Click += btn_dodawanie_Click;
            // 
            // button_Edytuj
            // 
            button_Edytuj.BackColor = SystemColors.ControlLight;
            button_Edytuj.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            button_Edytuj.Location = new Point(322, 692);
            button_Edytuj.Margin = new Padding(3, 4, 3, 4);
            button_Edytuj.Name = "button_Edytuj";
            button_Edytuj.Size = new Size(113, 45);
            button_Edytuj.TabIndex = 3;
            button_Edytuj.Text = "Edytuj";
            button_Edytuj.UseVisualStyleBackColor = false;
            button_Edytuj.Click += btn_edytowanie_Click;
            // 
            // button_ArrowR
            // 
            button_ArrowR.BackgroundImage = Properties.Resources.Arrow_right;
            button_ArrowR.BackgroundImageLayout = ImageLayout.Zoom;
            button_ArrowR.ImageAlign = ContentAlignment.TopCenter;
            button_ArrowR.Location = new Point(739, 804);
            button_ArrowR.Margin = new Padding(3, 4, 3, 4);
            button_ArrowR.Name = "button_ArrowR";
            button_ArrowR.Size = new Size(149, 67);
            button_ArrowR.TabIndex = 5;
            button_ArrowR.UseVisualStyleBackColor = true;
            button_ArrowR.Click += button_ArrowR_Click;
            // 
            // button_ArrowL
            // 
            button_ArrowL.BackgroundImage = Properties.Resources.Arrow_left;
            button_ArrowL.BackgroundImageLayout = ImageLayout.Zoom;
            button_ArrowL.Location = new Point(47, 804);
            button_ArrowL.Margin = new Padding(3, 4, 3, 4);
            button_ArrowL.Name = "button_ArrowL";
            button_ArrowL.Size = new Size(149, 67);
            button_ArrowL.TabIndex = 5;
            button_ArrowL.UseVisualStyleBackColor = true;
            button_ArrowL.Click += button_ArrowL_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(button_ArrowL);
            panel1.Controls.Add(label_idosoby);
            panel1.Controls.Add(button_ArrowR);
            panel1.Controls.Add(panel_daneosoby);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button_Wyczysc);
            panel1.Controls.Add(button_Edytuj);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(2, 3);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(931, 897);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(235, 156);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "Imię";
            // 
            // button_Wyczysc
            // 
            button_Wyczysc.BackColor = SystemColors.ControlLight;
            button_Wyczysc.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            button_Wyczysc.Location = new Point(523, 692);
            button_Wyczysc.Margin = new Padding(3, 4, 3, 4);
            button_Wyczysc.Name = "button_Wyczysc";
            button_Wyczysc.Size = new Size(193, 45);
            button_Wyczysc.TabIndex = 3;
            button_Wyczysc.Text = "Wyczyść dane";
            button_Wyczysc.UseVisualStyleBackColor = false;
            button_Wyczysc.Click += btn_wyczysc_Click;
            // 
            // Form_ListaOsob
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            ClientSize = new Size(935, 903);
            Controls.Add(comboBox_idosoby);
            Controls.Add(btn_usuwanie);
            Controls.Add(button_Dodaj);
            Controls.Add(btn_dodawanie);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_ListaOsob";
            Padding = new Padding(2, 3, 2, 3);
            Text = "Lista osób  ";
            panel_daneosoby.ResumeLayout(false);
            panel_daneosoby.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_imie;
        private TextBox textBox_imie;
        private Label label_nazwisko;
        private Label label_nrtelefonu;
        private Label label_email;
        private Label label_miejscowosc;
        private Label label_kodpocztowy;
        private Label label_ulica;
        private Label label_numer;
        private Label label_pesel;
        private TextBox textBox_nazwisko;
        private TextBox textBox_numertelefonu;
        private TextBox textBox_email;
        private TextBox textBox_miejscowosc;
        private TextBox textBox_kodpocztowy;
        private TextBox textBox_ulica;
        private TextBox textBox_numer;
        private TextBox textBox_pesel;
        private Panel panel_daneosoby;
        private Label label_idosoby;
        private Button btn_dodawanie;
        private Button btn_usuwanie;
        private ComboBox comboBox_idosoby;
        private Button button_Dodaj;
        private Button button_Edytuj;
        private Button button_ArrowR;
        private Button button_ArrowL;
        private Panel panel1;
        private Label label1;
        private Button button_Wyczysc;
    }
}