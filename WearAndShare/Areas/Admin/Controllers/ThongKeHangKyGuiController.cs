using WearAndShare.Areas.Admin.ViewModels;
using WearAndShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WearAndShare.Areas.Admin.Controllers
{
    [Authorize]
    public class ThongKeHangKyGuiController : Controller
    {

        menfashionEntities db = new menfashionEntities();
        // GET: Admin/ThongKeHangKyGui
        public ActionResult Index(int? thang, int? nam)
        {
            List<HangKyGuiVM> tongHopHangHoaKyGui = new List<HangKyGuiVM>();

            if (!thang.HasValue || !nam.HasValue)
            {
                tongHopHangHoaKyGui = db.Products.Where(x => x.IsHangKyGui)
                .Join(db.InvoinceDetails, x => x.productId, y => y.productId, (x, y) =>
                new HangKyGuiVM
                {
                    productId = x.productId,
                    ProductName = x.productName,
                    ThanhTien = (decimal)y.totalPrice,
                    LoaiChietKhau = x.PhuongThucChietKhau,
                    GiaTriChietKhau = x.GiaTriChietKhau,
                    LoiNhuan = 0
                }).ToList();
            }
            else
            {
                tongHopHangHoaKyGui = db.Products.Where(x => x.IsHangKyGui)
                .Join(db.Invoinces.Where(x => x.dateOrder.Value.Year == nam
                    && x.dateOrder.Value.Month == thang).Join(db.InvoinceDetails, x => x.invoinceNo, y => y.invoinceNo, (x, y) => y), x => x.productId, y => y.productId, (x, y) =>
                new HangKyGuiVM
                {
                    productId = x.productId,
                    ProductName = x.productName,
                    ThanhTien = (decimal)y.totalPrice,
                    LoaiChietKhau = x.PhuongThucChietKhau,
                    GiaTriChietKhau = x.GiaTriChietKhau,
                    LoiNhuan = 0
                }).ToList();
            } 
             
            for (int i = 0; i < tongHopHangHoaKyGui.Count; i++)
            {
                // Chiết khấu theo % sản phẩm
                if (tongHopHangHoaKyGui[i].LoaiChietKhau == 0)
                {
                    tongHopHangHoaKyGui[i].LoiNhuan = tongHopHangHoaKyGui[i]
                        .ThanhTien * (tongHopHangHoaKyGui[i].GiaTriChietKhau / 100);
                } 

                // Chiết khấu tiền mặt
                if (tongHopHangHoaKyGui[i].LoaiChietKhau == 1)
                {
                    tongHopHangHoaKyGui[i].LoiNhuan = tongHopHangHoaKyGui[i]
                        .GiaTriChietKhau;
                } 
            }

            var duLieuThongKe = tongHopHangHoaKyGui
                .GroupBy(x => x.productId)
                .Select(x => new
                {
                    ProductId = x.Key,
                    ProductName = x.FirstOrDefault().ProductName,
                    TongDoanhThu = x.Sum(y => y.ThanhTien),
                    TongLoiNhuan = x.Sum(y => y.LoiNhuan)
                }).ToList();

            ViewBag.Labels = duLieuThongKe
                .Select(x => x.ProductName)
                .ToList();

            ViewBag.DataLoiNhuans = duLieuThongKe
                .Select(x => (int) x.TongLoiNhuan)
                .ToList();

            ViewBag.DataDoanhThus = duLieuThongKe
                .Select(x => (int) x.TongDoanhThu)
                .ToList();

            return View();
        }
    }
}