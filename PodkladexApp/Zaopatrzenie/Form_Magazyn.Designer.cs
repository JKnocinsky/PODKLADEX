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
            label_wyszukaj = new Label();
            label_filtry = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Magazyn).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_Magazyn
            // 
            dataGridView_Magazyn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Magazyn.Location = new Point(86, 12);
            dataGridView_Magazyn.Name = "dataGridView_Magazyn";
            dataGridView_Magazyn.Size = new Size(1040, 556);
            dataGridView_Magazyn.TabIndex = 0;
            // 
            // textBox_Wyszukaj
            // 
            textBox_Wyszukaj.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox_Wyszukaj.Location = new Point(145, 628);
            textBox_Wyszukaj.Name = "textBox_Wyszukaj";
            textBox_Wyszukaj.Size = new Size(250, 33);
            textBox_Wyszukaj.TabIndex = 1;
            textBox_Wyszukaj.TextChanged += textBox_Wyszukaj_TextChanged;
            // 
            // comboBox_Rodzaj
            // 
            comboBox_Rodzaj.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            comboBox_Rodzaj.FormattingEnabled = true;
            comboBox_Rodzaj.Location = new Point(474, 628);
            comboBox_Rodzaj.Name = "comboBox_Rodzaj";
            comboBox_Rodzaj.Size = new Size(250, 33);
            comboBox_Rodzaj.TabIndex = 2;
            comboBox_Rodzaj.SelectedIndexChanged += comboBox_Rodzaj_SelectedIndexChanged;
            // 
            // button_WyczyscFiltry
            // 
            button_WyczyscFiltry.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_WyczyscFiltry.Location = new Point(806, 613);
            button_WyczyscFiltry.Name = "button_WyczyscFiltry";
            button_WyczyscFiltry.Size = new Size(260, 60);
            button_WyczyscFiltry.TabIndex = 3;
            button_WyczyscFiltry.Text = "Wyczyść filtry";
            button_WyczyscFiltry.UseVisualStyleBackColor = true;
            button_WyczyscFiltry.Click += button_WyczyscFiltry_Click;
            // 
            // label_wyszukaj
            // 
            label_wyszukaj.AutoSize = true;
            label_wyszukaj.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_wyszukaj.Location = new Point(184, 600);
            label_wyszukaj.Name = "label_wyszukaj";
            label_wyszukaj.Size = new Size(165, 25);
            label_wyszukaj.TabIndex = 4;
            label_wyszukaj.Text = "Wyszukaj materiał";
            // 
            // label_filtry
            // 
            label_filtry.AutoSize = true;
            label_filtry.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_filtry.Location = new Point(522, 600);
            label_filtry.Name = "label_filtry";
            label_filtry.Size = new Size(153, 25);
            label_filtry.TabIndex = 5;
            label_filtry.Text = "Rodzaj materiału";
            // 
            // Form_Magazyn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 767);
            Controls.Add(label_filtry);
            Controls.Add(label_wyszukaj);
            Controls.Add(button_WyczyscFiltry);
            Controls.Add(comboBox_Rodzaj);
            Controls.Add(textBox_Wyszukaj);
            Controls.Add(dataGridView_Magazyn);
            Name = "Form_Magazyn";
            Text = "Magazyn";
            ((System.ComponentModel.ISupportInitialize)dataGridView_Magazyn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_Magazyn;
        private TextBox textBox_Wyszukaj;
        private ComboBox comboBox_Rodzaj;
        private Button button_WyczyscFiltry;
        private Label label_wyszukaj;
        private Label label_filtry;
    }
}