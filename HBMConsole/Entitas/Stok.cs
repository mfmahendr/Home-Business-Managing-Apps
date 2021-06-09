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

        public object GetDataBerdasarkan()
        {
            return Helper.AksesTabel().ViewStoks.ToList();
        }

        public bool CekIdBarang(string idBarang)
        {
            return Helper.AksesTabel().Stoks.Any(x => x.IdBarang == idBarang);
        }

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

        public bool Tambah(string kondisiId, double jumlahPenambahan)
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
                Pesan.Error(ex.Message);
                status = false;
            }

            return status;
        }

        public bool Ubah(string kondisiId, double jumlahStok)
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
                Pesan.Error(ex.Message);
                status = false;
            }
            return status;
        }

        public bool Hapus(string idBarang)
        {
            try
            {
                Helper.AksesTabel().Stoks.Remove(Helper.AksesTabel().Stoks.Where(x => x.IdBarang == idBarang).Single());
                status = true;
                Helper.AksesTabel().SaveChanges();
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
