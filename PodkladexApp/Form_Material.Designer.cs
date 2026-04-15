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
            SuspendLayout();
            // 
            // label_NazwaMat
            // 
            label_NazwaMat.AutoSize = true;
            label_NazwaMat.Location = new Point(260, 53);
            label_NazwaMat.Name = "label_NazwaMat";
            label_NazwaMat.Size = new Size(101, 15);
            label_NazwaMat.TabIndex = 0;
            label_NazwaMat.Text = "Nazwa materiału: ";
            // 
            // textBox_DodajNazweMat
            // 
            textBox_DodajNazweMat.Location = new Point(381, 50);
            textBox_DodajNazweMat.Name = "textBox_DodajNazweMat";
            textBox_DodajNazweMat.Size = new Size(269, 23);
            textBox_DodajNazweMat.TabIndex = 1;
            // 
            // label_OpisMat
            // 
            label_OpisMat.AutoSize = true;
            label_OpisMat.Location = new Point(260, 109);
            label_OpisMat.Name = "label_OpisMat";
            label_OpisMat.Size = new Size(87, 15);
            label_OpisMat.TabIndex = 2;
            label_OpisMat.Text = "Opis materiału:";
            // 
            // textBox_DodajOpisMat
            // 
            textBox_DodajOpisMat.Location = new Point(381, 106);
            textBox_DodajOpisMat.Name = "textBox_DodajOpisMat";
            textBox_DodajOpisMat.Size = new Size(269, 23);
            textBox_DodajOpisMat.TabIndex = 3;
            // 
            // btn_DodajMaterial
            // 
            btn_DodajMaterial.Location = new Point(58, 63);
            btn_DodajMaterial.Name = "btn_DodajMaterial";
            btn_DodajMaterial.Size = new Size(144, 50);
            btn_DodajMaterial.TabIndex = 4;
            btn_DodajMaterial.Text = "Dodaj Material";
            btn_DodajMaterial.UseVisualStyleBackColor = true;
            // 
            // btn_EdytujMat
            // 
            btn_EdytujMat.Location = new Point(58, 177);
            btn_EdytujMat.Name = "btn_EdytujMat";
            btn_EdytujMat.Size = new Size(144, 50);
            btn_EdytujMat.TabIndex = 5;
            btn_EdytujMat.Text = "Edytuj Materiał";
            btn_EdytujMat.UseVisualStyleBackColor = true;
            // 
            // Form_Material
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}