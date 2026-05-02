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
            label_Tytul = new Label();
            label_FiltrMaszyna = new Label();
            label_FiltrPracownik = new Label();
            comboBox_FiltrMaszyna = new ComboBox();
            comboBox_FiltrPracownik = new ComboBox();
            btn_WyczyscFiltry = new Button();
            DGV_Efektywnosc = new DataGridView();
            label_Sortowanie = new Label();
            comboBox_Sortowanie = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DGV_Efektywnosc).BeginInit();
            SuspendLayout();
            // 
            // label_Tytul
            // 
            label_Tytul.AutoSize = true;
            label_Tytul.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Tytul.Location = new Point(384, 9);
            label_Tytul.Name = "label_Tytul";
            label_Tytul.Size = new Size(265, 25);
            label_Tytul.TabIndex = 0;
            label_Tytul.Text = "Raport Efektywności Produkcji";
            // 
            // label_FiltrMaszyna
            // 
            label_FiltrMaszyna.AutoSize = true;
            label_FiltrMaszyna.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_FiltrMaszyna.Location = new Point(42, 56);
            label_FiltrMaszyna.Name = "label_FiltrMaszyna";
            label_FiltrMaszyna.Size = new Size(159, 25);
            label_FiltrMaszyna.TabIndex = 1;
            label_FiltrMaszyna.Text = "Wybierz maszynę";
            // 
            // label_FiltrPracownik
            // 
            label_FiltrPracownik.AutoSize = true;
            label_FiltrPracownik.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_FiltrPracownik.Location = new Point(42, 100);
            label_FiltrPracownik.Name = "label_FiltrPracownik";
            label_FiltrPracownik.Size = new Size(183, 25);
            label_FiltrPracownik.TabIndex = 2;
            label_FiltrPracownik.Text = "Wybierz pracownika";
            // 
            // comboBox_FiltrMaszyna
            // 
            comboBox_FiltrMaszyna.FormattingEnabled = true;
            comboBox_FiltrMaszyna.Location = new Point(231, 58);
            comboBox_FiltrMaszyna.Name = "comboBox_FiltrMaszyna";
            comboBox_FiltrMaszyna.Size = new Size(180, 23);
            comboBox_FiltrMaszyna.TabIndex = 3;
            // 
            // comboBox_FiltrPracownik
            // 
            comboBox_FiltrPracownik.FormattingEnabled = true;
            comboBox_FiltrPracownik.Location = new Point(231, 102);
            comboBox_FiltrPracownik.Name = "comboBox_FiltrPracownik";
            comboBox_FiltrPracownik.Size = new Size(180, 23);
            comboBox_FiltrPracownik.TabIndex = 4;
            // 
            // btn_WyczyscFiltry
            // 
            btn_WyczyscFiltry.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_WyczyscFiltry.Location = new Point(458, 56);
            btn_WyczyscFiltry.Name = "btn_WyczyscFiltry";
            btn_WyczyscFiltry.Size = new Size(159, 66);
            btn_WyczyscFiltry.TabIndex = 5;
            btn_WyczyscFiltry.Text = "Wyczyść filtry";
            btn_WyczyscFiltry.UseVisualStyleBackColor = true;
            // 
            // DGV_Efektywnosc
            // 
            DGV_Efektywnosc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Efektywnosc.Location = new Point(42, 146);
            DGV_Efektywnosc.Name = "DGV_Efektywnosc";
            DGV_Efektywnosc.Size = new Size(1017, 248);
            DGV_Efektywnosc.TabIndex = 6;
            // 
            // label_Sortowanie
            // 
            label_Sortowanie.AutoSize = true;
            label_Sortowanie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Sortowanie.Location = new Point(674, 58);
            label_Sortowanie.Name = "label_Sortowanie";
            label_Sortowanie.Size = new Size(107, 25);
            label_Sortowanie.TabIndex = 7;
            label_Sortowanie.Text = "Sortowanie";
            // 
            // comboBox_Sortowanie
            // 
            comboBox_Sortowanie.FormattingEnabled = true;
            comboBox_Sortowanie.Location = new Point(674, 86);
            comboBox_Sortowanie.Name = "comboBox_Sortowanie";
            comboBox_Sortowanie.Size = new Size(159, 23);
            comboBox_Sortowanie.TabIndex = 8;
            // 
            // Form_Efektywnosc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1337, 758);
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
    }
}