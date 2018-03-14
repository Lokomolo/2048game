using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console2048
{
    //narzedziowa
    static class Tools
    {
        #region wsad
        static public void Ifw()
        {
            Console.WriteLine("wypisales w");
        }
        static public void Ifs()
        {
            Console.WriteLine("wypisales s");
        }
        static public void Ifa(int[,]x)
        {
            for (int i = 0; i <4; i++)
            {
                if(x[i, 0]== x[i, 1])
                {
                    x[i, 0] += x[i, 1];
                    x[i, 1] = 0;
                }
                if (x[i, 2] == x[i, 3])
                {
                    x[i, 2] += x[i, 3];
                    x[i, 3] = 0;
                }

            }
            
        }
        static public void Ifd()
        {
            Console.WriteLine("wypisales d");
        }
        #endregion
        public static string konwersja(int wejscie)
        {
            string wyjscie = wejscie.ToString();
            if (wyjscie.Length == 3)
            {
                return wyjscie.PadLeft(4,' ');
            }
            else if (wyjscie.Length <= 2)
            {
                //wyjscie.PadLeft(3, ' ');
               return wyjscie.PadLeft(3, ' ').PadRight(4,' ');
            }
            else
            {
                return wyjscie;
            }
            //return wyjscie;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int przykladowawartosc = 0;
            int[,] plansza = new int[4, 4];
            #region test
            //for (int y = 0; y < plansza.GetLength(0); y++)
            //{
            //    for (int x = 0; x < plansza.GetLength(1);   x++)
            //    {
            //        przykladowawartosc++;
            //        plansza[y,x ] = przykladowawartosc;
            //    }
            //}
            ////zmiana koncowej warosci do sb i poprawa wyswietlenia na planszy
            //string cd = "1";
            //if (cd.Length == 1)
            //{
            //    StringBuilder sb1 = new StringBuilder(cd);
            //    sb1.Insert(0, " ");
            //    sb1.Insert(1,"   ");
            //    Console.WriteLine("sb"+sb1+"sb");
            //    StringBuilder[] tabelaSb = new StringBuilder[16]; int e=0;
            //    for (int y = 0; y < plansza.GetLength(0); y++)
            //    {
            //        for (int x = 0; x < plansza.GetLength(1); x++)
            //        {

            //            tabelaSb[e].Append(plansza[y, x].ToString());
            //            e++;
            //        }
            //    }
            //    foreach (var dsa in tabelaSb)
            //    {
            //        Console.WriteLine(dsa);
            //    }
            //    }
            #endregion
            for (int x = 0; x < plansza.GetLength(0); x++)
            {
                for (int y = 0; y < plansza.GetLength(1); y++)
                {
                   plansza[x,y]=2;
                }
            }

            while (true)
            {
                #region Plansza
                Console.WriteLine("---------------------");
                Console.WriteLine("|{0}|{1}|{2}|{3}|" + "\n",Tools.konwersja(plansza[0, 0]), Tools.konwersja(plansza[0, 1]), Tools.konwersja(plansza[0, 2]), Tools.konwersja(plansza[0, 3]));
                Console.WriteLine("|{0}|{1}|{2}|{3}|"+ "\n", Tools.konwersja(plansza[1, 0]), Tools.konwersja(plansza[1, 1]), Tools.konwersja(plansza[1, 2]), Tools.konwersja(plansza[1, 3]));
                Console.WriteLine("|{0}|{1}|{2}|{3}|" + "\n",Tools.konwersja(plansza[2, 0]), Tools.konwersja(plansza[2, 1]), Tools.konwersja(plansza[2, 2]), Tools.konwersja(plansza[2, 3]));
                Console.WriteLine("|{0}|{1}|{2}|{3}|",       Tools.konwersja(plansza[3, 0]), Tools.konwersja(plansza[3, 1]), Tools.konwersja(plansza[3, 2]), Tools.konwersja(plansza[3, 3]));
                Console.WriteLine("---------------------");
                #endregion
                char wsad;
                wsad = Console.ReadKey().KeyChar;
                switch(wsad)
                {
                    case 'w': Tools.Ifw();break;
                    case 's':Tools.Ifs();break;
                    case 'a':Tools.Ifa(plansza);break;
                    case 'd':Tools.Ifd();break;

                }
                Console.Clear();
                //Console.ReadKey();
            }

        }
    }
}
