using System;
using System.Collections.Generic;
using System.Text;

namespace Pars2012_2
{
    class Versenyzo
    {
        public string nev { get; set; }
        public string csoport { get; set; }
        public string nemzetEsKod { get; set; }
        public string sorozat { get; set; }
        public string d1 { get; set; }
        public string d2 { get; set; }
        public string d3 { get; set; }

        public Versenyzo(string sor)
        {
            string[] sordarab = sor.Split(";");

            nev = sordarab[0];
            csoport = sordarab[1];
            nemzetEsKod = sordarab[2];
            sorozat = $"{sordarab[3]};{sordarab[4]};{sordarab[5]}";
            d1 = Konvertal(sordarab[3]);
            d2 = Konvertal(sordarab[4]);
            d3 = Konvertal(sordarab[5]);
        }

        public static string Konvertal(string elem)
        {
            if (elem == "X")
            {
                return "-1,0";
            }
            else if (elem == "-")
            {
                return "-2,0";
            }
            else return elem;
        }

        public double Eredmeny
        {
            get
            {
                double legjobb = 0.0;
                if (Convert.ToDouble(d1) > Convert.ToDouble(d2))
                {
                    if (Convert.ToDouble(d1) > Convert.ToDouble(d3))
                    {
                        legjobb = Convert.ToDouble(d1);
                    }
                    else
                    {
                        legjobb = Convert.ToDouble(d3);
                    }
                }
                else
                {
                    if (Convert.ToDouble(d2) > Convert.ToDouble(d3))
                    {
                        legjobb = Convert.ToDouble(d2);
                    }
                    else
                    {
                        legjobb = Convert.ToDouble(d3);
                    }
                }
                return legjobb;
            }
        }

        public string Nemzet
        {
            get
            {
                string[] nemzete = nemzetEsKod.Split("(");
                string nemzet = nemzete[0].TrimEnd();
                return nemzet;
            }
        }

        public string Kod
        {
            get
            {
                string[] kodja = nemzetEsKod.Split("(");
                string kod = kodja[1].Replace(")", "");
                return kod;
            }
        }
    }
}
