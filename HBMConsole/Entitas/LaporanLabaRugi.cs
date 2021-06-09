namespace HBMConsole.Entitas
{
    using HBMConsole.BusinessLogic;
    using HBMConsole.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("LaporanLabaRugi")]
    public partial class LaporanLabaRugi : IData
    {
        private bool status;
        private readonly HitungPendapatan hitung = new HitungPendapatan();

        [Key]
        public DateTime Periode { get; set; }

        public double Pendapatan { get; set; }

        public double Beban { get; set; }

        public double LabaRugi { get; set; }

        public object GetDataBerdasarkan()
        {
            return Helper.AksesTabel().LaporanLabaRugis.ToList();
        }

        public object GetDataBerdasarkan(int tahun, int bulan = 0)
        {
            if (bulan != 0)
            {
                return Helper.AksesTabel().LaporanLabaRugis.Where(x => x.Periode.Year == tahun && x.Periode.Month == bulan).Single();
            }
            else
            {
                return Helper.AksesTabel().LaporanLabaRugis.Where(x => x.Periode.Year == tahun).ToList();
            }
        }

        public bool CekLaporanLabaRugi(int tahun, int bulan, int tanggal)
        {
            return Helper.AksesTabel().LaporanLabaRugis.Any(x => x.Periode.Year == tahun && x.Periode.Month == bulan && x.Periode.Day == tanggal);
        }

        public bool Tambah(object laporan)
        {
            status = false;

            try
            {
                Helper.AksesTabel().LaporanLabaRugis.Add((LaporanLabaRugi)laporan);
                Helper.AksesTabel().SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                Pesan.Error(ex.Message);
                status = false;
            }
            
            return status;
        }

        public bool Perbaharui(int kondisiBulan, int kondisiTahun, double pendapatan = 0, double beban = 0)
        {
            
            status = false;
            List<LaporanLabaRugi> laporan = Helper.AksesTabel().LaporanLabaRugis
                                            .Where(x => x.Periode.Month == kondisiBulan && x.Periode.Year == kondisiTahun).ToList();

            if (pendapatan != 0 && beban != 0)
            {
                foreach (var item in laporan)
                {
                    item.Pendapatan += pendapatan;
                    item.Beban += beban;
                    item.LabaRugi = hitung.CalculateGrossProfit(item.Pendapatan, item.Beban);
                }

                status = true;
            }
            else if (pendapatan != 0)
            {
                foreach (var item in laporan)
                {
                    item.Pendapatan += pendapatan;
                    item.LabaRugi = hitung.CalculateGrossProfit(item.Pendapatan, item.Beban); ;
                }

                status = true;
            }
            else if (beban != 0)
            {
                foreach (var item in laporan)
                {
                    item.Beban += beban;
                    item.LabaRugi = hitung.CalculateGrossProfit(item.Pendapatan, item.Beban);
                }

                status = true;
            }
            Helper.AksesTabel().SaveChanges();
            return status;
        }

        public bool Hapus(object laporan)
        {
            status = false;

            try
            {
                Helper.AksesTabel().LaporanLabaRugis.Remove((LaporanLabaRugi)laporan);
                Helper.AksesTabel().SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                Pesan.Error(ex.Message);
                status = false;
            }

            return status;
        }

        public bool Hapus(int tahun, int bulan)
        {
            return Hapus(GetDataBerdasarkan(tahun, bulan));
        }
        
        public bool Ubah(int kondisiTahun, int kondisiBulan, int kondisiTanggal, 
                         int tahun, int bulan, int tanggal, 
                         double pendapatan, double beban, double labaRugi)
        {
            status = false;

            try
            {

                var laporan = Helper.AksesTabel().LaporanLabaRugis
                    .Where(x => x.Periode.Year == kondisiTahun && x.Periode.Month == kondisiBulan && x.Periode.Day == kondisiTanggal)
                    .Single();

                laporan.Periode = new DateTime(tahun, bulan, tanggal);
                laporan.Pendapatan = pendapatan;
                laporan.Beban = beban;
                laporan.LabaRugi = hitung.CalculateGrossProfit(pendapatan, beban);

                Helper.AksesTabel().SaveChanges();
                status = true;
            }
            catch (ArgumentNullException)
            {
                Pesan.Error("Laporan tidak ditemukan");
                status = false;
            }
            catch (Exception ex)
            {
                Pesan.Error(ex.Message);
                status = false;
            }

            return status;
        }
    }
}
