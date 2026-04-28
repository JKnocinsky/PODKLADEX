namespace PodkladexApp
{
    partial class Form_KadryFinanse
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
            button_listaosob = new Button();
            button_urlopy = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            panel_kadryfinanse = new Panel();
            SuspendLayout();
            // 
            // button_listaosob
            // 
            button_listaosob.Location = new Point(12, 3);
            button_listaosob.Name = "button_listaosob";
            button_listaosob.Size = new Size(182, 81);
            button_listaosob.TabIndex = 0;
            button_listaosob.Text = "Lista osób";
            button_listaosob.UseVisualStyleBackColor = true;
            button_listaosob.Click += button_listaosob_Click;
            // 
            // button_urlopy
            // 
            button_urlopy.Location = new Point(12, 94);
            button_urlopy.Name = "button_urlopy";
            button_urlopy.Size = new Size(182, 81);
            button_urlopy.TabIndex = 1;
            button_urlopy.Text = "Urlopy";
            button_urlopy.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(12, 181);
            button3.Name = "button3";
            button3.Size = new Size(182, 81);
            button3.TabIndex = 2;
            button3.Text = "Szkolenia";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(12, 268);
            button4.Name = "button4";
            button4.Size = new Size(182, 81);
            button4.TabIndex = 3;
            button4.Text = "Badania";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(12, 355);
            button5.Name = "button5";
            button5.Size = new Size(182, 81);
            button5.TabIndex = 4;
            button5.Text = "Umowy";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(12, 448);
            button6.Name = "button6";
            button6.Size = new Size(182, 81);
            button6.TabIndex = 5;
            button6.Text = "Bilans zysków i strat";
            button6.UseVisualStyleBackColor = true;
            // 
            // panel_kadryfinanse
            // 
            panel_kadryfinanse.BackColor = SystemColors.ButtonHighlight;
            panel_kadryfinanse.Location = new Point(212, 3);
            panel_kadryfinanse.Name = "panel_kadryfinanse";
            panel_kadryfinanse.Size = new Size(953, 950);
            panel_kadryfinanse.TabIndex = 6;
            // 
            // Form_KadryFinanse
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1173, 973);
            Controls.Add(panel_kadryfinanse);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button_urlopy);
            Controls.Add(button_listaosob);
            Name = "Form_KadryFinanse";
            Text = "Kadry i finanse";
            ResumeLayout(false);
        }

        #endregion

        private Button button_listaosob;
        private Button button_urlopy;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Panel panel_kadryfinanse;
    }
}