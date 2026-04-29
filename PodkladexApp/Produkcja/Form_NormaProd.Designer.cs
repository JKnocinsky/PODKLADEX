namespace PodkladexApp
{
    using System.Windows.Forms;

    partial class Form_NormaProd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgv_NormyProd = new DataGridView();
            tlpBottom = new TableLayoutPanel();
            btn_dodaj = new Button();
            btn_edytuj = new Button();
            btn_usun = new Button();
            tlpTop = new TableLayoutPanel();
            label1 = new Label();
            cmb_filtr = new ComboBox();
            cmb_wybieranie = new ComboBox();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_NormyProd).BeginInit();
            tlpBottom.SuspendLayout();
            tlpTop.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(971, 638);
            panel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dgv_NormyProd, 0, 1);
            tableLayoutPanel1.Controls.Add(tlpBottom, 0, 2);
            tableLayoutPanel1.Controls.Add(tlpTop, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(971, 638);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // dgv_NormyProd
            // 
            dgv_NormyProd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_NormyProd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgv_NormyProd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_NormyProd.Dock = DockStyle.Fill;
            dgv_NormyProd.Location = new Point(3, 66);
            dgv_NormyProd.Name = "dgv_NormyProd";
            dgv_NormyProd.RowHeadersWidth = 51;
            dgv_NormyProd.Size = new Size(965, 440);
            dgv_NormyProd.TabIndex = 0;
            // 
            // tlpBottom
            // 
            tlpBottom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpBottom.ColumnCount = 3;
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpBottom.Controls.Add(btn_dodaj, 0, 0);
            tlpBottom.Controls.Add(btn_edytuj, 1, 0);
            tlpBottom.Controls.Add(btn_usun, 2, 0);
            tlpBottom.Dock = DockStyle.Fill;
            tlpBottom.Location = new Point(3, 512);
            tlpBottom.Name = "tlpBottom";
            tlpBottom.RowCount = 1;
            tlpBottom.RowStyles.Add(new RowStyle());
            tlpBottom.Size = new Size(965, 57);
            tlpBottom.TabIndex = 1;
            // 
            // btn_dodaj
            // 
            btn_dodaj.AutoSize = true;
            btn_dodaj.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_dodaj.Dock = DockStyle.Fill;
            btn_dodaj.Location = new Point(3, 3);
            btn_dodaj.Name = "btn_dodaj";
            btn_dodaj.Size = new Size(315, 51);
            btn_dodaj.TabIndex = 2;
            btn_dodaj.Text = "Dodaj";
            btn_dodaj.UseVisualStyleBackColor = true;
            btn_dodaj.Click += btn_dodaj_Click;
            // 
            // btn_edytuj
            // 
            btn_edytuj.AutoSize = true;
            btn_edytuj.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_edytuj.Dock = DockStyle.Fill;
            btn_edytuj.Location = new Point(324, 3);
            btn_edytuj.Name = "btn_edytuj";
            btn_edytuj.Size = new Size(315, 51);
            btn_edytuj.TabIndex = 3;
            btn_edytuj.Text = "Edytuj";
            btn_edytuj.UseVisualStyleBackColor = true;
            btn_edytuj.Click += btn_dodaj_Click;
            // 
            // btn_usun
            // 
            btn_usun.AutoSize = true;
            btn_usun.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_usun.Dock = DockStyle.Fill;
            btn_usun.Location = new Point(645, 3);
            btn_usun.Name = "btn_usun";
            btn_usun.Size = new Size(317, 51);
            btn_usun.TabIndex = 4;
            btn_usun.Text = "Usuń";
            btn_usun.UseVisualStyleBackColor = true;
            btn_usun.Click += btn_dodaj_Click;
            // 
            // tlpTop
            // 
            tlpTop.ColumnCount = 2;
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tlpTop.Controls.Add(label1, 0, 0);
            tlpTop.Controls.Add(cmb_filtr, 0, 1);
            tlpTop.Controls.Add(cmb_wybieranie, 1, 0);
            tlpTop.Dock = DockStyle.Fill;
            tlpTop.Location = new Point(3, 3);
            tlpTop.Name = "tlpTop";
            tlpTop.RowCount = 2;
            tlpTop.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpTop.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpTop.Size = new Size(965, 57);
            tlpTop.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 5;
            label1.Text = "Filtr";
            // 
            // cmb_filtr
            // 
            cmb_filtr.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmb_filtr.FormattingEnabled = true;
            cmb_filtr.Location = new Point(3, 31);
            cmb_filtr.Name = "cmb_filtr";
            cmb_filtr.Size = new Size(138, 23);
            cmb_filtr.TabIndex = 6;
            cmb_filtr.SelectedIndexChanged += cmb_filtr_SelectedIndexChanged;
            // 
            // cmb_wybieranie
            // 
            cmb_wybieranie.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmb_wybieranie.FormattingEnabled = true;
            cmb_wybieranie.Location = new Point(147, 17);
            cmb_wybieranie.Name = "cmb_wybieranie";
            tlpTop.SetRowSpan(cmb_wybieranie, 2);
            cmb_wybieranie.Size = new Size(815, 23);
            cmb_wybieranie.TabIndex = 7;
            cmb_wybieranie.SelectedIndexChanged += cmb_wybieranie_SelectedIndexChanged;
            // 
            // Form_NormaProd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(971, 638);
            Controls.Add(panel1);
            Name = "Form_NormaProd";
            Text = "Form_NormaProd";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_NormyProd).EndInit();
            tlpBottom.ResumeLayout(false);
            tlpBottom.PerformLayout();
            tlpTop.ResumeLayout(false);
            tlpTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgv_NormyProd;
        private TableLayoutPanel tlpBottom;
        private Button btn_dodaj;
        private Button btn_edytuj;
        private Button btn_usun;
        private TableLayoutPanel tlpTop;
        private Label label1;
        private ComboBox cmb_filtr;
        private ComboBox cmb_wybieranie;
    }
}