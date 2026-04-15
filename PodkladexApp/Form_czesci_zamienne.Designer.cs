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
            button_dodaj_czesc.Location = new Point(31, 21);
            button_dodaj_czesc.Name = "button_dodaj_czesc";
            button_dodaj_czesc.Size = new Size(129, 55);
            button_dodaj_czesc.TabIndex = 0;
            button_dodaj_czesc.Text = "Dodaj Część";
            button_dodaj_czesc.UseVisualStyleBackColor = true;
            // 
            // textBox_nazwa_czesci
            // 
            textBox_nazwa_czesci.Location = new Point(203, 53);
            textBox_nazwa_czesci.Name = "textBox_nazwa_czesci";
            textBox_nazwa_czesci.Size = new Size(100, 23);
            textBox_nazwa_czesci.TabIndex = 1;
            // 
            // label_dodajczesc
            // 
            label_dodajczesc.AutoSize = true;
            label_dodajczesc.Location = new Point(203, 21);
            label_dodajczesc.Name = "label_dodajczesc";
            label_dodajczesc.Size = new Size(71, 15);
            label_dodajczesc.TabIndex = 2;
            label_dodajczesc.Text = "Dodaj Część";
            // 
            // button_edytuj_czesc
            // 
            button_edytuj_czesc.Location = new Point(247, 233);
            button_edytuj_czesc.Name = "button_edytuj_czesc";
            button_edytuj_czesc.Size = new Size(129, 55);
            button_edytuj_czesc.TabIndex = 3;
            button_edytuj_czesc.Text = "Edytuj Część";
            button_edytuj_czesc.UseVisualStyleBackColor = true;
            // 
            // button_usun_czesc
            // 
            button_usun_czesc.Location = new Point(247, 130);
            button_usun_czesc.Name = "button_usun_czesc";
            button_usun_czesc.Size = new Size(129, 55);
            button_usun_czesc.TabIndex = 6;
            button_usun_czesc.Text = "Usuń część";
            button_usun_czesc.UseVisualStyleBackColor = true;
            // 
            // comboBox_lista_czesci
            // 
            comboBox_lista_czesci.FormattingEnabled = true;
            comboBox_lista_czesci.Location = new Point(31, 147);
            comboBox_lista_czesci.Name = "comboBox_lista_czesci";
            comboBox_lista_czesci.Size = new Size(187, 23);
            comboBox_lista_czesci.TabIndex = 7;
            // 
            // label_listaczesc
            // 
            label_listaczesc.AutoSize = true;
            label_listaczesc.Location = new Point(31, 129);
            label_listaczesc.Name = "label_listaczesc";
            label_listaczesc.Size = new Size(65, 15);
            label_listaczesc.TabIndex = 8;
            label_listaczesc.Text = "Lista części";
            // 
            // button_powrot_z_czesci_zamienne
            // 
            button_powrot_z_czesci_zamienne.Location = new Point(659, 12);
            button_powrot_z_czesci_zamienne.Name = "button_powrot_z_czesci_zamienne";
            button_powrot_z_czesci_zamienne.Size = new Size(129, 55);
            button_powrot_z_czesci_zamienne.TabIndex = 9;
            button_powrot_z_czesci_zamienne.Text = "Powrót";
            button_powrot_z_czesci_zamienne.UseVisualStyleBackColor = true;
            // 
            // Form_czesci_zamienne
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_powrot_z_czesci_zamienne);
            Controls.Add(label_listaczesc);
            Controls.Add(comboBox_lista_czesci);
            Controls.Add(button_usun_czesc);
            Controls.Add(button_edytuj_czesc);
            Controls.Add(label_dodajczesc);
            Controls.Add(textBox_nazwa_czesci);
            Controls.Add(button_dodaj_czesc);
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