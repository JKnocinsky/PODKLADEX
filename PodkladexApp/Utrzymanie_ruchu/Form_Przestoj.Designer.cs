namespace PodkladexApp.Utrzymanie_ruchu
{
    partial class Form_Przestoj
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
            label_czesc = new Label();
            dataGridView1 = new DataGridView();
            cbox_maszyny = new ComboBox();
            button_rysuj_wykres = new Button();
            panel1 = new Panel();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label_czesc
            // 
            label_czesc.AutoSize = true;
            label_czesc.Font = new Font("Segoe UI", 14F);
            label_czesc.Location = new Point(12, 5);
            label_czesc.Name = "label_czesc";
            label_czesc.Size = new Size(53, 25);
            label_czesc.TabIndex = 42;
            label_czesc.Text = "Filtry";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 72);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1252, 346);
            dataGridView1.TabIndex = 41;
            // 
            // cbox_maszyny
            // 
            cbox_maszyny.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_maszyny.Font = new Font("Segoe UI", 14F);
            cbox_maszyny.FormattingEnabled = true;
            cbox_maszyny.Location = new Point(12, 33);
            cbox_maszyny.Name = "cbox_maszyny";
            cbox_maszyny.Size = new Size(645, 33);
            cbox_maszyny.TabIndex = 40;
            cbox_maszyny.SelectedIndexChanged += cbox_maszyny_SelectedIndexChanged;
            // 
            // button_rysuj_wykres
            // 
            button_rysuj_wykres.Font = new Font("Segoe UI", 14F);
            button_rysuj_wykres.Location = new Point(12, 424);
            button_rysuj_wykres.Name = "button_rysuj_wykres";
            button_rysuj_wykres.Size = new Size(1252, 46);
            button_rysuj_wykres.TabIndex = 43;
            button_rysuj_wykres.Text = "Generuj wykres";
            button_rysuj_wykres.UseVisualStyleBackColor = true;
            button_rysuj_wykres.Click += button_rysuj_wykres_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(formsPlot1);
            panel1.Location = new Point(12, 476);
            panel1.Name = "panel1";
            panel1.Size = new Size(1266, 533);
            panel1.TabIndex = 44;
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(0, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(1266, 516);
            formsPlot1.TabIndex = 0;
            // 
            // Form_Przestoj
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1422, 1036);
            Controls.Add(panel1);
            Controls.Add(button_rysuj_wykres);
            Controls.Add(label_czesc);
            Controls.Add(dataGridView1);
            Controls.Add(cbox_maszyny);
            Name = "Form_Przestoj";
            Text = "Form_Przestoj";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_czesc;
        private DataGridView dataGridView1;
        private ComboBox cbox_maszyny;
        private Button button_rysuj_wykres;
        private Panel panel1;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
    }
}