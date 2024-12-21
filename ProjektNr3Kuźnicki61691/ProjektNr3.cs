using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr3Kuźnicki61961
{
    public partial class ProjektNr3 : Form
    {
        const ushort PromienPunktu = 2;
        Graphics JKRysownicaTymczasowa;
        Graphics Rysownica;
        Pen JKPioroTymczasowe;
        Pen JKPioro;
        SolidBrush JKPedzel;
        Point Punkt = Point.Empty;
        public ProjektNr3()
        {
            InitializeComponent();
            JKpbRysownica.Image = new Bitmap(JKpbRysownica.Width, JKpbRysownica.Height);
            Rysownica = Graphics.FromImage(JKpbRysownica.Image);
            JKPioro = new Pen(Color.Red, 1.7f);
            JKPioro.DashStyle = DashStyle.Dash;
            JKPioro.StartCap = LineCap.Round;
            JKPioro.EndCap = LineCap.Round;
            JKRysownicaTymczasowa = JKpbRysownica.CreateGraphics();
            JKPioroTymczasowe = new Pen(Color.Blue, 1.0f);
            // utworzenie egzemplarza Pedzla
            JKPedzel = new SolidBrush(Color.RoyalBlue);
        }
        struct OpisKrzywejBeziera
        {
            public Point PunktP0;
            public Point PunktP1;
            public Point PunktP2;
            public Point PunktP3;
            public ushort NumerPunktuKontrolnego;
            public ushort PromienPunktuKontrolnego;
        }
        struct OpisKrzywejKardynalnej
        {
            public ushort NumerPunktuKrzywej;
            public ushort PromienPunktuKrzywej;
            public ushort LiczbaPunktów;
            public Point[] PunktyKrzywej;

        }
        OpisKrzywejKardynalnej KrzywaKardynalna;
        // deklaracja
        // zmiennej dla KrzywejBeziera
        OpisKrzywejBeziera KrzywaBeziera;
        Font FontOpisuPunktow = new Font("Arial", 8, FontStyle.Italic);

        private void JKpbRysownica_MouseUp(object sender, MouseEventArgs e)
        {
            JKlblX.Text = e.Location.X.ToString();
            JKlblY.Text = e.Location.Y.ToString();
            int JKLewyGornyNaroznikX = (Punkt.X > e.Location.X) ? e.Location.X : Punkt.X;
            int JKLewyGornyNaroznikY = (Punkt.Y > e.Location.Y) ? e.Location.Y : Punkt.Y;
            int JKSzerokosc = Math.Abs(Punkt.X - e.Location.X);
            int JKWysokosc = Math.Abs(Punkt.Y - e.Location.Y);
            if (e.Button == MouseButtons.Left)
            {
                if (JKrdbProstokąt.Checked)
                {
                    Rysownica.DrawRectangle(JKPioro, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc);
                }
                if (JKrdbProstokątWyp.Checked)
                {
                    Rectangle rectangle = new Rectangle(JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc);
                    JKPedzel.Color = JKbtnKolorWypełnienia.BackColor;
                    Rysownica.FillRectangle(JKPedzel, rectangle);
                }
                if (JKrdbKwadrat.Checked)
                {
                    Rysownica.DrawRectangle(JKPioro, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKSzerokosc);
                }
                if (JKrdb_KwadratWyp.Checked)
                {
                    JKPedzel.Color = JKbtnKolorWypełnienia.BackColor;
                    Rectangle rectangle = new Rectangle(JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKSzerokosc);
                    Rysownica.FillRectangle(JKPedzel, rectangle);

                }
                if (JKrdbElipsa.Checked)
                {
                    Rysownica.DrawEllipse(JKPioro, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc);
                }
                if (JKrdbElipsaWyp.Checked)
                {
                    JKPedzel.Color = JKbtnKolorWypełnienia.BackColor;
                    Rysownica.FillEllipse(JKPedzel, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc);
                }
                if (JKrdbOkrag.Checked)
                {
                    Rysownica.DrawEllipse(JKPioro, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKSzerokosc);
                }
                if (JKrdbKoło.Checked)
                {
                    JKPedzel.Color = JKbtnKolorWypełnienia.BackColor;
                    Rysownica.FillEllipse(JKPedzel, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKSzerokosc);
                }
                if (JKrdbŁukElipsy.Checked)
                {
                    ushort KątPoczątkowy = (ushort)numUD_KątPoczątkowy.Value;
                    ushort KątWygięcia = (ushort)numUD_KątWygięcia.Value;
                    try
                    {
                        Rysownica.DrawArc(JKPioro, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc, KątPoczątkowy, KątWygięcia);
                    }
                    catch (ArgumentException) { }
                }
                if (JKrdbWycinekElipsy.Checked)
                {
                    ushort KątPoczątkowy = (ushort)numUD_KątPoczątkowy.Value;
                    ushort KątWygięcia = (ushort)numUD_KątWygięcia.Value;
                    try
                    {
                        Rysownica.DrawPie(JKPioro, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc, KątPoczątkowy, KątWygięcia);
                    }
                    catch (ArgumentException) { }
                }
                if (JKrdbWypełnionyWycinekElipsy.Checked)
                {
                    if (JKcboxObramowanie.Checked)
                    {
                        JKPioro.Color = JKbtnKolorObramowania.BackColor;
                        ushort KątPoczątkowy = (ushort)numUD_KątPoczątkowy.Value;
                        ushort KątWygięcia = (ushort)numUD_KątWygięcia.Value;
                        try
                        {
                            Rysownica.DrawPie(JKPioro, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc, KątPoczątkowy, KątWygięcia);
                        }
                        catch (ArgumentException) { }
                    }
                    if (JKcboxWypełnienie.Checked)
                    {
                        JKPedzel.Color = JKbtnKolorWypełnienia.BackColor;
                        ushort KątPoczątkowy = (ushort)numUD_KątPoczątkowy.Value;
                        ushort KątWygięcia = (ushort)numUD_KątWygięcia.Value;
                        try
                        {
                            Rysownica.FillPie(JKPedzel, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc, KątPoczątkowy, KątWygięcia);
                        }
                        catch (ArgumentException) { }
                    }
                }
                if (JKrdbKrzywaKardynalna.Checked)
                {
                    if (JKgbWyborKrzywej.Enabled)
                    {
                        JKgbWyborKrzywej.Enabled = false;
                        KrzywaKardynalna.LiczbaPunktów = (ushort)numUD_Punkty.Value;
                        KrzywaKardynalna.NumerPunktuKrzywej = 0;

                        KrzywaKardynalna.PromienPunktuKrzywej = 5;
                        KrzywaKardynalna.PunktyKrzywej = new Point[KrzywaKardynalna.LiczbaPunktów];

                        KrzywaKardynalna.PunktyKrzywej[0] = e.Location;
                        using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                        {
                            Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                            Rysownica.DrawString("p" + KrzywaBeziera.NumerPunktuKontrolnego.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                        }
                    }
                    else
                    {
                        KrzywaKardynalna.NumerPunktuKrzywej++;

                        switch (KrzywaKardynalna.NumerPunktuKrzywej)
                        {
                            case 1: KrzywaKardynalna.PunktyKrzywej[1] = e.Location; break;
                            case 2: KrzywaKardynalna.PunktyKrzywej[2] = e.Location; break;
                            case 3: KrzywaKardynalna.PunktyKrzywej[3] = e.Location; break;
                            case 4: KrzywaKardynalna.PunktyKrzywej[4] = e.Location; break;
                            case 5: KrzywaKardynalna.PunktyKrzywej[5] = e.Location; break;
                            case 6: KrzywaKardynalna.PunktyKrzywej[6] = e.Location; break;
                            case 7: KrzywaKardynalna.PunktyKrzywej[7] = e.Location; break;
                            case 8: KrzywaKardynalna.PunktyKrzywej[8] = e.Location; break;
                            case 9: KrzywaKardynalna.PunktyKrzywej[9] = e.Location; break;
                            case 10: KrzywaKardynalna.PunktyKrzywej[10] = e.Location; break;
                            case 11: KrzywaKardynalna.PunktyKrzywej[11] = e.Location; break;
                            case 12: KrzywaKardynalna.PunktyKrzywej[12] = e.Location; break;
                            case 13: KrzywaKardynalna.PunktyKrzywej[13] = e.Location; break;
                            case 14: KrzywaKardynalna.PunktyKrzywej[14] = e.Location; break;
                            case 15: KrzywaKardynalna.PunktyKrzywej[15] = e.Location; break;
                            case 16: KrzywaKardynalna.PunktyKrzywej[16] = e.Location; break;
                            case 17: KrzywaKardynalna.PunktyKrzywej[17] = e.Location; break;
                            case 18: KrzywaKardynalna.PunktyKrzywej[18] = e.Location; break;
                            case 19: KrzywaKardynalna.PunktyKrzywej[19] = e.Location; break;
                            case 20: KrzywaKardynalna.PunktyKrzywej[20] = e.Location; break;
                        }
                        if (KrzywaKardynalna.NumerPunktuKrzywej < KrzywaKardynalna.LiczbaPunktów - 1)
                        {
                            using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                            {
                                Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                                // wykreślenie (wymalowanie) opisu wykreślonego punktu kontrolnego
                                Rysownica.DrawString("p" + KrzywaKardynalna.NumerPunktuKrzywej.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                            {
                                Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                                Rysownica.DrawString("p" + KrzywaKardynalna.NumerPunktuKrzywej.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                            }
                            Rysownica.DrawCurve(JKPioro, KrzywaKardynalna.PunktyKrzywej);
                            JKgbWyborKrzywej.Enabled = true;
                        }
                    }
                }
                if (JKrdbZamkniętaKrzywaKardynalna.Checked)
                {
                    if (JKgbWyborKrzywej.Enabled)
                    {
                        JKgbWyborKrzywej.Enabled = false;
                        KrzywaKardynalna.LiczbaPunktów = (ushort)numUD_Punkty.Value;
                        KrzywaKardynalna.NumerPunktuKrzywej = 0;

                        KrzywaKardynalna.PromienPunktuKrzywej = 5;
                        KrzywaKardynalna.PunktyKrzywej = new Point[KrzywaKardynalna.LiczbaPunktów];

                        KrzywaKardynalna.PunktyKrzywej[0] = e.Location;
                        using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                        {
                            Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                            Rysownica.DrawString("p" + KrzywaBeziera.NumerPunktuKontrolnego.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                        }
                    }
                    else
                    {
                        KrzywaKardynalna.NumerPunktuKrzywej++;

                        switch (KrzywaKardynalna.NumerPunktuKrzywej)
                        {
                            case 1: KrzywaKardynalna.PunktyKrzywej[1] = e.Location; break;
                            case 2: KrzywaKardynalna.PunktyKrzywej[2] = e.Location; break;
                            case 3: KrzywaKardynalna.PunktyKrzywej[3] = e.Location; break;
                            case 4: KrzywaKardynalna.PunktyKrzywej[4] = e.Location; break;
                            case 5: KrzywaKardynalna.PunktyKrzywej[5] = e.Location; break;
                            case 6: KrzywaKardynalna.PunktyKrzywej[6] = e.Location; break;
                            case 7: KrzywaKardynalna.PunktyKrzywej[7] = e.Location; break;
                            case 8: KrzywaKardynalna.PunktyKrzywej[8] = e.Location; break;
                            case 9: KrzywaKardynalna.PunktyKrzywej[9] = e.Location; break;
                            case 10: KrzywaKardynalna.PunktyKrzywej[10] = e.Location; break;
                            case 11: KrzywaKardynalna.PunktyKrzywej[11] = e.Location; break;
                            case 12: KrzywaKardynalna.PunktyKrzywej[12] = e.Location; break;
                            case 13: KrzywaKardynalna.PunktyKrzywej[13] = e.Location; break;
                            case 14: KrzywaKardynalna.PunktyKrzywej[14] = e.Location; break;
                            case 15: KrzywaKardynalna.PunktyKrzywej[15] = e.Location; break;
                            case 16: KrzywaKardynalna.PunktyKrzywej[16] = e.Location; break;
                            case 17: KrzywaKardynalna.PunktyKrzywej[17] = e.Location; break;
                            case 18: KrzywaKardynalna.PunktyKrzywej[18] = e.Location; break;
                            case 19: KrzywaKardynalna.PunktyKrzywej[19] = e.Location; break;
                            case 20: KrzywaKardynalna.PunktyKrzywej[20] = e.Location; break;
                        }
                        if (KrzywaKardynalna.NumerPunktuKrzywej < KrzywaKardynalna.LiczbaPunktów - 1)
                        {
                            using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                            {
                                Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                                // wykreślenie (wymalowanie) opisu wykreślonego punktu kontrolnego
                                Rysownica.DrawString("p" + KrzywaKardynalna.NumerPunktuKrzywej.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                            {
                                Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                                Rysownica.DrawString("p" + KrzywaKardynalna.NumerPunktuKrzywej.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                            }
                            Rysownica.DrawClosedCurve(JKPioro, KrzywaKardynalna.PunktyKrzywej);
                            JKgbWyborKrzywej.Enabled = true;
                        }
                    }
                }
                if (JKrdbWypZamkKrzywaKardynalna.Checked)
                {
                    if (JKgbWyborKrzywej.Enabled)
                    {
                        JKgbWyborKrzywej.Enabled = false;
                        KrzywaKardynalna.LiczbaPunktów = (ushort)numUD_Punkty.Value;
                        KrzywaKardynalna.NumerPunktuKrzywej = 0;

                        KrzywaKardynalna.PromienPunktuKrzywej = 5;
                        KrzywaKardynalna.PunktyKrzywej = new Point[KrzywaKardynalna.LiczbaPunktów];

                        KrzywaKardynalna.PunktyKrzywej[0] = e.Location;
                        using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                        {
                            Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                            Rysownica.DrawString("p" + KrzywaBeziera.NumerPunktuKontrolnego.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                        }
                    }
                    else
                    {
                        KrzywaKardynalna.NumerPunktuKrzywej++;

                        switch (KrzywaKardynalna.NumerPunktuKrzywej)
                        {
                            case 1: KrzywaKardynalna.PunktyKrzywej[1] = e.Location; break;
                            case 2: KrzywaKardynalna.PunktyKrzywej[2] = e.Location; break;
                            case 3: KrzywaKardynalna.PunktyKrzywej[3] = e.Location; break;
                            case 4: KrzywaKardynalna.PunktyKrzywej[4] = e.Location; break;
                            case 5: KrzywaKardynalna.PunktyKrzywej[5] = e.Location; break;
                            case 6: KrzywaKardynalna.PunktyKrzywej[6] = e.Location; break;
                            case 7: KrzywaKardynalna.PunktyKrzywej[7] = e.Location; break;
                            case 8: KrzywaKardynalna.PunktyKrzywej[8] = e.Location; break;
                            case 9: KrzywaKardynalna.PunktyKrzywej[9] = e.Location; break;
                            case 10: KrzywaKardynalna.PunktyKrzywej[10] = e.Location; break;
                            case 11: KrzywaKardynalna.PunktyKrzywej[11] = e.Location; break;
                            case 12: KrzywaKardynalna.PunktyKrzywej[12] = e.Location; break;
                            case 13: KrzywaKardynalna.PunktyKrzywej[13] = e.Location; break;
                            case 14: KrzywaKardynalna.PunktyKrzywej[14] = e.Location; break;
                            case 15: KrzywaKardynalna.PunktyKrzywej[15] = e.Location; break;
                            case 16: KrzywaKardynalna.PunktyKrzywej[16] = e.Location; break;
                            case 17: KrzywaKardynalna.PunktyKrzywej[17] = e.Location; break;
                            case 18: KrzywaKardynalna.PunktyKrzywej[18] = e.Location; break;
                            case 19: KrzywaKardynalna.PunktyKrzywej[19] = e.Location; break;
                            case 20: KrzywaKardynalna.PunktyKrzywej[20] = e.Location; break;
                        }
                        if (KrzywaKardynalna.NumerPunktuKrzywej < KrzywaKardynalna.LiczbaPunktów - 1)
                        {
                            using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                            {
                                Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                                // wykreślenie (wymalowanie) opisu wykreślonego punktu kontrolnego
                                Rysownica.DrawString("p" + KrzywaKardynalna.NumerPunktuKrzywej.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                            {
                                Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                                Rysownica.DrawString("p" + KrzywaKardynalna.NumerPunktuKrzywej.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                            }
                            JKPedzel.Color = JKbtnKolorWypełnienia.BackColor;
                            Rysownica.FillClosedCurve(JKPedzel, KrzywaKardynalna.PunktyKrzywej);
                            JKgbWyborKrzywej.Enabled = true;
                        }
                    }
                }
                if (JKrdbWypObrZamkKrzywaKardynalna.Checked)
                {
                    if (JKgbWyborKrzywej.Enabled)
                    {
                        JKgbWyborKrzywej.Enabled = false;
                        KrzywaKardynalna.LiczbaPunktów = (ushort)numUD_Punkty.Value;
                        KrzywaKardynalna.NumerPunktuKrzywej = 0;

                        KrzywaKardynalna.PromienPunktuKrzywej = 5;
                        KrzywaKardynalna.PunktyKrzywej = new Point[KrzywaKardynalna.LiczbaPunktów];

                        KrzywaKardynalna.PunktyKrzywej[0] = e.Location;
                        using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                        {
                            Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                            Rysownica.DrawString("p" + KrzywaBeziera.NumerPunktuKontrolnego.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                        }
                    }
                    else
                    {
                        KrzywaKardynalna.NumerPunktuKrzywej++;

                        switch (KrzywaKardynalna.NumerPunktuKrzywej)
                        {
                            case 1: KrzywaKardynalna.PunktyKrzywej[1] = e.Location; break;
                            case 2: KrzywaKardynalna.PunktyKrzywej[2] = e.Location; break;
                            case 3: KrzywaKardynalna.PunktyKrzywej[3] = e.Location; break;
                            case 4: KrzywaKardynalna.PunktyKrzywej[4] = e.Location; break;
                            case 5: KrzywaKardynalna.PunktyKrzywej[5] = e.Location; break;
                            case 6: KrzywaKardynalna.PunktyKrzywej[6] = e.Location; break;
                            case 7: KrzywaKardynalna.PunktyKrzywej[7] = e.Location; break;
                            case 8: KrzywaKardynalna.PunktyKrzywej[8] = e.Location; break;
                            case 9: KrzywaKardynalna.PunktyKrzywej[9] = e.Location; break;
                            case 10: KrzywaKardynalna.PunktyKrzywej[10] = e.Location; break;
                            case 11: KrzywaKardynalna.PunktyKrzywej[11] = e.Location; break;
                            case 12: KrzywaKardynalna.PunktyKrzywej[12] = e.Location; break;
                            case 13: KrzywaKardynalna.PunktyKrzywej[13] = e.Location; break;
                            case 14: KrzywaKardynalna.PunktyKrzywej[14] = e.Location; break;
                            case 15: KrzywaKardynalna.PunktyKrzywej[15] = e.Location; break;
                            case 16: KrzywaKardynalna.PunktyKrzywej[16] = e.Location; break;
                            case 17: KrzywaKardynalna.PunktyKrzywej[17] = e.Location; break;
                            case 18: KrzywaKardynalna.PunktyKrzywej[18] = e.Location; break;
                            case 19: KrzywaKardynalna.PunktyKrzywej[19] = e.Location; break;
                        }
                        if (KrzywaKardynalna.NumerPunktuKrzywej < KrzywaKardynalna.LiczbaPunktów - 1)
                        {
                            using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                            {
                                Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                                // wykreślenie (wymalowanie) opisu wykreślonego punktu kontrolnego
                                Rysownica.DrawString("p" + KrzywaKardynalna.NumerPunktuKrzywej.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush Pedzel = new SolidBrush(Color.Blue))
                            {
                                Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaKardynalna.PromienPunktuKrzywej, e.Location.Y - KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej, 2 * KrzywaKardynalna.PromienPunktuKrzywej);
                                Rysownica.DrawString("p" + KrzywaKardynalna.NumerPunktuKrzywej.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                            }
                            JKPedzel.Color = JKbtnKolorWypełnienia.BackColor;
                            JKPioro.Color = JKbtnKolorObramowania.BackColor;
                            Rysownica.DrawClosedCurve(JKPioro, KrzywaKardynalna.PunktyKrzywej);
                            Rysownica.FillClosedCurve(JKPedzel, KrzywaKardynalna.PunktyKrzywej);
                            JKgbWyborKrzywej.Enabled = true;
                        }
                    }
                }
                if (JKrdbKrzywaBeziera.Checked)
                {
                    if (JKgbWyborKrzywej.Enabled)
                    {
                        // ustawienie stanu braku aktywności dla kontenera: JKgbWyborKrzywej
                        JKgbWyborKrzywej.Enabled = false;
                        KrzywaBeziera.NumerPunktuKontrolnego = 0;
                        // ustawienie stanu początkowego tworzonego opisu Krzywej Beziera
                        KrzywaBeziera.PromienPunktuKontrolnego = 5;
                        // przechowanie współrzędnych aktualnego położenia myszy
                        KrzywaBeziera.PunktP0 = e.Location;
                        // wizualizacja (wykreślenie) punktu P0
                        using (SolidBrush Pedzel = new SolidBrush(Color.Black))
                        {
                            // wykreślenie punktu P0
                            Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaBeziera.PromienPunktuKontrolnego, e.Location.Y - KrzywaBeziera.PromienPunktuKontrolnego, 2 * KrzywaBeziera.PromienPunktuKontrolnego, 2 * KrzywaBeziera.PromienPunktuKontrolnego);
                            // wykreślenie (wymalowanie) opisu Punktu P0
                            Rysownica.DrawString("p" + KrzywaBeziera.NumerPunktuKontrolnego.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                        }// tutaj nastąpi zwolnienie Pędzla
                    }// od if (JKgbWyborKrzywej.Enabled)
                    else
                    {// przechowanie współrzędnych kolejnych punktów kontrolnych
                     // zwiększenie numeru (licznika) punktów kontrolnych
                        KrzywaBeziera.NumerPunktuKontrolnego++;
                        // przechowanie wartości współrzędnych punktu kontrolnego o numerze w KrzywaBeziera.NumerPunktuKontrolnego
                        switch (KrzywaBeziera.NumerPunktuKontrolnego)
                        {
                            case 1: KrzywaBeziera.PunktP1 = e.Location; break;
                            case 2: KrzywaBeziera.PunktP2 = e.Location; break;
                            case 3: KrzywaBeziera.PunktP3 = e.Location; break;
                        }
                        // sprawdzenie, czy jest to już ostatni punkt Krzywej Beziera
                        if (KrzywaBeziera.NumerPunktuKontrolnego < 3)
                        {
                            // wykreślenie punktu kontrolnego krzywej Beziera
                            using (SolidBrush Pedzel = new SolidBrush(Color.Red))
                            {
                                Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaBeziera.PromienPunktuKontrolnego, e.Location.Y - KrzywaBeziera.PromienPunktuKontrolnego, 2 * KrzywaBeziera.PromienPunktuKontrolnego, 2 * KrzywaBeziera.PromienPunktuKontrolnego);
                                // wykreślenie (wymalowanie) opisu wykreślonego punktu kontrolnego
                                Rysownica.DrawString("p" + KrzywaBeziera.NumerPunktuKontrolnego.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                            }
                        }
                        else
                        {
                            // wykreślenie punktu końcowego krzywej Beziera
                            using (SolidBrush Pedzel = new SolidBrush(Color.Black))
                            {
                                Rysownica.FillEllipse(Pedzel, e.Location.X - KrzywaBeziera.PromienPunktuKontrolnego, e.Location.Y - KrzywaBeziera.PromienPunktuKontrolnego, 2 * KrzywaBeziera.PromienPunktuKontrolnego, 2 * KrzywaBeziera.PromienPunktuKontrolnego);
                                // wykreślenie (wymalowanie) opisu wykreślonego punktu kontrolnego
                                Rysownica.DrawString("p" + KrzywaBeziera.NumerPunktuKontrolnego.ToString(), FontOpisuPunktow, Pedzel, e.Location);
                            }
                            // wykreślenie krzywej Beziera
                            Rysownica.DrawBezier(JKPioro, KrzywaBeziera.PunktP0, KrzywaBeziera.PunktP1, KrzywaBeziera.PunktP2, KrzywaBeziera.PunktP3);
                            // ponowne uaktywnienie kontenera: JKgbWyborKrzywej
                            JKgbWyborKrzywej.Enabled = true;
                        }
                    }
                }
            }
            JKpbRysownica.Refresh();
        }

        private void JKpbRysownica_MouseDown(object sender, MouseEventArgs e)
        {
            JKlblX.Text = e.Location.X.ToString();
            JKlblY.Text = e.Location.Y.ToString();
            if (e.Button == MouseButtons.Left)
                Punkt = e.Location;
        }

        private void JKrdbKrzywaBeziera_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdbKrzywaBeziera.Checked)
                // wizualizacja okna dialogowego z informacją dla Użytkownika: co powinien zrobić?
                MessageBox.Show("Wykreślenie krzywej Beziera wymaga zaznaczenia (kliknięcia) 4 punktów na Rysownicy", "Kreślenie krzywej Beziera", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void JKbtnKolorWypełnieniaProstokąta_Click(object sender, EventArgs e)
        {
            ColorDialog PaletaKolorow = new ColorDialog();
            PaletaKolorow.Color = JKbtnKolorWypełnienia.BackColor;
            // wyświetlenie Palety kolorów
            if (PaletaKolorow.ShowDialog() == DialogResult.OK)
                JKbtnKolorWypełnienia.BackColor = PaletaKolorow.Color;
            // zwolnienie zasobu graficznego, czyli Palety kolorów
            PaletaKolorow.Dispose();
        }

        private void JKrdbProstokątWyp_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdbProstokątWyp.Checked)
            {
                JKbtnKolorWypełnienia.Visible = true;
            }
            else
            {
                JKbtnKolorWypełnienia.Visible = false;
            }
        }
        private void JKrdb_KwadratWyp_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdb_KwadratWyp.Checked)
            {
                JKbtnKolorWypełnienia.Visible = true;
            }
            else
            {
                JKbtnKolorWypełnienia.Visible = false;
            }
        }

        private void JKrdbElipsaWyp_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdbElipsaWyp.Checked)
            {
                JKbtnKolorWypełnienia.Visible = true;
            }
            else
            {
                JKbtnKolorWypełnienia.Visible = false;
            }
        }

        private void JKrdbKoło_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdbKoło.Checked)
            {
                JKbtnKolorWypełnienia.Visible = true;
            }
            else
            {
                JKbtnKolorWypełnienia.Visible = false;
            }
        }

        private void JKrdbŁukElipsy_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdbŁukElipsy.Checked)
            {
                MessageBox.Show("Wyklreślenie łuku wymaga podania kąta początkowego oraz kąta wygięcia elipsy", "Kreślenie łuku elipsy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numUD_KątPoczątkowy.Visible = true;
                numUD_KątWygięcia.Visible = true;
                numUD_KątPoczątkowy.Enabled = true;
                numUD_KątWygięcia.Enabled = true;
                JKlblKątWygięcia.Visible = true;
                JKlblKątPoczątkowy.Visible = true;
                numUD_KątPoczątkowy.Maximum = 360;
                numUD_KątWygięcia.Maximum = 360;
            }
            else
            {
                numUD_KątWygięcia.Visible = false;
                numUD_KątPoczątkowy.Visible = false;
                JKlblKątPoczątkowy.Visible = false;
                JKlblKątWygięcia.Visible = false;
            }
        }

        private void JKrdbWycinekElipsy_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdbWycinekElipsy.Checked)
            {
                MessageBox.Show("Wyklreślenie wycinka elipsy wymaga podania kąta początkowego oraz kąta wygięcia elipsy", "Kreślenie wycinka elipsy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numUD_KątPoczątkowy.Visible = true;
                numUD_KątWygięcia.Visible = true;
                numUD_KątPoczątkowy.Enabled = true;
                numUD_KątWygięcia.Enabled = true;
                JKlblKątWygięcia.Visible = true;
                JKlblKątPoczątkowy.Visible = true;
            }
            else
            {
                numUD_KątWygięcia.Visible = false;
                numUD_KątPoczątkowy.Visible = false;
                JKlblKątPoczątkowy.Visible = false;
                JKlblKątWygięcia.Visible = false;
            }
        }

        private void JKrdbWypełnionyWycinekElipsy_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdbWypełnionyWycinekElipsy.Checked)
            {
                MessageBox.Show("Wyklreślenie wypełnionego lub obramowanego wycinka elipsy wymaga podania kąta początkowego oraz kąta wygięcia elipsy", "Kreślenie wypełnionego lub obramowanego wycinka elipsy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                JKbtnKolorWypełnienia.Visible = true;
                JKlblKątPoczątkowy.Visible=true;
                JKlblKątWygięcia.Visible=true;
                numUD_KątPoczątkowy.Visible = true;
                numUD_KątWygięcia.Visible = true;
                JKcboxObramowanie.Visible = true;
                JKcboxWypełnienie.Visible = true;
                JKbtnKolorObramowania.Visible = true;
            }
            else
            {
                JKbtnKolorObramowania.Visible = false;
                JKbtnKolorWypełnienia.Visible = false;
                JKlblKątPoczątkowy.Visible = false;
                JKlblKątWygięcia.Visible = false;
                numUD_KątPoczątkowy.Visible = false;
                numUD_KątWygięcia.Visible = false;
                JKcboxObramowanie.Visible = false;
                JKcboxWypełnienie.Visible = false;
            }
        }

        private void JKbtnKolorObramowania_Click(object sender, EventArgs e)
        {
            ColorDialog JKPaletaKolorow = new ColorDialog();
            JKPaletaKolorow.Color = JKbtnKolorObramowania.BackColor;
            // wyświetlenie Palety kolorów
            if (JKPaletaKolorow.ShowDialog() == DialogResult.OK)
                JKbtnKolorObramowania.BackColor = JKPaletaKolorow.Color;
            // zwolnienie zasobu graficznego, czyli Palety kolorów
            JKPaletaKolorow.Dispose();
        }

        private void JKrdbKrzywaKardynalna_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdbKrzywaKardynalna.Checked)
            {
                MessageBox.Show("Wykreślenie krzywej kardynalnej wymaga podania ilości punktów", "Kreślenie krzywej kardynalnej", MessageBoxButtons.OK, MessageBoxIcon.Information);
                JKlblPunkty.Visible = true;
                numUD_Punkty.Visible = true;
                numUD_Punkty.Maximum = 20;
                numUD_Punkty.Minimum = 3;
            }
        }

        private void zapiszBitMapęWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
        MessageBox.Show("Aby zapisać rysownice, należy wybrać miejsce docelowe zapisu", "Zapisywanie BitMapy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            using (SaveFileDialog PlikDoZapisu = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                if (PlikDoZapisu.ShowDialog() == DialogResult.OK)
                {
                    JKpbRysownica.Image.Save(PlikDoZapisu.FileName);
                }
            }
        }

        private void odczytajBitMapęZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aby odczytać plik z rysownicą, należy wybrać wcześniej zapisany plik", "Odczytywanie BitMapy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFileDialog PlikDoOdczytu = new OpenFileDialog();
            PlikDoOdczytu.ShowDialog();
            string sciezka = PlikDoOdczytu.FileName;
            try
            {
                JKpbRysownica.Image = Image.FromFile(sciezka);
            }
            catch (ArgumentException) { }

            Rysownica = Graphics.FromImage(JKpbRysownica.Image);
        }

        private void wyjścieZFormularzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult JKPytanieDoUzytkownika = MessageBox.Show("Czy na pewno chcesz zamknąć formularz (co może skutkować utratą danych zapisanych na formularzu)?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (JKPytanieDoUzytkownika == DialogResult.Yes)
                Close();
        }

        private void restartProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult JKPytanieDoUzytkownika = MessageBox.Show("Czy na pewno chcesz zrestartować formularz (co może skutkować utratą danych zapisanych na formularzu)?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (JKPytanieDoUzytkownika == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void kolorLiniiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog JKPaletaKolorow = new ColorDialog();
            JKPaletaKolorow.Color = JKPioro.Color;
            if (JKPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                JKPioro.Color = JKPaletaKolorow.Color;
                JKPaletaKolorow.Dispose();
            }
        }

        private void kolorTłaRysownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog JKPaletaKolorow = new ColorDialog();
            JKPaletaKolorow.Color = JKpbRysownica.BackColor;
            if (JKPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                JKpbRysownica.BackColor = JKPaletaKolorow.Color;
                JKPaletaKolorow.Dispose();
            }
        }

        private void kolorWypełnieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog JKPaletaKolorow = new ColorDialog();
            JKPaletaKolorow.Color = this.BackColor;
            if (JKPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = JKPaletaKolorow.Color;
                JKPaletaKolorow.Dispose();
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            JKPioro.Width = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            JKPioro.Width = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            JKPioro.Width = 3;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            JKPioro.Width = 4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            JKPioro.Width = 5;
        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.DashStyle = DashStyle.Dash;
        }

        private void liniaKreskowokropkowadashdotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.DashStyle = DashStyle.DashDot;
        }

        private void liniaKreskowoKropkowaKropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.DashStyle = DashStyle.DashDotDot;
        }

        private void liniaKropkowadotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.DashStyle = DashStyle.Dot;
        }

        private void ągłaSolidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.DashStyle = DashStyle.Solid;
        }
        private void krójCzcionkiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // utworzenie okna dialogowego dla zmiany czcionki
            FontDialog JKOknoCzcionki = new FontDialog();
            // zaznaczenie w oknie OknoCzcionki bieżącego fontu
            JKOknoCzcionki.Font = JKgbWyborKrzywej.Font;
            // wyświetlenie okna dialogowego OknoCzcionki i "odczytanie" nowych ustawień dla fontów
            if (JKOknoCzcionki.ShowDialog() == DialogResult.OK)
            JKgbWyborKrzywej.Font = JKOknoCzcionki.Font;
            JKOknoCzcionki.Dispose();
        }
        private void krójCzcionkiKontrolkiLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // utworzenie okna dialogowego dla zmiany czcionki
            FontDialog JKOknoCzcionki = new FontDialog();
            // zaznaczenie w oknie OknoCzcionki bieżącego fontu
            JKOknoCzcionki.Font = JKlblGóra.Font;
            // wyświetlenie okna dialogowego OknoCzcionki i "odczytanie" nowych ustawień dla fontów
            if (JKOknoCzcionki.ShowDialog() == DialogResult.OK)
            JKlblGóra.Font = JKOknoCzcionki.Font;
            JKOknoCzcionki.Dispose();
        }

        private void ProjektNr3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Czy na pewno chcesz zamknąć ten formularz i przejść do formularza głównego", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (OknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;
                foreach (Form Formularz in Application.OpenForms)
                    if (Formularz.Name == "KokpitProjektuNr3")
                    {// ukrycie bieżącego formularza 
                        this.Hide();
                        Formularz.Show();
                        return;
                    }
                KokpitProjektuNr3 FormularzKokpitProjektuNr3 = new KokpitProjektuNr3();
                this.Hide();
                this.Show();
            }
            else 
                e.Cancel = true;
        }

        private void JKrdbZamkniętaKrzywaKardynalna_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdbZamkniętaKrzywaKardynalna.Checked)
            {
                MessageBox.Show("Wykreślenie zamkniętej krzywej kardynalnej wymaga podania ilości punktów", "Kreślenie zamkniętej krzywej kardynalnej", MessageBoxButtons.OK, MessageBoxIcon.Information);
                JKlblPunkty.Visible = true;
                numUD_Punkty.Visible = true;
                numUD_Punkty.Maximum = 20;
                numUD_Punkty.Minimum = 3;
            }
            else
            {
                JKlblPunkty.Visible = false;
                numUD_Punkty.Visible = false;
            }
        }

        private void JKrdbWypZamkKrzywaKardynalna_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdbWypZamkKrzywaKardynalna.Checked)
            {
                MessageBox.Show("Wykreślenie wypełnionej i zamkniętej krzywej kardynalnej wymaga podania ilości punktów", "Kreślenie wypełnionej i zamkniętej krzywej kardynalnej", MessageBoxButtons.OK, MessageBoxIcon.Information);
                JKbtnKolorWypełnienia.Visible = true;
                JKlblPunkty.Visible = true;
                numUD_Punkty.Visible = true;
                numUD_Punkty.Maximum = 20;
                numUD_Punkty.Minimum = 3;
            }
            else
            {
                JKbtnKolorWypełnienia.Visible = false;
                JKlblPunkty.Visible = false;
                numUD_Punkty.Visible = false;
            }
        }

        private void JKrdbWypObrZamkKrzywaKardynalna_CheckedChanged(object sender, EventArgs e)
        {
            if (JKrdbWypObrZamkKrzywaKardynalna.Checked)
            {
                MessageBox.Show("Wykreślenie wypełnionej, zamkniętej i obramowanej krzywej kardynalnej wymaga podania ilości punktów", "Kreślenie wypełnionej, zamkniętej i obramowanej i zamkniętej krzywej kardynalnej", MessageBoxButtons.OK, MessageBoxIcon.Information);
                JKbtnKolorWypełnienia.Visible = true;
                JKbtnKolorObramowania.Visible = true;
                JKlblPunkty.Visible = true;
                numUD_Punkty.Visible = true;
                numUD_Punkty.Maximum = 20;
                numUD_Punkty.Minimum = 3;
            }
            else
            {
                JKbtnKolorObramowania.Visible = false;
                JKbtnKolorWypełnienia.Visible = false;
                JKlblPunkty.Visible = false;
                numUD_Punkty.Visible = false;
            }
        }

        private void JKpbRysownica_MouseMove(object sender, MouseEventArgs e)
        {
            JKlblX.Text=e.Location.X.ToString();
            JKlblY.Text = e.Location.Y.ToString();
            int JKLewyGornyNaroznikX = (Punkt.X > e.Location.X) ? e.Location.X : Punkt.X;
            int JKLewyGornyNaroznikY = (Punkt.Y > e.Location.Y) ? e.Location.Y : Punkt.Y;
            int JKSzerokosc = Math.Abs(Punkt.X - e.Location.X);
            int JKWysokosc = Math.Abs(Punkt.Y - e.Location.Y);

            if (e.Button == MouseButtons.Left)
            {
                if (JKrdbProstokąt.Checked || JKrdbProstokątWyp.Checked)
                {
                    JKRysownicaTymczasowa.DrawRectangle(JKPioroTymczasowe, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc);
                }
                if (JKrdbKwadrat.Checked || JKrdb_KwadratWyp.Checked)
                {
                    JKRysownicaTymczasowa.DrawRectangle(JKPioroTymczasowe, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKSzerokosc);
                }
                if (JKrdbElipsa.Checked || JKrdbElipsaWyp.Checked)
                {
                    JKRysownicaTymczasowa.DrawEllipse(JKPioroTymczasowe, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc);
                }
                if (JKrdbOkrag.Checked || JKrdbKoło.Checked)
                {
                    JKRysownicaTymczasowa.DrawEllipse(JKPioroTymczasowe, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKSzerokosc);
                }
                if (JKrdbŁukElipsy.Checked)
                {
                    ushort KątPoczątkowy = (ushort)numUD_KątPoczątkowy.Value;
                    ushort KątWygięcia = (ushort)numUD_KątWygięcia.Value;
                    try
                    {
                        JKRysownicaTymczasowa.DrawArc(JKPioroTymczasowe, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc, KątPoczątkowy, KątWygięcia);
                    }
                    catch (ArgumentException) { }
                }
                if (JKrdbWycinekElipsy.Checked)
                {
                    ushort KątPoczątkowy = (ushort)numUD_KątPoczątkowy.Value;
                    ushort KątWygięcia = (ushort)numUD_KątWygięcia.Value;
                    try
                    {
                        JKRysownicaTymczasowa.DrawArc(JKPioroTymczasowe, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc, KątPoczątkowy, KątWygięcia);
                    }
                    catch (ArgumentException) { }
                }
                if (JKrdbWypełnionyWycinekElipsy.Checked)
                {
                    if (JKcboxObramowanie.Checked)
                    {
                        JKPioro.Color = JKbtnKolorObramowania.BackColor;
                        ushort KątPoczątkowy = (ushort)numUD_KątPoczątkowy.Value;
                        ushort KątWygięcia = (ushort)numUD_KątWygięcia.Value;
                        try
                        {
                            JKRysownicaTymczasowa.DrawPie(JKPioroTymczasowe, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc, KątPoczątkowy, KątWygięcia);
                        }
                        catch (ArgumentException) { }
                    }
                    if (JKcboxWypełnienie.Checked)
                    {
                        JKPedzel.Color = JKbtnKolorWypełnienia.BackColor;
                        ushort KątPoczątkowy = (ushort)numUD_KątPoczątkowy.Value;
                        ushort KątWygięcia = (ushort)numUD_KątWygięcia.Value;
                        try
                        {
                            JKRysownicaTymczasowa.FillPie(JKPedzel, JKLewyGornyNaroznikX, JKLewyGornyNaroznikY, JKSzerokosc, JKWysokosc, KątPoczątkowy, KątWygięcia);
                        }
                        catch (ArgumentException) { }
                    }
                }
            }
            JKpbRysownica.Refresh();

        }

        private void nicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.StartCap = LineCap.Round;
        }

        private void strzałkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.StartCap = LineCap.ArrowAnchor;

        }

        private void kwadratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.StartCap = LineCap.SquareAnchor;

        }
        private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.StartCap = LineCap.RoundAnchor;

        }

        private void diamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.StartCap = LineCap.DiamondAnchor; 
        }

        private void brakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.EndCap = LineCap.Round;
        }

        private void strzałkaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            JKPioro.EndCap = LineCap.ArrowAnchor;
        }

        private void kwadratToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            JKPioro.EndCap = LineCap.SquareAnchor;
        }

        private void zaokrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JKPioro.EndCap = LineCap.RoundAnchor;
        }

        private void diamentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            JKPioro.EndCap = LineCap.DiamondAnchor;
        }
        private void kolorCzcionkiGroupBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dmPaletaKolorow = new ColorDialog();
            dmPaletaKolorow.Color = JKgbWyborKrzywej.ForeColor;
            if (dmPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                JKgbWyborKrzywej.ForeColor = dmPaletaKolorow.Color;
                dmPaletaKolorow.Dispose();
            }
        }

        private void kolorCzcionkiLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dmPaletaKolorow = new ColorDialog();
            // zaznaczenie w oknie OknoCzcionki bieżącego fontu
            dmPaletaKolorow.Color = JKlblGóra.ForeColor;
            // wyświetlenie okna dialogowego OknoCzcionki i "odczytanie" nowych ustawień dla fontów
            if (dmPaletaKolorow.ShowDialog() == DialogResult.OK)
                JKlblGóra.ForeColor = dmPaletaKolorow.Color;
            dmPaletaKolorow.Dispose();
        }
    }
}
