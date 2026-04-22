namespace PodkladexApp
{
    partial class Form_Maszyny
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
            dgv_Maszyny = new DataGridView();
            txt_Nazwa_Maszyny = new TextBox();
            btn_dodaj = new Button();
            btn_edytuj = new Button();
            btn_usun = new Button();
            label1 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgv_Maszyny).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_Maszyny
            // 
            dgv_Maszyny.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Maszyny.Location = new Point(65, 64);
            dgv_Maszyny.Name = "dgv_Maszyny";
            dgv_Maszyny.Size = new Size(875, 547);
            dgv_Maszyny.TabIndex = 0;
            // 
            // txt_Nazwa_Maszyny
            // 
            txt_Nazwa_Maszyny.Location = new Point(302, 18);
            txt_Nazwa_Maszyny.Name = "txt_Nazwa_Maszyny";
            txt_Nazwa_Maszyny.Size = new Size(374, 23);
            txt_Nazwa_Maszyny.TabIndex = 1;
            txt_Nazwa_Maszyny.TextChanged += txt_Nazwa_Maszyny_TextChanged;
            // 
            // btn_dodaj
            // 
            btn_dodaj.Location = new Point(302, 626);
            btn_dodaj.Name = "btn_dodaj";
            btn_dodaj.Size = new Size(120, 30);
            btn_dodaj.TabIndex = 2;
            btn_dodaj.Text = "Dodaj";
            btn_dodaj.UseVisualStyleBackColor = true;
            btn_dodaj.Click += btn_dodaj_Click;
            // 
            // btn_edytuj
            // 
            btn_edytuj.Location = new Point(430, 626);
            btn_edytuj.Name = "btn_edytuj";
            btn_edytuj.Size = new Size(120, 30);
            btn_edytuj.TabIndex = 3;
            btn_edytuj.Text = "Edytuj";
            btn_edytuj.UseVisualStyleBackColor = true;
            btn_edytuj.Click += btn_dodaj_Click;
            // 
            // btn_usun
            // 
            btn_usun.Location = new Point(556, 626);
            btn_usun.Name = "btn_usun";
            btn_usun.Size = new Size(120, 30);
            btn_usun.TabIndex = 4;
            btn_usun.Text = "Usuń";
            btn_usun.UseVisualStyleBackColor = true;
            btn_usun.Click += btn_dodaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(205, 21);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 5;
            label1.Text = "Nazwa Maszyny";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSize = true;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btn_usun);
            panel1.Controls.Add(btn_edytuj);
            panel1.Controls.Add(btn_dodaj);
            panel1.Controls.Add(txt_Nazwa_Maszyny);
            panel1.Controls.Add(dgv_Maszyny);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1028, 676);
            panel1.TabIndex = 6;
            // 
            // Form_Maszyny
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 676);
            Controls.Add(panel1);
            Name = "Form_Maszyny";
            Text = "Form_Maszyny";
            ((System.ComponentModel.ISupportInitialize)dgv_Maszyny).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_Maszyny;
        private TextBox txt_Nazwa_Maszyny;
        private Button btn_dodaj;
        private Button btn_edytuj;
        private Button btn_usun;
        private Label label1;
        private Panel panel1;
    }
}