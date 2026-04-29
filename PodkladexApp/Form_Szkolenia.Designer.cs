namespace PodkladexApp
{
    partial class Form_Szkolenia
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
            comboBox_filtrPracownik = new ComboBox();
            label1 = new Label();
            checkBox_tylkoNiewazne = new CheckBox();
            dataGridView_szkolenia = new DataGridView();
            panel1 = new Panel();
            button_dodajSzkolenie = new Button();
            textBox_cenaSzkolenia = new TextBox();
            dateTimePicker_dataSzkolenia = new DateTimePicker();
            dateTimePicker_dataWaznosci = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            comboBox_szkolenie = new ComboBox();
            comboBox_pracownik = new ComboBox();
            button_noweSzkolenie = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_szkolenia).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox_filtrPracownik
            // 
            comboBox_filtrPracownik.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_filtrPracownik.FormattingEnabled = true;
            comboBox_filtrPracownik.Location = new Point(632, 24);
            comboBox_filtrPracownik.Name = "comboBox_filtrPracownik";
            comboBox_filtrPracownik.Size = new Size(203, 33);
            comboBox_filtrPracownik.TabIndex = 0;
            comboBox_filtrPracownik.SelectedIndexChanged += comboBox_filtrPracownik_SelectedIndexChanged;
            comboBox_filtrPracownik.SelectedValueChanged += comboBox_filtrPracownik_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.Location = new Point(436, 24);
            label1.Name = "label1";
            label1.Size = new Size(190, 25);
            label1.TabIndex = 1;
            label1.Text = "Filtruj po pracowniku";
            // 
            // checkBox_tylkoNiewazne
            // 
            checkBox_tylkoNiewazne.AutoSize = true;
            checkBox_tylkoNiewazne.Font = new Font("Segoe UI", 14.25F);
            checkBox_tylkoNiewazne.Location = new Point(37, 20);
            checkBox_tylkoNiewazne.Name = "checkBox_tylkoNiewazne";
            checkBox_tylkoNiewazne.Size = new Size(210, 29);
            checkBox_tylkoNiewazne.TabIndex = 2;
            checkBox_tylkoNiewazne.Text = "Pokaż tylko nieważne";
            checkBox_tylkoNiewazne.UseVisualStyleBackColor = true;
            checkBox_tylkoNiewazne.CheckedChanged += checkBox_tylkoNiewazne_CheckedChanged;
            // 
            // dataGridView_szkolenia
            // 
            dataGridView_szkolenia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_szkolenia.Location = new Point(37, 77);
            dataGridView_szkolenia.Name = "dataGridView_szkolenia";
            dataGridView_szkolenia.Size = new Size(798, 150);
            dataGridView_szkolenia.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(button_dodajSzkolenie);
            panel1.Controls.Add(textBox_cenaSzkolenia);
            panel1.Controls.Add(dateTimePicker_dataSzkolenia);
            panel1.Controls.Add(dateTimePicker_dataWaznosci);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox_szkolenie);
            panel1.Controls.Add(comboBox_pracownik);
            panel1.Location = new Point(34, 285);
            panel1.Name = "panel1";
            panel1.Size = new Size(852, 355);
            panel1.TabIndex = 4;
            // 
            // button_dodajSzkolenie
            // 
            button_dodajSzkolenie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_dodajSzkolenie.Location = new Point(282, 290);
            button_dodajSzkolenie.Name = "button_dodajSzkolenie";
            button_dodajSzkolenie.Size = new Size(143, 42);
            button_dodajSzkolenie.TabIndex = 5;
            button_dodajSzkolenie.Text = "Dodaj";
            button_dodajSzkolenie.UseVisualStyleBackColor = true;
            button_dodajSzkolenie.Click += button_dodajSzkolenie_Click;
            // 
            // textBox_cenaSzkolenia
            // 
            textBox_cenaSzkolenia.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_cenaSzkolenia.Location = new Point(235, 230);
            textBox_cenaSzkolenia.Name = "textBox_cenaSzkolenia";
            textBox_cenaSzkolenia.Size = new Size(331, 33);
            textBox_cenaSzkolenia.TabIndex = 6;
            // 
            // dateTimePicker_dataSzkolenia
            // 
            dateTimePicker_dataSzkolenia.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_dataSzkolenia.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_dataSzkolenia.Location = new Point(235, 146);
            dateTimePicker_dataSzkolenia.Name = "dateTimePicker_dataSzkolenia";
            dateTimePicker_dataSzkolenia.Size = new Size(331, 33);
            dateTimePicker_dataSzkolenia.TabIndex = 5;
            dateTimePicker_dataSzkolenia.ValueChanged += dateTimePicker_dataSzkolenia_ValueChanged;
            // 
            // dateTimePicker_dataWaznosci
            // 
            dateTimePicker_dataWaznosci.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_dataWaznosci.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_dataWaznosci.Location = new Point(235, 187);
            dateTimePicker_dataWaznosci.Name = "dateTimePicker_dataWaznosci";
            dateTimePicker_dataWaznosci.Size = new Size(331, 33);
            dateTimePicker_dataWaznosci.TabIndex = 5;
            dateTimePicker_dataWaznosci.ValueChanged += dateTimePicker_dataWaznosci_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F);
            label6.Location = new Point(17, 233);
            label6.Name = "label6";
            label6.Size = new Size(139, 25);
            label6.TabIndex = 1;
            label6.Text = "Cena Szkolenia";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F);
            label5.Location = new Point(17, 193);
            label5.Name = "label5";
            label5.Size = new Size(133, 25);
            label5.TabIndex = 1;
            label5.Text = "Data ważności";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.Location = new Point(17, 152);
            label4.Name = "label4";
            label4.Size = new Size(157, 25);
            label4.TabIndex = 1;
            label4.Text = "Data rozpoczęcia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(17, 99);
            label3.Name = "label3";
            label3.Size = new Size(164, 25);
            label3.TabIndex = 1;
            label3.Text = "Rodzaj zwolnienia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(17, 38);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 1;
            label2.Text = "Pracownik";
            // 
            // comboBox_szkolenie
            // 
            comboBox_szkolenie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_szkolenie.FormattingEnabled = true;
            comboBox_szkolenie.Location = new Point(235, 96);
            comboBox_szkolenie.Name = "comboBox_szkolenie";
            comboBox_szkolenie.Size = new Size(331, 33);
            comboBox_szkolenie.TabIndex = 0;
            comboBox_szkolenie.SelectedIndexChanged += comboBox_szkolenie_SelectedIndexChanged;
            // 
            // comboBox_pracownik
            // 
            comboBox_pracownik.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_pracownik.FormattingEnabled = true;
            comboBox_pracownik.Location = new Point(235, 38);
            comboBox_pracownik.Name = "comboBox_pracownik";
            comboBox_pracownik.Size = new Size(331, 33);
            comboBox_pracownik.TabIndex = 0;
            // 
            // button_noweSzkolenie
            // 
            button_noweSzkolenie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_noweSzkolenie.Location = new Point(338, 237);
            button_noweSzkolenie.Name = "button_noweSzkolenie";
            button_noweSzkolenie.Size = new Size(183, 42);
            button_noweSzkolenie.TabIndex = 5;
            button_noweSzkolenie.Text = "Dodaj szkolenie";
            button_noweSzkolenie.UseVisualStyleBackColor = true;
            button_noweSzkolenie.Click += button_noweSzkolenie_Click;
            // 
            // Form_Szkolenia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(934, 711);
            Controls.Add(button_noweSzkolenie);
            Controls.Add(panel1);
            Controls.Add(dataGridView_szkolenia);
            Controls.Add(checkBox_tylkoNiewazne);
            Controls.Add(label1);
            Controls.Add(comboBox_filtrPracownik);
            Name = "Form_Szkolenia";
            Text = "Form_Szkolenia";
            Load += Form_Szkolenia_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_szkolenia).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_filtrPracownik;
        private Label label1;
        private CheckBox checkBox_tylkoNiewazne;
        private DataGridView dataGridView_szkolenia;
        private Panel panel1;
        private Button button_dodajSzkolenie;
        private TextBox textBox_cenaSzkolenia;
        private DateTimePicker dateTimePicker_dataSzkolenia;
        private DateTimePicker dateTimePicker_dataWaznosci;
        private ComboBox comboBox_szkolenie;
        private ComboBox comboBox_pracownik;
        private Button button_noweSzkolenie;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label6;
    }
}