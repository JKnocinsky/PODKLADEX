namespace PodkladexApp
{
    partial class Form_DodajMaszyne
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
            txtbox_Nazwa = new TextBox();
            label_tytul = new Label();
            label2 = new Label();
            label3 = new Label();
            txtbox_uwagi = new TextBox();
            dtp_dataZakup = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            dtp_dataUruch = new DateTimePicker();
            label6 = new Label();
            dtp_dataWyl = new DateTimePicker();
            btn_funkcja = new Button();
            SuspendLayout();
            // 
            // txtbox_Nazwa
            // 
            txtbox_Nazwa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtbox_Nazwa.Location = new Point(60, 102);
            txtbox_Nazwa.Name = "txtbox_Nazwa";
            txtbox_Nazwa.Size = new Size(289, 29);
            txtbox_Nazwa.TabIndex = 0;
            // 
            // label_tytul
            // 
            label_tytul.AutoSize = true;
            label_tytul.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_tytul.Location = new Point(86, 9);
            label_tytul.Name = "label_tytul";
            label_tytul.Size = new Size(236, 45);
            label_tytul.TabIndex = 1;
            label_tytul.Text = "Dodaj Maszynę";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(60, 78);
            label2.Name = "label2";
            label2.Size = new Size(57, 21);
            label2.TabIndex = 2;
            label2.Text = "Nazwa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(60, 436);
            label3.Name = "label3";
            label3.Size = new Size(54, 21);
            label3.TabIndex = 4;
            label3.Text = "Uwagi";
            // 
            // txtbox_uwagi
            // 
            txtbox_uwagi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtbox_uwagi.Location = new Point(60, 460);
            txtbox_uwagi.Name = "txtbox_uwagi";
            txtbox_uwagi.Size = new Size(289, 29);
            txtbox_uwagi.TabIndex = 3;
            // 
            // dtp_dataZakup
            // 
            dtp_dataZakup.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dtp_dataZakup.Location = new Point(60, 196);
            dtp_dataZakup.Name = "dtp_dataZakup";
            dtp_dataZakup.Size = new Size(289, 23);
            dtp_dataZakup.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(60, 172);
            label4.Name = "label4";
            label4.Size = new Size(96, 21);
            label4.TabIndex = 6;
            label4.Text = "Data zakupu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(60, 260);
            label5.Name = "label5";
            label5.Size = new Size(142, 21);
            label5.TabIndex = 8;
            label5.Text = "Data uruchomienia";
            // 
            // dtp_dataUruch
            // 
            dtp_dataUruch.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dtp_dataUruch.Location = new Point(60, 284);
            dtp_dataUruch.Name = "dtp_dataUruch";
            dtp_dataUruch.Size = new Size(289, 23);
            dtp_dataUruch.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label6.Location = new Point(60, 348);
            label6.Name = "label6";
            label6.Size = new Size(121, 21);
            label6.TabIndex = 10;
            label6.Text = "Data wyłączenia";
            // 
            // dtp_dataWyl
            // 
            dtp_dataWyl.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dtp_dataWyl.Location = new Point(60, 372);
            dtp_dataWyl.Name = "dtp_dataWyl";
            dtp_dataWyl.Size = new Size(289, 23);
            dtp_dataWyl.TabIndex = 9;
            // 
            // btn_funkcja
            // 
            btn_funkcja.Location = new Point(125, 523);
            btn_funkcja.Name = "btn_funkcja";
            btn_funkcja.Size = new Size(139, 34);
            btn_funkcja.TabIndex = 11;
            btn_funkcja.Text = "Zatwierdź";
            btn_funkcja.UseVisualStyleBackColor = true;
            btn_funkcja.Click += btn_funkcja_Click;
            // 
            // Form_DodajMaszyne
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 573);
            Controls.Add(btn_funkcja);
            Controls.Add(label6);
            Controls.Add(dtp_dataWyl);
            Controls.Add(label5);
            Controls.Add(dtp_dataUruch);
            Controls.Add(label4);
            Controls.Add(dtp_dataZakup);
            Controls.Add(label3);
            Controls.Add(txtbox_uwagi);
            Controls.Add(label2);
            Controls.Add(label_tytul);
            Controls.Add(txtbox_Nazwa);
            Name = "Form_DodajMaszyne";
            Text = "Form_DodajMaszyne";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbox_Nazwa;
        private Label label_tytul;
        private Label label2;
        private Label label3;
        private TextBox txtbox_uwagi;
        private DateTimePicker dtp_dataZakup;
        private Label label4;
        private Label label5;
        private DateTimePicker dtp_dataUruch;
        private Label label6;
        private DateTimePicker dtp_dataWyl;
        private Button btn_funkcja;
    }
}