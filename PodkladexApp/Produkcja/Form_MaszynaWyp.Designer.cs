namespace PodkladexApp.Produkcja
{
    partial class Form_MaszynaWyp
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
            cb_wyborMaszyny = new ComboBox();
            dgv_Wyposazenie = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            btn_dodaj = new Button();
            btn_edytuj = new Button();
            btn_przypisz = new Button();
            label2 = new Label();
            txtbox_wyszukaj = new TextBox();
            label3 = new Label();
            dgv_wlasciwosci = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Wyposazenie).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_wlasciwosci).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.03125F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.96875F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(cb_wyborMaszyny, 1, 0);
            tableLayoutPanel1.Controls.Add(dgv_Wyposazenie, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 5);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(txtbox_wyszukaj, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(dgv_wlasciwosci, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(939, 747);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(153, 25);
            label1.TabIndex = 0;
            label1.Text = "Maszyna:";
            // 
            // cb_wyborMaszyny
            // 
            cb_wyborMaszyny.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cb_wyborMaszyny.Font = new Font("Segoe UI", 11F);
            cb_wyborMaszyny.FormattingEnabled = true;
            cb_wyborMaszyny.Location = new Point(162, 4);
            cb_wyborMaszyny.Margin = new Padding(3, 4, 3, 4);
            cb_wyborMaszyny.Name = "cb_wyborMaszyny";
            cb_wyborMaszyny.Size = new Size(774, 33);
            cb_wyborMaszyny.TabIndex = 1;
            cb_wyborMaszyny.SelectedIndexChanged += cb_wyborMaszyny_SelectedIndexChanged;
            cb_wyborMaszyny.TextChanged += cb_wyborMaszyny_TextChanged;
            // 
            // dgv_Wyposazenie
            // 
            dgv_Wyposazenie.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Wyposazenie.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgv_Wyposazenie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgv_Wyposazenie, 2);
            dgv_Wyposazenie.Dock = DockStyle.Fill;
            dgv_Wyposazenie.Location = new Point(3, 78);
            dgv_Wyposazenie.Margin = new Padding(3, 4, 3, 4);
            dgv_Wyposazenie.Name = "dgv_Wyposazenie";
            dgv_Wyposazenie.RowHeadersWidth = 51;
            dgv_Wyposazenie.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Wyposazenie.Size = new Size(933, 253);
            dgv_Wyposazenie.TabIndex = 2;
            dgv_Wyposazenie.SelectionChanged += dgv_Wyposazenie_SelectionChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.Controls.Add(btn_dodaj, 0, 0);
            tableLayoutPanel2.Controls.Add(btn_edytuj, 1, 0);
            tableLayoutPanel2.Controls.Add(btn_przypisz, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 600);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(933, 66);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // btn_dodaj
            // 
            btn_dodaj.AutoSize = true;
            btn_dodaj.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_dodaj.Dock = DockStyle.Fill;
            btn_dodaj.Location = new Point(3, 3);
            btn_dodaj.Name = "btn_dodaj";
            btn_dodaj.Size = new Size(304, 60);
            btn_dodaj.TabIndex = 0;
            btn_dodaj.Text = "Dodaj";
            btn_dodaj.UseVisualStyleBackColor = true;
            btn_dodaj.Click += btn_dodaj_Click;
            // 
            // btn_edytuj
            // 
            btn_edytuj.AutoSize = true;
            btn_edytuj.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_edytuj.Dock = DockStyle.Fill;
            btn_edytuj.Location = new Point(313, 3);
            btn_edytuj.Name = "btn_edytuj";
            btn_edytuj.Size = new Size(305, 60);
            btn_edytuj.TabIndex = 1;
            btn_edytuj.Text = "Edytuj";
            btn_edytuj.UseVisualStyleBackColor = true;
            btn_edytuj.Click += btn_edytuj_Click;
            // 
            // btn_przypisz
            // 
            btn_przypisz.AutoSize = true;
            btn_przypisz.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_przypisz.Dock = DockStyle.Fill;
            btn_przypisz.Location = new Point(624, 3);
            btn_przypisz.Name = "btn_przypisz";
            btn_przypisz.Size = new Size(306, 60);
            btn_przypisz.TabIndex = 2;
            btn_przypisz.Text = "Przypisz wyposażenie";
            btn_przypisz.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(3, 43);
            label2.Name = "label2";
            label2.Size = new Size(153, 25);
            label2.TabIndex = 4;
            label2.Text = "Wyszukaj:";
            // 
            // txtbox_wyszukaj
            // 
            txtbox_wyszukaj.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtbox_wyszukaj.Font = new Font("Segoe UI", 11F);
            txtbox_wyszukaj.Location = new Point(162, 40);
            txtbox_wyszukaj.Name = "txtbox_wyszukaj";
            txtbox_wyszukaj.Size = new Size(774, 32);
            txtbox_wyszukaj.TabIndex = 5;
            txtbox_wyszukaj.TextChanged += txtbox_wyszukaj_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(3, 335);
            label3.Name = "label3";
            label3.Size = new Size(153, 37);
            label3.TabIndex = 6;
            label3.Text = "Właściwości";
            // 
            // dgv_wlasciwosci
            // 
            dgv_wlasciwosci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_wlasciwosci.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_wlasciwosci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgv_wlasciwosci, 2);
            dgv_wlasciwosci.Dock = DockStyle.Fill;
            dgv_wlasciwosci.Location = new Point(3, 375);
            dgv_wlasciwosci.Name = "dgv_wlasciwosci";
            dgv_wlasciwosci.RowHeadersWidth = 51;
            dgv_wlasciwosci.Size = new Size(933, 218);
            dgv_wlasciwosci.TabIndex = 7;
            // 
            // Form_MaszynaWyp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 747);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_MaszynaWyp";
            Text = "Form_MaszynaWyp";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Wyposazenie).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_wlasciwosci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private ComboBox cb_wyborMaszyny;
        private DataGridView dgv_Wyposazenie;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private TextBox txtbox_wyszukaj;
        private Button btn_dodaj;
        private Button btn_edytuj;
        private Button btn_przypisz;
        private Label label3;
        private DataGridView dgv_wlasciwosci;
    }
}