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
            button_konf_mat = new Button();
            comboBox_Nazwa_firmy = new ComboBox();
            panel_dane_firmy = new Panel();
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
            panel_dane_firmy.SuspendLayout();
            SuspendLayout();
            // 
            // button_Nowa_firma
            // 
            button_Nowa_firma.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            button_Nowa_firma.Location = new Point(35, 27);
            button_Nowa_firma.Margin = new Padding(3, 4, 3, 4);
            button_Nowa_firma.Name = "button_Nowa_firma";
            button_Nowa_firma.Size = new Size(183, 68);
            button_Nowa_firma.TabIndex = 0;
            button_Nowa_firma.Text = "Dodaj nową firmę";
            button_Nowa_firma.UseVisualStyleBackColor = true;
            button_Nowa_firma.Click += button_Nowa_firma_Click_1;
            // 
            // button_Edytuj_firmy
            // 
            button_Edytuj_firmy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            button_Edytuj_firmy.Location = new Point(35, 147);
            button_Edytuj_firmy.Margin = new Padding(3, 4, 3, 4);
            button_Edytuj_firmy.Name = "button_Edytuj_firmy";
            button_Edytuj_firmy.Size = new Size(183, 73);
            button_Edytuj_firmy.TabIndex = 1;
            button_Edytuj_firmy.Text = "Edytuj dane firmy";
            button_Edytuj_firmy.UseVisualStyleBackColor = true;
            button_Edytuj_firmy.Click += button_Edytuj_firmy_Click;
            // 
            // button_konf_mat
            // 
            button_konf_mat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            button_konf_mat.Location = new Point(35, 254);
            button_konf_mat.Margin = new Padding(3, 4, 3, 4);
            button_konf_mat.Name = "button_konf_mat";
            button_konf_mat.Size = new Size(183, 98);
            button_konf_mat.TabIndex = 2;
            button_konf_mat.Text = "Konfiguruj dane materiałowe";
            button_konf_mat.UseVisualStyleBackColor = true;
            button_konf_mat.Click += button_konf_mat_Click;
            // 
            // comboBox_Nazwa_firmy
            // 
            comboBox_Nazwa_firmy.FormattingEnabled = true;
            comboBox_Nazwa_firmy.Location = new Point(418, 57);
            comboBox_Nazwa_firmy.Name = "comboBox_Nazwa_firmy";
            comboBox_Nazwa_firmy.Size = new Size(555, 28);
            comboBox_Nazwa_firmy.TabIndex = 3;
            comboBox_Nazwa_firmy.SelectedIndexChanged += comboBox_Nazwa_firmy_SelectedIndexChanged;
            // 
            // panel_dane_firmy
            // 
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
            panel_dane_firmy.Location = new Point(418, 114);
            panel_dane_firmy.Name = "panel_dane_firmy";
            panel_dane_firmy.Size = new Size(555, 466);
            panel_dane_firmy.TabIndex = 4;
            panel_dane_firmy.Visible = false;
            // 
            // label_NIP
            // 
            label_NIP.AutoSize = true;
            label_NIP.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_NIP.Location = new Point(98, 370);
            label_NIP.Name = "label_NIP";
            label_NIP.Size = new Size(45, 28);
            label_NIP.TabIndex = 25;
            label_NIP.Text = "NIP";
            label_NIP.Click += label_NIP_Click;
            // 
            // textBox_NazwaFirmy
            // 
            textBox_NazwaFirmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NazwaFirmy.Location = new Point(155, 29);
            textBox_NazwaFirmy.Margin = new Padding(3, 4, 3, 4);
            textBox_NazwaFirmy.Name = "textBox_NazwaFirmy";
            textBox_NazwaFirmy.Size = new Size(388, 34);
            textBox_NazwaFirmy.TabIndex = 26;
            textBox_NazwaFirmy.TextChanged += textBox_NazwaFirmy_TextChanged;
            // 
            // textBox_NIP_firmy
            // 
            textBox_NIP_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NIP_firmy.Location = new Point(155, 364);
            textBox_NIP_firmy.Margin = new Padding(3, 4, 3, 4);
            textBox_NIP_firmy.Name = "textBox_NIP_firmy";
            textBox_NIP_firmy.Size = new Size(388, 34);
            textBox_NIP_firmy.TabIndex = 19;
            textBox_NIP_firmy.TextChanged += textBox_NIP_firmy_TextChanged;
            // 
            // label_Numer
            // 
            label_Numer.AutoSize = true;
            label_Numer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Numer.Location = new Point(68, 303);
            label_Numer.Name = "label_Numer";
            label_Numer.Size = new Size(75, 28);
            label_Numer.TabIndex = 24;
            label_Numer.Text = "Numer";
            label_Numer.Click += label_Numer_Click;
            // 
            // Label_Nazwa_firmy
            // 
            Label_Nazwa_firmy.AutoSize = true;
            Label_Nazwa_firmy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            Label_Nazwa_firmy.Location = new Point(16, 35);
            Label_Nazwa_firmy.Name = "Label_Nazwa_firmy";
            Label_Nazwa_firmy.Size = new Size(127, 28);
            Label_Nazwa_firmy.TabIndex = 20;
            Label_Nazwa_firmy.Text = "Nazwa firmy";
            Label_Nazwa_firmy.Click += Label_Nazwa_firmy_Click;
            // 
            // label_ulica
            // 
            label_ulica.AutoSize = true;
            label_ulica.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_ulica.Location = new Point(85, 236);
            label_ulica.Name = "label_ulica";
            label_ulica.Size = new Size(58, 28);
            label_ulica.TabIndex = 23;
            label_ulica.Text = "Ulica";
            label_ulica.Click += label_ulica_Click;
            // 
            // textBox_Numer_firmy
            // 
            textBox_Numer_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Numer_firmy.Location = new Point(155, 297);
            textBox_Numer_firmy.Margin = new Padding(3, 4, 3, 4);
            textBox_Numer_firmy.Name = "textBox_Numer_firmy";
            textBox_Numer_firmy.Size = new Size(388, 34);
            textBox_Numer_firmy.TabIndex = 18;
            textBox_Numer_firmy.TextChanged += textBox_Numer_firmy_TextChanged;
            // 
            // textBox_Miejscowosc_firmy
            // 
            textBox_Miejscowosc_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Miejscowosc_firmy.Location = new Point(155, 96);
            textBox_Miejscowosc_firmy.Margin = new Padding(3, 4, 3, 4);
            textBox_Miejscowosc_firmy.Name = "textBox_Miejscowosc_firmy";
            textBox_Miejscowosc_firmy.Size = new Size(388, 34);
            textBox_Miejscowosc_firmy.TabIndex = 15;
            textBox_Miejscowosc_firmy.TextChanged += textBox_Miejscowosc_firmy_TextChanged;
            // 
            // label_kod_pocztowy_firmy
            // 
            label_kod_pocztowy_firmy.AutoSize = true;
            label_kod_pocztowy_firmy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_kod_pocztowy_firmy.Location = new Point(8, 169);
            label_kod_pocztowy_firmy.Name = "label_kod_pocztowy_firmy";
            label_kod_pocztowy_firmy.Size = new Size(135, 28);
            label_kod_pocztowy_firmy.TabIndex = 22;
            label_kod_pocztowy_firmy.Text = "Kod pocztowy";
            label_kod_pocztowy_firmy.Click += label_kod_pocztowy_firmy_Click;
            // 
            // label_Miejscowosc
            // 
            label_Miejscowosc.AutoSize = true;
            label_Miejscowosc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Miejscowosc.Location = new Point(22, 102);
            label_Miejscowosc.Name = "label_Miejscowosc";
            label_Miejscowosc.Size = new Size(121, 28);
            label_Miejscowosc.TabIndex = 21;
            label_Miejscowosc.Text = "Miejscowość";
            label_Miejscowosc.Click += label_Miejscowosc_Click;
            // 
            // textBox_Ulica_firmy
            // 
            textBox_Ulica_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Ulica_firmy.Location = new Point(155, 230);
            textBox_Ulica_firmy.Margin = new Padding(3, 4, 3, 4);
            textBox_Ulica_firmy.Name = "textBox_Ulica_firmy";
            textBox_Ulica_firmy.Size = new Size(388, 34);
            textBox_Ulica_firmy.TabIndex = 17;
            textBox_Ulica_firmy.TextChanged += textBox_Ulica_firmy_TextChanged;
            // 
            // textBox_Kod_pocztowy_firmy
            // 
            textBox_Kod_pocztowy_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Kod_pocztowy_firmy.Location = new Point(155, 163);
            textBox_Kod_pocztowy_firmy.Margin = new Padding(3, 4, 3, 4);
            textBox_Kod_pocztowy_firmy.Name = "textBox_Kod_pocztowy_firmy";
            textBox_Kod_pocztowy_firmy.Size = new Size(388, 34);
            textBox_Kod_pocztowy_firmy.TabIndex = 16;
            textBox_Kod_pocztowy_firmy.TextChanged += textBox_Kod_pocztowy_firmy_TextChanged;
            // 
            // Form_ZaoLog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1268, 664);
            Controls.Add(panel_dane_firmy);
            Controls.Add(comboBox_Nazwa_firmy);
            Controls.Add(button_konf_mat);
            Controls.Add(button_Edytuj_firmy);
            Controls.Add(button_Nowa_firma);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_ZaoLog";
            Text = "Form_ZaoLog";
            panel_dane_firmy.ResumeLayout(false);
            panel_dane_firmy.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button_Nowa_firma;
        private Button button_Edytuj_firmy;
        private Button button_konf_mat;
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
    }
}