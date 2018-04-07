using QLDaiLy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLDaiLy.DAL
{
    public class DaiLyContext: DbContext
    {
        public DaiLyContext() : base("QuanLyDaiLy")
            {}
        public DbSet<LoaiMatHang> LoaiMatHangs { get; set; }
        public DbSet<MatHang> MatHangs { get; set; }
        public DbSet<LoaiDaiLy> LoaiDaiLys { get; set; }
        public DbSet<DaiLy> DaiLys { get; set; }
        public DbSet<DonVi> DonVis { get; set; }
        public DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public DbSet<PhieuXuatHang> PhieuXuatHangs { get; set; }

        public DbSet<PhieuThuTien> PhieuThuTiens { get; set; }
    }
}