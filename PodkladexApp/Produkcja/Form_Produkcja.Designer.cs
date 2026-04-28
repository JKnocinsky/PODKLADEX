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
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.4906425F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.50936F));
            tableLayoutPanel1.Controls.Add(panel_Produkcja, 1, 0);
            tableLayoutPanel1.Controls.Add(btn_wyp, 0, 1);
            tableLayoutPanel1.Controls.Add(btn_maszyny, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1924, 1055);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_Produkcja
            // 
            panel_Produkcja.Dock = DockStyle.Fill;
            panel_Produkcja.Location = new Point(377, 4);
            panel_Produkcja.Margin = new Padding(3, 4, 3, 4);
            panel_Produkcja.Name = "panel_Produkcja";
            tableLayoutPanel1.SetRowSpan(panel_Produkcja, 2);
            panel_Produkcja.Size = new Size(1544, 1047);
            panel_Produkcja.TabIndex = 3;
            // 
            // btn_wyp
            // 
            btn_wyp.Dock = DockStyle.Fill;
            btn_wyp.Font = new Font("Segoe UI", 14.5F);
            btn_wyp.Location = new Point(3, 530);
            btn_wyp.Name = "btn_wyp";
            btn_wyp.Size = new Size(368, 522);
            btn_wyp.TabIndex = 5;
            btn_wyp.Text = "Wyposażenie";
            btn_wyp.UseVisualStyleBackColor = true;
            btn_wyp.Click += btn_wyp_Click;
            // 
            // btn_maszyny
            // 
            btn_maszyny.Dock = DockStyle.Fill;
            btn_maszyny.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_maszyny.Location = new Point(3, 4);
            btn_maszyny.Margin = new Padding(3, 4, 3, 4);
            btn_maszyny.Name = "btn_maszyny";
            btn_maszyny.Size = new Size(368, 519);
            btn_maszyny.TabIndex = 4;
            btn_maszyny.Text = "Maszyny";
            btn_maszyny.UseVisualStyleBackColor = true;
            btn_maszyny.Click += btn_maszyny_Click;
            // 
            // Form_Produkcja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
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
    }
}