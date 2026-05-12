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
            panel_Main = new Panel();
            pictureBox1 = new PictureBox();
            button_Exit = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Kadry
            // 
            btn_Kadry.Font = new Font("Segoe UI", 14F);
            btn_Kadry.Location = new Point(10, 323);
            btn_Kadry.Margin = new Padding(3, 4, 3, 4);
            btn_Kadry.Name = "btn_Kadry";
            btn_Kadry.Size = new Size(368, 95);
            btn_Kadry.TabIndex = 0;
            btn_Kadry.Text = "Kadry i Finanse";
            btn_Kadry.UseVisualStyleBackColor = true;
            btn_Kadry.Click += btn_Kadry_Click;
            // 
            // btn_Produkcja
            // 
            btn_Produkcja.Font = new Font("Segoe UI", 14F);
            btn_Produkcja.Location = new Point(10, 528);
            btn_Produkcja.Margin = new Padding(3, 4, 3, 4);
            btn_Produkcja.Name = "btn_Produkcja";
            btn_Produkcja.Size = new Size(368, 95);
            btn_Produkcja.TabIndex = 1;
            btn_Produkcja.Text = "Produkcja";
            btn_Produkcja.UseVisualStyleBackColor = true;
            btn_Produkcja.Click += btn_Produkcja_Click;
            // 
            // btn_Zaopatrzenie
            // 
            btn_Zaopatrzenie.Font = new Font("Segoe UI", 14F);
            btn_Zaopatrzenie.Location = new Point(10, 733);
            btn_Zaopatrzenie.Margin = new Padding(3, 4, 3, 4);
            btn_Zaopatrzenie.Name = "btn_Zaopatrzenie";
            btn_Zaopatrzenie.Size = new Size(368, 101);
            btn_Zaopatrzenie.TabIndex = 2;
            btn_Zaopatrzenie.Text = "Zaopatrzenie i Logistyka";
            btn_Zaopatrzenie.UseVisualStyleBackColor = true;
            btn_Zaopatrzenie.Click += btn_Zaopatrzenie_Click;
            // 
            // btn_Kontrola_Jakosci
            // 
            btn_Kontrola_Jakosci.Font = new Font("Segoe UI", 14F);
            btn_Kontrola_Jakosci.Location = new Point(10, 425);
            btn_Kontrola_Jakosci.Margin = new Padding(3, 4, 3, 4);
            btn_Kontrola_Jakosci.Name = "btn_Kontrola_Jakosci";
            btn_Kontrola_Jakosci.Size = new Size(368, 95);
            btn_Kontrola_Jakosci.TabIndex = 3;
            btn_Kontrola_Jakosci.Text = "Kontrola Jakości";
            btn_Kontrola_Jakosci.UseVisualStyleBackColor = true;
            btn_Kontrola_Jakosci.Click += btn_Kontrola_Jakosci_Click;
            // 
            // btn_Utrzymanie_Ruchu
            // 
            btn_Utrzymanie_Ruchu.Font = new Font("Segoe UI", 14F);
            btn_Utrzymanie_Ruchu.Location = new Point(10, 631);
            btn_Utrzymanie_Ruchu.Margin = new Padding(3, 4, 3, 4);
            btn_Utrzymanie_Ruchu.Name = "btn_Utrzymanie_Ruchu";
            btn_Utrzymanie_Ruchu.Size = new Size(368, 95);
            btn_Utrzymanie_Ruchu.TabIndex = 4;
            btn_Utrzymanie_Ruchu.Text = "Utrzymanie Ruchu";
            btn_Utrzymanie_Ruchu.UseVisualStyleBackColor = true;
            btn_Utrzymanie_Ruchu.Click += btn_Utrzymanie_Ruchu_Click;
            // 
            // panel_Main
            // 
            panel_Main.AutoSize = true;
            panel_Main.BackColor = Color.Transparent;
            panel_Main.BackgroundImageLayout = ImageLayout.Stretch;
            panel_Main.Location = new Point(389, 16);
            panel_Main.Margin = new Padding(3, 4, 3, 4);
            panel_Main.Name = "panel_Main";
            panel_Main.Size = new Size(2544, 1516);
            panel_Main.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Logo1;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(10, 4);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(368, 310);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // button_Exit
            // 
            button_Exit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Exit.BackColor = Color.Firebrick;
            button_Exit.FlatAppearance.BorderColor = SystemColors.Window;
            button_Exit.FlatAppearance.BorderSize = 0;
            button_Exit.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button_Exit.ForeColor = Color.Snow;
            button_Exit.Location = new Point(3, 1395);
            button_Exit.Margin = new Padding(3, 4, 3, 4);
            button_Exit.Name = "button_Exit";
            button_Exit.Size = new Size(368, 101);
            button_Exit.TabIndex = 8;
            button_Exit.Text = "Exit";
            button_Exit.UseVisualStyleBackColor = false;
            button_Exit.Click += buttonExit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button_Exit);
            panel1.Controls.Add(btn_Zaopatrzenie);
            panel1.Controls.Add(btn_Utrzymanie_Ruchu);
            panel1.Controls.Add(btn_Kadry);
            panel1.Controls.Add(btn_Kontrola_Jakosci);
            panel1.Controls.Add(btn_Produkcja);
            panel1.Location = new Point(0, 16);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 1516);
            panel1.TabIndex = 9;
            // 
            // Form_Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(2945, 1548);
            Controls.Add(panel_Main);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_Menu";
            Text = "Podkladex";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Kadry;
        private Button btn_Produkcja;
        private Button btn_Zaopatrzenie;
        private Button btn_Kontrola_Jakosci;
        private Button btn_Utrzymanie_Ruchu;
        private Panel panel_Main;
        private PictureBox pictureBox1;
        private Button button_Exit;
        private Panel panel1;
    }
}
