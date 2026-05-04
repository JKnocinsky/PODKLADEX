namespace PodkladexApp.Utrzymanie_ruchu
{
    partial class Form_Awaryjnosc
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
            cbox_maszyny = new ComboBox();
            comboBox_filtry = new ComboBox();
            dataGridView1 = new DataGridView();
            label_maszyna = new Label();
            label1 = new Label();
            button_rysuj_wykres = new Button();
            panel1 = new Panel();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cbox_maszyny
            // 
            cbox_maszyny.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_maszyny.Font = new Font("Segoe UI", 14F);
            cbox_maszyny.FormattingEnabled = true;
            cbox_maszyny.Location = new Point(12, 28);
            cbox_maszyny.Name = "cbox_maszyny";
            cbox_maszyny.Size = new Size(341, 33);
            cbox_maszyny.TabIndex = 31;
            cbox_maszyny.SelectedIndexChanged += cbox_maszyny_SelectedIndexChanged;
            // 
            // comboBox_filtry
            // 
            comboBox_filtry.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_filtry.Font = new Font("Segoe UI", 14F);
            comboBox_filtry.FormattingEnabled = true;
            comboBox_filtry.Location = new Point(359, 28);
            comboBox_filtry.Name = "comboBox_filtry";
            comboBox_filtry.Size = new Size(307, 33);
            comboBox_filtry.TabIndex = 32;
            comboBox_filtry.SelectedIndexChanged += comboBox_filtry_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1252, 282);
            dataGridView1.TabIndex = 33;
            // 
            // label_maszyna
            // 
            label_maszyna.AutoSize = true;
            label_maszyna.Font = new Font("Segoe UI", 14F);
            label_maszyna.Location = new Point(12, 0);
            label_maszyna.Name = "label_maszyna";
            label_maszyna.Size = new Size(86, 25);
            label_maszyna.TabIndex = 34;
            label_maszyna.Text = "Maszyna";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(359, 0);
            label1.Name = "label1";
            label1.Size = new Size(175, 25);
            label1.TabIndex = 35;
            label1.Text = "Filtrowanie danych:";
            // 
            // button_rysuj_wykres
            // 
            button_rysuj_wykres.Font = new Font("Segoe UI", 14F);
            button_rysuj_wykres.Location = new Point(672, 12);
            button_rysuj_wykres.Name = "button_rysuj_wykres";
            button_rysuj_wykres.Size = new Size(592, 50);
            button_rysuj_wykres.TabIndex = 44;
            button_rysuj_wykres.Text = "Generuj wykresy";
            button_rysuj_wykres.UseVisualStyleBackColor = true;
            button_rysuj_wykres.Click += button_rysuj_wykres_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(formsPlot2);
            panel1.Controls.Add(formsPlot1);
            panel1.Location = new Point(12, 355);
            panel1.Name = "panel1";
            panel1.Size = new Size(1266, 676);
            panel1.TabIndex = 45;
            // 
            // formsPlot2
            // 
            formsPlot2.Location = new Point(3, 324);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(1263, 320);
            formsPlot2.TabIndex = 1;
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(0, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(1263, 315);
            formsPlot1.TabIndex = 0;
            // 
            // Form_Awaryjnosc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1315, 1061);
            Controls.Add(panel1);
            Controls.Add(button_rysuj_wykres);
            Controls.Add(label1);
            Controls.Add(label_maszyna);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox_filtry);
            Controls.Add(cbox_maszyny);
            Name = "Form_Awaryjnosc";
            Text = "Form_Awaryjnosc";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbox_maszyny;
        private ComboBox comboBox_filtry;
        private DataGridView dataGridView1;
        private Label label_maszyna;
        private Label label1;
        private Button button_rysuj_wykres;
        private Panel panel1;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
    }
}