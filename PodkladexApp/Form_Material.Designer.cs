namespace PodkladexApp
{
    partial class Form_Material
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
            label_NazwaMat = new Label();
            textBox_DodajNazweMat = new TextBox();
            label_OpisMat = new Label();
            textBox_DodajOpisMat = new TextBox();
            btn_DodajMaterial = new Button();
            btn_EdytujMat = new Button();
            btn_UsunMat = new Button();
            comboBox1 = new ComboBox();
            label_DodajUsun = new Label();
            SuspendLayout();
            // 
            // label_NazwaMat
            // 
            label_NazwaMat.AutoSize = true;
            label_NazwaMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_NazwaMat.Location = new Point(102, 54);
            label_NazwaMat.Name = "label_NazwaMat";
            label_NazwaMat.Size = new Size(163, 25);
            label_NazwaMat.TabIndex = 0;
            label_NazwaMat.Text = "Nazwa materiału: ";
            // 
            // textBox_DodajNazweMat
            // 
            textBox_DodajNazweMat.Location = new Point(276, 56);
            textBox_DodajNazweMat.Name = "textBox_DodajNazweMat";
            textBox_DodajNazweMat.Size = new Size(346, 23);
            textBox_DodajNazweMat.TabIndex = 1;
            // 
            // label_OpisMat
            // 
            label_OpisMat.AutoSize = true;
            label_OpisMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_OpisMat.Location = new Point(102, 110);
            label_OpisMat.Name = "label_OpisMat";
            label_OpisMat.Size = new Size(139, 25);
            label_OpisMat.TabIndex = 2;
            label_OpisMat.Text = "Opis materiału:";
            // 
            // textBox_DodajOpisMat
            // 
            textBox_DodajOpisMat.Location = new Point(276, 112);
            textBox_DodajOpisMat.Name = "textBox_DodajOpisMat";
            textBox_DodajOpisMat.Size = new Size(346, 23);
            textBox_DodajOpisMat.TabIndex = 3;
            // 
            // btn_DodajMaterial
            // 
            btn_DodajMaterial.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_DodajMaterial.Location = new Point(46, 256);
            btn_DodajMaterial.Name = "btn_DodajMaterial";
            btn_DodajMaterial.Size = new Size(167, 61);
            btn_DodajMaterial.TabIndex = 4;
            btn_DodajMaterial.Text = "Dodaj Material";
            btn_DodajMaterial.UseVisualStyleBackColor = true;
            // 
            // btn_EdytujMat
            // 
            btn_EdytujMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_EdytujMat.Location = new Point(276, 254);
            btn_EdytujMat.Name = "btn_EdytujMat";
            btn_EdytujMat.Size = new Size(167, 63);
            btn_EdytujMat.TabIndex = 5;
            btn_EdytujMat.Text = "Edytuj Materiał";
            btn_EdytujMat.UseVisualStyleBackColor = true;
            // 
            // btn_UsunMat
            // 
            btn_UsunMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_UsunMat.Location = new Point(513, 254);
            btn_UsunMat.Name = "btn_UsunMat";
            btn_UsunMat.Size = new Size(167, 61);
            btn_UsunMat.TabIndex = 6;
            btn_UsunMat.Text = "Usuń materiał";
            btn_UsunMat.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(353, 180);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(269, 23);
            comboBox1.TabIndex = 7;
            // 
            // label_DodajUsun
            // 
            label_DodajUsun.AutoSize = true;
            label_DodajUsun.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_DodajUsun.Location = new Point(102, 175);
            label_DodajUsun.Name = "label_DodajUsun";
            label_DodajUsun.Size = new Size(243, 25);
            label_DodajUsun.TabIndex = 8;
            label_DodajUsun.Text = "Wybierz istniejący materiał ";
            // 
            // Form_Material
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_DodajUsun);
            Controls.Add(comboBox1);
            Controls.Add(btn_UsunMat);
            Controls.Add(btn_EdytujMat);
            Controls.Add(btn_DodajMaterial);
            Controls.Add(textBox_DodajOpisMat);
            Controls.Add(label_OpisMat);
            Controls.Add(textBox_DodajNazweMat);
            Controls.Add(label_NazwaMat);
            Name = "Form_Material";
            Text = "Form_Material";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_NazwaMat;
        private TextBox textBox_DodajNazweMat;
        private Label label_OpisMat;
        private TextBox textBox_DodajOpisMat;
        private Button btn_DodajMaterial;
        private Button btn_EdytujMat;
        private Button btn_UsunMat;
        private ComboBox comboBox1;
        private Label label_DodajUsun;
    }
}