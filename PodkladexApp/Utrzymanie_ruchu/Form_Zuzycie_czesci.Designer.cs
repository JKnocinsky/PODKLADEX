namespace PodkladexApp.Utrzymanie_ruchu
{
    partial class Form_Zuzycie_czesci
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
            label_czesc = new Label();
            dataGridView1 = new DataGridView();
            comboBox_filtry = new ComboBox();
            cbox_maszyny = new ComboBox();
            button_rysuj_wykres = new Button();
            panel1 = new Panel();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(373, 9);
            label1.Name = "label1";
            label1.Size = new Size(175, 25);
            label1.TabIndex = 40;
            label1.Text = "Filtrowanie danych:";
            // 
            // label_czesc
            // 
            label_czesc.AutoSize = true;
            label_czesc.Font = new Font("Segoe UI", 14F);
            label_czesc.Location = new Point(12, 13);
            label_czesc.Name = "label_czesc";
            label_czesc.Size = new Size(86, 25);
            label_czesc.TabIndex = 39;
            label_czesc.Text = "Maszyna";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 80);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1252, 377);
            dataGridView1.TabIndex = 38;
            // 
            // comboBox_filtry
            // 
            comboBox_filtry.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_filtry.Font = new Font("Segoe UI", 14F);
            comboBox_filtry.FormattingEnabled = true;
            comboBox_filtry.Location = new Point(373, 41);
            comboBox_filtry.Name = "comboBox_filtry";
            comboBox_filtry.Size = new Size(307, 33);
            comboBox_filtry.TabIndex = 37;
            comboBox_filtry.SelectedIndexChanged += comboBox_filtry_SelectedIndexChanged;
            // 
            // cbox_maszyny
            // 
            cbox_maszyny.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_maszyny.Font = new Font("Segoe UI", 14F);
            cbox_maszyny.FormattingEnabled = true;
            cbox_maszyny.Location = new Point(12, 41);
            cbox_maszyny.Name = "cbox_maszyny";
            cbox_maszyny.Size = new Size(349, 33);
            cbox_maszyny.TabIndex = 36;
            cbox_maszyny.SelectedIndexChanged += cbox_maszyny_SelectedIndexChanged;
            // 
            // button_rysuj_wykres
            // 
            button_rysuj_wykres.Font = new Font("Segoe UI", 14F);
            button_rysuj_wykres.Location = new Point(12, 463);
            button_rysuj_wykres.Name = "button_rysuj_wykres";
            button_rysuj_wykres.Size = new Size(1252, 46);
            button_rysuj_wykres.TabIndex = 44;
            button_rysuj_wykres.Text = "Generuj wykres";
            button_rysuj_wykres.UseVisualStyleBackColor = true;
            button_rysuj_wykres.Click += button_rysuj_wykres_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(formsPlot1);
            panel1.Location = new Point(12, 516);
            panel1.Name = "panel1";
            panel1.Size = new Size(1266, 533);
            panel1.TabIndex = 45;
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(0, 0);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(1266, 516);
            formsPlot1.TabIndex = 0;
            // 
            // Form_Zuzycie_czesci
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1336, 1061);
            Controls.Add(panel1);
            Controls.Add(button_rysuj_wykres);
            Controls.Add(label1);
            Controls.Add(label_czesc);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox_filtry);
            Controls.Add(cbox_maszyny);
            Name = "Form_Zuzycie_czesci";
            Text = "Form_Zuzycie_czesci";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label_czesc;
        private DataGridView dataGridView1;
        private ComboBox comboBox_filtry;
        private ComboBox cbox_maszyny;
        private Button button_rysuj_wykres;
        private Panel panel1;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
    }
}