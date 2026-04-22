namespace PodkladexApp
{
    partial class Form_Gwarancja
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
            comboBox_lista_gwarnacja_maszyny = new ComboBox();
            button_usun_gwarancje = new Button();
            button_edytuj_gwarancje = new Button();
            label_dodajczesc = new Label();
            textBox_warunki_gwarancji = new TextBox();
            button_dodaj_gwarancje = new Button();
            label1 = new Label();
            comboBox_lista_firm = new ComboBox();
            label2 = new Label();
            textBox_miesiace_gwarancji = new TextBox();
            SuspendLayout();
            // 
            // label_lista_rodzajow
            // 
            label_lista_rodzajow.AutoSize = true;
            label_lista_rodzajow.Location = new Point(10, 7);
            label_lista_rodzajow.Name = "label_lista_rodzajow";
            label_lista_rodzajow.Size = new Size(74, 15);
            label_lista_rodzajow.TabIndex = 28;
            label_lista_rodzajow.Text = "Lista maszyn";
            // 
            // comboBox_lista_gwarnacja_maszyny
            // 
            comboBox_lista_gwarnacja_maszyny.FormattingEnabled = true;
            comboBox_lista_gwarnacja_maszyny.Location = new Point(10, 27);
            comboBox_lista_gwarnacja_maszyny.Name = "comboBox_lista_gwarnacja_maszyny";
            comboBox_lista_gwarnacja_maszyny.Size = new Size(187, 23);
            comboBox_lista_gwarnacja_maszyny.TabIndex = 27;
            // 
            // button_usun_gwarancje
            // 
            button_usun_gwarancje.Location = new Point(561, 138);
            button_usun_gwarancje.Name = "button_usun_gwarancje";
            button_usun_gwarancje.Size = new Size(129, 55);
            button_usun_gwarancje.TabIndex = 26;
            button_usun_gwarancje.Text = "Usuń gwarancje";
            button_usun_gwarancje.UseVisualStyleBackColor = true;
            // 
            // button_edytuj_gwarancje
            // 
            button_edytuj_gwarancje.Location = new Point(561, 199);
            button_edytuj_gwarancje.Name = "button_edytuj_gwarancje";
            button_edytuj_gwarancje.Size = new Size(129, 55);
            button_edytuj_gwarancje.TabIndex = 25;
            button_edytuj_gwarancje.Text = "Edytuj gwarancje";
            button_edytuj_gwarancje.UseVisualStyleBackColor = true;
            // 
            // label_dodajczesc
            // 
            label_dodajczesc.AutoSize = true;
            label_dodajczesc.Location = new Point(10, 238);
            label_dodajczesc.Name = "label_dodajczesc";
            label_dodajczesc.Size = new Size(105, 15);
            label_dodajczesc.TabIndex = 24;
            label_dodajczesc.Text = "Warunki gawrancji";
            // 
            // textBox_warunki_gwarancji
            // 
            textBox_warunki_gwarancji.Location = new Point(10, 263);
            textBox_warunki_gwarancji.Name = "textBox_warunki_gwarancji";
            textBox_warunki_gwarancji.Size = new Size(373, 23);
            textBox_warunki_gwarancji.TabIndex = 23;
            // 
            // button_dodaj_gwarancje
            // 
            button_dodaj_gwarancje.Location = new Point(561, 77);
            button_dodaj_gwarancje.Name = "button_dodaj_gwarancje";
            button_dodaj_gwarancje.Size = new Size(129, 55);
            button_dodaj_gwarancje.TabIndex = 22;
            button_dodaj_gwarancje.Text = "Dodaj gwarancje";
            button_dodaj_gwarancje.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(227, 7);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 31;
            label1.Text = "Lista firm";
            // 
            // comboBox_lista_firm
            // 
            comboBox_lista_firm.FormattingEnabled = true;
            comboBox_lista_firm.Location = new Point(227, 27);
            comboBox_lista_firm.Name = "comboBox_lista_firm";
            comboBox_lista_firm.Size = new Size(187, 23);
            comboBox_lista_firm.TabIndex = 30;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 130);
            label2.Name = "label2";
            label2.Size = new Size(184, 15);
            label2.TabIndex = 33;
            label2.Text = "Czas trwania gwarancji (miesiące)";
            // 
            // textBox_miesiace_gwarancji
            // 
            textBox_miesiace_gwarancji.Location = new Point(10, 155);
            textBox_miesiace_gwarancji.Name = "textBox_miesiace_gwarancji";
            textBox_miesiace_gwarancji.Size = new Size(373, 23);
            textBox_miesiace_gwarancji.TabIndex = 32;
            // 
            // Form_Gwarancja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(label2);
            Controls.Add(textBox_miesiace_gwarancji);
            Controls.Add(label1);
            Controls.Add(comboBox_lista_firm);
            Controls.Add(label_lista_rodzajow);
            Controls.Add(comboBox_lista_gwarnacja_maszyny);
            Controls.Add(button_usun_gwarancje);
            Controls.Add(button_edytuj_gwarancje);
            Controls.Add(label_dodajczesc);
            Controls.Add(textBox_warunki_gwarancji);
            Controls.Add(button_dodaj_gwarancje);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_Gwarancja";
            Text = "Gwarancja";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_lista_rodzajow;
        private ComboBox comboBox_lista_gwarnacja_maszyny;
        private Button button_usun_gwarancje;
        private Button button_edytuj_gwarancje;
        private Label label_dodajczesc;
        private TextBox textBox_warunki_gwarancji;
        private Button button_dodaj_gwarancje;
        private Label label1;
        private ComboBox comboBox_lista_firm;
        private Label label2;
        private TextBox textBox_miesiace_gwarancji;
    }
}