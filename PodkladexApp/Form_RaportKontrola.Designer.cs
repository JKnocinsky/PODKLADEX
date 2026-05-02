namespace PodkladexApp
{
    partial class Form_RaportKontrola
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
            btn_WidokProdukty = new Button();
            btn_WidokMaterialy = new Button();
            label_FiltrPracownik = new Label();
            comboBox_FiltrPracownik = new ComboBox();
            label_Sortowanie = new Label();
            comboBox_Sortowanie = new ComboBox();
            btn_WyczyscFiltry = new Button();
            label_ListaKontroli = new Label();
            DGV_Kontrole = new DataGridView();
            label_Pomiary = new Label();
            DGV_Pomiary = new DataGridView();
            label_SortowaniePomiarow = new Label();
            comboBox_SortowaniePomiarow = new ComboBox();
            label_Tytul = new Label();
            ((System.ComponentModel.ISupportInitialize)DGV_Kontrole).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Pomiary).BeginInit();
            SuspendLayout();
            // 
            // btn_WidokProdukty
            // 
            btn_WidokProdukty.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_WidokProdukty.Location = new Point(26, 109);
            btn_WidokProdukty.Name = "btn_WidokProdukty";
            btn_WidokProdukty.Size = new Size(154, 65);
            btn_WidokProdukty.TabIndex = 0;
            btn_WidokProdukty.Text = "Kontrola Produktów";
            btn_WidokProdukty.UseVisualStyleBackColor = true;
            // 
            // btn_WidokMaterialy
            // 
            btn_WidokMaterialy.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_WidokMaterialy.Location = new Point(26, 21);
            btn_WidokMaterialy.Name = "btn_WidokMaterialy";
            btn_WidokMaterialy.Size = new Size(154, 65);
            btn_WidokMaterialy.TabIndex = 1;
            btn_WidokMaterialy.Text = "Kontrola Materiałów";
            btn_WidokMaterialy.UseVisualStyleBackColor = true;
            // 
            // label_FiltrPracownik
            // 
            label_FiltrPracownik.AutoSize = true;
            label_FiltrPracownik.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_FiltrPracownik.Location = new Point(232, 51);
            label_FiltrPracownik.Name = "label_FiltrPracownik";
            label_FiltrPracownik.Size = new Size(196, 25);
            label_FiltrPracownik.TabIndex = 2;
            label_FiltrPracownik.Text = "Filtruj wg pracownika:";
            // 
            // comboBox_FiltrPracownik
            // 
            comboBox_FiltrPracownik.FormattingEnabled = true;
            comboBox_FiltrPracownik.Location = new Point(456, 51);
            comboBox_FiltrPracownik.Name = "comboBox_FiltrPracownik";
            comboBox_FiltrPracownik.Size = new Size(181, 23);
            comboBox_FiltrPracownik.TabIndex = 3;
            // 
            // label_Sortowanie
            // 
            label_Sortowanie.AutoSize = true;
            label_Sortowanie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Sortowanie.Location = new Point(232, 111);
            label_Sortowanie.Name = "label_Sortowanie";
            label_Sortowanie.Size = new Size(93, 25);
            label_Sortowanie.TabIndex = 4;
            label_Sortowanie.Text = "Sortuj po:";
            // 
            // comboBox_Sortowanie
            // 
            comboBox_Sortowanie.FormattingEnabled = true;
            comboBox_Sortowanie.Location = new Point(456, 111);
            comboBox_Sortowanie.Name = "comboBox_Sortowanie";
            comboBox_Sortowanie.Size = new Size(181, 23);
            comboBox_Sortowanie.TabIndex = 5;
            // 
            // btn_WyczyscFiltry
            // 
            btn_WyczyscFiltry.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_WyczyscFiltry.Location = new Point(758, 60);
            btn_WyczyscFiltry.Name = "btn_WyczyscFiltry";
            btn_WyczyscFiltry.Size = new Size(154, 65);
            btn_WyczyscFiltry.TabIndex = 6;
            btn_WyczyscFiltry.Text = "Wyczyść filtry";
            btn_WyczyscFiltry.UseVisualStyleBackColor = true;
            // 
            // label_ListaKontroli
            // 
            label_ListaKontroli.AutoSize = true;
            label_ListaKontroli.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_ListaKontroli.Location = new Point(232, 179);
            label_ListaKontroli.Name = "label_ListaKontroli";
            label_ListaKontroli.Size = new Size(621, 25);
            label_ListaKontroli.TabIndex = 7;
            label_ListaKontroli.Text = "Lista przeprowadzonych kontroli (kliknij wiersz, aby zobaczyć szczegóły):";
            // 
            // DGV_Kontrole
            // 
            DGV_Kontrole.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Kontrole.Location = new Point(232, 207);
            DGV_Kontrole.Name = "DGV_Kontrole";
            DGV_Kontrole.Size = new Size(876, 222);
            DGV_Kontrole.TabIndex = 8;
            // 
            // label_Pomiary
            // 
            label_Pomiary.AutoSize = true;
            label_Pomiary.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Pomiary.Location = new Point(232, 523);
            label_Pomiary.Name = "label_Pomiary";
            label_Pomiary.Size = new Size(403, 25);
            label_Pomiary.TabIndex = 9;
            label_Pomiary.Text = "Zarejestrowane pomiary dla wybranej kontroli:";
            // 
            // DGV_Pomiary
            // 
            DGV_Pomiary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Pomiary.Location = new Point(232, 551);
            DGV_Pomiary.Name = "DGV_Pomiary";
            DGV_Pomiary.Size = new Size(876, 222);
            DGV_Pomiary.TabIndex = 10;
            // 
            // label_SortowaniePomiarow
            // 
            label_SortowaniePomiarow.AutoSize = true;
            label_SortowaniePomiarow.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_SortowaniePomiarow.Location = new Point(232, 468);
            label_SortowaniePomiarow.Name = "label_SortowaniePomiarow";
            label_SortowaniePomiarow.Size = new Size(140, 25);
            label_SortowaniePomiarow.TabIndex = 11;
            label_SortowaniePomiarow.Text = "Sortuj pomiary:";
            // 
            // comboBox_SortowaniePomiarow
            // 
            comboBox_SortowaniePomiarow.FormattingEnabled = true;
            comboBox_SortowaniePomiarow.Location = new Point(378, 470);
            comboBox_SortowaniePomiarow.Name = "comboBox_SortowaniePomiarow";
            comboBox_SortowaniePomiarow.Size = new Size(181, 23);
            comboBox_SortowaniePomiarow.TabIndex = 12;
            // 
            // label_Tytul
            // 
            label_Tytul.AutoSize = true;
            label_Tytul.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_Tytul.Location = new Point(535, 9);
            label_Tytul.Name = "label_Tytul";
            label_Tytul.Size = new Size(329, 25);
            label_Tytul.TabIndex = 13;
            label_Tytul.Text = "Raport z przeprowadzonychh kontroli";
            // 
            // Form_RaportKontrola
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1322, 1007);
            Controls.Add(label_Tytul);
            Controls.Add(comboBox_SortowaniePomiarow);
            Controls.Add(label_SortowaniePomiarow);
            Controls.Add(DGV_Pomiary);
            Controls.Add(label_Pomiary);
            Controls.Add(DGV_Kontrole);
            Controls.Add(label_ListaKontroli);
            Controls.Add(btn_WyczyscFiltry);
            Controls.Add(comboBox_Sortowanie);
            Controls.Add(label_Sortowanie);
            Controls.Add(comboBox_FiltrPracownik);
            Controls.Add(label_FiltrPracownik);
            Controls.Add(btn_WidokMaterialy);
            Controls.Add(btn_WidokProdukty);
            Name = "Form_RaportKontrola";
            Text = "Form_RaportKontrola";
            ((System.ComponentModel.ISupportInitialize)DGV_Kontrole).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_Pomiary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_WidokProdukty;
        private Button btn_WidokMaterialy;
        private Label label_FiltrPracownik;
        private ComboBox comboBox_FiltrPracownik;
        private Label label_Sortowanie;
        private ComboBox comboBox_Sortowanie;
        private Button btn_WyczyscFiltry;
        private Label label_ListaKontroli;
        private DataGridView DGV_Kontrole;
        private Label label_Pomiary;
        private DataGridView DGV_Pomiary;
        private Label label_SortowaniePomiarow;
        private ComboBox comboBox_SortowaniePomiarow;
        private Label label_Tytul;
    }
}