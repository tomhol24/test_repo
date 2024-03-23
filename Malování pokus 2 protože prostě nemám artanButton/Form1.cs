using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Malování_pokus_2_protože_prostě_nemám_artanButton //Valná většina věcí zplozená v tomto úkolu byla udělána pomocí chatu GPT, Youtube a nebo mnou (hlavně když jsem si část kódu smazal a musel ji dopsat)
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();  // Vyvolává komponenty formuláře.
            this.Width = 1080;  // Nastavuje šířku formuláře na 1080 a výšku na 720 pixelů.
            this.Height = 720;  
            bm = new Bitmap(PicBx.Width,PicBx.Height);  // Vytváří nový objekt typu Bitmap (bm) s rozměry odpovídajícími velikosti PictureBoxu (PicBx).
            g = Graphics.FromImage(bm); // Vytváří grafický objekt (g) pro práci s vytvořeným obrázkem.
            g.Clear(Color.White);   // Vyplňuje grafický objekt bílou barvou.
            PicBx.Image = bm;   // Nastavuje vytvořený obrázek jako obsah PictureBoxu (PicBx).
        }
        
        List<Point> circleCenters = new List<Point>(); // Seznam bodů typu Point, který bude uchovávat středy kruhů.
        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black,1); //vytvoření štětce
        Pen erase = new Pen(Color.White,1); //vytvoření gumy
        int index;
        int x, y, sX, sY, cX, cY; // Proměnné pro uchování hodnot souřadnic a dalších informací.
        ColorDialog cd = new ColorDialog(); //Zadefinování dialogu pro barvy
        Color new_color;    // Proměnná pro uchování nové barvy vybrané pomocí dialogu.


        //Buttony s funkcemi
        private void BtnPencil_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void BtnEraser_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void BtnEllipse_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void BtnRect_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {
            index = 5;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            index = 6;
        }
        private void BtnFill_Click(object sender, EventArgs e)
        {
            index = 7;
        }
        //Konec buttonů s funkcemi


        private void PicBx_Paint(object sender, PaintEventArgs e)//Díky tomuhle v živém čase vidím co kreslím
        {
            Graphics g = e.Graphics; // Iniciace grafického objektu pro kreslení na základě PaintEventArgs.

            if (paint) // Podmínka zjišťuje, zda je proměnná "paint" nastavena na true. Pokud ano, bude se kreslit.
            {
                if (index == 3) //Pro kreslení kruhu
                {
                    g.DrawEllipse(p, cX, cY, sX, sY); // Kreslí elipsu pomocí pera a na základě daných parametrů (cX, cY, sX, sY).
                }
                if (index == 4) //Pro kreslení obdélníku
                {
                    g.DrawRectangle(p, cX, cY, sX, sY); // Kreslí obdélník pomocí pera a na základě daných souřadnic
                }
                if (index == 5) //Pro kreslení přímky
                {
                    g.DrawLine(p, cX, cY, x, y); // Nakreslí přímku pomocí definovaného pera mezi dvěma body dle daných parametrů (cX, cY, x, y).
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White); // Vyčistí géčko a nastaví ho na bílou barvu.
            PicBx.Image = bm; // Nastaví obrázek v PictureBoxu na předdefinovaný obrázek 'bm'.
            index = 0; // Nastaví index na hodnotu 0.
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();// Zobrazí dialog pro výběr barvy.
            new_color = cd.Color;// Nastaví proměnnou 'new_color' na vybranou barvu z dialogu.
            PicColor.BackColor = cd.Color;// Nastaví barvu pozadí PictureBoxu 'PicColor' na vybranou barvu z dialogu.
            p.Color = cd.Color;// Nastaví barvu pero pera na vybranou barvu z dialogu.
        }

        private void PicBx_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;// Nastaví proměnnou 'paint' na hodnotu true, což znamená že se začalo kreslit
            py = e.Location;// Uloží aktuální pozici myši (e.Location) do proměnné py.
            cX = e.X;// Uloží aktuální Xovou souřadnici myši (e.X) do proměnné 'cX'.
            cY = e.Y;// Uloží aktuální Ylonovou souřadnici myši (e.Y) do proměnné 'cY'.
        }

        private void PicBx_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint) 
            { 
                if (index == 1)// Kontrola, zda je vybráno kreslení čáry
                {
                    px = e.Location;// Uložení aktuální pozice myši do proměnné 'px'
                    g.DrawLine(p, px, py);// Kreslení čáry mezi předchozí a aktuální pozicí myši
                    // Výpočet souřadnic pro vykreslení kruhu, který představuje konec čáry
                    float diameter = p.Width;// Průměr kruhu je dán šířkou pera
                    float diameterX = px.X - diameter / 2;// X-ová souřadnice středu kruhu
                    float diameterY = px.Y - diameter / 2;// Y-ová souřadnice středu kruhu
                    g.FillEllipse(new SolidBrush(p.Color), diameterX, diameterY, diameter, diameter);  // Vykreslení kruhu na koncové pozici čáry 
                    py = px;// Aktualizace předchozí pozice myši pro další kreslení
                }
                else if (index == 6) // Vodovkový štětec 
                {
                    px = e.Location;
                    Color transparentColor = Color.FromArgb(1, p.Color); // Nastavení poloprůhledné barvy
                    float diameter = p.Width;
                    float diameterX = px.X - diameter / 2;
                    float diameterY = px.Y - diameter / 2;
                    g.FillEllipse(new SolidBrush(transparentColor), diameterX, diameterY, diameter, diameter);
                                 
                    circleCenters.Add(px); //Přidání souřadnic středu aktuálního kruhu do seznamu
         
                    if (circleCenters.Count >= 2) // Vytvoření spojení mezi posledním a předposledním kruhem v seznamu
                    {
                        Point prevCenter = circleCenters[circleCenters.Count - 2];
                        g.DrawLine(new Pen(transparentColor, p.Width), prevCenter, px);         
                    }                   
                    py = px;
                }
                if (index == 2) //--> to samé jako pár řádků nahoru
                {
                    px = e.Location;
                    g.DrawLine(erase, px, py);
                    float diameterEraser = p.Width;
                    float diameterEraserX = px.X - diameterEraser / 2;
                    float diameterEraserY = px.Y - diameterEraser / 2;
                    g.FillEllipse(new SolidBrush(Color.White), diameterEraserX, diameterEraserY, diameterEraser, diameterEraser);
                    py = px;
                }
            }

            PicBx.Refresh();
            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {            
            ChangePenSize(TrackBar_PenSize.Value);
        }

        private void ChangePenSize(float pen_width) 
        { 
            p.Width = pen_width;
            erase.Width = pen_width;
        }


        //Buttony s barvami
        private void button2_Click(object sender, EventArgs e)
        {           
            p.Color = Color.Red;
            PicColor.BackColor = Color.Red;
            new_color = Color.Red;
        }
        private void BtnYellow_Click(object sender, EventArgs e)
        {
            p.Color = Color.Yellow;
            PicColor.BackColor = Color.Yellow;
            new_color = Color.Yellow;
        }
        private void BtnOrange_Click(object sender, EventArgs e)
        {
            p.Color = Color.Orange;
            PicColor.BackColor = Color.Orange;
            new_color = Color.Orange;
        }
        private void BtnGreen_Click(object sender, EventArgs e)
        {
            p.Color = Color.Green;
            PicColor.BackColor = Color.Green;
            new_color = Color.Green;
        }
        private void BtnMagenta_Click(object sender, EventArgs e)
        {
            p.Color = Color.Magenta;
            PicColor.BackColor = Color.Magenta;
            new_color = Color.Magenta;
        }
        private void BtnLightBlue_Click(object sender, EventArgs e)
        {
            p.Color = Color.Aqua;
            PicColor.BackColor = Color.Aqua;
            new_color = Color.Aqua;
        }
        private void BtnDarkBlue_Click(object sender, EventArgs e)
        {
            p.Color = Color.Blue;
            PicColor.BackColor = Color.Blue;
            new_color = Color.Blue;
        }
        private void BtnBlack_Click(object sender, EventArgs e)
        {
            p.Color = Color.Black;
            PicColor.BackColor = Color.Black;
            new_color = Color.Black;
        }
        private void BtnLime_Click(object sender, EventArgs e)
        {
            p.Color = Color.Lime;
            PicColor.BackColor = Color.Lime;
            new_color = Color.Lime;
        }
        private void BtnGold_Click(object sender, EventArgs e)
        {
            p.Color = Color.Gold;
            PicColor.BackColor = Color.Gold;
            new_color = Color.Gold;
        }
        private void BtnPink_Click(object sender, EventArgs e)
        {
            p.Color = Color.Pink;
            PicColor.BackColor = Color.Pink;
            new_color = Color.Pink;
        }
        private void BtnGreenYellow_Click(object sender, EventArgs e)
        {
            p.Color = Color.GreenYellow;
            PicColor.BackColor = Color.GreenYellow;
            new_color = Color.GreenYellow;
        }
        private void BtnTeal_Click(object sender, EventArgs e)
        {
            p.Color = Color.Teal;
            PicColor.BackColor = Color.Teal;
            new_color = Color.Teal;
        }
        private void BtnPurple_Click(object sender, EventArgs e)
        {
            p.Color = Color.Purple;
            PicColor.BackColor = Color.Purple;
            new_color = Color.Purple;
        }
        private void BtnBrown_Click(object sender, EventArgs e)
        {
            p.Color = Color.Brown;
            PicColor.BackColor = Color.Brown;
            new_color = Color.Brown;
        }
        //Konec Buttonů s barvami
        

        private void TrackBar_Vodovka_Scroll(object sender, EventArgs e) // Tohle je z chatu gpt ale bohužel to nefuguje. Mělo to měnit hodnotu transparentnosti ale nebyl jsem schopen přijít na to jak to dotáhnout do konce.
        {
            ChangeTransparency(TrackBar_Vodovka.Value);
        }
        private void ChangeTransparency(int transparencyValue)
        {
            int alpha = transparencyValue * 255 / 100; // Převod hodnoty na rozsah alfa kanálu (0-255)
            p.Color = Color.FromArgb(alpha, p.Color.R, p.Color.G, p.Color.B); // Nastavení nové barvy s upravenou průhledností
        }

        private void panel2_Paint(object sender, PaintEventArgs e) 
        {
        }
 
        private void PicBx_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            sX = x - cX;
            sY = y - cY;

            if (index == 3) 
            { 
                g.DrawEllipse(p,cX,cY,sX,sY);            
            }
            if (index == 4) 
            {
                g.DrawRectangle(p,cX,cY,sX,sY);
            }
            if (index == 5) 
            {
                g.DrawLine(p,cX,cY,x,y);
            }
            circleCenters.Clear();//Když přestanu krestlit tak mi to vyčistí list aby se mi už nedělali spojnice mezi tím co jem nakreslil předtím a tím co budu kreslit
        }

        static Point set_point(PictureBox pb, Point pt) 
        {
            float pX = 1f * pb.Width / pb.Width;// Výpočet poměru šířky PictureBoxu k jeho vlastní šířce
            float pY = 1f * pb.Height / pb.Height;// Výpočet poměru výšky PictureBoxu k jeho vlastní výšce
            return new Point ((int)(pt.X*pX), (int)(pt.Y*pY));  // Transformace absolutních souřadnic bodu na relativní souřadnice // Návrat nového bodu s relativními souřadnicemi
        }

        private void PicBx_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 7)
            {
                Point point = set_point(PicBx, e.Location);
                Fill(bm, point.X, point.Y, new_color);
            }
        }       
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void validate(Bitmap bm, Stack<Point> sp, int x, int y, Color old_color, Color new_color) 
        { 
            Color cx = bm.GetPixel(x, y);// Získání barvy pixelu na souřadnicích (x, y) z bitmapy
            if (cx == old_color) // Kontrola, zda je barva pixelu shodná s původní barvou
            { 
                sp.Push(new Point(x, y));// Pokud je barva pixelu shodná s původní barvou, přidej souřadnice pixelu do zásobníku
                bm.SetPixel(x, y,new_color);// Nastav novou barvu pixelu na zadaných souřadnicích
            }
        }

        public void Fill(Bitmap bm, int x, int y, Color new_clr) // Tato část kódu slouží k udělání bucketu.
        {
            Color old_color = bm.GetPixel(x, y);// Získání původní barvy pixelu na zadaných souřadnicích
            Stack<Point> pixel = new Stack<Point>();// Vytvoření zásobníku pro ukládání pixelů, které budou validovány a vyplněny
            pixel.Push(new Point(x, y));// Přidání zadaného pixelu do zásobníku a nastavení nové barvy pixelu
            bm.SetPixel(x, y, new_clr);
            if (old_color == new_clr) return;// Pokud je původní barva pixelu shodná s novou barvou, ukonči vyplňování

            while (pixel.Count > 0)// Iterativní proces vyplňování pixelů
            {
                Point pt = (Point)pixel.Pop();// Odebrání pixelu ze zásobníku
                if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)// Pokud pixel leží uvnitř hranic bitmapy, zavolej metodu validate pro jeho okolní pixely
                {
                    validate(bm, pixel, pt.X - 1, pt.Y, old_color, new_clr); // Zavolá metodu ValidateAndFill pro každý sousední pixel.
                    validate(bm, pixel, pt.X, pt.Y - 1, old_color, new_clr);
                    validate(bm, pixel, pt.X + 1, pt.Y, old_color, new_clr);
                    validate(bm, pixel, pt.X, pt.Y + 1, old_color, new_clr);
                }
            }

        }
    }
}
