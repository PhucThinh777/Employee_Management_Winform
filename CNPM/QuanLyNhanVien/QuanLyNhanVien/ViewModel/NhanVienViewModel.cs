using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien.ViewModel
{
    internal class NhanVienViewModel
    {

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

        //Thêm
        public string Quyen { get; set; }

        public string TenChucVu { get; set; }

        public string TenKhuVuc { get; set; }

        public string GioiTinh { get; set; }

        public int? LuongCoBan { get; set; }
    }
}
