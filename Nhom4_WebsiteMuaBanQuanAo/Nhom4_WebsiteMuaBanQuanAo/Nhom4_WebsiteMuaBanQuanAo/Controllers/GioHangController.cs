using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom4_WebsiteMuaBanQuanAo.Models;

namespace Nhom4_WebsiteMuaBanQuanAo.Controllers
{
    public class GioHangController : Controller
    {
        LoaiHangDataContext db = new LoaiHangDataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int mh, string strURL)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang Hang = lstGioHang.Find(sp => sp.iMaHang == mh);
            if (Hang == null)
            {
                Hang = new GioHang(mh);
                lstGioHang.Add(Hang);
                return Redirect(strURL);
            }
            else
            {
                Hang.iSLKho++;
                return Redirect(strURL);
            }
        }
        public int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(sp => sp.iSLKho);
            }
            return tsl;
        }
        public int TongThanhTien()
        {
            int ttt = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                ttt += lstGioHang.Sum(sp => sp.iThanhTien);
            }
            return ttt;
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Hang");
            }
            List<GioHang> lstGioHang = LayGioHang();

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lstGioHang);
        }
        public ActionResult GioHangPartial()
        {
            //if (Session["GioHang"] == null)
            //{
            //    return RedirectToAction("Index", "Sach");
            //}
            //List<GioHang> lstGioHang = LayGioHang();

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View();
        }

        public ActionResult xoaGioHang(int MaSP)
        {
            List<GioHang> lstGioHang = LayGioHang();

            GioHang sp = lstGioHang.Single(s => s.iMaHang == MaSP);
            if (sp != null)
            {
                lstGioHang.RemoveAll(s => s.iMaHang == MaSP);
                return RedirectToAction("GioHang", "GioHang");
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Sach");
            }
            return RedirectToAction("GioHang", "GioHang");
        }   
	}
}