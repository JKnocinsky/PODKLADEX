namespace PodkladexApp.Zaopatrzenie
{
    partial class Form_HistoriaZamowienSzczegoly
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
            textBox_Klient = new TextBox();
            textBox_DataZlozenia = new TextBox();
            textBox_DataZrealizowania = new TextBox();
            dataGridView_Koszyk = new DataGridView();
            panel_Firmy = new Panel();
            textBox_NIP = new TextBox();
            textBox_NazwaFirmy = new TextBox();
            label_Klient = new Label();
            label_DataZlozenia = new Label();
            label_DataZrealizowania = new Label();
            label_Firma = new Label();
            label_NIP = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Koszyk).BeginInit();
            panel_Firmy.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_Klient
            // 
            textBox_Klient.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Klient.Location = new Point(229, 51);
            textBox_Klient.Name = "textBox_Klient";
            textBox_Klient.Size = new Size(250, 33);
            textBox_Klient.TabIndex = 0;
            // 
            // textBox_DataZlozenia
            // 
            textBox_DataZlozenia.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_DataZlozenia.Location = new Point(229, 154);
            textBox_DataZlozenia.Name = "textBox_DataZlozenia";
            textBox_DataZlozenia.Size = new Size(250, 33);
            textBox_DataZlozenia.TabIndex = 1;
            // 
            // textBox_DataZrealizowania
            // 
            textBox_DataZrealizowania.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_DataZrealizowania.Location = new Point(229, 257);
            textBox_DataZrealizowania.Name = "textBox_DataZrealizowania";
            textBox_DataZrealizowania.Size = new Size(250, 33);
            textBox_DataZrealizowania.TabIndex = 2;
            // 
            // dataGridView_Koszyk
            // 
            dataGridView_Koszyk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Koszyk.Location = new Point(501, 50);
            dataGridView_Koszyk.Name = "dataGridView_Koszyk";
            dataGridView_Koszyk.Size = new Size(702, 410);
            dataGridView_Koszyk.TabIndex = 3;
            // 
            // panel_Firmy
            // 
            panel_Firmy.Controls.Add(label_NIP);
            panel_Firmy.Controls.Add(label_Firma);
            panel_Firmy.Controls.Add(textBox_NazwaFirmy);
            panel_Firmy.Controls.Add(textBox_NIP);
            panel_Firmy.Location = new Point(48, 330);
            panel_Firmy.Name = "panel_Firmy";
            panel_Firmy.Size = new Size(447, 254);
            panel_Firmy.TabIndex = 4;
            // 
            // textBox_NIP
            // 
            textBox_NIP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NIP.Location = new Point(181, 132);
            textBox_NIP.Name = "textBox_NIP";
            textBox_NIP.Size = new Size(250, 33);
            textBox_NIP.TabIndex = 6;
            // 
            // textBox_NazwaFirmy
            // 
            textBox_NazwaFirmy.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NazwaFirmy.Location = new Point(181, 34);
            textBox_NazwaFirmy.Name = "textBox_NazwaFirmy";
            textBox_NazwaFirmy.Size = new Size(250, 33);
            textBox_NazwaFirmy.TabIndex = 5;
            // 
            // label_Klient
            // 
            label_Klient.AutoSize = true;
            label_Klient.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Klient.Location = new Point(160, 59);
            label_Klient.Name = "label_Klient";
            label_Klient.Size = new Size(60, 25);
            label_Klient.TabIndex = 7;
            label_Klient.Text = "Klient";
            // 
            // label_DataZlozenia
            // 
            label_DataZlozenia.AutoSize = true;
            label_DataZlozenia.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_DataZlozenia.Location = new Point(94, 162);
            label_DataZlozenia.Name = "label_DataZlozenia";
            label_DataZlozenia.Size = new Size(126, 25);
            label_DataZlozenia.TabIndex = 8;
            label_DataZlozenia.Text = "Data zlożenia";
            // 
            // label_DataZrealizowania
            // 
            label_DataZrealizowania.AutoSize = true;
            label_DataZrealizowania.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_DataZrealizowania.Location = new Point(48, 260);
            label_DataZrealizowania.Name = "label_DataZrealizowania";
            label_DataZrealizowania.Size = new Size(172, 25);
            label_DataZrealizowania.TabIndex = 9;
            label_DataZrealizowania.Text = "Data zrealizowania";
            // 
            // label_Firma
            // 
            label_Firma.AutoSize = true;
            label_Firma.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Firma.Location = new Point(112, 42);
            label_Firma.Name = "label_Firma";
            label_Firma.Size = new Size(59, 25);
            label_Firma.TabIndex = 10;
            label_Firma.Text = "Firma";
            label_Firma.Click += label_Firma_Click;
            // 
            // label_NIP
            // 
            label_NIP.AutoSize = true;
            label_NIP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_NIP.Location = new Point(129, 140);
            label_NIP.Name = "label_NIP";
            label_NIP.Size = new Size(42, 25);
            label_NIP.TabIndex = 11;
            label_NIP.Text = "NIP";
            // 
            // Form_HistoriaZamowienSzczegoly
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1215, 629);
            Controls.Add(label_DataZrealizowania);
            Controls.Add(label_DataZlozenia);
            Controls.Add(label_Klient);
            Controls.Add(textBox_DataZrealizowania);
            Controls.Add(textBox_DataZlozenia);
            Controls.Add(textBox_Klient);
            Controls.Add(panel_Firmy);
            Controls.Add(dataGridView_Koszyk);
            Name = "Form_HistoriaZamowienSzczegoly";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView_Koszyk).EndInit();
            panel_Firmy.ResumeLayout(false);
            panel_Firmy.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_Klient;
        private TextBox textBox_DataZlozenia;
        private TextBox textBox_DataZrealizowania;
        private DataGridView dataGridView_Koszyk;
        private Panel panel_Firmy;
        private TextBox textBox_NIP;
        private TextBox textBox_NazwaFirmy;
        private Label label_NIP;
        private Label label_Firma;
        private Label label_Klient;
        private Label label_DataZlozenia;
        private Label label_DataZrealizowania;
    }
}