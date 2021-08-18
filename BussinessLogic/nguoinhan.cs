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
    public class nguoinhan
    {
        Data da = new Data();
        //xây dựng hàm hiển thị dữ liệu lên datagrit
        public DataTable ShowKh()
        {
            string sql = "select * from NguoiNhan";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }

        public DataTable ShowKh1(string key)
        {
            string sql = "select * from NguoiNhan where maNN = N'" + key + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertKh(string maNN, string hoten, string diachi, string sdt)
        {
            string sql = "Insert into NguoiNhan values(N'" + maNN + "',N'" + hoten + "',N'" + diachi + "',N'" + sdt + "')";
            da.ExecuteNonQuery(sql);
        }
        public void UpdateKh(string maNN, string hoten, string diachi, string sdt)
        {
            string sql = "Update NguoiNhan set maNN = N'" + maNN + "', tenNN = N'" + hoten + "', diachi = N'" + diachi + "', sdt = N'" + sdt + "' where maNN = '" + maNN + "' ";
            da.ExecuteNonQuery(sql);
        }
        public void XoaKh(string maNN)
        {
            string sql = "Delete from NguoiNhan where maNN = '" + maNN + "' ";
            da.ExecuteNonQuery(sql);
        }
    }
}
