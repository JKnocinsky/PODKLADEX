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
            cmb_typ = new ComboBox();
            label1 = new Label();
            cb_dataUr = new CheckBox();
            cb_dataWy = new CheckBox();
            cb_dataZa = new CheckBox();
            SuspendLayout();
            // 
            // txtbox_Nazwa
            // 
            txtbox_Nazwa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtbox_Nazwa.Location = new Point(112, 155);
            txtbox_Nazwa.Margin = new Padding(5, 6, 5, 6);
            txtbox_Nazwa.Name = "txtbox_Nazwa";
            txtbox_Nazwa.Size = new Size(534, 34);
            txtbox_Nazwa.TabIndex = 0;
            // 
            // label_tytul
            // 
            label_tytul.AutoSize = true;
            label_tytul.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label_tytul.Location = new Point(143, -6);
            label_tytul.Margin = new Padding(5, 0, 5, 0);
            label_tytul.Name = "label_tytul";
            label_tytul.Size = new Size(293, 54);
            label_tytul.TabIndex = 1;
            label_tytul.Text = "Dodaj Maszynę";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(112, 105);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 28);
            label2.TabIndex = 2;
            label2.Text = "Nazwa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(117, 866);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(67, 28);
            label3.TabIndex = 4;
            label3.Text = "Uwagi";
            // 
            // txtbox_uwagi
            // 
            txtbox_uwagi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txtbox_uwagi.Location = new Point(112, 916);
            txtbox_uwagi.Margin = new Padding(5, 6, 5, 6);
            txtbox_uwagi.Name = "txtbox_uwagi";
            txtbox_uwagi.Size = new Size(534, 34);
            txtbox_uwagi.TabIndex = 3;
            // 
            // dtp_dataZakup
            // 
            dtp_dataZakup.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dtp_dataZakup.Location = new Point(112, 474);
            dtp_dataZakup.Margin = new Padding(5, 6, 5, 6);
            dtp_dataZakup.Name = "dtp_dataZakup";
            dtp_dataZakup.Size = new Size(534, 39);
            dtp_dataZakup.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(112, 425);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(121, 28);
            label4.TabIndex = 6;
            label4.Text = "Data zakupu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(112, 572);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(177, 28);
            label5.TabIndex = 8;
            label5.Text = "Data uruchomienia";
            // 
            // dtp_dataUruch
            // 
            dtp_dataUruch.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dtp_dataUruch.Location = new Point(112, 622);
            dtp_dataUruch.Margin = new Padding(5, 6, 5, 6);
            dtp_dataUruch.Name = "dtp_dataUruch";
            dtp_dataUruch.Size = new Size(534, 39);
            dtp_dataUruch.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label6.Location = new Point(112, 719);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(151, 28);
            label6.TabIndex = 10;
            label6.Text = "Data wyłączenia";
            // 
            // dtp_dataWyl
            // 
            dtp_dataWyl.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dtp_dataWyl.Location = new Point(112, 769);
            dtp_dataWyl.Margin = new Padding(5, 6, 5, 6);
            dtp_dataWyl.Name = "dtp_dataWyl";
            dtp_dataWyl.Size = new Size(534, 39);
            dtp_dataWyl.TabIndex = 9;
            // 
            // btn_funkcja
            // 
            btn_funkcja.Location = new Point(252, 1074);
            btn_funkcja.Margin = new Padding(5, 6, 5, 6);
            btn_funkcja.Name = "btn_funkcja";
            btn_funkcja.Size = new Size(258, 70);
            btn_funkcja.TabIndex = 11;
            btn_funkcja.Text = "Zatwierdź";
            btn_funkcja.UseVisualStyleBackColor = true;
            btn_funkcja.Click += btn_Zapisz_Click;
            // 
            // cmb_typ
            // 
            cmb_typ.Font = new Font("Segoe UI", 12F);
            cmb_typ.FormattingEnabled = true;
            cmb_typ.Location = new Point(112, 313);
            cmb_typ.Margin = new Padding(5, 5, 5, 5);
            cmb_typ.Name = "cmb_typ";
            cmb_typ.Size = new Size(534, 36);
            cmb_typ.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(112, 265);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 28);
            label1.TabIndex = 13;
            label1.Text = "Typ";
            // 
            // cb_dataUr
            // 
            cb_dataUr.Checked = true;
            cb_dataUr.CheckState = CheckState.Checked;
            cb_dataUr.Location = new Point(58, 622);
            cb_dataUr.Margin = new Padding(5, 5, 5, 5);
            cb_dataUr.Name = "cb_dataUr";
            cb_dataUr.Size = new Size(44, 42);
            cb_dataUr.TabIndex = 14;
            cb_dataUr.UseVisualStyleBackColor = true;
            // 
            // cb_dataWy
            // 
            cb_dataWy.Checked = true;
            cb_dataWy.CheckState = CheckState.Checked;
            cb_dataWy.Location = new Point(58, 769);
            cb_dataWy.Margin = new Padding(5, 5, 5, 5);
            cb_dataWy.Name = "cb_dataWy";
            cb_dataWy.Size = new Size(44, 42);
            cb_dataWy.TabIndex = 15;
            cb_dataWy.UseVisualStyleBackColor = true;
            // 
            // cb_dataZa
            // 
            cb_dataZa.Checked = true;
            cb_dataZa.CheckState = CheckState.Checked;
            cb_dataZa.Location = new Point(58, 474);
            cb_dataZa.Margin = new Padding(5, 5, 5, 5);
            cb_dataZa.Name = "cb_dataZa";
            cb_dataZa.Size = new Size(44, 42);
            cb_dataZa.TabIndex = 16;
            cb_dataZa.UseVisualStyleBackColor = true;
            // 
            // Form_DodajMaszyne
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 1184);
            Controls.Add(cb_dataZa);
            Controls.Add(cb_dataWy);
            Controls.Add(cb_dataUr);
            Controls.Add(label1);
            Controls.Add(cmb_typ);
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
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5, 6, 5, 6);
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
        private ComboBox cmb_typ;
        private Label label1;
        private CheckBox cb_dataUr;
        private CheckBox cb_dataWy;
        private CheckBox cb_dataZa;
    }
}