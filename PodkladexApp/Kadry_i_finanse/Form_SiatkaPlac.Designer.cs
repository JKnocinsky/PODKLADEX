namespace PodkladexApp.Kadry_i_finanse
{
    partial class Form_SiatkaPlac
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
            dataGridView_siatkaPlac = new DataGridView();
            label_pracownik = new Label();
            label_okresUmowy = new Label();
            dateTimePicker_dataPocz = new DateTimePicker();
            dateTimePicker_dataKoniec = new DateTimePicker();
            textBox_wynagrodzenie = new TextBox();
            button_dodajWpis = new Button();
            button_zatwierdzZmiany = new Button();
            button_wyczysc = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_siatkaPlac).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_siatkaPlac
            // 
            dataGridView_siatkaPlac.AllowUserToAddRows = false;
            dataGridView_siatkaPlac.AllowUserToDeleteRows = false;
            dataGridView_siatkaPlac.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_siatkaPlac.Location = new Point(405, 12);
            dataGridView_siatkaPlac.Name = "dataGridView_siatkaPlac";
            dataGridView_siatkaPlac.ReadOnly = true;
            dataGridView_siatkaPlac.Size = new Size(383, 197);
            dataGridView_siatkaPlac.TabIndex = 0;
            // 
            // label_pracownik
            // 
            label_pracownik.AutoSize = true;
            label_pracownik.Font = new Font("Segoe UI", 14.25F);
            label_pracownik.Location = new Point(12, 28);
            label_pracownik.Name = "label_pracownik";
            label_pracownik.Size = new Size(63, 25);
            label_pracownik.TabIndex = 1;
            label_pracownik.Text = "label1";
            // 
            // label_okresUmowy
            // 
            label_okresUmowy.AutoSize = true;
            label_okresUmowy.Font = new Font("Segoe UI", 14.25F);
            label_okresUmowy.Location = new Point(12, 83);
            label_okresUmowy.Name = "label_okresUmowy";
            label_okresUmowy.Size = new Size(63, 25);
            label_okresUmowy.TabIndex = 2;
            label_okresUmowy.Text = "label2";
            // 
            // dateTimePicker_dataPocz
            // 
            dateTimePicker_dataPocz.CustomFormat = "MM.yyyy";
            dateTimePicker_dataPocz.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_dataPocz.Format = DateTimePickerFormat.Custom;
            dateTimePicker_dataPocz.Location = new Point(108, 251);
            dateTimePicker_dataPocz.Name = "dateTimePicker_dataPocz";
            dateTimePicker_dataPocz.Size = new Size(352, 33);
            dateTimePicker_dataPocz.TabIndex = 3;
            // 
            // dateTimePicker_dataKoniec
            // 
            dateTimePicker_dataKoniec.CustomFormat = "MM.yyyy";
            dateTimePicker_dataKoniec.Font = new Font("Segoe UI", 14.25F);
            dateTimePicker_dataKoniec.Format = DateTimePickerFormat.Custom;
            dateTimePicker_dataKoniec.Location = new Point(108, 299);
            dateTimePicker_dataKoniec.Name = "dateTimePicker_dataKoniec";
            dateTimePicker_dataKoniec.Size = new Size(352, 33);
            dateTimePicker_dataKoniec.TabIndex = 3;
            // 
            // textBox_wynagrodzenie
            // 
            textBox_wynagrodzenie.Font = new Font("Segoe UI", 14.25F);
            textBox_wynagrodzenie.Location = new Point(108, 351);
            textBox_wynagrodzenie.Name = "textBox_wynagrodzenie";
            textBox_wynagrodzenie.Size = new Size(352, 33);
            textBox_wynagrodzenie.TabIndex = 4;
            // 
            // button_dodajWpis
            // 
            button_dodajWpis.Font = new Font("Segoe UI", 14.25F);
            button_dodajWpis.Location = new Point(177, 406);
            button_dodajWpis.Name = "button_dodajWpis";
            button_dodajWpis.Size = new Size(178, 32);
            button_dodajWpis.TabIndex = 5;
            button_dodajWpis.Text = "Dodaj wpis";
            button_dodajWpis.UseVisualStyleBackColor = true;
            button_dodajWpis.Click += button_dodajWpis_Click;
            // 
            // button_zatwierdzZmiany
            // 
            button_zatwierdzZmiany.Enabled = false;
            button_zatwierdzZmiany.Font = new Font("Segoe UI", 14.25F);
            button_zatwierdzZmiany.Location = new Point(204, 406);
            button_zatwierdzZmiany.Name = "button_zatwierdzZmiany";
            button_zatwierdzZmiany.Size = new Size(118, 32);
            button_zatwierdzZmiany.TabIndex = 5;
            button_zatwierdzZmiany.Text = "Zatwierdź zmiany";
            button_zatwierdzZmiany.UseVisualStyleBackColor = true;
            button_zatwierdzZmiany.Visible = false;
            button_zatwierdzZmiany.Click += button_zatwierdzZmiany_Click;
            // 
            // button_wyczysc
            // 
            button_wyczysc.Font = new Font("Segoe UI", 14.25F);
            button_wyczysc.Location = new Point(458, 406);
            button_wyczysc.Name = "button_wyczysc";
            button_wyczysc.Size = new Size(118, 32);
            button_wyczysc.TabIndex = 5;
            button_wyczysc.Text = "Wyczyść";
            button_wyczysc.UseVisualStyleBackColor = true;
            button_wyczysc.Click += button_wyczysc_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.Location = new Point(14, 251);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 1;
            label1.Text = "Data od:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(14, 305);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 1;
            label2.Text = "Data do:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(14, 354);
            label3.Name = "label3";
            label3.Size = new Size(67, 25);
            label3.TabIndex = 1;
            label3.Text = "Kwota:";
            // 
            // Form_SiatkaPlac
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_wyczysc);
            Controls.Add(button_zatwierdzZmiany);
            Controls.Add(button_dodajWpis);
            Controls.Add(textBox_wynagrodzenie);
            Controls.Add(dateTimePicker_dataKoniec);
            Controls.Add(dateTimePicker_dataPocz);
            Controls.Add(label_okresUmowy);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label_pracownik);
            Controls.Add(dataGridView_siatkaPlac);
            Name = "Form_SiatkaPlac";
            Text = "Siatka Płac";
            Load += Form_SiatkaPlac_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_siatkaPlac).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_siatkaPlac;
        private Label label_pracownik;
        private Label label_okresUmowy;
        private DateTimePicker dateTimePicker_dataPocz;
        private DateTimePicker dateTimePicker_dataKoniec;
        private TextBox textBox_wynagrodzenie;
        private Button button_dodajWpis;
        private Button button_zatwierdzZmiany;
        private Button button_wyczysc;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}