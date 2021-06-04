namespace Home_Business_Managing_App.Entitas
{
    using Home_Business_Managing_App.BusinessLogic;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LaporanLabaRugi")]
    public partial class LaporanLabaRugi : IData
    {
        [Key]
        public DateTime Periode { get; set; }

        public double Pendapatan { get; set; }

        public double Beban { get; set; }

        public double LabaRugi { get; set; }

        public object GetDataBerdasarkan()
        {
            throw new NotImplementedException();
        }

        public bool Hapus()
        {
            throw new NotImplementedException();
        }

        public bool Tambah(object laporan)
        {
            throw new NotImplementedException();
        }

        public bool Ubah()
        {
            throw new NotImplementedException();
        }
    }
}
