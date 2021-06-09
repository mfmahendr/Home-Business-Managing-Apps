using HBMConsole.BusinessLogic;
using HBMConsole.Entitas;
using HBMConsole.Enum;
using HBMConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBMConsole.Menu
{
    public class MenuKelolaStok : SubMenu
    {
        
        public new void Menu()
        {
            Console.Clear();
            Console.WriteLine("\t ___________________________________________________");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t|              Menu Kelola Stok Barang              |");
            Console.WriteLine("\t|___________________________________________________|");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("\t| 0     : Keluar                                    |");
            Console.WriteLine("\t| 1     : Tampilkan Informasi Stok Barang           |");
            Console.WriteLine("\t| 2     : Tambah Informasi Stok                     |");
            Console.WriteLine("\t| 3     : Ubah atau Tambah/Kurangi Stok             |");
            Console.WriteLine("\t| 4     : Hapus Informasi Stok                      |");
            Console.WriteLine("\t| 5     : Kembali                                   |");
            Console.WriteLine("\t|___________________________________________________|");
            Opsi();
        }

        private void Opsi()
        {
            switch ((PilihanKelolaData)Perintah.Masukan())
            {
                case PilihanKelolaData.Keluar:
                    Console.WriteLine("\n\tTerima kasih dan sampai jumpa kembali... :)");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case PilihanKelolaData.Tampilkan:
                    TampilkanTabel();
                    Menu();
                    break;
                case PilihanKelolaData.Tambah:
                    Tambah();
                    Menu();
                    break;
                case PilihanKelolaData.Ubah:
                    Ubah();
                    Menu();
                    break;
                case PilihanKelolaData.Hapus:
                    Hapus();
                    Menu();
                    break;
                case PilihanKelolaData.Kembali:
                    MenuUtama.TampilkanMenuUtama();
                    break;
                case PilihanKelolaData.Default:
                    Opsi();
                    break;
                default:
                    Pesan.Error("Maaf, pilihan tidak ditemukan");
                    Opsi();
                    break;
            }
        }

        public new void TampilkanTabel()
        {
            Console.Clear();
            Stok stok = new Stok();
            var listInfoStok = (List<ViewStok>)stok.GetDataBerdasarkan();

            string[] kolom = { "Id Barang", "Nama Barang", "Jenis Barang", "Jumlah Stok" };

            Console.WriteLine("\t_____________________________________________________________________");
            Console.WriteLine("\t| {0, -15}| {1, -15}| {2, -15}| {3, -15}|", kolom);
            Console.WriteLine("\t|________________|________________|________________|________________|");
            foreach (var item in listInfoStok)
            {
                Console.WriteLine("\t| {0, -15}| {1, -15}| {2, -15}| {3, -15}|", item.Id, item.Nama, item.Jenis, item.JumlahStok);
            }
            Console.WriteLine("\t|________________|________________|________________|________________|");
            Console.ReadKey();
        }
        
        private void Tambah()
        {
            Stok stok = new Stok();
            MenuKelolaBarang menuBarang = new MenuKelolaBarang();

            Console.Clear();
            menuBarang.TampilkanTabel();
            Console.WriteLine("\n\tMasukkan informasi stok barang baru yang ingin Anda masukkan");

            try
            {
                string idBarang = InputData.IdTersedia();

                if (stok.CekIdBarang(idBarang))
                {
                    Pesan.Error("Informasi untuk ID Barang yang Anda masukkan sudah ada sehingga tidak perlu ditambahkan lagi");
                    Menu();
                }

                double jumlahStok = InputData.AngkaDouble("Jumlah stok");
                var stokBaru = new Stok()
                {
                    IdBarang = idBarang,
                    JumlahStok = jumlahStok
                };

                if (stok.Tambah(stokBaru))
                {
                    Console.WriteLine("\tJumlah stok berhasil ditambah");
                    Console.ReadKey();
                    TampilkanTabel();
                    Menu();
                }
                else
                {
                    Pesan.Error("Jumlah stok gagal ditambah");
                    Menu();
                }
            }
            catch (Exception ex)
            {
                Pesan.Error(ex.Message);
                Menu();
            }
        }

        private void Hapus()
        {
            Stok stok = new Stok();

            Console.Clear();
            TampilkanTabel();
            Console.WriteLine("\n\tMasukkan ID Barang yang ingin dihapus");

            try
            {
                string idBarang = InputData.IdTersedia();
                if (stok.Hapus(idBarang))
                {
                    Console.WriteLine("\n\tInformasi stok barang berhasil dihapus\n");
                    Console.ReadKey();
                    TampilkanTabel();
                    Menu();
                }
                else
                {
                    Pesan.Error("Informasi stok barang gagal dihapus");
                    Menu();
                }
            }
            catch (Exception ex)
            {
                Pesan.Error(ex.Message);
            }
        }

        private void Ubah()
        {
            var stok = new Stok();

            Console.Clear();
            TampilkanTabel();

            Console.WriteLine("\n\tBerdasarkan data barang di atas, masukkan ID Barang yang ingin diubah");
            Console.WriteLine("\tNote: Awali jumlah stok dengan minus (-) untuk menguranginya");

            try
            {
                string idBarang = InputData.IdTersedia();
                double jumlahStok = InputData.AngkaDouble("Jumlah Stok");

                if (stok.Tambah(idBarang, jumlahStok))
                {
                    Console.WriteLine("\n\tInformasi barang berhasil diubah");
                    TampilkanTabel();
                    Menu();
                }
                else
                {
                    Pesan.Error("Informasi barang gagal diubah");
                    Menu();
                }
            }
            catch (Exception ex)
            {
                Pesan.Error(ex.Message);
            }
        }
    }
}
