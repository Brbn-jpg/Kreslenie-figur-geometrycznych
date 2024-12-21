namespace ProjektNr3Kuźnicki61961
{
    partial class KokpitProjektuNr3
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
            this.btnLaboratoriumNr3 = new System.Windows.Forms.Button();
            this.btnProjektIndywidualnyNr3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLaboratoriumNr3
            // 
            this.btnLaboratoriumNr3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLaboratoriumNr3.Location = new System.Drawing.Point(157, 197);
            this.btnLaboratoriumNr3.Name = "btnLaboratoriumNr3";
            this.btnLaboratoriumNr3.Size = new System.Drawing.Size(187, 86);
            this.btnLaboratoriumNr3.TabIndex = 0;
            this.btnLaboratoriumNr3.Text = "Laboratorium Nr3 \r\n(kreślenie krzywych geometrycznych)";
            this.btnLaboratoriumNr3.UseVisualStyleBackColor = true;
            this.btnLaboratoriumNr3.Click += new System.EventHandler(this.btnLaboratoriumNr3_Click);
            // 
            // btnProjektIndywidualnyNr3
            // 
            this.btnProjektIndywidualnyNr3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnProjektIndywidualnyNr3.Location = new System.Drawing.Point(458, 197);
            this.btnProjektIndywidualnyNr3.Name = "btnProjektIndywidualnyNr3";
            this.btnProjektIndywidualnyNr3.Size = new System.Drawing.Size(198, 86);
            this.btnProjektIndywidualnyNr3.TabIndex = 1;
            this.btnProjektIndywidualnyNr3.Text = "Projekt Indywidualny Nr3 \r\n(kreślenie figur i linii geometrycznych)";
            this.btnProjektIndywidualnyNr3.UseVisualStyleBackColor = true;
            this.btnProjektIndywidualnyNr3.Click += new System.EventHandler(this.btnProjektIndywidualnyNr3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(209, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "KOKPIT PROJEKTU Nr3\r\n(kreślenie figur, krzywych i linii geometrycznych)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // KokpitProjektuNr3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProjektIndywidualnyNr3);
            this.Controls.Add(this.btnLaboratoriumNr3);
            this.Name = "KokpitProjektuNr3";
            this.Text = "KokpitProjektuNr3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KokpitProjektuNr3_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLaboratoriumNr3;
        private System.Windows.Forms.Button btnProjektIndywidualnyNr3;
        private System.Windows.Forms.Label label1;
    }
}

