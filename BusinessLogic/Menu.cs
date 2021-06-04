using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing_App.BusinessLogic
{
    public static class Menu
    {
        private static SubMenu subMenu = new SubMenu();

        public static void TampilkanMenuUtama()
        {
            Console.Clear();
            Console.WriteLine(" ___________________________________________________");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("|                    Menu Utama                     |");
            Console.WriteLine("|___________________________________________________|");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("| 0     : Keluar                                    |");
            Console.WriteLine("| 1     : Transaksi                                 |");
            Console.WriteLine("| 2     : Kelola Barang                             |");
            Console.WriteLine("| 3     : Kelola Stok Barang                        |");
            Console.WriteLine("| 4     : Laporan                                   |");
            Console.WriteLine("| 5     : Help                                      |");
            Console.WriteLine("|___________________________________________________|");
            while (true)
            {
                PilihanMenu pilihan = (PilihanMenu)Perintah.Masukan();
                switch (pilihan)
                {
                    case PilihanMenu.Keluar:
                        Console.WriteLine("\nTerima kasih dan sampai jumpa kembali... :)");
                        Console.ReadKey();
                        return;
                    case PilihanMenu.Transaksi:
                        subMenu.Transaksi();
                        break;
                    case PilihanMenu.KelolaBarang:
                        subMenu.KelolaBarang();
                        break;
                    case PilihanMenu.KelolaStokBarang:
                        subMenu.KelolaStok();
                        break;
                    case PilihanMenu.Laporan:
                        subMenu.Laporan();
                        break;
                    case PilihanMenu.Default:
                        continue;
                    default:
                        Console.WriteLine("\nMaaf, pilihan tidak ditemukan");
                        continue;
                }
            }
        }        

    }
}
