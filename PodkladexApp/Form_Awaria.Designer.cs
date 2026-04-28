namespace PodkladexApp
{
    partial class Form_Awaria
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
            dtp_data_zgloszenia = new DateTimePicker();
            label_datazgloszenia = new Label();
            label_datausuniecia = new Label();
            dtp_data_usuniecia = new DateTimePicker();
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
            button_zglos_awarie = new Button();
            button_dodaj_czesc = new Button();
            panel_posredniczaca = new Panel();
            button_usun = new Button();
            button_edycja = new Button();
            button_dodaj_czesc_awaria_posredniczaca = new Button();
            label1 = new Label();
            comboBox_lista_awarii = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)num_ud_liczba_czesci).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel_posredniczaca.SuspendLayout();
            SuspendLayout();
            // 
            // txtb_opis_awaria
            // 
            txtb_opis_awaria.Font = new Font("Segoe UI", 14F);
            txtb_opis_awaria.Location = new Point(515, 124);
            txtb_opis_awaria.Margin = new Padding(3, 4, 3, 4);
            txtb_opis_awaria.Multiline = true;
            txtb_opis_awaria.Name = "txtb_opis_awaria";
            txtb_opis_awaria.Size = new Size(316, 115);
            txtb_opis_awaria.TabIndex = 0;
            // 
            // label_opis
            // 
            label_opis.AutoSize = true;
            label_opis.Font = new Font("Segoe UI", 14F);
            label_opis.Location = new Point(515, 85);
            label_opis.Name = "label_opis";
            label_opis.Size = new Size(62, 32);
            label_opis.TabIndex = 1;
            label_opis.Text = "Opis";
            // 
            // dtp_data_zgloszenia
            // 
            dtp_data_zgloszenia.Font = new Font("Segoe UI", 14F);
            dtp_data_zgloszenia.Location = new Point(271, 121);
            dtp_data_zgloszenia.Margin = new Padding(3, 4, 3, 4);
            dtp_data_zgloszenia.Name = "dtp_data_zgloszenia";
            dtp_data_zgloszenia.Size = new Size(238, 39);
            dtp_data_zgloszenia.TabIndex = 2;
            // 
            // label_datazgloszenia
            // 
            label_datazgloszenia.AutoSize = true;
            label_datazgloszenia.Font = new Font("Segoe UI", 14F);
            label_datazgloszenia.Location = new Point(271, 85);
            label_datazgloszenia.Name = "label_datazgloszenia";
            label_datazgloszenia.Size = new Size(185, 32);
            label_datazgloszenia.TabIndex = 3;
            label_datazgloszenia.Text = "Data Zgłoszenia";
            // 
            // label_datausuniecia
            // 
            label_datausuniecia.AutoSize = true;
            label_datausuniecia.Font = new Font("Segoe UI", 14F);
            label_datausuniecia.Location = new Point(271, 164);
            label_datausuniecia.Name = "label_datausuniecia";
            label_datausuniecia.Size = new Size(172, 32);
            label_datausuniecia.TabIndex = 5;
            label_datausuniecia.Text = "Data Usuniecia";
            label_datausuniecia.Click += label3_Click;
            // 
            // dtp_data_usuniecia
            // 
            dtp_data_usuniecia.Font = new Font("Segoe UI", 14F);
            dtp_data_usuniecia.Location = new Point(271, 200);
            dtp_data_usuniecia.Margin = new Padding(3, 4, 3, 4);
            dtp_data_usuniecia.Name = "dtp_data_usuniecia";
            dtp_data_usuniecia.Size = new Size(238, 39);
            dtp_data_usuniecia.TabIndex = 4;
            // 
            // cbox_osoby
            // 
            cbox_osoby.Font = new Font("Segoe UI", 14F);
            cbox_osoby.FormattingEnabled = true;
            cbox_osoby.Location = new Point(271, 42);
            cbox_osoby.Margin = new Padding(3, 4, 3, 4);
            cbox_osoby.Name = "cbox_osoby";
            cbox_osoby.Size = new Size(238, 39);
            cbox_osoby.TabIndex = 6;
            // 
            // label_osoby
            // 
            label_osoby.AutoSize = true;
            label_osoby.Font = new Font("Segoe UI", 14F);
            label_osoby.Location = new Point(271, 9);
            label_osoby.Name = "label_osoby";
            label_osoby.Size = new Size(82, 32);
            label_osoby.TabIndex = 7;
            label_osoby.Text = "Osoby";
            // 
            // label_maszyna
            // 
            label_maszyna.AutoSize = true;
            label_maszyna.Font = new Font("Segoe UI", 14F);
            label_maszyna.Location = new Point(515, 3);
            label_maszyna.Name = "label_maszyna";
            label_maszyna.Size = new Size(107, 32);
            label_maszyna.TabIndex = 9;
            label_maszyna.Text = "Maszyna";
            // 
            // cbox_maszyna
            // 
            cbox_maszyna.Font = new Font("Segoe UI", 14F);
            cbox_maszyna.FormattingEnabled = true;
            cbox_maszyna.Location = new Point(515, 42);
            cbox_maszyna.Margin = new Padding(3, 4, 3, 4);
            cbox_maszyna.Name = "cbox_maszyna";
            cbox_maszyna.Size = new Size(316, 39);
            cbox_maszyna.TabIndex = 8;
            // 
            // num_ud_liczba_czesci
            // 
            num_ud_liczba_czesci.Font = new Font("Segoe UI", 14F);
            num_ud_liczba_czesci.Location = new Point(491, 131);
            num_ud_liczba_czesci.Margin = new Padding(3, 5, 3, 5);
            num_ud_liczba_czesci.Name = "num_ud_liczba_czesci";
            num_ud_liczba_czesci.Size = new Size(79, 39);
            num_ud_liczba_czesci.TabIndex = 10;
            // 
            // label_liczba
            // 
            label_liczba.AutoSize = true;
            label_liczba.Font = new Font("Segoe UI", 14F);
            label_liczba.Location = new Point(491, 95);
            label_liczba.Name = "label_liczba";
            label_liczba.Size = new Size(79, 32);
            label_liczba.TabIndex = 11;
            label_liczba.Text = "Liczba";
            // 
            // label_czesc
            // 
            label_czesc.AutoSize = true;
            label_czesc.Font = new Font("Segoe UI", 14F);
            label_czesc.Location = new Point(269, 95);
            label_czesc.Name = "label_czesc";
            label_czesc.Size = new Size(74, 32);
            label_czesc.TabIndex = 13;
            label_czesc.Text = "Część";
            // 
            // cbox_czesc
            // 
            cbox_czesc.Font = new Font("Segoe UI", 14F);
            cbox_czesc.FormattingEnabled = true;
            cbox_czesc.Location = new Point(269, 131);
            cbox_czesc.Margin = new Padding(3, 4, 3, 4);
            cbox_czesc.Name = "cbox_czesc";
            cbox_czesc.Size = new Size(216, 39);
            cbox_czesc.TabIndex = 12;
            // 
            // label_opis2
            // 
            label_opis2.AutoSize = true;
            label_opis2.Font = new Font("Segoe UI", 14F);
            label_opis2.Location = new Point(586, 92);
            label_opis2.Name = "label_opis2";
            label_opis2.Size = new Size(62, 32);
            label_opis2.TabIndex = 15;
            label_opis2.Text = "Opis";
            // 
            // tbox_opis_awaria_czesc
            // 
            tbox_opis_awaria_czesc.Font = new Font("Segoe UI", 14F);
            tbox_opis_awaria_czesc.Location = new Point(586, 128);
            tbox_opis_awaria_czesc.Margin = new Padding(3, 4, 3, 4);
            tbox_opis_awaria_czesc.Multiline = true;
            tbox_opis_awaria_czesc.Name = "tbox_opis_awaria_czesc";
            tbox_opis_awaria_czesc.Size = new Size(243, 42);
            tbox_opis_awaria_czesc.TabIndex = 14;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(269, 185);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(560, 166);
            dataGridView1.TabIndex = 16;
            // 
            // button_zglos_awarie
            // 
            button_zglos_awarie.Font = new Font("Segoe UI", 14F);
            button_zglos_awarie.Location = new Point(12, 13);
            button_zglos_awarie.Margin = new Padding(3, 4, 3, 4);
            button_zglos_awarie.Name = "button_zglos_awarie";
            button_zglos_awarie.Size = new Size(217, 90);
            button_zglos_awarie.TabIndex = 17;
            button_zglos_awarie.Text = "Zgłoś Awarie";
            button_zglos_awarie.UseVisualStyleBackColor = true;
            // 
            // button_dodaj_czesc
            // 
            button_dodaj_czesc.Font = new Font("Segoe UI", 14F);
            button_dodaj_czesc.Location = new Point(12, 121);
            button_dodaj_czesc.Margin = new Padding(3, 4, 3, 4);
            button_dodaj_czesc.Name = "button_dodaj_czesc";
            button_dodaj_czesc.Size = new Size(217, 94);
            button_dodaj_czesc.TabIndex = 18;
            button_dodaj_czesc.Text = "Dodaj Część Do Awarii";
            button_dodaj_czesc.UseVisualStyleBackColor = true;
            button_dodaj_czesc.Click += button_dodaj_czesc_Click;
            // 
            // panel_posredniczaca
            // 
            panel_posredniczaca.Controls.Add(button_usun);
            panel_posredniczaca.Controls.Add(button_edycja);
            panel_posredniczaca.Controls.Add(button_dodaj_czesc_awaria_posredniczaca);
            panel_posredniczaca.Controls.Add(label1);
            panel_posredniczaca.Controls.Add(comboBox_lista_awarii);
            panel_posredniczaca.Controls.Add(dataGridView1);
            panel_posredniczaca.Controls.Add(num_ud_liczba_czesci);
            panel_posredniczaca.Controls.Add(label_liczba);
            panel_posredniczaca.Controls.Add(cbox_czesc);
            panel_posredniczaca.Controls.Add(label_opis2);
            panel_posredniczaca.Controls.Add(label_czesc);
            panel_posredniczaca.Controls.Add(tbox_opis_awaria_czesc);
            panel_posredniczaca.Location = new Point(2, 246);
            panel_posredniczaca.Name = "panel_posredniczaca";
            panel_posredniczaca.Size = new Size(890, 342);
            panel_posredniczaca.TabIndex = 19;
            // 
            // button_usun
            // 
            button_usun.Font = new Font("Segoe UI", 14F);
            button_usun.Location = new Point(10, 185);
            button_usun.Margin = new Padding(3, 4, 3, 4);
            button_usun.Name = "button_usun";
            button_usun.Size = new Size(217, 78);
            button_usun.TabIndex = 21;
            button_usun.Text = "Usuń Część";
            button_usun.UseVisualStyleBackColor = true;
            // 
            // button_edycja
            // 
            button_edycja.Font = new Font("Segoe UI", 14F);
            button_edycja.Location = new Point(10, 99);
            button_edycja.Margin = new Padding(3, 4, 3, 4);
            button_edycja.Name = "button_edycja";
            button_edycja.Size = new Size(217, 78);
            button_edycja.TabIndex = 20;
            button_edycja.Text = "Edytuj Część";
            button_edycja.UseVisualStyleBackColor = true;
            // 
            // button_dodaj_czesc_awaria_posredniczaca
            // 
            button_dodaj_czesc_awaria_posredniczaca.Font = new Font("Segoe UI", 14F);
            button_dodaj_czesc_awaria_posredniczaca.Location = new Point(10, 13);
            button_dodaj_czesc_awaria_posredniczaca.Margin = new Padding(3, 4, 3, 4);
            button_dodaj_czesc_awaria_posredniczaca.Name = "button_dodaj_czesc_awaria_posredniczaca";
            button_dodaj_czesc_awaria_posredniczaca.Size = new Size(217, 78);
            button_dodaj_czesc_awaria_posredniczaca.TabIndex = 19;
            button_dodaj_czesc_awaria_posredniczaca.Text = "Dodaj Część";
            button_dodaj_czesc_awaria_posredniczaca.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(269, 16);
            label1.Name = "label1";
            label1.Size = new Size(152, 32);
            label1.TabIndex = 18;
            label1.Text = "Wybór awarii";
            // 
            // comboBox_lista_awarii
            // 
            comboBox_lista_awarii.Font = new Font("Segoe UI", 14F);
            comboBox_lista_awarii.FormattingEnabled = true;
            comboBox_lista_awarii.Location = new Point(269, 52);
            comboBox_lista_awarii.Margin = new Padding(3, 4, 3, 4);
            comboBox_lista_awarii.Name = "comboBox_lista_awarii";
            comboBox_lista_awarii.Size = new Size(560, 39);
            comboBox_lista_awarii.TabIndex = 17;
            // 
            // Form_Awaria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panel_posredniczaca);
            Controls.Add(button_dodaj_czesc);
            Controls.Add(button_zglos_awarie);
            Controls.Add(label_maszyna);
            Controls.Add(cbox_maszyna);
            Controls.Add(label_osoby);
            Controls.Add(cbox_osoby);
            Controls.Add(label_datausuniecia);
            Controls.Add(dtp_data_usuniecia);
            Controls.Add(label_datazgloszenia);
            Controls.Add(dtp_data_zgloszenia);
            Controls.Add(label_opis);
            Controls.Add(txtb_opis_awaria);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_Awaria";
            Text = "Awaria";
            Load += Form_Awaria_Load;
            ((System.ComponentModel.ISupportInitialize)num_ud_liczba_czesci).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel_posredniczaca.ResumeLayout(false);
            panel_posredniczaca.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtb_opis_awaria;
        private Label label_opis;
        private DateTimePicker dtp_data_zgloszenia;
        private Label label_datazgloszenia;
        private Label label_datausuniecia;
        private DateTimePicker dtp_data_usuniecia;
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
        private Button button_zglos_awarie;
        private Button button_dodaj_czesc;
        private Panel panel_posredniczaca;
        private Button button_dodaj_czesc_awaria_posredniczaca;
        private Label label1;
        private ComboBox comboBox_lista_awarii;
        private Button button_usun;
        private Button button_edycja;
    }
}