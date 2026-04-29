namespace PodkladexApp
{
    partial class Form_Umowy
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
            dataGridView_umowy = new DataGridView();
            comboBox_pracownik = new ComboBox();
            comboBox_rodzajUmowy = new ComboBox();
            dateTimePicker_dataroz = new DateTimePicker();
            button_dodajUmowe = new Button();
            dateTimePicker_datazak = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            button_nowaumowa = new Button();
            checkBox_tylkoAktywne = new CheckBox();
            comboBox_filtrPracownik = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_umowy).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView_umowy
            // 
            dataGridView_umowy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_umowy.Location = new Point(2, 60);
            dataGridView_umowy.Name = "dataGridView_umowy";
            dataGridView_umowy.Size = new Size(935, 246);
            dataGridView_umowy.TabIndex = 0;
            // 
            // comboBox_pracownik
            // 
            comboBox_pracownik.Font = new Font("Segoe UI", 14.25F);
            comboBox_pracownik.FormattingEnabled = true;
            comboBox_pracownik.Location = new Point(192, 36);
            comboBox_pracownik.Name = "comboBox_pracownik";
            comboBox_pracownik.Size = new Size(420, 33);
            comboBox_pracownik.TabIndex = 1;
            // 
            // comboBox_rodzajUmowy
            // 
            comboBox_rodzajUmowy.Font = new Font("Segoe UI", 14.25F);
            comboBox_rodzajUmowy.FormattingEnabled = true;
            comboBox_rodzajUmowy.Location = new Point(192, 81);
            comboBox_rodzajUmowy.Name = "comboBox_rodzajUmowy";
            comboBox_rodzajUmowy.Size = new Size(420, 33);
            comboBox_rodzajUmowy.TabIndex = 2;
            // 
            // dateTimePicker_dataroz
            // 
            dateTimePicker_dataroz.Font = new Font("Segoe UI", 14.25F);
            dateTimePicker_dataroz.Location = new Point(220, 145);
            dateTimePicker_dataroz.Name = "dateTimePicker_dataroz";
            dateTimePicker_dataroz.Size = new Size(337, 33);
            dateTimePicker_dataroz.TabIndex = 3;
            // 
            // button_dodajUmowe
            // 
            button_dodajUmowe.Font = new Font("Segoe UI", 14.25F);
            button_dodajUmowe.Location = new Point(360, 250);
            button_dodajUmowe.Name = "button_dodajUmowe";
            button_dodajUmowe.Size = new Size(140, 38);
            button_dodajUmowe.TabIndex = 4;
            button_dodajUmowe.Text = "Dodaj";
            button_dodajUmowe.UseVisualStyleBackColor = true;
            button_dodajUmowe.Click += button_dodajUmowe_Click;
            // 
            // dateTimePicker_datazak
            // 
            dateTimePicker_datazak.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_datazak.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_datazak.Location = new Point(220, 192);
            dateTimePicker_datazak.Name = "dateTimePicker_datazak";
            dateTimePicker_datazak.Size = new Size(337, 33);
            dateTimePicker_datazak.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 5;
            label1.Text = "Pracownik";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(12, 84);
            label2.Name = "label2";
            label2.Size = new Size(134, 25);
            label2.TabIndex = 5;
            label2.Text = "Rodzaj umowy";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(12, 192);
            label3.Name = "label3";
            label3.Size = new Size(160, 25);
            label3.TabIndex = 5;
            label3.Text = "Data zakończenia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.Location = new Point(12, 145);
            label4.Name = "label4";
            label4.Size = new Size(157, 25);
            label4.TabIndex = 5;
            label4.Text = "Data rozpoczęcia";
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboBox_pracownik);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboBox_rodzajUmowy);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dateTimePicker_dataroz);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateTimePicker_datazak);
            panel1.Controls.Add(button_dodajUmowe);
            panel1.Location = new Point(12, 393);
            panel1.Name = "panel1";
            panel1.Size = new Size(887, 306);
            panel1.TabIndex = 6;
            // 
            // button_nowaumowa
            // 
            button_nowaumowa.Font = new Font("Segoe UI", 14.25F);
            button_nowaumowa.Location = new Point(314, 330);
            button_nowaumowa.Name = "button_nowaumowa";
            button_nowaumowa.Size = new Size(255, 38);
            button_nowaumowa.TabIndex = 4;
            button_nowaumowa.Text = "Nowa umowa";
            button_nowaumowa.UseVisualStyleBackColor = true;
            button_nowaumowa.Click += button_nowaumowa_Click;
            // 
            // checkBox_tylkoAktywne
            // 
            checkBox_tylkoAktywne.AutoSize = true;
            checkBox_tylkoAktywne.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            checkBox_tylkoAktywne.Location = new Point(12, 12);
            checkBox_tylkoAktywne.Name = "checkBox_tylkoAktywne";
            checkBox_tylkoAktywne.Size = new Size(265, 29);
            checkBox_tylkoAktywne.TabIndex = 7;
            checkBox_tylkoAktywne.Text = "Pokaż tylko aktywne umowy";
            checkBox_tylkoAktywne.UseVisualStyleBackColor = true;
            checkBox_tylkoAktywne.CheckedChanged += checkBox_tylkoAktywne_CheckedChanged;
            // 
            // comboBox_filtrPracownik
            // 
            comboBox_filtrPracownik.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_filtrPracownik.FormattingEnabled = true;
            comboBox_filtrPracownik.Location = new Point(608, 16);
            comboBox_filtrPracownik.Name = "comboBox_filtrPracownik";
            comboBox_filtrPracownik.Size = new Size(314, 33);
            comboBox_filtrPracownik.TabIndex = 8;
            comboBox_filtrPracownik.SelectedIndexChanged += comboBox_filtrPracownik_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F);
            label5.Location = new Point(503, 19);
            label5.Name = "label5";
            label5.Size = new Size(99, 25);
            label5.TabIndex = 5;
            label5.Text = "Pracownik";
            // 
            // Form_Umowy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(934, 711);
            Controls.Add(comboBox_filtrPracownik);
            Controls.Add(checkBox_tylkoAktywne);
            Controls.Add(dataGridView_umowy);
            Controls.Add(panel1);
            Controls.Add(button_nowaumowa);
            Controls.Add(label5);
            Name = "Form_Umowy";
            Text = "Form_Umowy";
            Load += Form_Umowy_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_umowy).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_umowy;
        private ComboBox comboBox_pracownik;
        private ComboBox comboBox_rodzajUmowy;
        private DateTimePicker dateTimePicker_dataroz;
        private Button button_dodajUmowe;
        private DateTimePicker dateTimePicker_datazak;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Button button_nowaumowa;
        private CheckBox checkBox_tylkoAktywne;
        private ComboBox comboBox_filtrPracownik;
        private Label label5;
    }
}