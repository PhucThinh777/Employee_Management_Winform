using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyNhanVien.Data
{
    public partial class DBContectQLNV : DbContext
    {
        public DBContectQLNV()
            : base("name=DBContectQLNV")
        {
        }

        public virtual DbSet<ChucVu> ChucVu { get; set; }
        public virtual DbSet<GioiTinh> GioiTinh { get; set; }
        public virtual DbSet<KhuVuc> KhuVuc { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.NguoiDung)
                .WithRequired(e => e.ChucVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GioiTinh>()
                .HasMany(e => e.NguoiDung)
                .WithRequired(e => e.GioiTinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhuVuc>()
                .Property(e => e.TenKhuVuc)
                .IsUnicode(false);

            modelBuilder.Entity<KhuVuc>()
                .HasMany(e => e.NguoiDung)
                .WithRequired(e => e.KhuVuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<PhanQuyen>()
                .HasMany(e => e.NguoiDung)
                .WithRequired(e => e.PhanQuyen)
                .WillCascadeOnDelete(false);
        }
    }
}
