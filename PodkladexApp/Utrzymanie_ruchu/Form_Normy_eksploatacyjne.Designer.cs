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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            button5 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            panel2 = new Panel();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(452, 68);
            label1.Name = "label1";
            label1.Size = new Size(226, 25);
            label1.TabIndex = 31;
            label1.Text = "Godziny pracy dla normy:";
            // 
            // textBox_norma_rbh
            // 
            textBox_norma_rbh.Font = new Font("Segoe UI", 14F);
            textBox_norma_rbh.Location = new Point(452, 96);
            textBox_norma_rbh.Name = "textBox_norma_rbh";
            textBox_norma_rbh.Size = new Size(218, 32);
            textBox_norma_rbh.TabIndex = 30;
            // 
            // label_lista_norm
            // 
            label_lista_norm.AutoSize = true;
            label_lista_norm.Font = new Font("Segoe UI", 14F);
            label_lista_norm.Location = new Point(172, 4);
            label_lista_norm.Name = "label_lista_norm";
            label_lista_norm.Size = new Size(248, 25);
            label_lista_norm.TabIndex = 28;
            label_lista_norm.Text = "Lista norm eksploatacyjnych";
            // 
            // comboBox_lista_norm
            // 
            comboBox_lista_norm.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_lista_norm.Font = new Font("Segoe UI", 14F);
            comboBox_lista_norm.FormattingEnabled = true;
            comboBox_lista_norm.Location = new Point(172, 32);
            comboBox_lista_norm.Name = "comboBox_lista_norm";
            comboBox_lista_norm.Size = new Size(274, 33);
            comboBox_lista_norm.TabIndex = 27;
            comboBox_lista_norm.SelectedIndexChanged += comboBox_lista_norm_SelectedIndexChanged;
            // 
            // button_usun_norma
            // 
            button_usun_norma.Font = new Font("Segoe UI", 14F);
            button_usun_norma.Location = new Point(10, 152);
            button_usun_norma.Name = "button_usun_norma";
            button_usun_norma.Size = new Size(149, 55);
            button_usun_norma.TabIndex = 26;
            button_usun_norma.Text = "Usuń normę";
            button_usun_norma.UseVisualStyleBackColor = true;
            button_usun_norma.Click += button_usun_norma_Click;
            // 
            // button_edytuj_norma
            // 
            button_edytuj_norma.Font = new Font("Segoe UI", 14F);
            button_edytuj_norma.Location = new Point(10, 81);
            button_edytuj_norma.Name = "button_edytuj_norma";
            button_edytuj_norma.Size = new Size(149, 65);
            button_edytuj_norma.TabIndex = 25;
            button_edytuj_norma.Text = "Edytuj normę";
            button_edytuj_norma.UseVisualStyleBackColor = true;
            button_edytuj_norma.Click += button_edytuj_norma_Click;
            // 
            // label_dodajczesc
            // 
            label_dodajczesc.AutoSize = true;
            label_dodajczesc.Font = new Font("Segoe UI", 14F);
            label_dodajczesc.Location = new Point(452, 5);
            label_dodajczesc.Name = "label_dodajczesc";
            label_dodajczesc.Size = new Size(132, 25);
            label_dodajczesc.TabIndex = 24;
            label_dodajczesc.Text = "Nazwa normy:";
            // 
            // textBox_nazwa_normy
            // 
            textBox_nazwa_normy.Font = new Font("Segoe UI", 14F);
            textBox_nazwa_normy.Location = new Point(452, 33);
            textBox_nazwa_normy.Name = "textBox_nazwa_normy";
            textBox_nazwa_normy.Size = new Size(373, 32);
            textBox_nazwa_normy.TabIndex = 23;
            // 
            // button_dodaj_norme_eksp
            // 
            button_dodaj_norme_eksp.Font = new Font("Segoe UI", 14F);
            button_dodaj_norme_eksp.Location = new Point(10, 10);
            button_dodaj_norme_eksp.Name = "button_dodaj_norme_eksp";
            button_dodaj_norme_eksp.Size = new Size(149, 65);
            button_dodaj_norme_eksp.TabIndex = 22;
            button_dodaj_norme_eksp.Text = "Dodaj normę eksploatacji";
            button_dodaj_norme_eksp.UseVisualStyleBackColor = true;
            button_dodaj_norme_eksp.Click += button_dodaj_norme_eksp_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(22, 10);
            label3.Name = "label3";
            label3.Size = new Size(144, 55);
            label3.TabIndex = 37;
            label3.Text = "Wartość godzin poza produkcją";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.Location = new Point(22, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(144, 32);
            textBox1.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(3, 3);
            label4.Name = "label4";
            label4.Size = new Size(118, 25);
            label4.TabIndex = 35;
            label4.Text = "Lista maszyn";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 14F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 31);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(274, 33);
            comboBox1.TabIndex = 34;
            // 
            // button_maszyny_norma
            // 
            button_maszyny_norma.Font = new Font("Segoe UI", 14F);
            button_maszyny_norma.Location = new Point(10, 276);
            button_maszyny_norma.Name = "button_maszyny_norma";
            button_maszyny_norma.Size = new Size(149, 86);
            button_maszyny_norma.TabIndex = 38;
            button_maszyny_norma.Text = "Powiąż wartość normy z maszyną";
            button_maszyny_norma.UseVisualStyleBackColor = true;
            button_maszyny_norma.Click += button_maszyny_norma_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(10, 215);
            button1.Name = "button1";
            button1.Size = new Size(149, 55);
            button1.TabIndex = 39;
            button1.Text = "Potwierdź";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 104);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(821, 324);
            dataGridView1.TabIndex = 40;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(172, 136);
            panel1.Name = "panel1";
            panel1.Size = new Size(832, 519);
            panel1.TabIndex = 41;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 14F);
            button5.Location = new Point(280, 434);
            button5.Name = "button5";
            button5.Size = new Size(305, 55);
            button5.TabIndex = 44;
            button5.Text = "Usuń powiązanie";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(477, 16);
            button2.Name = "button2";
            button2.Size = new Size(318, 67);
            button2.TabIndex = 41;
            button2.Text = "Godziny pracy maszyny poza produkcją";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 14F);
            checkBox1.Location = new Point(283, 33);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(168, 29);
            checkBox1.TabIndex = 42;
            checkBox1.Text = "Tylko bez normy";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckStateChanged += checkBox1_CheckStateChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(1002, 136);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 171);
            panel2.TabIndex = 42;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 14F);
            button3.Location = new Point(22, 103);
            button3.Name = "button3";
            button3.Size = new Size(144, 55);
            button3.TabIndex = 40;
            button3.Text = "Aktualizuj";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form_Normy_eksploatacyjne
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 726);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(button_maszyny_norma);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Button button1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button button2;
        private CheckBox checkBox1;
        private Panel panel2;
        private Button button3;
        private Button button5;
    }
}