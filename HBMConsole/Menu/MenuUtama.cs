using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBMConsole.BusinessLogic;
using HBMConsole.Enum;

namespace HBMConsole.Menu
{
    public static class MenuUtama
    {
        public static void TampilkanMenuUtama()
        {
            Console.Clear();
            Console.WriteLine("\t ___________________________________________________");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t|                    Menu Utama                     |");
            Console.WriteLine("\t|___________________________________________________|");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("\t| 0     : Keluar                                    |");
            Console.WriteLine("\t| 1     : Transaksi                                 |");
            Console.WriteLine("\t| 2     : Kelola Barang                             |");
            Console.WriteLine("\t| 3     : Kelola Stok Barang                        |");
            Console.WriteLine("\t| 4     : Laporan                                   |");
            Console.WriteLine("\t|___________________________________________________|");
            while (true)
            {
                PilihanMenu pilihan = (PilihanMenu)Perintah.Masukan();
                switch (pilihan)
                {
                    case PilihanMenu.Keluar:
                        Console.WriteLine("\n\tTerima kasih dan sampai jumpa kembali... :)");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case PilihanMenu.Transaksi:
                        MenuTransaksi transaksi = new MenuTransaksi();
                        transaksi.Menu();
                        break;
                    case PilihanMenu.KelolaBarang:
                        MenuKelolaBarang kelolaBarang = new MenuKelolaBarang();
                        kelolaBarang.Menu();
                        break;
                    case PilihanMenu.KelolaStokBarang:
                        MenuKelolaStok kelolaStok = new MenuKelolaStok();
                        kelolaStok.Menu();
                        break;
                    case PilihanMenu.Laporan:
                        MenuLaporan laporan = new MenuLaporan();
                        laporan.Menu();
                        break;
                    case PilihanMenu.Default:
                        continue;
                    default:
                        Pesan.Warning("Maaf, pilihan tidak ditemukan");
                        continue;
                }
            }
        }        

    }
}
