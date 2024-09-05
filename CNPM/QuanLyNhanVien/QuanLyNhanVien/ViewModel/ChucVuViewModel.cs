using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien.ViewModel
{
    internal class ChucVuViewModel
    {
        [Key]
        public int MaChucVu { get; set; }

        [StringLength(15)]
        public string TenChucVu { get; set; }

        public int? LuongCoBan { get; set; }
    }
}
