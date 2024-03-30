using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Nhom4_WebsiteMuaBanQuanAo.Models
{
    public class ConnectLoai
    {
        List<Loai> list = new List<Loai>();
        //string conStr = "Data Source = ADMIN\\SQLEXPRESS; database = QL_SHOPQUANAO; Integrated Security = true";
        string conStr = @"Data Source = LAPTOP-DAC11E8M\SQLEXPRESS; database = QL_SHOPQUANAO; Integrated Security = true";
        public List<Loai> showLoai()
        {
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = conStr;
                string sql = "select * from LOAI";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    var pro = new Loai();

                    pro.MaLoai = (int)row["MALOAI"];
                    pro.TenLoai = row["TENLOAI"].ToString();
                    list.Add(pro);
                }
            }
            return list;
        }

        public void AddLoai(Loai pro)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string strcmd1 = "select count(*) from LOAI where TENLOAI = '" + pro.TenLoai + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strcmd1;
            cmd.Connection = con;
            int kt = (int)cmd.ExecuteScalar();
            if (kt == 0)
            {
                string Strcmd = "insert into LOAI values('" + pro.MaLoai + "' , N'" + pro.TenLoai + "')";
                cmd.CommandText = Strcmd;

                int rs = cmd.ExecuteNonQuery();

            }

            con.Close();
        }

        public void UpdateLoai(Loai sp, string ma)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = conStr;
                con.Open();
                string sql = "update LOAI set MALOAI = '" + sp.MaLoai + "' ,TENLOAI = N'" + sp.TenLoai + "' where MALOAI = '" + ma + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                con.Close();
            }
        }

        public void DeleteLoai(Loai sp, string ma)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = conStr;
                con.Open();
                string sql = "DELETE FROM LOAI WHERE MALOAI = '" + ma + "'";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                con.Close();
            }
        }
    }
}