namespace PodkladexApp
{
    partial class Form_KadryFinanse
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
            button_szkolenia = new Button();
            button_umowy = new Button();
            button_urlopy = new Button();
            button_listaosob = new Button();
            panel_kadryfinanse = new Panel();
            button_bilans = new Button();
            button_badania = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button_szkolenia
            // 
            button_szkolenia.FlatStyle = FlatStyle.Flat;
            button_szkolenia.Font = new Font("Segoe UI", 14.25F);
            button_szkolenia.Location = new Point(454, 0);
            button_szkolenia.Margin = new Padding(0);
            button_szkolenia.Name = "button_szkolenia";
            button_szkolenia.Size = new Size(150, 50);
            button_szkolenia.TabIndex = 2;
            button_szkolenia.Text = "Szkolenia";
            button_szkolenia.UseVisualStyleBackColor = true;
            button_szkolenia.Click += button_szkolenia_Click;
            // 
            // button_umowy
            // 
            button_umowy.FlatStyle = FlatStyle.Flat;
            button_umowy.Font = new Font("Segoe UI", 14.25F);
            button_umowy.Location = new Point(152, 0);
            button_umowy.Margin = new Padding(0);
            button_umowy.Name = "button_umowy";
            button_umowy.Size = new Size(150, 50);
            button_umowy.TabIndex = 4;
            button_umowy.Text = "Umowy";
            button_umowy.UseVisualStyleBackColor = true;
            button_umowy.Click += button_umowy_Click;
            // 
            // button_urlopy
            // 
            button_urlopy.FlatStyle = FlatStyle.Flat;
            button_urlopy.Font = new Font("Segoe UI", 14.25F);
            button_urlopy.Location = new Point(303, 0);
            button_urlopy.Margin = new Padding(0);
            button_urlopy.Name = "button_urlopy";
            button_urlopy.Size = new Size(150, 50);
            button_urlopy.TabIndex = 1;
            button_urlopy.Text = "Urlopy";
            button_urlopy.UseVisualStyleBackColor = true;
            button_urlopy.Click += button_urlopy_Click;
            // 
            // button_listaosob
            // 
            button_listaosob.FlatStyle = FlatStyle.Flat;
            button_listaosob.Font = new Font("Segoe UI", 14.25F);
            button_listaosob.Location = new Point(1, 0);
            button_listaosob.Margin = new Padding(0);
            button_listaosob.Name = "button_listaosob";
            button_listaosob.Size = new Size(150, 50);
            button_listaosob.TabIndex = 0;
            button_listaosob.Text = "Lista osób";
            button_listaosob.UseVisualStyleBackColor = true;
            button_listaosob.Click += button_listaosob_Click;
            // 
            // panel_kadryfinanse
            // 
            panel_kadryfinanse.BackColor = SystemColors.Control;
            panel_kadryfinanse.Location = new Point(1, 50);
            panel_kadryfinanse.Margin = new Padding(0);
            panel_kadryfinanse.Name = "panel_kadryfinanse";
            panel_kadryfinanse.Size = new Size(950, 750);
            panel_kadryfinanse.TabIndex = 6;
            // 
            // button_bilans
            // 
            button_bilans.FlatStyle = FlatStyle.Flat;
            button_bilans.Font = new Font("Segoe UI", 14.25F);
            button_bilans.Location = new Point(756, 0);
            button_bilans.Margin = new Padding(0);
            button_bilans.Name = "button_bilans";
            button_bilans.Size = new Size(197, 50);
            button_bilans.TabIndex = 5;
            button_bilans.Text = "Bilans zysków i strat";
            button_bilans.UseVisualStyleBackColor = true;
            // 
            // button_badania
            // 
            button_badania.FlatStyle = FlatStyle.Flat;
            button_badania.Font = new Font("Segoe UI", 14.25F);
            button_badania.Location = new Point(605, 0);
            button_badania.Margin = new Padding(0);
            button_badania.Name = "button_badania";
            button_badania.Size = new Size(150, 50);
            button_badania.TabIndex = 3;
            button_badania.Text = "Badania";
            button_badania.UseVisualStyleBackColor = true;
            button_badania.Click += button_badania_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(button_badania);
            panel1.Controls.Add(button_bilans);
            panel1.Controls.Add(panel_kadryfinanse);
            panel1.Controls.Add(button_listaosob);
            panel1.Controls.Add(button_urlopy);
            panel1.Controls.Add(button_umowy);
            panel1.Controls.Add(button_szkolenia);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(955, 789);
            panel1.TabIndex = 7;
            // 
            // Form_KadryFinanse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(957, 788);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_KadryFinanse";
            Text = "Kadry i finanse";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button_szkolenia;
        private Button button_umowy;
        private Button button_urlopy;
        private Button button_listaosob;
        private Panel panel_kadryfinanse;
        private Button button_bilans;
        private Button button_badania;
        private Panel panel1;
    }
}