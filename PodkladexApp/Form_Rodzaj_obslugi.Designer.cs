namespace PodkladexApp
{
    partial class Form_Rodzaj_obslugi
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
            label_lista_rodzajow = new Label();
            comboBox_lista_rodzaj_obslug = new ComboBox();
            button_usun_obsluga = new Button();
            button_edytuj_czesc = new Button();
            label_dodajczesc = new Label();
            textBox_nazwa_obslugi = new TextBox();
            button_dodaj_obsluge = new Button();
            label1 = new Label();
            textBox_opis_rodzaj_obslugi = new TextBox();
            textBox_opis_obslugi_wyswietlanie = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label_lista_rodzajow
            // 
            label_lista_rodzajow.AutoSize = true;
            label_lista_rodzajow.Location = new Point(10, 118);
            label_lista_rodzajow.Name = "label_lista_rodzajow";
            label_lista_rodzajow.Size = new Size(82, 15);
            label_lista_rodzajow.TabIndex = 16;
            label_lista_rodzajow.Text = "Lista rodzajów";
            // 
            // comboBox_lista_rodzaj_obslug
            // 
            comboBox_lista_rodzaj_obslug.FormattingEnabled = true;
            comboBox_lista_rodzaj_obslug.Location = new Point(10, 136);
            comboBox_lista_rodzaj_obslug.Name = "comboBox_lista_rodzaj_obslug";
            comboBox_lista_rodzaj_obslug.Size = new Size(187, 23);
            comboBox_lista_rodzaj_obslug.TabIndex = 15;
            // 
            // button_usun_obsluga
            // 
            button_usun_obsluga.Location = new Point(561, 118);
            button_usun_obsluga.Name = "button_usun_obsluga";
            button_usun_obsluga.Size = new Size(129, 55);
            button_usun_obsluga.TabIndex = 14;
            button_usun_obsluga.Text = "Usuń rodzaj osbługi";
            button_usun_obsluga.UseVisualStyleBackColor = true;
            // 
            // button_edytuj_czesc
            // 
            button_edytuj_czesc.Location = new Point(561, 199);
            button_edytuj_czesc.Name = "button_edytuj_czesc";
            button_edytuj_czesc.Size = new Size(129, 55);
            button_edytuj_czesc.TabIndex = 13;
            button_edytuj_czesc.Text = "Edytuj rodzaj obsługi";
            button_edytuj_czesc.UseVisualStyleBackColor = true;
            // 
            // label_dodajczesc
            // 
            label_dodajczesc.AutoSize = true;
            label_dodajczesc.Location = new Point(183, 10);
            label_dodajczesc.Name = "label_dodajczesc";
            label_dodajczesc.Size = new Size(84, 15);
            label_dodajczesc.TabIndex = 12;
            label_dodajczesc.Text = "Nazwa obsługi";
            // 
            // textBox_nazwa_obslugi
            // 
            textBox_nazwa_obslugi.Location = new Point(183, 28);
            textBox_nazwa_obslugi.Name = "textBox_nazwa_obslugi";
            textBox_nazwa_obslugi.Size = new Size(373, 23);
            textBox_nazwa_obslugi.TabIndex = 11;
            // 
            // button_dodaj_obsluge
            // 
            button_dodaj_obsluge.Location = new Point(10, 10);
            button_dodaj_obsluge.Name = "button_dodaj_obsluge";
            button_dodaj_obsluge.Size = new Size(129, 55);
            button_dodaj_obsluge.TabIndex = 10;
            button_dodaj_obsluge.Text = "Dodaj rodzaj obsługi";
            button_dodaj_obsluge.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(183, 52);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 19;
            label1.Text = "Opis";
            // 
            // textBox_opis_rodzaj_obslugi
            // 
            textBox_opis_rodzaj_obslugi.Location = new Point(183, 70);
            textBox_opis_rodzaj_obslugi.Name = "textBox_opis_rodzaj_obslugi";
            textBox_opis_rodzaj_obslugi.Size = new Size(375, 23);
            textBox_opis_rodzaj_obslugi.TabIndex = 18;
            // 
            // textBox_opis_obslugi_wyswietlanie
            // 
            textBox_opis_obslugi_wyswietlanie.Location = new Point(202, 136);
            textBox_opis_obslugi_wyswietlanie.Name = "textBox_opis_obslugi_wyswietlanie";
            textBox_opis_obslugi_wyswietlanie.Size = new Size(354, 23);
            textBox_opis_obslugi_wyswietlanie.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(202, 118);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 21;
            label2.Text = "Opis";
            // 
            // Form_Rodzaj_obslugi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(label2);
            Controls.Add(textBox_opis_obslugi_wyswietlanie);
            Controls.Add(label1);
            Controls.Add(textBox_opis_rodzaj_obslugi);
            Controls.Add(label_lista_rodzajow);
            Controls.Add(comboBox_lista_rodzaj_obslug);
            Controls.Add(button_usun_obsluga);
            Controls.Add(button_edytuj_czesc);
            Controls.Add(label_dodajczesc);
            Controls.Add(textBox_nazwa_obslugi);
            Controls.Add(button_dodaj_obsluge);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_Rodzaj_obslugi";
            Text = "Rodzaj obsługi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_lista_rodzajow;
        private ComboBox comboBox_lista_rodzaj_obslug;
        private Button button_usun_obsluga;
        private Button button_edytuj_czesc;
        private Label label_dodajczesc;
        private TextBox textBox_nazwa_obslugi;
        private Button button_dodaj_obsluge;
        private Label label1;
        private TextBox textBox_opis_rodzaj_obslugi;
        private TextBox textBox_opis_obslugi_wyswietlanie;
        private Label label2;
    }
}