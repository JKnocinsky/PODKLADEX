namespace PodkladexApp.Produkcja
{
    partial class Form_PrzypiszWyp
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
            label1 = new Label();
            cmb_maszyna = new ComboBox();
            label2 = new Label();
            dgv_wyposazenie = new DataGridView();
            btn_zapisz = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_wyposazenie).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.5F);
            label1.Location = new Point(152, 28);
            label1.Name = "label1";
            label1.Size = new Size(252, 35);
            label1.TabIndex = 0;
            label1.Text = "Przypisz wyposażenie";
            // 
            // cmb_maszyna
            // 
            cmb_maszyna.Font = new Font("Segoe UI", 11F);
            cmb_maszyna.FormattingEnabled = true;
            cmb_maszyna.Location = new Point(79, 116);
            cmb_maszyna.Name = "cmb_maszyna";
            cmb_maszyna.Size = new Size(399, 33);
            cmb_maszyna.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(79, 88);
            label2.Name = "label2";
            label2.Size = new Size(86, 25);
            label2.TabIndex = 2;
            label2.Text = "Maszyna";
            // 
            // dgv_wyposazenie
            // 
            dgv_wyposazenie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_wyposazenie.Location = new Point(79, 166);
            dgv_wyposazenie.Name = "dgv_wyposazenie";
            dgv_wyposazenie.RowHeadersWidth = 51;
            dgv_wyposazenie.Size = new Size(399, 237);
            dgv_wyposazenie.TabIndex = 3;
            // 
            // btn_zapisz
            // 
            btn_zapisz.AutoSize = true;
            btn_zapisz.Font = new Font("Segoe UI", 11F);
            btn_zapisz.Location = new Point(240, 438);
            btn_zapisz.Name = "btn_zapisz";
            btn_zapisz.Size = new Size(76, 35);
            btn_zapisz.TabIndex = 4;
            btn_zapisz.Text = "Zapisz";
            btn_zapisz.UseVisualStyleBackColor = true;
            btn_zapisz.Click += btn_zapisz_Click;
            // 
            // Form_PrzypiszWyp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 503);
            Controls.Add(btn_zapisz);
            Controls.Add(dgv_wyposazenie);
            Controls.Add(label2);
            Controls.Add(cmb_maszyna);
            Controls.Add(label1);
            Name = "Form_PrzypiszWyp";
            Text = "Form_PrzypiszWyp";
            ((System.ComponentModel.ISupportInitialize)dgv_wyposazenie).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmb_maszyna;
        private Label label2;
        private DataGridView dgv_wyposazenie;
        private Button btn_zapisz;
    }
}