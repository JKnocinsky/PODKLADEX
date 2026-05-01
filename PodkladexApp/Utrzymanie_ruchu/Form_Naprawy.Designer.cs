namespace PodkladexApp
{
    partial class Form_Naprawy
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
            checkedListBox1 = new CheckedListBox();
            label1 = new Label();
            label2 = new Label();
            checkedListBox2 = new CheckedListBox();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.Font = new Font("Segoe UI", 14F);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(12, 40);
            checkedListBox1.Margin = new Padding(3, 2, 3, 2);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(327, 85);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(213, 25);
            label1.TabIndex = 1;
            label1.Text = "Wybór rodzaju obsługi: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(345, 9);
            label2.Name = "label2";
            label2.Size = new Size(149, 25);
            label2.TabIndex = 3;
            label2.Text = "Wybór maszyny:";
            // 
            // checkedListBox2
            // 
            checkedListBox2.Font = new Font("Segoe UI", 14F);
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Location = new Point(345, 40);
            checkedListBox2.Margin = new Padding(3, 2, 3, 2);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(184, 85);
            checkedListBox2.TabIndex = 2;
            checkedListBox2.ItemCheck += checkedListBox2_ItemCheck;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 154);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(682, 241);
            dataGridView1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(12, 127);
            label3.Name = "label3";
            label3.Size = new Size(148, 25);
            label3.TabIndex = 5;
            label3.Text = "Raport z obsług:";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(535, 40);
            button1.Name = "button1";
            button1.Size = new Size(159, 85);
            button1.TabIndex = 6;
            button1.Text = "Odznacz wszystko";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form_Naprawy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 520);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(checkedListBox2);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_Naprawy";
            Text = "Form_Naprawy";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Label label1;
        private Label label2;
        private CheckedListBox checkedListBox2;
        private DataGridView dataGridView1;
        private Label label3;
        private Button button1;
    }
}