using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom4_WebsiteMuaBanQuanAo.Models
{
    public class GioHang
    {
        LoaiHangDataContext db = new LoaiHangDataContext();
        public int iMaHang { get; set; }
        public string sTenHang { get; set; }
        public string sAnhBia { get; set; }
        public int iDonGia { get; set; }
        public int iSLKho { get; set; }
        public int iThanhTien
        {
            get { return iSLKho * iDonGia; }
        }

        public GioHang(int MaHang)
        {
            iMaHang = MaHang;
            HANG hang = db.HANGs.Single(s => s.MAHANG == iMaHang);
            sTenHang = hang.TENHANG;
            sAnhBia = hang.ANHBIA;
            iDonGia = int.Parse(hang.DONGIA.ToString());
            iSLKho = 1;
        }
    }
}