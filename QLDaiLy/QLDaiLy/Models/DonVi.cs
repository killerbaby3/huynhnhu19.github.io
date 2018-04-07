using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDaiLy.Models
{
    public class DonVi
    {
        [Key]
        public int MaDonVi { get; set; }
        public string TenDonVi { get; set; }
        public string GhiChu { get; set; }
        public int MaMatHang { get; set; }
        public virtual ICollection<MatHang> MatHangs { get; set; }
    }
}