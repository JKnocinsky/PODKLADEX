namespace PodkladexApp
{
    partial class Form_Jakosc
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
            btn_Material = new Button();
            btn_KontrolaMat = new Button();
            panel_Jakosc = new Panel();
            btn_KontrolaProd = new Button();
            btn_Efektywnosc = new Button();
            btn_RaportKontrola = new Button();
            SuspendLayout();
            // 
            // btn_Material
            // 
            btn_Material.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Material.Location = new Point(12, 12);
            btn_Material.Name = "btn_Material";
            btn_Material.Size = new Size(195, 66);
            btn_Material.TabIndex = 0;
            btn_Material.Text = "Materiał";
            btn_Material.UseVisualStyleBackColor = true;
            btn_Material.Click += btn_Material_Click_1;
            // 
            // btn_KontrolaMat
            // 
            btn_KontrolaMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontrolaMat.Location = new Point(12, 99);
            btn_KontrolaMat.Name = "btn_KontrolaMat";
            btn_KontrolaMat.Size = new Size(195, 66);
            btn_KontrolaMat.TabIndex = 2;
            btn_KontrolaMat.Text = "Kontrola jakości materiałów";
            btn_KontrolaMat.UseVisualStyleBackColor = true;
            btn_KontrolaMat.Click += btn_KontrolaMat_Click;
            // 
            // panel_Jakosc
            // 
            panel_Jakosc.Location = new Point(213, 12);
            panel_Jakosc.Name = "panel_Jakosc";
            panel_Jakosc.Size = new Size(1459, 993);
            panel_Jakosc.TabIndex = 4;
            // 
            // btn_KontrolaProd
            // 
            btn_KontrolaProd.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontrolaProd.Location = new Point(12, 186);
            btn_KontrolaProd.Name = "btn_KontrolaProd";
            btn_KontrolaProd.Size = new Size(195, 66);
            btn_KontrolaProd.TabIndex = 5;
            btn_KontrolaProd.Text = "Kontrola jakości produków";
            btn_KontrolaProd.UseVisualStyleBackColor = true;
            btn_KontrolaProd.Click += btn_KontrolaProd_Click;
            // 
            // btn_Efektywnosc
            // 
            btn_Efektywnosc.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Efektywnosc.Location = new Point(12, 273);
            btn_Efektywnosc.Name = "btn_Efektywnosc";
            btn_Efektywnosc.Size = new Size(195, 66);
            btn_Efektywnosc.TabIndex = 6;
            btn_Efektywnosc.Text = "Efektywność produkcji";
            btn_Efektywnosc.UseVisualStyleBackColor = true;
            btn_Efektywnosc.Click += btn_Efektywnosc_Click;
            // 
            // btn_RaportKontrola
            // 
            btn_RaportKontrola.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_RaportKontrola.Location = new Point(12, 360);
            btn_RaportKontrola.Name = "btn_RaportKontrola";
            btn_RaportKontrola.Size = new Size(195, 66);
            btn_RaportKontrola.TabIndex = 7;
            btn_RaportKontrola.Text = "Raporty z kontroli";
            btn_RaportKontrola.UseVisualStyleBackColor = true;
            btn_RaportKontrola.Click += btn_RaportKontrola_Click;
            // 
            // Form_Jakosc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 791);
            Controls.Add(btn_RaportKontrola);
            Controls.Add(btn_Efektywnosc);
            Controls.Add(btn_KontrolaProd);
            Controls.Add(panel_Jakosc);
            Controls.Add(btn_KontrolaMat);
            Controls.Add(btn_Material);
            Name = "Form_Jakosc";
            Text = "Form_Jakosc";
            Load += Form_Jakosc_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Material;
        private Button btn_KontrolaMat;
        private Panel panel_Jakosc;
        private Button btn_KontrolaProd;
        private Button btn_Efektywnosc;
        private Button btn_RaportKontrola;
    }
}