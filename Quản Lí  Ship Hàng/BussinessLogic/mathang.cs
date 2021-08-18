using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class mathang
    {
        Data da = new Data();
        //xây dựng hàm hiển thị dữ liệu lên datagrit
        public DataTable ShowMH()
        {
            string sql = "select * from MatHang";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ShowMH1(string key)
        {
            string sql = "select * from MatHang where mahang like N'" + key + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertMh(string mahang, string tenhang, string kichthuoc, int gia, string ghichu)
        {
            string sql = "Insert into MatHang values(N'" + mahang + "',N'" + tenhang + "',N'" + kichthuoc +"', '"+gia+"' ,N'" + ghichu + "')";
            da.ExecuteNonQuery(sql);
        }
        public void UpdateMh(string mahang, string tenhang, string kichthuoc, string ghichu, string matg)
        {
            string sql = "Update MatHang set mahang = N'" + mahang + "', tenhang = N'" + tenhang + "', kichthuoc = N'" + kichthuoc + "', ghichu = N'" + ghichu + "', where mahang = '" + matg + "' ";
            da.ExecuteNonQuery(sql);
        }
        public void XoaMh(string mahang)
        {
            string sql = "Delete from MatHang where mahang = '" + mahang + "' ";
            da.ExecuteNonQuery(sql);
        }
    }
}
