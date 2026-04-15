
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
            SuspendLayout();
            // 
            // textBox_Miejscowosc_firmy
            // 
            textBox_Miejscowosc_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Miejscowosc_firmy.Location = new Point(145, 104);
            textBox_Miejscowosc_firmy.Name = "textBox_Miejscowosc_firmy";
            textBox_Miejscowosc_firmy.Size = new Size(340, 29);
            textBox_Miejscowosc_firmy.TabIndex = 1;
            textBox_Miejscowosc_firmy.TextChanged += textBox_Miejscowosc_firmy_TextChanged;
            // 
            // textBox_Ulica_firmy
            // 
            textBox_Ulica_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Ulica_firmy.Location = new Point(145, 246);
            textBox_Ulica_firmy.Name = "textBox_Ulica_firmy";
            textBox_Ulica_firmy.Size = new Size(340, 29);
            textBox_Ulica_firmy.TabIndex = 3;
            textBox_Ulica_firmy.TextChanged += textBox_Ulica_firmy_TextChanged;
            // 
            // textBox_Kod_pocztowy_firmy
            // 
            textBox_Kod_pocztowy_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Kod_pocztowy_firmy.Location = new Point(145, 175);
            textBox_Kod_pocztowy_firmy.Name = "textBox_Kod_pocztowy_firmy";
            textBox_Kod_pocztowy_firmy.Size = new Size(340, 29);
            textBox_Kod_pocztowy_firmy.TabIndex = 2;
            textBox_Kod_pocztowy_firmy.TextChanged += textBox_Kod_pocztowy_firmy_TextChanged;
            // 
            // textBox_NIP_firmy
            // 
            textBox_NIP_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NIP_firmy.Location = new Point(145, 388);
            textBox_NIP_firmy.Name = "textBox_NIP_firmy";
            textBox_NIP_firmy.Size = new Size(340, 29);
            textBox_NIP_firmy.TabIndex = 5;
            textBox_NIP_firmy.TextChanged += textBox_NIP_firmy_TextChanged;
            // 
            // textBox_Numer_firmy
            // 
            textBox_Numer_firmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Numer_firmy.Location = new Point(145, 317);
            textBox_Numer_firmy.Name = "textBox_Numer_firmy";
            textBox_Numer_firmy.Size = new Size(340, 29);
            textBox_Numer_firmy.TabIndex = 4;
            textBox_Numer_firmy.TextChanged += textBox_Numer_firmy_TextChanged;
            // 
            // Label_Nazwa_firmy
            // 
            Label_Nazwa_firmy.AutoSize = true;
            Label_Nazwa_firmy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            Label_Nazwa_firmy.Location = new Point(37, 32);
            Label_Nazwa_firmy.Name = "Label_Nazwa_firmy";
            Label_Nazwa_firmy.Size = new Size(102, 21);
            Label_Nazwa_firmy.TabIndex = 7;
            Label_Nazwa_firmy.Text = "Nazwa firmy";
            Label_Nazwa_firmy.Click += Label_Nazwa_firmy_Click;
            // 
            // label_Miejscowosc
            // 
            label_Miejscowosc.AutoSize = true;
            label_Miejscowosc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Miejscowosc.Location = new Point(40, 104);
            label_Miejscowosc.Name = "label_Miejscowosc";
            label_Miejscowosc.Size = new Size(99, 21);
            label_Miejscowosc.TabIndex = 8;
            label_Miejscowosc.Text = "Miejscowość";
            label_Miejscowosc.Click += label_Miejscowosc_Click;
            // 
            // label_kod_pocztowy_firmy
            // 
            label_kod_pocztowy_firmy.AutoSize = true;
            label_kod_pocztowy_firmy.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_kod_pocztowy_firmy.Location = new Point(29, 176);
            label_kod_pocztowy_firmy.Name = "label_kod_pocztowy_firmy";
            label_kod_pocztowy_firmy.Size = new Size(110, 21);
            label_kod_pocztowy_firmy.TabIndex = 9;
            label_kod_pocztowy_firmy.Text = "Kod pocztowy";
            label_kod_pocztowy_firmy.Click += label_kod_pocztowy_firmy_Click;
            // 
            // label_ulica
            // 
            label_ulica.AutoSize = true;
            label_ulica.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_ulica.Location = new Point(92, 248);
            label_ulica.Name = "label_ulica";
            label_ulica.Size = new Size(47, 21);
            label_ulica.TabIndex = 10;
            label_ulica.Text = "Ulica";
            label_ulica.Click += label_ulica_Click;
            // 
            // label_Numer
            // 
            label_Numer.AutoSize = true;
            label_Numer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Numer.Location = new Point(80, 320);
            label_Numer.Name = "label_Numer";
            label_Numer.Size = new Size(59, 21);
            label_Numer.TabIndex = 11;
            label_Numer.Text = "Numer";
            label_Numer.Click += label1_Click;
            // 
            // label_NIP
            // 
            label_NIP.AutoSize = true;
            label_NIP.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_NIP.Location = new Point(102, 392);
            label_NIP.Name = "label_NIP";
            label_NIP.Size = new Size(37, 21);
            label_NIP.TabIndex = 12;
            label_NIP.Text = "NIP";
            label_NIP.Click += label_NIP_Click;
            // 
            // button_Dodaj_nowa_firme
            // 
            button_Dodaj_nowa_firme.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            button_Dodaj_nowa_firme.Location = new Point(525, 188);
            button_Dodaj_nowa_firme.Name = "button_Dodaj_nowa_firme";
            button_Dodaj_nowa_firme.Size = new Size(246, 81);
            button_Dodaj_nowa_firme.TabIndex = 13;
            button_Dodaj_nowa_firme.Text = "Dodaj nowa firmę";
            button_Dodaj_nowa_firme.UseVisualStyleBackColor = true;
            button_Dodaj_nowa_firme.Click += button_Dodaj_nowa_firme_Click;
            // 
            // textBox_NazwaFirmy
            // 
            textBox_NazwaFirmy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NazwaFirmy.Location = new Point(145, 33);
            textBox_NazwaFirmy.Name = "textBox_NazwaFirmy";
            textBox_NazwaFirmy.Size = new Size(340, 29);
            textBox_NazwaFirmy.TabIndex = 14;
            textBox_NazwaFirmy.TextChanged += textBox_NazwaFirmy_TextChanged;
            // 
            // Form_Nowa_Firma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "Form_Nowa_Firma";
            Text = "Nowa_Firma";
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
    }
}