using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDaiLy.Models
{
    public class PhieuThuTien
    {
        [Key]
        public int MaPhieuThuTien { get; set; }
        public DateTime NgayThu { get; set; }
        public int TienThu { get; set; }
        public int MaPhieuXuat { get; set; }
        public virtual ICollection<PhieuXuatHang> PhieuXuatHangs { get; set; }
    }
}