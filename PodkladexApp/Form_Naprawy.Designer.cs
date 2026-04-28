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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(81, 74);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(150, 114);
            checkedListBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 31);
            label1.Name = "label1";
            label1.Size = new Size(304, 20);
            label1.TabIndex = 1;
            label1.Text = "wybór rodzaju obsługi, naprawy,konserwacje";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(449, 31);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 3;
            label2.Text = "wybór maszyny";
            // 
            // checkedListBox2
            // 
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Location = new Point(437, 74);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(150, 114);
            checkedListBox2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(81, 231);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(828, 271);
            dataGridView1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 208);
            label3.Name = "label3";
            label3.Size = new Size(388, 20);
            label3.TabIndex = 5;
            label3.Text = "info z obslugi plus do tego ilosc czesci zuzyta i jaka czesc";
            // 
            // Form_Naprawy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 514);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(checkedListBox2);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
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
    }
}