using ProjektNr3Kuźnicki61961;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr3Kuźnicki61961
{
    public partial class KokpitProjektuNr3 : Form
    {
        public KokpitProjektuNr3()
        {
            InitializeComponent();
        }

        private void btnLaboratoriumNr3_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
                if(Formularz.Name == "LaboratoriumNr3")
                {
                    this.Hide();
                    Formularz.Show();
                    return;
                }
            // utworzenie egzemplarza formularza: LaboratoriumNr3
            LaboratoriumNr3 FormularzLaboratoryjny = new LaboratoriumNr3();
            this.Hide();
            FormularzLaboratoryjny.Show();
        }

        private void btnProjektIndywidualnyNr3_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
                if (Formularz.Name == "ProjektNr3")
                {
                    this.Hide();
                    Formularz.Show();
                    return;
                }
            ProjektNr3 ProjektIndywidualny = new ProjektNr3();
            this.Hide();
            ProjektIndywidualny.Show();
        }

        private void KokpitProjektuNr3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Czy napewno chcesz zamknac formularz glowny i zakonczyc dzialanie programu", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (OknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;
                Application.ExitThread();
            }
            e.Cancel = true;
        }
    }
}
