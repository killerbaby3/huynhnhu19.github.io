namespace QLDaiLy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuanLyDaiLy1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietPhieuXuats",
                c => new
                    {
                        MaCTPhieuXuat = c.Int(nullable: false, identity: true),
                        SoLuongDat = c.Int(nullable: false),
                        TinhTrang = c.String(),
                        TongTien = c.Int(nullable: false),
                        MaMH = c.Int(nullable: false),
                        PhieuXuatHang_MaPhieuXuat = c.Int(),
                    })
                .PrimaryKey(t => t.MaCTPhieuXuat)
                .ForeignKey("dbo.PhieuXuatHangs", t => t.PhieuXuatHang_MaPhieuXuat)
                .Index(t => t.PhieuXuatHang_MaPhieuXuat);
            
            CreateTable(
                "dbo.MatHangs",
                c => new
                    {
                        MaMH = c.Int(nullable: false, identity: true),
                        TenMH = c.String(),
                        DonGia = c.Int(nullable: false),
                        SoLuongCon = c.Int(nullable: false),
                        MaLoaiMH = c.Int(nullable: false),
                        MaDonVi = c.Int(nullable: false),
                        MaCTPhieuXuat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaMH)
                .ForeignKey("dbo.ChiTietPhieuXuats", t => t.MaCTPhieuXuat, cascadeDelete: true)
                .ForeignKey("dbo.DonVis", t => t.MaDonVi, cascadeDelete: true)
                .ForeignKey("dbo.LoaiMatHangs", t => t.MaLoaiMH, cascadeDelete: true)
                .Index(t => t.MaLoaiMH)
                .Index(t => t.MaDonVi)
                .Index(t => t.MaCTPhieuXuat);
            
            CreateTable(
                "dbo.DonVis",
                c => new
                    {
                        MaDonVi = c.Int(nullable: false, identity: true),
                        TenDonVi = c.String(),
                        GhiChu = c.String(),
                        MaMatHang = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaDonVi);
            
            CreateTable(
                "dbo.LoaiMatHangs",
                c => new
                    {
                        MaLoaiMH = c.Int(nullable: false, identity: true),
                        TenLoaiMH = c.String(),
                        GhiChu = c.String(),
                        MaMH = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaLoaiMH);
            
            CreateTable(
                "dbo.PhieuXuatHangs",
                c => new
                    {
                        MaPhieuXuat = c.Int(nullable: false, identity: true),
                        NgayLapPhieuDat = c.DateTime(nullable: false),
                        NgayLapPhieuXuat = c.DateTime(nullable: false),
                        MaDL = c.Int(nullable: false),
                        MaCTPhieu = c.Int(nullable: false),
                        MaPhieuThuTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhieuXuat)
                .ForeignKey("dbo.PhieuThuTiens", t => t.MaPhieuThuTien, cascadeDelete: true)
                .Index(t => t.MaPhieuThuTien);
            
            CreateTable(
                "dbo.PhieuThuTiens",
                c => new
                    {
                        MaPhieuThuTien = c.Int(nullable: false, identity: true),
                        NgayThu = c.DateTime(nullable: false),
                        TienThu = c.Int(nullable: false),
                        MaPhieuXuat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhieuThuTien);
            
            CreateTable(
                "dbo.DaiLies",
                c => new
                    {
                        MaDL = c.Int(nullable: false, identity: true),
                        TenDL = c.String(),
                        DiaChi = c.String(),
                        DienThoai = c.String(),
                        Quan = c.Int(nullable: false),
                        NgayTiepNhan = c.DateTime(nullable: false),
                        TienNo = c.Int(nullable: false),
                        MaLoaiDL = c.Int(nullable: false),
                        MaLoaiDaiLy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaDL)
                .ForeignKey("dbo.LoaiDaiLies", t => t.MaLoaiDL, cascadeDelete: true)
                .Index(t => t.MaLoaiDL);
            
            CreateTable(
                "dbo.LoaiDaiLies",
                c => new
                    {
                        MaLoaiDL = c.Int(nullable: false, identity: true),
                        TenLoaiDL = c.String(),
                        GhiChu = c.String(),
                        MaDaiLy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaLoaiDL);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DaiLies", "MaLoaiDL", "dbo.LoaiDaiLies");
            DropForeignKey("dbo.PhieuXuatHangs", "MaPhieuThuTien", "dbo.PhieuThuTiens");
            DropForeignKey("dbo.ChiTietPhieuXuats", "PhieuXuatHang_MaPhieuXuat", "dbo.PhieuXuatHangs");
            DropForeignKey("dbo.MatHangs", "MaLoaiMH", "dbo.LoaiMatHangs");
            DropForeignKey("dbo.MatHangs", "MaDonVi", "dbo.DonVis");
            DropForeignKey("dbo.MatHangs", "MaCTPhieuXuat", "dbo.ChiTietPhieuXuats");
            DropIndex("dbo.DaiLies", new[] { "MaLoaiDL" });
            DropIndex("dbo.PhieuXuatHangs", new[] { "MaPhieuThuTien" });
            DropIndex("dbo.MatHangs", new[] { "MaCTPhieuXuat" });
            DropIndex("dbo.MatHangs", new[] { "MaDonVi" });
            DropIndex("dbo.MatHangs", new[] { "MaLoaiMH" });
            DropIndex("dbo.ChiTietPhieuXuats", new[] { "PhieuXuatHang_MaPhieuXuat" });
            DropTable("dbo.LoaiDaiLies");
            DropTable("dbo.DaiLies");
            DropTable("dbo.PhieuThuTiens");
            DropTable("dbo.PhieuXuatHangs");
            DropTable("dbo.LoaiMatHangs");
            DropTable("dbo.DonVis");
            DropTable("dbo.MatHangs");
            DropTable("dbo.ChiTietPhieuXuats");
        }
    }
}
