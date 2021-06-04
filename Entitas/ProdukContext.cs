using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Home_Business_Managing_App.Entitas
{
    public partial class ProdukContext : DbContext
    {
        public ProdukContext()
            : base("name=ProdukContext")
        {
        }

        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<LaporanLabaRugi> LaporanLabaRugis { get; set; }
        public virtual DbSet<Stok> Stoks { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }
        public virtual DbSet<ViewStok> ViewStoks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .Property(e => e.Nama)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .Property(e => e.Jenis)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .Property(e => e.InformasiPenjelas)
                .IsUnicode(false);

            modelBuilder.Entity<Barang>()
                .HasOptional(e => e.Stok)
                .WithRequired(e => e.Barang);

            modelBuilder.Entity<Barang>()
                .HasMany(e => e.Transaksis)
                .WithRequired(e => e.Barang)
                .HasForeignKey(e => e.IdBarang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stok>()
                .Property(e => e.IdBarang)
                .IsUnicode(false);

            modelBuilder.Entity<Transaksi>()
                .Property(e => e.Keterangan)
                .IsUnicode(false);

            modelBuilder.Entity<Transaksi>()
                .Property(e => e.IdBarang)
                .IsUnicode(false);

            modelBuilder.Entity<Transaksi>()
                .Property(e => e.JenisTransaksi)
                .IsFixedLength();

            modelBuilder.Entity<ViewStok>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<ViewStok>()
                .Property(e => e.Nama)
                .IsUnicode(false);

            modelBuilder.Entity<ViewStok>()
                .Property(e => e.Jenis)
                .IsUnicode(false);
        }
    }
}
