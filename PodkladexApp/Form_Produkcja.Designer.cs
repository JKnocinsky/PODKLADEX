namespace PodkladexApp
{
    partial class Form_Produkcja
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
            btn_maszyny = new Button();
            panel_Produkcja = new Panel();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_maszyny
            // 
            btn_maszyny.Location = new Point(8, 9);
            btn_maszyny.Name = "btn_maszyny";
            btn_maszyny.Size = new Size(178, 38);
            btn_maszyny.TabIndex = 0;
            btn_maszyny.Text = "Maszyny";
            btn_maszyny.UseVisualStyleBackColor = true;
            btn_maszyny.Click += btn_maszyny_Click;
            // 
            // panel_Produkcja
            // 
            panel_Produkcja.Dock = DockStyle.Right;
            panel_Produkcja.Location = new Point(197, 0);
            panel_Produkcja.Name = "panel_Produkcja";
            panel_Produkcja.Size = new Size(1617, 1017);
            panel_Produkcja.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_maszyny);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(191, 1017);
            panel1.TabIndex = 2;
            // 
            // Form_Produkcja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1814, 1017);
            Controls.Add(panel1);
            Controls.Add(panel_Produkcja);
            Name = "Form_Produkcja";
            Text = "Form_Produkcja";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_maszyny;
        private Panel panel_Produkcja;
        private Panel panel1;
    }
}