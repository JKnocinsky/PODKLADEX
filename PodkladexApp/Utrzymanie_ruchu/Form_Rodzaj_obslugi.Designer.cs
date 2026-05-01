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
            SuspendLayout();
            // 
            // label_lista_rodzajow
            // 
            label_lista_rodzajow.AutoSize = true;
            label_lista_rodzajow.Font = new Font("Segoe UI", 14F);
            label_lista_rodzajow.Location = new Point(205, 20);
            label_lista_rodzajow.Name = "label_lista_rodzajow";
            label_lista_rodzajow.Size = new Size(164, 32);
            label_lista_rodzajow.TabIndex = 16;
            label_lista_rodzajow.Text = "Lista rodzajów";
            // 
            // comboBox_lista_rodzaj_obslug
            // 
            comboBox_lista_rodzaj_obslug.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_lista_rodzaj_obslug.Font = new Font("Segoe UI", 14F);
            comboBox_lista_rodzaj_obslug.FormattingEnabled = true;
            comboBox_lista_rodzaj_obslug.Location = new Point(208, 56);
            comboBox_lista_rodzaj_obslug.Margin = new Padding(3, 4, 3, 4);
            comboBox_lista_rodzaj_obslug.Name = "comboBox_lista_rodzaj_obslug";
            comboBox_lista_rodzaj_obslug.Size = new Size(426, 39);
            comboBox_lista_rodzaj_obslug.TabIndex = 15;
            comboBox_lista_rodzaj_obslug.SelectedIndexChanged += comboBox_lista_rodzaj_obslug_SeletedIndexChanged;
            // 
            // button_usun_obsluga
            // 
            button_usun_obsluga.Font = new Font("Segoe UI", 14F);
            button_usun_obsluga.Location = new Point(9, 201);
            button_usun_obsluga.Margin = new Padding(3, 4, 3, 4);
            button_usun_obsluga.Name = "button_usun_obsluga";
            button_usun_obsluga.Size = new Size(192, 95);
            button_usun_obsluga.TabIndex = 14;
            button_usun_obsluga.Text = "Usuń rodzaj obsługi";
            button_usun_obsluga.UseVisualStyleBackColor = true;
            button_usun_obsluga.Click += button_usun_obsluga_Click;
            // 
            // button_edytuj_czesc
            // 
            button_edytuj_czesc.Font = new Font("Segoe UI", 14F);
            button_edytuj_czesc.Location = new Point(10, 108);
            button_edytuj_czesc.Margin = new Padding(3, 4, 3, 4);
            button_edytuj_czesc.Name = "button_edytuj_czesc";
            button_edytuj_czesc.Size = new Size(192, 85);
            button_edytuj_czesc.TabIndex = 13;
            button_edytuj_czesc.Text = "Edytuj rodzaj obsługi";
            button_edytuj_czesc.UseVisualStyleBackColor = true;
            button_edytuj_czesc.Click += button_edytuj_czesc_Click;
            // 
            // label_dodajczesc
            // 
            label_dodajczesc.AutoSize = true;
            label_dodajczesc.Font = new Font("Segoe UI", 14F);
            label_dodajczesc.Location = new Point(651, 16);
            label_dodajczesc.Name = "label_dodajczesc";
            label_dodajczesc.Size = new Size(170, 32);
            label_dodajczesc.TabIndex = 12;
            label_dodajczesc.Text = "Nazwa obsługi";
            // 
            // textBox_nazwa_obslugi
            // 
            textBox_nazwa_obslugi.Font = new Font("Segoe UI", 14F);
            textBox_nazwa_obslugi.Location = new Point(651, 56);
            textBox_nazwa_obslugi.Margin = new Padding(3, 4, 3, 4);
            textBox_nazwa_obslugi.Name = "textBox_nazwa_obslugi";
            textBox_nazwa_obslugi.Size = new Size(426, 39);
            textBox_nazwa_obslugi.TabIndex = 11;
            // 
            // button_dodaj_obsluge
            // 
            button_dodaj_obsluge.Font = new Font("Segoe UI", 14F);
            button_dodaj_obsluge.Location = new Point(10, 13);
            button_dodaj_obsluge.Margin = new Padding(3, 4, 3, 4);
            button_dodaj_obsluge.Name = "button_dodaj_obsluge";
            button_dodaj_obsluge.Size = new Size(192, 87);
            button_dodaj_obsluge.TabIndex = 10;
            button_dodaj_obsluge.Text = "Dodaj rodzaj obsługi";
            button_dodaj_obsluge.UseVisualStyleBackColor = true;
            button_dodaj_obsluge.Click += button_dodaj_obsluge_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(651, 99);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 19;
            label1.Text = "Opis";
            // 
            // textBox_opis_rodzaj_obslugi
            // 
            textBox_opis_rodzaj_obslugi.Font = new Font("Segoe UI", 14F);
            textBox_opis_rodzaj_obslugi.Location = new Point(651, 135);
            textBox_opis_rodzaj_obslugi.Margin = new Padding(3, 4, 3, 4);
            textBox_opis_rodzaj_obslugi.Multiline = true;
            textBox_opis_rodzaj_obslugi.Name = "textBox_opis_rodzaj_obslugi";
            textBox_opis_rodzaj_obslugi.Size = new Size(426, 75);
            textBox_opis_rodzaj_obslugi.TabIndex = 18;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(10, 304);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(192, 73);
            button1.TabIndex = 20;
            button1.Text = "Potwierdź zmiany";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form_Rodzaj_obslugi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 451);
            Controls.Add(textBox_nazwa_obslugi);
            Controls.Add(label_lista_rodzajow);
            Controls.Add(label_dodajczesc);
            Controls.Add(textBox_opis_rodzaj_obslugi);
            Controls.Add(comboBox_lista_rodzaj_obslug);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(button_usun_obsluga);
            Controls.Add(button_edytuj_czesc);
            Controls.Add(button_dodaj_obsluge);
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
        private Button button1;
    }
}