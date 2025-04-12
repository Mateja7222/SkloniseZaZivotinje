using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SkloniseZaZivotinje
{
    public partial class Form1 : Form
    {
        List<Zivotinja> zivotinje = new List<Zivotinja>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UcitajZivotinje();
        }
        void UcitajZivotinje()
        {
            zivotinje.Clear();
            listBox1.Items.Clear();
            StreamReader f = new StreamReader("zivotinje.txt");
                while (!f.EndOfStream)
                {
                    string vrsta = f.ReadLine();
                    Zivotinja z = null;

                    if (vrsta == "Pas")
                        z = new Pas();
                    else if (vrsta == "Macka")
                        z = new Macka();

                    if (z != null)
                    {
                        z.Citaj(f, vrsta);
                        zivotinje.Add(z);
                        listBox1.Items.Add(z.ToString());
                   }
                }
            f.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                for (int i = 0; i < zivotinje.Count - 1; i++)
                {
                    for (int j = 0; j < zivotinje.Count - 1 - i; j++)
                    {
                        if (zivotinje[j].Tezina < zivotinje[j + 1].Tezina)
                        {

                            Zivotinja temp = zivotinje[j];
                            zivotinje[j] = zivotinje[j + 1];
                            zivotinje[j + 1] = temp;
                        }
                    }
                }

                listBox1.Items.Clear();
                for (int i = 0; i < zivotinje.Count; i++)
                {
                    listBox1.Items.Add(zivotinje[i].ToString());
                }
            }
        }
        float prosekPas;
        float prosekMacka;
        private void button2_Click(object sender, EventArgs e)
        {
            double prosekPa = zivotinje.OfType<Pas>().Average(z => z.Tezina);
            double prosekMa = zivotinje.OfType<Macka>().Average(z => z.Tezina);
            textBox1.Text = prosekPa.ToString();
            textBox2.Text = prosekMa.ToString();
            prosekPas = Convert.ToSingle (prosekPa);
            prosekMacka = Convert.ToSingle(prosekMa);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Pas p = new Pas
                {
                    Ime = textBox3.Text,
                    Tezina = Convert.ToDouble(textBox4.Text),
                    Rasa = textBox5.Text,
                    Vakcinisan = checkBox1.Checked
                };
                zivotinje.Add(p);

                StreamWriter f = new StreamWriter("zivotinje.txt", true);
                p.Upisi(f);
                f.Close();
            }
            else if (radioButton2.Checked)
            {
                Macka m = new Macka
                {
                    Ime = textBox3.Text,
                    Tezina = Convert.ToDouble(textBox4.Text),
                    Boja = textBox5.Text,
                    Sterilisana = checkBox1.Checked
                };
                zivotinje.Add(m);

                StreamWriter f = new StreamWriter("zivotinje.txt", true);
                m.Upisi(f);
                f.Close();
            }

            MessageBox.Show("Životinja dodata!");
            UcitajZivotinje();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string unos = textBox6.Text.ToLower();

            listBox1.Items.Clear();

            for (int i = 0; i < zivotinje.Count; i++)
            {
                Zivotinja z = zivotinje[i];

                if (radioButton3.Checked && z is Pas) 
                {
                    if (z.Ime.ToLower().StartsWith(unos))
                    {
                        listBox1.Items.Add(z.ToString());
                    }
                }
                else if (radioButton4.Checked && z is Macka)
                {
                    if (z.Ime.ToLower().StartsWith(unos))
                    {
                        listBox1.Items.Add(z.ToString());
                    }
                }
  
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Zivotinja nzivotinja = zivotinje[listBox1.SelectedIndex];
                int x = ClientRectangle.Width / 2;
                int y = ClientRectangle.Height / 2+100;
                float a = 80;
                float b = 80;
                float o;
                float r;

                Graphics g = this.CreateGraphics();
                    if (nzivotinja is Pas p)
                    {
                        Refresh();
                        o = Convert.ToSingle(nzivotinja.Tezina);
                        r = o / prosekPas;
                        a = a * r;
                        b = b * r;
                        p.CrtajGlavuPsa(g, x, y, a, b, r);
                    }
                    else if (nzivotinja is Macka m)
                    {
                        Refresh();
                        o = Convert.ToSingle(nzivotinja.Tezina);
                        r = o / prosekMacka;
                        a = a * r;
                        b = b * r;
                        m.CrtajGlavuMacke(g, x, y, a, b, r);
                    }
            }
            else
            {
                MessageBox.Show("Izaberite životinju!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
