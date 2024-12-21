using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// dodanie nowej przestrzeni nazw dla potrzeb grafiki 2D 
using System.Drawing.Drawing2D;

namespace ProjektNr3Kuźnicki61961
{
    public partial class LaboratoriumNr3 : Form
    {
        // deklaracje stałych
        const ushort PromienPunktu = 2;
        // deklaracje zmiennych referencyjnych narzędzi graficznych
        Graphics Rysownica;
        Pen Pioro;
        SolidBrush Pedzel;
        Point Punkt = Point.Empty;
        // deklaracja zmiennej dla KrzywejBeziera

        // deklaracja Fontu opisu punktu kontrolnego
        Font FontOpisuPunktow = new Font("Arial", 8, FontStyle.Italic);

        public LaboratoriumNr3()
        {
            InitializeComponent();

            // ...
            // "podpięcie" BitMapy do kontrolki PictureBox
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            // utworzenie egzemplarza powierzchni graficznej
            Rysownica = Graphics.FromImage(pbRysownica.Image);
            // utworzenie egzemplarza Pióra i jego sformatowanie
            Pioro = new Pen(Color.Red, 1.7f);
            Pioro.DashStyle = DashStyle.Dash;
            Pioro.StartCap = LineCap.Round;
            Pioro.EndCap = LineCap.Round;

            // utworzenie egzemplarza Pedzla
            Pedzel = new SolidBrush(Color.RoyalBlue);
        }

        private void pbRysownica_MouseDown(object sender, MouseEventArgs e)
        {
            // wizualizacja współrzędnych aktualnego połóżenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();
            // sprawdzenie czy zdarzenie MouseDown zostało spowodowane naciśnięciem lewego przycisku myszy
            if (e.Button == MouseButtons.Left)
            // tak, to zapamiętamy aktualne połóżenie Myszy
                Punkt = e.Location;
        }

