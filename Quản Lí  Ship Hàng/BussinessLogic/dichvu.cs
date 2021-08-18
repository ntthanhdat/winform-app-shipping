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
    public class dichvu
    {
        Data da = new Data();
        //xây dựng hàm hiển thị dữ liệu lên datagrit
        public DataTable ShowDV()
        {
            string sql = "select * from Dichvu";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ShowDV1(string key)
        {
            string sql = "select * from DichVu where maDV like N'" + key + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertDV(string maDV, string tenDV, float phiDV)
        {
            string sql = "Insert into DichVu values(N'" + maDV + "',N'" + tenDV + "'," + phiDV + ")";
            da.ExecuteNonQuery(sql);
        }
        public void UpdateDV(string maDV, string tenDV, float phiDV)
        {
            string sql = "Update DichVu set  tenDV = N'" + tenDV + "', phiDV = '" + phiDV + "'where maDV = N'" + maDV + "'";
            try
            {
                da.ExecuteNonQuery(sql);
            }
            catch
            {
                throw;
            }
        }
        public void XoaDV(string maDV)
        {
            string sql = "Delete from DichVu where maDV = '" + maDV + "' ";
            da.ExecuteNonQuery(sql);
        }
    }
}
