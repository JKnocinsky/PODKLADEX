namespace PodkladexApp.Produkcja
{
    partial class Form_ProdukcjaZatwierdzPodform
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
            btn_zapisz = new Button();
            txt_odpady = new TextBox();
            txt_wyprodukowano = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btn_zapisz
            // 
            btn_zapisz.AutoSize = true;
            btn_zapisz.Font = new Font("Segoe UI", 11F);
            btn_zapisz.Location = new Point(217, 340);
            btn_zapisz.Name = "btn_zapisz";
            btn_zapisz.Size = new Size(94, 35);
            btn_zapisz.TabIndex = 0;
            btn_zapisz.Text = "Zapisz";
            btn_zapisz.UseVisualStyleBackColor = true;
            btn_zapisz.Click += btn_zapisz_Click;
            // 
            // txt_odpady
            // 
            txt_odpady.Font = new Font("Segoe UI", 11F);
            txt_odpady.Location = new Point(132, 225);
            txt_odpady.Name = "txt_odpady";
            txt_odpady.Size = new Size(264, 32);
            txt_odpady.TabIndex = 1;
            // 
            // txt_wyprodukowano
            // 
            txt_wyprodukowano.Font = new Font("Segoe UI", 11F);
            txt_wyprodukowano.Location = new Point(132, 106);
            txt_wyprodukowano.Name = "txt_wyprodukowano";
            txt_wyprodukowano.Size = new Size(264, 32);
            txt_wyprodukowano.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.5F);
            label1.Location = new Point(203, 26);
            label1.Name = "label1";
            label1.Size = new Size(122, 35);
            label1.TabIndex = 3;
            label1.Text = "Zatwierdź";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 83);
            label2.Name = "label2";
            label2.Size = new Size(169, 20);
            label2.TabIndex = 4;
            label2.Text = "Ile wyprodukowano [kg]";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(132, 202);
            label3.Name = "label3";
            label3.Size = new Size(228, 20);
            label3.TabIndex = 5;
            label3.Text = "Ile odpadów wygenerowano [kg]";
            // 
            // Form_ProdukcjaZatwierdzPodform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 400);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txt_wyprodukowano);
            Controls.Add(txt_odpady);
            Controls.Add(btn_zapisz);
            Name = "Form_ProdukcjaZatwierdzPodform";
            Text = "Form_ProdukcjaZatwierdzPodform";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_zapisz;
        private TextBox txt_odpady;
        private TextBox txt_wyprodukowano;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}