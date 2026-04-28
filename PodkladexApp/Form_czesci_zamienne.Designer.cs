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
            panel_nazwa = new Panel();
            panel_lista = new Panel();
            button_potwierdz = new Button();
            panel_nazwa.SuspendLayout();
            panel_lista.SuspendLayout();
            SuspendLayout();
            // 
            // button_dodaj_czesc
            // 
            button_dodaj_czesc.Font = new Font("Segoe UI", 14F);
            button_dodaj_czesc.Location = new Point(12, 12);
            button_dodaj_czesc.Name = "button_dodaj_czesc";
            button_dodaj_czesc.Size = new Size(166, 55);
            button_dodaj_czesc.TabIndex = 0;
            button_dodaj_czesc.Text = "Dodaj część";
            button_dodaj_czesc.UseVisualStyleBackColor = true;
            button_dodaj_czesc.Click += button_dodaj_czesc_Click;
            // 
            // textBox_nazwa_czesci
            // 
            textBox_nazwa_czesci.Font = new Font("Segoe UI", 14F);
            textBox_nazwa_czesci.Location = new Point(3, 33);
            textBox_nazwa_czesci.Name = "textBox_nazwa_czesci";
            textBox_nazwa_czesci.Size = new Size(361, 32);
            textBox_nazwa_czesci.TabIndex = 1;
            // 
            // label_dodajczesc
            // 
            label_dodajczesc.AutoSize = true;
            label_dodajczesc.Font = new Font("Segoe UI", 14F);
            label_dodajczesc.Location = new Point(3, 8);
            label_dodajczesc.Name = "label_dodajczesc";
            label_dodajczesc.Size = new Size(124, 25);
            label_dodajczesc.TabIndex = 2;
            label_dodajczesc.Text = "Nazwa części";
            label_dodajczesc.Click += label_dodajczesc_Click;
            // 
            // button_edytuj_czesc
            // 
            button_edytuj_czesc.Font = new Font("Segoe UI", 14F);
            button_edytuj_czesc.Location = new Point(12, 134);
            button_edytuj_czesc.Name = "button_edytuj_czesc";
            button_edytuj_czesc.Size = new Size(166, 55);
            button_edytuj_czesc.TabIndex = 3;
            button_edytuj_czesc.Text = "Edytuj część";
            button_edytuj_czesc.UseVisualStyleBackColor = true;
            button_edytuj_czesc.Click += button_edytuj_czesc_Click;
            // 
            // button_usun_czesc
            // 
            button_usun_czesc.Font = new Font("Segoe UI", 14F);
            button_usun_czesc.Location = new Point(12, 73);
            button_usun_czesc.Name = "button_usun_czesc";
            button_usun_czesc.Size = new Size(166, 55);
            button_usun_czesc.TabIndex = 6;
            button_usun_czesc.Text = "Usuń część";
            button_usun_czesc.UseVisualStyleBackColor = true;
            button_usun_czesc.Click += button_usun_czesc_Click;
            // 
            // comboBox_lista_czesci
            // 
            comboBox_lista_czesci.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_lista_czesci.Font = new Font("Segoe UI", 14F);
            comboBox_lista_czesci.FormattingEnabled = true;
            comboBox_lista_czesci.Location = new Point(3, 28);
            comboBox_lista_czesci.Name = "comboBox_lista_czesci";
            comboBox_lista_czesci.Size = new Size(361, 33);
            comboBox_lista_czesci.TabIndex = 7;
            comboBox_lista_czesci.SelectedIndexChanged += comboBox_lista_czesci_SelectedIndexChanged;
            // 
            // label_listaczesc
            // 
            label_listaczesc.AutoSize = true;
            label_listaczesc.Font = new Font("Segoe UI", 14F);
            label_listaczesc.Location = new Point(3, 0);
            label_listaczesc.Name = "label_listaczesc";
            label_listaczesc.Size = new Size(105, 25);
            label_listaczesc.TabIndex = 8;
            label_listaczesc.Text = "Lista części";
            // 
            // panel_nazwa
            // 
            panel_nazwa.Controls.Add(textBox_nazwa_czesci);
            panel_nazwa.Controls.Add(label_dodajczesc);
            panel_nazwa.Location = new Point(184, 12);
            panel_nazwa.Margin = new Padding(3, 2, 3, 2);
            panel_nazwa.Name = "panel_nazwa";
            panel_nazwa.Size = new Size(397, 68);
            panel_nazwa.TabIndex = 9;
            // 
            // panel_lista
            // 
            panel_lista.Controls.Add(comboBox_lista_czesci);
            panel_lista.Controls.Add(label_listaczesc);
            panel_lista.Location = new Point(184, 84);
            panel_lista.Margin = new Padding(3, 2, 3, 2);
            panel_lista.Name = "panel_lista";
            panel_lista.Size = new Size(397, 65);
            panel_lista.TabIndex = 10;
            // 
            // button_potwierdz
            // 
            button_potwierdz.Font = new Font("Segoe UI", 14F);
            button_potwierdz.Location = new Point(12, 195);
            button_potwierdz.Name = "button_potwierdz";
            button_potwierdz.Size = new Size(166, 55);
            button_potwierdz.TabIndex = 11;
            button_potwierdz.Text = "Potwierdź";
            button_potwierdz.UseVisualStyleBackColor = true;
            button_potwierdz.Click += button_potwierdz_Click;
            // 
            // Form_czesci_zamienne
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_potwierdz);
            Controls.Add(panel_lista);
            Controls.Add(panel_nazwa);
            Controls.Add(button_usun_czesc);
            Controls.Add(button_edytuj_czesc);
            Controls.Add(button_dodaj_czesc);
            Name = "Form_czesci_zamienne";
            Text = "Części zamienne";
            panel_nazwa.ResumeLayout(false);
            panel_nazwa.PerformLayout();
            panel_lista.ResumeLayout(false);
            panel_lista.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button_dodaj_czesc;
        private TextBox textBox_nazwa_czesci;
        private Label label_dodajczesc;
        private Button button_edytuj_czesc;
        private Button button_usun_czesc;
        private ComboBox comboBox_lista_czesci;
        private Label label_listaczesc;
        private Panel panel_nazwa;
        private Panel panel_lista;
        private Button button_potwierdz;
    }
}