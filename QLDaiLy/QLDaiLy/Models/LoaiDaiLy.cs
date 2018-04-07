using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDaiLy.Models
{
    public class LoaiDaiLy
    {
        [Key]
        public int MaLoaiDL { get; set; }
        public string TenLoaiDL { get; set; }
        public string GhiChu { get; set; }
        public int MaDaiLy { get; set; }
        public virtual ICollection<DaiLy> DaiLy { get; set; }
    }
}