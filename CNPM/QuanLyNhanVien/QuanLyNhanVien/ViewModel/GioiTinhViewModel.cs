using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien.ViewModel
{
    internal class GioiTinhViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte MaGioiTinh { get; set; }

        [StringLength(4)]
        public string LoaiGioiTinh { get; set; }

        public byte? DoTuoiDiLam { get; set; }

        public byte? DoTuoiNghiHuu { get; set; }
    }
}
