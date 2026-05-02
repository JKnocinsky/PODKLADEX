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
            label_data_Poczatku = new Label();
            label_Data_konca = new Label();
            label_Sortowanie = new Label();
            button_Szczegoly = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_HistoriaZamowien).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_HistoriaZamowien
            // 
            dataGridView_HistoriaZamowien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_HistoriaZamowien.Location = new Point(42, 66);
            dataGridView_HistoriaZamowien.Name = "dataGridView_HistoriaZamowien";
            dataGridView_HistoriaZamowien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_HistoriaZamowien.Size = new Size(1076, 523);
            dataGridView_HistoriaZamowien.TabIndex = 0;
            dataGridView_HistoriaZamowien.CellContentClick += dataGridView_HistoriaZamowien_CellContentClick;
            dataGridView_HistoriaZamowien.SelectionChanged += dataGridView_HistoriaZamowien_SelectionChanged;
            // 
            // dateTimePicker_Poczatek
            // 
            dateTimePicker_Poczatek.CalendarFont = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dateTimePicker_Poczatek.Format = DateTimePickerFormat.Short;
            dateTimePicker_Poczatek.Location = new Point(205, 627);
            dateTimePicker_Poczatek.Name = "dateTimePicker_Poczatek";
            dateTimePicker_Poczatek.Size = new Size(150, 23);
            dateTimePicker_Poczatek.TabIndex = 1;
            dateTimePicker_Poczatek.ValueChanged += dateTimePicker_Poczatek_ValueChanged;
            // 
            // dateTimePicker_Koniec
            // 
            dateTimePicker_Koniec.CalendarFont = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePicker_Koniec.Format = DateTimePickerFormat.Short;
            dateTimePicker_Koniec.Location = new Point(503, 627);
            dateTimePicker_Koniec.Name = "dateTimePicker_Koniec";
            dateTimePicker_Koniec.Size = new Size(150, 23);
            dateTimePicker_Koniec.TabIndex = 2;
            dateTimePicker_Koniec.ValueChanged += dateTimePicker_Koniec_ValueChanged;
            // 
            // comboBox_sortowanie
            // 
            comboBox_sortowanie.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            comboBox_sortowanie.FormattingEnabled = true;
            comboBox_sortowanie.Location = new Point(274, 672);
            comboBox_sortowanie.Name = "comboBox_sortowanie";
            comboBox_sortowanie.Size = new Size(379, 33);
            comboBox_sortowanie.TabIndex = 3;
            comboBox_sortowanie.SelectedIndexChanged += comboBox_sortowanie_SelectedIndexChanged;
            // 
            // label_data_Poczatku
            // 
            label_data_Poczatku.AutoSize = true;
            label_data_Poczatku.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_data_Poczatku.Location = new Point(42, 627);
            label_data_Poczatku.Name = "label_data_Poczatku";
            label_data_Poczatku.Size = new Size(132, 25);
            label_data_Poczatku.TabIndex = 4;
            label_data_Poczatku.Text = "Data początku";
            label_data_Poczatku.Click += label_data_Poczatku_Click;
            // 
            // label_Data_konca
            // 
            label_Data_konca.AutoSize = true;
            label_Data_konca.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Data_konca.Location = new Point(377, 625);
            label_Data_konca.Name = "label_Data_konca";
            label_Data_konca.Size = new Size(106, 25);
            label_Data_konca.TabIndex = 5;
            label_Data_konca.Text = "Data końca";
            // 
            // label_Sortowanie
            // 
            label_Sortowanie.AutoSize = true;
            label_Sortowanie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Sortowanie.Location = new Point(161, 675);
            label_Sortowanie.Name = "label_Sortowanie";
            label_Sortowanie.Size = new Size(107, 25);
            label_Sortowanie.TabIndex = 6;
            label_Sortowanie.Text = "Sortowanie";
            // 
            // button_Szczegoly
            // 
            button_Szczegoly.Enabled = false;
            button_Szczegoly.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_Szczegoly.Location = new Point(764, 650);
            button_Szczegoly.Name = "button_Szczegoly";
            button_Szczegoly.Size = new Size(250, 50);
            button_Szczegoly.TabIndex = 7;
            button_Szczegoly.Text = "Szczegóły zamówienia";
            button_Szczegoly.UseVisualStyleBackColor = true;
            button_Szczegoly.Click += button1_Click;
            // 
            // Form_HistoriaZamowien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 730);
            Controls.Add(button_Szczegoly);
            Controls.Add(label_Sortowanie);
            Controls.Add(label_Data_konca);
            Controls.Add(label_data_Poczatku);
            Controls.Add(comboBox_sortowanie);
            Controls.Add(dateTimePicker_Koniec);
            Controls.Add(dateTimePicker_Poczatek);
            Controls.Add(dataGridView_HistoriaZamowien);
            Name = "Form_HistoriaZamowien";
            Text = "Historia zamówień";
            Load += Form_HistoriaZamowien_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_HistoriaZamowien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_HistoriaZamowien;
        private DateTimePicker dateTimePicker_Poczatek;
        private DateTimePicker dateTimePicker_Koniec;
        private ComboBox comboBox_sortowanie;
        private Label label_data_Poczatku;
        private Label label_Data_konca;
        private Label label_Sortowanie;
        private Button button_Szczegoly;
    }
}