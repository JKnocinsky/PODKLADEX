namespace PodkladexApp
{
    partial class Form_Utrzymanie_Ruchu
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
            button_otworz_czesci_zamienne = new Button();
            button_otworz_awaria = new Button();
            button_otworz_obsluga = new Button();
            button_otworz_normy_eksplatacyjne = new Button();
            button_otworz_rodzaj_obslugi = new Button();
            button_otworz_gwarancja = new Button();
            panel_UR = new Panel();
            SuspendLayout();
            // 
            // button_otworz_czesci_zamienne
            // 
            button_otworz_czesci_zamienne.Font = new Font("Segoe UI", 16F);
            button_otworz_czesci_zamienne.Location = new Point(12, 6);
            button_otworz_czesci_zamienne.Name = "button_otworz_czesci_zamienne";
            button_otworz_czesci_zamienne.Size = new Size(129, 55);
            button_otworz_czesci_zamienne.TabIndex = 1;
            button_otworz_czesci_zamienne.Text = "Części zamienne";
            button_otworz_czesci_zamienne.UseVisualStyleBackColor = true;
            button_otworz_czesci_zamienne.Click += button_otworz_czesci_zamienne_Click;
            // 
            // button_otworz_awaria
            // 
            button_otworz_awaria.Location = new Point(12, 67);
            button_otworz_awaria.Name = "button_otworz_awaria";
            button_otworz_awaria.Size = new Size(129, 55);
            button_otworz_awaria.TabIndex = 2;
            button_otworz_awaria.Text = "Awaria";
            button_otworz_awaria.UseVisualStyleBackColor = true;
            button_otworz_awaria.Click += button_otworz_awaria_Click;
            // 
            // button_otworz_obsluga
            // 
            button_otworz_obsluga.Location = new Point(12, 128);
            button_otworz_obsluga.Name = "button_otworz_obsluga";
            button_otworz_obsluga.Size = new Size(129, 55);
            button_otworz_obsluga.TabIndex = 3;
            button_otworz_obsluga.Text = "Obsługa";
            button_otworz_obsluga.UseVisualStyleBackColor = true;
            button_otworz_obsluga.Click += button_otworz_obsluga_Click;
            // 
            // button_otworz_normy_eksplatacyjne
            // 
            button_otworz_normy_eksplatacyjne.Location = new Point(12, 251);
            button_otworz_normy_eksplatacyjne.Name = "button_otworz_normy_eksplatacyjne";
            button_otworz_normy_eksplatacyjne.Size = new Size(129, 55);
            button_otworz_normy_eksplatacyjne.TabIndex = 5;
            button_otworz_normy_eksplatacyjne.Text = "Normy Eksploatacyjne";
            button_otworz_normy_eksplatacyjne.UseVisualStyleBackColor = true;
            button_otworz_normy_eksplatacyjne.Click += button_otworz_normy_eksplatacyjne_Click;
            // 
            // button_otworz_rodzaj_obslugi
            // 
            button_otworz_rodzaj_obslugi.Location = new Point(12, 189);
            button_otworz_rodzaj_obslugi.Name = "button_otworz_rodzaj_obslugi";
            button_otworz_rodzaj_obslugi.Size = new Size(129, 55);
            button_otworz_rodzaj_obslugi.TabIndex = 6;
            button_otworz_rodzaj_obslugi.Text = "Rodzaj obsługi";
            button_otworz_rodzaj_obslugi.UseVisualStyleBackColor = true;
            button_otworz_rodzaj_obslugi.Click += button_otworz_rodzaj_obslugi_Click;
            // 
            // button_otworz_gwarancja
            // 
            button_otworz_gwarancja.Location = new Point(12, 318);
            button_otworz_gwarancja.Name = "button_otworz_gwarancja";
            button_otworz_gwarancja.Size = new Size(129, 55);
            button_otworz_gwarancja.TabIndex = 7;
            button_otworz_gwarancja.Text = "Gwarancja";
            button_otworz_gwarancja.UseVisualStyleBackColor = true;
            button_otworz_gwarancja.Click += button_otworz_gwarancja_Click;
            // 
            // panel_UR
            // 
            panel_UR.Location = new Point(147, 6);
            panel_UR.Name = "panel_UR";
            panel_UR.Size = new Size(1756, 1151);
            panel_UR.TabIndex = 8;
            // 
            // Form_Utrzymanie_Ruchu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1161);
            Controls.Add(panel_UR);
            Controls.Add(button_otworz_gwarancja);
            Controls.Add(button_otworz_rodzaj_obslugi);
            Controls.Add(button_otworz_normy_eksplatacyjne);
            Controls.Add(button_otworz_obsluga);
            Controls.Add(button_otworz_awaria);
            Controls.Add(button_otworz_czesci_zamienne);
            Name = "Form_Utrzymanie_Ruchu";
            Text = "Utrzymanie_Ruchu";
            ResumeLayout(false);
        }

        #endregion

        private Button button_otworz_czesci_zamienne;
        private Button button_otworz_awaria;
        private Button button_otworz_obsluga;
        private Button button_otworz_normy_eksplatacyjne;
        private Button button_otworz_rodzaj_obslugi;
        private Button button_otworz_gwarancja;
        private Panel panel_UR;
    }
}