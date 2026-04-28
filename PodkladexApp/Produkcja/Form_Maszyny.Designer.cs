namespace PodkladexApp
{
    using System.Windows.Forms;

    partial class Form_Maszyny
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
            dgv_Maszyny = new DataGridView();
            tlpBottom = new TableLayoutPanel();
            btn_dodaj = new Button();
            btn_edytuj = new Button();
            btn_usun = new Button();
            tlpTop = new TableLayoutPanel();
            label1 = new Label();
            txt_Nazwa_Maszyny = new TextBox();
            btn_MaszWyp = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Maszyny).BeginInit();
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
            tableLayoutPanel1.Controls.Add(dgv_Maszyny, 0, 1);
            tableLayoutPanel1.Controls.Add(tlpBottom, 0, 2);
            tableLayoutPanel1.Controls.Add(tlpTop, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76.1904755F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.142857F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.523809F));
            tableLayoutPanel1.Size = new Size(971, 638);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // dgv_Maszyny
            // 
            dgv_Maszyny.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Maszyny.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgv_Maszyny.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Maszyny.Dock = DockStyle.Fill;
            dgv_Maszyny.Location = new Point(3, 48);
            dgv_Maszyny.Name = "dgv_Maszyny";
            dgv_Maszyny.RowHeadersWidth = 51;
            dgv_Maszyny.Size = new Size(965, 480);
            dgv_Maszyny.TabIndex = 0;
            // 
            // tlpBottom
            // 
            tlpBottom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpBottom.ColumnCount = 4;
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpBottom.Controls.Add(btn_dodaj, 0, 0);
            tlpBottom.Controls.Add(btn_edytuj, 1, 0);
            tlpBottom.Controls.Add(btn_usun, 2, 0);
            tlpBottom.Controls.Add(btn_MaszWyp, 3, 0);
            tlpBottom.Dock = DockStyle.Fill;
            tlpBottom.Location = new Point(3, 534);
            tlpBottom.Name = "tlpBottom";
            tlpBottom.RowCount = 1;
            tlpBottom.RowStyles.Add(new RowStyle());
            tlpBottom.Size = new Size(965, 39);
            tlpBottom.TabIndex = 1;
            // 
            // btn_dodaj
            // 
            btn_dodaj.AutoSize = true;
            btn_dodaj.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_dodaj.Dock = DockStyle.Fill;
            btn_dodaj.Location = new Point(3, 3);
            btn_dodaj.Name = "btn_dodaj";
            btn_dodaj.Size = new Size(235, 33);
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
            btn_edytuj.Location = new Point(244, 3);
            btn_edytuj.Name = "btn_edytuj";
            btn_edytuj.Size = new Size(235, 33);
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
            btn_usun.Location = new Point(485, 3);
            btn_usun.Name = "btn_usun";
            btn_usun.Size = new Size(235, 33);
            btn_usun.TabIndex = 4;
            btn_usun.Text = "Usuń";
            btn_usun.UseVisualStyleBackColor = true;
            btn_usun.Click += btn_dodaj_Click;
            // 
            // tlpTop
            // 
            tlpTop.ColumnCount = 2;
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.658744F));
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 91.3412552F));
            tlpTop.Controls.Add(label1, 0, 0);
            tlpTop.Controls.Add(txt_Nazwa_Maszyny, 1, 0);
            tlpTop.Dock = DockStyle.Fill;
            tlpTop.Location = new Point(3, 3);
            tlpTop.Name = "tlpTop";
            tlpTop.RowCount = 1;
            tlpTop.RowStyles.Add(new RowStyle());
            tlpTop.Size = new Size(965, 39);
            tlpTop.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 4);
            label1.Name = "label1";
            label1.Size = new Size(53, 30);
            label1.TabIndex = 5;
            label1.Text = "Nazwa Maszyny";
            // 
            // txt_Nazwa_Maszyny
            // 
            txt_Nazwa_Maszyny.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt_Nazwa_Maszyny.Location = new Point(86, 8);
            txt_Nazwa_Maszyny.Name = "txt_Nazwa_Maszyny";
            txt_Nazwa_Maszyny.Size = new Size(876, 23);
            txt_Nazwa_Maszyny.TabIndex = 1;
            txt_Nazwa_Maszyny.TextChanged += txt_Nazwa_Maszyny_TextChanged;
            // 
            // btn_MaszWyp
            // 
            btn_MaszWyp.AutoSize = true;
            btn_MaszWyp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_MaszWyp.Dock = DockStyle.Fill;
            btn_MaszWyp.Location = new Point(726, 3);
            btn_MaszWyp.Name = "btn_MaszWyp";
            btn_MaszWyp.Size = new Size(236, 33);
            btn_MaszWyp.TabIndex = 5;
            btn_MaszWyp.Text = "Wyświetl wyposażenie";
            btn_MaszWyp.UseVisualStyleBackColor = true;
            btn_MaszWyp.Click += btn_MaszWyp_Click;
            // 
            // Form_Maszyny
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(971, 638);
            Controls.Add(panel1);
            Name = "Form_Maszyny";
            Text = "Form_Maszyny";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Maszyny).EndInit();
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
        private DataGridView dgv_Maszyny;
        private TableLayoutPanel tlpBottom;
        private Button btn_dodaj;
        private Button btn_edytuj;
        private Button btn_usun;
        private TableLayoutPanel tlpTop;
        private Label label1;
        private TextBox txt_Nazwa_Maszyny;
        private Button btn_MaszWyp;
    }
}