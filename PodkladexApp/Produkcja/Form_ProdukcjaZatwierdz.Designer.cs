namespace PodkladexApp.Produkcja
{
    partial class Form_ProdukcjaZatwierdz
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            cmb_zamowienia = new ComboBox();
            dtp_data = new DateTimePicker();
            dgv_produkcja = new DataGridView();
            btn_clearDate = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            btn_zatwierdz = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_produkcja).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(cmb_zamowienia, 1, 0);
            tableLayoutPanel1.Controls.Add(dtp_data, 1, 1);
            tableLayoutPanel1.Controls.Add(dgv_produkcja, 0, 2);
            tableLayoutPanel1.Controls.Add(btn_clearDate, 2, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.Size = new Size(1149, 862);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(3, 11);
            label1.Name = "label1";
            label1.Size = new Size(166, 20);
            label1.TabIndex = 0;
            label1.Text = "Zamowienie";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(3, 54);
            label2.Name = "label2";
            label2.Size = new Size(166, 20);
            label2.TabIndex = 1;
            label2.Text = "Data";
            // 
            // cmb_zamowienia
            // 
            cmb_zamowienia.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmb_zamowienia.FormattingEnabled = true;
            cmb_zamowienia.Location = new Point(175, 7);
            cmb_zamowienia.Name = "cmb_zamowienia";
            cmb_zamowienia.Size = new Size(625, 28);
            cmb_zamowienia.TabIndex = 2;
            // 
            // dtp_data
            // 
            dtp_data.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtp_data.Location = new Point(175, 51);
            dtp_data.Name = "dtp_data";
            dtp_data.Size = new Size(625, 27);
            dtp_data.TabIndex = 3;
            // 
            // dgv_produkcja
            // 
            dgv_produkcja.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgv_produkcja.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_produkcja.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgv_produkcja, 2);
            dgv_produkcja.Dock = DockStyle.Fill;
            dgv_produkcja.Location = new Point(3, 89);
            dgv_produkcja.Name = "dgv_produkcja";
            dgv_produkcja.RowHeadersWidth = 51;
            dgv_produkcja.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_produkcja.Size = new Size(797, 770);
            dgv_produkcja.TabIndex = 4;
            // 
            // btn_clearDate
            // 
            btn_clearDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btn_clearDate.Location = new Point(806, 46);
            btn_clearDate.Name = "btn_clearDate";
            btn_clearDate.Size = new Size(94, 37);
            btn_clearDate.TabIndex = 5;
            btn_clearDate.Text = "Wyczyść";
            btn_clearDate.UseVisualStyleBackColor = true;
            btn_clearDate.Click += btn_clearDate_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(btn_zatwierdz, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(806, 89);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel2.Size = new Size(340, 770);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // btn_zatwierdz
            // 
            btn_zatwierdz.Anchor = AnchorStyles.None;
            btn_zatwierdz.Font = new Font("Segoe UI", 14.5F);
            btn_zatwierdz.Location = new Point(99, 53);
            btn_zatwierdz.Name = "btn_zatwierdz";
            btn_zatwierdz.Size = new Size(141, 47);
            btn_zatwierdz.TabIndex = 0;
            btn_zatwierdz.Text = "Zatwierdź";
            btn_zatwierdz.UseVisualStyleBackColor = true;
            btn_zatwierdz.Click += btn_zatwierdz_Click;
            // 
            // Form_ProdukcjaZatwierdz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1149, 862);
            Controls.Add(tableLayoutPanel1);
            Name = "Form_ProdukcjaZatwierdz";
            Text = "Form_ProdukcjaZatwierdz";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_produkcja).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private ComboBox cmb_zamowienia;
        private DateTimePicker dtp_data;
        private DataGridView dgv_produkcja;
        private Button btn_clearDate;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btn_zatwierdz;
    }
}