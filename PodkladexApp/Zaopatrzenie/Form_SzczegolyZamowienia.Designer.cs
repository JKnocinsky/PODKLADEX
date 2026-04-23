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
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Ilosc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Cena).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Koszyk).BeginInit();
            SuspendLayout();
            // 
            // comboBox_Produkt
            // 
            comboBox_Produkt.Font = new Font("Segoe UI", 14F);
            comboBox_Produkt.FormattingEnabled = true;
            comboBox_Produkt.Location = new Point(44, 55);
            comboBox_Produkt.Name = "comboBox_Produkt";
            comboBox_Produkt.Size = new Size(234, 39);
            comboBox_Produkt.TabIndex = 0;
            comboBox_Produkt.SelectedIndexChanged += comboBox_Produkt_SelectedIndexChanged;
            // 
            // comboBox_Material
            // 
            comboBox_Material.Font = new Font("Segoe UI", 14F);
            comboBox_Material.FormattingEnabled = true;
            comboBox_Material.Location = new Point(363, 55);
            comboBox_Material.Name = "comboBox_Material";
            comboBox_Material.Size = new Size(234, 39);
            comboBox_Material.TabIndex = 1;
            comboBox_Material.SelectedIndexChanged += comboBox_Material_SelectedIndexChanged;
            // 
            // numericUpDown_Ilosc
            // 
            numericUpDown_Ilosc.Location = new Point(123, 196);
            numericUpDown_Ilosc.Name = "numericUpDown_Ilosc";
            numericUpDown_Ilosc.Size = new Size(150, 27);
            numericUpDown_Ilosc.TabIndex = 2;
            numericUpDown_Ilosc.ValueChanged += numericUpDown_Ilosc_ValueChanged;
            // 
            // numericUpDown_Cena
            // 
            numericUpDown_Cena.Location = new Point(354, 196);
            numericUpDown_Cena.Name = "numericUpDown_Cena";
            numericUpDown_Cena.Size = new Size(150, 27);
            numericUpDown_Cena.TabIndex = 3;
            numericUpDown_Cena.ValueChanged += numericUpDown_Cena_ValueChanged;
            // 
            // textBox_Uwagi
            // 
            textBox_Uwagi.Font = new Font("Segoe UI", 14F);
            textBox_Uwagi.Location = new Point(96, 294);
            textBox_Uwagi.Name = "textBox_Uwagi";
            textBox_Uwagi.Size = new Size(125, 39);
            textBox_Uwagi.TabIndex = 4;
            textBox_Uwagi.TextChanged += textBox_Uwagi_TextChanged;
            // 
            // button_DodajPozycje
            // 
            button_DodajPozycje.Font = new Font("Segoe UI", 14F);
            button_DodajPozycje.Location = new Point(110, 377);
            button_DodajPozycje.Name = "button_DodajPozycje";
            button_DodajPozycje.Size = new Size(284, 48);
            button_DodajPozycje.TabIndex = 5;
            button_DodajPozycje.Text = "Dodaj do zamówienia";
            button_DodajPozycje.UseVisualStyleBackColor = true;
            button_DodajPozycje.Click += button_DodajPozycje_Click;
            // 
            // dataGridView_Koszyk
            // 
            dataGridView_Koszyk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Koszyk.Location = new Point(665, 45);
            dataGridView_Koszyk.Name = "dataGridView_Koszyk";
            dataGridView_Koszyk.RowHeadersWidth = 51;
            dataGridView_Koszyk.Size = new Size(300, 188);
            dataGridView_Koszyk.TabIndex = 6;
            dataGridView_Koszyk.CellContentClick += dataGridView_Koszyk_CellContentClick;
            // 
            // button_PrzejdzDalej
            // 
            button_PrzejdzDalej.Font = new Font("Segoe UI", 14F);
            button_PrzejdzDalej.Location = new Point(473, 377);
            button_PrzejdzDalej.Name = "button_PrzejdzDalej";
            button_PrzejdzDalej.Size = new Size(284, 48);
            button_PrzejdzDalej.TabIndex = 7;
            button_PrzejdzDalej.Text = "Przejdź dalej";
            button_PrzejdzDalej.UseVisualStyleBackColor = true;
            button_PrzejdzDalej.Click += button_PrzejdzDalej_Click;
            // 
            // Form_SzczegolyZamowienia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 450);
            Controls.Add(button_PrzejdzDalej);
            Controls.Add(dataGridView_Koszyk);
            Controls.Add(button_DodajPozycje);
            Controls.Add(textBox_Uwagi);
            Controls.Add(numericUpDown_Cena);
            Controls.Add(numericUpDown_Ilosc);
            Controls.Add(comboBox_Material);
            Controls.Add(comboBox_Produkt);
            Name = "Form_SzczegolyZamowienia";
            Text = "Form1";
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
    }
}