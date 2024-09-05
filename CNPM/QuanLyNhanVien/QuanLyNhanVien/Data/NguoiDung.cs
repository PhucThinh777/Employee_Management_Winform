namespace QuanLyNhanVien.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        public byte MaPhanQuyen { get; set; }

        public int MaChucVu { get; set; }

        public byte MaGioiTinh { get; set; }

        public int MaKhuVuc { get; set; }

        [Key]
        [StringLength(16)]
        public string TaiKhoan { get; set; }

        [StringLength(35)]
        public string TenNguoiDung { get; set; }

        [StringLength(64)]
        public string MatKhau { get; set; }

        public int? Tuoi { get; set; }

        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [StringLength(150)]
        public string DiaChi { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        public virtual GioiTinh GioiTinh { get; set; }

        public virtual KhuVuc KhuVuc { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}
