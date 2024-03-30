using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Nhom4_WebsiteMuaBanQuanAo.Models
{
    public partial class SanPham
    {
        //public int MaHang { get; set; }
        //public string Size { get; set; }
        //public string MauSac { get; set; }
        //public int MaMH { get; set; }
        //public int SLNhap { get; set; }
        //public int SLConLai { get; set; }
        
       [Required(ErrorMessage = "Mã sản phẩm không được để trống")]
        public int MaHang { get; set; } 
        
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")] 
        public string TenHang { get; set; }
        [Required()]
        public string MaLoai { get; set; }
        [Required()]
        public int SLKho { get; set; }
        [Required()]
        public int DonGia { get; set; }
        public string AnhBia { get; set; }
    }
}