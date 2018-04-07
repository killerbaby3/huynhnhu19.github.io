using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDaiLy.Models
{
    public class ChiTietPhieuXuat
    {
        [Key]
        public int MaCTPhieuXuat { get; set; }
        public int SoLuongDat { get; set; }
        public string TinhTrang { get; set; }
        public int TongTien { get; set; }
        public int MaMH { get; set; }
        public virtual ICollection<MatHang> MatHang { get; set; }
        public virtual PhieuXuatHang PhieuXuatHang { get; set; }
    }
}