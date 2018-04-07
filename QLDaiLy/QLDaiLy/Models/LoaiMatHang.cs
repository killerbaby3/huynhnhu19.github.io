using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDaiLy.Models
{
    public class LoaiMatHang
    {
        [Key]
        public int MaLoaiMH { get; set; }
        public string TenLoaiMH { get; set; }
        public string GhiChu { get; set; }
        public int MaMH { get; set; }
        public virtual ICollection<MatHang> MatHang { get; set; }
    }
}