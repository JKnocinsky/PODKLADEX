namespace PodkladexApp
{
    partial class Form_BilansZiS
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            comboBox_miesiacOd = new ComboBox();
            comboBox_rokOd = new ComboBox();
            comboBox_miesiacDo = new ComboBox();
            comboBox_rokDo = new ComboBox();
            button_pokazBilans = new Button();
            dataGridView_bilans = new DataGridView();
            label1 = new Label();
            label_przychody = new Label();
            Dochod = new Label();
            textBox_przychody = new TextBox();
            textBox_wydatki = new TextBox();
            textBox_dochod = new TextBox();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label3 = new Label();
            formsPlot_bilans = new ScottPlot.WinForms.FormsPlot();
            flowLayoutPanel_legenda = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView_bilans).BeginInit();
            SuspendLayout();
            // 
            // comboBox_miesiacOd
            // 
            comboBox_miesiacOd.Font = new Font("Segoe UI", 14.25F);
            comboBox_miesiacOd.FormattingEnabled = true;
            comboBox_miesiacOd.Location = new Point(148, 57);
            comboBox_miesiacOd.Name = "comboBox_miesiacOd";
            comboBox_miesiacOd.Size = new Size(366, 33);
            comboBox_miesiacOd.TabIndex = 0;
            // 
            // comboBox_rokOd
            // 
            comboBox_rokOd.Font = new Font("Segoe UI", 14.25F);
            comboBox_rokOd.FormattingEnabled = true;
            comboBox_rokOd.Location = new Point(148, 96);
            comboBox_rokOd.Name = "comboBox_rokOd";
            comboBox_rokOd.Size = new Size(366, 33);
            comboBox_rokOd.TabIndex = 0;
            // 
            // comboBox_miesiacDo
            // 
            comboBox_miesiacDo.Font = new Font("Segoe UI", 14.25F);
            comboBox_miesiacDo.FormattingEnabled = true;
            comboBox_miesiacDo.Location = new Point(148, 158);
            comboBox_miesiacDo.Name = "comboBox_miesiacDo";
            comboBox_miesiacDo.Size = new Size(366, 33);
            comboBox_miesiacDo.TabIndex = 0;
            // 
            // comboBox_rokDo
            // 
            comboBox_rokDo.Font = new Font("Segoe UI", 14.25F);
            comboBox_rokDo.FormattingEnabled = true;
            comboBox_rokDo.Location = new Point(148, 197);
            comboBox_rokDo.Name = "comboBox_rokDo";
            comboBox_rokDo.Size = new Size(366, 33);
            comboBox_rokDo.TabIndex = 0;
            // 
            // button_pokazBilans
            // 
            button_pokazBilans.Font = new Font("Segoe UI", 14.25F);
            button_pokazBilans.Location = new Point(120, 258);
            button_pokazBilans.Name = "button_pokazBilans";
            button_pokazBilans.Size = new Size(269, 36);
            button_pokazBilans.TabIndex = 1;
            button_pokazBilans.Text = "Pokaż bilans";
            button_pokazBilans.UseVisualStyleBackColor = true;
            button_pokazBilans.Click += button_pokazBilans_Click;
            // 
            // dataGridView_bilans
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_bilans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_bilans.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView_bilans.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView_bilans.Location = new Point(12, 461);
            dataGridView_bilans.Name = "dataGridView_bilans";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView_bilans.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView_bilans.Size = new Size(1390, 322);
            dataGridView_bilans.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.Location = new Point(54, 331);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 3;
            label1.Text = "Przychody";
            // 
            // label_przychody
            // 
            label_przychody.AutoSize = true;
            label_przychody.Font = new Font("Segoe UI", 14.25F);
            label_przychody.Location = new Point(31, 60);
            label_przychody.Name = "label_przychody";
            label_przychody.Size = new Size(112, 25);
            label_przychody.TabIndex = 4;
            label_przychody.Text = "od miesiąca";
            // 
            // Dochod
            // 
            Dochod.AutoSize = true;
            Dochod.Font = new Font("Segoe UI", 14.25F);
            Dochod.Location = new Point(54, 412);
            Dochod.Name = "Dochod";
            Dochod.Size = new Size(78, 25);
            Dochod.TabIndex = 5;
            Dochod.Text = "Dochód";
            // 
            // textBox_przychody
            // 
            textBox_przychody.Font = new Font("Segoe UI", 14.25F);
            textBox_przychody.Location = new Point(159, 331);
            textBox_przychody.Name = "textBox_przychody";
            textBox_przychody.Size = new Size(277, 33);
            textBox_przychody.TabIndex = 6;
            // 
            // textBox_wydatki
            // 
            textBox_wydatki.Font = new Font("Segoe UI", 14.25F);
            textBox_wydatki.Location = new Point(159, 370);
            textBox_wydatki.Name = "textBox_wydatki";
            textBox_wydatki.Size = new Size(277, 33);
            textBox_wydatki.TabIndex = 6;
            // 
            // textBox_dochod
            // 
            textBox_dochod.Font = new Font("Segoe UI", 14.25F);
            textBox_dochod.Location = new Point(159, 409);
            textBox_dochod.Name = "textBox_dochod";
            textBox_dochod.Size = new Size(277, 33);
            textBox_dochod.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(94, 99);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 4;
            label2.Text = "roku";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.Location = new Point(31, 158);
            label4.Name = "label4";
            label4.Size = new Size(112, 25);
            label4.TabIndex = 4;
            label4.Text = "do miesiąca";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F);
            label5.Location = new Point(94, 200);
            label5.Name = "label5";
            label5.Size = new Size(50, 25);
            label5.TabIndex = 4;
            label5.Text = "roku";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F);
            label6.Location = new Point(54, 373);
            label6.Name = "label6";
            label6.Size = new Size(80, 25);
            label6.TabIndex = 5;
            label6.Text = "Wydatki";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(173, 13);
            label3.Name = "label3";
            label3.Size = new Size(231, 25);
            label3.TabIndex = 4;
            label3.Text = "Bilans finansowy z okresu:";
            // 
            // formsPlot_bilans
            // 
            formsPlot_bilans.Location = new Point(553, 13);
            formsPlot_bilans.Name = "formsPlot_bilans";
            formsPlot_bilans.Size = new Size(433, 413);
            formsPlot_bilans.TabIndex = 7;
            // 
            // flowLayoutPanel_legenda
            // 
            flowLayoutPanel_legenda.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            flowLayoutPanel_legenda.Location = new Point(997, 99);
            flowLayoutPanel_legenda.Name = "flowLayoutPanel_legenda";
            flowLayoutPanel_legenda.Size = new Size(415, 253);
            flowLayoutPanel_legenda.TabIndex = 9;
            // 
            // Form_BilansZiS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1424, 811);
            Controls.Add(flowLayoutPanel_legenda);
            Controls.Add(formsPlot_bilans);
            Controls.Add(textBox_dochod);
            Controls.Add(textBox_wydatki);
            Controls.Add(textBox_przychody);
            Controls.Add(label6);
            Controls.Add(Dochod);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label_przychody);
            Controls.Add(label1);
            Controls.Add(dataGridView_bilans);
            Controls.Add(button_pokazBilans);
            Controls.Add(comboBox_rokDo);
            Controls.Add(comboBox_miesiacDo);
            Controls.Add(comboBox_rokOd);
            Controls.Add(comboBox_miesiacOd);
            Name = "Form_BilansZiS";
            Text = "Form1";
            Load += Form_BilansZiS_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_bilans).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_miesiacOd;
        private ComboBox comboBox_rokOd;
        private ComboBox comboBox_miesiacDo;
        private ComboBox comboBox_rokDo;
        private Button button_pokazBilans;
        private DataGridView dataGridView_bilans;
        private Label label1;
        private Label label_przychody;
        private Label Dochod;
        private TextBox textBox_przychody;
        private TextBox textBox_wydatki;
        private TextBox textBox_dochod;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label3;
        private ScottPlot.WinForms.FormsPlot formsPlot_bilans;
        private FlowLayoutPanel flowLayoutPanel_legenda;
    }
}