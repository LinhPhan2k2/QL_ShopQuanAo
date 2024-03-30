using Nhom4_WebsiteMuaBanQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom4_WebsiteMuaBanQuanAo.Controllers
{
    public class HomeController : Controller
    {
        LoaiHangDataContext lh = new LoaiHangDataContext();
        ConnectSanPham sp = new ConnectSanPham();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SanPham()
        {
            var sanpham = sp.showSanPham();
            return View(sanpham);
        }

        public ActionResult Search(string s)
        {
            ConnectSanPham sp = new ConnectSanPham();
            List<SanPham> listSP = sp.Search(s);
            return View(listSP);
        }

        public ActionResult XemChiTiet(int ms)
        {
            HANG hang = lh.HANGs.Single(s => s.MAHANG == ms);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }
        //public ActionResult AddSanPham()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult AddSanPham(SanPham sanpham)
        //{
        //    sp.AddSanPham(sanpham);
        //    return RedirectToAction("SanPham");
        //}

        //public ActionResult UpdateSanPham(string ma)
        //{
        //    return View(sp.showSanPham().FirstOrDefault(t => Convert.ToString(t.MaMH) == ma));
        //}
        //[HttpPost]
        //public ActionResult UpdateSanPham(SanPham sps, string ma)
        //{
        //    sp.UpdateSanPham(sps, ma);
        //    return RedirectToAction("SanPham");
        //}

        //public ActionResult DeleteSanPham(string ma)
        //{
        //    return View(sp.showSanPham().FirstOrDefault(t => t.MaMH == Convert.ToInt64(ma)));
        //}

        //[HttpPost]
        //public ActionResult DeleteSanPham(SanPham ob, string ma)
        //{
        //    sp.DeleteSanPham(ob, ma);
        //    return RedirectToAction("SanPham");
        //}
	}
}