namespace PodkladexApp.Produkcja
{
    partial class Form_DodajNormProd
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
            cmb_produkt = new ComboBox();
            cmb_material = new ComboBox();
            txt_usedMaterial = new TextBox();
            txt_wyprodukowano = new TextBox();
            btn_zapisz = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txt_czas = new TextBox();
            label5 = new Label();
            lbl_tytul = new Label();
            SuspendLayout();
            // 
            // cmb_produkt
            // 
            cmb_produkt.Font = new Font("Segoe UI", 11F);
            cmb_produkt.FormattingEnabled = true;
            cmb_produkt.Location = new Point(219, 215);
            cmb_produkt.Margin = new Padding(5, 5, 5, 5);
            cmb_produkt.Name = "cmb_produkt";
            cmb_produkt.Size = new Size(456, 33);
            cmb_produkt.TabIndex = 0;
            // 
            // cmb_material
            // 
            cmb_material.Font = new Font("Segoe UI", 11F);
            cmb_material.FormattingEnabled = true;
            cmb_material.Location = new Point(219, 366);
            cmb_material.Margin = new Padding(5, 5, 5, 5);
            cmb_material.Name = "cmb_material";
            cmb_material.Size = new Size(456, 33);
            cmb_material.TabIndex = 1;
            // 
            // txt_usedMaterial
            // 
            txt_usedMaterial.Font = new Font("Segoe UI", 11F);
            txt_usedMaterial.Location = new Point(219, 516);
            txt_usedMaterial.Margin = new Padding(5, 5, 5, 5);
            txt_usedMaterial.Name = "txt_usedMaterial";
            txt_usedMaterial.Size = new Size(456, 32);
            txt_usedMaterial.TabIndex = 2;
            // 
            // txt_wyprodukowano
            // 
            txt_wyprodukowano.Font = new Font("Segoe UI", 11F);
            txt_wyprodukowano.Location = new Point(219, 665);
            txt_wyprodukowano.Margin = new Padding(5, 5, 5, 5);
            txt_wyprodukowano.Name = "txt_wyprodukowano";
            txt_wyprodukowano.Size = new Size(456, 32);
            txt_wyprodukowano.TabIndex = 3;
            // 
            // btn_zapisz
            // 
            btn_zapisz.AutoSize = true;
            btn_zapisz.Font = new Font("Segoe UI", 11F);
            btn_zapisz.Location = new Point(315, 930);
            btn_zapisz.Margin = new Padding(5, 5, 5, 5);
            btn_zapisz.Name = "btn_zapisz";
            btn_zapisz.Size = new Size(266, 76);
            btn_zapisz.TabIndex = 4;
            btn_zapisz.Text = "Zapisz";
            btn_zapisz.UseVisualStyleBackColor = true;
            btn_zapisz.Click += btn_zapisz_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(221, 180);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(97, 32);
            label1.TabIndex = 5;
            label1.Text = "Produkt";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(221, 330);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 32);
            label2.TabIndex = 6;
            label2.Text = "Materiał";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(221, 480);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(320, 32);
            label3.TabIndex = 7;
            label3.Text = "Ilość zużytego materiału [kg]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(221, 629);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(433, 32);
            label4.TabIndex = 8;
            label4.Text = "Ilość wyprodukowanych podkładek [kg]";
            // 
            // txt_czas
            // 
            txt_czas.Font = new Font("Segoe UI", 11F);
            txt_czas.Location = new Point(219, 814);
            txt_czas.Margin = new Padding(5, 5, 5, 5);
            txt_czas.Name = "txt_czas";
            txt_czas.Size = new Size(456, 32);
            txt_czas.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(221, 778);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(97, 32);
            label5.TabIndex = 10;
            label5.Text = "Czas [h]";
            // 
            // lbl_tytul
            // 
            lbl_tytul.AutoSize = true;
            lbl_tytul.Font = new Font("Segoe UI", 14.5F);
            lbl_tytul.Location = new Point(200, 62);
            lbl_tytul.Margin = new Padding(5, 0, 5, 0);
            lbl_tytul.Name = "lbl_tytul";
            lbl_tytul.Size = new Size(306, 35);
            lbl_tytul.TabIndex = 11;
            lbl_tytul.Text = "Dodaj normę produkcyjną";
            // 
            // Form_DodajNormProd
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 1074);
            Controls.Add(lbl_tytul);
            Controls.Add(label5);
            Controls.Add(txt_czas);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_zapisz);
            Controls.Add(txt_wyprodukowano);
            Controls.Add(txt_usedMaterial);
            Controls.Add(cmb_material);
            Controls.Add(cmb_produkt);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form_DodajNormProd";
            Text = "Form_DodajNormProd";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmb_produkt;
        private ComboBox cmb_material;
        private TextBox txt_usedMaterial;
        private TextBox txt_wyprodukowano;
        private Button btn_zapisz;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txt_czas;
        private Label label5;
        private Label lbl_tytul;
    }
}