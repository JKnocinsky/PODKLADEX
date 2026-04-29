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
            dataGridView_HistoriaZamowien = new DataGridView();
            dateTimePicker_Poczatek = new DateTimePicker();
            dateTimePicker_Koniec = new DateTimePicker();
            comboBox_sortowanie = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HistoriaZamowien).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_HistoriaZamowien
            // 
            dataGridView_HistoriaZamowien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_HistoriaZamowien.Location = new Point(42, 66);
            dataGridView_HistoriaZamowien.Name = "dataGridView_HistoriaZamowien";
            dataGridView_HistoriaZamowien.Size = new Size(1076, 523);
            dataGridView_HistoriaZamowien.TabIndex = 0;
            dataGridView_HistoriaZamowien.CellContentClick += dataGridView_HistoriaZamowien_CellContentClick;
            // 
            // dateTimePicker_Poczatek
            // 
            dateTimePicker_Poczatek.Location = new Point(219, 630);
            dateTimePicker_Poczatek.Name = "dateTimePicker_Poczatek";
            dateTimePicker_Poczatek.Size = new Size(200, 23);
            dateTimePicker_Poczatek.TabIndex = 1;
            dateTimePicker_Poczatek.ValueChanged += dateTimePicker_Poczatek_ValueChanged;
            // 
            // dateTimePicker_Koniec
            // 
            dateTimePicker_Koniec.Location = new Point(458, 630);
            dateTimePicker_Koniec.Name = "dateTimePicker_Koniec";
            dateTimePicker_Koniec.Size = new Size(200, 23);
            dateTimePicker_Koniec.TabIndex = 2;
            dateTimePicker_Koniec.ValueChanged += dateTimePicker_Koniec_ValueChanged;
            // 
            // comboBox_sortowanie
            // 
            comboBox_sortowanie.FormattingEnabled = true;
            comboBox_sortowanie.Location = new Point(739, 630);
            comboBox_sortowanie.Name = "comboBox_sortowanie";
            comboBox_sortowanie.Size = new Size(121, 23);
            comboBox_sortowanie.TabIndex = 3;
            comboBox_sortowanie.SelectedIndexChanged += comboBox_sortowanie_SelectedIndexChanged;
            // 
            // Form_HistoriaZamowien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 730);
            Controls.Add(comboBox_sortowanie);
            Controls.Add(dateTimePicker_Koniec);
            Controls.Add(dateTimePicker_Poczatek);
            Controls.Add(dataGridView_HistoriaZamowien);
            Name = "Form_HistoriaZamowien";
            Text = "Historia zamówień";
            Load += Form_HistoriaZamowien_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_HistoriaZamowien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView_HistoriaZamowien;
        private DateTimePicker dateTimePicker_Poczatek;
        private DateTimePicker dateTimePicker_Koniec;
        private ComboBox comboBox_sortowanie;
    }
}