namespace PodkladexApp
{
    partial class Form_Badania
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
            button_noweBadanie = new Button();
            panel1 = new Panel();
            button_dodajBadanie = new Button();
            textBox_uwagi = new TextBox();
            textBox_koszt = new TextBox();
            dateTimePicker_dataBadania = new DateTimePicker();
            label7 = new Label();
            dateTimePicker_dataWaznosci = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            comboBox_typBadania = new ComboBox();
            comboBox_pracownik = new ComboBox();
            dataGridView_badania = new DataGridView();
            checkBox_tylkoNiewazne = new CheckBox();
            label1 = new Label();
            comboBox_filtrPracownik = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_badania).BeginInit();
            SuspendLayout();
            // 
            // button_noweBadanie
            // 
            button_noweBadanie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_noweBadanie.Location = new Point(620, 391);
            button_noweBadanie.Name = "button_noweBadanie";
            button_noweBadanie.Size = new Size(183, 42);
            button_noweBadanie.TabIndex = 11;
            button_noweBadanie.Text = "Dodaj Badanie";
            button_noweBadanie.UseVisualStyleBackColor = true;
            button_noweBadanie.Click += button_noweBadanie_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button_dodajBadanie);
            panel1.Controls.Add(textBox_uwagi);
            panel1.Controls.Add(textBox_koszt);
            panel1.Controls.Add(dateTimePicker_dataBadania);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dateTimePicker_dataWaznosci);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox_typBadania);
            panel1.Controls.Add(comboBox_pracownik);
            panel1.Location = new Point(276, 439);
            panel1.Name = "panel1";
            panel1.Size = new Size(852, 332);
            panel1.TabIndex = 10;
            // 
            // button_dodajBadanie
            // 
            button_dodajBadanie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_dodajBadanie.Location = new Point(355, 269);
            button_dodajBadanie.Name = "button_dodajBadanie";
            button_dodajBadanie.Size = new Size(143, 42);
            button_dodajBadanie.TabIndex = 5;
            button_dodajBadanie.Text = "Dodaj";
            button_dodajBadanie.UseVisualStyleBackColor = true;
            button_dodajBadanie.Click += button_dodajBadanie_Click;
            // 
            // textBox_uwagi
            // 
            textBox_uwagi.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_uwagi.Location = new Point(370, 214);
            textBox_uwagi.Name = "textBox_uwagi";
            textBox_uwagi.Size = new Size(331, 33);
            textBox_uwagi.TabIndex = 6;
            // 
            // textBox_koszt
            // 
            textBox_koszt.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_koszt.Location = new Point(370, 175);
            textBox_koszt.Name = "textBox_koszt";
            textBox_koszt.Size = new Size(331, 33);
            textBox_koszt.TabIndex = 6;
            // 
            // dateTimePicker_dataBadania
            // 
            dateTimePicker_dataBadania.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_dataBadania.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_dataBadania.Location = new Point(370, 91);
            dateTimePicker_dataBadania.Name = "dateTimePicker_dataBadania";
            dateTimePicker_dataBadania.Size = new Size(331, 33);
            dateTimePicker_dataBadania.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F);
            label7.Location = new Point(152, 217);
            label7.Name = "label7";
            label7.Size = new Size(65, 25);
            label7.TabIndex = 1;
            label7.Text = "Uwagi";
            // 
            // dateTimePicker_dataWaznosci
            // 
            dateTimePicker_dataWaznosci.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_dataWaznosci.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_dataWaznosci.Location = new Point(370, 132);
            dateTimePicker_dataWaznosci.Name = "dateTimePicker_dataWaznosci";
            dateTimePicker_dataWaznosci.Size = new Size(331, 33);
            dateTimePicker_dataWaznosci.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F);
            label6.Location = new Point(152, 178);
            label6.Name = "label6";
            label6.Size = new Size(128, 25);
            label6.TabIndex = 1;
            label6.Text = "Cena badania";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F);
            label5.Location = new Point(152, 138);
            label5.Name = "label5";
            label5.Size = new Size(133, 25);
            label5.TabIndex = 1;
            label5.Text = "Data ważności";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.Location = new Point(152, 97);
            label4.Name = "label4";
            label4.Size = new Size(124, 25);
            label4.TabIndex = 1;
            label4.Text = "Data badania";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(152, 55);
            label3.Name = "label3";
            label3.Size = new Size(141, 25);
            label3.TabIndex = 1;
            label3.Text = "Rodzaj badania";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(152, 13);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 1;
            label2.Text = "Pracownik";
            // 
            // comboBox_typBadania
            // 
            comboBox_typBadania.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_typBadania.FormattingEnabled = true;
            comboBox_typBadania.Location = new Point(370, 52);
            comboBox_typBadania.Name = "comboBox_typBadania";
            comboBox_typBadania.Size = new Size(331, 33);
            comboBox_typBadania.TabIndex = 0;
            // 
            // comboBox_pracownik
            // 
            comboBox_pracownik.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_pracownik.FormattingEnabled = true;
            comboBox_pracownik.Location = new Point(370, 13);
            comboBox_pracownik.Name = "comboBox_pracownik";
            comboBox_pracownik.Size = new Size(331, 33);
            comboBox_pracownik.TabIndex = 0;
            comboBox_pracownik.TextUpdate += comboBox_pracownik_TextUpdate;
            // 
            // dataGridView_badania
            // 
            dataGridView_badania.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_badania.Location = new Point(17, 55);
            dataGridView_badania.Name = "dataGridView_badania";
            dataGridView_badania.Size = new Size(1390, 330);
            dataGridView_badania.TabIndex = 9;
            // 
            // checkBox_tylkoNiewazne
            // 
            checkBox_tylkoNiewazne.AutoSize = true;
            checkBox_tylkoNiewazne.Font = new Font("Segoe UI", 14.25F);
            checkBox_tylkoNiewazne.Location = new Point(17, 12);
            checkBox_tylkoNiewazne.Name = "checkBox_tylkoNiewazne";
            checkBox_tylkoNiewazne.Size = new Size(210, 29);
            checkBox_tylkoNiewazne.TabIndex = 8;
            checkBox_tylkoNiewazne.Text = "Pokaż tylko nieważne";
            checkBox_tylkoNiewazne.UseVisualStyleBackColor = true;
            checkBox_tylkoNiewazne.CheckedChanged += checkBox_tylkoNiewazne_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.Location = new Point(886, 14);
            label1.Name = "label1";
            label1.Size = new Size(194, 25);
            label1.TabIndex = 7;
            label1.Text = "Filtruj po pracowniku:";
            // 
            // comboBox_filtrPracownik
            // 
            comboBox_filtrPracownik.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_filtrPracownik.FormattingEnabled = true;
            comboBox_filtrPracownik.Location = new Point(1092, 11);
            comboBox_filtrPracownik.Name = "comboBox_filtrPracownik";
            comboBox_filtrPracownik.Size = new Size(315, 33);
            comboBox_filtrPracownik.TabIndex = 6;
            comboBox_filtrPracownik.SelectedIndexChanged += comboBox_filtrPracownik_SelectedIndexChanged;
            comboBox_filtrPracownik.TextUpdate += comboBox_filtrPracownik_TextUpdate;
            // 
            // Form_Badania
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1424, 811);
            Controls.Add(button_noweBadanie);
            Controls.Add(panel1);
            Controls.Add(dataGridView_badania);
            Controls.Add(checkBox_tylkoNiewazne);
            Controls.Add(label1);
            Controls.Add(comboBox_filtrPracownik);
            Name = "Form_Badania";
            Text = "Form_Badania";
            Load += Form_Badania_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_badania).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_noweBadanie;
        private Panel panel1;
        private Button button_dodajBadanie;
        private TextBox textBox_koszt;
        private DateTimePicker dateTimePicker_dataBadania;
        private DateTimePicker dateTimePicker_dataWaznosci;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboBox_typBadania;
        private ComboBox comboBox_pracownik;
        private DataGridView dataGridView_badania;
        private CheckBox checkBox_tylkoNiewazne;
        private Label label1;
        private ComboBox comboBox_filtrPracownik;
        private TextBox textBox_uwagi;
        private Label label7;
    }
}