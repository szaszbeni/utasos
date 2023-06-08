using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20230525_utasszalito
{
    class Típus
        {
        public string tipus, utas, személyzet;
        public int év, utazósebesség, felszállótömeg;
        public double fesztav;
        public Típus(string egysor)
        {
            string[] darabok = egysor.Split(';');
            tipus = darabok[0];
            év = int.Parse(darabok[1]);
            utas = darabok[2];
            személyzet = darabok[3];
            utazósebesség = int.Parse(darabok[4]);
            felszállótömeg = int.Parse(darabok[5]);
            fesztav = double.Parse(darabok[6]);
        }
    }
    class Sebessegkategoria
    {
        private int Utazosebesseg;
        public string Kategorianev
        {
            get
            {
                if (Utazosebesseg < 500) return "Alacsony sebességű";
                else if (Utazosebesseg < 1000) return "Szubszonikus";
                else if (Utazosebesseg < 1200) return "Transzszonikus";
                else return "Szuperszonikus";
            }
        }
        public Sebessegkategoria(int utazosebesseg)
        {
            Utazosebesseg = utazosebesseg;
        }
    }
    class Program
    {
        static List<Típus> tipusok = new List<Típus>();
        static List<Sebessegkategoria> sebeesseg = new List<Sebessegkategoria>();
        static int utasszallitok;
        static void Main(string[] args)
        {
            feladat3();
            feladat4();
            feladat5();
            feladat6();
            Console.WriteLine("enter");
            Console.ReadLine();
        }
        static void feladat3()
        {
            foreach (var item in File.ReadAllLines("utasszallitok.txt" , Encoding.UTF8).Skip(1))
            {
                tipusok.Add(new Típus(item));
            }
        }
        static void feladat4()
        {
            Console.WriteLine($"4. feladat: Adatsorok száma  {tipusok.Count}");
        }
        static void feladat5()
        {
            int db = 0;
            foreach (var item in tipusok)
            {
                if (item.tipus.Contains("Boeing"))
                {
                    db++;
                }
            }
            Console.WriteLine($"5. feladat: Boing tipusok szama {db}");
        }
        static void feladat6()
        {
            List<int> utasok = new List<int>();
            foreach (var item in tipusok)
            {
                if (item.utas.Contains("-"))
                {
                    utasok.Add(int.Parse(item.utas.Split('-')[1]));
                }
                else
                {
                    utasok.Add(int.Parse(item.utas));
                }
            }
            Console.WriteLine($"6. feladat: A legtöbb utast szállitó repülőgéptípus");
            int maxertek = utasok[0];
            int maxindex = 0;
            for (int i = 0; i < utasok.Count; i++)
            {
                if (utasok[i] > maxertek)
                {
                    maxertek = utasok[i];
                    maxertek = i;
                }
            }
            Console.WriteLine($"\t Típus: {tipusok[maxindex].tipus}");
            Console.WriteLine($"\t Első felszállás: {tipusok[maxindex].év}");
            Console.WriteLine($"\t utasok szama: {tipusok[maxindex].utas}");
            Console.WriteLine($"\t személyzet: {tipusok[maxindex].személyzet}");
            Console.WriteLine($"\t utazósebesség: {tipusok[maxindex].utazósebesség}");
        }
    }
}

