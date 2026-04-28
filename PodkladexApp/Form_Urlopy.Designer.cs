namespace PodkladexApp
{
    partial class Form_Urlopy
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
            dataGridView_urlopy = new DataGridView();
            button_odswiez = new Button();
            button_zatwierdz = new Button();
            checkBox_tylkoNiezatwierdzone = new CheckBox();
            button_dodajWniosek = new Button();
            dateTimePicker_datarozp = new DateTimePicker();
            dateTimePicker_datazak = new DateTimePicker();
            label1 = new Label();
            panel1 = new Panel();
            label_datazak = new Label();
            button_dodajWniosekdoZatwierdzenia = new Button();
            label_rodzajurlopu = new Label();
            label_pracownik = new Label();
            label_datarozp = new Label();
            comboBox_Rodzaj_Urlopu = new ComboBox();
            comboBox_Dane_Pracownika = new ComboBox();
            comboBox_filtrPracownik = new ComboBox();
            label_filtr = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_urlopy).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView_urlopy
            // 
            dataGridView_urlopy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_urlopy.Location = new Point(17, 44);
            dataGridView_urlopy.Margin = new Padding(9, 8, 9, 8);
            dataGridView_urlopy.Name = "dataGridView_urlopy";
            dataGridView_urlopy.RowHeadersWidth = 51;
            dataGridView_urlopy.Size = new Size(690, 193);
            dataGridView_urlopy.TabIndex = 0;
            // 
            // button_odswiez
            // 
            button_odswiez.Location = new Point(17, 244);
            button_odswiez.Margin = new Padding(3, 2, 3, 2);
            button_odswiez.Name = "button_odswiez";
            button_odswiez.Size = new Size(82, 22);
            button_odswiez.TabIndex = 1;
            button_odswiez.Text = "Odśwież";
            button_odswiez.UseVisualStyleBackColor = true;
            button_odswiez.Click += button_odswiez_Click;
            // 
            // button_zatwierdz
            // 
            button_zatwierdz.Location = new Point(315, 244);
            button_zatwierdz.Margin = new Padding(3, 2, 3, 2);
            button_zatwierdz.Name = "button_zatwierdz";
            button_zatwierdz.Size = new Size(82, 22);
            button_zatwierdz.TabIndex = 2;
            button_zatwierdz.Text = "Zatwierdź";
            button_zatwierdz.UseVisualStyleBackColor = true;
            button_zatwierdz.Click += button_zatwierdz_Click;
            // 
            // checkBox_tylkoNiezatwierdzone
            // 
            checkBox_tylkoNiezatwierdzone.AutoSize = true;
            checkBox_tylkoNiezatwierdzone.Location = new Point(17, 16);
            checkBox_tylkoNiezatwierdzone.Margin = new Padding(3, 2, 3, 2);
            checkBox_tylkoNiezatwierdzone.Name = "checkBox_tylkoNiezatwierdzone";
            checkBox_tylkoNiezatwierdzone.Size = new Size(190, 19);
            checkBox_tylkoNiezatwierdzone.TabIndex = 3;
            checkBox_tylkoNiezatwierdzone.Text = "Wyświetl tylko niezatwierdzone";
            checkBox_tylkoNiezatwierdzone.UseVisualStyleBackColor = true;
            checkBox_tylkoNiezatwierdzone.CheckedChanged += checkBox_tylkoNiezatwierdzone_CheckedChanged;
            // 
            // button_dodajWniosek
            // 
            button_dodajWniosek.Location = new Point(613, 242);
            button_dodajWniosek.Margin = new Padding(3, 2, 3, 2);
            button_dodajWniosek.Name = "button_dodajWniosek";
            button_dodajWniosek.Size = new Size(82, 22);
            button_dodajWniosek.TabIndex = 4;
            button_dodajWniosek.Text = "Dodaj wniosek";
            button_dodajWniosek.UseVisualStyleBackColor = true;
            button_dodajWniosek.Click += button_dodajWniosek_Click;
            // 
            // dateTimePicker_datarozp
            // 
            dateTimePicker_datarozp.Location = new Point(192, 84);
            dateTimePicker_datarozp.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker_datarozp.Name = "dateTimePicker_datarozp";
            dateTimePicker_datarozp.Size = new Size(247, 23);
            dateTimePicker_datarozp.TabIndex = 0;
            // 
            // dateTimePicker_datazak
            // 
            dateTimePicker_datazak.Location = new Point(192, 114);
            dateTimePicker_datazak.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker_datazak.Name = "dateTimePicker_datazak";
            dateTimePicker_datazak.Size = new Size(247, 23);
            dateTimePicker_datazak.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 17);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(label_datazak);
            panel1.Controls.Add(button_dodajWniosekdoZatwierdzenia);
            panel1.Controls.Add(label_rodzajurlopu);
            panel1.Controls.Add(label_pracownik);
            panel1.Controls.Add(label_datarozp);
            panel1.Controls.Add(comboBox_Rodzaj_Urlopu);
            panel1.Controls.Add(comboBox_Dane_Pracownika);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateTimePicker_datazak);
            panel1.Controls.Add(dateTimePicker_datarozp);
            panel1.Location = new Point(17, 271);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(687, 212);
            panel1.TabIndex = 5;
            // 
            // label_datazak
            // 
            label_datazak.AutoSize = true;
            label_datazak.Location = new Point(11, 116);
            label_datazak.Name = "label_datazak";
            label_datazak.Size = new Size(136, 15);
            label_datazak.TabIndex = 4;
            label_datazak.Text = "Data zakończenia urlopu";
            // 
            // button_dodajWniosekdoZatwierdzenia
            // 
            button_dodajWniosekdoZatwierdzenia.Location = new Point(230, 166);
            button_dodajWniosekdoZatwierdzenia.Margin = new Padding(3, 2, 3, 2);
            button_dodajWniosekdoZatwierdzenia.Name = "button_dodajWniosekdoZatwierdzenia";
            button_dodajWniosekdoZatwierdzenia.Size = new Size(209, 22);
            button_dodajWniosekdoZatwierdzenia.TabIndex = 4;
            button_dodajWniosekdoZatwierdzenia.Text = "Dodaj wniosek do zatwierdzenia";
            button_dodajWniosekdoZatwierdzenia.UseVisualStyleBackColor = true;
            button_dodajWniosekdoZatwierdzenia.Click += button_dodajWniosekdoZatwierdzenia_Click;
            // 
            // label_rodzajurlopu
            // 
            label_rodzajurlopu.AutoSize = true;
            label_rodzajurlopu.Location = new Point(13, 51);
            label_rodzajurlopu.Name = "label_rodzajurlopu";
            label_rodzajurlopu.Size = new Size(80, 15);
            label_rodzajurlopu.TabIndex = 4;
            label_rodzajurlopu.Text = "Rodzaj urlopu";
            // 
            // label_pracownik
            // 
            label_pracownik.AutoSize = true;
            label_pracownik.Location = new Point(13, 26);
            label_pracownik.Name = "label_pracownik";
            label_pracownik.Size = new Size(62, 15);
            label_pracownik.TabIndex = 4;
            label_pracownik.Text = "Pracownik";
            // 
            // label_datarozp
            // 
            label_datarozp.AutoSize = true;
            label_datarozp.Location = new Point(11, 86);
            label_datarozp.Name = "label_datarozp";
            label_datarozp.Size = new Size(134, 15);
            label_datarozp.TabIndex = 4;
            label_datarozp.Text = "Data rozpoczęcia urlopu";
            // 
            // comboBox_Rodzaj_Urlopu
            // 
            comboBox_Rodzaj_Urlopu.FormattingEnabled = true;
            comboBox_Rodzaj_Urlopu.Location = new Point(113, 49);
            comboBox_Rodzaj_Urlopu.Margin = new Padding(3, 2, 3, 2);
            comboBox_Rodzaj_Urlopu.Name = "comboBox_Rodzaj_Urlopu";
            comboBox_Rodzaj_Urlopu.Size = new Size(522, 23);
            comboBox_Rodzaj_Urlopu.TabIndex = 3;
            // 
            // comboBox_Dane_Pracownika
            // 
            comboBox_Dane_Pracownika.FormattingEnabled = true;
            comboBox_Dane_Pracownika.Location = new Point(113, 23);
            comboBox_Dane_Pracownika.Margin = new Padding(3, 2, 3, 2);
            comboBox_Dane_Pracownika.Name = "comboBox_Dane_Pracownika";
            comboBox_Dane_Pracownika.Size = new Size(522, 23);
            comboBox_Dane_Pracownika.TabIndex = 3;
            // 
            // comboBox_filtrPracownik
            // 
            comboBox_filtrPracownik.FormattingEnabled = true;
            comboBox_filtrPracownik.Location = new Point(389, 14);
            comboBox_filtrPracownik.Margin = new Padding(3, 2, 3, 2);
            comboBox_filtrPracownik.Name = "comboBox_filtrPracownik";
            comboBox_filtrPracownik.Size = new Size(315, 23);
            comboBox_filtrPracownik.TabIndex = 5;
            comboBox_filtrPracownik.SelectedIndexChanged += comboBox_filtrPracownik_SelectedIndexChanged;
            // 
            // label_filtr
            // 
            label_filtr.AutoSize = true;
            label_filtr.Location = new Point(303, 19);
            label_filtr.Name = "label_filtr";
            label_filtr.Size = new Size(65, 15);
            label_filtr.TabIndex = 6;
            label_filtr.Text = "Pracownik:";
            // 
            // Form_Urlopy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 524);
            Controls.Add(label_filtr);
            Controls.Add(comboBox_filtrPracownik);
            Controls.Add(panel1);
            Controls.Add(button_dodajWniosek);
            Controls.Add(checkBox_tylkoNiezatwierdzone);
            Controls.Add(button_zatwierdz);
            Controls.Add(button_odswiez);
            Controls.Add(dataGridView_urlopy);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_Urlopy";
            Text = "Form_Urlopy";
            Load += Form_Urlopy_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_urlopy).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_urlopy;
        private Button button_odswiez;
        private Button button_zatwierdz;
        private CheckBox checkBox_tylkoNiezatwierdzone;
        private Button button_dodajWniosek;
        private DateTimePicker dateTimePicker_datarozp;
        private DateTimePicker dateTimePicker_datazak;
        private Label label1;
        private Panel panel1;
        private Label label_datazak;
        private Label label_pracownik;
        private Label label_datarozp;
        private ComboBox comboBox_Dane_Pracownika;
        private Label label_rodzajurlopu;
        private ComboBox comboBox_Rodzaj_Urlopu;
        private Button button_dodajWniosekdoZatwierdzenia;
        private ComboBox comboBox_filtrPracownik;
        private Label label_filtr;
    }
}