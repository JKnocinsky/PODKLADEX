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
            btn_KontrolaMat.Location = new Point(12, 94);
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
            panel_Jakosc.Size = new Size(979, 834);
            panel_Jakosc.TabIndex = 4;
            // 
            // btn_KontrolaProd
            // 
            btn_KontrolaProd.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontrolaProd.Location = new Point(12, 177);
            btn_KontrolaProd.Name = "btn_KontrolaProd";
            btn_KontrolaProd.Size = new Size(195, 66);
            btn_KontrolaProd.TabIndex = 5;
            btn_KontrolaProd.Text = "Kontrola jakości produków";
            btn_KontrolaProd.UseVisualStyleBackColor = true;
            btn_KontrolaProd.Click += btn_KontrolaProd_Click;
            // 
            // Form_Jakosc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 791);
            Controls.Add(btn_KontrolaProd);
            Controls.Add(panel_Jakosc);
            Controls.Add(btn_KontrolaMat);
            Controls.Add(btn_Material);
            Name = "Form_Jakosc";
            Text = "Form_Jakosc";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Material;
        private Button btn_KontrolaMat;
        private Panel panel_Jakosc;
        private Button btn_KontrolaProd;
    }
}