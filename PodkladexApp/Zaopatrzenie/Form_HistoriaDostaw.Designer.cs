namespace PodkladexApp.Zaopatrzenie
{
    partial class Form_HistoriaDostaw
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
            button_Szczegoly = new Button();
            label_Sortowanie = new Label();
            label_Data_konca = new Label();
            label_data_Poczatku = new Label();
            comboBox_sortowanie = new ComboBox();
            dateTimePicker_Koniec = new DateTimePicker();
            dateTimePicker_Poczatek = new DateTimePicker();
            radioButton_StatusWszystkie = new RadioButton();
            panel1 = new Panel();
            radioButton_StatusZakonczone = new RadioButton();
            radioButton_StatusWToku = new RadioButton();
            dataGridView_HistoriaZamowien = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HistoriaZamowien).BeginInit();
            SuspendLayout();
            // 
            // button_Szczegoly
            // 
            button_Szczegoly.Enabled = false;
            button_Szczegoly.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_Szczegoly.Location = new Point(842, 579);
            button_Szczegoly.Name = "button_Szczegoly";
            button_Szczegoly.Size = new Size(250, 50);
            button_Szczegoly.TabIndex = 19;
            button_Szczegoly.Text = "Szczegóły zamówienia";
            button_Szczegoly.UseVisualStyleBackColor = true;
            // 
            // label_Sortowanie
            // 
            label_Sortowanie.AutoSize = true;
            label_Sortowanie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Sortowanie.Location = new Point(52, 646);
            label_Sortowanie.Name = "label_Sortowanie";
            label_Sortowanie.Size = new Size(107, 25);
            label_Sortowanie.TabIndex = 18;
            label_Sortowanie.Text = "Sortowanie";
            // 
            // label_Data_konca
            // 
            label_Data_konca.AutoSize = true;
            label_Data_konca.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Data_konca.Location = new Point(392, 592);
            label_Data_konca.Name = "label_Data_konca";
            label_Data_konca.Size = new Size(106, 25);
            label_Data_konca.TabIndex = 17;
            label_Data_konca.Text = "Data końca";
            // 
            // label_data_Poczatku
            // 
            label_data_Poczatku.AutoSize = true;
            label_data_Poczatku.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_data_Poczatku.Location = new Point(57, 594);
            label_data_Poczatku.Name = "label_data_Poczatku";
            label_data_Poczatku.Size = new Size(132, 25);
            label_data_Poczatku.TabIndex = 16;
            label_data_Poczatku.Text = "Data początku";
            // 
            // comboBox_sortowanie
            // 
            comboBox_sortowanie.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            comboBox_sortowanie.FormattingEnabled = true;
            comboBox_sortowanie.Location = new Point(165, 643);
            comboBox_sortowanie.Name = "comboBox_sortowanie";
            comboBox_sortowanie.Size = new Size(379, 33);
            comboBox_sortowanie.TabIndex = 15;
            // 
            // dateTimePicker_Koniec
            // 
            dateTimePicker_Koniec.CalendarFont = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_Koniec.Format = DateTimePickerFormat.Short;
            dateTimePicker_Koniec.Location = new Point(518, 594);
            dateTimePicker_Koniec.Name = "dateTimePicker_Koniec";
            dateTimePicker_Koniec.Size = new Size(150, 23);
            dateTimePicker_Koniec.TabIndex = 14;
            // 
            // dateTimePicker_Poczatek
            // 
            dateTimePicker_Poczatek.CalendarFont = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dateTimePicker_Poczatek.Format = DateTimePickerFormat.Short;
            dateTimePicker_Poczatek.Location = new Point(220, 594);
            dateTimePicker_Poczatek.Name = "dateTimePicker_Poczatek";
            dateTimePicker_Poczatek.Size = new Size(150, 23);
            dateTimePicker_Poczatek.TabIndex = 13;
            // 
            // radioButton_StatusWszystkie
            // 
            radioButton_StatusWszystkie.AutoSize = true;
            radioButton_StatusWszystkie.Checked = true;
            radioButton_StatusWszystkie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            radioButton_StatusWszystkie.Location = new Point(0, 24);
            radioButton_StatusWszystkie.Name = "radioButton_StatusWszystkie";
            radioButton_StatusWszystkie.Size = new Size(158, 29);
            radioButton_StatusWszystkie.TabIndex = 9;
            radioButton_StatusWszystkie.TabStop = true;
            radioButton_StatusWszystkie.Text = "Dowolny status";
            radioButton_StatusWszystkie.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton_StatusZakonczone);
            panel1.Controls.Add(radioButton_StatusWToku);
            panel1.Controls.Add(radioButton_StatusWszystkie);
            panel1.Location = new Point(566, 682);
            panel1.Name = "panel1";
            panel1.Size = new Size(551, 65);
            panel1.TabIndex = 20;
            // 
            // radioButton_StatusZakonczone
            // 
            radioButton_StatusZakonczone.AutoSize = true;
            radioButton_StatusZakonczone.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            radioButton_StatusZakonczone.Location = new Point(339, 24);
            radioButton_StatusZakonczone.Name = "radioButton_StatusZakonczone";
            radioButton_StatusZakonczone.Size = new Size(143, 29);
            radioButton_StatusZakonczone.TabIndex = 11;
            radioButton_StatusZakonczone.Text = "Zrealizowane";
            radioButton_StatusZakonczone.UseVisualStyleBackColor = true;
            // 
            // radioButton_StatusWToku
            // 
            radioButton_StatusWToku.AutoSize = true;
            radioButton_StatusWToku.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            radioButton_StatusWToku.Location = new Point(189, 24);
            radioButton_StatusWToku.Name = "radioButton_StatusWToku";
            radioButton_StatusWToku.Size = new Size(128, 29);
            radioButton_StatusWToku.TabIndex = 10;
            radioButton_StatusWToku.Text = "W realizacji";
            radioButton_StatusWToku.UseVisualStyleBackColor = true;
            // 
            // dataGridView_HistoriaZamowien
            // 
            dataGridView_HistoriaZamowien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_HistoriaZamowien.Location = new Point(57, 33);
            dataGridView_HistoriaZamowien.Name = "dataGridView_HistoriaZamowien";
            dataGridView_HistoriaZamowien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_HistoriaZamowien.Size = new Size(1076, 523);
            dataGridView_HistoriaZamowien.TabIndex = 12;
            dataGridView_HistoriaZamowien.CellContentClick += dataGridView_HistoriaZamowien_CellContentClick;
            // 
            // Form_HistoriaDostaw
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 781);
            Controls.Add(button_Szczegoly);
            Controls.Add(label_Sortowanie);
            Controls.Add(label_Data_konca);
            Controls.Add(label_data_Poczatku);
            Controls.Add(comboBox_sortowanie);
            Controls.Add(dateTimePicker_Koniec);
            Controls.Add(dateTimePicker_Poczatek);
            Controls.Add(panel1);
            Controls.Add(dataGridView_HistoriaZamowien);
            Name = "Form_HistoriaDostaw";
            Text = "Form2";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HistoriaZamowien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Szczegoly;
        private Label label_Sortowanie;
        private Label label_Data_konca;
        private Label label_data_Poczatku;
        private ComboBox comboBox_sortowanie;
        private DateTimePicker dateTimePicker_Koniec;
        private DateTimePicker dateTimePicker_Poczatek;
        private RadioButton radioButton_StatusWszystkie;
        private Panel panel1;
        private RadioButton radioButton_StatusZakonczone;
        private RadioButton radioButton_StatusWToku;
        private DataGridView dataGridView_HistoriaZamowien;
    }
}