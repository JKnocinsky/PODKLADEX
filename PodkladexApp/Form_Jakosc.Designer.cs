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
            btn_Pomiar = new Button();
            btn_Kontrola = new Button();
            btn_Normy = new Button();
            SuspendLayout();
            // 
            // btn_Material
            // 
            btn_Material.Location = new Point(12, 12);
            btn_Material.Name = "btn_Material";
            btn_Material.Size = new Size(179, 58);
            btn_Material.TabIndex = 0;
            btn_Material.Text = "Dodaj materiał";
            btn_Material.UseVisualStyleBackColor = true;
            btn_Material.Click += btn_Material_Click_1;
            // 
            // btn_Pomiar
            // 
            btn_Pomiar.Location = new Point(12, 76);
            btn_Pomiar.Name = "btn_Pomiar";
            btn_Pomiar.Size = new Size(179, 62);
            btn_Pomiar.TabIndex = 1;
            btn_Pomiar.Text = "Dodaj pomiar";
            btn_Pomiar.UseVisualStyleBackColor = true;
            // 
            // btn_Kontrola
            // 
            btn_Kontrola.Location = new Point(12, 144);
            btn_Kontrola.Name = "btn_Kontrola";
            btn_Kontrola.Size = new Size(179, 63);
            btn_Kontrola.TabIndex = 2;
            btn_Kontrola.Text = "Dodaj kontrole";
            btn_Kontrola.UseVisualStyleBackColor = true;
            // 
            // btn_Normy
            // 
            btn_Normy.Location = new Point(12, 213);
            btn_Normy.Name = "btn_Normy";
            btn_Normy.Size = new Size(179, 63);
            btn_Normy.TabIndex = 3;
            btn_Normy.Text = "Dodaj normę jakości";
            btn_Normy.UseVisualStyleBackColor = true;
            // 
            // Form_Jakosc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Normy);
            Controls.Add(btn_Kontrola);
            Controls.Add(btn_Pomiar);
            Controls.Add(btn_Material);
            Name = "Form_Jakosc";
            Text = "Form_Jakosc";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Material;
        private Button btn_Pomiar;
        private Button btn_Kontrola;
        private Button btn_Normy;
    }
}