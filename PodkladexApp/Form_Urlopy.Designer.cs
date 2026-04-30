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
            dataGridView_urlopy.Location = new Point(17, 55);
            dataGridView_urlopy.Margin = new Padding(9, 8, 9, 8);
            dataGridView_urlopy.Name = "dataGridView_urlopy";
            dataGridView_urlopy.RowHeadersWidth = 51;
            dataGridView_urlopy.Size = new Size(1390, 409);
            dataGridView_urlopy.TabIndex = 0;
            // 
            // button_zatwierdz
            // 
            button_zatwierdz.Font = new Font("Segoe UI", 14.25F);
            button_zatwierdz.Location = new Point(473, 474);
            button_zatwierdz.Margin = new Padding(3, 2, 3, 2);
            button_zatwierdz.Name = "button_zatwierdz";
            button_zatwierdz.Size = new Size(203, 51);
            button_zatwierdz.TabIndex = 2;
            button_zatwierdz.Text = "Zatwierdź wniosek";
            button_zatwierdz.UseVisualStyleBackColor = true;
            button_zatwierdz.Click += button_zatwierdz_Click;
            // 
            // checkBox_tylkoNiezatwierdzone
            // 
            checkBox_tylkoNiezatwierdzone.AutoSize = true;
            checkBox_tylkoNiezatwierdzone.Font = new Font("Segoe UI", 14.25F);
            checkBox_tylkoNiezatwierdzone.Location = new Point(17, 12);
            checkBox_tylkoNiezatwierdzone.Margin = new Padding(3, 2, 3, 2);
            checkBox_tylkoNiezatwierdzone.Name = "checkBox_tylkoNiezatwierdzone";
            checkBox_tylkoNiezatwierdzone.Size = new Size(295, 29);
            checkBox_tylkoNiezatwierdzone.TabIndex = 3;
            checkBox_tylkoNiezatwierdzone.Text = "Wyświetl tylko niezatwierdzone";
            checkBox_tylkoNiezatwierdzone.UseVisualStyleBackColor = true;
            checkBox_tylkoNiezatwierdzone.CheckedChanged += checkBox_tylkoNiezatwierdzone_CheckedChanged;
            // 
            // button_dodajWniosek
            // 
            button_dodajWniosek.Font = new Font("Segoe UI", 14.25F);
            button_dodajWniosek.Location = new Point(769, 474);
            button_dodajWniosek.Margin = new Padding(3, 2, 3, 2);
            button_dodajWniosek.Name = "button_dodajWniosek";
            button_dodajWniosek.Size = new Size(162, 51);
            button_dodajWniosek.TabIndex = 4;
            button_dodajWniosek.Text = "Dodaj wniosek";
            button_dodajWniosek.UseVisualStyleBackColor = true;
            button_dodajWniosek.Click += button_dodajWniosek_Click;
            // 
            // dateTimePicker_datarozp
            // 
            dateTimePicker_datarozp.Font = new Font("Segoe UI", 14.25F);
            dateTimePicker_datarozp.Location = new Point(588, 101);
            dateTimePicker_datarozp.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker_datarozp.Name = "dateTimePicker_datarozp";
            dateTimePicker_datarozp.Size = new Size(476, 33);
            dateTimePicker_datarozp.TabIndex = 0;
            // 
            // dateTimePicker_datazak
            // 
            dateTimePicker_datazak.Font = new Font("Segoe UI", 14.25F);
            dateTimePicker_datazak.Location = new Point(588, 138);
            dateTimePicker_datazak.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker_datazak.Name = "dateTimePicker_datazak";
            dateTimePicker_datazak.Size = new Size(476, 33);
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
            panel1.Location = new Point(17, 545);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1395, 255);
            panel1.TabIndex = 5;
            // 
            // label_datazak
            // 
            label_datazak.AutoSize = true;
            label_datazak.Font = new Font("Segoe UI", 14.25F);
            label_datazak.Location = new Point(347, 143);
            label_datazak.Name = "label_datazak";
            label_datazak.Size = new Size(221, 25);
            label_datazak.TabIndex = 4;
            label_datazak.Text = "Data zakończenia urlopu";
            // 
            // button_dodajWniosekdoZatwierdzenia
            // 
            button_dodajWniosekdoZatwierdzenia.Font = new Font("Segoe UI", 14.25F);
            button_dodajWniosekdoZatwierdzenia.Location = new Point(542, 184);
            button_dodajWniosekdoZatwierdzenia.Margin = new Padding(3, 2, 3, 2);
            button_dodajWniosekdoZatwierdzenia.Name = "button_dodajWniosekdoZatwierdzenia";
            button_dodajWniosekdoZatwierdzenia.Size = new Size(319, 51);
            button_dodajWniosekdoZatwierdzenia.TabIndex = 4;
            button_dodajWniosekdoZatwierdzenia.Text = "Dodaj wniosek do zatwierdzenia";
            button_dodajWniosekdoZatwierdzenia.UseVisualStyleBackColor = true;
            button_dodajWniosekdoZatwierdzenia.Click += button_dodajWniosekdoZatwierdzenia_Click;
            // 
            // label_rodzajurlopu
            // 
            label_rodzajurlopu.AutoSize = true;
            label_rodzajurlopu.Font = new Font("Segoe UI", 14.25F);
            label_rodzajurlopu.Location = new Point(347, 66);
            label_rodzajurlopu.Name = "label_rodzajurlopu";
            label_rodzajurlopu.Size = new Size(129, 25);
            label_rodzajurlopu.TabIndex = 4;
            label_rodzajurlopu.Text = "Rodzaj urlopu";
            // 
            // label_pracownik
            // 
            label_pracownik.AutoSize = true;
            label_pracownik.Font = new Font("Segoe UI", 14.25F);
            label_pracownik.Location = new Point(347, 31);
            label_pracownik.Name = "label_pracownik";
            label_pracownik.Size = new Size(99, 25);
            label_pracownik.TabIndex = 4;
            label_pracownik.Text = "Pracownik";
            // 
            // label_datarozp
            // 
            label_datarozp.AutoSize = true;
            label_datarozp.Font = new Font("Segoe UI", 14.25F);
            label_datarozp.Location = new Point(347, 101);
            label_datarozp.Name = "label_datarozp";
            label_datarozp.Size = new Size(218, 25);
            label_datarozp.TabIndex = 4;
            label_datarozp.Text = "Data rozpoczęcia urlopu";
            // 
            // comboBox_Rodzaj_Urlopu
            // 
            comboBox_Rodzaj_Urlopu.Font = new Font("Segoe UI", 14.25F);
            comboBox_Rodzaj_Urlopu.FormattingEnabled = true;
            comboBox_Rodzaj_Urlopu.Location = new Point(510, 64);
            comboBox_Rodzaj_Urlopu.Margin = new Padding(3, 2, 3, 2);
            comboBox_Rodzaj_Urlopu.Name = "comboBox_Rodzaj_Urlopu";
            comboBox_Rodzaj_Urlopu.Size = new Size(563, 33);
            comboBox_Rodzaj_Urlopu.TabIndex = 3;
            // 
            // comboBox_Dane_Pracownika
            // 
            comboBox_Dane_Pracownika.Font = new Font("Segoe UI", 14.25F);
            comboBox_Dane_Pracownika.FormattingEnabled = true;
            comboBox_Dane_Pracownika.Location = new Point(510, 27);
            comboBox_Dane_Pracownika.Margin = new Padding(3, 2, 3, 2);
            comboBox_Dane_Pracownika.Name = "comboBox_Dane_Pracownika";
            comboBox_Dane_Pracownika.Size = new Size(563, 33);
            comboBox_Dane_Pracownika.TabIndex = 3;
            comboBox_Dane_Pracownika.SelectedIndexChanged += comboBox_Dane_Pracownika_SelectedIndexChanged;
            comboBox_Dane_Pracownika.TextUpdate += comboBox_Dane_Pracownika_TextUpdate;
            // 
            // comboBox_filtrPracownik
            // 
            comboBox_filtrPracownik.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_filtrPracownik.FormattingEnabled = true;
            comboBox_filtrPracownik.Location = new Point(1092, 11);
            comboBox_filtrPracownik.Margin = new Padding(3, 2, 3, 2);
            comboBox_filtrPracownik.Name = "comboBox_filtrPracownik";
            comboBox_filtrPracownik.Size = new Size(315, 33);
            comboBox_filtrPracownik.TabIndex = 5;
            comboBox_filtrPracownik.SelectedIndexChanged += comboBox_filtrPracownik_SelectedIndexChanged;
            comboBox_filtrPracownik.TextUpdate += comboBox_filtrPracownik_TextUpdate;
            // 
            // label_filtr
            // 
            label_filtr.AutoSize = true;
            label_filtr.Font = new Font("Segoe UI", 14.25F);
            label_filtr.Location = new Point(886, 14);
            label_filtr.Name = "label_filtr";
            label_filtr.Size = new Size(194, 25);
            label_filtr.TabIndex = 6;
            label_filtr.Text = "Filtruj po pracowniku:";
            // 
            // Form_Urlopy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1424, 811);
            Controls.Add(label_filtr);
            Controls.Add(comboBox_filtrPracownik);
            Controls.Add(panel1);
            Controls.Add(button_dodajWniosek);
            Controls.Add(checkBox_tylkoNiezatwierdzone);
            Controls.Add(button_zatwierdz);
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