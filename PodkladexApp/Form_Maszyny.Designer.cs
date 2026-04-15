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
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            btn_dodaj = new Button();
            btn_edytuj = new Button();
            btn_usun = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(78, 74);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(875, 547);
            dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(315, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(374, 23);
            textBox1.TabIndex = 1;
            // 
            // btn_dodaj
            // 
            btn_dodaj.Location = new Point(315, 636);
            btn_dodaj.Name = "btn_dodaj";
            btn_dodaj.Size = new Size(120, 30);
            btn_dodaj.TabIndex = 2;
            btn_dodaj.Text = "Dodaj";
            btn_dodaj.UseVisualStyleBackColor = true;
            btn_dodaj.Click += btn_dodaj_Click;
            // 
            // btn_edytuj
            // 
            btn_edytuj.Location = new Point(443, 636);
            btn_edytuj.Name = "btn_edytuj";
            btn_edytuj.Size = new Size(120, 30);
            btn_edytuj.TabIndex = 3;
            btn_edytuj.Text = "Edytuj";
            btn_edytuj.UseVisualStyleBackColor = true;
            btn_edytuj.Click += btn_dodaj_Click;
            // 
            // btn_usun
            // 
            btn_usun.Location = new Point(569, 636);
            btn_usun.Name = "btn_usun";
            btn_usun.Size = new Size(120, 30);
            btn_usun.TabIndex = 4;
            btn_usun.Text = "Usuń";
            btn_usun.UseVisualStyleBackColor = true;
            btn_usun.Click += btn_dodaj_Click;
            // 
            // Form_Maszyny
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 676);
            Controls.Add(btn_usun);
            Controls.Add(btn_edytuj);
            Controls.Add(btn_dodaj);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "Form_Maszyny";
            Text = "Form_Maszyny";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Button btn_dodaj;
        private Button btn_edytuj;
        private Button btn_usun;
    }
}