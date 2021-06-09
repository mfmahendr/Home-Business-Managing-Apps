namespace HBMConsole.Entitas
{
    using HBMConsole.BusinessLogic;
    using HBMConsole.Enum;
    using HBMConsole.Interface;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Transaksi")]
    public partial class Transaksi : IData
    {
        private bool status;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoTransaksi { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tanggal { get; set; }

        public TimeSpan? Waktu { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Keterangan { get; set; }

        [Required]
        [StringLength(5)]
        public string IdBarang { get; set; }

        [Required]
        [StringLength(10)]
        public string JenisTransaksi { get; set; }

        public double JumlahBarang { get; set; }

        public double? TotalCashFlow { get; set; }

        public virtual Barang Barang { get; set; }

        public object GetDataBerdasarkan()
        {
            return Helper.AksesTabel().Transaksis.ToList();
        }

        public object GetDataBerdasarkan(int noTransaksi)
        {
            return Helper.AksesTabel().Transaksis.Where(x => x.NoTransaksi == noTransaksi).Single();
        }

        public object GetDataBerdasarkan(int tahun, int bulan = 0)
        {
            if (bulan != 0)
            {
                return Helper.AksesTabel().Transaksis.Where(x => x.Tanggal.Month == bulan && x.Tanggal.Year == tahun).ToList();
            }
            else
            {
                return Helper.AksesTabel().Transaksis.Where(x =>  x.Tanggal.Year == tahun).ToList();
            }
        }

        public object GetDataBerdasarkan(string idBarang)
        {
            return Helper.AksesTabel().Transaksis.Where(x => x.IdBarang == idBarang).ToList();
        }

        public object GetDataBerdasarkan(PilihanMenuTransaksi transaksi)
        {
            object objek = null;

            if (transaksi == PilihanMenuTransaksi.Jual)
            {
                objek = Helper.AksesTabel().Transaksis.Where(x => x.JenisTransaksi == "J").ToList();
            }
            if (transaksi == PilihanMenuTransaksi.Beli)
            {
                objek = Helper.AksesTabel().Transaksis.Where(x => x.JenisTransaksi == "B").ToList();
            }

            return objek;
        }

        public bool CekTransaksi(int noTransaksi)
        {
            return Helper.AksesTabel().Transaksis.Any(x => x.NoTransaksi == noTransaksi);
        }

        public bool Tambah(object transaksi)
        {
            try
            {
                Helper.AksesTabel().Transaksis.Add((Transaksi)transaksi);
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

        public bool Hapus(int noTransaksi)
        {
            status = false;

            if (CekTransaksi(noTransaksi))
            {
                status = Hapus(GetDataBerdasarkan(noTransaksi));
            }

            return status;
        }

        public bool Hapus(object transaksi)
        {
            status = false;

            try
            {
                Helper.AksesTabel().Transaksis.Remove((Transaksi)transaksi);
                Helper.AksesTabel().SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }

            return status;
        }

    }
}
