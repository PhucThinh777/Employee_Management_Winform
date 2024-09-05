using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien.ViewModel
{
    internal class PhanQuyenViewModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte MaPhanQuyen { get; set; }

        [StringLength(10)]
        public string Quyen { get; set; }

    }
}
