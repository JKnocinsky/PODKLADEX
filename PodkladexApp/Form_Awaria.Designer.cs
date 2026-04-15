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
            button_powrot_z_awaria = new Button();
            ((System.ComponentModel.ISupportInitialize)num_ud_liczba_czesci).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtb_opis_awaria
            // 
            txtb_opis_awaria.Location = new Point(207, 162);
            txtb_opis_awaria.Name = "txtb_opis_awaria";
            txtb_opis_awaria.Size = new Size(253, 23);
            txtb_opis_awaria.TabIndex = 0;
            // 
            // label_opis
            // 
            label_opis.AutoSize = true;
            label_opis.Location = new Point(207, 144);
            label_opis.Name = "label_opis";
            label_opis.Size = new Size(31, 15);
            label_opis.TabIndex = 1;
            label_opis.Text = "Opis";
            // 
            // dtp_data_zgloszenia
            // 
            dtp_data_zgloszenia.Location = new Point(207, 57);
            dtp_data_zgloszenia.Name = "dtp_data_zgloszenia";
            dtp_data_zgloszenia.Size = new Size(200, 23);
            dtp_data_zgloszenia.TabIndex = 2;
            // 
            // label_datazgloszenia
            // 
            label_datazgloszenia.AutoSize = true;
            label_datazgloszenia.Location = new Point(207, 36);
            label_datazgloszenia.Name = "label_datazgloszenia";
            label_datazgloszenia.Size = new Size(90, 15);
            label_datazgloszenia.TabIndex = 3;
            label_datazgloszenia.Text = "Data Zgłoszenia";
            // 
            // label_datausuniecia
            // 
            label_datausuniecia.AutoSize = true;
            label_datausuniecia.Location = new Point(207, 93);
            label_datausuniecia.Name = "label_datausuniecia";
            label_datausuniecia.Size = new Size(85, 15);
            label_datausuniecia.TabIndex = 5;
            label_datausuniecia.Text = "Data Usuniecia";
            label_datausuniecia.Click += label3_Click;
            // 
            // dtp_data_usuniecia
            // 
            dtp_data_usuniecia.Location = new Point(207, 114);
            dtp_data_usuniecia.Name = "dtp_data_usuniecia";
            dtp_data_usuniecia.Size = new Size(200, 23);
            dtp_data_usuniecia.TabIndex = 4;
            // 
            // cbox_osoby
            // 
            cbox_osoby.FormattingEnabled = true;
            cbox_osoby.Location = new Point(41, 45);
            cbox_osoby.Name = "cbox_osoby";
            cbox_osoby.Size = new Size(121, 23);
            cbox_osoby.TabIndex = 6;
            // 
            // label_osoby
            // 
            label_osoby.AutoSize = true;
            label_osoby.Location = new Point(41, 27);
            label_osoby.Name = "label_osoby";
            label_osoby.Size = new Size(41, 15);
            label_osoby.TabIndex = 7;
            label_osoby.Text = "Osoby";
            // 
            // label_maszyna
            // 
            label_maszyna.AutoSize = true;
            label_maszyna.Location = new Point(41, 91);
            label_maszyna.Name = "label_maszyna";
            label_maszyna.Size = new Size(53, 15);
            label_maszyna.TabIndex = 9;
            label_maszyna.Text = "Maszyna";
            // 
            // cbox_maszyna
            // 
            cbox_maszyna.FormattingEnabled = true;
            cbox_maszyna.Location = new Point(41, 109);
            cbox_maszyna.Name = "cbox_maszyna";
            cbox_maszyna.Size = new Size(121, 23);
            cbox_maszyna.TabIndex = 8;
            // 
            // num_ud_liczba_czesci
            // 
            num_ud_liczba_czesci.Location = new Point(42, 271);
            num_ud_liczba_czesci.Name = "num_ud_liczba_czesci";
            num_ud_liczba_czesci.Size = new Size(120, 23);
            num_ud_liczba_czesci.TabIndex = 10;
            // 
            // label_liczba
            // 
            label_liczba.AutoSize = true;
            label_liczba.Location = new Point(41, 253);
            label_liczba.Name = "label_liczba";
            label_liczba.Size = new Size(40, 15);
            label_liczba.TabIndex = 11;
            label_liczba.Text = "Liczba";
            // 
            // label_czesc
            // 
            label_czesc.AutoSize = true;
            label_czesc.Location = new Point(41, 311);
            label_czesc.Name = "label_czesc";
            label_czesc.Size = new Size(37, 15);
            label_czesc.TabIndex = 13;
            label_czesc.Text = "Cześć";
            // 
            // cbox_czesc
            // 
            cbox_czesc.FormattingEnabled = true;
            cbox_czesc.Location = new Point(41, 329);
            cbox_czesc.Name = "cbox_czesc";
            cbox_czesc.Size = new Size(121, 23);
            cbox_czesc.TabIndex = 12;
            // 
            // label_opis2
            // 
            label_opis2.AutoSize = true;
            label_opis2.Location = new Point(41, 366);
            label_opis2.Name = "label_opis2";
            label_opis2.Size = new Size(31, 15);
            label_opis2.TabIndex = 15;
            label_opis2.Text = "Opis";
            // 
            // tbox_opis_awaria_czesc
            // 
            tbox_opis_awaria_czesc.Location = new Point(41, 384);
            tbox_opis_awaria_czesc.Name = "tbox_opis_awaria_czesc";
            tbox_opis_awaria_czesc.Size = new Size(253, 23);
            tbox_opis_awaria_czesc.TabIndex = 14;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(487, 257);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 16;
            // 
            // button_zglos_awarie
            // 
            button_zglos_awarie.Location = new Point(42, 147);
            button_zglos_awarie.Name = "button_zglos_awarie";
            button_zglos_awarie.Size = new Size(120, 51);
            button_zglos_awarie.TabIndex = 17;
            button_zglos_awarie.Text = "Zgłoś Awarie";
            button_zglos_awarie.UseVisualStyleBackColor = true;
            // 
            // button_dodaj_czesc
            // 
            button_dodaj_czesc.Location = new Point(193, 271);
            button_dodaj_czesc.Name = "button_dodaj_czesc";
            button_dodaj_czesc.Size = new Size(242, 93);
            button_dodaj_czesc.TabIndex = 18;
            button_dodaj_czesc.Text = "Dodaj Część";
            button_dodaj_czesc.UseVisualStyleBackColor = true;
            // 
            // button_powrot_z_awaria
            // 
            button_powrot_z_awaria.Location = new Point(648, 16);
            button_powrot_z_awaria.Name = "button_powrot_z_awaria";
            button_powrot_z_awaria.Size = new Size(129, 55);
            button_powrot_z_awaria.TabIndex = 19;
            button_powrot_z_awaria.Text = "Powrót";
            button_powrot_z_awaria.UseVisualStyleBackColor = true;
            // 
            // Form_Awaria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_powrot_z_awaria);
            Controls.Add(button_dodaj_czesc);
            Controls.Add(button_zglos_awarie);
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
            Controls.Add(dtp_data_usuniecia);
            Controls.Add(label_datazgloszenia);
            Controls.Add(dtp_data_zgloszenia);
            Controls.Add(label_opis);
            Controls.Add(txtb_opis_awaria);
            Name = "Form_Awaria";
            Text = "Awaria";
            ((System.ComponentModel.ISupportInitialize)num_ud_liczba_czesci).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private Button button_powrot_z_awaria;
    }
}