        private void pbRysownica_MouseUp(object sender, MouseEventArgs e)
        {
            // wizualizacja współrzędnych aktualnego połóżenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();
            // ustalenie położenia i rozmiarów prostokąta, w którym będzie wkreślana figura
            int LewyGornyNaroznikX = (Punkt.X > e.Location.X) ? e.Location.X : Punkt.X;
            int LewyGornyNaroznikY = (Punkt.Y > e.Location.Y) ? e.Location.Y : Punkt.Y;
            int Szerokosc = Math.Abs(Punkt.X - e.Location.X);
            int Wysokosc = Math.Abs(Punkt.Y - e.Location.Y);
            // sprawdzenie czy zdarzenie MouseUp zostało spowodowane zwolnieniem lewego przycisku myszy 
            if (e.Button == MouseButtons.Left)
            {// musimy teraz sprawdzić, która kontrolka RadioButton jest zaznaczona
                // czy to jest kontorlka dla Punktu
                if (rdbPunkt.Checked)
                {
                    // tak, to ją wykreślamy
                    Rysownica.FillEllipse(Pedzel, Punkt.X - PromienPunktu, Punkt.Y - PromienPunktu, 2 * PromienPunktu, 2 * PromienPunktu);
                    // czy to jest jkontrolka: Linia prosta
                }
                if (rdbLiniaProsta.Checked)
                {
                    // tak, to kreślimy linię
                    Rysownica.DrawLine(Pioro, Punkt.X, Punkt.Y, e.Location.X, e.Location.Y);
                }
                if (rdbLiniaKreslonaMysza.Checked)
                {// wykreślenie "małego" odcinka linii prostej
                    Rysownica.DrawLine(Pioro, Punkt.X, Punkt.Y, e.Location.X, e.Location.Y);
                    // uaktualnienie (przesunięcie Punktu na koniec wykreślonego odcinka)
                    Punkt = e.Location;
                }
                // czy to ma być kreślenie wielokąta?
                if (rdbWielokatForemny.Checked)
                { // ustawienie stanu braku aktywności dla kontrolki umożliwiającej zmianę liczby kątów
                    numUD_LiczbaKatow.Enabled = false;
                    // deklaracje pomocnicze
                    ushort StopienWielokata = (ushort)numUD_LiczbaKatow.Value;
                    int R = Szerokosc;
                    double KatMiedzyWierzcholkami = 360.0 / StopienWielokata;
                    double KatPolozeniaPierwszegoWierzcholka = 0.0;
                    Point[] WierzcholkiWielokata = new Point[StopienWielokata];
                    // wyznaczenie współrzędnych wierzchołków wielokąta 
                    for (int i = 0; i < StopienWielokata; i++)
                    {
                        WierzcholkiWielokata[i].X = LewyGornyNaroznikX + (int)(R * Math.Cos(Math.PI * (KatPolozeniaPierwszegoWierzcholka + i * KatMiedzyWierzcholkami) / 180.0));
                        WierzcholkiWielokata[i].Y = LewyGornyNaroznikY - (int)(R * Math.Sin(Math.PI * (KatPolozeniaPierwszegoWierzcholka + i * KatMiedzyWierzcholkami) / 180.0));
                    }
                    // wykreślenie wielokąta
                    Rysownica.DrawPolygon(Pioro, WierzcholkiWielokata);
                }
                // czy to ma być wykreślony wielokąt wypełniony?
                if (rdbWielokatWypelniony.Checked)
                {
                    // ustawienie stanu braku aktywności dla kontrolki umożliwiającej zmianę liczby kątów
                    numUD_LiczbaKatow.Enabled = false;
                    // deklaracje pomocnicze
                    ushort StopienWielokata = (ushort)numUD_LiczbaKatow.Value;
                    int R = Szerokosc;
                    double KatMiedzyWierzcholkami = 360.0 / StopienWielokata;
                    double KatPolozeniaPierwszegoWierzcholka = 0.0;
                    Point[] WierzcholkiWielokata = new Point[StopienWielokata];
                    // wyznaczenie współrzędnych wierzchołków wielokąta 
                    for (int i = 0; i < StopienWielokata; i++)
                    {
                        WierzcholkiWielokata[i].X = LewyGornyNaroznikX + (int)(R * Math.Cos(Math.PI * (KatPolozeniaPierwszegoWierzcholka + i * KatMiedzyWierzcholkami) / 180.0));
                        WierzcholkiWielokata[i].Y = LewyGornyNaroznikY - (int)(R * Math.Sin(Math.PI * (KatPolozeniaPierwszegoWierzcholka + i * KatMiedzyWierzcholkami) / 180.0));
                    }
                    // wykreślenie wielokąta wypełnionego
                    // ustawienie koloru Pędzla
                    Pedzel.Color = btnKolorWypelnienia.BackColor;
                    Rysownica.FillPolygon(Pedzel, WierzcholkiWielokata);
                }
                // czy to jest Trójkąt Sierpińskiego
                if (rdbTrojkatSierpinskiego.Checked)
                {// deklaracje pomocnicze i pobranie danych z formularza
                    int PoziomRekurencji = (int)NumUD_PoziomRekurencji.Value;
                    Color KolorWypelnienia = btnKolorWypelnieniaTrojkata.BackColor;

                    // wyznaczenie współrzędnych wierzchołków "głównego" trójkąta
                    Point WierzcholekGorny = new Point(LewyGornyNaroznikX + Szerokosc/2, LewyGornyNaroznikY);
                    Point WierzcholekLewyDolny = new Point(LewyGornyNaroznikX, LewyGornyNaroznikY + Wysokosc);
                    Point WierzcholekPrawyDolny = new Point(LewyGornyNaroznikX + Szerokosc, LewyGornyNaroznikY + Wysokosc);
                    // wywołanie rekurencyjnej metody kreślenia Trójkąta Sierpińskiego
                    WykreslTrojkatSierpinskiego(Rysownica, PoziomRekurencji, KolorWypelnienia, WierzcholekGorny, WierzcholekLewyDolny, WierzcholekPrawyDolny);
                }
            }
            // odświerzenie powierzchni graficznej
            pbRysownica.Refresh();
        }

        private void pbRysownica_MouseMove(object sender, MouseEventArgs e)
        {
            // wizualizacja współrzędnych aktualnego połóżenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.Y.ToString();
            // sprawdzenie czy zdarzenie MouseMove zostało wygenerowane przy przesunięciu myszy przy wciśniętym lewym jej przyciskiem 
            if (e.Button == MouseButtons.Left)
            {// musimy teraz sprawdzić, która kontrolka RadioButton jest zaznaczona
                // sprawdzenie, czy jest zaznaczona kontrolka RadioButton dla 'Linii kreślonej myszą'
                if (rdbLiniaKreslonaMysza.Checked)
                {// wykreślenie "małego" odcinka linii prostej
                    Rysownica.DrawLine(Pioro, Punkt.X, Punkt.Y, e.Location.X, e.Location.Y);
                    // uaktualnienie (przesunięcie Punktu na koniec wykreślonego odcinka)
                    Punkt = e.Location;
                }
            }
            // odświerzenie powierzchni graficznej
            pbRysownica.Refresh();
        }

