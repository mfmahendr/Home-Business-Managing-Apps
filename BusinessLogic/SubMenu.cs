using Home_Business_Managing_App.Entitas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Business_Managing_App.BusinessLogic
{
    public class SubMenu
    {
        Barang barang = new Barang();
        Transaksi transaksi = new Transaksi();
        Stok stok = new Stok();
        LaporanLabaRugi laporan = new LaporanLabaRugi();
        private string idBarang;
        private string nama;
        private string jenis;
        private string info;
        private float satuan;
        private float hargaJual;
        private float jumlahStok;

        public void Transaksi()
        {
            Console.Clear();
            Console.WriteLine(" ___________________________________________________");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("|                   Menu Transaksi                  |");
            Console.WriteLine("|___________________________________________________|");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("| 0     : Keluar                                    |");
            Console.WriteLine("| 1     : Jual Barang                               |");
            Console.WriteLine("| 2     : Beli Barang                               |");;
            Console.WriteLine("| 3     : Kembali                                   |");
            Console.WriteLine("|___________________________________________________|");
            while (true)
            {
                switch ((PilihanTransaksi)Perintah.Masukan())
                {
                    case PilihanTransaksi.Keluar:
                        Console.WriteLine("\nTerima kasih dan sampai jumpa kembali... :)");
                        return;
                    case PilihanTransaksi.Jual:

                        break;
                    case PilihanTransaksi.Beli:
                        break;
                    case PilihanTransaksi.Kembali:
                        break;
                    case PilihanTransaksi.Default:
                        continue;
                    default:
                        Console.WriteLine("\nMaaf, pilihan tidak ditemukan");
                        continue;
                }
            }
        }

        public void KelolaBarang()
        {
            Console.Clear();
            Console.WriteLine(" ___________________________________________________");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("|                 Menu Kelola Barang                |");
            Console.WriteLine("|___________________________________________________|");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("| 0     : Keluar                                    |");
            Console.WriteLine("| 1     : Tampilkan Informasi Barang                |");
            Console.WriteLine("| 2     : Tambah Barang                             |");
            Console.WriteLine("| 3     : Ubah Informasi                            |");
            Console.WriteLine("| 4     : Hapus Barang                              |");
            Console.WriteLine("| 5     : Kembali                                   |");
            Console.WriteLine("|___________________________________________________|");
            while (true)
            {
                switch ((PilihanKelolaData)Perintah.Masukan())
                {
                    case PilihanKelolaData.Keluar:
                        Console.WriteLine("\nTerima kasih dan sampai jumpa kembali... :)");
                        Console.ReadKey();
                        return;
                    case PilihanKelolaData.Tampilkan:
                        TampilkanInformasiBarang();
                        KelolaBarang();
                        continue;

                    case PilihanKelolaData.Tambah:
                        Console.Clear();
                        Console.WriteLine("\nMasukkan data barang yang baru...\n");
                        try
                        {
                            Console.Write("{0, -16}:", "Id");
                            idBarang = Console.ReadLine();

                            if (barang.CekIdBarang(idBarang) != false)
                            {
                                Console.WriteLine("\nBarang tidak bisa ditambahkan karena barang yang ditambahkan tersebut sudah ada");
                                Console.ReadKey();
                                KelolaBarang();
                            }

                            Console.Write("{0, -16}:", "Nama");
                            nama = Console.ReadLine();
                            Console.Write("{0, -16}:", "Jenis / varian");
                            jenis = Console.ReadLine();

                            if (barang.CekBarang(nama, jenis) == true)
                            {
                                Console.WriteLine("\nBarang tidak bisa ditambahkan karena barang yang ditambahkan tersebut sudah ada");
                                Console.ReadKey();
                                KelolaBarang();
                            }

                            Console.Write("{0, -16}:", "Informasi");
                            info = Console.ReadLine();
                            Console.Write("{0, -16}:", "Satuan");
                            satuan = float.Parse(Console.ReadLine());
                            Console.Write("{0, -16}:", "Harga Jual");
                            hargaJual = float.Parse(Console.ReadLine());

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
                                Console.WriteLine("\nBarang berhasil ditambahkan");
                                Console.ReadKey();
                                TampilkanInformasiBarang();
                                KelolaBarang();
                            }
                            else 
                            { 
                                Console.WriteLine("\nBarang gagal ditambahkan");
                                Console.ReadKey();
                                KelolaBarang();
                            }
                        }
                        catch(Exception ex)
                        {
                            var tempColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Error: " + ex.Message);
                            Console.ForegroundColor = tempColor;
                        }
                        break;

                    case PilihanKelolaData.Ubah:
                        Console.Clear();
                        TampilkanInformasiBarang();
                        Console.WriteLine("\nBerdasarkan data barang di atas... \nMasukkan ID Barang yang ingin diubah");
                        Console.Write("{0, -16}:", "Id Barang");
                        idBarang = Console.ReadLine();

                        // Masih ada bug karena harus mengubah semua data
                        // dan gk bisa ngubah harga doang atau satu item lain
                        try
                        {
                            if (!barang.CekIdBarang(idBarang))
                            {
                                Console.WriteLine("Id Barang yang Anda masukkan tidak ada");
                                continue;
                            }

                            Console.Write("{0, -16}:", "Nama");
                            nama = Console.ReadLine();
                            Console.Write("{0, -16}:", "Jenis / varian");
                            jenis = Console.ReadLine();

                            if (barang.CekBarang(nama, jenis))
                            {
                                Console.WriteLine("Barang tidak bisa diubah karena tidak ada perubahan");
                                continue;
                            }

                            Console.Write("{0, -16}:", "Informasi");
                            info = Console.ReadLine();
                            Console.Write("{0, -16}:", "Satuan");
                            satuan = float.Parse(Console.ReadLine());
                            Console.Write("{0, -16}:", "Harga Jual");
                            hargaJual = float.Parse(Console.ReadLine());

                            if (barang.Ubah(idBarang, nama, jenis, info, satuan, hargaJual))
                            {
                                Console.WriteLine("Informasi barang berhasil diubah"); 
                                TampilkanInformasiBarang();
                                KelolaBarang();
                            }
                            else
                            {
                                Console.WriteLine("Informasi barang gagal diubah");
                                Console.ReadKey();
                                KelolaBarang();
                            }
                        }
                        catch(Exception ex)
                        {
                            var tempColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Error: " + ex.Message);
                            Console.ForegroundColor = tempColor;
                        }
                        break;

                    case PilihanKelolaData.Hapus:
                        Console.Clear();
                        TampilkanInformasiBarang();
                        Console.WriteLine("\nBerdasarkan data barang di atas... \nMasukkan ID Barang yang ingin dihapus");
                        Console.Write("{0, -16}:", "Id Barang");
                        idBarang = Console.ReadLine();
                        try
                        {
                            if (!barang.CekIdBarang(idBarang))
                            {
                                Console.WriteLine("Id Barang yang Anda masukkan tidak ada");
                                continue;
                            }

                            if (barang.Hapus(idBarang))
                            {
                                Console.WriteLine("Informasi barang berhasil dihapus");
                                TampilkanInformasiBarang();
                                KelolaBarang();
                            }
                            else
                            {
                                Console.WriteLine("Barang gagal dihapus");
                                Console.ReadKey();
                                KelolaBarang();
                            }
                        }
                        catch(Exception ex)
                        {
                            var tempColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Error: " + ex.Message);
                            Console.ForegroundColor = tempColor;
                        }
                        break;
                    case PilihanKelolaData.Kembali:
                        Menu.TampilkanMenuUtama();
                        break;
                    case PilihanKelolaData.Default:
                        continue;
                    default:
                        Console.WriteLine("\nMaaf, pilihan tidak ditemukan");
                        continue;
                }
            }
        }

        private void TampilkanInformasiBarang()
        {
            Console.Clear();
            var listBarang = (List<Barang>)barang.GetDataBerdasarkan();

            string[] kolom = { "Id Barang", "Nama Barang", "Jenis Barang",
                                           "Informasi", "Satuan", "Harga Jual" };

            Console.WriteLine("\n\t| {0, -15}| {1, -15}| {2, -15}| {3, -50}| {4, -15}| {5, -15}|", kolom);
            foreach (var item in listBarang)
            {
                Console.WriteLine("\t| {0, -15}| {1, -15}| {2, -15}| {3, -50}| {4, -15}| {5, -15}|", item.Id, item.Nama, item.Jenis, item.InformasiPenjelas, item.Satuan, item.HargaJual);
            }
            Console.ReadKey();
        }

        public void KelolaStok()
        {
            Console.Clear();
            Console.WriteLine(" ___________________________________________________");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("|              Menu Kelola Stok Barang              |");
            Console.WriteLine("|___________________________________________________|");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("| 0     : Keluar                                    |");
            Console.WriteLine("| 1     : Tampilkan Informasi Stok Barang           |");
            Console.WriteLine("| 2     : Tambah Informasi Stok                     |");
            Console.WriteLine("| 3     : Ubah atau Tambah/Kurangi Stok             |");
            Console.WriteLine("| 4     : Hapus Informasi Stok                      |");
            Console.WriteLine("| 5     : Kembali                                   |");
            Console.WriteLine("|___________________________________________________|");
            while (true)
            {
                switch ((PilihanKelolaData)Perintah.Masukan())
                {
                    case PilihanKelolaData.Keluar:
                        Console.WriteLine("\nTerima kasih dan sampai jumpa kembali... :)");
                        Console.ReadKey();
                        return;
                    case PilihanKelolaData.Tampilkan:
                        TampilkanInformasiStok();
                        KelolaStok();
                        break;
                    case PilihanKelolaData.Tambah:
                        Console.Clear();
                        TampilkanInformasiStok();
                        Console.WriteLine("\nBerdasarkan informasi di atas, masukkan ID Barang yang jumlah stoknya ingin ditambah atau dikurangi");
                        Console.Write("{0, -16}:", "Id Barang");
                        idBarang = Console.ReadLine();
                        Console.Write("{0, -16}:", "Jumlah stok");

                        try
                        {
                            jumlahStok = float.Parse(Console.ReadLine());
                            var stok = new Stok()
                            {
                                IdBarang = idBarang,
                                JumlahStok = jumlahStok
                            };

                            if (stok.Tambah(stok))
                            {
                                Console.WriteLine("Jumlah stok berhasil ditambah");
                                TampilkanInformasiStok();
                                KelolaStok();
                            }
                            else
                            {
                                Console.WriteLine("Jumlah stok gagal ditambah");
                                Console.ReadKey();
                                KelolaStok();
                            }
                        }
                        catch (Exception ex)
                        {
                            var tempColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Error: " + ex.Message);
                            Console.ForegroundColor = tempColor;
                        }
                        break;

                    case PilihanKelolaData.Ubah:
                        Console.Clear();
                        TampilkanInformasiStok();
                        Console.WriteLine("\nBerdasarkan data barang di atas... \nMasukkan ID Barang yang ingin diubah");
                        Console.WriteLine("\nNote: Awali jumlah stok dengan minus (-) untuk menguranginya");
                        Console.Write("{0, -16}:", "Id Barang");
                        idBarang = Console.ReadLine();

                        try
                        {
                            if (!stok.CekIdBarang(idBarang))
                            {
                                Console.WriteLine("Id Barang yang Anda masukkan tidak ada");
                                continue;
                            }

                            Console.Write("{0, -16}:", "Jumlah stok");
                            jumlahStok = float.Parse(Console.ReadLine());

                            if (stok.Tambah(idBarang, jumlahStok))
                            {
                                Console.WriteLine("Informasi barang berhasil diubah");
                                TampilkanInformasiStok();
                                KelolaStok();
                            }
                            else
                            {
                                Console.WriteLine("Informasi barang gagal diubah");
                                Console.ReadKey();
                                KelolaStok();
                            }
                        }
                        catch (Exception ex)
                        {
                            var tempColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Error: " + ex.Message);
                            Console.ForegroundColor = tempColor;
                        }
                        break;

                    case PilihanKelolaData.Hapus:
                        Console.Clear();
                        TampilkanInformasiStok();
                        Console.WriteLine("\nBerdasarkan data barang di atas... \nMasukkan ID Barang yang ingin dihapus");
                        Console.Write("{0, -16}:", "Id Barang");
                        idBarang = Console.ReadLine();
                        try
                        {
                            if (!stok.CekIdBarang(idBarang))
                            {
                                Console.WriteLine("Id Barang yang Anda masukkan tidak ada");
                                continue;
                            }

                            if (stok.Hapus(idBarang))
                            {
                                Console.WriteLine("Informasi stok barang berhasil dihapus");
                                TampilkanInformasiStok();
                                KelolaStok();
                            }
                            else
                            {
                                Console.WriteLine("Informasi stok barang gagal dihapus");
                                Console.ReadKey();
                                KelolaStok();
                            }
                        }
                        catch (Exception ex)
                        {
                            var tempColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Error: " + ex.Message);
                            Console.ForegroundColor = tempColor;
                        }
                        break;
                    case PilihanKelolaData.Kembali:
                        Menu.TampilkanMenuUtama();
                        break;
                    case PilihanKelolaData.Default:
                        continue;
                    default:
                        Console.WriteLine("\nMaaf, pilihan tidak ditemukan");
                        continue;
                }
            }
        }

        private void TampilkanInformasiStok()
        {
            Console.Clear();
            var listInfoStok = (List<ViewStok>)stok.GetDataBerdasarkan();

            string[] kolom = { "Id Barang", "Nama Barang", "Jenis Barang", "Jumlah Stok" };

            Console.WriteLine("\n\t| {0, -15}| {1, -15}| {2, -15}| {3, -15}|", kolom);
            foreach (var item in listInfoStok)
            {
                Console.WriteLine("\t| {0, -15}| {1, -15}| {2, -15}| {3, -15}|", item.Id, item.Nama, item.Jenis, item.JumlahStok);
            }
            Console.ReadKey();
        }

        public void Laporan()
        {
            Console.Clear();
            Console.WriteLine(" ___________________________________________________");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("|                    Menu Laporan                   |");
            Console.WriteLine("|___________________________________________________|");
            Console.WriteLine("|                                                   |");
            Console.WriteLine("| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("| 0     : Keluar                                    |");
            Console.WriteLine("| 1     : Tampilkan Laporan Keuangan                |");
            Console.WriteLine("| 2     : Tambah Record                             |");
            Console.WriteLine("| 3     : Ubah Record                               |");
            Console.WriteLine("| 4     : Hapus Record                              |");
            Console.WriteLine("| 5     : Kembali                                   |");
            Console.WriteLine("|___________________________________________________|");
            while (true)
            {
                switch ((PilihanKelolaData)Perintah.Masukan())
                {
                    case PilihanKelolaData.Keluar:
                        Console.WriteLine("\nTerima kasih dan sampai jumpa kembali... :)");
                        Console.ReadKey();
                        return;
                    case PilihanKelolaData.Tampilkan:

                        break;
                    case PilihanKelolaData.Tambah:
                        break;
                    case PilihanKelolaData.Ubah:
                        break;
                    case PilihanKelolaData.Hapus:
                        break;
                    case PilihanKelolaData.Kembali:
                        Menu.TampilkanMenuUtama();
                        break;
                    case PilihanKelolaData.Default:
                        continue;
                    default:
                        Console.WriteLine("\nMaaf, pilihan tidak ditemukan");
                        continue;
                }
            }
        }

    }
}
