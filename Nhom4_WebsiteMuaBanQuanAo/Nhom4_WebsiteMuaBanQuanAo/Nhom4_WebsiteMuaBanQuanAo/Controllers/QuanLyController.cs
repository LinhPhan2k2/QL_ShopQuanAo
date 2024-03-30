using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Nhom4_WebsiteMuaBanQuanAo.Models;
using PagedList;

namespace Nhom4_WebsiteMuaBanQuanAo.Controllers
{
    public class QuanLyController : Controller
    {
        ConnectSanPham sp = new ConnectSanPham();
        ConnectLoai l = new ConnectLoai();
        public ActionResult Index(int? page, int ?pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 10;
            }
            
            var sanpham = sp.showAllSanPham().ToList();
            return View(sanpham.ToPagedList((int)page, (int)pageSize));
        }
        public ActionResult SanPham(int? page, int? pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 10;
            }
            var sanpham = sp.showAllSanPham().ToList();
            return View(sanpham.ToPagedList((int)page, (int)pageSize));
        }

        public ActionResult AddSanPham()
        {
            ViewBag.Loai = l.showLoai();
            return View();
        }
        [HttpPost]
        public ActionResult AddSanPham(SanPham sanpham, HttpPostedFileBase anhbia)
        {
            bool kq = sp.AddSanPham(sanpham);
            if (kq)
            {
                if (anhbia != null && anhbia.ContentLength > 0)
                {

                    string path = Path.Combine(Server.MapPath("~/Image"));
                    anhbia.SaveAs(path);
                }

                SetAlert("Thêm sản phẩm thành công", "success");
            }
            else
            {
                SetAlert("Thêm sản phẩm thất bại", "warning");
            }
            
            return RedirectToAction("SanPham");
            
        }

        public ActionResult UpdateSanPham(string ma)
        {
            return View(sp.showAllSanPham().FirstOrDefault(t => Convert.ToString(t.MaHang) == ma));
        }
        [HttpPost]
        public ActionResult UpdateSanPham(SanPham sps, string ma)
        {
            bool kq = sp.UpdateSanPham(sps, ma);
            if (kq)
            {
                SetAlert("Cập nhật sản phẩm thành công", "success");
            }
            else
            {
                SetAlert("Cập nhật sản phẩm thất bại", "warning");
            }
            
            return RedirectToAction("SanPham");
        }

        public ActionResult DeleteSanPham(string ma)
        {
            return View(sp.showAllSanPham().FirstOrDefault(t => t.MaHang == Convert.ToInt64(ma)));
        }

        [HttpPost]
        public ActionResult DeleteSanPham(SanPham ob, string ma)
        {
            bool kq = sp.DeleteSanPham(ob, ma);
            if(kq)
            {
                SetAlert("Xóa sản phẩm thành công", "success");
            }
            else
            {
                SetAlert("Xóa sản phẩm thất bại!!!", "warning");
            }
            
            return RedirectToAction("SanPham");
        }

        // Loại sản phẩm

        public ActionResult Loai()
        {
            var loai = l.showLoai();
            return View(loai);
        }

        public ActionResult AddLoai()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLoai(Loai Loai)
        {
            l.AddLoai(Loai);
            return RedirectToAction("Loai");
        }

        public ActionResult UpdateLoai(string ma)
        {
            return View(l.showLoai().FirstOrDefault(t => Convert.ToString(t.MaLoai) == ma));
        }
        [HttpPost]
        public ActionResult UpdateLoai(Loai sps, string ma)
        {
            l.UpdateLoai(sps, ma);
            return RedirectToAction("Loai");
        }

        public ActionResult DeleteLoai(string ma)
        {
            return View(l.showLoai().FirstOrDefault(t => t.MaLoai == Convert.ToInt64(ma)));
        }

        [HttpPost]
        public ActionResult DeleteLoai(Loai ob, string ma)
        {
            l.DeleteLoai(ob, ma);
            return RedirectToAction("Loai");
        }

        protected void SetAlert(string mess, string type)
        {
            TempData["AlertMessage"] = mess;
            switch(type)
            {
                case "success":
                    TempData["AlertType"] = "alert-success"; break;
                case "warning":
                    TempData["AlertType"] = "alert-warning"; break;
                case "error":
                    TempData["AlertType"] = "alert-error"; break;
                default: TempData["AlertType"] = ""; break;

            }

        }
	}
}