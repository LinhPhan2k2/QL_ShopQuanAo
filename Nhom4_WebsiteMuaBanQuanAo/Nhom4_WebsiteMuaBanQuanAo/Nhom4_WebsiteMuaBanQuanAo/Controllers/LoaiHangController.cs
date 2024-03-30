using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom4_WebsiteMuaBanQuanAo.Models;

namespace Nhom4_WebsiteMuaBanQuanAo.Controllers
{
    public class LoaiHangController : Controller
    {
        LoaiHangDataContext lh = new LoaiHangDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoaiHangPartial()
        {
            var ListLoaiHang = lh.LOAIs.Take(5).OrderBy(cd => cd.TENLOAI).ToList();
            return PartialView(ListLoaiHang);
        }
        public ActionResult SanPhamTheoLoai(int maloai)
        {
            var ListLoai = lh.HANGs.Where(s => s.MALOAI == maloai).OrderBy(s => s.DONGIA).ToList();
            if (ListLoai.Count == 0)
                ViewBag.Sach = "ko có loại sản phẩm này";
            return View(ListLoai);
        }
	}
}