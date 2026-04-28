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
            comboBox_MaterialLista = new ComboBox();
            label_DodajUsun = new Label();
            btn_MaterialPotwierdz = new Button();
            label_MaterialRodzaj = new Label();
            comboBox_MaterialRodzaj = new ComboBox();
            SuspendLayout();
            // 
            // label_NazwaMat
            // 
            label_NazwaMat.AutoSize = true;
            label_NazwaMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_NazwaMat.Location = new Point(245, 53);
            label_NazwaMat.Name = "label_NazwaMat";
            label_NazwaMat.Size = new Size(204, 32);
            label_NazwaMat.TabIndex = 0;
            label_NazwaMat.Text = "Nazwa materiału: ";
            // 
            // textBox_DodajNazweMat
            // 
            textBox_DodajNazweMat.Location = new Point(469, 53);
            textBox_DodajNazweMat.Margin = new Padding(3, 4, 3, 4);
            textBox_DodajNazweMat.Name = "textBox_DodajNazweMat";
            textBox_DodajNazweMat.Size = new Size(395, 27);
            textBox_DodajNazweMat.TabIndex = 1;
            // 
            // label_OpisMat
            // 
            label_OpisMat.AutoSize = true;
            label_OpisMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_OpisMat.Location = new Point(245, 123);
            label_OpisMat.Name = "label_OpisMat";
            label_OpisMat.Size = new Size(175, 32);
            label_OpisMat.TabIndex = 2;
            label_OpisMat.Text = "Opis materiału:";
            // 
            // textBox_DodajOpisMat
            // 
            textBox_DodajOpisMat.Location = new Point(469, 128);
            textBox_DodajOpisMat.Margin = new Padding(3, 4, 3, 4);
            textBox_DodajOpisMat.Name = "textBox_DodajOpisMat";
            textBox_DodajOpisMat.Size = new Size(395, 27);
            textBox_DodajOpisMat.TabIndex = 3;
            // 
            // btn_DodajMaterial
            // 
            btn_DodajMaterial.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_DodajMaterial.Location = new Point(12, 27);
            btn_DodajMaterial.Margin = new Padding(3, 4, 3, 4);
            btn_DodajMaterial.Name = "btn_DodajMaterial";
            btn_DodajMaterial.Size = new Size(191, 81);
            btn_DodajMaterial.TabIndex = 4;
            btn_DodajMaterial.Text = "Dodaj material";
            btn_DodajMaterial.UseVisualStyleBackColor = true;
            // 
            // btn_EdytujMat
            // 
            btn_EdytujMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_EdytujMat.Location = new Point(12, 131);
            btn_EdytujMat.Margin = new Padding(3, 4, 3, 4);
            btn_EdytujMat.Name = "btn_EdytujMat";
            btn_EdytujMat.Size = new Size(191, 81);
            btn_EdytujMat.TabIndex = 5;
            btn_EdytujMat.Text = "Edytuj materiał";
            btn_EdytujMat.UseVisualStyleBackColor = true;
            // 
            // btn_UsunMat
            // 
            btn_UsunMat.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_UsunMat.Location = new Point(12, 235);
            btn_UsunMat.Margin = new Padding(3, 4, 3, 4);
            btn_UsunMat.Name = "btn_UsunMat";
            btn_UsunMat.Size = new Size(191, 81);
            btn_UsunMat.TabIndex = 6;
            btn_UsunMat.Text = "Usuń materiał";
            btn_UsunMat.UseVisualStyleBackColor = true;
            // 
            // comboBox_MaterialLista
            // 
            comboBox_MaterialLista.FormattingEnabled = true;
            comboBox_MaterialLista.Location = new Point(469, 262);
            comboBox_MaterialLista.Margin = new Padding(3, 4, 3, 4);
            comboBox_MaterialLista.Name = "comboBox_MaterialLista";
            comboBox_MaterialLista.Size = new Size(395, 28);
            comboBox_MaterialLista.TabIndex = 7;
            // 
            // label_DodajUsun
            // 
            label_DodajUsun.AutoSize = true;
            label_DodajUsun.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_DodajUsun.Location = new Point(245, 262);
            label_DodajUsun.Name = "label_DodajUsun";
            label_DodajUsun.Size = new Size(186, 32);
            label_DodajUsun.TabIndex = 8;
            label_DodajUsun.Text = "Lista materiałów";
            // 
            // btn_MaterialPotwierdz
            // 
            btn_MaterialPotwierdz.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btn_MaterialPotwierdz.Location = new Point(12, 339);
            btn_MaterialPotwierdz.Name = "btn_MaterialPotwierdz";
            btn_MaterialPotwierdz.Size = new Size(191, 81);
            btn_MaterialPotwierdz.TabIndex = 9;
            btn_MaterialPotwierdz.Text = "Potwierdź";
            btn_MaterialPotwierdz.UseVisualStyleBackColor = true;
            // 
            // label_MaterialRodzaj
            // 
            label_MaterialRodzaj.AutoSize = true;
            label_MaterialRodzaj.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_MaterialRodzaj.Location = new Point(245, 193);
            label_MaterialRodzaj.Name = "label_MaterialRodzaj";
            label_MaterialRodzaj.Size = new Size(190, 31);
            label_MaterialRodzaj.TabIndex = 10;
            label_MaterialRodzaj.Text = "Rodzaj materiału:";
            // 
            // comboBox_MaterialRodzaj
            // 
            comboBox_MaterialRodzaj.FormattingEnabled = true;
            comboBox_MaterialRodzaj.Location = new Point(469, 196);
            comboBox_MaterialRodzaj.Name = "comboBox_MaterialRodzaj";
            comboBox_MaterialRodzaj.Size = new Size(395, 28);
            comboBox_MaterialRodzaj.TabIndex = 11;
            // 
            // Form_Material
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(comboBox_MaterialRodzaj);
            Controls.Add(label_MaterialRodzaj);
            Controls.Add(btn_MaterialPotwierdz);
            Controls.Add(label_DodajUsun);
            Controls.Add(comboBox_MaterialLista);
            Controls.Add(btn_UsunMat);
            Controls.Add(btn_EdytujMat);
            Controls.Add(btn_DodajMaterial);
            Controls.Add(textBox_DodajOpisMat);
            Controls.Add(label_OpisMat);
            Controls.Add(textBox_DodajNazweMat);
            Controls.Add(label_NazwaMat);
            Margin = new Padding(3, 4, 3, 4);
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
        private ComboBox comboBox_MaterialLista;
        private Label label_DodajUsun;
        private Button btn_MaterialPotwierdz;
        private Label label_MaterialRodzaj;
        private ComboBox comboBox_MaterialRodzaj;
    }
}