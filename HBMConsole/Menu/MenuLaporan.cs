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
    public class MenuLaporan : SubMenu
    {
        private readonly LaporanLabaRugi laporan = new LaporanLabaRugi();
        private readonly HitungPendapatan hitung = new HitungPendapatan();

        public new void Menu()
        {
            Console.Clear();
            Console.WriteLine("\t ___________________________________________________");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t|                    Menu Laporan                   |");
            Console.WriteLine("\t|___________________________________________________|");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("\t| 0     : Keluar                                    |");
            Console.WriteLine("\t| 1     : Tampilkan Laporan Keuangan                |");
            Console.WriteLine("\t| 2     : Tambah Record                             |");
            Console.WriteLine("\t| 3     : Ubah Record                               |");
            Console.WriteLine("\t| 4     : Hapus Record                              |");
            Console.WriteLine("\t| 5     : Kembali                                   |");
            Console.WriteLine("\t|___________________________________________________|");
            while (true)
            {
                switch ((PilihanKelolaData)Perintah.Masukan())
                {
                    case PilihanKelolaData.Keluar:
                        Console.WriteLine("\n\tTerima kasih dan sampai jumpa kembali... :)");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    case PilihanKelolaData.Tampilkan:
                        DataLaporanKeuangan();
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
                        continue;
                    default:
                        Console.WriteLine("\n\tMaaf, pilihan tidak ditemukan");
                        continue;
                }
            }
        }

        public void DataLaporanKeuangan()
        {
            List<LaporanLabaRugi> listLaporan;
            Console.Clear();
            Console.WriteLine("\t ___________________________________________________");
            Console.WriteLine("\t|                                                   |");
            Console.WriteLine("\t| Berikut adalah menu-menu yang tersedia:           |");
            Console.WriteLine("\t| 1     : Tampilkan laporan keuangan tahun ini      |");
            Console.WriteLine("\t| 2     : Tampilkan berdasarkan bulan dan tahun     |");
            Console.WriteLine("\t| 3     : Kembali                                   |");
            Console.WriteLine("\t|___________________________________________________|");

            while (true)
            {
                var masukan = Perintah.Masukan();
                switch (masukan)
                {
                    case 1:
                        listLaporan = (List<LaporanLabaRugi>)laporan.GetDataBerdasarkan(DateTime.Now.Year);
                        TampilkanTabel(listLaporan);
                        DataLaporanKeuangan();
                        break;
                    case 2:
                        int bulan = InputData.AngkaInt("Bulan");
                        int tahun = InputData.AngkaInt("Tahun");
                        listLaporan = (List<LaporanLabaRugi>)laporan.GetDataBerdasarkan(tahun, bulan);
                        TampilkanTabel(listLaporan);
                        DataLaporanKeuangan();
                        break;
                    case 3:
                        Menu();
                        break;
                    case -1:
                        continue;
                    default:
                        Pesan.Warning("Maaf, pilihan tidak ditemukan");
                        continue;
                }
            }
        }

        public void TampilkanTabel(List<LaporanLabaRugi> laporanLabaRugi)
        {
            Console.Clear();

            string[] kolom = { "Periode", "Pendapatan", "Beban", "Laba/Rugi"};
            Console.WriteLine("\t ____________________________________________________________________");
            Console.WriteLine("\t| {0, -16}| {1, -15}| {2, -15}| {3, -15}|", kolom);
            Console.WriteLine("\t|_________________|________________|________________|________________|");

            foreach (var item in laporanLabaRugi)
            {
                Console.WriteLine("\t| {0, -16}| {1, -15}| {2, -15}| {3, -15}|", item.Periode.ToShortDateString(), item.Pendapatan, item.Beban, item.LabaRugi);
            }

            Console.WriteLine("\t|_________________|________________|________________|________________|");
            Console.ReadKey();
        }

        private void Tambah()
        {
            Console.Clear();
            Console.WriteLine("\n\tMasukkan informasi laporan keuangan yang ditambahkan");
            int tahun = InputData.AngkaInt("Tahun");
            int bulan = InputData.AngkaInt("Bulan");           

            double pendapatan = InputData.AngkaDouble("Pendapatan");
            double beban = InputData.AngkaDouble("Beban");
            double labaRugi = hitung.CalculateGrossProfit(pendapatan, beban);

            LaporanLabaRugi laporanBaru = new LaporanLabaRugi()
            {
                Periode = new DateTime(tahun, bulan, DateTime.DaysInMonth(tahun, bulan)),
                Pendapatan = pendapatan,
                Beban = beban,
                LabaRugi = labaRugi
            };

            if (laporan.Tambah(laporanBaru))
            {
                Console.WriteLine("\tData laporan laba rugi berhasil ditambahkan");
                Console.ReadKey();
            }
            else
            {
                Pesan.Error("Data laporan laba rugi gagal ditambahkan");
            }
            Menu();
        }

        private void Ubah()
        {
            Console.Clear();
            Console.WriteLine("\n\tMasukkan informasi laporan keuangan yang akan diubah");
            int kondisiTahun = InputData.AngkaInt("Tahun");
            int kondisiBulan = InputData.AngkaInt("Bulan");
            int kondisiTanggal = DateTime.DaysInMonth(kondisiTahun, kondisiBulan);

            if(!laporan.CekLaporanLabaRugi(kondisiTahun, kondisiBulan, kondisiTanggal))
            {
                Pesan.Warning("Data laporan tidak ditemukan");
                Menu();
            }

            Console.WriteLine("\n\tMasukkan informasi laporan keuangan yang baru");
            int tahun = InputData.AngkaInt("Tahun");
            int bulan = InputData.AngkaInt("Bulan");
            int tanggal = DateTime.DaysInMonth(kondisiTahun, kondisiBulan);
            DateTime periode = new DateTime(tahun, bulan, tanggal);

            double pendapatan = InputData.AngkaDouble("Pendapatan");
            double beban = InputData.AngkaDouble("Beban");
            double labaRugi = hitung.CalculateGrossProfit(pendapatan, beban);

            if (laporan.Ubah(kondisiTahun, kondisiBulan, kondisiTanggal, tahun, bulan, tanggal, pendapatan, beban, labaRugi))
            {
                Console.WriteLine("\n\tData laporan laba rugi berhasil diubah");
                Console.ReadKey();
            }
            else
            {
                Pesan.Error("Data laporan laba rugi gagal diubah");
            }
            Menu();
        }

        private void Hapus()
        {
            Console.Clear();
            Console.WriteLine("\n\tMasukkan informasi periode barang yang akan dihapus...");
            int tahun = InputData.AngkaInt("Tahun");
            int bulan = InputData.AngkaInt("Bulan");
            int tanggal = DateTime.DaysInMonth(tahun, bulan);

            var tempLaporan = laporan.GetDataBerdasarkan(tahun, bulan);

            if (!laporan.Hapus(tempLaporan))
            {
                Pesan.Error("Data transaksi gagal dihapus karena Nomor Transaksi yang Anda masukkan tidak ada");
            }
            else
            {
                Console.WriteLine("\n\tData transaksi berhasil dihapus");
                Console.ReadKey();
            }
            Menu();
        }
    }
}
