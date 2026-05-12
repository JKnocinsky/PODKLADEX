namespace PodkladexApp.Produkcja
{
    partial class Form_ProdukcjaPracownicy
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
            dgv_pracownicy = new DataGridView();
            dtp_data = new DateTimePicker();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_pracownicy).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(dgv_pracownicy, 1, 2);
            tableLayoutPanel1.Controls.Add(dtp_data, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(5, 5, 5, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Size = new Size(1436, 1136);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgv_pracownicy
            // 
            dgv_pracownicy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_pracownicy.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_pracownicy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_pracownicy.Dock = DockStyle.Fill;
            dgv_pracownicy.Location = new Point(76, 231);
            dgv_pracownicy.Margin = new Padding(5, 5, 5, 5);
            dgv_pracownicy.Name = "dgv_pracownicy";
            dgv_pracownicy.RowHeadersWidth = 51;
            dgv_pracownicy.Size = new Size(1210, 728);
            dgv_pracownicy.TabIndex = 0;
            // 
            // dtp_data
            // 
            dtp_data.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtp_data.Location = new Point(76, 150);
            dtp_data.Margin = new Padding(5, 5, 5, 5);
            dtp_data.Name = "dtp_data";
            dtp_data.Size = new Size(1210, 39);
            dtp_data.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.5F);
            label1.Location = new Point(465, 39);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(432, 35);
            label1.TabIndex = 2;
            label1.Text = "Produkcja - dostępność pracowników";
            // 
            // Form_ProdukcjaPracownicy
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1436, 1136);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form_ProdukcjaPracownicy";
            Text = "Form_ProdukcjaPracownicy";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_pracownicy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgv_pracownicy;
        private DateTimePicker dtp_data;
        private Label label1;
    }
}