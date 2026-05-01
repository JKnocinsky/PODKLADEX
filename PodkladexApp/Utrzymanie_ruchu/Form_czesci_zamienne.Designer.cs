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
            button_potwierdz = new Button();
            SuspendLayout();
            // 
            // button_dodaj_czesc
            // 
            button_dodaj_czesc.Font = new Font("Segoe UI", 14F);
            button_dodaj_czesc.Location = new Point(14, 16);
            button_dodaj_czesc.Margin = new Padding(3, 4, 3, 4);
            button_dodaj_czesc.Name = "button_dodaj_czesc";
            button_dodaj_czesc.Size = new Size(190, 73);
            button_dodaj_czesc.TabIndex = 0;
            button_dodaj_czesc.Text = "Dodaj część";
            button_dodaj_czesc.UseVisualStyleBackColor = true;
            button_dodaj_czesc.Click += button_dodaj_czesc_Click;
            // 
            // textBox_nazwa_czesci
            // 
            textBox_nazwa_czesci.Font = new Font("Segoe UI", 14F);
            textBox_nazwa_czesci.Location = new Point(653, 50);
            textBox_nazwa_czesci.Margin = new Padding(3, 4, 3, 4);
            textBox_nazwa_czesci.Name = "textBox_nazwa_czesci";
            textBox_nazwa_czesci.Size = new Size(412, 39);
            textBox_nazwa_czesci.TabIndex = 1;
            // 
            // label_dodajczesc
            // 
            label_dodajczesc.AutoSize = true;
            label_dodajczesc.Font = new Font("Segoe UI", 14F);
            label_dodajczesc.Location = new Point(210, 16);
            label_dodajczesc.Name = "label_dodajczesc";
            label_dodajczesc.Size = new Size(153, 32);
            label_dodajczesc.TabIndex = 2;
            label_dodajczesc.Text = "Nazwa części";
            label_dodajczesc.Click += label_dodajczesc_Click;
            // 
            // button_edytuj_czesc
            // 
            button_edytuj_czesc.Font = new Font("Segoe UI", 14F);
            button_edytuj_czesc.Location = new Point(14, 179);
            button_edytuj_czesc.Margin = new Padding(3, 4, 3, 4);
            button_edytuj_czesc.Name = "button_edytuj_czesc";
            button_edytuj_czesc.Size = new Size(190, 73);
            button_edytuj_czesc.TabIndex = 3;
            button_edytuj_czesc.Text = "Edytuj część";
            button_edytuj_czesc.UseVisualStyleBackColor = true;
            button_edytuj_czesc.Click += button_edytuj_czesc_Click;
            // 
            // button_usun_czesc
            // 
            button_usun_czesc.Font = new Font("Segoe UI", 14F);
            button_usun_czesc.Location = new Point(14, 97);
            button_usun_czesc.Margin = new Padding(3, 4, 3, 4);
            button_usun_czesc.Name = "button_usun_czesc";
            button_usun_czesc.Size = new Size(190, 73);
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
            comboBox_lista_czesci.Location = new Point(216, 50);
            comboBox_lista_czesci.Margin = new Padding(3, 4, 3, 4);
            comboBox_lista_czesci.Name = "comboBox_lista_czesci";
            comboBox_lista_czesci.Size = new Size(412, 39);
            comboBox_lista_czesci.TabIndex = 7;
            comboBox_lista_czesci.SelectedIndexChanged += comboBox_lista_czesci_SelectedIndexChanged;
            // 
            // label_listaczesc
            // 
            label_listaczesc.AutoSize = true;
            label_listaczesc.Font = new Font("Segoe UI", 14F);
            label_listaczesc.Location = new Point(653, 9);
            label_listaczesc.Name = "label_listaczesc";
            label_listaczesc.Size = new Size(130, 32);
            label_listaczesc.TabIndex = 8;
            label_listaczesc.Text = "Lista części";
            // 
            // button_potwierdz
            // 
            button_potwierdz.Font = new Font("Segoe UI", 14F);
            button_potwierdz.Location = new Point(14, 260);
            button_potwierdz.Margin = new Padding(3, 4, 3, 4);
            button_potwierdz.Name = "button_potwierdz";
            button_potwierdz.Size = new Size(190, 73);
            button_potwierdz.TabIndex = 11;
            button_potwierdz.Text = "Potwierdź";
            button_potwierdz.UseVisualStyleBackColor = true;
            button_potwierdz.Click += button_potwierdz_Click;
            // 
            // Form_czesci_zamienne
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 649);
            Controls.Add(comboBox_lista_czesci);
            Controls.Add(textBox_nazwa_czesci);
            Controls.Add(label_listaczesc);
            Controls.Add(button_potwierdz);
            Controls.Add(label_dodajczesc);
            Controls.Add(button_usun_czesc);
            Controls.Add(button_edytuj_czesc);
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
        private Button button_potwierdz;
    }
}