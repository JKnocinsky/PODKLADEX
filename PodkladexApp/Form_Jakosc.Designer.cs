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
            btn_Material.Location = new Point(12, 12);
            btn_Material.Name = "btn_Material";
            btn_Material.Size = new Size(179, 62);
            btn_Material.TabIndex = 0;
            btn_Material.Text = "Dodaj materiał";
            btn_Material.UseVisualStyleBackColor = true;
            btn_Material.Click += btn_Material_Click_1;
            // 
            // btn_PomiarMat
            // 
            btn_PomiarMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarMat.Location = new Point(12, 261);
            btn_PomiarMat.Name = "btn_PomiarMat";
            btn_PomiarMat.Size = new Size(179, 62);
            btn_PomiarMat.TabIndex = 1;
            btn_PomiarMat.Text = "Dodaj pomiar materiału";
            btn_PomiarMat.UseVisualStyleBackColor = true;
            // 
            // btn_KontrolaMat
            // 
            btn_KontrolaMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_KontrolaMat.Location = new Point(12, 95);
            btn_KontrolaMat.Name = "btn_KontrolaMat";
            btn_KontrolaMat.Size = new Size(179, 62);
            btn_KontrolaMat.TabIndex = 2;
            btn_KontrolaMat.Text = "Dodaj kontrole jakości materiałów";
            btn_KontrolaMat.UseVisualStyleBackColor = true;
            btn_KontrolaMat.Click += btn_KontrolaMat_Click;
            // 
            // btn_NormaMat
            // 
            btn_NormaMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_NormaMat.Location = new Point(12, 427);
            btn_NormaMat.Name = "btn_NormaMat";
            btn_NormaMat.Size = new Size(179, 62);
            btn_NormaMat.TabIndex = 3;
            btn_NormaMat.Text = "Dodaj normę jakości materiału";
            btn_NormaMat.UseVisualStyleBackColor = true;
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
            btn_KontrolaProd.Location = new Point(12, 178);
            btn_KontrolaProd.Name = "btn_KontrolaProd";
            btn_KontrolaProd.Size = new Size(179, 62);
            btn_KontrolaProd.TabIndex = 5;
            btn_KontrolaProd.Text = "Dodaj kontrole jakości produków";
            btn_KontrolaProd.UseVisualStyleBackColor = true;
            // 
            // btn_PomiarProd
            // 
            btn_PomiarProd.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarProd.Location = new Point(12, 344);
            btn_PomiarProd.Name = "btn_PomiarProd";
            btn_PomiarProd.Size = new Size(179, 62);
            btn_PomiarProd.TabIndex = 6;
            btn_PomiarProd.Text = "Dodaj pomiar produktu";
            btn_PomiarProd.UseVisualStyleBackColor = true;
            // 
            // btn_NormaProd
            // 
            btn_NormaProd.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_NormaProd.Location = new Point(12, 508);
            btn_NormaProd.Name = "btn_NormaProd";
            btn_NormaProd.Size = new Size(179, 62);
            btn_NormaProd.TabIndex = 7;
            btn_NormaProd.Text = "Dodaj normę jakości produktu";
            btn_NormaProd.UseVisualStyleBackColor = true;
            // 
            // Form_Jakosc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 852);
            Controls.Add(btn_NormaProd);
            Controls.Add(btn_PomiarProd);
            Controls.Add(btn_KontrolaProd);
            Controls.Add(panel_Jakosc);
            Controls.Add(btn_NormaMat);
            Controls.Add(btn_KontrolaMat);
            Controls.Add(btn_PomiarMat);
            Controls.Add(btn_Material);
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