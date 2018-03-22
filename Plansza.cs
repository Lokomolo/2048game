using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console2048
{
    static class Plansza
    {
        static Random los = new Random();
        public static void wypisz()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("|{0}|{1}|{2}|{3}|" + "\n", Tool.konwersja(Tool.plansza[0, 0]), Tool.konwersja(Tool.plansza[0, 1]), Tool.konwersja(Tool.plansza[0, 2]), Tool.konwersja(Tool.plansza[0, 3]));
            Console.WriteLine("|{0}|{1}|{2}|{3}|" + "\n", Tool.konwersja(Tool.plansza[1, 0]), Tool.konwersja(Tool.plansza[1, 1]), Tool.konwersja(Tool.plansza[1, 2]), Tool.konwersja(Tool.plansza[1, 3]));
            Console.WriteLine("|{0}|{1}|{2}|{3}|" + "\n", Tool.konwersja(Tool.plansza[2, 0]), Tool.konwersja(Tool.plansza[2, 1]), Tool.konwersja(Tool.plansza[2, 2]), Tool.konwersja(Tool.plansza[2, 3]));
            Console.WriteLine("|{0}|{1}|{2}|{3}|", Tool.konwersja(Tool.plansza[3, 0]), Tool.konwersja(Tool.plansza[3, 1]), Tool.konwersja(Tool.plansza[3, 2]), Tool.konwersja(Tool.plansza[3, 3]));
            Console.WriteLine("---------------------");
        }
        public static void wyczysc()
        {
            Array.Clear(Tool.plansza, 0, Tool.plansza.GetLength(0) * Tool.plansza.GetLength(1));
        }
        public static void losoweMiejsceTo2()
        {
            if (Tool.znak == 'w' || Tool.znak == 's' || Tool.znak == 'a' || Tool.znak == 'd')
            {
                while (true)
                {
                    int losm = los.Next(0, 16);
                    int y = losm % 4;
                    int z = (losm / 4);
                    if (Tool.plansza[y, z] == 0)// kiedy index pusty
                    {
                        Tool.plansza[y, z] = 2;
                        break;
                    }
                }
            }
        }
        public static void losoweMiejsceTo2(string start)
        {
            while (true)
            {
                int losm = los.Next(0, 16);
                int y = losm % 4;
                int z = (losm / 4);
                if (Tool.plansza[y, z] == 0)// kiedy index pusty
                {
                    Tool.plansza[y, z] = 2;
                    break;
                }
            }
        }
    }
}
