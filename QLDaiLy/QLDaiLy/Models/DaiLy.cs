using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDaiLy.Models
{
    public class DaiLy
    {
        [Key]
        public int MaDL { get; set; }
        public string TenDL { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public  int Quan { get; set; }
        public DateTime NgayTiepNhan { get; set; }
        public  int TienNo { get; set; }
        public int MaLoaiDL { get; set; }
        public int MaLoaiDaiLy { get; set; }
    }
}