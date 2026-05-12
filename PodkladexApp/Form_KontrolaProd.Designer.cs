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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            btn_Anuluj = new Button();
            btn_Edytuj = new Button();
            label_ListaKontroli = new Label();
            panel_DodawaniePomiaru = new Panel();
            btn_GenerujPomiary = new Button();
            textBox_IloscSztukGeneruj = new TextBox();
            label1 = new Label();
            textBox_OdpadyPomiarySzt = new TextBox();
            textBox_OdpadyWizualneSzt = new TextBox();
            label_OdpadyPomiarySzt = new Label();
            label_OdpadyWizualneSzt = new Label();
            btn_WymusZatwierdzenie = new Button();
            label_PostepInfo = new Label();
            progressBar_Postep = new ProgressBar();
            textBox_KontProdOdpadySzt = new TextBox();
            label_KontProdOdpadySzt = new Label();
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
            panel_DodawaniePomiaru.Controls.Add(btn_GenerujPomiary);
            panel_DodawaniePomiaru.Controls.Add(textBox_IloscSztukGeneruj);
            panel_DodawaniePomiaru.Controls.Add(label1);
            panel_DodawaniePomiaru.Controls.Add(textBox_OdpadyPomiarySzt);
            panel_DodawaniePomiaru.Controls.Add(textBox_OdpadyWizualneSzt);
            panel_DodawaniePomiaru.Controls.Add(label_OdpadyPomiarySzt);
            panel_DodawaniePomiaru.Controls.Add(label_OdpadyWizualneSzt);
            panel_DodawaniePomiaru.Controls.Add(btn_WymusZatwierdzenie);
            panel_DodawaniePomiaru.Controls.Add(label_PostepInfo);
            panel_DodawaniePomiaru.Controls.Add(progressBar_Postep);
            panel_DodawaniePomiaru.Controls.Add(textBox_KontProdOdpadySzt);
            panel_DodawaniePomiaru.Controls.Add(label_KontProdOdpadySzt);
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
            panel_DodawaniePomiaru.Location = new Point(103, 402);
            panel_DodawaniePomiaru.Name = "panel_DodawaniePomiaru";
            panel_DodawaniePomiaru.Size = new Size(1207, 585);
            panel_DodawaniePomiaru.TabIndex = 37;
            // 
            // btn_GenerujPomiary
            // 
            btn_GenerujPomiary.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_GenerujPomiary.Location = new Point(928, 71);
            btn_GenerujPomiary.Margin = new Padding(3, 2, 3, 2);
            btn_GenerujPomiary.Name = "btn_GenerujPomiary";
            btn_GenerujPomiary.Size = new Size(172, 57);
            btn_GenerujPomiary.TabIndex = 40;
            btn_GenerujPomiary.Text = "Generuj Pomiary";
            btn_GenerujPomiary.UseVisualStyleBackColor = true;
            // 
            // textBox_IloscSztukGeneruj
            // 
            textBox_IloscSztukGeneruj.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_IloscSztukGeneruj.Location = new Point(1070, 29);
            textBox_IloscSztukGeneruj.Name = "textBox_IloscSztukGeneruj";
            textBox_IloscSztukGeneruj.Size = new Size(100, 33);
            textBox_IloscSztukGeneruj.TabIndex = 39;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(837, 32);
            label1.Name = "label1";
            label1.Size = new Size(227, 25);
            label1.TabIndex = 38;
            label1.Text = "Liczba sztuk do symulacji:";
            // 
            // textBox_OdpadyPomiarySzt
            // 
            textBox_OdpadyPomiarySzt.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_OdpadyPomiarySzt.Location = new Point(1068, 214);
            textBox_OdpadyPomiarySzt.Name = "textBox_OdpadyPomiarySzt";
            textBox_OdpadyPomiarySzt.ReadOnly = true;
            textBox_OdpadyPomiarySzt.Size = new Size(100, 33);
            textBox_OdpadyPomiarySzt.TabIndex = 37;
            // 
            // textBox_OdpadyWizualneSzt
            // 
            textBox_OdpadyWizualneSzt.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_OdpadyWizualneSzt.Location = new Point(1068, 162);
            textBox_OdpadyWizualneSzt.Name = "textBox_OdpadyWizualneSzt";
            textBox_OdpadyWizualneSzt.Size = new Size(100, 33);
            textBox_OdpadyWizualneSzt.TabIndex = 36;
            // 
            // label_OdpadyPomiarySzt
            // 
            label_OdpadyPomiarySzt.AutoSize = true;
            label_OdpadyPomiarySzt.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_OdpadyPomiarySzt.Location = new Point(910, 217);
            label_OdpadyPomiarySzt.Name = "label_OdpadyPomiarySzt";
            label_OdpadyPomiarySzt.Size = new Size(152, 25);
            label_OdpadyPomiarySzt.TabIndex = 35;
            label_OdpadyPomiarySzt.Text = "Złe pomiary [szt]";
            // 
            // label_OdpadyWizualneSzt
            // 
            label_OdpadyWizualneSzt.AutoSize = true;
            label_OdpadyWizualneSzt.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_OdpadyWizualneSzt.Location = new Point(837, 165);
            label_OdpadyWizualneSzt.Name = "label_OdpadyWizualneSzt";
            label_OdpadyWizualneSzt.Size = new Size(235, 25);
            label_OdpadyWizualneSzt.TabIndex = 34;
            label_OdpadyWizualneSzt.Text = "Braki pozapomiarowe [szt]";
            // 
            // btn_WymusZatwierdzenie
            // 
            btn_WymusZatwierdzenie.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_WymusZatwierdzenie.Location = new Point(339, 359);
            btn_WymusZatwierdzenie.Margin = new Padding(3, 2, 3, 2);
            btn_WymusZatwierdzenie.Name = "btn_WymusZatwierdzenie";
            btn_WymusZatwierdzenie.Size = new Size(228, 64);
            btn_WymusZatwierdzenie.TabIndex = 33;
            btn_WymusZatwierdzenie.Text = "Wymuś wcześniejsze zakończenie";
            btn_WymusZatwierdzenie.UseVisualStyleBackColor = true;
            // 
            // label_PostepInfo
            // 
            label_PostepInfo.AutoSize = true;
            label_PostepInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PostepInfo.Location = new Point(467, 304);
            label_PostepInfo.Name = "label_PostepInfo";
            label_PostepInfo.Size = new Size(63, 25);
            label_PostepInfo.TabIndex = 32;
            label_PostepInfo.Text = "label1";
            // 
            // progressBar_Postep
            // 
            progressBar_Postep.Location = new Point(62, 306);
            progressBar_Postep.Name = "progressBar_Postep";
            progressBar_Postep.Size = new Size(388, 23);
            progressBar_Postep.TabIndex = 31;
            // 
            // textBox_KontProdOdpadySzt
            // 
            textBox_KontProdOdpadySzt.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_KontProdOdpadySzt.Location = new Point(184, 496);
            textBox_KontProdOdpadySzt.Name = "textBox_KontProdOdpadySzt";
            textBox_KontProdOdpadySzt.ReadOnly = true;
            textBox_KontProdOdpadySzt.Size = new Size(100, 33);
            textBox_KontProdOdpadySzt.TabIndex = 30;
            // 
            // label_KontProdOdpadySzt
            // 
            label_KontProdOdpadySzt.AutoSize = true;
            label_KontProdOdpadySzt.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontProdOdpadySzt.Location = new Point(4, 499);
            label_KontProdOdpadySzt.Name = "label_KontProdOdpadySzt";
            label_KontProdOdpadySzt.Size = new Size(177, 25);
            label_KontProdOdpadySzt.TabIndex = 29;
            label_KontProdOdpadySzt.Text = "Odpady łączne [szt]";
            // 
            // btn_UsunPomiar
            // 
            btn_UsunPomiar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_UsunPomiar.Location = new Point(350, 60);
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
            btn_EdytujPomiar.Location = new Point(569, 60);
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
            btn_ZakonczKontrole.Location = new Point(350, 514);
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
            btn_PomiarProdDodaj.Location = new Point(131, 60);
            btn_PomiarProdDodaj.Margin = new Padding(3, 2, 3, 2);
            btn_PomiarProdDodaj.Name = "btn_PomiarProdDodaj";
            btn_PomiarProdDodaj.Size = new Size(172, 57);
            btn_PomiarProdDodaj.TabIndex = 24;
            btn_PomiarProdDodaj.Text = "Zatwierdź pomiar";
            btn_PomiarProdDodaj.UseVisualStyleBackColor = true;
            // 
            // textBox_PomiarProdWartosc
            // 
            textBox_PomiarProdWartosc.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_PomiarProdWartosc.Location = new Point(646, 15);
            textBox_PomiarProdWartosc.Margin = new Padding(3, 2, 3, 2);
            textBox_PomiarProdWartosc.Name = "textBox_PomiarProdWartosc";
            textBox_PomiarProdWartosc.Size = new Size(110, 33);
            textBox_PomiarProdWartosc.TabIndex = 25;
            // 
            // comboBox_PomiarProdWlasc
            // 
            comboBox_PomiarProdWlasc.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_PomiarProdWlasc.FormattingEnabled = true;
            comboBox_PomiarProdWlasc.Location = new Point(204, 15);
            comboBox_PomiarProdWlasc.Margin = new Padding(3, 2, 3, 2);
            comboBox_PomiarProdWlasc.Name = "comboBox_PomiarProdWlasc";
            comboBox_PomiarProdWlasc.Size = new Size(178, 33);
            comboBox_PomiarProdWlasc.TabIndex = 24;
            // 
            // label_PomiarProdWartosc
            // 
            label_PomiarProdWartosc.AutoSize = true;
            label_PomiarProdWartosc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarProdWartosc.Location = new Point(467, 18);
            label_PomiarProdWartosc.Name = "label_PomiarProdWartosc";
            label_PomiarProdWartosc.Size = new Size(173, 25);
            label_PomiarProdWartosc.TabIndex = 23;
            label_PomiarProdWartosc.Text = "Wartość zmierzona";
            // 
            // label_PomiarProdWlasc
            // 
            label_PomiarProdWlasc.AutoSize = true;
            label_PomiarProdWlasc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarProdWlasc.Location = new Point(79, 18);
            label_PomiarProdWlasc.Name = "label_PomiarProdWlasc";
            label_PomiarProdWlasc.Size = new Size(109, 25);
            label_PomiarProdWlasc.TabIndex = 22;
            label_PomiarProdWlasc.Text = "Właściwość";
            // 
            // DGV_PomiaryProd
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGV_PomiaryProd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGV_PomiaryProd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DGV_PomiaryProd.DefaultCellStyle = dataGridViewCellStyle2;
            DGV_PomiaryProd.Location = new Point(62, 133);
            DGV_PomiaryProd.Name = "DGV_PomiaryProd";
            DGV_PomiaryProd.Size = new Size(754, 150);
            DGV_PomiaryProd.TabIndex = 21;
            // 
            // textBox_KontProdRBH
            // 
            textBox_KontProdRBH.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_KontProdRBH.Location = new Point(441, 455);
            textBox_KontProdRBH.Name = "textBox_KontProdRBH";
            textBox_KontProdRBH.Size = new Size(100, 33);
            textBox_KontProdRBH.TabIndex = 1;
            // 
            // label_KontProdRBH
            // 
            label_KontProdRBH.AutoSize = true;
            label_KontProdRBH.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontProdRBH.Location = new Point(388, 458);
            label_KontProdRBH.Name = "label_KontProdRBH";
            label_KontProdRBH.Size = new Size(47, 25);
            label_KontProdRBH.TabIndex = 3;
            label_KontProdRBH.Text = "RBH";
            // 
            // label_KontProdZat
            // 
            label_KontProdZat.AutoSize = true;
            label_KontProdZat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontProdZat.Location = new Point(615, 458);
            label_KontProdZat.Name = "label_KontProdZat";
            label_KontProdZat.Size = new Size(127, 25);
            label_KontProdZat.TabIndex = 4;
            label_KontProdZat.Text = "Zatwierdzone";
            // 
            // checkBox_KontrolaProdZat
            // 
            checkBox_KontrolaProdZat.AutoSize = true;
            checkBox_KontrolaProdZat.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            checkBox_KontrolaProdZat.Location = new Point(748, 463);
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
            label_KontProdOdpady.Location = new Point(4, 457);
            label_KontProdOdpady.Name = "label_KontProdOdpady";
            label_KontProdOdpady.Size = new Size(174, 25);
            label_KontProdOdpady.TabIndex = 5;
            label_KontProdOdpady.Text = "Odpady łączne [kg]";
            // 
            // textBox_KontProdOdpady
            // 
            textBox_KontProdOdpady.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_KontProdOdpady.Location = new Point(184, 454);
            textBox_KontProdOdpady.Name = "textBox_KontProdOdpady";
            textBox_KontProdOdpady.ReadOnly = true;
            textBox_KontProdOdpady.Size = new Size(100, 33);
            textBox_KontProdOdpady.TabIndex = 10;
            // 
            // btn_KontProdPomiar
            // 
            btn_KontProdPomiar.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontProdPomiar.Location = new Point(471, 334);
            btn_KontProdPomiar.Name = "btn_KontProdPomiar";
            btn_KontProdPomiar.Size = new Size(172, 57);
            btn_KontProdPomiar.TabIndex = 36;
            btn_KontProdPomiar.Text = "Pomiary";
            btn_KontProdPomiar.UseVisualStyleBackColor = true;
            // 
            // DGV_KontProdKontrole
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DGV_KontProdKontrole.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DGV_KontProdKontrole.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            DGV_KontProdKontrole.DefaultCellStyle = dataGridViewCellStyle4;
            DGV_KontProdKontrole.Location = new Point(227, 74);
            DGV_KontProdKontrole.Name = "DGV_KontProdKontrole";
            DGV_KontProdKontrole.Size = new Size(754, 139);
            DGV_KontProdKontrole.TabIndex = 35;
            // 
            // btn_KontProdPotwierdz
            // 
            btn_KontProdPotwierdz.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontProdPotwierdz.Location = new Point(244, 334);
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
            comboBox_KontProdZadP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_KontProdZadP.FormattingEnabled = true;
            comboBox_KontProdZadP.Location = new Point(514, 267);
            comboBox_KontProdZadP.Name = "comboBox_KontProdZadP";
            comboBox_KontProdZadP.Size = new Size(371, 33);
            comboBox_KontProdZadP.TabIndex = 31;
            // 
            // label_KontProdZadP
            // 
            label_KontProdZadP.AutoSize = true;
            label_KontProdZadP.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontProdZadP.Location = new Point(264, 275);
            label_KontProdZadP.Name = "label_KontProdZadP";
            label_KontProdZadP.Size = new Size(189, 25);
            label_KontProdZadP.TabIndex = 28;
            label_KontProdZadP.Text = "Zadanie produkcyjne";
            // 
            // label_KontProdPrac
            // 
            label_KontProdPrac.AutoSize = true;
            label_KontProdPrac.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_KontProdPrac.Location = new Point(264, 227);
            label_KontProdPrac.Name = "label_KontProdPrac";
            label_KontProdPrac.Size = new Size(99, 25);
            label_KontProdPrac.TabIndex = 27;
            label_KontProdPrac.Text = "Pracownik";
            // 
            // comboBox_KontProdPrac
            // 
            comboBox_KontProdPrac.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_KontProdPrac.FormattingEnabled = true;
            comboBox_KontProdPrac.Location = new Point(514, 219);
            comboBox_KontProdPrac.Name = "comboBox_KontProdPrac";
            comboBox_KontProdPrac.Size = new Size(371, 33);
            comboBox_KontProdPrac.TabIndex = 26;
            // 
            // Form_KontrolaProd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1322, 1007);
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
        private TextBox textBox_KontProdOdpadySzt;
        private Label label_KontProdOdpadySzt;
        private Button btn_WymusZatwierdzenie;
        private Label label_PostepInfo;
        private ProgressBar progressBar_Postep;
        private TextBox textBox_OdpadyPomiarySzt;
        private TextBox textBox_OdpadyWizualneSzt;
        private Label label_OdpadyPomiarySzt;
        private Label label_OdpadyWizualneSzt;
        private Button btn_GenerujPomiary;
        private TextBox textBox_IloscSztukGeneruj;
        private Label label1;
    }
}