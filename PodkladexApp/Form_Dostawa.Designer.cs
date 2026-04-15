namespace PodkladexApp
{
    partial class Form_Dostawa
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
            comboBox_DostawaMat = new ComboBox();
            comboBox_DostawaFirma = new ComboBox();
            comboBox_DostawaPracownik = new ComboBox();
            btn_DodajDostawe = new Button();
            label_DosawaMat = new Label();
            label_DostawaFirma = new Label();
            label_DostawaPrac = new Label();
            label_DostawaData = new Label();
            dateTimePicker1 = new DateTimePicker();
            btn_DostawaEdytuj = new Button();
            btn_DostawaUsun = new Button();
            comboBox_DostawaEdytuj = new ComboBox();
            label_EdytujUsunDostawe = new Label();
            SuspendLayout();
            // 
            // comboBox_DostawaMat
            // 
            comboBox_DostawaMat.FormattingEnabled = true;
            comboBox_DostawaMat.Location = new Point(267, 47);
            comboBox_DostawaMat.Name = "comboBox_DostawaMat";
            comboBox_DostawaMat.Size = new Size(389, 23);
            comboBox_DostawaMat.TabIndex = 0;
            // 
            // comboBox_DostawaFirma
            // 
            comboBox_DostawaFirma.FormattingEnabled = true;
            comboBox_DostawaFirma.Location = new Point(267, 91);
            comboBox_DostawaFirma.Name = "comboBox_DostawaFirma";
            comboBox_DostawaFirma.Size = new Size(389, 23);
            comboBox_DostawaFirma.TabIndex = 1;
            // 
            // comboBox_DostawaPracownik
            // 
            comboBox_DostawaPracownik.FormattingEnabled = true;
            comboBox_DostawaPracownik.Location = new Point(267, 139);
            comboBox_DostawaPracownik.Name = "comboBox_DostawaPracownik";
            comboBox_DostawaPracownik.Size = new Size(389, 23);
            comboBox_DostawaPracownik.TabIndex = 2;
            // 
            // btn_DodajDostawe
            // 
            btn_DodajDostawe.Location = new Point(109, 336);
            btn_DodajDostawe.Name = "btn_DodajDostawe";
            btn_DodajDostawe.Size = new Size(150, 61);
            btn_DodajDostawe.TabIndex = 4;
            btn_DodajDostawe.Text = "Dodaj dostawe";
            btn_DodajDostawe.UseVisualStyleBackColor = true;
            // 
            // label_DosawaMat
            // 
            label_DosawaMat.AutoSize = true;
            label_DosawaMat.Location = new Point(181, 50);
            label_DosawaMat.Name = "label_DosawaMat";
            label_DosawaMat.Size = new Size(50, 15);
            label_DosawaMat.TabIndex = 5;
            label_DosawaMat.Text = "Material";
            // 
            // label_DostawaFirma
            // 
            label_DostawaFirma.AutoSize = true;
            label_DostawaFirma.Location = new Point(181, 94);
            label_DostawaFirma.Name = "label_DostawaFirma";
            label_DostawaFirma.Size = new Size(37, 15);
            label_DostawaFirma.TabIndex = 6;
            label_DostawaFirma.Text = "Firma";
            // 
            // label_DostawaPrac
            // 
            label_DostawaPrac.AutoSize = true;
            label_DostawaPrac.Location = new Point(181, 142);
            label_DostawaPrac.Name = "label_DostawaPrac";
            label_DostawaPrac.Size = new Size(62, 15);
            label_DostawaPrac.TabIndex = 7;
            label_DostawaPrac.Text = "Pracownik";
            // 
            // label_DostawaData
            // 
            label_DostawaData.AutoSize = true;
            label_DostawaData.Location = new Point(181, 200);
            label_DostawaData.Name = "label_DostawaData";
            label_DostawaData.Size = new Size(78, 15);
            label_DostawaData.TabIndex = 8;
            label_DostawaData.Text = "Data dostawy";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(351, 194);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 9;
            // 
            // btn_DostawaEdytuj
            // 
            btn_DostawaEdytuj.Location = new Point(539, 336);
            btn_DostawaEdytuj.Name = "btn_DostawaEdytuj";
            btn_DostawaEdytuj.Size = new Size(155, 59);
            btn_DostawaEdytuj.TabIndex = 10;
            btn_DostawaEdytuj.Text = "Edytuj Dostawe";
            btn_DostawaEdytuj.UseVisualStyleBackColor = true;
            // 
            // btn_DostawaUsun
            // 
            btn_DostawaUsun.Location = new Point(344, 337);
            btn_DostawaUsun.Name = "btn_DostawaUsun";
            btn_DostawaUsun.Size = new Size(145, 58);
            btn_DostawaUsun.TabIndex = 11;
            btn_DostawaUsun.Text = "Usuń dostawe";
            btn_DostawaUsun.UseVisualStyleBackColor = true;
            // 
            // comboBox_DostawaEdytuj
            // 
            comboBox_DostawaEdytuj.FormattingEnabled = true;
            comboBox_DostawaEdytuj.Location = new Point(289, 280);
            comboBox_DostawaEdytuj.Name = "comboBox_DostawaEdytuj";
            comboBox_DostawaEdytuj.Size = new Size(367, 23);
            comboBox_DostawaEdytuj.TabIndex = 12;
            // 
            // label_EdytujUsunDostawe
            // 
            label_EdytujUsunDostawe.AutoSize = true;
            label_EdytujUsunDostawe.Location = new Point(52, 283);
            label_EdytujUsunDostawe.Name = "label_EdytujUsunDostawe";
            label_EdytujUsunDostawe.Size = new Size(215, 15);
            label_EdytujUsunDostawe.TabIndex = 13;
            label_EdytujUsunDostawe.Text = "Wybierz dotawe do usunięcia lub edycji";
            // 
            // Form_Dostawa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_EdytujUsunDostawe);
            Controls.Add(comboBox_DostawaEdytuj);
            Controls.Add(btn_DostawaUsun);
            Controls.Add(btn_DostawaEdytuj);
            Controls.Add(dateTimePicker1);
            Controls.Add(label_DostawaData);
            Controls.Add(label_DostawaPrac);
            Controls.Add(label_DostawaFirma);
            Controls.Add(label_DosawaMat);
            Controls.Add(btn_DodajDostawe);
            Controls.Add(comboBox_DostawaPracownik);
            Controls.Add(comboBox_DostawaFirma);
            Controls.Add(comboBox_DostawaMat);
            Name = "Form_Dostawa";
            Text = "Dodaj Dostawe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_DostawaMat;
        private ComboBox comboBox_DostawaFirma;
        private ComboBox comboBox_DostawaPracownik;
        private Button btn_DodajDostawe;
        private Label label_DosawaMat;
        private Label label_DostawaFirma;
        private Label label_DostawaPrac;
        private Label label_DostawaData;
        private DateTimePicker dateTimePicker1;
        private Button btn_DostawaEdytuj;
        private Button btn_DostawaUsun;
        private ComboBox comboBox_DostawaEdytuj;
        private Label label_EdytujUsunDostawe;
    }
}