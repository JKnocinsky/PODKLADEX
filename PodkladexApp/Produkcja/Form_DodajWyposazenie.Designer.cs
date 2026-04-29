namespace PodkladexApp.Produkcja
{
    partial class Form_DodajWyposazenie
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
            lbl_tytul = new Label();
            lbl_nazwa = new Label();
            txtbox_Nazwa = new TextBox();
            cmb_wlasciwosc = new ComboBox();
            label2 = new Label();
            dgv_wlasciwosci = new DataGridView();
            btn_zapisz = new Button();
            btn_zapiszZamknij = new Button();
            txtbox_wartosc = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtbox_Uwagi = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv_wlasciwosci).BeginInit();
            SuspendLayout();
            // 
            // lbl_tytul
            // 
            lbl_tytul.AutoSize = true;
            lbl_tytul.Font = new Font("Segoe UI", 14.5F);
            lbl_tytul.Location = new Point(118, 23);
            lbl_tytul.Name = "lbl_tytul";
            lbl_tytul.Size = new Size(230, 35);
            lbl_tytul.TabIndex = 0;
            lbl_tytul.Text = "Dodaj wyposażenie";
            // 
            // lbl_nazwa
            // 
            lbl_nazwa.AutoSize = true;
            lbl_nazwa.Font = new Font("Segoe UI", 11F);
            lbl_nazwa.Location = new Point(20, 88);
            lbl_nazwa.Name = "lbl_nazwa";
            lbl_nazwa.Size = new Size(69, 25);
            lbl_nazwa.TabIndex = 1;
            lbl_nazwa.Text = "Nazwa";
            // 
            // txtbox_Nazwa
            // 
            txtbox_Nazwa.Font = new Font("Segoe UI", 11F);
            txtbox_Nazwa.Location = new Point(95, 85);
            txtbox_Nazwa.Name = "txtbox_Nazwa";
            txtbox_Nazwa.Size = new Size(328, 32);
            txtbox_Nazwa.TabIndex = 2;
            // 
            // cmb_wlasciwosc
            // 
            cmb_wlasciwosc.Font = new Font("Segoe UI", 11F);
            cmb_wlasciwosc.FormattingEnabled = true;
            cmb_wlasciwosc.Location = new Point(20, 269);
            cmb_wlasciwosc.Name = "cmb_wlasciwosc";
            cmb_wlasciwosc.Size = new Size(328, 33);
            cmb_wlasciwosc.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(20, 241);
            label2.Name = "label2";
            label2.Size = new Size(114, 25);
            label2.TabIndex = 4;
            label2.Text = "Właściwości";
            // 
            // dgv_wlasciwosci
            // 
            dgv_wlasciwosci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_wlasciwosci.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_wlasciwosci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_wlasciwosci.Location = new Point(20, 390);
            dgv_wlasciwosci.Name = "dgv_wlasciwosci";
            dgv_wlasciwosci.RowHeadersWidth = 51;
            dgv_wlasciwosci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_wlasciwosci.Size = new Size(428, 350);
            dgv_wlasciwosci.TabIndex = 5;
            dgv_wlasciwosci.SelectionChanged += dgv_wlasciwosci_SelectionChanged;
            // 
            // btn_zapisz
            // 
            btn_zapisz.Font = new Font("Segoe UI", 11F);
            btn_zapisz.Location = new Point(354, 337);
            btn_zapisz.Name = "btn_zapisz";
            btn_zapisz.Size = new Size(94, 33);
            btn_zapisz.TabIndex = 6;
            btn_zapisz.Text = "Zapisz";
            btn_zapisz.UseVisualStyleBackColor = true;
            btn_zapisz.Click += btn_zapisz_Click;
            // 
            // btn_zapiszZamknij
            // 
            btn_zapiszZamknij.Font = new Font("Segoe UI", 11F);
            btn_zapiszZamknij.Location = new Point(135, 760);
            btn_zapiszZamknij.Name = "btn_zapiszZamknij";
            btn_zapiszZamknij.Size = new Size(194, 39);
            btn_zapiszZamknij.TabIndex = 8;
            btn_zapiszZamknij.Text = "Zapisz i zamknij";
            btn_zapiszZamknij.UseVisualStyleBackColor = true;
            btn_zapiszZamknij.Click += btn_zapiszZamknij_Click;
            // 
            // txtbox_wartosc
            // 
            txtbox_wartosc.Font = new Font("Segoe UI", 11F);
            txtbox_wartosc.Location = new Point(20, 338);
            txtbox_wartosc.Name = "txtbox_wartosc";
            txtbox_wartosc.Size = new Size(328, 32);
            txtbox_wartosc.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(20, 310);
            label3.Name = "label3";
            label3.Size = new Size(80, 25);
            label3.TabIndex = 10;
            label3.Text = "Wartość";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(20, 136);
            label4.Name = "label4";
            label4.Size = new Size(65, 25);
            label4.TabIndex = 11;
            label4.Text = "Uwagi";
            // 
            // txtbox_Uwagi
            // 
            txtbox_Uwagi.Font = new Font("Segoe UI", 11F);
            txtbox_Uwagi.Location = new Point(20, 164);
            txtbox_Uwagi.Name = "txtbox_Uwagi";
            txtbox_Uwagi.Size = new Size(403, 32);
            txtbox_Uwagi.TabIndex = 12;
            // 
            // Form_DodajWyposazenie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 811);
            Controls.Add(txtbox_Uwagi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtbox_wartosc);
            Controls.Add(btn_zapiszZamknij);
            Controls.Add(btn_zapisz);
            Controls.Add(dgv_wlasciwosci);
            Controls.Add(label2);
            Controls.Add(cmb_wlasciwosc);
            Controls.Add(txtbox_Nazwa);
            Controls.Add(lbl_nazwa);
            Controls.Add(lbl_tytul);
            Name = "Form_DodajWyposazenie";
            Text = "Form_DodajWyposazenie";
            ((System.ComponentModel.ISupportInitialize)dgv_wlasciwosci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_tytul;
        private Label lbl_nazwa;
        private TextBox txtbox_Nazwa;
        private ComboBox cmb_wlasciwosc;
        private Label label2;
        private DataGridView dgv_wlasciwosci;
        private Button btn_zapisz;
        private Button btn_zapiszZamknij;
        private TextBox txtbox_wartosc;
        private Label label3;
        private Label label4;
        private TextBox txtbox_Uwagi;
    }
}