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
            dgv_Maszyny = new DataGridView();
            txt_Nazwa_Maszyny = new TextBox();
            btn_dodaj = new Button();
            btn_edytuj = new Button();
            btn_usun = new Button();
            label1 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tlpTop = new TableLayoutPanel();
            tlpBottom = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgv_Maszyny).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tlpTop.SuspendLayout();
            tlpBottom.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_Maszyny
            // 
            dgv_Maszyny.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Maszyny.Dock = DockStyle.Fill;
            dgv_Maszyny.Location = new Point(3, 109);
            dgv_Maszyny.Name = "dgv_Maszyny";
            dgv_Maszyny.Size = new Size(1589, 885);
            dgv_Maszyny.TabIndex = 0;
            // 
            // txt_Nazwa_Maszyny
            // 
            txt_Nazwa_Maszyny.Dock = DockStyle.Fill;
            txt_Nazwa_Maszyny.Location = new Point(100, 3);
            txt_Nazwa_Maszyny.Name = "txt_Nazwa_Maszyny";
            txt_Nazwa_Maszyny.Size = new Size(1486, 23);
            txt_Nazwa_Maszyny.TabIndex = 1;
            txt_Nazwa_Maszyny.TextChanged += txt_Nazwa_Maszyny_TextChanged;
            // 
            // btn_dodaj
            // 
            btn_dodaj.Dock = DockStyle.Fill;
            btn_dodaj.Location = new Point(13, 13);
            btn_dodaj.Name = "btn_dodaj";
            btn_dodaj.Size = new Size(516, 74);
            btn_dodaj.TabIndex = 2;
            btn_dodaj.Text = "Dodaj";
            btn_dodaj.UseVisualStyleBackColor = true;
            btn_dodaj.Click += btn_dodaj_Click;
            // 
            // btn_edytuj
            // 
            btn_edytuj.Dock = DockStyle.Fill;
            btn_edytuj.Location = new Point(535, 13);
            btn_edytuj.Name = "btn_edytuj";
            btn_edytuj.Size = new Size(516, 74);
            btn_edytuj.TabIndex = 3;
            btn_edytuj.Text = "Edytuj";
            btn_edytuj.UseVisualStyleBackColor = true;
            btn_edytuj.Click += btn_dodaj_Click;
            // 
            // btn_usun
            // 
            btn_usun.Dock = DockStyle.Fill;
            btn_usun.Location = new Point(1057, 13);
            btn_usun.Name = "btn_usun";
            btn_usun.Size = new Size(519, 74);
            btn_usun.TabIndex = 4;
            btn_usun.Text = "Usuń";
            btn_usun.UseVisualStyleBackColor = true;
            btn_usun.Click += btn_dodaj_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 42);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 5;
            label1.Text = "Nazwa Maszyny";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSize = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1595, 1103);
            panel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tlpTop, 0, 0);
            tableLayoutPanel1.Controls.Add(dgv_Maszyny, 0, 1);
            tableLayoutPanel1.Controls.Add(tlpBottom, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(1595, 1103);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // tlpTop
            // 
            tlpTop.ColumnCount = 2;
            tlpTop.ColumnStyles.Add(new ColumnStyle());
            tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTop.Controls.Add(label1, 0, 0);
            tlpTop.Controls.Add(txt_Nazwa_Maszyny, 1, 0);
            tlpTop.Dock = DockStyle.Fill;
            tlpTop.Location = new Point(3, 3);
            tlpTop.Name = "tlpTop";
            tlpTop.RowCount = 1;
            tlpTop.RowStyles.Add(new RowStyle());
            tlpTop.Size = new Size(1589, 100);
            tlpTop.TabIndex = 0;
            // 
            // tlpBottom
            // 
            tlpBottom.ColumnCount = 3;
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpBottom.Controls.Add(btn_dodaj, 0, 0);
            tlpBottom.Controls.Add(btn_edytuj, 1, 0);
            tlpBottom.Controls.Add(btn_usun, 2, 0);
            tlpBottom.Dock = DockStyle.Fill;
            tlpBottom.Location = new Point(3, 1000);
            tlpBottom.Name = "tlpBottom";
            tlpBottom.Padding = new Padding(10);
            tlpBottom.RowCount = 1;
            tlpBottom.RowStyles.Add(new RowStyle());
            tlpBottom.Size = new Size(1589, 100);
            tlpBottom.TabIndex = 1;
            // 
            // Form_Maszyny
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1595, 1103);
            Controls.Add(panel1);
            Name = "Form_Maszyny";
            Text = "Form_Maszyny";
            ((System.ComponentModel.ISupportInitialize)dgv_Maszyny).EndInit();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tlpTop.ResumeLayout(false);
            tlpTop.PerformLayout();
            tlpBottom.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_Maszyny;
        private TextBox txt_Nazwa_Maszyny;
        private Button btn_dodaj;
        private Button btn_edytuj;
        private Button btn_usun;
        private Label label1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tlpTop;
        private TableLayoutPanel tlpBottom;
    }
}