namespace Home_Business_Managing_App.Entitas
{
    using Home_Business_Managing_App.BusinessLogic;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaksi")]
    public partial class Transaksi : IData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public bool Tambah(object transaksi)
        {
            throw new NotImplementedException();
        }

        public bool Ubah()
        {
            throw new NotImplementedException();
        }

        public bool Hapus()
        {
            throw new NotImplementedException();
        }

        public object GetDataBerdasarkan()
        {
            throw new NotImplementedException();
        }
    }
}
