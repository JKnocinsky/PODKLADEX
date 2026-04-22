namespace PodkladexApp
{
    partial class Form_Normy_eksploatacyjne
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
            textBox_norma_rbh = new TextBox();
            label_lista_norm = new Label();
            comboBox_lista_norm = new ComboBox();
            button_usun_norma = new Button();
            button_edytuj_norma = new Button();
            label_dodajczesc = new Label();
            textBox_nazwa_normy = new TextBox();
            button_dodaj_norme_eksp = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            button_maszyny_norma = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(173, 52);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 31;
            label1.Text = "Godziny pracy ";
            // 
            // textBox_norma_rbh
            // 
            textBox_norma_rbh.Location = new Point(173, 70);
            textBox_norma_rbh.Name = "textBox_norma_rbh";
            textBox_norma_rbh.Size = new Size(375, 23);
            textBox_norma_rbh.TabIndex = 30;
            // 
            // label_lista_norm
            // 
            label_lista_norm.AutoSize = true;
            label_lista_norm.Location = new Point(1, 107);
            label_lista_norm.Name = "label_lista_norm";
            label_lista_norm.Size = new Size(157, 15);
            label_lista_norm.TabIndex = 28;
            label_lista_norm.Text = "Lista norm eksploatacyjnych";
            // 
            // comboBox_lista_norm
            // 
            comboBox_lista_norm.FormattingEnabled = true;
            comboBox_lista_norm.Location = new Point(1, 125);
            comboBox_lista_norm.Name = "comboBox_lista_norm";
            comboBox_lista_norm.Size = new Size(187, 23);
            comboBox_lista_norm.TabIndex = 27;
            // 
            // button_usun_norma
            // 
            button_usun_norma.Location = new Point(604, 131);
            button_usun_norma.Name = "button_usun_norma";
            button_usun_norma.Size = new Size(129, 55);
            button_usun_norma.TabIndex = 26;
            button_usun_norma.Text = "Usuń rodzaj osbługi";
            button_usun_norma.UseVisualStyleBackColor = true;
            // 
            // button_edytuj_norma
            // 
            button_edytuj_norma.Location = new Point(604, 70);
            button_edytuj_norma.Name = "button_edytuj_norma";
            button_edytuj_norma.Size = new Size(129, 55);
            button_edytuj_norma.TabIndex = 25;
            button_edytuj_norma.Text = "Edytuj rodzaj obsługi";
            button_edytuj_norma.UseVisualStyleBackColor = true;
            // 
            // label_dodajczesc
            // 
            label_dodajczesc.AutoSize = true;
            label_dodajczesc.Location = new Point(173, 10);
            label_dodajczesc.Name = "label_dodajczesc";
            label_dodajczesc.Size = new Size(80, 15);
            label_dodajczesc.TabIndex = 24;
            label_dodajczesc.Text = "Nazwa normy";
            // 
            // textBox_nazwa_normy
            // 
            textBox_nazwa_normy.Location = new Point(173, 28);
            textBox_nazwa_normy.Name = "textBox_nazwa_normy";
            textBox_nazwa_normy.Size = new Size(373, 23);
            textBox_nazwa_normy.TabIndex = 23;
            // 
            // button_dodaj_norme_eksp
            // 
            button_dodaj_norme_eksp.Location = new Point(1, 10);
            button_dodaj_norme_eksp.Name = "button_dodaj_norme_eksp";
            button_dodaj_norme_eksp.Size = new Size(129, 55);
            button_dodaj_norme_eksp.TabIndex = 22;
            button_dodaj_norme_eksp.Text = "Dodaj norme eksploatacji";
            button_dodaj_norme_eksp.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(396, 107);
            label3.Name = "label3";
            label3.Size = new Size(185, 15);
            label3.TabIndex = 37;
            label3.Text = "Wartość przepracowanych godzin";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(398, 126);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 23);
            textBox1.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(206, 107);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 35;
            label4.Text = "Lista maszyn";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(206, 125);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(187, 23);
            comboBox1.TabIndex = 34;
            // 
            // button_maszyny_norma
            // 
            button_maszyny_norma.Location = new Point(604, 192);
            button_maszyny_norma.Name = "button_maszyny_norma";
            button_maszyny_norma.Size = new Size(129, 55);
            button_maszyny_norma.TabIndex = 38;
            button_maszyny_norma.Text = "Powiąż wartość normy z maszyną";
            button_maszyny_norma.UseVisualStyleBackColor = true;
            // 
            // Form_Normy_eksploatacyjne
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 338);
            Controls.Add(button_maszyny_norma);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(textBox_norma_rbh);
            Controls.Add(label_lista_norm);
            Controls.Add(comboBox_lista_norm);
            Controls.Add(button_usun_norma);
            Controls.Add(button_edytuj_norma);
            Controls.Add(label_dodajczesc);
            Controls.Add(textBox_nazwa_normy);
            Controls.Add(button_dodaj_norme_eksp);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_Normy_eksploatacyjne";
            Text = "Normy Eksploatacyjne";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox textBox_norma_rbh;
        private Label label_lista_norm;
        private ComboBox comboBox_lista_norm;
        private Button button_usun_norma;
        private Button button_edytuj_norma;
        private Label label_dodajczesc;
        private TextBox textBox_nazwa_normy;
        private Button button_dodaj_norme_eksp;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private ComboBox comboBox1;
        private Button button_maszyny_norma;
    }
}