using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console2048
{
    static class Tool
    {
        internal static int[,] plansza = new int[4, 4];
        public static char znak;
        public static void gra()
        {
            Plansza.losoweMiejsceTo2("start");
            while (true)
            {
                Console.WriteLine("W,S,A,D aby sterowac");
                Console.WriteLine($"Wynik:{Tool.wynik()}");
                Plansza.wypisz();
                if (Tool.wynik() == 2048)
                {
                    Console.WriteLine("WYGRALES");
                    break;
                }
                if (Tool.przegranaCheck() == 16)
                {
                    Console.WriteLine("PRZEGRALES");
                    break;
                }
                Tool.wejscieWsad();
                Plansza.losoweMiejsceTo2();
                Console.Clear();

            }
        }
        public static void wejscieWsad()
        {
            znak = Console.ReadKey().KeyChar;
            switch (znak)
            {
                case 'w': Tool.ifW(); break;
                case 's': Tool.ifS(); break;
                case 'a': Tool.ifA(); break;
                case 'd': Tool.ifD(); break;

            }

        }
        public static void ifW()
        {
            for (int i = 0; i < 4; i++)//dla każdej kolumny
            {
                #region usuwanieZer
                while (plansza[0, i] == 0 && (plansza[1, i] > 0 || plansza[2, i] > 0 || plansza[3, i] > 0))//usuwanie zer ze skraju gory, gdy przynajmniej jedna zmienna w kolumnie
                {
                    if (plansza[0, i] == 0)
                    {
                        for (int e = 0; e < 3; e++)
                        {
                            plansza[e, i] = plansza[e + 1, i];//przesuwa wartosci na planszy w gora
                            if (e == 2) plansza[e + 1, i] = 0;//czysci ostatnia kolumne z dolu
                        }
                    }
                    else if (plansza[0, i] != 0) { break; }//gdy nie ma zera w gorze przerywa
                }
                if (plansza[2, i] < plansza[3, i] && plansza[2, i] == 0)//gdy zero w 3 wierszu
                {
                    plansza[2, i] = plansza[3, i];
                    plansza[3, i] = 0;
                }
                if (plansza[1, i] < plansza[2, i] && plansza[1, i] == 0)//gdy zero w 2 wierszu
                {
                    plansza[1, i] = plansza[2, i];
                    plansza[2, i] = 0;
                    if (plansza[3, i] != 0)//gdy !0 w 4 wierszu
                    {
                        plansza[2, i] = plansza[3, i];
                        plansza[3, i] = 0;
                    }
                }
                #endregion
                if (plansza[0, i] == plansza[1, i])//1 i 2 wiersz
                {
                    plansza[0, i] += plansza[1, i];
                    plansza[1, i] = plansza[2, i];
                    plansza[2, i] = plansza[3, i];
                    plansza[3, i] = 0;
                }
                if (plansza[1, i] == plansza[2, i])//2 i 3 wiersz
                {
                    plansza[1, i] += plansza[2, i];
                    plansza[2, i] = plansza[3, i];
                    plansza[3, i] = 0;
                }
                if (plansza[2, i] == plansza[3, i])//3 i 4 wiersz
                {
                    plansza[2, i] += plansza[3, i];
                    plansza[3, i] = 0;
                }
            }
        }
        public static void ifS()
        {
            for (int i = 0; i < 4; i++)//dla każdej kolumny
            {
                #region usuwanieZer
                while (plansza[3 - 0, i] == 0 && (plansza[3 - 1, i] > 0 || plansza[3 - 2, i] > 0 || plansza[3 - 3, i] > 0))//usuwanie zer ze skraju gory, gdy przynajmniej jedna zmienna w kolumnie
                {
                    if (plansza[3 - 0, i] == 0)
                    {
                        for (int e = 3; e > 0; e--)
                        {
                            plansza[e, i] = plansza[e - 1, i];//przesuwa wartosci na planszy w gora
                            if (e == 3 - 2) plansza[e - 1, i] = 0;//czysci ostatnia kolumne z dolu
                        }
                    }
                    else if (plansza[3 - 0, i] != 0) { break; }//gdy nie ma zera w gorze przerywa
                }
                if (plansza[3 - 2, i] < plansza[3 - 3, i] && plansza[3 - 2, i] == 0)//gdy zero w 3 wierszu
                {
                    plansza[3 - 2, i] = plansza[3 - 3, i];
                    plansza[3 - 3, i] = 0;
                }
                if (plansza[3 - 1, i] < plansza[3 - 2, i] && plansza[3 - 1, i] == 0)//gdy zero w 2 wierszu
                {
                    plansza[3 - 1, i] = plansza[3 - 2, i];
                    plansza[3 - 2, i] = 0;
                    if (plansza[3 - 3, i] != 0)//gdy !0 w 4 wierszu
                    {
                        plansza[3 - 2, i] = plansza[3 - 3, i];
                        plansza[3 - 3, i] = 0;
                    }
                }
                #endregion
                if (plansza[3 - 0, i] == plansza[3 - 1, i])//1 i 2 wiersz
                {
                    plansza[3 - 0, i] += plansza[3 - 1, i];
                    plansza[3 - 1, i] = plansza[3 - 2, i];
                    plansza[3 - 2, i] = plansza[3 - 3, i];
                    plansza[3 - 3, i] = 0;
                }
                if (plansza[3 - 1, i] == plansza[3 - 2, i])//2 i 3 wiersz
                {
                    plansza[3 - 1, i] += plansza[3 - 2, i];
                    plansza[3 - 2, i] = plansza[3 - 3, i];
                    plansza[3 - 3, i] = 0;
                }
                if (plansza[3 - 2, i] == plansza[3 - 3, i])//3 i 4 wiersz
                {
                    plansza[3 - 2, i] += plansza[3 - 3, i];
                    plansza[3 - 3, i] = 0;
                }
            }
        }
        public static void ifA()
        {
            for (int i = 0; i < 4; i++)//dla każdego wiersza
            {
                #region usuwanieZer
                while (plansza[i, 0] == 0 && (plansza[i, 1] > 0 || plansza[i, 2] > 0 || plansza[i, 3] > 0))//usuwanie zer ze skraju lewej, gdy przynajmniej jedna zmienna w wierszu
                {
                    if (plansza[i, 0] == 0)
                    {
                        for (int e = 0; e < 3; e++)
                        {
                            plansza[i, e] = plansza[i, e + 1];//przesuwa wartosci na planszy w lewo
                            if (e == 2) plansza[i, e + 1] = 0;//czysci ostatnia kolumne z prawej
                        }
                    }
                    else if (plansza[i, 0] != 0) { break; }//gdy nie ma zera po lewej przerywa
                }
                if (plansza[i, 2] < plansza[i, 3] && plansza[i, 2] == 0)//gdy zero w 3 kolumnie
                {
                    plansza[i, 2] = plansza[i, 3];
                    plansza[i, 3] = 0;
                }
                if (plansza[i, 1] < plansza[i, 2] && plansza[i, 1] == 0)//gdy zero w 2 kolumnie
                {
                    plansza[i, 1] = plansza[i, 2];
                    plansza[i, 2] = 0;
                    if (plansza[i, 3] != 0)//gdy !0 w 4 kolumnie
                    {
                        plansza[i, 2] = plansza[i, 3];
                        plansza[i, 3] = 0;
                    }
                }
                #endregion
                if (plansza[i, 0] == plansza[i, 1])//1 i 2 kolumna
                {
                    plansza[i, 0] += plansza[i, 1];
                    plansza[i, 1] = plansza[i, 2];
                    plansza[i, 2] = plansza[i, 3];
                    plansza[i, 3] = 0;
                }
                if (plansza[i, 1] == plansza[i, 2])//2 i 3 kolumna
                {
                    plansza[i, 1] += plansza[i, 2];
                    plansza[i, 2] = plansza[i, 3];//edit
                    plansza[i, 3] = 0;
                }
                if (plansza[i, 2] == plansza[i, 3])//3 i 4 kolumna
                {
                    plansza[i, 2] += plansza[i, 3];
                    plansza[i, 3] = 0;
                }
            }

        }
        public static void ifD()
        {
            for (int i = 0; i < 4; i++)//dla każdego wiersza
            {
                #region usuwanieZer
                while (plansza[i, 3 - 0] == 0 && (plansza[i, 3 - 1] > 0 || plansza[i, 3 - 2] > 0 || plansza[i, 3 - 3] > 0))//usuwanie zer ze skraju prawej, gdy przynajmniej jedna zmienna w wierszu
                {
                    if (plansza[i, 3 - 0] == 0)
                    {
                        for (int e = 3; e > 0; e--)
                        {
                            plansza[i, e] = plansza[i, e - 1];//przesuwa wartosci na planszy w prawo
                            if (e == 3 - 2) plansza[i, e - 1] = 0;//czysci ostatnia kolumne z lewej
                        }
                    }
                    else if (plansza[i, 3 - 0] != 0) { break; }//gdy nie ma zera po prawej przerywa
                }
                if (plansza[i, 3 - 2] < plansza[i, 3 - 3] && plansza[i, 3 - 2] == 0)//gdy zero w 4-3 kolumnie
                {
                    plansza[i, 3 - 2] = plansza[i, 3 - 3];
                    plansza[i, 3 - 3] = 0;
                }
                if (plansza[i, 3 - 1] < plansza[i, 3 - 2] && plansza[i, 3 - 1] == 0)//gdy zero w 4-2 kolumnie
                {
                    plansza[i, 3 - 1] = plansza[i, 3 - 2];
                    plansza[i, 3 - 2] = 0;
                    if (plansza[i, 3 - 3] != 0)//gdy !0 w 4-4 kolumnie
                    {
                        plansza[i, 3 - 2] = plansza[i, 3 - 3];
                        plansza[i, 3 - 3] = 0;
                    }
                }
                #endregion
                if (plansza[i, 3 - 0] == plansza[i, 3 - 1])//4-1 i 4-2 kolumna
                {
                    plansza[i, 3 - 0] += plansza[i, 3 - 1];
                    plansza[i, 3 - 1] = plansza[i, 3 - 2];
                    plansza[i, 3 - 2] = plansza[i, 3 - 3];
                    plansza[i, 3 - 3] = 0;
                }
                if (plansza[i, 3 - 1] == plansza[i, 3 - 2])//4-2 i 4-3 kolumna
                {
                    plansza[i, 3 - 1] += plansza[i, 3 - 2];
                    plansza[i, 3 - 2] = plansza[i, 3 - 3];
                    plansza[i, 3 - 3] = 0;
                }
                if (plansza[i, 3 - 2] == plansza[i, 3 - 3])//4-3 i 4-4 kolumna
                {
                    plansza[i, 3 - 2] += plansza[i, 3 - 3];
                    plansza[i, 3 - 3] = 0;
                }
            }
        }
        public static int przegranaCheck()
        {
            int j = 0;
            for (int y = 0; y < plansza.GetLength(0); y++)
            {
                for (int x = 0; x < plansza.GetLength(1); x++)
                {
                    if (plansza[y, x] != 0) j++;
                }
            }
            return j;
        }
        public static int wynik()
        {
            List<int> lista = new List<int>();
            foreach (var a in plansza)
            {
                lista.Add(a);
            }
            return lista.Max();
        }
        public static string konwersja(int wejscie)
        {
            string wyjscie = wejscie.ToString();
            if (wejscie == 0)
            {
                return wyjscie = "    ";
            }
            else if (wyjscie.Length == 3)
            {
                return wyjscie.PadLeft(4, ' ');
            }
            else if (wyjscie.Length <= 2)
            {
                return wyjscie.PadLeft(3, ' ').PadRight(4, ' ');
            }
            else
            {
                return wyjscie;
            }
        }


    }
}
