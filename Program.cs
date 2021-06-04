using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Business_Managing_App.BusinessLogic;

namespace Home_Business_Managing_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Aplikasi Home-Business-Managing";
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Halo, selamat datang!");
            Console.WriteLine("Tekan tombol apa saja untuk melakukan...");

            Console.ReadKey();
            Menu.TampilkanMenuUtama();
        }
    }
}
