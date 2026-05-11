namespace PodkladexApp
{
    partial class Form_Umowy
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Umowy));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridView_umowy = new DataGridView();
            comboBox_pracownik = new ComboBox();
            comboBox_rodzajUmowy = new ComboBox();
            dateTimePicker_dataroz = new DateTimePicker();
            button_dodajUmowe = new Button();
            dateTimePicker_datazak = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            button_siatkaPlac = new Button();
            button_zatwierdzZmiany = new Button();
            button_nowaumowa = new Button();
            checkBox_tylkoAktywne = new CheckBox();
            comboBox_filtrPracownik = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_umowy).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView_umowy
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_umowy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_umowy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView_umowy.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(dataGridView_umowy, "dataGridView_umowy");
            dataGridView_umowy.Name = "dataGridView_umowy";
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridView_umowy.RowsDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // comboBox_pracownik
            // 
            resources.ApplyResources(comboBox_pracownik, "comboBox_pracownik");
            comboBox_pracownik.FormattingEnabled = true;
            comboBox_pracownik.Name = "comboBox_pracownik";
            comboBox_pracownik.TextUpdate += comboBox_pracownik_TextUpdate;
            // 
            // comboBox_rodzajUmowy
            // 
            resources.ApplyResources(comboBox_rodzajUmowy, "comboBox_rodzajUmowy");
            comboBox_rodzajUmowy.FormattingEnabled = true;
            comboBox_rodzajUmowy.Name = "comboBox_rodzajUmowy";
            // 
            // dateTimePicker_dataroz
            // 
            resources.ApplyResources(dateTimePicker_dataroz, "dateTimePicker_dataroz");
            dateTimePicker_dataroz.Name = "dateTimePicker_dataroz";
            // 
            // button_dodajUmowe
            // 
            resources.ApplyResources(button_dodajUmowe, "button_dodajUmowe");
            button_dodajUmowe.Name = "button_dodajUmowe";
            button_dodajUmowe.UseVisualStyleBackColor = true;
            button_dodajUmowe.Click += button_dodajUmowe_Click;
            // 
            // dateTimePicker_datazak
            // 
            resources.ApplyResources(dateTimePicker_datazak, "dateTimePicker_datazak");
            dateTimePicker_datazak.Name = "dateTimePicker_datazak";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // panel1
            // 
            panel1.Controls.Add(button_siatkaPlac);
            panel1.Controls.Add(button_zatwierdzZmiany);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboBox_pracownik);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboBox_rodzajUmowy);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dateTimePicker_dataroz);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateTimePicker_datazak);
            panel1.Controls.Add(button_dodajUmowe);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // button_siatkaPlac
            // 
            resources.ApplyResources(button_siatkaPlac, "button_siatkaPlac");
            button_siatkaPlac.Name = "button_siatkaPlac";
            button_siatkaPlac.UseVisualStyleBackColor = true;
            button_siatkaPlac.Click += button_siatkaPlac_Click;
            // 
            // button_zatwierdzZmiany
            // 
            resources.ApplyResources(button_zatwierdzZmiany, "button_zatwierdzZmiany");
            button_zatwierdzZmiany.Name = "button_zatwierdzZmiany";
            button_zatwierdzZmiany.UseVisualStyleBackColor = true;
            button_zatwierdzZmiany.Click += button_zatwierdzZmiany_Click;
            // 
            // button_nowaumowa
            // 
            resources.ApplyResources(button_nowaumowa, "button_nowaumowa");
            button_nowaumowa.Name = "button_nowaumowa";
            button_nowaumowa.UseVisualStyleBackColor = true;
            button_nowaumowa.Click += button_nowaumowa_Click;
            // 
            // checkBox_tylkoAktywne
            // 
            resources.ApplyResources(checkBox_tylkoAktywne, "checkBox_tylkoAktywne");
            checkBox_tylkoAktywne.Name = "checkBox_tylkoAktywne";
            checkBox_tylkoAktywne.UseVisualStyleBackColor = true;
            checkBox_tylkoAktywne.CheckedChanged += checkBox_tylkoAktywne_CheckedChanged;
            // 
            // comboBox_filtrPracownik
            // 
            resources.ApplyResources(comboBox_filtrPracownik, "comboBox_filtrPracownik");
            comboBox_filtrPracownik.FormattingEnabled = true;
            comboBox_filtrPracownik.Name = "comboBox_filtrPracownik";
            comboBox_filtrPracownik.SelectedIndexChanged += comboBox_filtrPracownik_SelectedIndexChanged;
            comboBox_filtrPracownik.TextUpdate += comboBox_filtrPracownik_TextUpdate;
            comboBox_filtrPracownik.Leave += comboBox_filtrPracownik_Leave;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // Form_Umowy
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            Controls.Add(comboBox_filtrPracownik);
            Controls.Add(checkBox_tylkoAktywne);
            Controls.Add(dataGridView_umowy);
            Controls.Add(panel1);
            Controls.Add(button_nowaumowa);
            Controls.Add(label5);
            Name = "Form_Umowy";
            Load += Form_Umowy_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_umowy).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_umowy;
        private ComboBox comboBox_pracownik;
        private ComboBox comboBox_rodzajUmowy;
        private DateTimePicker dateTimePicker_dataroz;
        private Button button_dodajUmowe;
        private DateTimePicker dateTimePicker_datazak;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Button button_nowaumowa;
        private CheckBox checkBox_tylkoAktywne;
        private ComboBox comboBox_filtrPracownik;
        private Label label5;
        private Button button_zatwierdzZmiany;
        private Button button_siatkaPlac;
    }
}