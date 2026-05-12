namespace PodkladexApp.Produkcja
{
    partial class Form_ProdukcjaZaplanujPodform
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
            dtp_Data = new DateTimePicker();
            cmb_Maszyny = new ComboBox();
            label1 = new Label();
            cmb_pracownik = new ComboBox();
            label2 = new Label();
            dgv_produktyZamowienie = new DataGridView();
            label3 = new Label();
            txt_rbh = new TextBox();
            txt_doWyprod = new TextBox();
            btn_zapisz = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dtg_info = new DataGridView();
            label7 = new Label();
            cmb_wyp = new ComboBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_produktyZamowienie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtg_info).BeginInit();
            SuspendLayout();
            // 
            // dtp_Data
            // 
            dtp_Data.CalendarFont = new Font("Segoe UI", 11F);
            dtp_Data.Location = new Point(214, 121);
            dtp_Data.Margin = new Padding(5, 5, 5, 5);
            dtp_Data.Name = "dtp_Data";
            dtp_Data.Size = new Size(449, 39);
            dtp_Data.TabIndex = 0;
            // 
            // cmb_Maszyny
            // 
            cmb_Maszyny.Font = new Font("Segoe UI", 11F);
            cmb_Maszyny.FormattingEnabled = true;
            cmb_Maszyny.Location = new Point(214, 242);
            cmb_Maszyny.Margin = new Padding(5, 5, 5, 5);
            cmb_Maszyny.Name = "cmb_Maszyny";
            cmb_Maszyny.Size = new Size(449, 33);
            cmb_Maszyny.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(214, 206);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 32);
            label1.TabIndex = 2;
            label1.Text = "Maszyna";
            // 
            // cmb_pracownik
            // 
            cmb_pracownik.Font = new Font("Segoe UI", 11F);
            cmb_pracownik.FormattingEnabled = true;
            cmb_pracownik.Location = new Point(214, 490);
            cmb_pracownik.Margin = new Padding(5, 5, 5, 5);
            cmb_pracownik.Name = "cmb_pracownik";
            cmb_pracownik.Size = new Size(449, 33);
            cmb_pracownik.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(214, 454);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(121, 32);
            label2.TabIndex = 4;
            label2.Text = "Pracownik";
            // 
            // dgv_produktyZamowienie
            // 
            dgv_produktyZamowienie.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_produktyZamowienie.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_produktyZamowienie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_produktyZamowienie.Location = new Point(72, 622);
            dgv_produktyZamowienie.Margin = new Padding(5, 5, 5, 5);
            dgv_produktyZamowienie.Name = "dgv_produktyZamowienie";
            dgv_produktyZamowienie.RowHeadersWidth = 51;
            dgv_produktyZamowienie.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_produktyZamowienie.Size = new Size(738, 291);
            dgv_produktyZamowienie.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 586);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(109, 32);
            label3.TabIndex = 6;
            label3.Text = "Produkty";
            // 
            // txt_rbh
            // 
            txt_rbh.Font = new Font("Segoe UI", 11F);
            txt_rbh.Location = new Point(167, 1004);
            txt_rbh.Margin = new Padding(5, 5, 5, 5);
            txt_rbh.Name = "txt_rbh";
            txt_rbh.Size = new Size(201, 32);
            txt_rbh.TabIndex = 7;
            // 
            // txt_doWyprod
            // 
            txt_doWyprod.Font = new Font("Segoe UI", 11F);
            txt_doWyprod.Location = new Point(523, 1004);
            txt_doWyprod.Margin = new Padding(5, 5, 5, 5);
            txt_doWyprod.Name = "txt_doWyprod";
            txt_doWyprod.ReadOnly = true;
            txt_doWyprod.Size = new Size(201, 32);
            txt_doWyprod.TabIndex = 8;
            // 
            // btn_zapisz
            // 
            btn_zapisz.AutoSize = true;
            btn_zapisz.Font = new Font("Segoe UI", 11F);
            btn_zapisz.Location = new Point(364, 1094);
            btn_zapisz.Margin = new Padding(5, 5, 5, 5);
            btn_zapisz.Name = "btn_zapisz";
            btn_zapisz.Size = new Size(153, 54);
            btn_zapisz.TabIndex = 9;
            btn_zapisz.Text = "Zapisz";
            btn_zapisz.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(167, 969);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(59, 32);
            label4.TabIndex = 10;
            label4.Text = "RBH";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(523, 969);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(232, 32);
            label5.TabIndex = 11;
            label5.Text = "Do wyprodukowania";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(214, 85);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 32);
            label6.TabIndex = 12;
            label6.Text = "Data";
            // 
            // dtg_info
            // 
            dtg_info.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_info.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtg_info.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_info.Location = new Point(926, 157);
            dtg_info.Margin = new Padding(5, 5, 5, 5);
            dtg_info.Name = "dtg_info";
            dtg_info.RowHeadersWidth = 51;
            dtg_info.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_info.Size = new Size(782, 897);
            dtg_info.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(926, 121);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(56, 32);
            label7.TabIndex = 14;
            label7.Text = "Info";
            // 
            // cmb_wyp
            // 
            cmb_wyp.Font = new Font("Segoe UI", 11F);
            cmb_wyp.FormattingEnabled = true;
            cmb_wyp.Location = new Point(214, 364);
            cmb_wyp.Margin = new Padding(5, 5, 5, 5);
            cmb_wyp.Name = "cmb_wyp";
            cmb_wyp.Size = new Size(449, 33);
            cmb_wyp.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(214, 329);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(155, 32);
            label8.TabIndex = 16;
            label8.Text = "Wyposażenie";
            // 
            // Form_ProdukcjaZaplanujPodform
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1818, 1231);
            Controls.Add(label8);
            Controls.Add(cmb_wyp);
            Controls.Add(label7);
            Controls.Add(dtg_info);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btn_zapisz);
            Controls.Add(txt_doWyprod);
            Controls.Add(txt_rbh);
            Controls.Add(label3);
            Controls.Add(dgv_produktyZamowienie);
            Controls.Add(label2);
            Controls.Add(cmb_pracownik);
            Controls.Add(label1);
            Controls.Add(cmb_Maszyny);
            Controls.Add(dtp_Data);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form_ProdukcjaZaplanujPodform";
            Text = "Form_ProdukcjaZaplanujPodform";
            ((System.ComponentModel.ISupportInitialize)dgv_produktyZamowienie).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtg_info).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtp_Data;
        private ComboBox cmb_Maszyny;
        private Label label1;
        private ComboBox cmb_pracownik;
        private Label label2;
        private DataGridView dgv_produktyZamowienie;
        private Label label3;
        private TextBox txt_rbh;
        private TextBox txt_doWyprod;
        private Button btn_zapisz;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dtg_info;
        private Label label7;
        private ComboBox cmb_wyp;
        private Label label8;
    }
}