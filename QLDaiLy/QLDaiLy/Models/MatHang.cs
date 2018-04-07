using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDaiLy.Models
{
    public class MatHang
    {
        [Key]
        public int MaMH { get; set; }
        public string TenMH { get; set; }
        public int DonGia { get; set; }
        public int SoLuongCon { get; set; }
        public int MaLoaiMH { get; set; }
        public int MaDonVi { get; set; }
        public int MaCTPhieuXuat { get; set; }
        public virtual DonVi Donvi { get; set; }
        public virtual LoaiMatHang LoaiMatHang { get; set; }
        public virtual ChiTietPhieuXuat CTPhieuXuat { get; set; }
    }
}