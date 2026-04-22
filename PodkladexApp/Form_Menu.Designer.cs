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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_Kadry
            // 
            btn_Kadry.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Kadry.Location = new Point(12, 157);
            btn_Kadry.Name = "btn_Kadry";
            btn_Kadry.Size = new Size(223, 53);
            btn_Kadry.TabIndex = 0;
            btn_Kadry.Text = "Kadry i Finanse";
            btn_Kadry.UseVisualStyleBackColor = true;
            btn_Kadry.Click += btn_Kadry_Click;
            // 
            // btn_Produkcja
            // 
            btn_Produkcja.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Produkcja.Location = new Point(12, 216);
            btn_Produkcja.Name = "btn_Produkcja";
            btn_Produkcja.Size = new Size(223, 53);
            btn_Produkcja.TabIndex = 1;
            btn_Produkcja.Text = "Produkcja";
            btn_Produkcja.UseVisualStyleBackColor = true;
            btn_Produkcja.Click += btn_Produkcja_Click;
            // 
            // btn_Zaopatrzenie
            // 
            btn_Zaopatrzenie.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Zaopatrzenie.Location = new Point(12, 275);
            btn_Zaopatrzenie.Name = "btn_Zaopatrzenie";
            btn_Zaopatrzenie.Size = new Size(223, 53);
            btn_Zaopatrzenie.TabIndex = 2;
            btn_Zaopatrzenie.Text = "Zaopatrzenie i Logistyka";
            btn_Zaopatrzenie.UseVisualStyleBackColor = true;
            btn_Zaopatrzenie.Click += btn_Zaopatrzenie_Click;
            // 
            // btn_Kontrola_Jakosci
            // 
            btn_Kontrola_Jakosci.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Kontrola_Jakosci.Location = new Point(12, 334);
            btn_Kontrola_Jakosci.Name = "btn_Kontrola_Jakosci";
            btn_Kontrola_Jakosci.Size = new Size(223, 53);
            btn_Kontrola_Jakosci.TabIndex = 3;
            btn_Kontrola_Jakosci.Text = "Kontrola Jakości";
            btn_Kontrola_Jakosci.UseVisualStyleBackColor = true;
            btn_Kontrola_Jakosci.Click += btn_Kontrola_Jakosci_Click;
            // 
            // btn_Utrzymanie_Ruchu
            // 
            btn_Utrzymanie_Ruchu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_Utrzymanie_Ruchu.Location = new Point(12, 393);
            btn_Utrzymanie_Ruchu.Name = "btn_Utrzymanie_Ruchu";
            btn_Utrzymanie_Ruchu.Size = new Size(223, 53);
            btn_Utrzymanie_Ruchu.TabIndex = 4;
            btn_Utrzymanie_Ruchu.Text = "Utrzymanie Ruchu";
            btn_Utrzymanie_Ruchu.UseVisualStyleBackColor = true;
            btn_Utrzymanie_Ruchu.Click += btn_Utrzymanie_Ruchu_Click;
            // 
            // panel_Main
            // 
            panel_Main.BackColor = Color.Transparent;
            panel_Main.BackgroundImageLayout = ImageLayout.Stretch;
            panel_Main.Location = new Point(251, 12);
            panel_Main.Name = "panel_Main";
            panel_Main.Size = new Size(1650, 1137);
            panel_Main.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Logo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 139);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Form_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1904, 1161);
            Controls.Add(pictureBox1);
            Controls.Add(panel_Main);
            Controls.Add(btn_Utrzymanie_Ruchu);
            Controls.Add(btn_Kontrola_Jakosci);
            Controls.Add(btn_Zaopatrzenie);
            Controls.Add(btn_Produkcja);
            Controls.Add(btn_Kadry);
            DoubleBuffered = true;
            Name = "Form_Menu";
            Text = "Podkladex";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Kadry;
        private Button btn_Produkcja;
        private Button btn_Zaopatrzenie;
        private Button btn_Kontrola_Jakosci;
        private Button btn_Utrzymanie_Ruchu;
        private Panel panel_Main;
        private PictureBox pictureBox1;
    }
}
