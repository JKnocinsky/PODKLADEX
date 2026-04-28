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
            button1 = new Button();
            panel_lista_rodzajow = new Panel();
            panel_nazwa_opis = new Panel();
            panel_lista_rodzajow.SuspendLayout();
            panel_nazwa_opis.SuspendLayout();
            SuspendLayout();
            // 
            // label_lista_rodzajow
            // 
            label_lista_rodzajow.AutoSize = true;
            label_lista_rodzajow.Font = new Font("Segoe UI", 14F);
            label_lista_rodzajow.Location = new Point(3, 4);
            label_lista_rodzajow.Name = "label_lista_rodzajow";
            label_lista_rodzajow.Size = new Size(133, 25);
            label_lista_rodzajow.TabIndex = 16;
            label_lista_rodzajow.Text = "Lista rodzajów";
            // 
            // comboBox_lista_rodzaj_obslug
            // 
            comboBox_lista_rodzaj_obslug.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_lista_rodzaj_obslug.Font = new Font("Segoe UI", 14F);
            comboBox_lista_rodzaj_obslug.FormattingEnabled = true;
            comboBox_lista_rodzaj_obslug.Location = new Point(3, 32);
            comboBox_lista_rodzaj_obslug.Name = "comboBox_lista_rodzaj_obslug";
            comboBox_lista_rodzaj_obslug.Size = new Size(373, 33);
            comboBox_lista_rodzaj_obslug.TabIndex = 15;
            // 
            // button_usun_obsluga
            // 
            button_usun_obsluga.Font = new Font("Segoe UI", 14F);
            button_usun_obsluga.Location = new Point(8, 151);
            button_usun_obsluga.Name = "button_usun_obsluga";
            button_usun_obsluga.Size = new Size(168, 71);
            button_usun_obsluga.TabIndex = 14;
            button_usun_obsluga.Text = "Usuń rodzaj obsługi";
            button_usun_obsluga.UseVisualStyleBackColor = true;
            button_usun_obsluga.Click += button_usun_obsluga_Click;
            // 
            // button_edytuj_czesc
            // 
            button_edytuj_czesc.Font = new Font("Segoe UI", 14F);
            button_edytuj_czesc.Location = new Point(9, 81);
            button_edytuj_czesc.Name = "button_edytuj_czesc";
            button_edytuj_czesc.Size = new Size(168, 64);
            button_edytuj_czesc.TabIndex = 13;
            button_edytuj_czesc.Text = "Edytuj rodzaj obsługi";
            button_edytuj_czesc.UseVisualStyleBackColor = true;
            button_edytuj_czesc.Click += button_edytuj_czesc_Click;
            // 
            // label_dodajczesc
            // 
            label_dodajczesc.AutoSize = true;
            label_dodajczesc.Font = new Font("Segoe UI", 14F);
            label_dodajczesc.Location = new Point(3, 3);
            label_dodajczesc.Name = "label_dodajczesc";
            label_dodajczesc.Size = new Size(136, 25);
            label_dodajczesc.TabIndex = 12;
            label_dodajczesc.Text = "Nazwa obsługi";
            // 
            // textBox_nazwa_obslugi
            // 
            textBox_nazwa_obslugi.Font = new Font("Segoe UI", 14F);
            textBox_nazwa_obslugi.Location = new Point(3, 33);
            textBox_nazwa_obslugi.Name = "textBox_nazwa_obslugi";
            textBox_nazwa_obslugi.Size = new Size(373, 32);
            textBox_nazwa_obslugi.TabIndex = 11;
            // 
            // button_dodaj_obsluge
            // 
            button_dodaj_obsluge.Font = new Font("Segoe UI", 14F);
            button_dodaj_obsluge.Location = new Point(9, 10);
            button_dodaj_obsluge.Name = "button_dodaj_obsluge";
            button_dodaj_obsluge.Size = new Size(168, 65);
            button_dodaj_obsluge.TabIndex = 10;
            button_dodaj_obsluge.Text = "Dodaj rodzaj obsługi";
            button_dodaj_obsluge.UseVisualStyleBackColor = true;
            button_dodaj_obsluge.Click += button_dodaj_obsluge_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(3, 65);
            label1.Name = "label1";
            label1.Size = new Size(50, 25);
            label1.TabIndex = 19;
            label1.Text = "Opis";
            // 
            // textBox_opis_rodzaj_obslugi
            // 
            textBox_opis_rodzaj_obslugi.Font = new Font("Segoe UI", 14F);
            textBox_opis_rodzaj_obslugi.Location = new Point(3, 92);
            textBox_opis_rodzaj_obslugi.Name = "textBox_opis_rodzaj_obslugi";
            textBox_opis_rodzaj_obslugi.Size = new Size(373, 32);
            textBox_opis_rodzaj_obslugi.TabIndex = 18;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(9, 228);
            button1.Name = "button1";
            button1.Size = new Size(168, 55);
            button1.TabIndex = 20;
            button1.Text = "Potwierdź zmiany";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel_lista_rodzajow
            // 
            panel_lista_rodzajow.Controls.Add(comboBox_lista_rodzaj_obslug);
            panel_lista_rodzajow.Controls.Add(label_lista_rodzajow);
            panel_lista_rodzajow.Location = new Point(182, 10);
            panel_lista_rodzajow.Margin = new Padding(3, 2, 3, 2);
            panel_lista_rodzajow.Name = "panel_lista_rodzajow";
            panel_lista_rodzajow.Size = new Size(423, 84);
            panel_lista_rodzajow.TabIndex = 21;
            // 
            // panel_nazwa_opis
            // 
            panel_nazwa_opis.Controls.Add(textBox_nazwa_obslugi);
            panel_nazwa_opis.Controls.Add(label_dodajczesc);
            panel_nazwa_opis.Controls.Add(textBox_opis_rodzaj_obslugi);
            panel_nazwa_opis.Controls.Add(label1);
            panel_nazwa_opis.Location = new Point(182, 98);
            panel_nazwa_opis.Margin = new Padding(3, 2, 3, 2);
            panel_nazwa_opis.Name = "panel_nazwa_opis";
            panel_nazwa_opis.Size = new Size(423, 135);
            panel_nazwa_opis.TabIndex = 22;
            // 
            // Form_Rodzaj_obslugi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(panel_nazwa_opis);
            Controls.Add(panel_lista_rodzajow);
            Controls.Add(button1);
            Controls.Add(button_usun_obsluga);
            Controls.Add(button_edytuj_czesc);
            Controls.Add(button_dodaj_obsluge);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_Rodzaj_obslugi";
            Text = "Rodzaj obsługi";
            panel_lista_rodzajow.ResumeLayout(false);
            panel_lista_rodzajow.PerformLayout();
            panel_nazwa_opis.ResumeLayout(false);
            panel_nazwa_opis.PerformLayout();
            ResumeLayout(false);
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
        private Button button1;
        private Panel panel_lista_rodzajow;
        private Panel panel_nazwa_opis;
    }
}