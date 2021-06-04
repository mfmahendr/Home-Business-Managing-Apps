namespace Home_Business_Managing_App.Entitas
{
    using Home_Business_Managing_App.BusinessLogic;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Stok")]
    public partial class Stok : IData
    {
        private bool status;

        [Key]
        [StringLength(5)]
        public string IdBarang { get; set; }

        [Column("Stok")]
        public double JumlahStok { get; set; }

        public virtual Barang Barang { get; set; }

        public bool Tambah(object stok)
        {
            try
            {
                Helper.AksesTabel().Stoks.Add((Stok)stok);
                Helper.AksesTabel().SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }

            return status;
        }

        public bool Tambah(string kondisiId, float jumlahPenambahan)
        {
            try
            {
                var stok = Helper.AksesTabel().Stoks.Where(x => x.IdBarang == kondisiId).Single();
                stok.JumlahStok += jumlahPenambahan;
                Helper.AksesTabel().SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                var tempColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ForegroundColor = tempColor;
                status = false;
            }
            return status;
        }

        public bool Ubah(string kondisiId, float jumlahStok)
        {
            try
            {
                var stok = Helper.AksesTabel().Stoks.Where(x => x.IdBarang == kondisiId).Single();
                stok.JumlahStok = jumlahStok;
                status = true;
                Helper.AksesTabel().SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                status = false;
            }
            return status;
        }

        public bool Hapus(string idBarang)
        {
            throw new NotImplementedException();
        }

        public object GetDataBerdasarkan()
        {
            return Helper.AksesTabel().ViewStoks.ToList();
        }

        public bool CekIdBarang(string idBarang)
        {
            return Helper.AksesTabel().Stoks.Any(x => x.IdBarang == idBarang);
        }
    }
}
