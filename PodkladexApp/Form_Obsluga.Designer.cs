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
            txtb_opis_awaria = new TextBox();
            label_opis = new Label();
            dtp_data_poczatek = new DateTimePicker();
            label_datazgloszenia = new Label();
            label_datausuniecia = new Label();
            dtp_data_koniec = new DateTimePicker();
            cbox_osoby = new ComboBox();
            label_osoby = new Label();
            label_maszyna = new Label();
            cbox_maszyna = new ComboBox();
            num_ud_liczba_czesci = new NumericUpDown();
            label_liczba = new Label();
            label_czesc = new Label();
            cbox_czesc = new ComboBox();
            label_opis2 = new Label();
            tbox_opis_awaria_czesc = new TextBox();
            dataGridView1 = new DataGridView();
            button_zglos_obsluge = new Button();
            button_dodaj_czesc = new Button();
            button_powrot_z_obsluga = new Button();
            label1 = new Label();
            textBox_RBH = new TextBox();
            label2 = new Label();
            comboBox_rodzaj_obslugi = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)num_ud_liczba_czesci).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtb_opis_awaria
            // 
            txtb_opis_awaria.Location = new Point(239, 180);
            txtb_opis_awaria.Margin = new Padding(3, 4, 3, 4);
            txtb_opis_awaria.Name = "txtb_opis_awaria";
            txtb_opis_awaria.Size = new Size(289, 27);
            txtb_opis_awaria.TabIndex = 0;
            // 
            // label_opis
            // 
            label_opis.AutoSize = true;
            label_opis.Location = new Point(239, 156);
            label_opis.Name = "label_opis";
            label_opis.Size = new Size(51, 20);
            label_opis.TabIndex = 1;
            label_opis.Text = "Uwagi";
            // 
            // dtp_data_poczatek
            // 
            dtp_data_poczatek.Location = new Point(239, 40);
            dtp_data_poczatek.Margin = new Padding(3, 4, 3, 4);
            dtp_data_poczatek.Name = "dtp_data_poczatek";
            dtp_data_poczatek.Size = new Size(228, 27);
            dtp_data_poczatek.TabIndex = 2;
            // 
            // label_datazgloszenia
            // 
            label_datazgloszenia.AutoSize = true;
            label_datazgloszenia.Location = new Point(239, 12);
            label_datazgloszenia.Name = "label_datazgloszenia";
            label_datazgloszenia.Size = new Size(103, 20);
            label_datazgloszenia.TabIndex = 3;
            label_datazgloszenia.Text = "Data Początek";
            // 
            // label_datausuniecia
            // 
            label_datausuniecia.AutoSize = true;
            label_datausuniecia.Location = new Point(239, 88);
            label_datausuniecia.Name = "label_datausuniecia";
            label_datausuniecia.Size = new Size(90, 20);
            label_datausuniecia.TabIndex = 5;
            label_datausuniecia.Text = "Data Koniec";
            label_datausuniecia.Click += label3_Click;
            // 
            // dtp_data_koniec
            // 
            dtp_data_koniec.Location = new Point(239, 116);
            dtp_data_koniec.Margin = new Padding(3, 4, 3, 4);
            dtp_data_koniec.Name = "dtp_data_koniec";
            dtp_data_koniec.Size = new Size(228, 27);
            dtp_data_koniec.TabIndex = 4;
            // 
            // cbox_osoby
            // 
            cbox_osoby.FormattingEnabled = true;
            cbox_osoby.Location = new Point(47, 60);
            cbox_osoby.Margin = new Padding(3, 4, 3, 4);
            cbox_osoby.Name = "cbox_osoby";
            cbox_osoby.Size = new Size(138, 28);
            cbox_osoby.TabIndex = 6;
            // 
            // label_osoby
            // 
            label_osoby.AutoSize = true;
            label_osoby.Location = new Point(47, 36);
            label_osoby.Name = "label_osoby";
            label_osoby.Size = new Size(51, 20);
            label_osoby.TabIndex = 7;
            label_osoby.Text = "Osoby";
            // 
            // label_maszyna
            // 
            label_maszyna.AutoSize = true;
            label_maszyna.Location = new Point(47, 121);
            label_maszyna.Name = "label_maszyna";
            label_maszyna.Size = new Size(66, 20);
            label_maszyna.TabIndex = 9;
            label_maszyna.Text = "Maszyna";
            // 
            // cbox_maszyna
            // 
            cbox_maszyna.FormattingEnabled = true;
            cbox_maszyna.Location = new Point(47, 145);
            cbox_maszyna.Margin = new Padding(3, 4, 3, 4);
            cbox_maszyna.Name = "cbox_maszyna";
            cbox_maszyna.Size = new Size(138, 28);
            cbox_maszyna.TabIndex = 8;
            // 
            // num_ud_liczba_czesci
            // 
            num_ud_liczba_czesci.Location = new Point(46, 403);
            num_ud_liczba_czesci.Margin = new Padding(3, 4, 3, 4);
            num_ud_liczba_czesci.Name = "num_ud_liczba_czesci";
            num_ud_liczba_czesci.Size = new Size(137, 27);
            num_ud_liczba_czesci.TabIndex = 10;
            // 
            // label_liczba
            // 
            label_liczba.AutoSize = true;
            label_liczba.Location = new Point(45, 379);
            label_liczba.Name = "label_liczba";
            label_liczba.Size = new Size(51, 20);
            label_liczba.TabIndex = 11;
            label_liczba.Text = "Liczba";
            // 
            // label_czesc
            // 
            label_czesc.AutoSize = true;
            label_czesc.Location = new Point(45, 456);
            label_czesc.Name = "label_czesc";
            label_czesc.Size = new Size(46, 20);
            label_czesc.TabIndex = 13;
            label_czesc.Text = "Cześć";
            // 
            // cbox_czesc
            // 
            cbox_czesc.FormattingEnabled = true;
            cbox_czesc.Location = new Point(45, 480);
            cbox_czesc.Margin = new Padding(3, 4, 3, 4);
            cbox_czesc.Name = "cbox_czesc";
            cbox_czesc.Size = new Size(138, 28);
            cbox_czesc.TabIndex = 12;
            // 
            // label_opis2
            // 
            label_opis2.AutoSize = true;
            label_opis2.Location = new Point(45, 529);
            label_opis2.Name = "label_opis2";
            label_opis2.Size = new Size(39, 20);
            label_opis2.TabIndex = 15;
            label_opis2.Text = "Opis";
            // 
            // tbox_opis_awaria_czesc
            // 
            tbox_opis_awaria_czesc.Location = new Point(45, 553);
            tbox_opis_awaria_czesc.Margin = new Padding(3, 4, 3, 4);
            tbox_opis_awaria_czesc.Name = "tbox_opis_awaria_czesc";
            tbox_opis_awaria_czesc.Size = new Size(289, 27);
            tbox_opis_awaria_czesc.TabIndex = 14;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(554, 384);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(274, 200);
            dataGridView1.TabIndex = 16;
            // 
            // button_zglos_obsluge
            // 
            button_zglos_obsluge.Location = new Point(48, 196);
            button_zglos_obsluge.Margin = new Padding(3, 4, 3, 4);
            button_zglos_obsluge.Name = "button_zglos_obsluge";
            button_zglos_obsluge.Size = new Size(137, 68);
            button_zglos_obsluge.TabIndex = 17;
            button_zglos_obsluge.Text = "Zgłoś Obsługe";
            button_zglos_obsluge.UseVisualStyleBackColor = true;
            // 
            // button_dodaj_czesc
            // 
            button_dodaj_czesc.Location = new Point(218, 403);
            button_dodaj_czesc.Margin = new Padding(3, 4, 3, 4);
            button_dodaj_czesc.Name = "button_dodaj_czesc";
            button_dodaj_czesc.Size = new Size(277, 124);
            button_dodaj_czesc.TabIndex = 18;
            button_dodaj_czesc.Text = "Dodaj Część";
            button_dodaj_czesc.UseVisualStyleBackColor = true;
            // 
            // button_powrot_z_obsluga
            // 
            button_powrot_z_obsluga.Location = new Point(741, 21);
            button_powrot_z_obsluga.Margin = new Padding(3, 4, 3, 4);
            button_powrot_z_obsluga.Name = "button_powrot_z_obsluga";
            button_powrot_z_obsluga.Size = new Size(147, 73);
            button_powrot_z_obsluga.TabIndex = 19;
            button_powrot_z_obsluga.Text = "Powrót";
            button_powrot_z_obsluga.UseVisualStyleBackColor = true;
            button_powrot_z_obsluga.Click += button_powrot_z_obsluga_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(239, 220);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 21;
            label1.Text = "RBH";
            // 
            // textBox_RBH
            // 
            textBox_RBH.Location = new Point(239, 244);
            textBox_RBH.Margin = new Padding(3, 4, 3, 4);
            textBox_RBH.Name = "textBox_RBH";
            textBox_RBH.Size = new Size(99, 27);
            textBox_RBH.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(591, 121);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 23;
            label2.Text = "Rodzaj obsługi";
            // 
            // comboBox_rodzaj_obslugi
            // 
            comboBox_rodzaj_obslugi.FormattingEnabled = true;
            comboBox_rodzaj_obslugi.Location = new Point(591, 145);
            comboBox_rodzaj_obslugi.Margin = new Padding(3, 4, 3, 4);
            comboBox_rodzaj_obslugi.Name = "comboBox_rodzaj_obslugi";
            comboBox_rodzaj_obslugi.Size = new Size(173, 28);
            comboBox_rodzaj_obslugi.TabIndex = 22;
            // 
            // Form_Obsluga
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(label2);
            Controls.Add(comboBox_rodzaj_obslugi);
            Controls.Add(label1);
            Controls.Add(textBox_RBH);
            Controls.Add(button_powrot_z_obsluga);
            Controls.Add(button_dodaj_czesc);
            Controls.Add(button_zglos_obsluge);
            Controls.Add(dataGridView1);
            Controls.Add(label_opis2);
            Controls.Add(tbox_opis_awaria_czesc);
            Controls.Add(label_czesc);
            Controls.Add(cbox_czesc);
            Controls.Add(label_liczba);
            Controls.Add(num_ud_liczba_czesci);
            Controls.Add(label_maszyna);
            Controls.Add(cbox_maszyna);
            Controls.Add(label_osoby);
            Controls.Add(cbox_osoby);
            Controls.Add(label_datausuniecia);
            Controls.Add(dtp_data_koniec);
            Controls.Add(label_datazgloszenia);
            Controls.Add(dtp_data_poczatek);
            Controls.Add(label_opis);
            Controls.Add(txtb_opis_awaria);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_Obsluga";
            Text = "Obsluga";
            ((System.ComponentModel.ISupportInitialize)num_ud_liczba_czesci).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtb_opis_awaria;
        private Label label_opis;
        private DateTimePicker dtp_data_poczatek;
        private Label label_datazgloszenia;
        private Label label_datausuniecia;
        private DateTimePicker dtp_data_koniec;
        private ComboBox cbox_osoby;
        private Label label_osoby;
        private Label label_maszyna;
        private ComboBox cbox_maszyna;
        private NumericUpDown num_ud_liczba_czesci;
        private Label label_liczba;
        private Label label_czesc;
        private ComboBox cbox_czesc;
        private Label label_opis2;
        private TextBox tbox_opis_awaria_czesc;
        private DataGridView dataGridView1;
        private Button button_zglos_obsluge;
        private Button button_dodaj_czesc;
        private Button button_powrot_z_obsluga;
        private Label label1;
        private TextBox textBox_RBH;
        private Label label2;
        private ComboBox comboBox_rodzaj_obslugi;
    }
}