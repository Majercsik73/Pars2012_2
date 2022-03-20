using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pars2012_2
{
    class Program
    {
        static List<Versenyzo> selejtezo = new List<Versenyzo>();
        static Dictionary<string, double> eredmenyek = new Dictionary<string, double>();

        static void Main(string[] args)
        {
            string[] teljesSelejtezo = File.ReadAllLines("../../../../Selejtezo2012.txt");

            for (int i = 1; i < teljesSelejtezo.Length; i++)
            {
                selejtezo.Add(new Versenyzo(teljesSelejtezo[i]));
            }

            Otodikfeladat();

            Hatodikfeladat();

            Kilencedikfeladat();

            Tizedikfeladat();
        }

        public static void Tizedikfeladat()
        {
            StreamWriter sw = new StreamWriter("Dontos2012.txt");
            sw.WriteLine("Helyezés;Név;Csoport;Nemzet;NemzetKód;Sorozat;Eredmény");

            for (int i = 1; i < 13; i++)
            {
                double legnagyobbdobas = 0.0;
                string doboneve = "";
                for (int j = 0; j < eredmenyek.Count; j++)
                {

                    if (legnagyobbdobas < eredmenyek.ElementAt(j).Value)
                    {
                        legnagyobbdobas = eredmenyek.ElementAt(j).Value;
                        doboneve = eredmenyek.ElementAt(j).Key;
                    }
                }
                //Console.WriteLine($"A legjobb dobó: {doboneve} , eredménye: {legnagyobbdobas}   !");

                for (int k = 0; k < selejtezo.Count; k++)
                {
                    if (selejtezo[k].nev == doboneve)
                    {
                        sw.WriteLine($"{i};{doboneve};{selejtezo[k].csoport};" +
                        $"{selejtezo[k].Nemzet};{selejtezo[k].Kod};" +
                        $"{selejtezo[k].sorozat};{legnagyobbdobas}");
                    }
                }
                eredmenyek.Remove(doboneve);
            }
            sw.Close();
        }

        public static void Kilencedikfeladat()
        {

            for (int i = 0; i < selejtezo.Count; i++)
            {
                eredmenyek.Add(selejtezo[i].nev, selejtezo[i].Eredmeny);
                Console.WriteLine($"{selejtezo[i].nev} :   {selejtezo[i].Eredmeny}");
            }

            double legnagyobbdobas = 0.0;
            string doboneve = "";
            for (int j = 0; j < eredmenyek.Count; j++)
            {

                if (legnagyobbdobas < eredmenyek.ElementAt(j).Value)
                {
                    legnagyobbdobas = eredmenyek.ElementAt(j).Value;
                    doboneve = eredmenyek.ElementAt(j).Key;
                }
            }
            //Console.WriteLine($"A legjobb dobó: {doboneve} , eredménye: {legnagyobbdobas}   !");



            for (int k = 0; k < selejtezo.Count; k++)
            {
                if (selejtezo[k].nev == doboneve)
                {
                    Console.WriteLine($"9. feladat: A selejtező nyertese:\n\t" +
                        $"Név: {selejtezo[k].nev}\n\tCsoport: {selejtezo[k].csoport}" +
                        $"\n\tNemzet: {selejtezo[k].Nemzet}\n\tNemzet kód: {selejtezo[k].Kod}\n\t" +
                        $"Sorozat: {selejtezo[k].sorozat};\n\tEredmény: {legnagyobbdobas}");
                }
            }

        }

        private static void Hatodikfeladat()
        {
            int db = 0;
            for (int i = 0; i < selejtezo.Count; i++)
            {
                if (Convert.ToDouble(selejtezo[i].d1) > 78.00 || Convert.ToDouble(selejtezo[i].d2) > 78.00 || Convert.ToDouble(selejtezo[i].d3) > 78.00)
                {
                    db++;
                }
            }

            Console.WriteLine($"6. feladat: 78,00 méter feletti eredménnyel továbbjutott: {db} fő");
        }

        private static void Otodikfeladat()
        {
            Console.WriteLine($"5. feladat: Versenyzők száma a selejtezőben: {selejtezo.Count} fő!");
        }
    }
}
