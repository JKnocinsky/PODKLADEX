namespace PodkladexApp
{
    partial class Form_ocena_stanu
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
            label_lista_rodzajow = new Label();
            comboBox_lista_rodzaj_obslug = new ComboBox();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            dataGridView2 = new DataGridView();
            label4 = new Label();
            textBox_uruchomienie = new TextBox();
            label2 = new Label();
            textBox_miesiace_gwarancji = new TextBox();
            dataGridView3 = new DataGridView();
            label5 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label_lista_rodzajow
            // 
            label_lista_rodzajow.AutoSize = true;
            label_lista_rodzajow.Font = new Font("Segoe UI", 14F);
            label_lista_rodzajow.Location = new Point(12, 1);
            label_lista_rodzajow.Name = "label_lista_rodzajow";
            label_lista_rodzajow.Size = new Size(146, 25);
            label_lista_rodzajow.TabIndex = 18;
            label_lista_rodzajow.Text = "Wybór Maszyny";
            // 
            // comboBox_lista_rodzaj_obslug
            // 
            comboBox_lista_rodzaj_obslug.Font = new Font("Segoe UI", 14F);
            comboBox_lista_rodzaj_obslug.FormattingEnabled = true;
            comboBox_lista_rodzaj_obslug.Location = new Point(12, 29);
            comboBox_lista_rodzaj_obslug.Name = "comboBox_lista_rodzaj_obslug";
            comboBox_lista_rodzaj_obslug.Size = new Size(304, 33);
            comboBox_lista_rodzaj_obslug.TabIndex = 17;
            comboBox_lista_rodzaj_obslug.SelectedIndexChanged += comboBox_lista_rodzaj_obslug_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(12, 65);
            label3.Name = "label3";
            label3.Size = new Size(196, 25);
            label3.TabIndex = 20;
            label3.Text = "Obsługi i użyte części:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 92);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(863, 144);
            dataGridView1.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 238);
            label1.Name = "label1";
            label1.Size = new Size(189, 25);
            label1.TabIndex = 22;
            label1.Text = "Awarie i użyte części:";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 267);
            dataGridView2.Margin = new Padding(3, 2, 3, 2);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(863, 144);
            dataGridView2.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(451, 44);
            label4.Name = "label4";
            label4.Size = new Size(254, 25);
            label4.TabIndex = 42;
            label4.Text = "Data uruchomienia maszyny:";
            // 
            // textBox_uruchomienie
            // 
            textBox_uruchomienie.Font = new Font("Segoe UI", 14F);
            textBox_uruchomienie.Location = new Point(711, 41);
            textBox_uruchomienie.Name = "textBox_uruchomienie";
            textBox_uruchomienie.Size = new Size(164, 32);
            textBox_uruchomienie.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(451, 9);
            label2.Name = "label2";
            label2.Size = new Size(212, 25);
            label2.TabIndex = 40;
            label2.Text = "Do kiedy ma gwarancje:";
            // 
            // textBox_miesiace_gwarancji
            // 
            textBox_miesiace_gwarancji.Font = new Font("Segoe UI", 14F);
            textBox_miesiace_gwarancji.Location = new Point(711, 3);
            textBox_miesiace_gwarancji.Name = "textBox_miesiace_gwarancji";
            textBox_miesiace_gwarancji.Size = new Size(164, 32);
            textBox_miesiace_gwarancji.TabIndex = 39;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(881, 35);
            dataGridView3.Margin = new Padding(3, 2, 3, 2);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(442, 376);
            dataGridView3.TabIndex = 43;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(881, 6);
            label5.Name = "label5";
            label5.Size = new Size(218, 25);
            label5.TabIndex = 44;
            label5.Text = "Przepracowane godziny:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.Location = new Point(1096, 2);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(227, 32);
            textBox1.TabIndex = 45;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(12, 416);
            button1.Name = "button1";
            button1.Size = new Size(1311, 40);
            button1.TabIndex = 46;
            button1.Text = "Generuj wykresy";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(formsPlot2);
            panel1.Controls.Add(formsPlot1);
            panel1.Location = new Point(12, 462);
            panel1.Name = "panel1";
            panel1.Size = new Size(1311, 540);
            panel1.TabIndex = 47;
            // 
            // formsPlot2
            // 
            formsPlot2.Location = new Point(663, 3);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(650, 540);
            formsPlot2.TabIndex = 1;
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(0, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(650, 540);
            formsPlot1.TabIndex = 0;
            // 
            // Form_ocena_stanu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1322, 1007);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(dataGridView3);
            Controls.Add(label4);
            Controls.Add(textBox_uruchomienie);
            Controls.Add(label2);
            Controls.Add(textBox_miesiace_gwarancji);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(label_lista_rodzajow);
            Controls.Add(comboBox_lista_rodzaj_obslug);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_ocena_stanu";
            Text = "Form_ocena_stanu";
            Load += Form_ocena_stanu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_lista_rodzajow;
        private ComboBox comboBox_lista_rodzaj_obslug;
        private Label label3;
        private DataGridView dataGridView1;
        private Label label1;
        private DataGridView dataGridView2;
        private Label label4;
        private TextBox textBox_uruchomienie;
        private Label label2;
        private TextBox textBox_miesiace_gwarancji;
        private DataGridView dataGridView3;
        private Label label5;
        private TextBox textBox1;
        private Button button1;
        private Panel panel1;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
    }
}