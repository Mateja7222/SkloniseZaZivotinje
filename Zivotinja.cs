using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace SkloniseZaZivotinje
{
    abstract public class Zivotinja
    {
        public string Vrsta { get; set; }
        public string Ime { get; set; }
        public double Tezina { get; set; }
        public abstract void Upisi(StreamWriter f);
        public abstract void Citaj(StreamReader f, string vrsta);

        public override string ToString()
        {
            return Ime + "-" + Convert.ToString(Tezina);
        }
    }
}