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
            button_potwierdz = new Button();
            dataGridView_gwarancja_info = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            textBox_uruchomienie = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView_gwarancja_info).BeginInit();
            SuspendLayout();
            // 
            // label_lista_rodzajow
            // 
            label_lista_rodzajow.AutoSize = true;
            label_lista_rodzajow.Font = new Font("Segoe UI", 14F);
            label_lista_rodzajow.Location = new Point(223, 11);
            label_lista_rodzajow.Name = "label_lista_rodzajow";
            label_lista_rodzajow.Size = new Size(107, 32);
            label_lista_rodzajow.TabIndex = 28;
            label_lista_rodzajow.Text = "Maszyna";
            // 
            // comboBox_lista_gwarnacja_maszyny
            // 
            comboBox_lista_gwarnacja_maszyny.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_lista_gwarnacja_maszyny.Font = new Font("Segoe UI", 14F);
            comboBox_lista_gwarnacja_maszyny.FormattingEnabled = true;
            comboBox_lista_gwarnacja_maszyny.Location = new Point(223, 48);
            comboBox_lista_gwarnacja_maszyny.Margin = new Padding(3, 4, 3, 4);
            comboBox_lista_gwarnacja_maszyny.Name = "comboBox_lista_gwarnacja_maszyny";
            comboBox_lista_gwarnacja_maszyny.Size = new Size(259, 39);
            comboBox_lista_gwarnacja_maszyny.TabIndex = 27;
            // 
            // button_usun_gwarancje
            // 
            button_usun_gwarancje.Font = new Font("Segoe UI", 14F);
            button_usun_gwarancje.Location = new Point(14, 89);
            button_usun_gwarancje.Margin = new Padding(3, 4, 3, 4);
            button_usun_gwarancje.Name = "button_usun_gwarancje";
            button_usun_gwarancje.Size = new Size(190, 73);
            button_usun_gwarancje.TabIndex = 26;
            button_usun_gwarancje.Text = "Usuń gwarancje";
            button_usun_gwarancje.UseVisualStyleBackColor = true;
            button_usun_gwarancje.Click += button_usun_gwarancje_Click;
            // 
            // button_edytuj_gwarancje
            // 
            button_edytuj_gwarancje.Font = new Font("Segoe UI", 14F);
            button_edytuj_gwarancje.Location = new Point(14, 171);
            button_edytuj_gwarancje.Margin = new Padding(3, 4, 3, 4);
            button_edytuj_gwarancje.Name = "button_edytuj_gwarancje";
            button_edytuj_gwarancje.Size = new Size(190, 73);
            button_edytuj_gwarancje.TabIndex = 25;
            button_edytuj_gwarancje.Text = "Edytuj gwarancje";
            button_edytuj_gwarancje.UseVisualStyleBackColor = true;
            button_edytuj_gwarancje.Click += button_edytuj_gwarancje_Click;
            // 
            // label_dodajczesc
            // 
            label_dodajczesc.AutoSize = true;
            label_dodajczesc.Font = new Font("Segoe UI", 14F);
            label_dodajczesc.Location = new Point(223, 190);
            label_dodajczesc.Name = "label_dodajczesc";
            label_dodajczesc.Size = new Size(213, 32);
            label_dodajczesc.TabIndex = 24;
            label_dodajczesc.Text = "Warunki gwarancji:";
            // 
            // textBox_warunki_gwarancji
            // 
            textBox_warunki_gwarancji.Font = new Font("Segoe UI", 14F);
            textBox_warunki_gwarancji.Location = new Point(223, 226);
            textBox_warunki_gwarancji.Margin = new Padding(3, 4, 3, 4);
            textBox_warunki_gwarancji.Multiline = true;
            textBox_warunki_gwarancji.Name = "textBox_warunki_gwarancji";
            textBox_warunki_gwarancji.Size = new Size(563, 96);
            textBox_warunki_gwarancji.TabIndex = 23;
            // 
            // button_dodaj_gwarancje
            // 
            button_dodaj_gwarancje.Font = new Font("Segoe UI", 14F);
            button_dodaj_gwarancje.Location = new Point(14, 8);
            button_dodaj_gwarancje.Margin = new Padding(3, 4, 3, 4);
            button_dodaj_gwarancje.Name = "button_dodaj_gwarancje";
            button_dodaj_gwarancje.Size = new Size(190, 73);
            button_dodaj_gwarancje.TabIndex = 22;
            button_dodaj_gwarancje.Text = "Dodaj gwarancje";
            button_dodaj_gwarancje.UseVisualStyleBackColor = true;
            button_dodaj_gwarancje.Click += button_dodaj_gwarancje_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(489, 11);
            label1.Name = "label1";
            label1.Size = new Size(304, 32);
            label1.TabIndex = 31;
            label1.Text = "Firma udzielająca gwarancji";
            // 
            // comboBox_lista_firm
            // 
            comboBox_lista_firm.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_lista_firm.Font = new Font("Segoe UI", 14F);
            comboBox_lista_firm.FormattingEnabled = true;
            comboBox_lista_firm.Location = new Point(489, 48);
            comboBox_lista_firm.Margin = new Padding(3, 4, 3, 4);
            comboBox_lista_firm.Name = "comboBox_lista_firm";
            comboBox_lista_firm.Size = new Size(297, 39);
            comboBox_lista_firm.TabIndex = 30;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(223, 104);
            label2.Name = "label2";
            label2.Size = new Size(405, 32);
            label2.TabIndex = 33;
            label2.Text = "Czas trwania gwarancji w miesiącach:";
            // 
            // textBox_miesiace_gwarancji
            // 
            textBox_miesiace_gwarancji.Font = new Font("Segoe UI", 14F);
            textBox_miesiace_gwarancji.Location = new Point(599, 100);
            textBox_miesiace_gwarancji.Margin = new Padding(3, 4, 3, 4);
            textBox_miesiace_gwarancji.Name = "textBox_miesiace_gwarancji";
            textBox_miesiace_gwarancji.Size = new Size(187, 39);
            textBox_miesiace_gwarancji.TabIndex = 32;
            // 
            // button_potwierdz
            // 
            button_potwierdz.Font = new Font("Segoe UI", 14F);
            button_potwierdz.Location = new Point(14, 252);
            button_potwierdz.Margin = new Padding(3, 4, 3, 4);
            button_potwierdz.Name = "button_potwierdz";
            button_potwierdz.Size = new Size(190, 73);
            button_potwierdz.TabIndex = 34;
            button_potwierdz.Text = "Potwierdź";
            button_potwierdz.UseVisualStyleBackColor = true;
            // 
            // dataGridView_gwarancja_info
            // 
            dataGridView_gwarancja_info.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_gwarancja_info.Location = new Point(223, 364);
            dataGridView_gwarancja_info.Margin = new Padding(3, 4, 3, 4);
            dataGridView_gwarancja_info.Name = "dataGridView_gwarancja_info";
            dataGridView_gwarancja_info.RowHeadersWidth = 51;
            dataGridView_gwarancja_info.Size = new Size(563, 400);
            dataGridView_gwarancja_info.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(223, 327);
            label3.Name = "label3";
            label3.Size = new Size(216, 32);
            label3.TabIndex = 36;
            label3.Text = "Obecne gwarancje:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(223, 151);
            label4.Name = "label4";
            label4.Size = new Size(321, 32);
            label4.TabIndex = 38;
            label4.Text = "Data uruchomienia maszyny:";
            // 
            // textBox_uruchomienie
            // 
            textBox_uruchomienie.Font = new Font("Segoe UI", 14F);
            textBox_uruchomienie.Location = new Point(599, 147);
            textBox_uruchomienie.Margin = new Padding(3, 4, 3, 4);
            textBox_uruchomienie.Name = "textBox_uruchomienie";
            textBox_uruchomienie.Size = new Size(187, 39);
            textBox_uruchomienie.TabIndex = 37;
            // 
            // Form_Gwarancja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 823);
            Controls.Add(label4);
            Controls.Add(textBox_uruchomienie);
            Controls.Add(label3);
            Controls.Add(dataGridView_gwarancja_info);
            Controls.Add(button_potwierdz);
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
            Name = "Form_Gwarancja";
            Text = "Gwarancja";
            ((System.ComponentModel.ISupportInitialize)dataGridView_gwarancja_info).EndInit();
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
        private Button button_potwierdz;
        private DataGridView dataGridView_gwarancja_info;
        private Label label3;
        private Label label4;
        private TextBox textBox_uruchomienie;
    }
}