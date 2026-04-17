namespace PodkladexApp
{
    partial class Form_Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Kadry = new Button();
            btn_Produkcja = new Button();
            btn_Zaopatrzenie = new Button();
            btn_Kontrola_Jakosci = new Button();
            btn_Utrzymanie_Ruchu = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // btn_Kadry
            // 
            btn_Kadry.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Kadry.Location = new Point(14, 16);
            btn_Kadry.Margin = new Padding(3, 4, 3, 4);
            btn_Kadry.Name = "btn_Kadry";
            btn_Kadry.Size = new Size(158, 71);
            btn_Kadry.TabIndex = 0;
            btn_Kadry.Text = "Kadry i Finanse";
            btn_Kadry.UseVisualStyleBackColor = true;
            btn_Kadry.Click += btn_Kadry_Click;
            // 
            // btn_Produkcja
            // 
            btn_Produkcja.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Produkcja.Location = new Point(14, 95);
            btn_Produkcja.Margin = new Padding(3, 4, 3, 4);
            btn_Produkcja.Name = "btn_Produkcja";
            btn_Produkcja.Size = new Size(158, 71);
            btn_Produkcja.TabIndex = 1;
            btn_Produkcja.Text = "Produkcja";
            btn_Produkcja.UseVisualStyleBackColor = true;
            btn_Produkcja.Click += btn_Produkcja_Click;
            // 
            // btn_Zaopatrzenie
            // 
            btn_Zaopatrzenie.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Zaopatrzenie.Location = new Point(14, 173);
            btn_Zaopatrzenie.Margin = new Padding(3, 4, 3, 4);
            btn_Zaopatrzenie.Name = "btn_Zaopatrzenie";
            btn_Zaopatrzenie.Size = new Size(158, 71);
            btn_Zaopatrzenie.TabIndex = 2;
            btn_Zaopatrzenie.Text = "Zaopatrzenie i Logistyka";
            btn_Zaopatrzenie.UseVisualStyleBackColor = true;
            btn_Zaopatrzenie.Click += btn_Zaopatrzenie_Click;
            // 
            // btn_Kontrola_Jakosci
            // 
            btn_Kontrola_Jakosci.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Kontrola_Jakosci.Location = new Point(14, 252);
            btn_Kontrola_Jakosci.Margin = new Padding(3, 4, 3, 4);
            btn_Kontrola_Jakosci.Name = "btn_Kontrola_Jakosci";
            btn_Kontrola_Jakosci.Size = new Size(158, 71);
            btn_Kontrola_Jakosci.TabIndex = 3;
            btn_Kontrola_Jakosci.Text = "Kontrola Jakości";
            btn_Kontrola_Jakosci.UseVisualStyleBackColor = true;
            btn_Kontrola_Jakosci.Click += btn_Kontrola_Jakosci_Click;
            // 
            // btn_Utrzymanie_Ruchu
            // 
            btn_Utrzymanie_Ruchu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Utrzymanie_Ruchu.Location = new Point(14, 331);
            btn_Utrzymanie_Ruchu.Margin = new Padding(3, 4, 3, 4);
            btn_Utrzymanie_Ruchu.Name = "btn_Utrzymanie_Ruchu";
            btn_Utrzymanie_Ruchu.Size = new Size(158, 71);
            btn_Utrzymanie_Ruchu.TabIndex = 4;
            btn_Utrzymanie_Ruchu.Text = "Utrzymanie Ruchu";
            btn_Utrzymanie_Ruchu.UseVisualStyleBackColor = true;
            btn_Utrzymanie_Ruchu.Click += btn_Utrzymanie_Ruchu_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(299, 95);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(710, 28);
            comboBox1.TabIndex = 5;
            // 
            // Form_Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1139, 427);
            Controls.Add(comboBox1);
            Controls.Add(btn_Utrzymanie_Ruchu);
            Controls.Add(btn_Kontrola_Jakosci);
            Controls.Add(btn_Zaopatrzenie);
            Controls.Add(btn_Produkcja);
            Controls.Add(btn_Kadry);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_Menu";
            Text = "Podkladex";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Kadry;
        private Button btn_Produkcja;
        private Button btn_Zaopatrzenie;
        private Button btn_Kontrola_Jakosci;
        private Button btn_Utrzymanie_Ruchu;
        private ComboBox comboBox1;
    }
}
