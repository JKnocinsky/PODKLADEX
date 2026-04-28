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
            button_usun_czesc = new Button();
            button_edycja_czesc = new Button();
            button_dodaj_czesc_awaria_posredniczaca = new Button();
            label1 = new Label();
            comboBox_lista_awarii = new ComboBox();
            button_edytuj_awarie = new Button();
            button_usun_awarie = new Button();
            panel_wybor_awarii = new Panel();
            panel_awaria_info = new Panel();
            button_potwierdz = new Button();
            ((System.ComponentModel.ISupportInitialize)num_ud_liczba_czesci).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel_posredniczaca.SuspendLayout();
            panel_wybor_awarii.SuspendLayout();
            panel_awaria_info.SuspendLayout();
            SuspendLayout();
            // 
            // txtb_opis_awaria
            // 
            txtb_opis_awaria.Font = new Font("Segoe UI", 14F);
            txtb_opis_awaria.Location = new Point(216, 95);
            txtb_opis_awaria.Multiline = true;
            txtb_opis_awaria.Name = "txtb_opis_awaria";
            txtb_opis_awaria.Size = new Size(277, 91);
            txtb_opis_awaria.TabIndex = 0;
            // 
            // label_opis
            // 
            label_opis.AutoSize = true;
            label_opis.Font = new Font("Segoe UI", 14F);
            label_opis.Location = new Point(216, 67);
            label_opis.Name = "label_opis";
            label_opis.Size = new Size(50, 25);
            label_opis.TabIndex = 1;
            label_opis.Text = "Opis";
            // 
            // dtp_data_zgloszenia
            // 
            dtp_data_zgloszenia.Font = new Font("Segoe UI", 14F);
            dtp_data_zgloszenia.Location = new Point(2, 95);
            dtp_data_zgloszenia.Name = "dtp_data_zgloszenia";
            dtp_data_zgloszenia.Size = new Size(209, 32);
            dtp_data_zgloszenia.TabIndex = 2;
            // 
            // label_datazgloszenia
            // 
            label_datazgloszenia.AutoSize = true;
            label_datazgloszenia.Font = new Font("Segoe UI", 14F);
            label_datazgloszenia.Location = new Point(2, 68);
            label_datazgloszenia.Name = "label_datazgloszenia";
            label_datazgloszenia.Size = new Size(147, 25);
            label_datazgloszenia.TabIndex = 3;
            label_datazgloszenia.Text = "Data Zgłoszenia";
            // 
            // label_datausuniecia
            // 
            label_datausuniecia.AutoSize = true;
            label_datausuniecia.Font = new Font("Segoe UI", 14F);
            label_datausuniecia.Location = new Point(2, 127);
            label_datausuniecia.Name = "label_datausuniecia";
            label_datausuniecia.Size = new Size(138, 25);
            label_datausuniecia.TabIndex = 5;
            label_datausuniecia.Text = "Data Usuniecia";
            // 
            // dtp_data_usuniecia
            // 
            dtp_data_usuniecia.Font = new Font("Segoe UI", 14F);
            dtp_data_usuniecia.Location = new Point(2, 154);
            dtp_data_usuniecia.Name = "dtp_data_usuniecia";
            dtp_data_usuniecia.Size = new Size(209, 32);
            dtp_data_usuniecia.TabIndex = 4;
            // 
            // cbox_osoby
            // 
            cbox_osoby.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_osoby.Font = new Font("Segoe UI", 14F);
            cbox_osoby.FormattingEnabled = true;
            cbox_osoby.Location = new Point(2, 32);
            cbox_osoby.Name = "cbox_osoby";
            cbox_osoby.Size = new Size(209, 33);
            cbox_osoby.TabIndex = 6;
            // 
            // label_osoby
            // 
            label_osoby.AutoSize = true;
            label_osoby.Font = new Font("Segoe UI", 14F);
            label_osoby.Location = new Point(2, 6);
            label_osoby.Name = "label_osoby";
            label_osoby.Size = new Size(65, 25);
            label_osoby.TabIndex = 7;
            label_osoby.Text = "Osoby";
            // 
            // label_maszyna
            // 
            label_maszyna.AutoSize = true;
            label_maszyna.Font = new Font("Segoe UI", 14F);
            label_maszyna.Location = new Point(216, 4);
            label_maszyna.Name = "label_maszyna";
            label_maszyna.Size = new Size(86, 25);
            label_maszyna.TabIndex = 9;
            label_maszyna.Text = "Maszyna";
            // 
            // cbox_maszyna
            // 
            cbox_maszyna.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_maszyna.Font = new Font("Segoe UI", 14F);
            cbox_maszyna.FormattingEnabled = true;
            cbox_maszyna.Location = new Point(216, 32);
            cbox_maszyna.Name = "cbox_maszyna";
            cbox_maszyna.Size = new Size(277, 33);
            cbox_maszyna.TabIndex = 8;
            // 
            // num_ud_liczba_czesci
            // 
            num_ud_liczba_czesci.Font = new Font("Segoe UI", 14F);
            num_ud_liczba_czesci.Location = new Point(419, 26);
            num_ud_liczba_czesci.Margin = new Padding(3, 4, 3, 4);
            num_ud_liczba_czesci.Name = "num_ud_liczba_czesci";
            num_ud_liczba_czesci.Size = new Size(69, 32);
            num_ud_liczba_czesci.TabIndex = 10;
            // 
            // label_liczba
            // 
            label_liczba.AutoSize = true;
            label_liczba.Font = new Font("Segoe UI", 14F);
            label_liczba.Location = new Point(419, 3);
            label_liczba.Name = "label_liczba";
            label_liczba.Size = new Size(65, 25);
            label_liczba.TabIndex = 11;
            label_liczba.Text = "Liczba";
            // 
            // label_czesc
            // 
            label_czesc.AutoSize = true;
            label_czesc.Font = new Font("Segoe UI", 14F);
            label_czesc.Location = new Point(223, 3);
            label_czesc.Name = "label_czesc";
            label_czesc.Size = new Size(60, 25);
            label_czesc.TabIndex = 13;
            label_czesc.Text = "Część";
            // 
            // cbox_czesc
            // 
            cbox_czesc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_czesc.Font = new Font("Segoe UI", 14F);
            cbox_czesc.FormattingEnabled = true;
            cbox_czesc.Location = new Point(223, 28);
            cbox_czesc.Name = "cbox_czesc";
            cbox_czesc.Size = new Size(190, 33);
            cbox_czesc.TabIndex = 12;
            // 
            // label_opis2
            // 
            label_opis2.AutoSize = true;
            label_opis2.Font = new Font("Segoe UI", 14F);
            label_opis2.Location = new Point(501, 3);
            label_opis2.Name = "label_opis2";
            label_opis2.Size = new Size(50, 25);
            label_opis2.TabIndex = 15;
            label_opis2.Text = "Opis";
            // 
            // tbox_opis_awaria_czesc
            // 
            tbox_opis_awaria_czesc.Font = new Font("Segoe UI", 14F);
            tbox_opis_awaria_czesc.Location = new Point(501, 28);
            tbox_opis_awaria_czesc.Multiline = true;
            tbox_opis_awaria_czesc.Name = "tbox_opis_awaria_czesc";
            tbox_opis_awaria_czesc.Size = new Size(213, 32);
            tbox_opis_awaria_czesc.TabIndex = 14;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(224, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(490, 124);
            dataGridView1.TabIndex = 16;
            // 
            // button_zglos_awarie
            // 
            button_zglos_awarie.Font = new Font("Segoe UI", 14F);
            button_zglos_awarie.Location = new Point(10, 10);
            button_zglos_awarie.Name = "button_zglos_awarie";
            button_zglos_awarie.Size = new Size(190, 68);
            button_zglos_awarie.TabIndex = 17;
            button_zglos_awarie.Text = "Zgłoś Awarie";
            button_zglos_awarie.UseVisualStyleBackColor = true;
            button_zglos_awarie.Click += button_zglos_awarie_Click;
            // 
            // button_dodaj_czesc
            // 
            button_dodaj_czesc.Font = new Font("Segoe UI", 14F);
            button_dodaj_czesc.Location = new Point(10, 232);
            button_dodaj_czesc.Name = "button_dodaj_czesc";
            button_dodaj_czesc.Size = new Size(190, 62);
            button_dodaj_czesc.TabIndex = 18;
            button_dodaj_czesc.Text = "Dodaj Część Do Awarii";
            button_dodaj_czesc.UseVisualStyleBackColor = true;
            button_dodaj_czesc.Click += button_dodaj_czesc_Click;
            // 
            // panel_posredniczaca
            // 
            panel_posredniczaca.Controls.Add(button_usun_czesc);
            panel_posredniczaca.Controls.Add(button_edycja_czesc);
            panel_posredniczaca.Controls.Add(button_dodaj_czesc_awaria_posredniczaca);
            panel_posredniczaca.Controls.Add(dataGridView1);
            panel_posredniczaca.Controls.Add(num_ud_liczba_czesci);
            panel_posredniczaca.Controls.Add(label_liczba);
            panel_posredniczaca.Controls.Add(cbox_czesc);
            panel_posredniczaca.Controls.Add(label_opis2);
            panel_posredniczaca.Controls.Add(label_czesc);
            panel_posredniczaca.Controls.Add(tbox_opis_awaria_czesc);
            panel_posredniczaca.Location = new Point(-1, 367);
            panel_posredniczaca.Margin = new Padding(3, 2, 3, 2);
            panel_posredniczaca.Name = "panel_posredniczaca";
            panel_posredniczaca.Size = new Size(727, 204);
            panel_posredniczaca.TabIndex = 19;
            // 
            // button_usun_czesc
            // 
            button_usun_czesc.Font = new Font("Segoe UI", 14F);
            button_usun_czesc.Location = new Point(9, 131);
            button_usun_czesc.Name = "button_usun_czesc";
            button_usun_czesc.Size = new Size(192, 58);
            button_usun_czesc.TabIndex = 21;
            button_usun_czesc.Text = "Usuń Część";
            button_usun_czesc.UseVisualStyleBackColor = true;
            // 
            // button_edycja_czesc
            // 
            button_edycja_czesc.Font = new Font("Segoe UI", 14F);
            button_edycja_czesc.Location = new Point(9, 67);
            button_edycja_czesc.Name = "button_edycja_czesc";
            button_edycja_czesc.Size = new Size(192, 58);
            button_edycja_czesc.TabIndex = 20;
            button_edycja_czesc.Text = "Edytuj Część";
            button_edycja_czesc.UseVisualStyleBackColor = true;
            // 
            // button_dodaj_czesc_awaria_posredniczaca
            // 
            button_dodaj_czesc_awaria_posredniczaca.Font = new Font("Segoe UI", 14F);
            button_dodaj_czesc_awaria_posredniczaca.Location = new Point(9, 3);
            button_dodaj_czesc_awaria_posredniczaca.Name = "button_dodaj_czesc_awaria_posredniczaca";
            button_dodaj_czesc_awaria_posredniczaca.Size = new Size(192, 58);
            button_dodaj_czesc_awaria_posredniczaca.TabIndex = 19;
            button_dodaj_czesc_awaria_posredniczaca.Text = "Dodaj Część";
            button_dodaj_czesc_awaria_posredniczaca.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(2, 0);
            label1.Name = "label1";
            label1.Size = new Size(124, 25);
            label1.TabIndex = 18;
            label1.Text = "Wybór awarii";
            // 
            // comboBox_lista_awarii
            // 
            comboBox_lista_awarii.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_lista_awarii.Font = new Font("Segoe UI", 14F);
            comboBox_lista_awarii.FormattingEnabled = true;
            comboBox_lista_awarii.Location = new Point(3, 28);
            comboBox_lista_awarii.Name = "comboBox_lista_awarii";
            comboBox_lista_awarii.Size = new Size(492, 33);
            comboBox_lista_awarii.TabIndex = 17;
            // 
            // button_edytuj_awarie
            // 
            button_edytuj_awarie.Font = new Font("Segoe UI", 14F);
            button_edytuj_awarie.Location = new Point(10, 84);
            button_edytuj_awarie.Name = "button_edytuj_awarie";
            button_edytuj_awarie.Size = new Size(190, 68);
            button_edytuj_awarie.TabIndex = 20;
            button_edytuj_awarie.Text = "Edytuj Awarie";
            button_edytuj_awarie.UseVisualStyleBackColor = true;
            button_edytuj_awarie.Click += button_edytuj_awarie_Click;
            // 
            // button_usun_awarie
            // 
            button_usun_awarie.Font = new Font("Segoe UI", 14F);
            button_usun_awarie.Location = new Point(10, 158);
            button_usun_awarie.Name = "button_usun_awarie";
            button_usun_awarie.Size = new Size(190, 68);
            button_usun_awarie.TabIndex = 21;
            button_usun_awarie.Text = "Usuń Awarie";
            button_usun_awarie.UseVisualStyleBackColor = true;
            button_usun_awarie.Click += button_usun_awarie_Click;
            // 
            // panel_wybor_awarii
            // 
            panel_wybor_awarii.Controls.Add(comboBox_lista_awarii);
            panel_wybor_awarii.Controls.Add(label1);
            panel_wybor_awarii.Location = new Point(221, 206);
            panel_wybor_awarii.Name = "panel_wybor_awarii";
            panel_wybor_awarii.Size = new Size(505, 102);
            panel_wybor_awarii.TabIndex = 22;
            // 
            // panel_awaria_info
            // 
            panel_awaria_info.Controls.Add(txtb_opis_awaria);
            panel_awaria_info.Controls.Add(label_opis);
            panel_awaria_info.Controls.Add(dtp_data_zgloszenia);
            panel_awaria_info.Controls.Add(label_datazgloszenia);
            panel_awaria_info.Controls.Add(dtp_data_usuniecia);
            panel_awaria_info.Controls.Add(label_datausuniecia);
            panel_awaria_info.Controls.Add(cbox_osoby);
            panel_awaria_info.Controls.Add(label_maszyna);
            panel_awaria_info.Controls.Add(label_osoby);
            panel_awaria_info.Controls.Add(cbox_maszyna);
            panel_awaria_info.Location = new Point(221, 10);
            panel_awaria_info.Name = "panel_awaria_info";
            panel_awaria_info.Size = new Size(505, 190);
            panel_awaria_info.TabIndex = 23;
            // 
            // button_potwierdz
            // 
            button_potwierdz.Font = new Font("Segoe UI", 14F);
            button_potwierdz.Location = new Point(10, 300);
            button_potwierdz.Name = "button_potwierdz";
            button_potwierdz.Size = new Size(190, 62);
            button_potwierdz.TabIndex = 24;
            button_potwierdz.Text = "Potwierdź";
            button_potwierdz.UseVisualStyleBackColor = true;
            // 
            // Form_Awaria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 644);
            Controls.Add(button_potwierdz);
            Controls.Add(panel_awaria_info);
            Controls.Add(panel_wybor_awarii);
            Controls.Add(button_usun_awarie);
            Controls.Add(button_edytuj_awarie);
            Controls.Add(panel_posredniczaca);
            Controls.Add(button_dodaj_czesc);
            Controls.Add(button_zglos_awarie);
            Name = "Form_Awaria";
            Text = "Awaria";
            Load += Form_Awaria_Load;
            ((System.ComponentModel.ISupportInitialize)num_ud_liczba_czesci).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel_posredniczaca.ResumeLayout(false);
            panel_posredniczaca.PerformLayout();
            panel_wybor_awarii.ResumeLayout(false);
            panel_wybor_awarii.PerformLayout();
            panel_awaria_info.ResumeLayout(false);
            panel_awaria_info.PerformLayout();
            ResumeLayout(false);
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
        private Button button_usun_czesc;
        private Button button_edycja_czesc;
        private Button button_edytuj_awarie;
        private Button button_usun_awarie;
        private Panel panel_wybor_awarii;
        private Panel panel_awaria_info;
        private Button button_potwierdz;
    }
}