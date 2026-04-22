namespace PodkladexApp
{
    partial class Form_ZaoLog
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
            button_Nowa_firma = new Button();
            button_Edytuj_firmy = new Button();
            comboBox_Nazwa_firmy = new ComboBox();
            panel_dane_firmy = new Panel();
            button_usun_firme = new Button();
            button_zaakceptuj_zmiany = new Button();
            label_NIP = new Label();
            textBox_NazwaFirmy = new TextBox();
            textBox_NIP_firmy = new TextBox();
            label_Numer = new Label();
            Label_Nazwa_firmy = new Label();
            label_ulica = new Label();
            textBox_Numer_firmy = new TextBox();
            textBox_Miejscowosc_firmy = new TextBox();
            label_kod_pocztowy_firmy = new Label();
            label_Miejscowosc = new Label();
            textBox_Ulica_firmy = new TextBox();
            textBox_Kod_pocztowy_firmy = new TextBox();
            btn_Dostawa = new Button();
            panel_dane_firmy.SuspendLayout();
            SuspendLayout();
            // 
            // button_Nowa_firma
            // 
            button_Nowa_firma.Cursor = Cursors.Hand;
            button_Nowa_firma.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            button_Nowa_firma.Location = new Point(31, 20);
            button_Nowa_firma.Name = "button_Nowa_firma";
            button_Nowa_firma.Size = new Size(160, 51);
            button_Nowa_firma.TabIndex = 0;
            button_Nowa_firma.Text = "Dodaj nową firmę";
            button_Nowa_firma.UseVisualStyleBackColor = true;
            button_Nowa_firma.Click += button_Nowa_firma_Click_1;
            // 
            // button_Edytuj_firmy
            // 
            button_Edytuj_firmy.Cursor = Cursors.Hand;
            button_Edytuj_firmy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            button_Edytuj_firmy.Location = new Point(31, 110);
            button_Edytuj_firmy.Name = "button_Edytuj_firmy";
            button_Edytuj_firmy.Size = new Size(160, 55);
            button_Edytuj_firmy.TabIndex = 1;
            button_Edytuj_firmy.Text = "Edytuj dane firmy";
            button_Edytuj_firmy.UseVisualStyleBackColor = true;
            button_Edytuj_firmy.Click += button_Edytuj_firmy_Click;
            // 
            // button_konf_mat
            // 
            button_konf_mat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            button_konf_mat.Location = new Point(31, 190);
            button_konf_mat.Name = "button_konf_mat";
            button_konf_mat.Size = new Size(160, 74);
            button_konf_mat.TabIndex = 2;
            button_konf_mat.Text = "Konfiguruj dane materiałowe";
            button_konf_mat.UseVisualStyleBackColor = true;
            button_konf_mat.Click += button_konf_mat_Click;
            // 
            // comboBox_Nazwa_firmy
            // 
            comboBox_Nazwa_firmy.Font = new Font("Segoe UI", 12F);
            comboBox_Nazwa_firmy.FormattingEnabled = true;
            comboBox_Nazwa_firmy.Location = new Point(366, 43);
            comboBox_Nazwa_firmy.Margin = new Padding(3, 2, 3, 2);
            comboBox_Nazwa_firmy.Name = "comboBox_Nazwa_firmy";
            comboBox_Nazwa_firmy.Size = new Size(486, 23);
            comboBox_Nazwa_firmy.TabIndex = 3;
            comboBox_Nazwa_firmy.SelectedIndexChanged += comboBox_Nazwa_firmy_SelectedIndexChanged;
            // 
            // panel_dane_firmy
            // 
            panel_dane_firmy.Controls.Add(button_usun_firme);
            panel_dane_firmy.Controls.Add(button_zaakceptuj_zmiany);
            panel_dane_firmy.Controls.Add(label_NIP);
            panel_dane_firmy.Controls.Add(textBox_NazwaFirmy);
            panel_dane_firmy.Controls.Add(textBox_NIP_firmy);
            panel_dane_firmy.Controls.Add(label_Numer);
            panel_dane_firmy.Controls.Add(Label_Nazwa_firmy);
            panel_dane_firmy.Controls.Add(label_ulica);
            panel_dane_firmy.Controls.Add(textBox_Numer_firmy);
            panel_dane_firmy.Controls.Add(textBox_Miejscowosc_firmy);
            panel_dane_firmy.Controls.Add(label_kod_pocztowy_firmy);
            panel_dane_firmy.Controls.Add(label_Miejscowosc);
            panel_dane_firmy.Controls.Add(textBox_Ulica_firmy);
            panel_dane_firmy.Controls.Add(textBox_Kod_pocztowy_firmy);
            panel_dane_firmy.Location = new Point(366, 86);
            panel_dane_firmy.Margin = new Padding(3, 2, 3, 2);
            panel_dane_firmy.Name = "panel_dane_firmy";
            panel_dane_firmy.Size = new Size(486, 350);
            panel_dane_firmy.TabIndex = 4;
            panel_dane_firmy.Visible = false;
            // 
            // button_usun_firme
            // 
            button_usun_firme.Cursor = Cursors.Hand;
            button_usun_firme.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            button_usun_firme.Location = new Point(640, 330);
            button_usun_firme.Name = "button_usun_firme";
            button_usun_firme.Size = new Size(160, 55);
            button_usun_firme.TabIndex = 6;
            button_usun_firme.Text = "Usuń firmę";
            button_usun_firme.UseVisualStyleBackColor = true;
            button_usun_firme.Click += button_usun_firme_Click;
            // 
            // button_zaakceptuj_zmiany
            // 
            button_zaakceptuj_zmiany.Cursor = Cursors.Hand;
            button_zaakceptuj_zmiany.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            button_zaakceptuj_zmiany.Location = new Point(640, 215);
            button_zaakceptuj_zmiany.Name = "button_zaakceptuj_zmiany";
            button_zaakceptuj_zmiany.Size = new Size(160, 55);
            button_zaakceptuj_zmiany.TabIndex = 5;
            button_zaakceptuj_zmiany.Text = "Zaakceptuj zmiany";
            button_zaakceptuj_zmiany.UseVisualStyleBackColor = true;
            button_zaakceptuj_zmiany.Click += button_zaakceptuj_zmiany_Click;
            // 
            // label_NIP
            // 
            label_NIP.AutoSize = true;
            label_NIP.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_NIP.Location = new Point(86, 278);
            label_NIP.Name = "label_NIP";
            label_NIP.Size = new Size(37, 21);
            label_NIP.TabIndex = 25;
            label_NIP.Text = "NIP";
            label_NIP.Click += label_NIP_Click;
            // 
            // textBox_NazwaFirmy
            // 
            textBox_NazwaFirmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NazwaFirmy.Location = new Point(136, 22);
            textBox_NazwaFirmy.Name = "textBox_NazwaFirmy";
            textBox_NazwaFirmy.Size = new Size(340, 29);
            textBox_NazwaFirmy.TabIndex = 26;
            textBox_NazwaFirmy.TextChanged += textBox_NazwaFirmy_TextChanged;
            // 
            // textBox_NIP_firmy
            // 
            textBox_NIP_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NIP_firmy.Location = new Point(136, 273);
            textBox_NIP_firmy.Name = "textBox_NIP_firmy";
            textBox_NIP_firmy.Size = new Size(340, 29);
            textBox_NIP_firmy.TabIndex = 19;
            textBox_NIP_firmy.TextChanged += textBox_NIP_firmy_TextChanged;
            // 
            // label_Numer
            // 
            label_Numer.AutoSize = true;
            label_Numer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Numer.Location = new Point(60, 227);
            label_Numer.Name = "label_Numer";
            label_Numer.Size = new Size(59, 21);
            label_Numer.TabIndex = 24;
            label_Numer.Text = "Numer";
            label_Numer.Click += label_Numer_Click;
            // 
            // Label_Nazwa_firmy
            // 
            Label_Nazwa_firmy.AutoSize = true;
            Label_Nazwa_firmy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            Label_Nazwa_firmy.Location = new Point(14, 26);
            Label_Nazwa_firmy.Name = "Label_Nazwa_firmy";
            Label_Nazwa_firmy.Size = new Size(102, 21);
            Label_Nazwa_firmy.TabIndex = 20;
            Label_Nazwa_firmy.Text = "Nazwa firmy";
            Label_Nazwa_firmy.Click += Label_Nazwa_firmy_Click;
            // 
            // label_ulica
            // 
            label_ulica.AutoSize = true;
            label_ulica.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_ulica.Location = new Point(74, 177);
            label_ulica.Name = "label_ulica";
            label_ulica.Size = new Size(47, 21);
            label_ulica.TabIndex = 23;
            label_ulica.Text = "Ulica";
            label_ulica.Click += label_ulica_Click;
            // 
            // textBox_Numer_firmy
            // 
            textBox_Numer_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Numer_firmy.Location = new Point(136, 223);
            textBox_Numer_firmy.Name = "textBox_Numer_firmy";
            textBox_Numer_firmy.Size = new Size(340, 29);
            textBox_Numer_firmy.TabIndex = 18;
            textBox_Numer_firmy.TextChanged += textBox_Numer_firmy_TextChanged;
            // 
            // textBox_Miejscowosc_firmy
            // 
            textBox_Miejscowosc_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Miejscowosc_firmy.Location = new Point(136, 72);
            textBox_Miejscowosc_firmy.Name = "textBox_Miejscowosc_firmy";
            textBox_Miejscowosc_firmy.Size = new Size(340, 29);
            textBox_Miejscowosc_firmy.TabIndex = 15;
            textBox_Miejscowosc_firmy.TextChanged += textBox_Miejscowosc_firmy_TextChanged;
            // 
            // label_kod_pocztowy_firmy
            // 
            label_kod_pocztowy_firmy.AutoSize = true;
            label_kod_pocztowy_firmy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_kod_pocztowy_firmy.Location = new Point(7, 127);
            label_kod_pocztowy_firmy.Name = "label_kod_pocztowy_firmy";
            label_kod_pocztowy_firmy.Size = new Size(110, 21);
            label_kod_pocztowy_firmy.TabIndex = 22;
            label_kod_pocztowy_firmy.Text = "Kod pocztowy";
            label_kod_pocztowy_firmy.Click += label_kod_pocztowy_firmy_Click;
            // 
            // label_Miejscowosc
            // 
            label_Miejscowosc.AutoSize = true;
            label_Miejscowosc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Miejscowosc.Location = new Point(19, 76);
            label_Miejscowosc.Name = "label_Miejscowosc";
            label_Miejscowosc.Size = new Size(99, 21);
            label_Miejscowosc.TabIndex = 21;
            label_Miejscowosc.Text = "Miejscowość";
            label_Miejscowosc.Click += label_Miejscowosc_Click;
            // 
            // textBox_Ulica_firmy
            // 
            textBox_Ulica_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Ulica_firmy.Location = new Point(136, 172);
            textBox_Ulica_firmy.Name = "textBox_Ulica_firmy";
            textBox_Ulica_firmy.Size = new Size(340, 29);
            textBox_Ulica_firmy.TabIndex = 17;
            textBox_Ulica_firmy.TextChanged += textBox_Ulica_firmy_TextChanged;
            // 
            // textBox_Kod_pocztowy_firmy
            // 
            textBox_Kod_pocztowy_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Kod_pocztowy_firmy.Location = new Point(136, 122);
            textBox_Kod_pocztowy_firmy.Name = "textBox_Kod_pocztowy_firmy";
            textBox_Kod_pocztowy_firmy.Size = new Size(340, 29);
            textBox_Kod_pocztowy_firmy.TabIndex = 16;
            textBox_Kod_pocztowy_firmy.TextChanged += textBox_Kod_pocztowy_firmy_TextChanged;
            // 
            // btn_Dostawa
            // 
            btn_Dostawa.Location = new Point(31, 283);
            btn_Dostawa.Name = "btn_Dostawa";
            btn_Dostawa.Size = new Size(160, 64);
            btn_Dostawa.TabIndex = 5;
            btn_Dostawa.Text = "Dodaj/Edytuj dostawę";
            btn_Dostawa.UseVisualStyleBackColor = true;
            btn_Dostawa.Click += btn_Dostawa_Click;
            // 
            // Form_ZaoLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 498);
            Controls.Add(btn_Dostawa);
            Controls.Add(panel_dane_firmy);
            Controls.Add(comboBox_Nazwa_firmy);
            Controls.Add(button_Edytuj_firmy);
            Controls.Add(button_Nowa_firma);
            Name = "Form_ZaoLog";
            Text = "Zaopatrzenie i logistyka";
            Load += Form_ZaoLog_Load;
            panel_dane_firmy.ResumeLayout(false);
            panel_dane_firmy.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button_Nowa_firma;
        private Button button_Edytuj_firmy;
        private ComboBox comboBox_Nazwa_firmy;
        private Panel panel_dane_firmy;
        private TextBox textBox_NazwaFirmy;
        private Label label_NIP;
        private Label label_Numer;
        private Label label_ulica;
        private Label label_kod_pocztowy_firmy;
        private Label label_Miejscowosc;
        private Label Label_Nazwa_firmy;
        private TextBox textBox_NIP_firmy;
        private TextBox textBox_Numer_firmy;
        private TextBox textBox_Ulica_firmy;
        private TextBox textBox_Kod_pocztowy_firmy;
        private TextBox textBox_Miejscowosc_firmy;
        private Button btn_Dostawa;
        private Button button_usun_firme;
        private Button button_zaakceptuj_zmiany;
    }
}