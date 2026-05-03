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
            ((System.ComponentModel.ISupportInitialize)dataGridView_Koszyk).BeginInit();
            panel_Firmy.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_Klient
            // 
            textBox_Klient.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Klient.Location = new Point(83, 82);
            textBox_Klient.Name = "textBox_Klient";
            textBox_Klient.Size = new Size(250, 33);
            textBox_Klient.TabIndex = 0;
            textBox_Klient.TextChanged += textBox_Klient_TextChanged;
            // 
            // textBox_DataZlozenia
            // 
            textBox_DataZlozenia.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_DataZlozenia.Location = new Point(83, 172);
            textBox_DataZlozenia.Name = "textBox_DataZlozenia";
            textBox_DataZlozenia.Size = new Size(250, 33);
            textBox_DataZlozenia.TabIndex = 1;
            // 
            // textBox_DataZrealizowania
            // 
            textBox_DataZrealizowania.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_DataZrealizowania.Location = new Point(83, 271);
            textBox_DataZrealizowania.Name = "textBox_DataZrealizowania";
            textBox_DataZrealizowania.Size = new Size(250, 33);
            textBox_DataZrealizowania.TabIndex = 2;
            // 
            // dataGridView_Koszyk
            // 
            dataGridView_Koszyk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Koszyk.Location = new Point(456, 46);
            dataGridView_Koszyk.Name = "dataGridView_Koszyk";
            dataGridView_Koszyk.Size = new Size(702, 410);
            dataGridView_Koszyk.TabIndex = 3;
            // 
            // panel_Firmy
            // 
            panel_Firmy.Controls.Add(textBox_NIP);
            panel_Firmy.Controls.Add(textBox_NazwaFirmy);
            panel_Firmy.Location = new Point(12, 345);
            panel_Firmy.Name = "panel_Firmy";
            panel_Firmy.Size = new Size(420, 254);
            panel_Firmy.TabIndex = 4;
            // 
            // textBox_NIP
            // 
            textBox_NIP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NIP.Location = new Point(71, 164);
            textBox_NIP.Name = "textBox_NIP";
            textBox_NIP.Size = new Size(250, 33);
            textBox_NIP.TabIndex = 6;
            // 
            // textBox_NazwaFirmy
            // 
            textBox_NazwaFirmy.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_NazwaFirmy.Location = new Point(71, 45);
            textBox_NazwaFirmy.Name = "textBox_NazwaFirmy";
            textBox_NazwaFirmy.Size = new Size(250, 33);
            textBox_NazwaFirmy.TabIndex = 5;
            // 
            // Form_HistoriaZamowienSzczegoly
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 611);
            Controls.Add(panel_Firmy);
            Controls.Add(dataGridView_Koszyk);
            Controls.Add(textBox_DataZrealizowania);
            Controls.Add(textBox_DataZlozenia);
            Controls.Add(textBox_Klient);
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
    }
}