namespace PodkladexApp
{
    partial class Form_Kadry_finanse
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
            btn_Lista_osob = new Button();
            SuspendLayout();
            // 
            // btn_Lista_osob
            // 
            btn_Lista_osob.Location = new Point(29, 29);
            btn_Lista_osob.Name = "btn_Lista_osob";
            btn_Lista_osob.Size = new Size(75, 23);
            btn_Lista_osob.TabIndex = 0;
            btn_Lista_osob.Text = "Lista Osób";
            btn_Lista_osob.UseVisualStyleBackColor = true;
            btn_Lista_osob.Click += btn_lista_Click;
            // 
            // Form_Kadry_finanse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Lista_osob);
            Name = "Form_Kadry_finanse";
            Text = "Form_Kadry_finanse";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Lista_osob;

        private void btn_lista_Click(object sender, EventArgs e)
        {
            ListaOsob formlista = new ListaOsob();
            formlista.Show();
        }
    }
}