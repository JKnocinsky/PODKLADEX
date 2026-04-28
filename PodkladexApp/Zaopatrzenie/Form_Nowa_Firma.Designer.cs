
namespace PodkladexApp
{
    partial class Form_Nowa_Firma
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
            textBox_Miejscowosc_firmy = new TextBox();
            textBox_Ulica_firmy = new TextBox();
            textBox_Kod_pocztowy_firmy = new TextBox();
            textBox_NIP_firmy = new TextBox();
            textBox_Numer_firmy = new TextBox();
            Label_Nazwa_firmy = new Label();
            label_Miejscowosc = new Label();
            label_kod_pocztowy_firmy = new Label();
            label_ulica = new Label();
            label_Numer = new Label();
            label_NIP = new Label();
            button_Dodaj_nowa_firme = new Button();
            textBox_NazwaFirmy = new TextBox();
            button_Wyczysc = new Button();
            SuspendLayout();
            // 
            // textBox_Miejscowosc_firmy
            // 
            textBox_Miejscowosc_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Miejscowosc_firmy.Location = new Point(162, 109);
            textBox_Miejscowosc_firmy.Margin = new Padding(3, 4, 3, 4);
            textBox_Miejscowosc_firmy.Name = "textBox_Miejscowosc_firmy";
            textBox_Miejscowosc_firmy.Size = new Size(388, 34);
            textBox_Miejscowosc_firmy.TabIndex = 1;
            textBox_Miejscowosc_firmy.TextChanged += textBox_Miejscowosc_firmy_TextChanged;
            // 
            // textBox_Ulica_firmy
            // 
            textBox_Ulica_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Ulica_firmy.Location = new Point(162, 298);
            textBox_Ulica_firmy.Margin = new Padding(3, 4, 3, 4);
            textBox_Ulica_firmy.Name = "textBox_Ulica_firmy";
            textBox_Ulica_firmy.Size = new Size(388, 34);
            textBox_Ulica_firmy.TabIndex = 3;
            textBox_Ulica_firmy.TextChanged += textBox_Ulica_firmy_TextChanged;
            // 
            // textBox_Kod_pocztowy_firmy
            // 
            textBox_Kod_pocztowy_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Kod_pocztowy_firmy.Location = new Point(162, 203);
            textBox_Kod_pocztowy_firmy.Margin = new Padding(3, 4, 3, 4);
            textBox_Kod_pocztowy_firmy.Name = "textBox_Kod_pocztowy_firmy";
            textBox_Kod_pocztowy_firmy.Size = new Size(388, 34);
            textBox_Kod_pocztowy_firmy.TabIndex = 2;
            textBox_Kod_pocztowy_firmy.TextChanged += textBox_Kod_pocztowy_firmy_TextChanged;
            // 
            // textBox_NIP_firmy
            // 
            textBox_NIP_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NIP_firmy.Location = new Point(162, 487);
            textBox_NIP_firmy.Margin = new Padding(3, 4, 3, 4);
            textBox_NIP_firmy.Name = "textBox_NIP_firmy";
            textBox_NIP_firmy.Size = new Size(388, 34);
            textBox_NIP_firmy.TabIndex = 5;
            textBox_NIP_firmy.TextChanged += textBox_NIP_firmy_TextChanged;
            // 
            // textBox_Numer_firmy
            // 
            textBox_Numer_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Numer_firmy.Location = new Point(162, 393);
            textBox_Numer_firmy.Margin = new Padding(3, 4, 3, 4);
            textBox_Numer_firmy.Name = "textBox_Numer_firmy";
            textBox_Numer_firmy.Size = new Size(388, 34);
            textBox_Numer_firmy.TabIndex = 4;
            textBox_Numer_firmy.TextChanged += textBox_Numer_firmy_TextChanged;
            // 
            // Label_Nazwa_firmy
            // 
            Label_Nazwa_firmy.AutoSize = true;
            Label_Nazwa_firmy.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic);
            Label_Nazwa_firmy.Location = new Point(8, 9);
            Label_Nazwa_firmy.Name = "Label_Nazwa_firmy";
            Label_Nazwa_firmy.Size = new Size(148, 31);
            Label_Nazwa_firmy.TabIndex = 7;
            Label_Nazwa_firmy.Text = "Nazwa firmy";
            Label_Nazwa_firmy.Click += Label_Nazwa_firmy_Click;
            // 
            // label_Miejscowosc
            // 
            label_Miejscowosc.AutoSize = true;
            label_Miejscowosc.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic);
            label_Miejscowosc.Location = new Point(12, 105);
            label_Miejscowosc.Name = "label_Miejscowosc";
            label_Miejscowosc.Size = new Size(141, 31);
            label_Miejscowosc.TabIndex = 8;
            label_Miejscowosc.Text = "Miejscowość";
            label_Miejscowosc.Click += label_Miejscowosc_Click;
            // 
            // label_kod_pocztowy_firmy
            // 
            label_kod_pocztowy_firmy.AutoSize = true;
            label_kod_pocztowy_firmy.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic);
            label_kod_pocztowy_firmy.Location = new Point(-1, 201);
            label_kod_pocztowy_firmy.Name = "label_kod_pocztowy_firmy";
            label_kod_pocztowy_firmy.Size = new Size(157, 31);
            label_kod_pocztowy_firmy.TabIndex = 9;
            label_kod_pocztowy_firmy.Text = "Kod pocztowy";
            label_kod_pocztowy_firmy.Click += label_kod_pocztowy_firmy_Click;
            // 
            // label_ulica
            // 
            label_ulica.AutoSize = true;
            label_ulica.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic);
            label_ulica.Location = new Point(71, 297);
            label_ulica.Name = "label_ulica";
            label_ulica.Size = new Size(67, 31);
            label_ulica.TabIndex = 10;
            label_ulica.Text = "Ulica";
            label_ulica.Click += label_ulica_Click;
            // 
            // label_Numer
            // 
            label_Numer.AutoSize = true;
            label_Numer.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic);
            label_Numer.Location = new Point(57, 393);
            label_Numer.Name = "label_Numer";
            label_Numer.Size = new Size(86, 31);
            label_Numer.TabIndex = 11;
            label_Numer.Text = "Numer";
            label_Numer.Click += label1_Click;
            // 
            // label_NIP
            // 
            label_NIP.AutoSize = true;
            label_NIP.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic);
            label_NIP.Location = new Point(83, 489);
            label_NIP.Name = "label_NIP";
            label_NIP.Size = new Size(53, 31);
            label_NIP.TabIndex = 12;
            label_NIP.Text = "NIP";
            label_NIP.Click += label_NIP_Click;
            // 
            // button_Dodaj_nowa_firme
            // 
            button_Dodaj_nowa_firme.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            button_Dodaj_nowa_firme.Location = new Point(632, 14);
            button_Dodaj_nowa_firme.Margin = new Padding(3, 4, 3, 4);
            button_Dodaj_nowa_firme.Name = "button_Dodaj_nowa_firme";
            button_Dodaj_nowa_firme.Size = new Size(234, 84);
            button_Dodaj_nowa_firme.TabIndex = 13;
            button_Dodaj_nowa_firme.Text = "Dodaj nowa firmę";
            button_Dodaj_nowa_firme.UseVisualStyleBackColor = true;
            button_Dodaj_nowa_firme.Click += button_Dodaj_nowa_firme_Click;
            // 
            // textBox_NazwaFirmy
            // 
            textBox_NazwaFirmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NazwaFirmy.Location = new Point(162, 14);
            textBox_NazwaFirmy.Margin = new Padding(3, 4, 3, 4);
            textBox_NazwaFirmy.Name = "textBox_NazwaFirmy";
            textBox_NazwaFirmy.Size = new Size(388, 34);
            textBox_NazwaFirmy.TabIndex = 14;
            textBox_NazwaFirmy.TextChanged += textBox_NazwaFirmy_TextChanged;
            // 
            // button_Wyczysc
            // 
            button_Wyczysc.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            button_Wyczysc.Location = new Point(632, 164);
            button_Wyczysc.Margin = new Padding(3, 4, 3, 4);
            button_Wyczysc.Name = "button_Wyczysc";
            button_Wyczysc.Size = new Size(234, 84);
            button_Wyczysc.TabIndex = 15;
            button_Wyczysc.Text = "Wyczyść pola";
            button_Wyczysc.UseVisualStyleBackColor = true;
            button_Wyczysc.Click += button_Wyczysc_Click;
            // 
            // Form_Nowa_Firma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(button_Wyczysc);
            Controls.Add(textBox_NazwaFirmy);
            Controls.Add(button_Dodaj_nowa_firme);
            Controls.Add(label_NIP);
            Controls.Add(label_Numer);
            Controls.Add(label_ulica);
            Controls.Add(label_kod_pocztowy_firmy);
            Controls.Add(label_Miejscowosc);
            Controls.Add(Label_Nazwa_firmy);
            Controls.Add(textBox_NIP_firmy);
            Controls.Add(textBox_Numer_firmy);
            Controls.Add(textBox_Ulica_firmy);
            Controls.Add(textBox_Kod_pocztowy_firmy);
            Controls.Add(textBox_Miejscowosc_firmy);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_Nowa_Firma";
            Text = "Nowa Firma";
            Load += Nowa_Firma_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void label_kod_pocztowy_firmy_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label_Miejscowosc_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Label_Nazwa_firmy_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox textBox_Miejscowosc_firmy;
        private TextBox textBox_Ulica_firmy;
        private TextBox textBox_Kod_pocztowy_firmy;
        private TextBox textBox_NIP_firmy;
        private TextBox textBox_Numer_firmy;
        private Label Label_Nazwa_firmy;
        private Label label_Miejscowosc;
        private Label label_kod_pocztowy_firmy;
        private Label label_ulica;
        private Label label_Numer;
        private Label label_NIP;
        private Button button_Dodaj_nowa_firme;
        private TextBox textBox_NazwaFirmy;
        private Button button_Wyczysc;
    }
}