namespace PodkladexApp
{
    partial class Form_Obsluga
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
            label1 = new Label();
            textBox_RBH = new TextBox();
            label2 = new Label();
            comboBox_rodzaj_obslugi = new ComboBox();
            panel_posredniczaca = new Panel();
            button_usun = new Button();
            button_edycja = new Button();
            button_dodaj_czesc_awaria_posredniczaca = new Button();
            dataGridView1 = new DataGridView();
            num_ud_liczba_czesci = new NumericUpDown();
            label_liczba = new Label();
            cbox_czesc = new ComboBox();
            label_opis2 = new Label();
            label_czesc = new Label();
            tbox_opis_awaria_czesc = new TextBox();
            label3 = new Label();
            comboBox_lista_awarii = new ComboBox();
            button_dodaj_czesc = new Button();
            button_zglos_awarie = new Button();
            label_maszyna = new Label();
            cbox_maszyna = new ComboBox();
            label_osoby = new Label();
            cbox_osoby = new ComboBox();
            label_datausuniecia = new Label();
            dtp_data_usuniecia = new DateTimePicker();
            label_datazgloszenia = new Label();
            dtp_data_zgloszenia = new DateTimePicker();
            label4 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button_potwierdz = new Button();
            panel1 = new Panel();
            button2 = new Button();
            panel2 = new Panel();
            panel_posredniczaca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_ud_liczba_czesci).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(517, 62);
            label1.Name = "label1";
            label1.Size = new Size(47, 25);
            label1.TabIndex = 21;
            label1.Text = "RBH";
            // 
            // textBox_RBH
            // 
            textBox_RBH.Font = new Font("Segoe UI", 14F);
            textBox_RBH.Location = new Point(517, 89);
            textBox_RBH.Name = "textBox_RBH";
            textBox_RBH.Size = new Size(266, 32);
            textBox_RBH.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(517, 0);
            label2.Name = "label2";
            label2.Size = new Size(135, 25);
            label2.TabIndex = 23;
            label2.Text = "Rodzaj obsługi";
            // 
            // comboBox_rodzaj_obslugi
            // 
            comboBox_rodzaj_obslugi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_rodzaj_obslugi.Font = new Font("Segoe UI", 14F);
            comboBox_rodzaj_obslugi.FormattingEnabled = true;
            comboBox_rodzaj_obslugi.Location = new Point(517, 29);
            comboBox_rodzaj_obslugi.Name = "comboBox_rodzaj_obslugi";
            comboBox_rodzaj_obslugi.Size = new Size(266, 33);
            comboBox_rodzaj_obslugi.TabIndex = 22;
            // 
            // panel_posredniczaca
            // 
            panel_posredniczaca.Controls.Add(button_usun);
            panel_posredniczaca.Controls.Add(button_edycja);
            panel_posredniczaca.Controls.Add(button_dodaj_czesc_awaria_posredniczaca);
            panel_posredniczaca.Controls.Add(dataGridView1);
            panel_posredniczaca.Controls.Add(num_ud_liczba_czesci);
            panel_posredniczaca.Controls.Add(label_liczba);
            panel_posredniczaca.Controls.Add(cbox_czesc);
            panel_posredniczaca.Controls.Add(label_opis2);
            panel_posredniczaca.Controls.Add(label_czesc);
            panel_posredniczaca.Controls.Add(tbox_opis_awaria_czesc);
            panel_posredniczaca.Location = new Point(215, 282);
            panel_posredniczaca.Margin = new Padding(3, 2, 3, 2);
            panel_posredniczaca.Name = "panel_posredniczaca";
            panel_posredniczaca.Size = new Size(884, 396);
            panel_posredniczaca.TabIndex = 36;
            // 
            // button_usun
            // 
            button_usun.Font = new Font("Segoe UI", 14F);
            button_usun.Location = new Point(9, 139);
            button_usun.Name = "button_usun";
            button_usun.Size = new Size(190, 58);
            button_usun.TabIndex = 21;
            button_usun.Text = "Usuń Część";
            button_usun.UseVisualStyleBackColor = true;
            button_usun.Click += button_usun_Click;
            // 
            // button_edycja
            // 
            button_edycja.Font = new Font("Segoe UI", 14F);
            button_edycja.Location = new Point(9, 74);
            button_edycja.Name = "button_edycja";
            button_edycja.Size = new Size(190, 58);
            button_edycja.TabIndex = 20;
            button_edycja.Text = "Edytuj Część";
            button_edycja.UseVisualStyleBackColor = true;
            button_edycja.Click += button_edycja_Click;
            // 
            // button_dodaj_czesc_awaria_posredniczaca
            // 
            button_dodaj_czesc_awaria_posredniczaca.Font = new Font("Segoe UI", 14F);
            button_dodaj_czesc_awaria_posredniczaca.Location = new Point(9, 10);
            button_dodaj_czesc_awaria_posredniczaca.Name = "button_dodaj_czesc_awaria_posredniczaca";
            button_dodaj_czesc_awaria_posredniczaca.Size = new Size(190, 58);
            button_dodaj_czesc_awaria_posredniczaca.TabIndex = 19;
            button_dodaj_czesc_awaria_posredniczaca.Text = "Dodaj Część";
            button_dodaj_czesc_awaria_posredniczaca.UseVisualStyleBackColor = true;
            button_dodaj_czesc_awaria_posredniczaca.Click += button_dodaj_czesc_awaria_posredniczaca_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(213, 74);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(662, 319);
            dataGridView1.TabIndex = 16;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // num_ud_liczba_czesci
            // 
            num_ud_liczba_czesci.Font = new Font("Segoe UI", 14F);
            num_ud_liczba_czesci.Location = new Point(425, 35);
            num_ud_liczba_czesci.Margin = new Padding(3, 4, 3, 4);
            num_ud_liczba_czesci.Name = "num_ud_liczba_czesci";
            num_ud_liczba_czesci.Size = new Size(69, 32);
            num_ud_liczba_czesci.TabIndex = 10;
            // 
            // label_liczba
            // 
            label_liczba.AutoSize = true;
            label_liczba.Font = new Font("Segoe UI", 14F);
            label_liczba.Location = new Point(425, 10);
            label_liczba.Name = "label_liczba";
            label_liczba.Size = new Size(65, 25);
            label_liczba.TabIndex = 11;
            label_liczba.Text = "Liczba";
            // 
            // cbox_czesc
            // 
            cbox_czesc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_czesc.Font = new Font("Segoe UI", 14F);
            cbox_czesc.FormattingEnabled = true;
            cbox_czesc.Location = new Point(213, 35);
            cbox_czesc.Name = "cbox_czesc";
            cbox_czesc.Size = new Size(197, 33);
            cbox_czesc.TabIndex = 12;
            // 
            // label_opis2
            // 
            label_opis2.AutoSize = true;
            label_opis2.Font = new Font("Segoe UI", 14F);
            label_opis2.Location = new Point(510, 10);
            label_opis2.Name = "label_opis2";
            label_opis2.Size = new Size(50, 25);
            label_opis2.TabIndex = 15;
            label_opis2.Text = "Opis";
            // 
            // label_czesc
            // 
            label_czesc.AutoSize = true;
            label_czesc.Font = new Font("Segoe UI", 14F);
            label_czesc.Location = new Point(218, 10);
            label_czesc.Name = "label_czesc";
            label_czesc.Size = new Size(60, 25);
            label_czesc.TabIndex = 13;
            label_czesc.Text = "Część";
            // 
            // tbox_opis_awaria_czesc
            // 
            tbox_opis_awaria_czesc.Font = new Font("Segoe UI", 14F);
            tbox_opis_awaria_czesc.Location = new Point(510, 36);
            tbox_opis_awaria_czesc.Multiline = true;
            tbox_opis_awaria_czesc.Name = "tbox_opis_awaria_czesc";
            tbox_opis_awaria_czesc.Size = new Size(365, 32);
            tbox_opis_awaria_czesc.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(135, 25);
            label3.TabIndex = 18;
            label3.Text = "Wybór obsługi";
            // 
            // comboBox_lista_awarii
            // 
            comboBox_lista_awarii.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_lista_awarii.Font = new Font("Segoe UI", 14F);
            comboBox_lista_awarii.FormattingEnabled = true;
            comboBox_lista_awarii.Location = new Point(3, 28);
            comboBox_lista_awarii.Name = "comboBox_lista_awarii";
            comboBox_lista_awarii.Size = new Size(776, 33);
            comboBox_lista_awarii.TabIndex = 17;
            comboBox_lista_awarii.SelectedIndexChanged += comboBox_lista_awarii_SelectedIndexChanged;
            // 
            // button_dodaj_czesc
            // 
            button_dodaj_czesc.Font = new Font("Segoe UI", 14F);
            button_dodaj_czesc.Location = new Point(19, 181);
            button_dodaj_czesc.Name = "button_dodaj_czesc";
            button_dodaj_czesc.Size = new Size(190, 67);
            button_dodaj_czesc.TabIndex = 35;
            button_dodaj_czesc.Text = "Dodaj Części Do Obsługi";
            button_dodaj_czesc.UseVisualStyleBackColor = true;
            button_dodaj_czesc.Click += button_dodaj_czesc_Click;
            // 
            // button_zglos_awarie
            // 
            button_zglos_awarie.Font = new Font("Segoe UI", 14F);
            button_zglos_awarie.Location = new Point(19, 10);
            button_zglos_awarie.Name = "button_zglos_awarie";
            button_zglos_awarie.Size = new Size(190, 51);
            button_zglos_awarie.TabIndex = 34;
            button_zglos_awarie.Text = "Zgłoś Obsługe";
            button_zglos_awarie.UseVisualStyleBackColor = true;
            button_zglos_awarie.Click += button_zglos_awarie_Click;
            // 
            // label_maszyna
            // 
            label_maszyna.AutoSize = true;
            label_maszyna.Font = new Font("Segoe UI", 14F);
            label_maszyna.Location = new Point(217, 0);
            label_maszyna.Name = "label_maszyna";
            label_maszyna.Size = new Size(86, 25);
            label_maszyna.TabIndex = 33;
            label_maszyna.Text = "Maszyna";
            // 
            // cbox_maszyna
            // 
            cbox_maszyna.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_maszyna.Font = new Font("Segoe UI", 14F);
            cbox_maszyna.FormattingEnabled = true;
            cbox_maszyna.Location = new Point(217, 29);
            cbox_maszyna.Name = "cbox_maszyna";
            cbox_maszyna.Size = new Size(277, 33);
            cbox_maszyna.TabIndex = 32;
            // 
            // label_osoby
            // 
            label_osoby.AutoSize = true;
            label_osoby.Font = new Font("Segoe UI", 14F);
            label_osoby.Location = new Point(4, 4);
            label_osoby.Name = "label_osoby";
            label_osoby.Size = new Size(65, 25);
            label_osoby.TabIndex = 31;
            label_osoby.Text = "Osoby";
            // 
            // cbox_osoby
            // 
            cbox_osoby.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_osoby.Font = new Font("Segoe UI", 14F);
            cbox_osoby.FormattingEnabled = true;
            cbox_osoby.Location = new Point(4, 29);
            cbox_osoby.Name = "cbox_osoby";
            cbox_osoby.Size = new Size(209, 33);
            cbox_osoby.TabIndex = 30;
            // 
            // label_datausuniecia
            // 
            label_datausuniecia.AutoSize = true;
            label_datausuniecia.Font = new Font("Segoe UI", 14F);
            label_datausuniecia.Location = new Point(4, 121);
            label_datausuniecia.Name = "label_datausuniecia";
            label_datausuniecia.Size = new Size(138, 25);
            label_datausuniecia.TabIndex = 29;
            label_datausuniecia.Text = "Data Usunięcia";
            // 
            // dtp_data_usuniecia
            // 
            dtp_data_usuniecia.Font = new Font("Segoe UI", 14F);
            dtp_data_usuniecia.Format = DateTimePickerFormat.Short;
            dtp_data_usuniecia.Location = new Point(4, 148);
            dtp_data_usuniecia.Name = "dtp_data_usuniecia";
            dtp_data_usuniecia.Size = new Size(209, 32);
            dtp_data_usuniecia.TabIndex = 28;
            // 
            // label_datazgloszenia
            // 
            label_datazgloszenia.AutoSize = true;
            label_datazgloszenia.Font = new Font("Segoe UI", 14F);
            label_datazgloszenia.Location = new Point(4, 62);
            label_datazgloszenia.Name = "label_datazgloszenia";
            label_datazgloszenia.Size = new Size(147, 25);
            label_datazgloszenia.TabIndex = 27;
            label_datazgloszenia.Text = "Data Zgłoszenia";
            // 
            // dtp_data_zgloszenia
            // 
            dtp_data_zgloszenia.Font = new Font("Segoe UI", 14F);
            dtp_data_zgloszenia.Format = DateTimePickerFormat.Short;
            dtp_data_zgloszenia.Location = new Point(4, 88);
            dtp_data_zgloszenia.Name = "dtp_data_zgloszenia";
            dtp_data_zgloszenia.Size = new Size(209, 32);
            dtp_data_zgloszenia.TabIndex = 26;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(217, 65);
            label4.Name = "label4";
            label4.Size = new Size(65, 25);
            label4.TabIndex = 25;
            label4.Text = "Uwagi";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.Location = new Point(217, 91);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(277, 89);
            textBox1.TabIndex = 24;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(19, 67);
            button1.Name = "button1";
            button1.Size = new Size(190, 51);
            button1.TabIndex = 37;
            button1.Text = "Edytuj Obsługe";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button_potwierdz
            // 
            button_potwierdz.Font = new Font("Segoe UI", 14F);
            button_potwierdz.Location = new Point(19, 254);
            button_potwierdz.Name = "button_potwierdz";
            button_potwierdz.Size = new Size(190, 63);
            button_potwierdz.TabIndex = 38;
            button_potwierdz.Text = "Potwierdź";
            button_potwierdz.UseVisualStyleBackColor = true;
            button_potwierdz.Click += button_potwierdz_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBox_lista_awarii);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(215, 201);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 76);
            panel1.TabIndex = 39;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(19, 124);
            button2.Name = "button2";
            button2.Size = new Size(190, 51);
            button2.TabIndex = 40;
            button2.Text = "Usuń Obsługe";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(textBox_RBH);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(comboBox_rodzaj_obslugi);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(dtp_data_zgloszenia);
            panel2.Controls.Add(label_datazgloszenia);
            panel2.Controls.Add(label_maszyna);
            panel2.Controls.Add(dtp_data_usuniecia);
            panel2.Controls.Add(cbox_maszyna);
            panel2.Controls.Add(label_datausuniecia);
            panel2.Controls.Add(label_osoby);
            panel2.Controls.Add(cbox_osoby);
            panel2.Location = new Point(215, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(794, 191);
            panel2.TabIndex = 41;
            // 
            // Form_Obsluga
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 676);
            Controls.Add(panel2);
            Controls.Add(button2);
            Controls.Add(panel1);
            Controls.Add(button_potwierdz);
            Controls.Add(button1);
            Controls.Add(panel_posredniczaca);
            Controls.Add(button_dodaj_czesc);
            Controls.Add(button_zglos_awarie);
            Name = "Form_Obsluga";
            Text = "Obsluga";
            panel_posredniczaca.ResumeLayout(false);
            panel_posredniczaca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_ud_liczba_czesci).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TextBox textBox_RBH;
        private Label label2;
        private ComboBox comboBox_rodzaj_obslugi;
        private Panel panel_posredniczaca;
        private Button button_usun;
        private Button button_edycja;
        private Button button_dodaj_czesc_awaria_posredniczaca;
        private Label label3;
        private ComboBox comboBox_lista_awarii;
        private DataGridView dataGridView1;
        private NumericUpDown num_ud_liczba_czesci;
        private Label label_liczba;
        private ComboBox cbox_czesc;
        private Label label_opis2;
        private Label label_czesc;
        private TextBox tbox_opis_awaria_czesc;
        private Button button_dodaj_czesc;
        private Button button_zglos_awarie;
        private Label label_maszyna;
        private ComboBox cbox_maszyna;
        private Label label_osoby;
        private ComboBox cbox_osoby;
        private Label label_datausuniecia;
        private DateTimePicker dtp_data_usuniecia;
        private Label label_datazgloszenia;
        private DateTimePicker dtp_data_zgloszenia;
        private Label label4;
        private TextBox textBox1;
        private Button button1;
        private Button button_potwierdz;
        private Panel panel1;
        private Button button2;
        private Panel panel2;
    }
}