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
            btn_maszyny = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.4859905F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 88.51401F));
            tableLayoutPanel1.Controls.Add(panel_Produkcja, 1, 0);
            tableLayoutPanel1.Controls.Add(btn_maszyny, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1814, 1117);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_Produkcja
            // 
            panel_Produkcja.Dock = DockStyle.Fill;
            panel_Produkcja.Location = new Point(211, 3);
            panel_Produkcja.Name = "panel_Produkcja";
            panel_Produkcja.Size = new Size(1600, 1111);
            panel_Produkcja.TabIndex = 3;
            // 
            // btn_maszyny
            // 
            btn_maszyny.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_maszyny.Location = new Point(3, 3);
            btn_maszyny.Name = "btn_maszyny";
            btn_maszyny.Size = new Size(191, 52);
            btn_maszyny.TabIndex = 4;
            btn_maszyny.Text = "Maszyny";
            btn_maszyny.UseVisualStyleBackColor = true;
            btn_maszyny.Click += btn_maszyny_Click;
            // 
            // Form_Produkcja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1814, 1117);
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
    }
}