namespace PodkladexApp
{
    partial class Form_Efektywnosc
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
            label_Tytul = new Label();
            label_FiltrMaszyna = new Label();
            label_FiltrPracownik = new Label();
            comboBox_FiltrMaszyna = new ComboBox();
            comboBox_FiltrPracownik = new ComboBox();
            btn_WyczyscFiltry = new Button();
            DGV_Efektywnosc = new DataGridView();
            label_Sortowanie = new Label();
            comboBox_Sortowanie = new ComboBox();
            formsPlot_Efektywnosc = new ScottPlot.WinForms.FormsPlot();
            btn_WidokMaterialy = new Button();
            btn_WidokProdukty = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Efektywnosc).BeginInit();
            SuspendLayout();
            // 
            // label_Tytul
            // 
            label_Tytul.AutoSize = true;
            label_Tytul.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Tytul.Location = new Point(564, 11);
            label_Tytul.Name = "label_Tytul";
            label_Tytul.Size = new Size(265, 25);
            label_Tytul.TabIndex = 0;
            label_Tytul.Text = "Raport Efektywności Produkcji";
            // 
            // label_FiltrMaszyna
            // 
            label_FiltrMaszyna.AutoSize = true;
            label_FiltrMaszyna.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_FiltrMaszyna.Location = new Point(222, 58);
            label_FiltrMaszyna.Name = "label_FiltrMaszyna";
            label_FiltrMaszyna.Size = new Size(159, 25);
            label_FiltrMaszyna.TabIndex = 1;
            label_FiltrMaszyna.Text = "Wybierz maszynę";
            // 
            // label_FiltrPracownik
            // 
            label_FiltrPracownik.AutoSize = true;
            label_FiltrPracownik.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_FiltrPracownik.Location = new Point(222, 102);
            label_FiltrPracownik.Name = "label_FiltrPracownik";
            label_FiltrPracownik.Size = new Size(183, 25);
            label_FiltrPracownik.TabIndex = 2;
            label_FiltrPracownik.Text = "Wybierz pracownika";
            // 
            // comboBox_FiltrMaszyna
            // 
            comboBox_FiltrMaszyna.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_FiltrMaszyna.FormattingEnabled = true;
            comboBox_FiltrMaszyna.Location = new Point(411, 50);
            comboBox_FiltrMaszyna.Name = "comboBox_FiltrMaszyna";
            comboBox_FiltrMaszyna.Size = new Size(210, 33);
            comboBox_FiltrMaszyna.TabIndex = 3;
            // 
            // comboBox_FiltrPracownik
            // 
            comboBox_FiltrPracownik.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_FiltrPracownik.FormattingEnabled = true;
            comboBox_FiltrPracownik.Location = new Point(411, 94);
            comboBox_FiltrPracownik.Name = "comboBox_FiltrPracownik";
            comboBox_FiltrPracownik.Size = new Size(210, 33);
            comboBox_FiltrPracownik.TabIndex = 4;
            // 
            // btn_WyczyscFiltry
            // 
            btn_WyczyscFiltry.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_WyczyscFiltry.Location = new Point(660, 58);
            btn_WyczyscFiltry.Name = "btn_WyczyscFiltry";
            btn_WyczyscFiltry.Size = new Size(159, 66);
            btn_WyczyscFiltry.TabIndex = 5;
            btn_WyczyscFiltry.Text = "Wyczyść filtry";
            btn_WyczyscFiltry.UseVisualStyleBackColor = true;
            // 
            // DGV_Efektywnosc
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGV_Efektywnosc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGV_Efektywnosc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DGV_Efektywnosc.DefaultCellStyle = dataGridViewCellStyle2;
            DGV_Efektywnosc.Location = new Point(222, 148);
            DGV_Efektywnosc.Name = "DGV_Efektywnosc";
            DGV_Efektywnosc.Size = new Size(1017, 248);
            DGV_Efektywnosc.TabIndex = 6;
            // 
            // label_Sortowanie
            // 
            label_Sortowanie.AutoSize = true;
            label_Sortowanie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Sortowanie.Location = new Point(868, 79);
            label_Sortowanie.Name = "label_Sortowanie";
            label_Sortowanie.Size = new Size(107, 25);
            label_Sortowanie.TabIndex = 7;
            label_Sortowanie.Text = "Sortowanie";
            // 
            // comboBox_Sortowanie
            // 
            comboBox_Sortowanie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_Sortowanie.FormattingEnabled = true;
            comboBox_Sortowanie.Location = new Point(981, 76);
            comboBox_Sortowanie.Name = "comboBox_Sortowanie";
            comboBox_Sortowanie.Size = new Size(258, 33);
            comboBox_Sortowanie.TabIndex = 8;
            // 
            // formsPlot_Efektywnosc
            // 
            formsPlot_Efektywnosc.Location = new Point(222, 419);
            formsPlot_Efektywnosc.Name = "formsPlot_Efektywnosc";
            formsPlot_Efektywnosc.Size = new Size(1017, 540);
            formsPlot_Efektywnosc.TabIndex = 9;
            // 
            // btn_WidokMaterialy
            // 
            btn_WidokMaterialy.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_WidokMaterialy.Location = new Point(21, 126);
            btn_WidokMaterialy.Name = "btn_WidokMaterialy";
            btn_WidokMaterialy.Size = new Size(154, 65);
            btn_WidokMaterialy.TabIndex = 11;
            btn_WidokMaterialy.Text = "Produkcja półfabrykatów";
            btn_WidokMaterialy.UseVisualStyleBackColor = true;
            // 
            // btn_WidokProdukty
            // 
            btn_WidokProdukty.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_WidokProdukty.Location = new Point(21, 33);
            btn_WidokProdukty.Name = "btn_WidokProdukty";
            btn_WidokProdukty.Size = new Size(154, 65);
            btn_WidokProdukty.TabIndex = 10;
            btn_WidokProdukty.Text = "Produkcja podkładek";
            btn_WidokProdukty.UseVisualStyleBackColor = true;
            // 
            // Form_Efektywnosc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1322, 1007);
            Controls.Add(btn_WidokMaterialy);
            Controls.Add(btn_WidokProdukty);
            Controls.Add(formsPlot_Efektywnosc);
            Controls.Add(comboBox_Sortowanie);
            Controls.Add(label_Sortowanie);
            Controls.Add(DGV_Efektywnosc);
            Controls.Add(btn_WyczyscFiltry);
            Controls.Add(comboBox_FiltrPracownik);
            Controls.Add(comboBox_FiltrMaszyna);
            Controls.Add(label_FiltrPracownik);
            Controls.Add(label_FiltrMaszyna);
            Controls.Add(label_Tytul);
            Name = "Form_Efektywnosc";
            Text = "Form_Efektywnosc";
            ((System.ComponentModel.ISupportInitialize)DGV_Efektywnosc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Tytul;
        private Label label_FiltrMaszyna;
        private Label label_FiltrPracownik;
        private ComboBox comboBox_FiltrMaszyna;
        private ComboBox comboBox_FiltrPracownik;
        private Button btn_WyczyscFiltry;
        private DataGridView DGV_Efektywnosc;
        private Label label_Sortowanie;
        private ComboBox comboBox_Sortowanie;
        private ScottPlot.WinForms.FormsPlot formsPlot_Efektywnosc;
        private Button btn_WidokMaterialy;
        private Button btn_WidokProdukty;
    }
}