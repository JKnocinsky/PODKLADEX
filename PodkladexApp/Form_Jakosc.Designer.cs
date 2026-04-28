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
            btn_PomiarMat = new Button();
            btn_KontrolaMat = new Button();
            btn_NormaMat = new Button();
            panel_Jakosc = new Panel();
            btn_KontrolaProd = new Button();
            btn_PomiarProd = new Button();
            btn_NormaProd = new Button();
            SuspendLayout();
            // 
            // btn_Material
            // 
            btn_Material.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Material.Location = new Point(14, 16);
            btn_Material.Margin = new Padding(3, 4, 3, 4);
            btn_Material.Name = "btn_Material";
            btn_Material.Size = new Size(223, 88);
            btn_Material.TabIndex = 0;
            btn_Material.Text = "Materiał";
            btn_Material.UseVisualStyleBackColor = true;
            btn_Material.Click += btn_Material_Click_1;
            // 
            // btn_PomiarMat
            // 
            btn_PomiarMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarMat.Location = new Point(14, 346);
            btn_PomiarMat.Margin = new Padding(3, 4, 3, 4);
            btn_PomiarMat.Name = "btn_PomiarMat";
            btn_PomiarMat.Size = new Size(223, 88);
            btn_PomiarMat.TabIndex = 1;
            btn_PomiarMat.Text = "Pomiar materiału";
            btn_PomiarMat.UseVisualStyleBackColor = true;
            btn_PomiarMat.Click += btn_PomiarMat_Click;
            // 
            // btn_KontrolaMat
            // 
            btn_KontrolaMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontrolaMat.Location = new Point(14, 126);
            btn_KontrolaMat.Margin = new Padding(3, 4, 3, 4);
            btn_KontrolaMat.Name = "btn_KontrolaMat";
            btn_KontrolaMat.Size = new Size(223, 88);
            btn_KontrolaMat.TabIndex = 2;
            btn_KontrolaMat.Text = "Kontrola jakości materiałów";
            btn_KontrolaMat.UseVisualStyleBackColor = true;
            btn_KontrolaMat.Click += btn_KontrolaMat_Click;
            // 
            // btn_NormaMat
            // 
            btn_NormaMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_NormaMat.Location = new Point(14, 566);
            btn_NormaMat.Margin = new Padding(3, 4, 3, 4);
            btn_NormaMat.Name = "btn_NormaMat";
            btn_NormaMat.Size = new Size(223, 88);
            btn_NormaMat.TabIndex = 3;
            btn_NormaMat.Text = "Norma jakości materiału";
            btn_NormaMat.UseVisualStyleBackColor = true;
            // 
            // panel_Jakosc
            // 
            panel_Jakosc.Location = new Point(243, 16);
            panel_Jakosc.Margin = new Padding(3, 4, 3, 4);
            panel_Jakosc.Name = "panel_Jakosc";
            panel_Jakosc.Size = new Size(1119, 1112);
            panel_Jakosc.TabIndex = 4;
            // 
            // btn_KontrolaProd
            // 
            btn_KontrolaProd.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontrolaProd.Location = new Point(14, 236);
            btn_KontrolaProd.Margin = new Padding(3, 4, 3, 4);
            btn_KontrolaProd.Name = "btn_KontrolaProd";
            btn_KontrolaProd.Size = new Size(223, 88);
            btn_KontrolaProd.TabIndex = 5;
            btn_KontrolaProd.Text = "Kontrola jakości produków";
            btn_KontrolaProd.UseVisualStyleBackColor = true;
            btn_KontrolaProd.Click += btn_KontrolaProd_Click;
            // 
            // btn_PomiarProd
            // 
            btn_PomiarProd.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarProd.Location = new Point(14, 456);
            btn_PomiarProd.Margin = new Padding(3, 4, 3, 4);
            btn_PomiarProd.Name = "btn_PomiarProd";
            btn_PomiarProd.Size = new Size(223, 88);
            btn_PomiarProd.TabIndex = 6;
            btn_PomiarProd.Text = "Pomiar produktu";
            btn_PomiarProd.UseVisualStyleBackColor = true;
            btn_PomiarProd.Click += btn_PomiarProd_Click;
            // 
            // btn_NormaProd
            // 
            btn_NormaProd.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_NormaProd.Location = new Point(14, 676);
            btn_NormaProd.Margin = new Padding(3, 4, 3, 4);
            btn_NormaProd.Name = "btn_NormaProd";
            btn_NormaProd.Size = new Size(223, 88);
            btn_NormaProd.TabIndex = 7;
            btn_NormaProd.Text = "Norma jakości produktu";
            btn_NormaProd.UseVisualStyleBackColor = true;
            // 
            // Form_Jakosc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1369, 1055);
            Controls.Add(btn_NormaProd);
            Controls.Add(btn_PomiarProd);
            Controls.Add(btn_KontrolaProd);
            Controls.Add(panel_Jakosc);
            Controls.Add(btn_NormaMat);
            Controls.Add(btn_KontrolaMat);
            Controls.Add(btn_PomiarMat);
            Controls.Add(btn_Material);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_Jakosc";
            Text = "Form_Jakosc";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Material;
        private Button btn_PomiarMat;
        private Button btn_KontrolaMat;
        private Button btn_NormaMat;
        private Panel panel_Jakosc;
        private Button btn_KontrolaProd;
        private Button btn_PomiarProd;
        private Button btn_NormaProd;
    }
}