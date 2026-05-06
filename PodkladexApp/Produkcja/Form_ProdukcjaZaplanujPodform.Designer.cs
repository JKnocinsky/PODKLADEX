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
            ((System.ComponentModel.ISupportInitialize)dgv_produktyZamowienie).BeginInit();
            SuspendLayout();
            // 
            // dtp_Data
            // 
            dtp_Data.CalendarFont = new Font("Segoe UI", 11F);
            dtp_Data.Location = new Point(132, 78);
            dtp_Data.Name = "dtp_Data";
            dtp_Data.Size = new Size(278, 27);
            dtp_Data.TabIndex = 0;
            // 
            // cmb_Maszyny
            // 
            cmb_Maszyny.Font = new Font("Segoe UI", 11F);
            cmb_Maszyny.FormattingEnabled = true;
            cmb_Maszyny.Location = new Point(132, 156);
            cmb_Maszyny.Name = "cmb_Maszyny";
            cmb_Maszyny.Size = new Size(278, 33);
            cmb_Maszyny.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(132, 133);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 2;
            label1.Text = "Maszyna";
            // 
            // cmb_pracownik
            // 
            cmb_pracownik.Font = new Font("Segoe UI", 11F);
            cmb_pracownik.FormattingEnabled = true;
            cmb_pracownik.Location = new Point(132, 240);
            cmb_pracownik.Name = "cmb_pracownik";
            cmb_pracownik.Size = new Size(278, 33);
            cmb_pracownik.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 217);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 4;
            label2.Text = "Pracownik";
            // 
            // dgv_produktyZamowienie
            // 
            dgv_produktyZamowienie.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgv_produktyZamowienie.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_produktyZamowienie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_produktyZamowienie.Location = new Point(44, 324);
            dgv_produktyZamowienie.Name = "dgv_produktyZamowienie";
            dgv_produktyZamowienie.RowHeadersWidth = 51;
            dgv_produktyZamowienie.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_produktyZamowienie.Size = new Size(454, 188);
            dgv_produktyZamowienie.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 301);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 6;
            label3.Text = "Produkty";
            // 
            // txt_rbh
            // 
            txt_rbh.Font = new Font("Segoe UI", 11F);
            txt_rbh.Location = new Point(99, 598);
            txt_rbh.Name = "txt_rbh";
            txt_rbh.Size = new Size(125, 32);
            txt_rbh.TabIndex = 7;
            // 
            // txt_doWyprod
            // 
            txt_doWyprod.Font = new Font("Segoe UI", 11F);
            txt_doWyprod.Location = new Point(318, 598);
            txt_doWyprod.Name = "txt_doWyprod";
            txt_doWyprod.ReadOnly = true;
            txt_doWyprod.Size = new Size(125, 32);
            txt_doWyprod.TabIndex = 8;
            // 
            // btn_zapisz
            // 
            btn_zapisz.AutoSize = true;
            btn_zapisz.Font = new Font("Segoe UI", 11F);
            btn_zapisz.Location = new Point(224, 706);
            btn_zapisz.Name = "btn_zapisz";
            btn_zapisz.Size = new Size(94, 35);
            btn_zapisz.TabIndex = 9;
            btn_zapisz.Text = "Zapisz";
            btn_zapisz.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 575);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 10;
            label4.Text = "RBH";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(318, 575);
            label5.Name = "label5";
            label5.Size = new Size(146, 20);
            label5.TabIndex = 11;
            label5.Text = "Do wyprodukowania";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(132, 55);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 12;
            label6.Text = "Data";
            // 
            // Form_ProdukcjaZaplanujPodform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 794);
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
            Name = "Form_ProdukcjaZaplanujPodform";
            Text = "Form_ProdukcjaZaplanujPodform";
            ((System.ComponentModel.ISupportInitialize)dgv_produktyZamowienie).EndInit();
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
    }
}