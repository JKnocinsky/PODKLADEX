namespace PodkladexApp
{
    partial class Form_PomiarMat
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
            label_PomiarMatKontMat = new Label();
            label_PomiarMatWlasc = new Label();
            label_PomiarMatWartosc = new Label();
            label_PomiarMatPomiar = new Label();
            comboBox_PomiarMatKontMat = new ComboBox();
            comboBox_PomiarMatWlasc = new ComboBox();
            textBox_PomiarMatWartosc = new TextBox();
            comboBox_PomiarMatPomiar = new ComboBox();
            btn_PomiarMatDodaj = new Button();
            btn_PomiarMatEdytuj = new Button();
            btn_PomiarMatUsun = new Button();
            SuspendLayout();
            // 
            // label_PomiarMatKontMat
            // 
            label_PomiarMatKontMat.AutoSize = true;
            label_PomiarMatKontMat.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarMatKontMat.Location = new Point(249, 52);
            label_PomiarMatKontMat.Name = "label_PomiarMatKontMat";
            label_PomiarMatKontMat.Size = new Size(277, 31);
            label_PomiarMatKontMat.TabIndex = 0;
            label_PomiarMatKontMat.Text = "Kontrola jakości materiału";
            // 
            // label_PomiarMatWlasc
            // 
            label_PomiarMatWlasc.AutoSize = true;
            label_PomiarMatWlasc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarMatWlasc.Location = new Point(249, 141);
            label_PomiarMatWlasc.Name = "label_PomiarMatWlasc";
            label_PomiarMatWlasc.Size = new Size(131, 31);
            label_PomiarMatWlasc.TabIndex = 1;
            label_PomiarMatWlasc.Text = "Właściwość";
            // 
            // label_PomiarMatWartosc
            // 
            label_PomiarMatWartosc.AutoSize = true;
            label_PomiarMatWartosc.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarMatWartosc.Location = new Point(249, 230);
            label_PomiarMatWartosc.Name = "label_PomiarMatWartosc";
            label_PomiarMatWartosc.Size = new Size(206, 31);
            label_PomiarMatWartosc.TabIndex = 2;
            label_PomiarMatWartosc.Text = "Wartość zmierzona";
            // 
            // label_PomiarMatPomiar
            // 
            label_PomiarMatPomiar.AutoSize = true;
            label_PomiarMatPomiar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_PomiarMatPomiar.Location = new Point(249, 319);
            label_PomiarMatPomiar.Name = "label_PomiarMatPomiar";
            label_PomiarMatPomiar.Size = new Size(170, 31);
            label_PomiarMatPomiar.TabIndex = 3;
            label_PomiarMatPomiar.Text = "Lista pomiarów";
            // 
            // comboBox_PomiarMatKontMat
            // 
            comboBox_PomiarMatKontMat.FormattingEnabled = true;
            comboBox_PomiarMatKontMat.Location = new Point(606, 53);
            comboBox_PomiarMatKontMat.Name = "comboBox_PomiarMatKontMat";
            comboBox_PomiarMatKontMat.Size = new Size(386, 28);
            comboBox_PomiarMatKontMat.TabIndex = 4;
            // 
            // comboBox_PomiarMatWlasc
            // 
            comboBox_PomiarMatWlasc.FormattingEnabled = true;
            comboBox_PomiarMatWlasc.Location = new Point(606, 144);
            comboBox_PomiarMatWlasc.Name = "comboBox_PomiarMatWlasc";
            comboBox_PomiarMatWlasc.Size = new Size(386, 28);
            comboBox_PomiarMatWlasc.TabIndex = 5;
            // 
            // textBox_PomiarMatWartosc
            // 
            textBox_PomiarMatWartosc.Location = new Point(606, 234);
            textBox_PomiarMatWartosc.Name = "textBox_PomiarMatWartosc";
            textBox_PomiarMatWartosc.Size = new Size(125, 27);
            textBox_PomiarMatWartosc.TabIndex = 6;
            // 
            // comboBox_PomiarMatPomiar
            // 
            comboBox_PomiarMatPomiar.FormattingEnabled = true;
            comboBox_PomiarMatPomiar.Location = new Point(606, 322);
            comboBox_PomiarMatPomiar.Name = "comboBox_PomiarMatPomiar";
            comboBox_PomiarMatPomiar.Size = new Size(386, 28);
            comboBox_PomiarMatPomiar.TabIndex = 7;
            // 
            // btn_PomiarMatDodaj
            // 
            btn_PomiarMatDodaj.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarMatDodaj.Location = new Point(23, 31);
            btn_PomiarMatDodaj.Name = "btn_PomiarMatDodaj";
            btn_PomiarMatDodaj.Size = new Size(173, 73);
            btn_PomiarMatDodaj.TabIndex = 8;
            btn_PomiarMatDodaj.Text = "Dodaj pomiar";
            btn_PomiarMatDodaj.UseVisualStyleBackColor = true;
            // 
            // btn_PomiarMatEdytuj
            // 
            btn_PomiarMatEdytuj.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarMatEdytuj.Location = new Point(23, 132);
            btn_PomiarMatEdytuj.Name = "btn_PomiarMatEdytuj";
            btn_PomiarMatEdytuj.Size = new Size(173, 73);
            btn_PomiarMatEdytuj.TabIndex = 9;
            btn_PomiarMatEdytuj.Text = "Edytuj pomiar";
            btn_PomiarMatEdytuj.UseVisualStyleBackColor = true;
            // 
            // btn_PomiarMatUsun
            // 
            btn_PomiarMatUsun.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_PomiarMatUsun.Location = new Point(23, 233);
            btn_PomiarMatUsun.Name = "btn_PomiarMatUsun";
            btn_PomiarMatUsun.Size = new Size(173, 73);
            btn_PomiarMatUsun.TabIndex = 10;
            btn_PomiarMatUsun.Text = "Usuń pomiar";
            btn_PomiarMatUsun.UseVisualStyleBackColor = true;
            // 
            // Form_PomiarMat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1172, 602);
            Controls.Add(btn_PomiarMatUsun);
            Controls.Add(btn_PomiarMatEdytuj);
            Controls.Add(btn_PomiarMatDodaj);
            Controls.Add(comboBox_PomiarMatPomiar);
            Controls.Add(textBox_PomiarMatWartosc);
            Controls.Add(comboBox_PomiarMatWlasc);
            Controls.Add(comboBox_PomiarMatKontMat);
            Controls.Add(label_PomiarMatPomiar);
            Controls.Add(label_PomiarMatWartosc);
            Controls.Add(label_PomiarMatWlasc);
            Controls.Add(label_PomiarMatKontMat);
            Name = "Form_PomiarMat";
            Text = "Form_PomiarMat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_PomiarMatKontMat;
        private Label label_PomiarMatWlasc;
        private Label label_PomiarMatWartosc;
        private Label label_PomiarMatPomiar;
        private ComboBox comboBox_PomiarMatKontMat;
        private ComboBox comboBox_PomiarMatWlasc;
        private TextBox textBox_PomiarMatWartosc;
        private ComboBox comboBox_PomiarMatPomiar;
        private Button btn_PomiarMatDodaj;
        private Button btn_PomiarMatEdytuj;
        private Button btn_PomiarMatUsun;
    }
}