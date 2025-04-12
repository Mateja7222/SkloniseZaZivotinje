using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace SkloniseZaZivotinje
{
    class Macka : Zivotinja
    {
        public string Boja { get; set; }
        public bool Sterilisana { get; set; }

        public override void Upisi(StreamWriter f)
        {
            f.WriteLine("Macka");
            f.WriteLine(Ime);
            f.WriteLine(Tezina);
            f.WriteLine(Boja);
            f.WriteLine(Sterilisana);
        }

        public override void Citaj(StreamReader f, string vrsta)
        {
            Ime = f.ReadLine();
            Tezina = double.Parse(f.ReadLine());
            Boja = f.ReadLine();
            Sterilisana = bool.Parse(f.ReadLine());
        }

        public override string ToString()
        {
            return base.ToString() + $", Boja: {Boja}, Sterilisana: {Sterilisana}";
        }

        public void CrtajGlavuMacke(Graphics g, int x, int y, float a, float b, float pr)
        {
            Pen olovka = new Pen(Color.Black, 2);
            SolidBrush cetka = new SolidBrush(Color.LightGray);


            // Glava (krug)
            RectangleF glava = new RectangleF(x - a / 2, y - b / 2, a, b);
            g.FillEllipse(cetka, glava);
            g.DrawEllipse(olovka, glava);

            // Uši (trouglovi)
            PointF[] levoUvo = {
        new PointF(x - a / 2 + 5, y - b / 2 + 10),
        new PointF(x - a / 2 + a / 4, y - b),
        new PointF(x - a / 4, y - b / 2)
    };
            PointF[] desnoUvo = {
        new PointF(x + a / 2 - 5, y - b / 2 + 10),
        new PointF(x + a / 2 - a / 4, y - b),
        new PointF(x + a / 4, y - b / 2)
    };
            g.FillPolygon(cetka, levoUvo);
            g.FillPolygon(cetka, desnoUvo);
            g.DrawPolygon(olovka, levoUvo);
            g.DrawPolygon(olovka, desnoUvo);

            // Oči
            cetka.Color = Color.Green;
            g.FillEllipse(cetka, x - a / 4 - 5, y - b / 8, a / 6, b / 6); // levo oko
            g.FillEllipse(cetka, x + a / 4 - a / 6 + 5, y - b / 8, a / 6, b / 6); // desno oko

            // Zjenice
            cetka.Color = Color.Black;
            g.FillEllipse(cetka, x - a / 4, y - b / 10, a / 15, b / 6); // leva
            g.FillEllipse(cetka, x + a / 4 - a / 10, y - b / 10, a / 15, b / 6); // desna

            // Nos
            cetka.Color = Color.Pink;
            g.FillEllipse(cetka, x - a / 10, y + b / 10, a / 5, b / 10);

            // Brkovi
            g.DrawLine(olovka, x - a / 3, y + b / 10, x - a / 1.5f, y); // levi 1
            g.DrawLine(olovka, x - a / 3, y + b / 12, x - a / 1.5f, y - b / 20); // levi 2
            g.DrawLine(olovka, x - a / 3, y + b / 8, x - a / 1.5f, y + b / 20); // levi 3

            g.DrawLine(olovka, x + a / 3, y + b / 10, x + a / 1.5f, y); // desni 1
            g.DrawLine(olovka, x + a / 3, y + b / 12, x + a / 1.5f, y - b / 20); // desni 2
            g.DrawLine(olovka, x + a / 3, y + b / 8, x + a / 1.5f, y + b / 20); // desni 3
        }
    }
}
