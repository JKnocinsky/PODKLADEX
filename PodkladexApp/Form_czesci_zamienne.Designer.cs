namespace PodkladexApp
{
    partial class Form_czesci_zamienne
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
            button_dodaj_czesc = new Button();
            textBox_nazwa_czesci = new TextBox();
            label_dodajczesc = new Label();
            button_edytuj_czesc = new Button();
            button_usun_czesc = new Button();
            comboBox_lista_czesci = new ComboBox();
            label_listaczesc = new Label();
            button_powrot_z_czesci_zamienne = new Button();
            SuspendLayout();
            // 
            // button_dodaj_czesc
            // 
            button_dodaj_czesc.Location = new Point(35, 28);
            button_dodaj_czesc.Margin = new Padding(3, 4, 3, 4);
            button_dodaj_czesc.Name = "button_dodaj_czesc";
            button_dodaj_czesc.Size = new Size(147, 73);
            button_dodaj_czesc.TabIndex = 0;
            button_dodaj_czesc.Text = "Dodaj Część";
            button_dodaj_czesc.UseVisualStyleBackColor = true;
            // 
            // textBox_nazwa_czesci
            // 
            textBox_nazwa_czesci.Location = new Point(232, 71);
            textBox_nazwa_czesci.Margin = new Padding(3, 4, 3, 4);
            textBox_nazwa_czesci.Name = "textBox_nazwa_czesci";
            textBox_nazwa_czesci.Size = new Size(114, 27);
            textBox_nazwa_czesci.TabIndex = 1;
            // 
            // label_dodajczesc
            // 
            label_dodajczesc.AutoSize = true;
            label_dodajczesc.Location = new Point(232, 28);
            label_dodajczesc.Name = "label_dodajczesc";
            label_dodajczesc.Size = new Size(91, 20);
            label_dodajczesc.TabIndex = 2;
            label_dodajczesc.Text = "Dodaj Część";
            // 
            // button_edytuj_czesc
            // 
            button_edytuj_czesc.Location = new Point(282, 311);
            button_edytuj_czesc.Margin = new Padding(3, 4, 3, 4);
            button_edytuj_czesc.Name = "button_edytuj_czesc";
            button_edytuj_czesc.Size = new Size(147, 73);
            button_edytuj_czesc.TabIndex = 3;
            button_edytuj_czesc.Text = "Edytuj Część";
            button_edytuj_czesc.UseVisualStyleBackColor = true;
            // 
            // button_usun_czesc
            // 
            button_usun_czesc.Location = new Point(282, 173);
            button_usun_czesc.Margin = new Padding(3, 4, 3, 4);
            button_usun_czesc.Name = "button_usun_czesc";
            button_usun_czesc.Size = new Size(147, 73);
            button_usun_czesc.TabIndex = 6;
            button_usun_czesc.Text = "Usuń część";
            button_usun_czesc.UseVisualStyleBackColor = true;
            // 
            // comboBox_lista_czesci
            // 
            comboBox_lista_czesci.FormattingEnabled = true;
            comboBox_lista_czesci.Location = new Point(35, 196);
            comboBox_lista_czesci.Margin = new Padding(3, 4, 3, 4);
            comboBox_lista_czesci.Name = "comboBox_lista_czesci";
            comboBox_lista_czesci.Size = new Size(213, 28);
            comboBox_lista_czesci.TabIndex = 7;
            // 
            // label_listaczesc
            // 
            label_listaczesc.AutoSize = true;
            label_listaczesc.Location = new Point(35, 172);
            label_listaczesc.Name = "label_listaczesc";
            label_listaczesc.Size = new Size(82, 20);
            label_listaczesc.TabIndex = 8;
            label_listaczesc.Text = "Lista części";
            // 
            // button_powrot_z_czesci_zamienne
            // 
            button_powrot_z_czesci_zamienne.Location = new Point(753, 16);
            button_powrot_z_czesci_zamienne.Margin = new Padding(3, 4, 3, 4);
            button_powrot_z_czesci_zamienne.Name = "button_powrot_z_czesci_zamienne";
            button_powrot_z_czesci_zamienne.Size = new Size(147, 73);
            button_powrot_z_czesci_zamienne.TabIndex = 9;
            button_powrot_z_czesci_zamienne.Text = "Powrót";
            button_powrot_z_czesci_zamienne.UseVisualStyleBackColor = true;
            button_powrot_z_czesci_zamienne.Click += button_powrot_z_czesci_zamienne_Click;
            // 
            // Form_czesci_zamienne
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(button_powrot_z_czesci_zamienne);
            Controls.Add(label_listaczesc);
            Controls.Add(comboBox_lista_czesci);
            Controls.Add(button_usun_czesc);
            Controls.Add(button_edytuj_czesc);
            Controls.Add(label_dodajczesc);
            Controls.Add(textBox_nazwa_czesci);
            Controls.Add(button_dodaj_czesc);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_czesci_zamienne";
            Text = "Części zamienne";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_dodaj_czesc;
        private TextBox textBox_nazwa_czesci;
        private Label label_dodajczesc;
        private Button button_edytuj_czesc;
        private Button button_usun_czesc;
        private ComboBox comboBox_lista_czesci;
        private Label label_listaczesc;
        private Button button_powrot_z_czesci_zamienne;
    }
}