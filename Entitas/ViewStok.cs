namespace Home_Business_Managing_App.Entitas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewStok")]
    public partial class ViewStok
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Nama { get; set; }

        [StringLength(30)]
        public string Jenis { get; set; }

        [Key]
        [Column("Stok", Order = 2)]
        public double JumlahStok { get; set; }
    }
}
