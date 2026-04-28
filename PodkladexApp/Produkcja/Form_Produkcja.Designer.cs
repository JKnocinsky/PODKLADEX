namespace PodkladexApp
{
    partial class Form_Produkcja
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
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.49064F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.50936F));
            tableLayoutPanel1.Controls.Add(panel_Produkcja, 1, 0);
            tableLayoutPanel1.Controls.Add(btn_wyp, 0, 1);
            tableLayoutPanel1.Controls.Add(btn_maszyny, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_normyP, 0, 2);
            tableLayoutPanel1.Controls.Add(btn_prod, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Size = new Size(1684, 791);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_Produkcja
            // 
            panel_Produkcja.Dock = DockStyle.Fill;
            panel_Produkcja.Location = new Point(331, 3);
            panel_Produkcja.Name = "panel_Produkcja";
            tableLayoutPanel1.SetRowSpan(panel_Produkcja, 5);
            panel_Produkcja.Size = new Size(1350, 785);
            panel_Produkcja.TabIndex = 3;
            // 
            // btn_wyp
            // 
            btn_wyp.Dock = DockStyle.Fill;
            btn_wyp.Font = new Font("Segoe UI", 14.5F);
            btn_wyp.Location = new Point(3, 61);
            btn_wyp.Margin = new Padding(3, 2, 3, 2);
            btn_wyp.Name = "btn_wyp";
            btn_wyp.Size = new Size(322, 55);
            btn_wyp.TabIndex = 5;
            btn_wyp.Text = "Wyposażenie";
            btn_wyp.UseVisualStyleBackColor = true;
            btn_wyp.Click += btn_wyp_Click;
            // 
            // btn_maszyny
            // 
            btn_maszyny.Dock = DockStyle.Fill;
            btn_maszyny.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_maszyny.Location = new Point(3, 3);
            btn_maszyny.Name = "btn_maszyny";
            btn_maszyny.Size = new Size(322, 53);
            btn_maszyny.TabIndex = 4;
            btn_maszyny.Text = "Maszyny";
            btn_maszyny.UseVisualStyleBackColor = true;
            btn_maszyny.Click += btn_maszyny_Click;
            // 
            // btn_normyP
            // 
            btn_normyP.Dock = DockStyle.Fill;
            btn_normyP.Font = new Font("Segoe UI", 14.5F);
            btn_normyP.Location = new Point(3, 121);
            btn_normyP.Name = "btn_normyP";
            btn_normyP.Size = new Size(322, 53);
            btn_normyP.TabIndex = 6;
            btn_normyP.Text = "Normy Produkcyjne";
            btn_normyP.UseVisualStyleBackColor = true;
            // 
            // btn_prod
            // 
            btn_prod.Dock = DockStyle.Fill;
            btn_prod.Font = new Font("Segoe UI", 14.5F);
            btn_prod.Location = new Point(3, 180);
            btn_prod.Name = "btn_prod";
            btn_prod.Size = new Size(322, 53);
            btn_prod.TabIndex = 7;
            btn_prod.Text = "Produkcja";
            btn_prod.UseVisualStyleBackColor = true;
            // 
            // Form_Produkcja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 791);
            Controls.Add(tableLayoutPanel1);
            Name = "Form_Produkcja";
            Text = "Form_Produkcja";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel_Produkcja;
        private Button btn_maszyny;
        private Button btn_wyp;
        private Button btn_normyP;
        private Button btn_prod;
    }
}