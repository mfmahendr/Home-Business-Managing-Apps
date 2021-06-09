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
    public class MenuKelolaBarang : SubMenu
    {

        private readonly Barang barang = new Barang();

        public new void Menu()
        {
            Console.Clear();
            Console.WriteLine("\t ___________________________________________________");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t|                 Menu Kelola Barang                |");
            Console.WriteLine("\t|___________________________________________________|");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("\t| 0     : Keluar                                    |");
            Console.WriteLine("\t| 1     : Tampilkan Informasi Barang                |");
            Console.WriteLine("\t| 2     : Tambah Barang                             |");
            Console.WriteLine("\t| 3     : Ubah Informasi                            |");
            Console.WriteLine("\t| 4     : Hapus Barang                              |");
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
                    break;
                case PilihanKelolaData.Ubah:
                    Ubah();
                    break;
                case PilihanKelolaData.Hapus:
                    Hapus();
                    break;
                case PilihanKelolaData.Kembali:
                    MenuUtama.TampilkanMenuUtama();
                    break;
                case PilihanKelolaData.Default:
                    Opsi();
                    break;
                default:
                    Console.WriteLine("\nMaaf, pilihan tidak ditemukan");
                    Opsi();
                    break;
            }

        }

        public new void TampilkanTabel()
        {
            Console.Clear();
            var listBarang = (List<Barang>)barang.GetDataBerdasarkan();

            string[] kolom = { "Id Barang", "Nama Barang", "Jenis Barang",
                                           "Informasi", "Satuan", "Harga Jual" };
            Console.WriteLine("\t__________________________________________________________________________________________________________________________________________");
            Console.WriteLine("\t| {0, -15}| {1, -15}| {2, -15}| {3, -50}| {4, -15}| {5, -15}|", kolom);
            Console.WriteLine("\t|________________|________________|________________|___________________________________________________|________________|________________|");
            foreach (var item in listBarang)
            {
                Console.WriteLine("\t| {0, -15}| {1, -15}| {2, -15}| {3, -50}| {4, -15}| {5, -15}|", item.Id, item.Nama, item.Jenis, item.InformasiPenjelas, item.Satuan, item.HargaJual);
            }
            Console.WriteLine("\t|________________|________________|________________|___________________________________________________|________________|________________|");
            Console.ReadKey();
        }

        private void Tambah()
        {
            Console.Clear();
            Console.WriteLine("\n\tMasukkan data barang yang baru...\n");
            try
            {
                string idBarang = InputData.IdBaru();
                string nama = InputData.Teks("Nama");
                string jenis = InputData.Teks("Jenis / varian");

                if (barang.CekBarang(nama, jenis) == true)
                {
                    Pesan.Warning("Barang tidak bisa ditambahkan karena barang yang ditambahkan tersebut sudah ada");
                    Menu();
                }

                string info = InputData.Teks("Informasi");
                double satuan = InputData.AngkaDouble("Satuan");
                double hargaJual = InputData.AngkaDouble("Harga Jual");

                Barang barangBaru = new Barang()
                {
                    Id = idBarang,
                    Nama = nama,
                    Jenis = jenis,
                    InformasiPenjelas = info,
                    Satuan = satuan,
                    HargaJual = hargaJual
                };

                if (barang.Tambah(barangBaru))
                {
                    Console.WriteLine("\n\tBarang berhasil ditambahkan");
                    Console.ReadKey();
                    TampilkanTabel();
                    Menu();
                }
                else
                {
                    Pesan.Error("Barang gagal ditambahkan");
                    Console.ReadKey();
                    Menu();
                }
            }
            catch (FormatException)
            {
                Pesan.Error("Data yang Anda masukkan untuk angka harus dalam bentuk angka juga");
                Menu();
            }
            catch (Exception ex)
            {
                Pesan.Error(ex.Message);
                Menu();
            }
        }

        private void Hapus()
        {
            Console.Clear();
            TampilkanTabel();
            Console.WriteLine("\n\tBerdasarkan data barang di atas, masukkan ID Barang yang ingin dihapus");
            try
            {
                string idBarang = InputData.IdTersedia();
                if (!barang.CekIdBarang(idBarang))
                {
                    Pesan.Warning("Id Barang yang Anda masukkan tidak ada! Cek kembali ID Barang yang ingin Anda hapus.");
                    Opsi();
                }

                if (barang.Hapus(idBarang))
                {
                    Console.WriteLine("\n\tInformasi barang berhasil dihapus");
                    TampilkanTabel();
                    Menu();
                }
                else
                {
                    Pesan.Error("Barang gagal dihapus");
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
            Console.Clear();
            TampilkanTabel();
            Console.WriteLine("\n\tBerdasarkan data barang di atas, " +
                                "masukkan ID Barang yang ingin diubah dan informasi baru yang akan diubah");

            // Masih ada bug karena harus mengubah semua data
            // dan gk bisa ngubah harga doang atau satu item lain
            try
            {
                string idBarang = InputData.IdTersedia();
                string nama = InputData.Teks("Nama");
                string jenis = InputData.Teks("Jenis / varian");

                //if (barang.CekBarang(nama, jenis))
                //{
                //    Pesan.Warning("Tidak ada perubahan yang Anda masukkan");
                //    Menu();
                //}

                string info = InputData.Teks("Informasi");
                double satuan = InputData.AngkaDouble("Satuan");
                double hargaJual = InputData.AngkaDouble("Harga Jual");

                if (barang.Ubah(idBarang, nama, jenis, info, satuan, hargaJual))
                {
                    Console.WriteLine("\tInformasi barang berhasil diubah");
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