        private void rdbWielokatForemny_CheckedChanged(object sender, EventArgs e)
        {
            // rozpoznanie "wejścia" do obsługi zdarzenia CheckedChanged
            if (rdbWielokatForemny.Checked)
            {
                // wyświetlenie okna dialogowego dla użytkownika programu
                MessageBox.Show("Wykreślenie wielokąta foremnego wymaga ustalenia (podania) liczby kątów (minimalna liczba kątów wielokąta, to 3!)",
                    "Kreślenie wielokąta foremnego", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // odsłonięcie kontrolek umożliwiających ustalenie liczby kątów
                lblLiczbaKatow.Visible = true;
                numUD_LiczbaKatow.Visible = true;
                // ustawienie stanu aktywności dla kontrolki numUD_LiczbaKatow
                numUD_LiczbaKatow.Enabled = true;
                // ustawienie wartości domyślnej (minimalnej!) w kontrolce numUD_LiczbaKatow
                numUD_LiczbaKatow.Minimum = 3;
            }
            else
            {
                // ukrycie kontrolek umożliwiających ustalenie liczby kątów
                lblLiczbaKatow.Visible = false;
                numUD_LiczbaKatow.Visible = false;
            }
        }

        private void btnKolorWypelnienia_Click(object sender, EventArgs e)
        {
            ColorDialog PaletaKolorow = new ColorDialog();
            PaletaKolorow.Color = btnKolorWypelnienia.BackColor;
            // wyświetlenie Palety kolorów
            if (PaletaKolorow.ShowDialog() == DialogResult.OK)
                btnKolorWypelnienia.BackColor = PaletaKolorow.Color;
            // zwolnienie zasobu graficznego, czyli Palety kolorów
            PaletaKolorow.Dispose();
        }

        private void rdbWielokatWypelniony_CheckedChanged(object sender, EventArgs e)
        {
            // rozpoznanie "wejścia" do obsługi zdarzenia CheckedChanged
            if (rdbWielokatWypelniony.Checked)
            {
                // wyświetlenie okna dialogowego dla użytkownika programu
                MessageBox.Show("Wykreślenie wielokąta wypełnionego wymaga ustalenia (podania) liczby kątów (minimalna liczba kątów wielokąta, to 3!) oraz " +
                    "ustalenia koloru wypełnienia",
                    "Kreślenie wielokąta wypełnionego", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // odsłonięcie kontrolek umożliwiających ustalenie liczby kątów
                lblLiczbaKatow.Visible = true;
                btnKolorWypelnienia.Visible = true;
                numUD_LiczbaKatow.Visible = true;
                // ustawienie stanu aktywności dla kontrolki numUD_LiczbaKatow
                numUD_LiczbaKatow.Enabled = true;
                btnKolorWypelnienia.Enabled = true;
                // ustawienie wartości domyślnej (minimalnej!) w kontrolce numUD_LiczbaKatow
                numUD_LiczbaKatow.Minimum = 3;
            }
            else
            {
                // ukrycie kontrolek umożliwiających ustalenie liczby kątów
                lblLiczbaKatow.Visible = false;
                numUD_LiczbaKatow.Visible = false;
                btnKolorWypelnienia.Visible = false;
            }
        }

        private void btnKolorWypelnieniaTrojkata_Click(object sender, EventArgs e)
        {
            ColorDialog PaletaKolorow = new ColorDialog();
            // ustawienie bieżącego koloru wypełnienia w PalecieKolorow
            PaletaKolorow.Color = btnKolorWypelnieniaTrojkata.BackColor;
            // wizualizacja Palety kolorów i 'odczytanie' decyzji Użytkownika
            if (PaletaKolorow.ShowDialog() == DialogResult.OK)
                btnKolorWypelnieniaTrojkata.BackColor = PaletaKolorow.Color;
            // zwolnienie zasobów przydzielonego PalecieKolorow
            PaletaKolorow.Dispose();
        }

        private void rdbTrojkatSierpinskiego_CheckedChanged(object sender, EventArgs e)
        {
            // sprawdzenie, czy jest to 'zapalenie' kontrolki rdbTrojkatSierpinskiego
            if (rdbTrojkatSierpinskiego.Checked)
            { // wizualizacja okna dialogowego z informacją dla Użytkownika 
                MessageBox.Show("Wykreślenie trójkąta wymaga podania poziomu rekurencji oraz wybrania koloru wypełnienia trójkąta", "Kreślenie Trójkąta Sierpińskiego", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // odsłonięcie kontrolek dla ustawienia poziomu rekurencji i koloru wypełnienia
                lblPoziomRekurencji.Visible = true;
                btnKolorWypelnieniaTrojkata.Visible = true;
                NumUD_PoziomRekurencji.Visible = true;
                // ustawienia domyślne w kontrolkach dla ustalenia poziomu rekurencji i koloru wypełnienia
                NumUD_PoziomRekurencji.Value = 3;
                btnKolorWypelnieniaTrojkata.BackColor = Color.LightGreen;
                // uaktywnienie kontrolek dla ustalenia poziomu rekurencji i koloru wypełnienia
                NumUD_PoziomRekurencji.Enabled = true;
                btnKolorWypelnieniaTrojkata.Enabled = true;
            }
            else
            { // ukrycie kontrolek dla ustalenia poziomu rekurencji i koloru wypełnienia
                lblPoziomRekurencji.Visible = false;
                btnKolorWypelnieniaTrojkata.Visible = false;
                NumUD_PoziomRekurencji.Visible = false;
            }
        }
        void WykreslTrojkatSierpinskiego(Graphics Rysownica, int PoziomRekurencji, Color KolorWypelnienia, Point WierzcholekGorny, Point WierzcholekLewyDolny, Point WierzcholekPrawyDolny)
        { // czy to jest zerowy poziom rekurencji, czyli jej zakończenie
            if(PoziomRekurencji == 0)
            {
                // deklaracja tablicy WierzcholkowTrojkata z wpisaniem do niej współrzędnych wierzchołka
                Point[] WierzcholkiTrojkata = { WierzcholekGorny, WierzcholekLewyDolny, WierzcholekPrawyDolny };
                using (SolidBrush Pedzel = new SolidBrush(KolorWypelnienia))
                    Rysownica.FillPolygon(Pedzel, WierzcholkiTrojkata);
            }
            else
            {// podzielenie trójkąta na cztery trójkąty
                // wyznaczenie współrzędnych punktów środkowych 3 krawędzi trójkąta
                Point PunktSrodkowyLewejKrawedzi = new Point((WierzcholekGorny.X + WierzcholekLewyDolny.X)/2, (WierzcholekGorny.Y + WierzcholekLewyDolny.Y) / 2);
                Point PunktSrodkowyPrawejKrawedzi = new Point((WierzcholekGorny.X + WierzcholekPrawyDolny.X)/2, (WierzcholekGorny.Y + WierzcholekPrawyDolny.Y) / 2);
                Point PunktSrodkowyDolnejKrawdzi = new Point((WierzcholekLewyDolny.X + WierzcholekPrawyDolny.X)/2, (WierzcholekLewyDolny.Y + WierzcholekPrawyDolny.Y) / 2);
                // wywołanie metody rekurencyjnej WykreslTrojkatSierpinskiego( . . . ) dla 3 narożnych trójkątów
                WykreslTrojkatSierpinskiego(Rysownica, PoziomRekurencji - 1, KolorWypelnienia, WierzcholekGorny, PunktSrodkowyLewejKrawedzi, PunktSrodkowyPrawejKrawedzi);
                WykreslTrojkatSierpinskiego(Rysownica, PoziomRekurencji - 1, KolorWypelnienia, WierzcholekLewyDolny, PunktSrodkowyLewejKrawedzi, PunktSrodkowyDolnejKrawdzi);
                WykreslTrojkatSierpinskiego(Rysownica, PoziomRekurencji - 1, KolorWypelnienia, PunktSrodkowyDolnejKrawdzi, PunktSrodkowyPrawejKrawedzi, WierzcholekPrawyDolny);
            }
        }
    }
}
