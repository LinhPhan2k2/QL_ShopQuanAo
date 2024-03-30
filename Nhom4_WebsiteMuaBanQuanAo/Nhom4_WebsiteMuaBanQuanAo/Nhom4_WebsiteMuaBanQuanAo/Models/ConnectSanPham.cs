using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Nhom4_WebsiteMuaBanQuanAo.Models
{
    public class ConnectSanPham
    {
        List<SanPham> list = new List<SanPham>();
        //string conStr = "Data Source = ADMIN\\SQLEXPRESS; database = QL_SHOPQUANAO; Integrated Security = true";
        string conStr = @"Data Source = LAPTOP-DAC11E8M\SQLEXPRESS; database = QL_SHOPQUANAO; Integrated Security = true";
        public List<SanPham> showSanPham()
        {
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = conStr;
                string sql = "select * from HANG";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var pro = new SanPham();

                    pro.MaHang = (int)row["MAHANG"];
                    pro.TenHang = row["TENHANG"].ToString();
                    pro.DonGia = (int)row["DONGIA"];
                    pro.AnhBia = row["ANHBIA"].ToString();
                    list.Add(pro);
                }
            }
            return list;
        }

        public List<SanPham> showAllSanPham()
        {
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = conStr;
                string sql = "select * from HANG,LOAI where HANG.MALOAI = LOAI.MALOAI";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var pro = new SanPham();

                    pro.MaHang = (int)row["MAHANG"];
                    pro.TenHang = row["TENHANG"].ToString();
                    pro.MaLoai = row["TENLOAI"].ToString();
                    pro.SLKho = (int)row["SLKHO"];
                    pro.DonGia = (int)row["DONGIA"];
                    pro.AnhBia = row["ANHBIA"].ToString();
                    list.Add(pro);
                }
            }
            return list;
        }

        public List<SanPham> Search(string s)
        {
            List<SanPham> listSP = new List<SanPham>();
            SqlConnection con = new SqlConnection(conStr);
            string sql = "Select * from HANG where TENHANG like '%'+ @ten + '%'";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            SqlParameter par = new SqlParameter("@ten", s);
            cmd.Parameters.Add(par);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                SanPham pro = new SanPham();
                pro.MaHang = Convert.ToInt32(rdr.GetValue(0).ToString());
                pro.TenHang = rdr.GetValue(1).ToString();
                pro.DonGia = (int)rdr.GetValue(2);
                pro.AnhBia = rdr.GetValue(5).ToString();
                listSP.Add(pro);
            }
            return listSP;
        }

        public bool AddSanPham(SanPham pro)
        {
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                string strcmd1 = "select count(*) from HANG where TENHANG = '" + pro.TenHang + "' and MAHANG = '" + pro.MaHang + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strcmd1;
                cmd.Connection = con;
                int kt = (int)cmd.ExecuteScalar();
                if (kt == 0)
                {
                    string Strcmd = "insert into HANG values('" + pro.MaHang + "' , N'" + pro.TenHang + "' , '" + pro.MaLoai + "' , '" + pro.SLKho + "' , '" + pro.DonGia + "' , '" + pro.AnhBia + "')";
                    cmd.CommandText = Strcmd;

                    int rs = cmd.ExecuteNonQuery();
                    
                }
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            

            
        }

        public bool UpdateSanPham(SanPham sp, string ma)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    con.Open();
                    string sql = "update HANG set MAHANG = '" + sp.MaHang + "' ,TENHANG = N'" + sp.TenHang + "' , MALOAI = '" + sp.MaLoai + "' ,SLKHO = '" + sp.SLKho + "' , DONGIA = '" + sp.DonGia + "' , ANHBIA = '" + sp.AnhBia + "' where MAHANG = '" + ma + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool DeleteSanPham(SanPham sp, string ma)
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = conStr;
                    con.Open();
                    string sql = "DELETE FROM HANG WHERE MAHANG = '" + ma + "'";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                    con.Close();
                }
                return true; // xoa thanh cong
            }
            catch (Exception ex)
            {
                return false; // xoa không thanh cong
            }
           
        }
    }
}