namespace PodkladexApp.Zaopatrzenie
{
    partial class Form_Magazyn
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
            dataGridView_Magazyn = new DataGridView();
            textBox_Wyszukaj = new TextBox();
            comboBox_Rodzaj = new ComboBox();
            button_WyczyscFiltry = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Magazyn).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_Magazyn
            // 
            dataGridView_Magazyn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Magazyn.Location = new Point(80, 33);
            dataGridView_Magazyn.Name = "dataGridView_Magazyn";
            dataGridView_Magazyn.Size = new Size(240, 150);
            dataGridView_Magazyn.TabIndex = 0;
            // 
            // textBox_Wyszukaj
            // 
            textBox_Wyszukaj.Location = new Point(112, 265);
            textBox_Wyszukaj.Name = "textBox_Wyszukaj";
            textBox_Wyszukaj.Size = new Size(100, 23);
            textBox_Wyszukaj.TabIndex = 1;
            textBox_Wyszukaj.TextChanged += textBox_Wyszukaj_TextChanged;
            // 
            // comboBox_Rodzaj
            // 
            comboBox_Rodzaj.FormattingEnabled = true;
            comboBox_Rodzaj.Location = new Point(112, 346);
            comboBox_Rodzaj.Name = "comboBox_Rodzaj";
            comboBox_Rodzaj.Size = new Size(121, 23);
            comboBox_Rodzaj.TabIndex = 2;
            comboBox_Rodzaj.SelectedIndexChanged += comboBox_Rodzaj_SelectedIndexChanged;
            // 
            // button_WyczyscFiltry
            // 
            button_WyczyscFiltry.Location = new Point(114, 397);
            button_WyczyscFiltry.Name = "button_WyczyscFiltry";
            button_WyczyscFiltry.Size = new Size(75, 23);
            button_WyczyscFiltry.TabIndex = 3;
            button_WyczyscFiltry.Text = "button1";
            button_WyczyscFiltry.UseVisualStyleBackColor = true;
            button_WyczyscFiltry.Click += button_WyczyscFiltry_Click;
            // 
            // Form_Magazyn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_WyczyscFiltry);
            Controls.Add(comboBox_Rodzaj);
            Controls.Add(textBox_Wyszukaj);
            Controls.Add(dataGridView_Magazyn);
            Name = "Form_Magazyn";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView_Magazyn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_Magazyn;
        private TextBox textBox_Wyszukaj;
        private ComboBox comboBox_Rodzaj;
        private Button button_WyczyscFiltry;
    }
}