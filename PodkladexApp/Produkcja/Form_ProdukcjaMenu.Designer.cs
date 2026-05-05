namespace PodkladexApp
{
    partial class Form_ProdukcjaMenu
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
            panel_Produkcja = new Panel();
            btn_wyp = new Button();
            btn_maszyny = new Button();
            btn_normyP = new Button();
            btn_prod = new Button();
            btn_Pracownicy = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.49064F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.50936F));
            tableLayoutPanel1.Controls.Add(panel_Produkcja, 1, 0);
            tableLayoutPanel1.Controls.Add(btn_wyp, 0, 1);
            tableLayoutPanel1.Controls.Add(btn_maszyny, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_normyP, 0, 3);
            tableLayoutPanel1.Controls.Add(btn_prod, 0, 4);
            tableLayoutPanel1.Controls.Add(btn_Pracownicy, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 47.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1925, 1055);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_Produkcja
            // 
            panel_Produkcja.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Produkcja.Dock = DockStyle.Fill;
            panel_Produkcja.Location = new Point(378, 4);
            panel_Produkcja.Margin = new Padding(3, 4, 3, 4);
            panel_Produkcja.Name = "panel_Produkcja";
            tableLayoutPanel1.SetRowSpan(panel_Produkcja, 8);
            panel_Produkcja.Size = new Size(1544, 1047);
            panel_Produkcja.TabIndex = 3;
            // 
            // btn_wyp
            // 
            btn_wyp.AutoSize = true;
            btn_wyp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_wyp.Dock = DockStyle.Fill;
            btn_wyp.Font = new Font("Segoe UI", 14.5F);
            btn_wyp.Location = new Point(3, 82);
            btn_wyp.Name = "btn_wyp";
            btn_wyp.Size = new Size(369, 73);
            btn_wyp.TabIndex = 5;
            btn_wyp.Text = "Wyposażenie";
            btn_wyp.UseVisualStyleBackColor = true;
            btn_wyp.Click += btn_wyp_Click;
            // 
            // btn_maszyny
            // 
            btn_maszyny.AutoSize = true;
            btn_maszyny.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_maszyny.Dock = DockStyle.Fill;
            btn_maszyny.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_maszyny.Location = new Point(3, 4);
            btn_maszyny.Margin = new Padding(3, 4, 3, 4);
            btn_maszyny.Name = "btn_maszyny";
            btn_maszyny.Size = new Size(369, 71);
            btn_maszyny.TabIndex = 4;
            btn_maszyny.Text = "Maszyny";
            btn_maszyny.UseVisualStyleBackColor = true;
            btn_maszyny.Click += btn_maszyny_Click;
            // 
            // btn_normyP
            // 
            btn_normyP.AutoSize = true;
            btn_normyP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_normyP.Dock = DockStyle.Fill;
            btn_normyP.Font = new Font("Segoe UI", 14.5F);
            btn_normyP.Location = new Point(3, 241);
            btn_normyP.Margin = new Padding(3, 4, 3, 4);
            btn_normyP.Name = "btn_normyP";
            btn_normyP.Size = new Size(369, 71);
            btn_normyP.TabIndex = 6;
            btn_normyP.Text = "Normy Produkcyjne";
            btn_normyP.UseVisualStyleBackColor = true;
            btn_normyP.Click += btn_normyP_Click;
            // 
            // btn_prod
            // 
            btn_prod.AutoSize = true;
            btn_prod.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_prod.Dock = DockStyle.Fill;
            btn_prod.Font = new Font("Segoe UI", 14.5F);
            btn_prod.Location = new Point(3, 320);
            btn_prod.Margin = new Padding(3, 4, 3, 4);
            btn_prod.Name = "btn_prod";
            btn_prod.Size = new Size(369, 71);
            btn_prod.TabIndex = 7;
            btn_prod.Text = "Produkcja";
            btn_prod.UseVisualStyleBackColor = true;
            btn_prod.Click += btn_prod_Click;
            // 
            // btn_Pracownicy
            // 
            btn_Pracownicy.AutoSize = true;
            btn_Pracownicy.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Pracownicy.Dock = DockStyle.Fill;
            btn_Pracownicy.Font = new Font("Segoe UI", 14.5F);
            btn_Pracownicy.Location = new Point(3, 161);
            btn_Pracownicy.Name = "btn_Pracownicy";
            btn_Pracownicy.Size = new Size(369, 73);
            btn_Pracownicy.TabIndex = 8;
            btn_Pracownicy.Text = "Pracownicy";
            btn_Pracownicy.UseVisualStyleBackColor = true;
            // 
            // Form_ProdukcjaMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1925, 1055);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_ProdukcjaMenu";
            Text = "Form_Produkcja";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel_Produkcja;
        private Button btn_maszyny;
        private Button btn_wyp;
        private Button btn_normyP;
        private Button btn_prod;
        private Button btn_Pracownicy;
    }
}