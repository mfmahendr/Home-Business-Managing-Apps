namespace HBMConsole.Entitas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using HBMConsole.BusinessLogic;
    using HBMConsole.Interface;

    [Table("Barang")]
    public partial class Barang : IData
    {
        private bool status;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Barang()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        [StringLength(5)]
        public string Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nama { get; set; }

        [StringLength(30)]
        public string Jenis { get; set; }

        [Required]
        public string InformasiPenjelas { get; set; }

        public double Satuan { get; set; }

        public double HargaJual { get; set; }

        public virtual Stok Stok { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaksi> Transaksis { get; set; }
        
        public bool CekBarang(string namaBarang, string jenis)
        {
            return Helper.AksesTabel().Barangs.Any(x => x.Nama == namaBarang && x.Jenis == jenis);
        }

        public bool CekBarang(string namaBarang)
        {
            return Helper.AksesTabel().Barangs.Any(x => x.Nama == namaBarang);
        }

        public bool CekIdBarang(string idBarang)
        {
            return Helper.AksesTabel().Barangs.Any(x => x.Id == idBarang);
        }

        public object GetDataBerdasarkan()
        {
            return Helper.AksesTabel().Barangs.ToList();
        }

        public double GetHarga(string idBarang)
        {
            return Helper.AksesTabel().Barangs.Where(x => x.Id == idBarang).Select(x => x.HargaJual).Single();
        }

        public bool Tambah(object barang)
        {
            try
            {
                Helper.AksesTabel().Barangs.Add((Barang)barang);
                Helper.AksesTabel().SaveChanges();
                status = true;
            }
            catch(Exception)
            {
                status = false;
            }

            return status;
        }

        public bool Ubah(string kondisiId, double harga)
        {
            try
            {
                var barang = Helper.AksesTabel().Barangs.Where(x => x.Id == kondisiId).Single();
                barang.HargaJual = harga;
                status = true;
                Helper.AksesTabel().SaveChanges();
            }
            catch(Exception ex)
            {
                Pesan.Error(ex.Message);
                status = false;
            }
            return status;
            
        }

        public bool Ubah(string kondisiId, string namaBarang, string jenis, 
                         string informasi, double satuan, double harga)
        {
            try
            {
                var barang = Helper.AksesTabel().Barangs.Where(x => x.Id == kondisiId).Single();

                barang.Nama = namaBarang;
                barang.Jenis = jenis;
                barang.InformasiPenjelas = informasi;
                barang.Satuan = satuan;
                barang.HargaJual = harga;

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

        public bool Hapus(string kondisiId)
        {
            Helper.AksesTabel().Barangs.RemoveRange(Helper.AksesTabel().Barangs
                .Where(x => x.Id == kondisiId));

            Helper.AksesTabel().SaveChanges();

            return true;
        }
    }
}
