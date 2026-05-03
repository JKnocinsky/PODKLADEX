namespace PodkladexApp.Zaopatrzenie
{
    partial class Form_ZamowMaterial
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
            button_edytuj_zamowienie = new Button();
            button_powrot = new Button();
            button_usun_z_zamowienia = new Button();
            label_cena_pozycji = new Label();
            label_Materiał = new Label();
            label_Liczba = new Label();
            label_Pracownik = new Label();
            button_PrzejdzDalej = new Button();
            dataGridView_Koszyk = new DataGridView();
            button_DodajPozycje = new Button();
            numericUpDown_Cena = new NumericUpDown();
            numericUpDown_Ilosc = new NumericUpDown();
            comboBox_Material = new ComboBox();
            dateTimePicker_data = new DateTimePicker();
            label_data = new Label();
            comboBox_Firma = new ComboBox();
            label_Firma = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Koszyk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Cena).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Ilosc).BeginInit();
            SuspendLayout();
            // 
            // button_edytuj_zamowienie
            // 
            button_edytuj_zamowienie.Cursor = Cursors.Hand;
            button_edytuj_zamowienie.Font = new Font("Segoe UI", 14F);
            button_edytuj_zamowienie.Location = new Point(199, 549);
            button_edytuj_zamowienie.Margin = new Padding(3, 2, 3, 2);
            button_edytuj_zamowienie.Name = "button_edytuj_zamowienie";
            button_edytuj_zamowienie.Size = new Size(250, 50);
            button_edytuj_zamowienie.TabIndex = 31;
            button_edytuj_zamowienie.Text = "Edytuj pozycje";
            button_edytuj_zamowienie.UseVisualStyleBackColor = true;
            // 
            // button_powrot
            // 
            button_powrot.Cursor = Cursors.Hand;
            button_powrot.Font = new Font("Segoe UI", 14F);
            button_powrot.Location = new Point(34, 683);
            button_powrot.Margin = new Padding(3, 2, 3, 2);
            button_powrot.Name = "button_powrot";
            button_powrot.Size = new Size(250, 50);
            button_powrot.TabIndex = 30;
            button_powrot.Text = "Powrót";
            button_powrot.UseVisualStyleBackColor = true;
            // 
            // button_usun_z_zamowienia
            // 
            button_usun_z_zamowienia.Cursor = Cursors.Hand;
            button_usun_z_zamowienia.Font = new Font("Segoe UI", 14F);
            button_usun_z_zamowienia.Location = new Point(371, 463);
            button_usun_z_zamowienia.Margin = new Padding(3, 2, 3, 2);
            button_usun_z_zamowienia.Name = "button_usun_z_zamowienia";
            button_usun_z_zamowienia.Size = new Size(250, 50);
            button_usun_z_zamowienia.TabIndex = 29;
            button_usun_z_zamowienia.Text = "Usuń z zamówienia";
            button_usun_z_zamowienia.UseVisualStyleBackColor = true;
            // 
            // label_cena_pozycji
            // 
            label_cena_pozycji.AutoSize = true;
            label_cena_pozycji.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_cena_pozycji.Location = new Point(375, 250);
            label_cena_pozycji.Name = "label_cena_pozycji";
            label_cena_pozycji.Size = new Size(56, 25);
            label_cena_pozycji.TabIndex = 28;
            label_cena_pozycji.Text = "Cena";
            // 
            // label_Materiał
            // 
            label_Materiał.AutoSize = true;
            label_Materiał.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Materiał.Location = new Point(75, 173);
            label_Materiał.Name = "label_Materiał";
            label_Materiał.Size = new Size(84, 25);
            label_Materiał.TabIndex = 27;
            label_Materiał.Text = "Materiał";
            // 
            // label_Liczba
            // 
            label_Liczba.AutoSize = true;
            label_Liczba.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Liczba.Location = new Point(15, 250);
            label_Liczba.Name = "label_Liczba";
            label_Liczba.Size = new Size(66, 25);
            label_Liczba.TabIndex = 25;
            label_Liczba.Text = "Liczba";
            // 
            // label_Pracownik
            // 
            label_Pracownik.AutoSize = true;
            label_Pracownik.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Pracownik.Location = new Point(58, 394);
            label_Pracownik.Name = "label_Pracownik";
            label_Pracownik.Size = new Size(101, 25);
            label_Pracownik.TabIndex = 24;
            label_Pracownik.Text = "Pracownik";
            // 
            // button_PrzejdzDalej
            // 
            button_PrzejdzDalej.Cursor = Cursors.Hand;
            button_PrzejdzDalej.Font = new Font("Segoe UI", 14F);
            button_PrzejdzDalej.Location = new Point(974, 668);
            button_PrzejdzDalej.Margin = new Padding(3, 2, 3, 2);
            button_PrzejdzDalej.Name = "button_PrzejdzDalej";
            button_PrzejdzDalej.Size = new Size(250, 50);
            button_PrzejdzDalej.TabIndex = 23;
            button_PrzejdzDalej.Text = "Przejdź dalej";
            button_PrzejdzDalej.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Koszyk
            // 
            dataGridView_Koszyk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Koszyk.Location = new Point(691, 58);
            dataGridView_Koszyk.Margin = new Padding(3, 2, 3, 2);
            dataGridView_Koszyk.Name = "dataGridView_Koszyk";
            dataGridView_Koszyk.RowHeadersWidth = 51;
            dataGridView_Koszyk.Size = new Size(969, 414);
            dataGridView_Koszyk.TabIndex = 22;
            dataGridView_Koszyk.CellContentClick += dataGridView_Koszyk_CellContentClick;
            // 
            // button_DodajPozycje
            // 
            button_DodajPozycje.Cursor = Cursors.Hand;
            button_DodajPozycje.Font = new Font("Segoe UI", 14F);
            button_DodajPozycje.Location = new Point(51, 463);
            button_DodajPozycje.Margin = new Padding(3, 2, 3, 2);
            button_DodajPozycje.Name = "button_DodajPozycje";
            button_DodajPozycje.Size = new Size(250, 50);
            button_DodajPozycje.TabIndex = 21;
            button_DodajPozycje.Text = "Dodaj do zamówienia";
            button_DodajPozycje.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_Cena
            // 
            numericUpDown_Cena.DecimalPlaces = 2;
            numericUpDown_Cena.Font = new Font("Segoe UI", 13.8F);
            numericUpDown_Cena.Location = new Point(448, 246);
            numericUpDown_Cena.Margin = new Padding(3, 2, 3, 2);
            numericUpDown_Cena.Maximum = new decimal(new int[] { 1874919423, 2328306, 0, 0 });
            numericUpDown_Cena.Name = "numericUpDown_Cena";
            numericUpDown_Cena.Size = new Size(200, 32);
            numericUpDown_Cena.TabIndex = 19;
            numericUpDown_Cena.ValueChanged += numericUpDown_Cena_ValueChanged;
            // 
            // numericUpDown_Ilosc
            // 
            numericUpDown_Ilosc.Font = new Font("Segoe UI", 13.8F);
            numericUpDown_Ilosc.Location = new Point(101, 246);
            numericUpDown_Ilosc.Margin = new Padding(3, 2, 3, 2);
            numericUpDown_Ilosc.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDown_Ilosc.Name = "numericUpDown_Ilosc";
            numericUpDown_Ilosc.Size = new Size(200, 32);
            numericUpDown_Ilosc.TabIndex = 18;
            numericUpDown_Ilosc.ThousandsSeparator = true;
            numericUpDown_Ilosc.ValueChanged += numericUpDown_Ilosc_ValueChanged;
            // 
            // comboBox_Material
            // 
            comboBox_Material.Font = new Font("Segoe UI", 14F);
            comboBox_Material.FormattingEnabled = true;
            comboBox_Material.Location = new Point(165, 170);
            comboBox_Material.Margin = new Padding(3, 2, 3, 2);
            comboBox_Material.Name = "comboBox_Material";
            comboBox_Material.Size = new Size(400, 33);
            comboBox_Material.TabIndex = 17;
            comboBox_Material.SelectedIndexChanged += comboBox_Material_SelectedIndexChanged;
            // 
            // dateTimePicker_data
            // 
            dateTimePicker_data.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_data.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_data.Location = new Point(215, 323);
            dateTimePicker_data.MinDate = new DateTime(2026, 5, 3, 0, 0, 0, 0);
            dateTimePicker_data.Name = "dateTimePicker_data";
            dateTimePicker_data.Size = new Size(273, 33);
            dateTimePicker_data.TabIndex = 32;
            dateTimePicker_data.ValueChanged += dateTimePicker_data_ValueChanged;
            // 
            // label_data
            // 
            label_data.AutoSize = true;
            label_data.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_data.Location = new Point(154, 326);
            label_data.Name = "label_data";
            label_data.Size = new Size(55, 25);
            label_data.TabIndex = 33;
            label_data.Text = "Data";
            // 
            // comboBox_Firma
            // 
            comboBox_Firma.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_Firma.FormattingEnabled = true;
            comboBox_Firma.Location = new Point(165, 77);
            comboBox_Firma.Name = "comboBox_Firma";
            comboBox_Firma.Size = new Size(400, 33);
            comboBox_Firma.TabIndex = 34;
            comboBox_Firma.SelectedIndexChanged += comboBox_Firma_SelectedIndexChanged;
            // 
            // label_Firma
            // 
            label_Firma.AutoSize = true;
            label_Firma.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label_Firma.Location = new Point(62, 80);
            label_Firma.Name = "label_Firma";
            label_Firma.Size = new Size(97, 25);
            label_Firma.TabIndex = 35;
            label_Firma.Text = "Dostawca";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(165, 394);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(400, 33);
            comboBox1.TabIndex = 36;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form_ZamowMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1664, 791);
            Controls.Add(comboBox1);
            Controls.Add(label_Firma);
            Controls.Add(comboBox_Firma);
            Controls.Add(label_data);
            Controls.Add(dateTimePicker_data);
            Controls.Add(button_edytuj_zamowienie);
            Controls.Add(button_powrot);
            Controls.Add(button_usun_z_zamowienia);
            Controls.Add(label_cena_pozycji);
            Controls.Add(label_Materiał);
            Controls.Add(label_Liczba);
            Controls.Add(label_Pracownik);
            Controls.Add(button_PrzejdzDalej);
            Controls.Add(dataGridView_Koszyk);
            Controls.Add(button_DodajPozycje);
            Controls.Add(numericUpDown_Cena);
            Controls.Add(numericUpDown_Ilosc);
            Controls.Add(comboBox_Material);
            Name = "Form_ZamowMaterial";
            Text = "Zamawianie materiałów";
            ((System.ComponentModel.ISupportInitialize)dataGridView_Koszyk).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Cena).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Ilosc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_edytuj_zamowienie;
        private Button button_powrot;
        private Button button_usun_z_zamowienia;
        private Label label_cena_pozycji;
        private Label label_Materiał;
        private Label label_Liczba;
        private Label label_Pracownik;
        private Button button_PrzejdzDalej;
        private DataGridView dataGridView_Koszyk;
        private Button button_DodajPozycje;
        private NumericUpDown numericUpDown_Cena;
        private NumericUpDown numericUpDown_Ilosc;
        private ComboBox comboBox_Material;
        private DateTimePicker dateTimePicker_data;
        private Label label_data;
        private ComboBox comboBox_Firma;
        private Label label_Firma;
        private ComboBox comboBox1;
    }
}