namespace PodkladexApp
{
    partial class Form_KontrolaProd
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
            btn_Anuluj = new Button();
            btn_Edytuj = new Button();
            label_ListaKontroli = new Label();
            panel_DodawaniePomiaru = new Panel();
            btn_UsunPomiar = new Button();
            btn_EdytujPomiar = new Button();
            btn_ZakonczKontrole = new Button();
            btn_PomiarProdDodaj = new Button();
            textBox_PomiarProdWartosc = new TextBox();
            comboBox_PomiarProdWlasc = new ComboBox();
            label_PomiarProdWartosc = new Label();
            label_PomiarProdWlasc = new Label();
            DGV_PomiaryProd = new DataGridView();
            textBox_KontProdRBH = new TextBox();
            label_KontProdRBH = new Label();
            label_KontProdZat = new Label();
            checkBox_KontrolaProdZat = new CheckBox();
            label_KontProdOdpady = new Label();
            textBox_KontProdOdpady = new TextBox();
            btn_KontProdPomiar = new Button();
            DGV_KontProdKontrole = new DataGridView();
            btn_KontProdPotwierdz = new Button();
            btn_EdytujKontProd = new Button();
            btn_DodajKontProd = new Button();
            comboBox_KontProdZadP = new ComboBox();
            label_KontProdZadP = new Label();
            label_KontProdPrac = new Label();
            comboBox_KontProdPrac = new ComboBox();
            panel_DodawaniePomiaru.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_PomiaryProd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGV_KontProdKontrole).BeginInit();
            SuspendLayout();
            // 
            // btn_Anuluj
            // 
            btn_Anuluj.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Anuluj.Location = new Point(12, 187);
            btn_Anuluj.Name = "btn_Anuluj";
            btn_Anuluj.Size = new Size(172, 57);
            btn_Anuluj.TabIndex = 40;
            btn_Anuluj.Text = "Anuluj";
            btn_Anuluj.UseVisualStyleBackColor = true;
            // 
            // btn_Edytuj
            // 
            btn_Edytuj.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Edytuj.Location = new Point(790, 11);
            btn_Edytuj.Name = "btn_Edytuj";
            btn_Edytuj.Size = new Size(172, 57);
            btn_Edytuj.TabIndex = 39;
            btn_Edytuj.Text = "Edytuj dane";
            btn_Edytuj.UseVisualStyleBackColor = true;
            // 
            // label_ListaKontroli
            // 
            label_ListaKontroli.AutoSize = true;
            label_ListaKontroli.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_ListaKontroli.Location = new Point(227, 39);
            label_ListaKontroli.Name = "label_ListaKontroli";
            label_ListaKontroli.Size = new Size(225, 25);
            label_ListaKontroli.TabIndex = 38;
            label_ListaKontroli.Text = "Lista kontroli produktów: ";
            // 
            // panel_DodawaniePomiaru
            // 
            panel_DodawaniePomiaru.Controls.Add(btn_UsunPomiar);
            panel_DodawaniePomiaru.Controls.Add(btn_EdytujPomiar);
            panel_DodawaniePomiaru.Controls.Add(btn_ZakonczKontrole);
            panel_DodawaniePomiaru.Controls.Add(btn_PomiarProdDodaj);
            panel_DodawaniePomiaru.Controls.Add(textBox_PomiarProdWartosc);
            panel_DodawaniePomiaru.Controls.Add(comboBox_PomiarProdWlasc);
            panel_DodawaniePomiaru.Controls.Add(label_PomiarProdWartosc);
            panel_DodawaniePomiaru.Controls.Add(label_PomiarProdWlasc);
            panel_DodawaniePomiaru.Controls.Add(DGV_PomiaryProd);
            panel_DodawaniePomiaru.Controls.Add(textBox_KontProdRBH);
            panel_DodawaniePomiaru.Controls.Add(label_KontProdRBH);
            panel_DodawaniePomiaru.Controls.Add(label_KontProdZat);
            panel_DodawaniePomiaru.Controls.Add(checkBox_KontrolaProdZat);
            panel_DodawaniePomiaru.Controls.Add(label_KontProdOdpady);
            panel_DodawaniePomiaru.Controls.Add(textBox_KontProdOdpady);
            panel_DodawaniePomiaru.Location = new Point(183, 402);
            panel_DodawaniePomiaru.Name = "panel_DodawaniePomiaru";
            panel_DodawaniePomiaru.Size = new Size(854, 436);
            panel_DodawaniePomiaru.TabIndex = 37;
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
            // btn_PomiarProdDodaj
            // 
            btn_PomiarProdDodaj.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarProdDodaj.Location = new Point(113, 60);
            btn_PomiarProdDodaj.Margin = new Padding(3, 2, 3, 2);
            btn_PomiarProdDodaj.Name = "btn_PomiarProdDodaj";
            btn_PomiarProdDodaj.Size = new Size(172, 57);
            btn_PomiarProdDodaj.TabIndex = 24;
            btn_PomiarProdDodaj.Text = "Zatwierdź pomiar";
            btn_PomiarProdDodaj.UseVisualStyleBackColor = true;
            // 
            // textBox_PomiarProdWartosc
            // 
            textBox_PomiarProdWartosc.Location = new Point(630, 18);
            textBox_PomiarProdWartosc.Margin = new Padding(3, 2, 3, 2);
            textBox_PomiarProdWartosc.Name = "textBox_PomiarProdWartosc";
            textBox_PomiarProdWartosc.Size = new Size(110, 23);
            textBox_PomiarProdWartosc.TabIndex = 25;
            // 
            // comboBox_PomiarProdWlasc
            // 
            comboBox_PomiarProdWlasc.FormattingEnabled = true;
            comboBox_PomiarProdWlasc.Location = new Point(186, 18);
            comboBox_PomiarProdWlasc.Margin = new Padding(3, 2, 3, 2);
            comboBox_PomiarProdWlasc.Name = "comboBox_PomiarProdWlasc";
            comboBox_PomiarProdWlasc.Size = new Size(178, 23);
            comboBox_PomiarProdWlasc.TabIndex = 24;
            // 
            // label_PomiarProdWartosc
            // 
            label_PomiarProdWartosc.AutoSize = true;
            label_PomiarProdWartosc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarProdWartosc.Location = new Point(449, 18);
            label_PomiarProdWartosc.Name = "label_PomiarProdWartosc";
            label_PomiarProdWartosc.Size = new Size(173, 25);
            label_PomiarProdWartosc.TabIndex = 23;
            label_PomiarProdWartosc.Text = "Wartość zmierzona";
            // 
            // label_PomiarProdWlasc
            // 
            label_PomiarProdWlasc.AutoSize = true;
            label_PomiarProdWlasc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarProdWlasc.Location = new Point(61, 18);
            label_PomiarProdWlasc.Name = "label_PomiarProdWlasc";
            label_PomiarProdWlasc.Size = new Size(109, 25);
            label_PomiarProdWlasc.TabIndex = 22;
            label_PomiarProdWlasc.Text = "Właściwość";
            // 
            // DGV_PomiaryProd
            // 
            DGV_PomiaryProd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_PomiaryProd.Location = new Point(44, 133);
            DGV_PomiaryProd.Name = "DGV_PomiaryProd";
            DGV_PomiaryProd.Size = new Size(754, 150);
            DGV_PomiaryProd.TabIndex = 21;
            // 
            // textBox_KontProdRBH
            // 
            textBox_KontProdRBH.Location = new Point(422, 310);
            textBox_KontProdRBH.Name = "textBox_KontProdRBH";
            textBox_KontProdRBH.Size = new Size(100, 23);
            textBox_KontProdRBH.TabIndex = 1;
            // 
            // label_KontProdRBH
            // 
            label_KontProdRBH.AutoSize = true;
            label_KontProdRBH.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontProdRBH.Location = new Point(369, 309);
            label_KontProdRBH.Name = "label_KontProdRBH";
            label_KontProdRBH.Size = new Size(47, 25);
            label_KontProdRBH.TabIndex = 3;
            label_KontProdRBH.Text = "RBH";
            // 
            // label_KontProdZat
            // 
            label_KontProdZat.AutoSize = true;
            label_KontProdZat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontProdZat.Location = new Point(596, 309);
            label_KontProdZat.Name = "label_KontProdZat";
            label_KontProdZat.Size = new Size(127, 25);
            label_KontProdZat.TabIndex = 4;
            label_KontProdZat.Text = "Zatwierdzone";
            // 
            // checkBox_KontrolaProdZat
            // 
            checkBox_KontrolaProdZat.AutoSize = true;
            checkBox_KontrolaProdZat.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            checkBox_KontrolaProdZat.Location = new Point(729, 314);
            checkBox_KontrolaProdZat.Margin = new Padding(3, 2, 3, 2);
            checkBox_KontrolaProdZat.Name = "checkBox_KontrolaProdZat";
            checkBox_KontrolaProdZat.Size = new Size(15, 14);
            checkBox_KontrolaProdZat.TabIndex = 18;
            checkBox_KontrolaProdZat.UseVisualStyleBackColor = true;
            // 
            // label_KontProdOdpady
            // 
            label_KontProdOdpady.AutoSize = true;
            label_KontProdOdpady.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontProdOdpady.Location = new Point(116, 309);
            label_KontProdOdpady.Name = "label_KontProdOdpady";
            label_KontProdOdpady.Size = new Size(78, 25);
            label_KontProdOdpady.TabIndex = 5;
            label_KontProdOdpady.Text = "Odpady";
            // 
            // textBox_KontProdOdpady
            // 
            textBox_KontProdOdpady.Location = new Point(200, 310);
            textBox_KontProdOdpady.Name = "textBox_KontProdOdpady";
            textBox_KontProdOdpady.Size = new Size(100, 23);
            textBox_KontProdOdpady.TabIndex = 10;
            // 
            // btn_KontProdPomiar
            // 
            btn_KontProdPomiar.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontProdPomiar.Location = new Point(471, 316);
            btn_KontProdPomiar.Name = "btn_KontProdPomiar";
            btn_KontProdPomiar.Size = new Size(172, 57);
            btn_KontProdPomiar.TabIndex = 36;
            btn_KontProdPomiar.Text = "Pomiary";
            btn_KontProdPomiar.UseVisualStyleBackColor = true;
            // 
            // DGV_KontProdKontrole
            // 
            DGV_KontProdKontrole.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_KontProdKontrole.Location = new Point(227, 74);
            DGV_KontProdKontrole.Name = "DGV_KontProdKontrole";
            DGV_KontProdKontrole.Size = new Size(754, 120);
            DGV_KontProdKontrole.TabIndex = 35;
            // 
            // btn_KontProdPotwierdz
            // 
            btn_KontProdPotwierdz.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontProdPotwierdz.Location = new Point(244, 316);
            btn_KontProdPotwierdz.Margin = new Padding(3, 2, 3, 2);
            btn_KontProdPotwierdz.Name = "btn_KontProdPotwierdz";
            btn_KontProdPotwierdz.Size = new Size(172, 57);
            btn_KontProdPotwierdz.TabIndex = 34;
            btn_KontProdPotwierdz.Text = "Potwierdź";
            btn_KontProdPotwierdz.UseVisualStyleBackColor = true;
            // 
            // btn_EdytujKontProd
            // 
            btn_EdytujKontProd.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_EdytujKontProd.Location = new Point(12, 105);
            btn_EdytujKontProd.Name = "btn_EdytujKontProd";
            btn_EdytujKontProd.Size = new Size(172, 57);
            btn_EdytujKontProd.TabIndex = 33;
            btn_EdytujKontProd.Text = "Edytuj kontrole";
            btn_EdytujKontProd.UseVisualStyleBackColor = true;
            // 
            // btn_DodajKontProd
            // 
            btn_DodajKontProd.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_DodajKontProd.Location = new Point(12, 23);
            btn_DodajKontProd.Name = "btn_DodajKontProd";
            btn_DodajKontProd.Size = new Size(172, 57);
            btn_DodajKontProd.TabIndex = 32;
            btn_DodajKontProd.Text = "Dodaj kontrole";
            btn_DodajKontProd.UseVisualStyleBackColor = true;
            // 
            // comboBox_KontProdZadP
            // 
            comboBox_KontProdZadP.FormattingEnabled = true;
            comboBox_KontProdZadP.Location = new Point(514, 257);
            comboBox_KontProdZadP.Name = "comboBox_KontProdZadP";
            comboBox_KontProdZadP.Size = new Size(371, 23);
            comboBox_KontProdZadP.TabIndex = 31;
            // 
            // label_KontProdZadP
            // 
            label_KontProdZadP.AutoSize = true;
            label_KontProdZadP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontProdZadP.Location = new Point(264, 257);
            label_KontProdZadP.Name = "label_KontProdZadP";
            label_KontProdZadP.Size = new Size(189, 25);
            label_KontProdZadP.TabIndex = 28;
            label_KontProdZadP.Text = "Zadanie produkcyjne";
            // 
            // label_KontProdPrac
            // 
            label_KontProdPrac.AutoSize = true;
            label_KontProdPrac.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontProdPrac.Location = new Point(264, 209);
            label_KontProdPrac.Name = "label_KontProdPrac";
            label_KontProdPrac.Size = new Size(99, 25);
            label_KontProdPrac.TabIndex = 27;
            label_KontProdPrac.Text = "Pracownik";
            // 
            // comboBox_KontProdPrac
            // 
            comboBox_KontProdPrac.FormattingEnabled = true;
            comboBox_KontProdPrac.Location = new Point(514, 209);
            comboBox_KontProdPrac.Name = "comboBox_KontProdPrac";
            comboBox_KontProdPrac.Size = new Size(371, 23);
            comboBox_KontProdPrac.TabIndex = 26;
            // 
            // Form_KontrolaProd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 1059);
            Controls.Add(btn_Anuluj);
            Controls.Add(btn_Edytuj);
            Controls.Add(label_ListaKontroli);
            Controls.Add(panel_DodawaniePomiaru);
            Controls.Add(btn_KontProdPomiar);
            Controls.Add(DGV_KontProdKontrole);
            Controls.Add(btn_KontProdPotwierdz);
            Controls.Add(btn_EdytujKontProd);
            Controls.Add(btn_DodajKontProd);
            Controls.Add(comboBox_KontProdZadP);
            Controls.Add(label_KontProdZadP);
            Controls.Add(label_KontProdPrac);
            Controls.Add(comboBox_KontProdPrac);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_KontrolaProd";
            Text = "Form_KontProd";
            panel_DodawaniePomiaru.ResumeLayout(false);
            panel_DodawaniePomiaru.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_PomiaryProd).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGV_KontProdKontrole).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Anuluj;
        private Button btn_Edytuj;
        private Label label_ListaKontroli;
        private Panel panel_DodawaniePomiaru;
        private Button btn_UsunPomiar;
        private Button btn_EdytujPomiar;
        private Button btn_ZakonczKontrole;
        private Button btn_PomiarProdDodaj;
        private TextBox textBox_PomiarProdWartosc;
        private ComboBox comboBox_PomiarProdWlasc;
        private Label label_PomiarProdWartosc;
        private Label label_PomiarProdWlasc;
        private DataGridView DGV_PomiaryProd;
        private TextBox textBox_KontProdRBH;
        private Label label_KontProdRBH;
        private Label label_KontProdZat;
        private CheckBox checkBox_KontrolaProdZat;
        private Label label_KontProdOdpady;
        private TextBox textBox_KontProdOdpady;
        private Button btn_KontProdPomiar;
        private DataGridView DGV_KontProdKontrole;
        private Button btn_KontProdPotwierdz;
        private Button btn_EdytujKontProd;
        private Button btn_DodajKontProd;
        private ComboBox comboBox_KontProdZadP;
        private Label label_KontProdZadP;
        private Label label_KontProdPrac;
        private ComboBox comboBox_KontProdPrac;
    }
}