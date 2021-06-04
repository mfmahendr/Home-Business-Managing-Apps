using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing_App.BusinessLogic
{
    public static class Perintah
    {
        private static int pilihan;

        public static int Masukan()
        {
            pilihan = -1;
            Console.WriteLine("\nSilakan pilih menu yang tersedia di atas");
            Console.Write("==> ");
            try
            {
                pilihan = int.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                var tempColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Pilihan tidak boleh kosong");
                Console.ForegroundColor = tempColor;
            }
            catch (FormatException)
            {
                var tempColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Masukan tidak boleh karakter lain selain angka");
                Console.ForegroundColor = tempColor;
            }
            catch (Exception ex)
            {
                var tempColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + ex.Message);
                Console.ForegroundColor = tempColor;
            }

            return pilihan;
        }
    }
}
