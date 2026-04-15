namespace PodkladexApp
{
    partial class Form_ZaoLog
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
            button_Nowa_firma = new Button();
            button_Edytuj_firmy = new Button();
            SuspendLayout();
            // 
            // button_Nowa_firma
            // 
            button_Nowa_firma.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            button_Nowa_firma.Location = new Point(31, 27);
            button_Nowa_firma.Name = "button_Nowa_firma";
            button_Nowa_firma.Size = new Size(236, 67);
            button_Nowa_firma.TabIndex = 0;
            button_Nowa_firma.Text = "Dodaj nową firmę";
            button_Nowa_firma.UseVisualStyleBackColor = true;
            button_Nowa_firma.Click += button_Nowa_firma_Click_1;
            // 
            // button_Edytuj_firmy
            // 
            button_Edytuj_firmy.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            button_Edytuj_firmy.Location = new Point(315, 27);
            button_Edytuj_firmy.Name = "button_Edytuj_firmy";
            button_Edytuj_firmy.Size = new Size(236, 67);
            button_Edytuj_firmy.TabIndex = 1;
            button_Edytuj_firmy.Text = "Edytuj dane firmy";
            button_Edytuj_firmy.UseVisualStyleBackColor = true;
            button_Edytuj_firmy.Click += button_Edytuj_firmy_Click;
            // 
            // Form_ZaoLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_Edytuj_firmy);
            Controls.Add(button_Nowa_firma);
            Name = "Form_ZaoLog";
            Text = "Form_ZaoLog";
            ResumeLayout(false);
        }

        #endregion

        private Button button_Nowa_firma;
        private Button button_Edytuj_firmy;
    }
}