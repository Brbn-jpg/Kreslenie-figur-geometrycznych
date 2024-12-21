namespace ProjektNr3Kuźnicki61961
{
    partial class LaboratoriumNr3
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
            this.pbRysownica = new System.Windows.Forms.PictureBox();
            this.gbWyborKrzywej = new System.Windows.Forms.GroupBox();
            this.btnKolorWypelnieniaTrojkata = new System.Windows.Forms.Button();
            this.NumUD_PoziomRekurencji = new System.Windows.Forms.NumericUpDown();
            this.lblPoziomRekurencji = new System.Windows.Forms.Label();
            this.rdbTrojkatSierpinskiego = new System.Windows.Forms.RadioButton();
            this.btnKolorWypelnienia = new System.Windows.Forms.Button();
            this.numUD_LiczbaKatow = new System.Windows.Forms.NumericUpDown();
            this.lblLiczbaKatow = new System.Windows.Forms.Label();
            this.rdbWielokatWypelniony = new System.Windows.Forms.RadioButton();
            this.rdbWielokatForemny = new System.Windows.Forms.RadioButton();
            this.rdbLiniaKreslonaMysza = new System.Windows.Forms.RadioButton();
            this.rdbLiniaProsta = new System.Windows.Forms.RadioButton();
            this.rdbPunkt = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).BeginInit();
            this.gbWyborKrzywej.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_PoziomRekurencji)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_LiczbaKatow)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRysownica
            // 
            this.pbRysownica.Location = new System.Drawing.Point(3, 67);
            this.pbRysownica.Name = "pbRysownica";
            this.pbRysownica.Size = new System.Drawing.Size(774, 550);
            this.pbRysownica.TabIndex = 0;
            this.pbRysownica.TabStop = false;
            this.pbRysownica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbRysownica_MouseDown);
            this.pbRysownica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbRysownica_MouseMove);
            this.pbRysownica.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbRysownica_MouseUp);
            // 
            // gbWyborKrzywej
            // 
            this.gbWyborKrzywej.Controls.Add(this.btnKolorWypelnieniaTrojkata);
            this.gbWyborKrzywej.Controls.Add(this.NumUD_PoziomRekurencji);
            this.gbWyborKrzywej.Controls.Add(this.lblPoziomRekurencji);
            this.gbWyborKrzywej.Controls.Add(this.rdbTrojkatSierpinskiego);
            this.gbWyborKrzywej.Controls.Add(this.btnKolorWypelnienia);
            this.gbWyborKrzywej.Controls.Add(this.numUD_LiczbaKatow);
            this.gbWyborKrzywej.Controls.Add(this.lblLiczbaKatow);
            this.gbWyborKrzywej.Controls.Add(this.rdbWielokatWypelniony);
            this.gbWyborKrzywej.Controls.Add(this.rdbWielokatForemny);
            this.gbWyborKrzywej.Controls.Add(this.rdbLiniaKreslonaMysza);
            this.gbWyborKrzywej.Controls.Add(this.rdbLiniaProsta);
            this.gbWyborKrzywej.Controls.Add(this.rdbPunkt);
            this.gbWyborKrzywej.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbWyborKrzywej.Location = new System.Drawing.Point(803, 67);
            this.gbWyborKrzywej.Name = "gbWyborKrzywej";
            this.gbWyborKrzywej.Size = new System.Drawing.Size(241, 550);
            this.gbWyborKrzywej.TabIndex = 1;
            this.gbWyborKrzywej.TabStop = false;
            this.gbWyborKrzywej.Text = "Wybierz (zaznacz) odpowiednią kontrolkę RadioButton";
            // 
            // btnKolorWypelnieniaTrojkata
            // 
            this.btnKolorWypelnieniaTrojkata.Location = new System.Drawing.Point(119, 378);
            this.btnKolorWypelnieniaTrojkata.Name = "btnKolorWypelnieniaTrojkata";
            this.btnKolorWypelnieniaTrojkata.Size = new System.Drawing.Size(106, 52);
            this.btnKolorWypelnieniaTrojkata.TabIndex = 11;
            this.btnKolorWypelnieniaTrojkata.Text = "Kolor \r\nwypełnienia";
            this.btnKolorWypelnieniaTrojkata.UseVisualStyleBackColor = true;
            this.btnKolorWypelnieniaTrojkata.Visible = false;
            this.btnKolorWypelnieniaTrojkata.Click += new System.EventHandler(this.btnKolorWypelnieniaTrojkata_Click);
            // 
            // NumUD_PoziomRekurencji
            // 
            this.NumUD_PoziomRekurencji.Location = new System.Drawing.Point(135, 343);
            this.NumUD_PoziomRekurencji.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumUD_PoziomRekurencji.Name = "NumUD_PoziomRekurencji";
            this.NumUD_PoziomRekurencji.Size = new System.Drawing.Size(55, 29);
            this.NumUD_PoziomRekurencji.TabIndex = 10;
            this.NumUD_PoziomRekurencji.TabStop = false;
            this.NumUD_PoziomRekurencji.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumUD_PoziomRekurencji.Visible = false;
            // 
            // lblPoziomRekurencji
            // 
            this.lblPoziomRekurencji.AutoSize = true;
            this.lblPoziomRekurencji.Location = new System.Drawing.Point(131, 298);
            this.lblPoziomRekurencji.Name = "lblPoziomRekurencji";
            this.lblPoziomRekurencji.Size = new System.Drawing.Size(82, 42);
            this.lblPoziomRekurencji.TabIndex = 9;
            this.lblPoziomRekurencji.Text = "Poziom\r\nrekurencji";
            this.lblPoziomRekurencji.Visible = false;
            // 
            // rdbTrojkatSierpinskiego
            // 
            this.rdbTrojkatSierpinskiego.AutoSize = true;
            this.rdbTrojkatSierpinskiego.Location = new System.Drawing.Point(6, 326);
            this.rdbTrojkatSierpinskiego.Name = "rdbTrojkatSierpinskiego";
            this.rdbTrojkatSierpinskiego.Size = new System.Drawing.Size(128, 46);
            this.rdbTrojkatSierpinskiego.TabIndex = 8;
            this.rdbTrojkatSierpinskiego.TabStop = true;
            this.rdbTrojkatSierpinskiego.Text = "Trójkąt \r\nSierpińskiego";
            this.rdbTrojkatSierpinskiego.UseVisualStyleBackColor = true;
            this.rdbTrojkatSierpinskiego.CheckedChanged += new System.EventHandler(this.rdbTrojkatSierpinskiego_CheckedChanged);
            // 
            // btnKolorWypelnienia
            // 
            this.btnKolorWypelnienia.Location = new System.Drawing.Point(119, 236);
            this.btnKolorWypelnienia.Name = "btnKolorWypelnienia";
            this.btnKolorWypelnienia.Size = new System.Drawing.Size(106, 52);
            this.btnKolorWypelnienia.TabIndex = 7;
            this.btnKolorWypelnienia.Text = "Kolor \r\nwypełnienia";
            this.btnKolorWypelnienia.UseVisualStyleBackColor = true;
            this.btnKolorWypelnienia.Visible = false;
            this.btnKolorWypelnienia.Click += new System.EventHandler(this.btnKolorWypelnienia_Click);
            // 
            // numUD_LiczbaKatow
            // 
            this.numUD_LiczbaKatow.Location = new System.Drawing.Point(135, 198);
            this.numUD_LiczbaKatow.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUD_LiczbaKatow.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numUD_LiczbaKatow.Name = "numUD_LiczbaKatow";
            this.numUD_LiczbaKatow.Size = new System.Drawing.Size(55, 29);
            this.numUD_LiczbaKatow.TabIndex = 6;
            this.numUD_LiczbaKatow.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numUD_LiczbaKatow.Visible = false;
            // 
            // lblLiczbaKatow
            // 
            this.lblLiczbaKatow.AutoSize = true;
            this.lblLiczbaKatow.Location = new System.Drawing.Point(115, 174);
            this.lblLiczbaKatow.Name = "lblLiczbaKatow";
            this.lblLiczbaKatow.Size = new System.Drawing.Size(110, 21);
            this.lblLiczbaKatow.TabIndex = 5;
            this.lblLiczbaKatow.Text = "Liczba kątów";
            this.lblLiczbaKatow.Visible = false;
            // 
            // rdbWielokatWypelniony
            // 
            this.rdbWielokatWypelniony.AutoSize = true;
            this.rdbWielokatWypelniony.Location = new System.Drawing.Point(6, 236);
            this.rdbWielokatWypelniony.Name = "rdbWielokatWypelniony";
            this.rdbWielokatWypelniony.Size = new System.Drawing.Size(113, 46);
            this.rdbWielokatWypelniony.TabIndex = 4;
            this.rdbWielokatWypelniony.TabStop = true;
            this.rdbWielokatWypelniony.Text = "Wielokąt\r\nwypełniony";
            this.rdbWielokatWypelniony.UseVisualStyleBackColor = true;
            this.rdbWielokatWypelniony.CheckedChanged += new System.EventHandler(this.rdbWielokatWypelniony_CheckedChanged);
            // 
            // rdbWielokatForemny
            // 
            this.rdbWielokatForemny.AutoSize = true;
            this.rdbWielokatForemny.Location = new System.Drawing.Point(7, 174);
            this.rdbWielokatForemny.Name = "rdbWielokatForemny";
            this.rdbWielokatForemny.Size = new System.Drawing.Size(93, 46);
            this.rdbWielokatForemny.TabIndex = 3;
            this.rdbWielokatForemny.TabStop = true;
            this.rdbWielokatForemny.Text = "Wielokąt\r\nforemny";
            this.rdbWielokatForemny.UseVisualStyleBackColor = true;
            this.rdbWielokatForemny.CheckedChanged += new System.EventHandler(this.rdbWielokatForemny_CheckedChanged);
            // 
            // rdbLiniaKreslonaMysza
            // 
            this.rdbLiniaKreslonaMysza.AutoSize = true;
            this.rdbLiniaKreslonaMysza.Location = new System.Drawing.Point(7, 143);
            this.rdbLiniaKreslonaMysza.Name = "rdbLiniaKreslonaMysza";
            this.rdbLiniaKreslonaMysza.Size = new System.Drawing.Size(183, 25);
            this.rdbLiniaKreslonaMysza.TabIndex = 2;
            this.rdbLiniaKreslonaMysza.TabStop = true;
            this.rdbLiniaKreslonaMysza.Text = "Linia kreślona myszą";
            this.rdbLiniaKreslonaMysza.UseVisualStyleBackColor = true;
            // 
            // rdbLiniaProsta
            // 
            this.rdbLiniaProsta.AutoSize = true;
            this.rdbLiniaProsta.Location = new System.Drawing.Point(7, 111);
            this.rdbLiniaProsta.Name = "rdbLiniaProsta";
            this.rdbLiniaProsta.Size = new System.Drawing.Size(116, 25);
            this.rdbLiniaProsta.TabIndex = 1;
            this.rdbLiniaProsta.Text = "Linia prosta";
            this.rdbLiniaProsta.UseVisualStyleBackColor = true;
            // 
            // rdbPunkt
            // 
            this.rdbPunkt.AutoSize = true;
            this.rdbPunkt.Checked = true;
            this.rdbPunkt.Location = new System.Drawing.Point(7, 79);
            this.rdbPunkt.Name = "rdbPunkt";
            this.rdbPunkt.Size = new System.Drawing.Size(71, 25);
            this.rdbPunkt.TabIndex = 0;
            this.rdbPunkt.TabStop = true;
            this.rdbPunkt.Text = "Punkt";
            this.rdbPunkt.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(77, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Współrzędne (X i Y) aktualnego położenia myszy:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblX.Location = new System.Drawing.Point(403, 45);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(20, 19);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "X";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblY.Location = new System.Drawing.Point(446, 45);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(20, 19);
            this.lblY.TabIndex = 4;
            this.lblY.Text = "Y";
            // 
            // LaboratoriumNr3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 641);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbWyborKrzywej);
            this.Controls.Add(this.pbRysownica);
            this.Name = "LaboratoriumNr3";
            this.Text = "LaboratoriumNr3";
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).EndInit();
            this.gbWyborKrzywej.ResumeLayout(false);
            this.gbWyborKrzywej.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_PoziomRekurencji)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_LiczbaKatow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRysownica;
        private System.Windows.Forms.GroupBox gbWyborKrzywej;
        private System.Windows.Forms.RadioButton rdbPunkt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.RadioButton rdbLiniaProsta;
        private System.Windows.Forms.RadioButton rdbLiniaKreslonaMysza;
        private System.Windows.Forms.RadioButton rdbWielokatWypelniony;
        private System.Windows.Forms.RadioButton rdbWielokatForemny;
        private System.Windows.Forms.NumericUpDown numUD_LiczbaKatow;
        private System.Windows.Forms.Label lblLiczbaKatow;
        private System.Windows.Forms.Button btnKolorWypelnienia;
        private System.Windows.Forms.NumericUpDown NumUD_PoziomRekurencji;
        private System.Windows.Forms.Label lblPoziomRekurencji;
        private System.Windows.Forms.RadioButton rdbTrojkatSierpinskiego;
        private System.Windows.Forms.Button btnKolorWypelnieniaTrojkata;
    }
}