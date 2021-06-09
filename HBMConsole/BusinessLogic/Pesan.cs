using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMConsole.BusinessLogic
{
    public static class Pesan
    {
        public static void Error(string teks)
        {
            var tempForeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\tError: " + teks);
            Console.ForegroundColor = tempForeColor;
            Console.WriteLine("\tTekan Enter untuk melanjutkan...\n");
            Console.ReadKey();
        }

        public static void Warning(string teks)
        {
            var tempColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\tWarning: " + teks);
            Console.ForegroundColor = tempColor;
            Console.WriteLine("\tTekan Enter untuk melanjutkan...\n");
            Console.ReadKey();
        }
        
    }
}