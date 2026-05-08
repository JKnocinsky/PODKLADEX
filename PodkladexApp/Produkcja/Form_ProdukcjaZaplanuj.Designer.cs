namespace PodkladexApp.Produkcja
{
    partial class Form_ProdukcjaZaplanuj
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
            cmb_filtr = new ComboBox();
            cmb_wybor = new ComboBox();
            dtg_zaplanujProd = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            btn_zaplanuj = new Button();
            pb_procentZaplanowania = new ProgressBar();
            lbl_wybraneZam = new Label();
            label2 = new Label();
            label3 = new Label();
            pb_realizacja = new ProgressBar();
            btn_zatwierdz = new Button();
            lbl_procent_plan = new Label();
            lbl_procent_realiz = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_zaplanujProd).BeginInit();
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
            tableLayoutPanel1.Controls.Add(cmb_filtr, 0, 1);
            tableLayoutPanel1.Controls.Add(cmb_wybor, 1, 0);
            tableLayoutPanel1.Controls.Add(dtg_zaplanujProd, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(1149, 862);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 23);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 1;
            label1.Text = "Filtr";
            // 
            // cmb_filtr
            // 
            cmb_filtr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmb_filtr.FormattingEnabled = true;
            cmb_filtr.Location = new Point(3, 46);
            cmb_filtr.Name = "cmb_filtr";
            cmb_filtr.Size = new Size(166, 28);
            cmb_filtr.TabIndex = 0;
            // 
            // cmb_wybor
            // 
            cmb_wybor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmb_wybor.FormattingEnabled = true;
            cmb_wybor.Location = new Point(175, 29);
            cmb_wybor.Name = "cmb_wybor";
            tableLayoutPanel1.SetRowSpan(cmb_wybor, 2);
            cmb_wybor.Size = new Size(625, 28);
            cmb_wybor.TabIndex = 2;
            // 
            // dtg_zaplanujProd
            // 
            dtg_zaplanujProd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_zaplanujProd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dtg_zaplanujProd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dtg_zaplanujProd, 2);
            dtg_zaplanujProd.Dock = DockStyle.Fill;
            dtg_zaplanujProd.Location = new Point(3, 89);
            dtg_zaplanujProd.MultiSelect = false;
            dtg_zaplanujProd.Name = "dtg_zaplanujProd";
            dtg_zaplanujProd.RowHeadersWidth = 51;
            dtg_zaplanujProd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_zaplanujProd.Size = new Size(797, 597);
            dtg_zaplanujProd.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(btn_zaplanuj, 0, 3);
            tableLayoutPanel2.Controls.Add(pb_procentZaplanowania, 0, 2);
            tableLayoutPanel2.Controls.Add(lbl_wybraneZam, 0, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 1);
            tableLayoutPanel2.Controls.Add(label3, 0, 4);
            tableLayoutPanel2.Controls.Add(pb_realizacja, 0, 5);
            tableLayoutPanel2.Controls.Add(btn_zatwierdz, 0, 6);
            tableLayoutPanel2.Controls.Add(lbl_procent_plan, 1, 2);
            tableLayoutPanel2.Controls.Add(lbl_procent_realiz, 1, 5);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(806, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 8;
            tableLayoutPanel1.SetRowSpan(tableLayoutPanel2, 3);
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Size = new Size(340, 683);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // btn_zaplanuj
            // 
            btn_zaplanuj.Anchor = AnchorStyles.None;
            btn_zaplanuj.AutoSize = true;
            btn_zaplanuj.Font = new Font("Segoe UI", 11F);
            btn_zaplanuj.Location = new Point(16, 181);
            btn_zaplanuj.Name = "btn_zaplanuj";
            btn_zaplanuj.Size = new Size(222, 45);
            btn_zaplanuj.TabIndex = 1;
            btn_zaplanuj.Text = "Zaplanuj";
            btn_zaplanuj.UseVisualStyleBackColor = true;
            btn_zaplanuj.Click += btn_zaplanuj_Click;
            // 
            // pb_procentZaplanowania
            // 
            pb_procentZaplanowania.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pb_procentZaplanowania.Location = new Point(3, 121);
            pb_procentZaplanowania.Name = "pb_procentZaplanowania";
            pb_procentZaplanowania.Size = new Size(249, 29);
            pb_procentZaplanowania.TabIndex = 0;
            // 
            // lbl_wybraneZam
            // 
            lbl_wybraneZam.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_wybraneZam.AutoSize = true;
            lbl_wybraneZam.Font = new Font("Segoe UI", 11F);
            lbl_wybraneZam.Location = new Point(3, 43);
            lbl_wybraneZam.Name = "lbl_wybraneZam";
            lbl_wybraneZam.Size = new Size(249, 25);
            lbl_wybraneZam.TabIndex = 2;
            lbl_wybraneZam.Text = "label2";
            lbl_wybraneZam.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(3, 82);
            label2.Name = "label2";
            label2.Size = new Size(160, 20);
            label2.TabIndex = 3;
            label2.Text = "Poziom rozplanowania";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(3, 252);
            label3.Name = "label3";
            label3.Size = new Size(121, 20);
            label3.TabIndex = 4;
            label3.Text = "Poziom realizacji";
            // 
            // pb_realizacja
            // 
            pb_realizacja.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pb_realizacja.Location = new Point(3, 291);
            pb_realizacja.Name = "pb_realizacja";
            pb_realizacja.Size = new Size(249, 29);
            pb_realizacja.TabIndex = 5;
            // 
            // btn_zatwierdz
            // 
            btn_zatwierdz.Anchor = AnchorStyles.None;
            btn_zatwierdz.Font = new Font("Segoe UI", 11F);
            btn_zatwierdz.Location = new Point(16, 351);
            btn_zatwierdz.Name = "btn_zatwierdz";
            btn_zatwierdz.Size = new Size(222, 45);
            btn_zatwierdz.TabIndex = 6;
            btn_zatwierdz.Text = "Zatwierdź";
            btn_zatwierdz.UseVisualStyleBackColor = true;
            btn_zatwierdz.Click += btn_zatwierdz_Click;
            // 
            // lbl_procent_plan
            // 
            lbl_procent_plan.Anchor = AnchorStyles.Left;
            lbl_procent_plan.AutoSize = true;
            lbl_procent_plan.Location = new Point(258, 126);
            lbl_procent_plan.Name = "lbl_procent_plan";
            lbl_procent_plan.Size = new Size(50, 20);
            lbl_procent_plan.TabIndex = 7;
            lbl_procent_plan.Text = "label4";
            // 
            // lbl_procent_realiz
            // 
            lbl_procent_realiz.Anchor = AnchorStyles.Left;
            lbl_procent_realiz.AutoSize = true;
            lbl_procent_realiz.Location = new Point(258, 296);
            lbl_procent_realiz.Name = "lbl_procent_realiz";
            lbl_procent_realiz.Size = new Size(50, 20);
            lbl_procent_realiz.TabIndex = 8;
            lbl_procent_realiz.Text = "label5";
            // 
            // Form_ProdukcjaZaplanuj
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1149, 862);
            Controls.Add(tableLayoutPanel1);
            Name = "Form_ProdukcjaZaplanuj";
            Text = "Form_ProdukcjaZaplanuj";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_zaplanujProd).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private ComboBox cmb_filtr;
        private ComboBox cmb_wybor;
        private DataGridView dtg_zaplanujProd;
        private TableLayoutPanel tableLayoutPanel2;
        private ProgressBar pb_procentZaplanowania;
        private Button btn_zaplanuj;
        private Label lbl_wybraneZam;
        private Label label2;
        private Label label3;
        private ProgressBar pb_realizacja;
        private Button btn_zatwierdz;
        private Label lbl_procent_plan;
        private Label lbl_procent_realiz;
    }
}