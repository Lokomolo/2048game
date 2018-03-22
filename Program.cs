using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console2048
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Tool.gra();
                Plansza.wyczysc();
                Console.WriteLine("Kliknij, aby ponowic");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
