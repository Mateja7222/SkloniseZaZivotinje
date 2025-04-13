using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace SkloniseZaZivotinje
{
    class Pas : Zivotinja
    {
        public string Rasa 
        { get;
          set; }
        public bool Vakcinisan 
        { get;
          set; }

        public override void Upisi(StreamWriter f)
        {
            f.WriteLine("Pas");
            f.WriteLine(Ime);
            f.WriteLine(Tezina);
            f.WriteLine(Rasa);
            f.WriteLine(Vakcinisan);
        }

        public override void Citaj(StreamReader f, string vrsta)
        {
            Ime = f.ReadLine();
            Tezina = Convert.ToDouble(f.ReadLine());
            Rasa = f.ReadLine();
            Vakcinisan = Convert.ToBoolean(f.ReadLine());
        }

        public override string ToString()
        {
            return Ime+":"+Convert.ToString(Tezina)+" kg ,Rasa:"+Rasa+",Vakcinisan:"+Vakcinisan;
        }

        public void CrtajGlavuPsa(Graphics g, int x, int y, float a, float b, float pr)
        {
            Pen olovka = new Pen(Color.SaddleBrown, 2);
            SolidBrush cetka = new SolidBrush(Color.SandyBrown);

            g.FillEllipse(cetka, x - a / 2, y - b / 2, a, b);
            g.DrawEllipse(olovka, x - a / 2, y - b / 2, a, b);

            cetka.Color = Color.Black;
            float okoR = a / 10;
            g.FillEllipse(cetka, x - a / 4 - okoR / 2, y - b / 6, okoR, okoR);
            g.FillEllipse(cetka, x + a / 4 - okoR / 2, y - b / 6, okoR, okoR);

            cetka.Color = Color.Black;
            g.FillEllipse(cetka, x - a / 6, y + b / 6, a / 3, b / 4);

            Point[] levoUvo = 
                {
                new Point((int)(x - a / 2), (int)(y - b / 2)),
                new Point((int)(x - a / 2 + a / 6), (int)(y - b / 2 - b / 3)),
                new Point((int)(x - a / 2 + a / 3), (int)(y - b / 2))
                };
            Point[] desnoUvo = 
                {
                new Point((int)(x + a / 2), (int)(y - b / 2)),
                new Point((int)(x + a / 2 - a / 6), (int)(y - b / 2 - b / 3)),
                new Point((int)(x + a / 2 - a / 3), (int)(y - b / 2))
                };

            cetka.Color = Color.SaddleBrown;
            g.FillPolygon(cetka, levoUvo);
            g.FillPolygon(cetka, desnoUvo);
        }
    }

}
