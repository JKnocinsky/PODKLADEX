namespace PodkladexApp
{
    partial class Form_KontrolaMat
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
            comboBox_KontMatPrac = new ComboBox();
            textBox_KontMatRBH = new TextBox();
            label_KontMatPrac = new Label();
            label_KontMatRBH = new Label();
            label_KontMatZat = new Label();
            label_KontMatOdpady = new Label();
            label_KontMatZadP = new Label();
            label_KontMatMateral = new Label();
            comboBox_KontMatMaterial = new ComboBox();
            comboBox_KontMatZadP = new ComboBox();
            textBox_KontMatOdpady = new TextBox();
            btn_DodajKontMat = new Button();
            btn_EdytujKontMat = new Button();
            btn_KontMatPotwierdz = new Button();
            checkBox_KontrolaMatZat = new CheckBox();
            DGV_KontMatKontrole = new DataGridView();
            btn_KontMatPomiar = new Button();
            DGV_PomiaryMat = new DataGridView();
            panel_DodawaniePomiaru = new Panel();
            btn_UsunPomiar = new Button();
            btn_EdytujPomiar = new Button();
            btn_ZakonczKontrole = new Button();
            btn_PomiarMatDodaj = new Button();
            textBox_PomiarMatWartosc = new TextBox();
            comboBox_PomiarMatWlasc = new ComboBox();
            label_PomiarMatWartosc = new Label();
            label_PomiarMatWlasc = new Label();
            label_ListaKontroli = new Label();
            btn_Edytuj = new Button();
            btn_Anuluj = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_KontMatKontrole).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_PomiaryMat).BeginInit();
            panel_DodawaniePomiaru.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox_KontMatPrac
            // 
            comboBox_KontMatPrac.FormattingEnabled = true;
            comboBox_KontMatPrac.Location = new Point(526, 207);
            comboBox_KontMatPrac.Name = "comboBox_KontMatPrac";
            comboBox_KontMatPrac.Size = new Size(371, 23);
            comboBox_KontMatPrac.TabIndex = 0;
            // 
            // textBox_KontMatRBH
            // 
            textBox_KontMatRBH.Location = new Point(422, 310);
            textBox_KontMatRBH.Name = "textBox_KontMatRBH";
            textBox_KontMatRBH.Size = new Size(100, 23);
            textBox_KontMatRBH.TabIndex = 1;
            // 
            // label_KontMatPrac
            // 
            label_KontMatPrac.AutoSize = true;
            label_KontMatPrac.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontMatPrac.Location = new Point(276, 207);
            label_KontMatPrac.Name = "label_KontMatPrac";
            label_KontMatPrac.Size = new Size(99, 25);
            label_KontMatPrac.TabIndex = 2;
            label_KontMatPrac.Text = "Pracownik";
            // 
            // label_KontMatRBH
            // 
            label_KontMatRBH.AutoSize = true;
            label_KontMatRBH.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontMatRBH.Location = new Point(369, 309);
            label_KontMatRBH.Name = "label_KontMatRBH";
            label_KontMatRBH.Size = new Size(47, 25);
            label_KontMatRBH.TabIndex = 3;
            label_KontMatRBH.Text = "RBH";
            // 
            // label_KontMatZat
            // 
            label_KontMatZat.AutoSize = true;
            label_KontMatZat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontMatZat.Location = new Point(596, 309);
            label_KontMatZat.Name = "label_KontMatZat";
            label_KontMatZat.Size = new Size(127, 25);
            label_KontMatZat.TabIndex = 4;
            label_KontMatZat.Text = "Zatwierdzone";
            // 
            // label_KontMatOdpady
            // 
            label_KontMatOdpady.AutoSize = true;
            label_KontMatOdpady.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontMatOdpady.Location = new Point(116, 309);
            label_KontMatOdpady.Name = "label_KontMatOdpady";
            label_KontMatOdpady.Size = new Size(78, 25);
            label_KontMatOdpady.TabIndex = 5;
            label_KontMatOdpady.Text = "Odpady";
            // 
            // label_KontMatZadP
            // 
            label_KontMatZadP.AutoSize = true;
            label_KontMatZadP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontMatZadP.Location = new Point(276, 255);
            label_KontMatZadP.Name = "label_KontMatZadP";
            label_KontMatZadP.Size = new Size(189, 25);
            label_KontMatZadP.TabIndex = 6;
            label_KontMatZadP.Text = "Zadanie produkcyjne";
            // 
            // label_KontMatMateral
            // 
            label_KontMatMateral.AutoSize = true;
            label_KontMatMateral.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontMatMateral.Location = new Point(280, 303);
            label_KontMatMateral.Name = "label_KontMatMateral";
            label_KontMatMateral.Size = new Size(82, 25);
            label_KontMatMateral.TabIndex = 7;
            label_KontMatMateral.Text = "Materiał";
            // 
            // comboBox_KontMatMaterial
            // 
            comboBox_KontMatMaterial.FormattingEnabled = true;
            comboBox_KontMatMaterial.Location = new Point(526, 303);
            comboBox_KontMatMaterial.Name = "comboBox_KontMatMaterial";
            comboBox_KontMatMaterial.Size = new Size(371, 23);
            comboBox_KontMatMaterial.TabIndex = 8;
            // 
            // comboBox_KontMatZadP
            // 
            comboBox_KontMatZadP.FormattingEnabled = true;
            comboBox_KontMatZadP.Location = new Point(526, 255);
            comboBox_KontMatZadP.Name = "comboBox_KontMatZadP";
            comboBox_KontMatZadP.Size = new Size(371, 23);
            comboBox_KontMatZadP.TabIndex = 9;
            // 
            // textBox_KontMatOdpady
            // 
            textBox_KontMatOdpady.Location = new Point(200, 310);
            textBox_KontMatOdpady.Name = "textBox_KontMatOdpady";
            textBox_KontMatOdpady.Size = new Size(100, 23);
            textBox_KontMatOdpady.TabIndex = 10;
            // 
            // btn_DodajKontMat
            // 
            btn_DodajKontMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_DodajKontMat.Location = new Point(24, 21);
            btn_DodajKontMat.Name = "btn_DodajKontMat";
            btn_DodajKontMat.Size = new Size(172, 57);
            btn_DodajKontMat.TabIndex = 11;
            btn_DodajKontMat.Text = "Dodaj kontrole";
            btn_DodajKontMat.UseVisualStyleBackColor = true;
            // 
            // btn_EdytujKontMat
            // 
            btn_EdytujKontMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_EdytujKontMat.Location = new Point(24, 103);
            btn_EdytujKontMat.Name = "btn_EdytujKontMat";
            btn_EdytujKontMat.Size = new Size(172, 57);
            btn_EdytujKontMat.TabIndex = 12;
            btn_EdytujKontMat.Text = "Edytuj kontrole";
            btn_EdytujKontMat.UseVisualStyleBackColor = true;
            // 
            // btn_KontMatPotwierdz
            // 
            btn_KontMatPotwierdz.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontMatPotwierdz.Location = new Point(256, 337);
            btn_KontMatPotwierdz.Margin = new Padding(3, 2, 3, 2);
            btn_KontMatPotwierdz.Name = "btn_KontMatPotwierdz";
            btn_KontMatPotwierdz.Size = new Size(172, 57);
            btn_KontMatPotwierdz.TabIndex = 17;
            btn_KontMatPotwierdz.Text = "Potwierdź";
            btn_KontMatPotwierdz.UseVisualStyleBackColor = true;
            // 
            // checkBox_KontrolaMatZat
            // 
            checkBox_KontrolaMatZat.AutoSize = true;
            checkBox_KontrolaMatZat.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            checkBox_KontrolaMatZat.Location = new Point(729, 314);
            checkBox_KontrolaMatZat.Margin = new Padding(3, 2, 3, 2);
            checkBox_KontrolaMatZat.Name = "checkBox_KontrolaMatZat";
            checkBox_KontrolaMatZat.Size = new Size(15, 14);
            checkBox_KontrolaMatZat.TabIndex = 18;
            checkBox_KontrolaMatZat.UseVisualStyleBackColor = true;
            // 
            // DGV_KontMatKontrole
            // 
            DGV_KontMatKontrole.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_KontMatKontrole.Location = new Point(239, 72);
            DGV_KontMatKontrole.Name = "DGV_KontMatKontrole";
            DGV_KontMatKontrole.Size = new Size(754, 120);
            DGV_KontMatKontrole.TabIndex = 19;
            // 
            // btn_KontMatPomiar
            // 
            btn_KontMatPomiar.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontMatPomiar.Location = new Point(487, 337);
            btn_KontMatPomiar.Name = "btn_KontMatPomiar";
            btn_KontMatPomiar.Size = new Size(172, 57);
            btn_KontMatPomiar.TabIndex = 20;
            btn_KontMatPomiar.Text = "Pomiary";
            btn_KontMatPomiar.UseVisualStyleBackColor = true;
            // 
            // DGV_PomiaryMat
            // 
            DGV_PomiaryMat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_PomiaryMat.Location = new Point(44, 133);
            DGV_PomiaryMat.Name = "DGV_PomiaryMat";
            DGV_PomiaryMat.Size = new Size(754, 150);
            DGV_PomiaryMat.TabIndex = 21;
            // 
            // panel_DodawaniePomiaru
            // 
            panel_DodawaniePomiaru.Controls.Add(btn_UsunPomiar);
            panel_DodawaniePomiaru.Controls.Add(btn_EdytujPomiar);
            panel_DodawaniePomiaru.Controls.Add(btn_ZakonczKontrole);
            panel_DodawaniePomiaru.Controls.Add(btn_PomiarMatDodaj);
            panel_DodawaniePomiaru.Controls.Add(textBox_PomiarMatWartosc);
            panel_DodawaniePomiaru.Controls.Add(comboBox_PomiarMatWlasc);
            panel_DodawaniePomiaru.Controls.Add(label_PomiarMatWartosc);
            panel_DodawaniePomiaru.Controls.Add(label_PomiarMatWlasc);
            panel_DodawaniePomiaru.Controls.Add(DGV_PomiaryMat);
            panel_DodawaniePomiaru.Controls.Add(textBox_KontMatRBH);
            panel_DodawaniePomiaru.Controls.Add(label_KontMatRBH);
            panel_DodawaniePomiaru.Controls.Add(label_KontMatZat);
            panel_DodawaniePomiaru.Controls.Add(checkBox_KontrolaMatZat);
            panel_DodawaniePomiaru.Controls.Add(label_KontMatOdpady);
            panel_DodawaniePomiaru.Controls.Add(textBox_KontMatOdpady);
            panel_DodawaniePomiaru.Location = new Point(195, 400);
            panel_DodawaniePomiaru.Name = "panel_DodawaniePomiaru";
            panel_DodawaniePomiaru.Size = new Size(854, 436);
            panel_DodawaniePomiaru.TabIndex = 22;
            // 
            // btn_UsunPomiar
            // 
            btn_UsunPomiar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_UsunPomiar.Location = new Point(332, 60);
            btn_UsunPomiar.Margin = new Padding(3, 2, 3, 2);
            btn_UsunPomiar.Name = "btn_UsunPomiar";
            btn_UsunPomiar.Size = new Size(172, 57);
            btn_UsunPomiar.TabIndex = 28;
            btn_UsunPomiar.Text = "Usuń pomiar";
            btn_UsunPomiar.UseVisualStyleBackColor = true;
            // 
            // btn_EdytujPomiar
            // 
            btn_EdytujPomiar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_EdytujPomiar.Location = new Point(551, 60);
            btn_EdytujPomiar.Margin = new Padding(3, 2, 3, 2);
            btn_EdytujPomiar.Name = "btn_EdytujPomiar";
            btn_EdytujPomiar.Size = new Size(172, 57);
            btn_EdytujPomiar.TabIndex = 27;
            btn_EdytujPomiar.Text = "Edytuj pomiar";
            btn_EdytujPomiar.UseVisualStyleBackColor = true;
            // 
            // btn_ZakonczKontrole
            // 
            btn_ZakonczKontrole.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_ZakonczKontrole.Location = new Point(331, 365);
            btn_ZakonczKontrole.Margin = new Padding(3, 2, 3, 2);
            btn_ZakonczKontrole.Name = "btn_ZakonczKontrole";
            btn_ZakonczKontrole.Size = new Size(172, 57);
            btn_ZakonczKontrole.TabIndex = 26;
            btn_ZakonczKontrole.Text = "Zapisz i zamknij";
            btn_ZakonczKontrole.UseVisualStyleBackColor = true;
            // 
            // btn_PomiarMatDodaj
            // 
            btn_PomiarMatDodaj.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarMatDodaj.Location = new Point(113, 60);
            btn_PomiarMatDodaj.Margin = new Padding(3, 2, 3, 2);
            btn_PomiarMatDodaj.Name = "btn_PomiarMatDodaj";
            btn_PomiarMatDodaj.Size = new Size(172, 57);
            btn_PomiarMatDodaj.TabIndex = 24;
            btn_PomiarMatDodaj.Text = "Zatwierdź pomiar";
            btn_PomiarMatDodaj.UseVisualStyleBackColor = true;
            // 
            // textBox_PomiarMatWartosc
            // 
            textBox_PomiarMatWartosc.Location = new Point(630, 18);
            textBox_PomiarMatWartosc.Margin = new Padding(3, 2, 3, 2);
            textBox_PomiarMatWartosc.Name = "textBox_PomiarMatWartosc";
            textBox_PomiarMatWartosc.Size = new Size(110, 23);
            textBox_PomiarMatWartosc.TabIndex = 25;
            // 
            // comboBox_PomiarMatWlasc
            // 
            comboBox_PomiarMatWlasc.FormattingEnabled = true;
            comboBox_PomiarMatWlasc.Location = new Point(186, 18);
            comboBox_PomiarMatWlasc.Margin = new Padding(3, 2, 3, 2);
            comboBox_PomiarMatWlasc.Name = "comboBox_PomiarMatWlasc";
            comboBox_PomiarMatWlasc.Size = new Size(178, 23);
            comboBox_PomiarMatWlasc.TabIndex = 24;
            // 
            // label_PomiarMatWartosc
            // 
            label_PomiarMatWartosc.AutoSize = true;
            label_PomiarMatWartosc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarMatWartosc.Location = new Point(449, 18);
            label_PomiarMatWartosc.Name = "label_PomiarMatWartosc";
            label_PomiarMatWartosc.Size = new Size(173, 25);
            label_PomiarMatWartosc.TabIndex = 23;
            label_PomiarMatWartosc.Text = "Wartość zmierzona";
            // 
            // label_PomiarMatWlasc
            // 
            label_PomiarMatWlasc.AutoSize = true;
            label_PomiarMatWlasc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarMatWlasc.Location = new Point(61, 18);
            label_PomiarMatWlasc.Name = "label_PomiarMatWlasc";
            label_PomiarMatWlasc.Size = new Size(109, 25);
            label_PomiarMatWlasc.TabIndex = 22;
            label_PomiarMatWlasc.Text = "Właściwość";
            // 
            // label_ListaKontroli
            // 
            label_ListaKontroli.AutoSize = true;
            label_ListaKontroli.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_ListaKontroli.Location = new Point(239, 37);
            label_ListaKontroli.Name = "label_ListaKontroli";
            label_ListaKontroli.Size = new Size(228, 25);
            label_ListaKontroli.TabIndex = 23;
            label_ListaKontroli.Text = "Lista kontroli materiałów: ";
            // 
            // btn_Edytuj
            // 
            btn_Edytuj.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Edytuj.Location = new Point(802, 9);
            btn_Edytuj.Name = "btn_Edytuj";
            btn_Edytuj.Size = new Size(172, 57);
            btn_Edytuj.TabIndex = 24;
            btn_Edytuj.Text = "Edytuj dane";
            btn_Edytuj.UseVisualStyleBackColor = true;
            // 
            // btn_Anuluj
            // 
            btn_Anuluj.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Anuluj.Location = new Point(24, 185);
            btn_Anuluj.Name = "btn_Anuluj";
            btn_Anuluj.Size = new Size(172, 57);
            btn_Anuluj.TabIndex = 25;
            btn_Anuluj.Text = "Anuluj";
            btn_Anuluj.UseVisualStyleBackColor = true;
            // 
            // Form_KontrolaMat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1289, 1061);
            Controls.Add(btn_Anuluj);
            Controls.Add(btn_Edytuj);
            Controls.Add(label_ListaKontroli);
            Controls.Add(panel_DodawaniePomiaru);
            Controls.Add(btn_KontMatPomiar);
            Controls.Add(DGV_KontMatKontrole);
            Controls.Add(btn_KontMatPotwierdz);
            Controls.Add(btn_EdytujKontMat);
            Controls.Add(btn_DodajKontMat);
            Controls.Add(comboBox_KontMatZadP);
            Controls.Add(comboBox_KontMatMaterial);
            Controls.Add(label_KontMatMateral);
            Controls.Add(label_KontMatZadP);
            Controls.Add(label_KontMatPrac);
            Controls.Add(comboBox_KontMatPrac);
            Name = "Form_KontrolaMat";
            Text = "Form_KontrolaMat";
            ((System.ComponentModel.ISupportInitialize)DGV_KontMatKontrole).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_PomiaryMat).EndInit();
            panel_DodawaniePomiaru.ResumeLayout(false);
            panel_DodawaniePomiaru.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_KontMatPrac;
        private TextBox textBox_KontMatRBH;
        private Label label_KontMatPrac;
        private Label label_KontMatRBH;
        private Label label_KontMatZat;
        private Label label_KontMatOdpady;
        private Label label_KontMatZadP;
        private Label label_KontMatMateral;
        private ComboBox comboBox_KontMatMaterial;
        private ComboBox comboBox_KontMatZadP;
        private TextBox textBox_KontMatOdpady;
        private Button btn_DodajKontMat;
        private Button btn_EdytujKontMat;
        private Label label_KontMatKontrola;
        private Button btn_KontMatPotwierdz;
        private CheckBox checkBox_KontrolaMatZat;
        private DataGridView DGV_KontMatKontrole;
        private Button btn_KontMatPomiar;
        private DataGridView DGV_PomiaryMat;
        private Panel panel_DodawaniePomiaru;
        private Label label_ListaKontroli;
        private TextBox textBox_PomiarMatWartosc;
        private ComboBox comboBox_PomiarMatWlasc;
        private Label label_PomiarMatWartosc;
        private Label label_PomiarMatWlasc;
        private Button btn_ZakonczKontrole;
        private Button btn_PomiarMatDodaj;
        private Button btn_Edytuj;
        private Button btn_Anuluj;
        private Button btn_EdytujPomiar;
        private Button btn_UsunPomiar;
    }
}