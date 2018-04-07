using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDaiLy.Models
{
    public class PhieuXuatHang
    {
        [Key]
        public int MaPhieuXuat { get; set; }
        public DateTime  NgayLapPhieuDat { get; set; }
        public DateTime NgayLapPhieuXuat { get; set; }
        public int MaDL { get; set; }
        public int MaCTPhieu { get; set; }
        public int MaPhieuThuTien { get; set; }
        public virtual ICollection<ChiTietPhieuXuat> ChiTietXuat { get; set; }
        public virtual PhieuThuTien phieuThuTien { get; set; }
    }
}