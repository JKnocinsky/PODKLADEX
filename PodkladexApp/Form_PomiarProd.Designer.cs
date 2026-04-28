namespace PodkladexApp
{
    partial class Form_PomiarProd
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
            label_PomiarProdKont = new Label();
            label_PomiarProdWlasc = new Label();
            label_PomiarProdWartosc = new Label();
            label_PomiarProdPomiar = new Label();
            comboBox_PomiarProdKont = new ComboBox();
            comboBox_PomiarProdWlasc = new ComboBox();
            textBox1 = new TextBox();
            comboBox_PomiarProdPomiar = new ComboBox();
            btn_PomiarProdDodaj = new Button();
            btn_PomiarProdEdytuj = new Button();
            btn_PomiarProdUsun = new Button();
            SuspendLayout();
            // 
            // label_PomiarProdKont
            // 
            label_PomiarProdKont.AutoSize = true;
            label_PomiarProdKont.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarProdKont.Location = new Point(245, 64);
            label_PomiarProdKont.Name = "label_PomiarProdKont";
            label_PomiarProdKont.Size = new Size(274, 31);
            label_PomiarProdKont.TabIndex = 0;
            label_PomiarProdKont.Text = "Kontrola jakości produktu";
            // 
            // label_PomiarProdWlasc
            // 
            label_PomiarProdWlasc.AutoSize = true;
            label_PomiarProdWlasc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarProdWlasc.Location = new Point(307, 160);
            label_PomiarProdWlasc.Name = "label_PomiarProdWlasc";
            label_PomiarProdWlasc.Size = new Size(131, 31);
            label_PomiarProdWlasc.TabIndex = 1;
            label_PomiarProdWlasc.Text = "Właściwość";
            // 
            // label_PomiarProdWartosc
            // 
            label_PomiarProdWartosc.AutoSize = true;
            label_PomiarProdWartosc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarProdWartosc.Location = new Point(274, 256);
            label_PomiarProdWartosc.Name = "label_PomiarProdWartosc";
            label_PomiarProdWartosc.Size = new Size(206, 31);
            label_PomiarProdWartosc.TabIndex = 2;
            label_PomiarProdWartosc.Text = "Wartość zmierzona";
            // 
            // label_PomiarProdPomiar
            // 
            label_PomiarProdPomiar.AutoSize = true;
            label_PomiarProdPomiar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarProdPomiar.Location = new Point(288, 351);
            label_PomiarProdPomiar.Name = "label_PomiarProdPomiar";
            label_PomiarProdPomiar.Size = new Size(168, 31);
            label_PomiarProdPomiar.TabIndex = 3;
            label_PomiarProdPomiar.Text = "Lista Pomiarów";
            // 
            // comboBox_PomiarProdKont
            // 
            comboBox_PomiarProdKont.FormattingEnabled = true;
            comboBox_PomiarProdKont.Location = new Point(604, 67);
            comboBox_PomiarProdKont.Name = "comboBox_PomiarProdKont";
            comboBox_PomiarProdKont.Size = new Size(400, 28);
            comboBox_PomiarProdKont.TabIndex = 4;
            // 
            // comboBox_PomiarProdWlasc
            // 
            comboBox_PomiarProdWlasc.FormattingEnabled = true;
            comboBox_PomiarProdWlasc.Location = new Point(604, 163);
            comboBox_PomiarProdWlasc.Name = "comboBox_PomiarProdWlasc";
            comboBox_PomiarProdWlasc.Size = new Size(400, 28);
            comboBox_PomiarProdWlasc.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(610, 253);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 6;
            // 
            // comboBox_PomiarProdPomiar
            // 
            comboBox_PomiarProdPomiar.FormattingEnabled = true;
            comboBox_PomiarProdPomiar.Location = new Point(604, 354);
            comboBox_PomiarProdPomiar.Name = "comboBox_PomiarProdPomiar";
            comboBox_PomiarProdPomiar.Size = new Size(400, 28);
            comboBox_PomiarProdPomiar.TabIndex = 7;
            // 
            // btn_PomiarProdDodaj
            // 
            btn_PomiarProdDodaj.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarProdDodaj.Location = new Point(35, 34);
            btn_PomiarProdDodaj.Name = "btn_PomiarProdDodaj";
            btn_PomiarProdDodaj.Size = new Size(153, 72);
            btn_PomiarProdDodaj.TabIndex = 8;
            btn_PomiarProdDodaj.Text = "Dodaj";
            btn_PomiarProdDodaj.UseVisualStyleBackColor = true;
            // 
            // btn_PomiarProdEdytuj
            // 
            btn_PomiarProdEdytuj.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarProdEdytuj.Location = new Point(35, 143);
            btn_PomiarProdEdytuj.Name = "btn_PomiarProdEdytuj";
            btn_PomiarProdEdytuj.Size = new Size(153, 72);
            btn_PomiarProdEdytuj.TabIndex = 9;
            btn_PomiarProdEdytuj.Text = "Edytuj";
            btn_PomiarProdEdytuj.UseVisualStyleBackColor = true;
            // 
            // btn_PomiarProdUsun
            // 
            btn_PomiarProdUsun.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarProdUsun.Location = new Point(35, 252);
            btn_PomiarProdUsun.Name = "btn_PomiarProdUsun";
            btn_PomiarProdUsun.Size = new Size(153, 72);
            btn_PomiarProdUsun.TabIndex = 10;
            btn_PomiarProdUsun.Text = "Usuń";
            btn_PomiarProdUsun.UseVisualStyleBackColor = true;
            // 
            // Form_PomiarProd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 620);
            Controls.Add(btn_PomiarProdUsun);
            Controls.Add(btn_PomiarProdEdytuj);
            Controls.Add(btn_PomiarProdDodaj);
            Controls.Add(comboBox_PomiarProdPomiar);
            Controls.Add(textBox1);
            Controls.Add(comboBox_PomiarProdWlasc);
            Controls.Add(comboBox_PomiarProdKont);
            Controls.Add(label_PomiarProdPomiar);
            Controls.Add(label_PomiarProdWartosc);
            Controls.Add(label_PomiarProdWlasc);
            Controls.Add(label_PomiarProdKont);
            Name = "Form_PomiarProd";
            Text = "Form_PomiarProd";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_PomiarProdKont;
        private Label label_PomiarProdWlasc;
        private Label label_PomiarProdWartosc;
        private Label label_PomiarProdPomiar;
        private ComboBox comboBox_PomiarProdKont;
        private ComboBox comboBox_PomiarProdWlasc;
        private TextBox textBox1;
        private ComboBox comboBox_PomiarProdPomiar;
        private Button btn_PomiarProdDodaj;
        private Button btn_PomiarProdEdytuj;
        private Button btn_PomiarProdUsun;
    }
}