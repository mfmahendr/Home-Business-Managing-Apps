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
    public class MenuTransaksi : SubMenu
    {
        private readonly Transaksi transaksi = new Transaksi();
        private readonly Barang barang = new Barang();
        private readonly MenuKelolaStok menuKelolaStok = new MenuKelolaStok();

        public new void Menu()
        {
            Console.Clear();
            Console.WriteLine("\t ___________________________________________________");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t|                   Menu Transaksi                  |");
            Console.WriteLine("\t|___________________________________________________|");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("\t| 0     : Keluar                                    |");
            Console.WriteLine("\t| 1     : Jual Barang                               |");
            Console.WriteLine("\t| 2     : Beli Barang                               |");
            Console.WriteLine("\t| 3     : Tampilkan Record transaksi                |");
            Console.WriteLine("\t| 4     : Tambah Record Transaksi                   |");
            Console.WriteLine("\t| 5     : Hapus Record Transaksi                    |");
            Console.WriteLine("\t| 6     : Kembali ke Menu                           |");
            Console.WriteLine("\t|___________________________________________________|");
            Opsi();
        }

        private void Opsi()
        {
            switch ((PilihanMenuTransaksi)Perintah.Masukan())
            {
                case PilihanMenuTransaksi.Keluar:
                    Console.WriteLine("\n\tTerima kasih dan sampai jumpa kembali... :)");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case PilihanMenuTransaksi.Jual:
                    Jual();
                    break;
                case PilihanMenuTransaksi.Beli:
                    Beli();
                    break;
                case PilihanMenuTransaksi.Tampilkan:
                    DataTransaksi();
                    break;
                case PilihanMenuTransaksi.Tambah:
                    Tambah();
                    break;
                case PilihanMenuTransaksi.Hapus:
                    Hapus();
                    break;
                case PilihanMenuTransaksi.Kembali:
                    MenuUtama.TampilkanMenuUtama();
                    break;
                case PilihanMenuTransaksi.Default:
                    Opsi();
                    break;
                default:
                    Pesan.Warning("Maaf, pilihan tidak ditemukan");
                    Opsi();
                    break;
            }
        }
       
        private void DataTransaksi()
        {
            
            Console.Clear();
            Console.WriteLine("\t ___________________________________________________");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("\t| 1     : Tampilkan semua transaksi                 |");
            Console.WriteLine("\t| 2     : Tampilkan berdasarkan ID Barang           |");
            Console.WriteLine("\t| 3     : Tampilkan berdasarkan bulan dan tahun     |");
            Console.WriteLine("\t| 4     : Tampilkan berdasarkan jenis transaksi     |");
            Console.WriteLine("\t| 5     : Kembali                                   |");
            Console.WriteLine("\t|___________________________________________________|");

            OpsiTampilkan();
        }

        private void OpsiTampilkan()
        {
            List<Transaksi> listCatatanTransaksi;

            var masukan = Perintah.Masukan();
            switch ((PilihanMenampilkanTransaksi)masukan)
            {
                case PilihanMenampilkanTransaksi.Semua:
                    listCatatanTransaksi = (List<Transaksi>)transaksi.GetDataBerdasarkan();
                    TampilkanTabel(listCatatanTransaksi);
                    DataTransaksi();
                    break;
                case PilihanMenampilkanTransaksi.Id:

                    var idBarang = InputData.IdTersedia();
                    listCatatanTransaksi = (List<Transaksi>)transaksi.GetDataBerdasarkan(idBarang: idBarang);
                    TampilkanTabel(listCatatanTransaksi);
                    DataTransaksi();
                    break;
                case PilihanMenampilkanTransaksi.BulanTahun:
                    int bulan = InputData.AngkaInt("Bulan");
                    int tahun = InputData.AngkaInt("Tahun");

                    listCatatanTransaksi = (List<Transaksi>)transaksi.GetDataBerdasarkan(tahun: tahun, bulan: bulan);
                    TampilkanTabel(listCatatanTransaksi);
                    DataTransaksi();
                    break;
                case PilihanMenampilkanTransaksi.JenisTransaksi:
                    while (true)
                    {
                        Console.WriteLine("\tNote: Cukup tulis J/j untuk jual dan B/b untuk beli");
                        string JenisTransaksi = InputData.Teks("Jenis Transaksi").ToUpper();

                        if (JenisTransaksi == "J")
                        {
                            listCatatanTransaksi = (List<Transaksi>)transaksi.GetDataBerdasarkan(PilihanMenuTransaksi.Jual);
                            TampilkanTabel(listCatatanTransaksi);
                            break;
                        }
                        else if (JenisTransaksi == "B")
                        {
                            listCatatanTransaksi = (List<Transaksi>)transaksi.GetDataBerdasarkan(PilihanMenuTransaksi.Beli);
                            TampilkanTabel(listCatatanTransaksi);
                            break;
                        }
                        else
                        {
                            Pesan.Warning("Pilihan tidak ditemukan");
                            continue;
                        }
                    }
                    DataTransaksi();
                    break;
                case PilihanMenampilkanTransaksi.Default:
                    OpsiTampilkan();
                    break;
                case PilihanMenampilkanTransaksi.Kembali:
                    Menu();
                    break;
                default:
                    Pesan.Warning("Maaf, pilihan tidak ditemukan");
                    OpsiTampilkan();
                    break;
            }

        }

        private void TampilkanTabel(List<Transaksi> listCatatanTransaksi = null)
        {
            List<Transaksi> listTransaksi;
            DateTime date = DateTime.Now;

            Console.Clear();

            string[] kolom = { "No. Transaksi", "Tanggal", "Waktu", "Keterangan",
                               "Id Barang", "Transaksi", "Jumlah barang",  "Cash Flow"};
            Console.WriteLine("\t ___________________________________________________________________________________________________________________________________________________________");
            Console.WriteLine("\t| {0, -15}| {1, -15}| {2, -10}| {3, -50}| {4, -10}| {5, -10}| {6, 15}| {7, 15}|", kolom);
            Console.WriteLine("\t|________________|________________|___________|___________________________________________________|___________|___________|________________|________________|");

            if (listCatatanTransaksi != null)
            {
                listTransaksi = listCatatanTransaksi;
            }
            else
            {
                listTransaksi = (List<Transaksi>)transaksi.GetDataBerdasarkan(date.Year, date.Month);
            }

            foreach (var item in listTransaksi)
            {
                Console.WriteLine("\t| {0, -15}| {1, -15}| {2, -10}| {3, -50}| {4, -10}| {5, -10}| {6, 15}| {7, 15}|",
                                   item.NoTransaksi, item.Tanggal.ToShortDateString(), item.Waktu, item.Keterangan, item.IdBarang, item.JenisTransaksi, item.JumlahBarang, item.TotalCashFlow);
            }
            Console.WriteLine("\t|________________|________________|___________|___________________________________________________|___________|___________|________________|________________|");
            Console.ReadKey();
        }

        private void TampilkanTabel(int tahun)
        {
            Console.Clear();

            string[] kolom = { "No. Transaksi", "Tanggal", "Waktu", "Keterangan",
                               "Id Barang", "Transaksi", "Jumlah barang",  "Cash Flow"};
            Console.WriteLine("\t _________________________________________________________________________________________________________________________________________________________");
            Console.WriteLine("\t| {0, -15}| {1, -15}| {2, -10}| {3, -50}| {4, -10}| {5, -10}| {6, 15}| {7, 15}|", kolom);
            Console.WriteLine("\t|________________|________________|___________|___________________________________________________|__________|__________|________________|________________|");

            List<Transaksi> listTransaksi = (List<Transaksi>)transaksi.GetDataBerdasarkan(tahun: tahun);


            foreach (var item in listTransaksi)
            {
                Console.WriteLine("\t| {0, -15}| {1, -15}| {2, -10}| {3, -50}| {4, -10}| {5, -10}| {6, 15}| {7, 15}|",
                                   item.NoTransaksi, item.Tanggal, item.Waktu, item.Keterangan, item.IdBarang, item.JenisTransaksi, item.JumlahBarang, item.TotalCashFlow);
            }
            Console.WriteLine("\t|________________|________________|___________|___________________________________________________|__________|__________|________________|________________|");
            Console.ReadKey();
        }

        private void Jual()
        {
            Console.Clear();
            HitungPendapatan hitung = new HitungPendapatan();
            LaporanLabaRugi laporan = new LaporanLabaRugi();
            Stok stok = new Stok();

            var tanggal = DateTime.Now;
            var waktu = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            int bulan = tanggal.Month;
            int tahun = tanggal.Year;

            menuKelolaStok.TampilkanTabel();
            Console.WriteLine("\n\tMasukkan informasi barang yang dijual...");

            string idBarang = InputData.IdTersedia();
            double hargaJual = barang.GetHarga(idBarang);
            string keterangan = InputData.Teks("Keterangan");
            double jumlahBarang = InputData.AngkaDouble("Jumlah Barang");
            double totalCashFlow = hitung.CalculateRevenue(jumlahBarang, hargaJual);

            Transaksi transaksiJual = new Transaksi()
            {
                Tanggal = tanggal,
                Waktu = waktu,
                Keterangan = keterangan,
                IdBarang = idBarang,
                JenisTransaksi = "J",
                JumlahBarang = jumlahBarang,
                TotalCashFlow = totalCashFlow
            };

            if (transaksi.Tambah(transaksiJual) &&
                stok.Tambah(idBarang, -(jumlahBarang)) &&
                laporan.Perbaharui(bulan, tahun, pendapatan: totalCashFlow))
            {
                Console.WriteLine("\n\tData transaksi berhasil ditambahkan");
                Console.ReadKey();
                TampilkanTabel();
                Menu();
            }
            else
            {
                Pesan.Error("Transaksi gagal dilakukan");
                Menu();
            }
        }

        private void Beli()
        {
            Console.Clear();
            LaporanLabaRugi laporan = new LaporanLabaRugi();
            Stok stok = new Stok();

            var tanggal = DateTime.Now;
            var waktu = new TimeSpan();
            int bulan = tanggal.Month;
            int tahun = tanggal.Year;

            menuKelolaStok.TampilkanTabel();
            Console.WriteLine("\n\tMasukkan informasi barang yang dibeli...");

            string idBarang = InputData.IdTersedia();
            string keterangan = InputData.Teks("Keterangan");
            double jumlahBarang = InputData.AngkaDouble("Jumlah Barang");
            double totalCashFlow = InputData.AngkaDouble("Total Biaya");

            Console.ReadKey();

            Transaksi transaksiBeli = new Transaksi()
            {
                Tanggal = tanggal,
                Waktu = waktu,
                Keterangan = keterangan,
                IdBarang = idBarang,
                JenisTransaksi = "B",
                JumlahBarang = jumlahBarang,
                TotalCashFlow = totalCashFlow
            };

            if (transaksi.Tambah(transaksiBeli) &&
                stok.Tambah(idBarang, jumlahBarang) &&
                laporan.Perbaharui(bulan, tahun, beban: totalCashFlow))
            {
                Console.WriteLine("\n\tData transaksi berhasil ditambahkan");
                Console.ReadKey();
                menuKelolaStok.TampilkanTabel();
                Menu();
            }
            else
            {
                Pesan.Error("Data transaksi gagal ditambahkan");
                Menu();
            }
        }

        private void Tambah()
        {
            Console.Clear();
            LaporanLabaRugi laporan = new LaporanLabaRugi();
            Stok stok = new Stok();
            string jenisTransaksi;

            Console.WriteLine("\n\tMasukkan informasi transaksi baru...");
            int tanggal = InputData.AngkaInt("Tanggal");
            int bulan = InputData.AngkaInt("Bulan");
            int tahun = InputData.AngkaInt("Tahun");
            int jam = InputData.AngkaInt("Jam");
            int menit = InputData.AngkaInt("Menit");
            
            TimeSpan waktu = new TimeSpan(jam, menit, 0);

            string idBarang = InputData.IdTersedia();
            string keterangan = InputData.Teks("Keterangan");
            while (true)
            {
                Console.WriteLine("\tNote: Cukup tulis J/j untuk jual dan B/b untuk beli");
                jenisTransaksi = InputData.Teks("Jenis Transaksi").ToUpper();
                
                if(jenisTransaksi == "J" || jenisTransaksi == "B")
                {
                    break;
                }
                else
                {
                    Pesan.Error("Pilihan tidak ditemukan");
                }
            }
            double jumlahBarang = InputData.AngkaDouble("Jumlah Barang");

            if(jenisTransaksi == "J")
            {
                jumlahBarang = -(jumlahBarang);
            }

            double totalCashFlow = InputData.AngkaDouble("Total Cash Flow");

            Transaksi transaksiJual = new Transaksi()
            {
                Tanggal = new DateTime(tahun, bulan, tanggal),
                Waktu = waktu,
                Keterangan = keterangan,
                IdBarang = idBarang,
                JenisTransaksi = jenisTransaksi,
                JumlahBarang = jumlahBarang,
                TotalCashFlow = totalCashFlow
            };

            if (jenisTransaksi == "J")
            {
                if (transaksi.Tambah(transaksiJual) &&
                    stok.Tambah(idBarang, jumlahBarang) &&
                    laporan.Perbaharui(bulan, tahun, pendapatan: totalCashFlow))
                {
                    Console.WriteLine("\n\tData transaksi berhasil ditambahkan");
                    Console.ReadKey();
                    TampilkanTabel();
                }
                else
                {
                    Pesan.Error("Transaksi gagal dilakukan");
                }
            }
            else if(jenisTransaksi == "B")
            {
                if (transaksi.Tambah(transaksiJual) &&
                    stok.Tambah(idBarang, jumlahBarang) &&
                    laporan.Perbaharui(bulan, tahun, beban: totalCashFlow))
                {
                    Console.WriteLine("\n\tData transaksi berhasil ditambahkan");
                    Console.ReadKey();
                }
                else
                {
                    Pesan.Error("Transaksi gagal dilakukan");
                }
            }
            Menu();
        }

        private void Hapus()
        {
            Console.Clear();
            int noTransaksi;

            TampilkanTabel();

            Console.WriteLine("\n\tMasukkan informasi barang yang akan dihapus...");

            noTransaksi = InputData.AngkaInt("No. Transaksi");

            if (!transaksi.Hapus(noTransaksi))
            {
                Pesan.Error("Data transaksi gagal dihapus karena Nomor Transaksi yang Anda masukkan tidak ada");
                
            }
            Menu();
        }
    }
}
