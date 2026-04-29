namespace PodkladexApp.Zaopatrzenie
{
    partial class Form_HistoriaZamowien
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
            dataGridView__HistoriaZamowien = new DataGridView();
            dateTimePicker_Poczatek = new DateTimePicker();
            dateTimePicker_Koniec = new DateTimePicker();
            comboBox_sortowanie = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView__HistoriaZamowien).BeginInit();
            SuspendLayout();
            // 
            // dataGridView__HistoriaZamowien
            // 
            dataGridView__HistoriaZamowien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView__HistoriaZamowien.Location = new Point(42, 66);
            dataGridView__HistoriaZamowien.Name = "dataGridView__HistoriaZamowien";
            dataGridView__HistoriaZamowien.Size = new Size(692, 325);
            dataGridView__HistoriaZamowien.TabIndex = 0;
            // 
            // dateTimePicker_Poczatek
            // 
            dateTimePicker_Poczatek.Location = new Point(68, 434);
            dateTimePicker_Poczatek.Name = "dateTimePicker_Poczatek";
            dateTimePicker_Poczatek.Size = new Size(200, 23);
            dateTimePicker_Poczatek.TabIndex = 1;
            // 
            // dateTimePicker_Koniec
            // 
            dateTimePicker_Koniec.Location = new Point(307, 434);
            dateTimePicker_Koniec.Name = "dateTimePicker_Koniec";
            dateTimePicker_Koniec.Size = new Size(200, 23);
            dateTimePicker_Koniec.TabIndex = 2;
            // 
            // comboBox_sortowanie
            // 
            comboBox_sortowanie.FormattingEnabled = true;
            comboBox_sortowanie.Location = new Point(588, 434);
            comboBox_sortowanie.Name = "comboBox_sortowanie";
            comboBox_sortowanie.Size = new Size(121, 23);
            comboBox_sortowanie.TabIndex = 3;
            // 
            // Form_HistoriaZamowien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 520);
            Controls.Add(comboBox_sortowanie);
            Controls.Add(dateTimePicker_Koniec);
            Controls.Add(dateTimePicker_Poczatek);
            Controls.Add(dataGridView__HistoriaZamowien);
            Name = "Form_HistoriaZamowien";
            Text = "Historia zamówień";
            Load += Form_HistoriaZamowien_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView__HistoriaZamowien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView__HistoriaZamowien;
        private DateTimePicker dateTimePicker_Poczatek;
        private DateTimePicker dateTimePicker_Koniec;
        private ComboBox comboBox_sortowanie;
    }
}