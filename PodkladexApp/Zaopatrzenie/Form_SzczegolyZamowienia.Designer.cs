namespace PodkladexApp.Zaopatrzenie
{
    partial class Form_SzczegolyZamowienia
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
            comboBox_Produkt = new ComboBox();
            comboBox_Material = new ComboBox();
            numericUpDown_Ilosc = new NumericUpDown();
            numericUpDown_Cena = new NumericUpDown();
            textBox_Uwagi = new TextBox();
            button_DodajPozycje = new Button();
            dataGridView_Koszyk = new DataGridView();
            button_PrzejdzDalej = new Button();
            label_Uwagi = new Label();
            label_Liczba = new Label();
            label_Produkt = new Label();
            label_Materiał = new Label();
            label_cena_pozycji = new Label();
            button_usun_z_zamowienia = new Button();
            button_powrot = new Button();
            button_edytuj_zamowienie = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Ilosc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Cena).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Koszyk).BeginInit();
            SuspendLayout();
            // 
            // comboBox_Produkt
            // 
            comboBox_Produkt.Font = new Font("Segoe UI", 14F);
            comboBox_Produkt.FormattingEnabled = true;
            comboBox_Produkt.Location = new Point(124, 64);
            comboBox_Produkt.Margin = new Padding(3, 2, 3, 2);
            comboBox_Produkt.Name = "comboBox_Produkt";
            comboBox_Produkt.Size = new Size(200, 33);
            comboBox_Produkt.TabIndex = 0;
            comboBox_Produkt.SelectedIndexChanged += comboBox_Produkt_SelectedIndexChanged;
            // 
            // comboBox_Material
            // 
            comboBox_Material.Font = new Font("Segoe UI", 14F);
            comboBox_Material.FormattingEnabled = true;
            comboBox_Material.Location = new Point(444, 64);
            comboBox_Material.Margin = new Padding(3, 2, 3, 2);
            comboBox_Material.Name = "comboBox_Material";
            comboBox_Material.Size = new Size(200, 33);
            comboBox_Material.TabIndex = 1;
            comboBox_Material.SelectedIndexChanged += comboBox_Material_SelectedIndexChanged;
            // 
            // numericUpDown_Ilosc
            // 
            numericUpDown_Ilosc.Font = new Font("Segoe UI", 13.8F);
            numericUpDown_Ilosc.Location = new Point(124, 162);
            numericUpDown_Ilosc.Margin = new Padding(3, 2, 3, 2);
            numericUpDown_Ilosc.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDown_Ilosc.Name = "numericUpDown_Ilosc";
            numericUpDown_Ilosc.Size = new Size(200, 32);
            numericUpDown_Ilosc.TabIndex = 2;
            numericUpDown_Ilosc.ThousandsSeparator = true;
            numericUpDown_Ilosc.ValueChanged += numericUpDown_Ilosc_ValueChanged;
            // 
            // numericUpDown_Cena
            // 
            numericUpDown_Cena.DecimalPlaces = 2;
            numericUpDown_Cena.Font = new Font("Segoe UI", 13.8F);
            numericUpDown_Cena.Location = new Point(443, 162);
            numericUpDown_Cena.Margin = new Padding(3, 2, 3, 2);
            numericUpDown_Cena.Maximum = new decimal(new int[] { 1874919423, 2328306, 0, 0 });
            numericUpDown_Cena.Name = "numericUpDown_Cena";
            numericUpDown_Cena.Size = new Size(200, 32);
            numericUpDown_Cena.TabIndex = 3;
            numericUpDown_Cena.ValueChanged += numericUpDown_Cena_ValueChanged;
            // 
            // textBox_Uwagi
            // 
            textBox_Uwagi.Font = new Font("Segoe UI", 14F);
            textBox_Uwagi.Location = new Point(124, 242);
            textBox_Uwagi.Margin = new Padding(3, 2, 3, 2);
            textBox_Uwagi.Name = "textBox_Uwagi";
            textBox_Uwagi.Size = new Size(525, 32);
            textBox_Uwagi.TabIndex = 4;
            textBox_Uwagi.TextChanged += textBox_Uwagi_TextChanged;
            // 
            // button_DodajPozycje
            // 
            button_DodajPozycje.Cursor = Cursors.Hand;
            button_DodajPozycje.Font = new Font("Segoe UI", 14F);
            button_DodajPozycje.Location = new Point(79, 342);
            button_DodajPozycje.Margin = new Padding(3, 2, 3, 2);
            button_DodajPozycje.Name = "button_DodajPozycje";
            button_DodajPozycje.Size = new Size(250, 50);
            button_DodajPozycje.TabIndex = 5;
            button_DodajPozycje.Text = "Dodaj do zamówienia";
            button_DodajPozycje.UseVisualStyleBackColor = true;
            button_DodajPozycje.Click += button_DodajPozycje_Click;
            // 
            // dataGridView_Koszyk
            // 
            dataGridView_Koszyk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Koszyk.Location = new Point(720, 64);
            dataGridView_Koszyk.Margin = new Padding(3, 2, 3, 2);
            dataGridView_Koszyk.Name = "dataGridView_Koszyk";
            dataGridView_Koszyk.RowHeadersWidth = 51;
            dataGridView_Koszyk.Size = new Size(969, 414);
            dataGridView_Koszyk.TabIndex = 6;
            dataGridView_Koszyk.CellContentClick += dataGridView_Koszyk_CellContentClick;
            dataGridView_Koszyk.SelectionChanged += dataGridView_Koszyk_SelectionChanged;
            // 
            // button_PrzejdzDalej
            // 
            button_PrzejdzDalej.Cursor = Cursors.Hand;
            button_PrzejdzDalej.Font = new Font("Segoe UI", 14F);
            button_PrzejdzDalej.Location = new Point(1002, 547);
            button_PrzejdzDalej.Margin = new Padding(3, 2, 3, 2);
            button_PrzejdzDalej.Name = "button_PrzejdzDalej";
            button_PrzejdzDalej.Size = new Size(250, 50);
            button_PrzejdzDalej.TabIndex = 7;
            button_PrzejdzDalej.Text = "Przejdź dalej";
            button_PrzejdzDalej.UseVisualStyleBackColor = true;
            button_PrzejdzDalej.Click += button_PrzejdzDalej_Click;
            // 
            // label_Uwagi
            // 
            label_Uwagi.AutoSize = true;
            label_Uwagi.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Uwagi.Location = new Point(48, 245);
            label_Uwagi.Name = "label_Uwagi";
            label_Uwagi.Size = new Size(66, 25);
            label_Uwagi.TabIndex = 8;
            label_Uwagi.Text = "Uwagi";
            // 
            // label_Liczba
            // 
            label_Liczba.AutoSize = true;
            label_Liczba.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Liczba.Location = new Point(49, 166);
            label_Liczba.Name = "label_Liczba";
            label_Liczba.Size = new Size(66, 25);
            label_Liczba.TabIndex = 9;
            label_Liczba.Text = "Liczba";
            // 
            // label_Produkt
            // 
            label_Produkt.AutoSize = true;
            label_Produkt.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Produkt.Location = new Point(34, 66);
            label_Produkt.Name = "label_Produkt";
            label_Produkt.Size = new Size(80, 25);
            label_Produkt.TabIndex = 10;
            label_Produkt.Text = "Produkt";
            // 
            // label_Materiał
            // 
            label_Materiał.AutoSize = true;
            label_Materiał.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Materiał.Location = new Point(354, 66);
            label_Materiał.Name = "label_Materiał";
            label_Materiał.Size = new Size(84, 25);
            label_Materiał.TabIndex = 11;
            label_Materiał.Text = "Materiał";
            // 
            // label_cena_pozycji
            // 
            label_cena_pozycji.AutoSize = true;
            label_cena_pozycji.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_cena_pozycji.Location = new Point(384, 166);
            label_cena_pozycji.Name = "label_cena_pozycji";
            label_cena_pozycji.Size = new Size(56, 25);
            label_cena_pozycji.TabIndex = 12;
            label_cena_pozycji.Text = "Cena";
            // 
            // button_usun_z_zamowienia
            // 
            button_usun_z_zamowienia.Cursor = Cursors.Hand;
            button_usun_z_zamowienia.Font = new Font("Segoe UI", 14F);
            button_usun_z_zamowienia.Location = new Point(399, 342);
            button_usun_z_zamowienia.Margin = new Padding(3, 2, 3, 2);
            button_usun_z_zamowienia.Name = "button_usun_z_zamowienia";
            button_usun_z_zamowienia.Size = new Size(250, 50);
            button_usun_z_zamowienia.TabIndex = 13;
            button_usun_z_zamowienia.Text = "Usuń z zamówienia";
            button_usun_z_zamowienia.UseVisualStyleBackColor = true;
            button_usun_z_zamowienia.Click += button_usun_z_zamowienia_Click;
            // 
            // button_powrot
            // 
            button_powrot.Cursor = Cursors.Hand;
            button_powrot.Font = new Font("Segoe UI", 14F);
            button_powrot.Location = new Point(63, 689);
            button_powrot.Margin = new Padding(3, 2, 3, 2);
            button_powrot.Name = "button_powrot";
            button_powrot.Size = new Size(250, 50);
            button_powrot.TabIndex = 14;
            button_powrot.Text = "Powrót";
            button_powrot.UseVisualStyleBackColor = true;
            button_powrot.Click += button_powrot_Click;
            // 
            // button_edytuj_zamowienie
            // 
            button_edytuj_zamowienie.Cursor = Cursors.Hand;
            button_edytuj_zamowienie.Font = new Font("Segoe UI", 14F);
            button_edytuj_zamowienie.Location = new Point(227, 428);
            button_edytuj_zamowienie.Margin = new Padding(3, 2, 3, 2);
            button_edytuj_zamowienie.Name = "button_edytuj_zamowienie";
            button_edytuj_zamowienie.Size = new Size(250, 50);
            button_edytuj_zamowienie.TabIndex = 15;
            button_edytuj_zamowienie.Text = "Edytuj pozycje";
            button_edytuj_zamowienie.UseVisualStyleBackColor = true;
            button_edytuj_zamowienie.Click += button_edytuj_zamowienie_Click;
            // 
            // Form_SzczegolyZamowienia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1664, 791);
            Controls.Add(button_edytuj_zamowienie);
            Controls.Add(button_powrot);
            Controls.Add(button_usun_z_zamowienia);
            Controls.Add(label_cena_pozycji);
            Controls.Add(label_Materiał);
            Controls.Add(label_Produkt);
            Controls.Add(label_Liczba);
            Controls.Add(label_Uwagi);
            Controls.Add(button_PrzejdzDalej);
            Controls.Add(dataGridView_Koszyk);
            Controls.Add(button_DodajPozycje);
            Controls.Add(textBox_Uwagi);
            Controls.Add(numericUpDown_Cena);
            Controls.Add(numericUpDown_Ilosc);
            Controls.Add(comboBox_Material);
            Controls.Add(comboBox_Produkt);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_SzczegolyZamowienia";
            Text = "Wybór produktów";
            Load += Form_SzczegolyZamowienia_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Ilosc).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Cena).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Koszyk).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_Produkt;
        private ComboBox comboBox_Material;
        private NumericUpDown numericUpDown_Ilosc;
        private NumericUpDown numericUpDown_Cena;
        private TextBox textBox_Uwagi;
        private Button button_DodajPozycje;
        private DataGridView dataGridView_Koszyk;
        private Button button_PrzejdzDalej;
        private Label label_Uwagi;
        private Label label_Liczba;
        private Label label_Produkt;
        private Label label_Materiał;
        private Label label_cena_pozycji;
        private Button button_usun_z_zamowienia;
        private Button button_powrot;
        private Button button_edytuj_zamowienie;
    }
}