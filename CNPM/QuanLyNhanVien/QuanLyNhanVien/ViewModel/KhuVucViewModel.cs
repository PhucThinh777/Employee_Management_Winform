using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien.ViewModel
{
    internal class KhuVucViewModel
    {
        [Key]
        public int MaKhuVuc { get; set; }

        [StringLength(10)]
        public string TenKhuVuc { get; set; }
    }
}
