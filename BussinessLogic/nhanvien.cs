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
    public class nhanvien
    {
        Data da = new Data();
        //xây dựng hàm hiển thị dữ liệu lên datagrit
        public DataTable ShowNv()
        {
            string sql = "select * from nhanvien";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ShowNv1(string key)
        {
            string sql = "select * from nhanvien where maNV = N'" + key + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertNv(string maNV, string ten, string diachi, string gioitinh, string sdt, string danhgia)
        {
            string sql = "Insert into nhanvien values(N'" + maNV + "',N'" + ten + "',N'" + diachi + "',N'" + gioitinh + "',N'" + sdt + "',N'" + danhgia + "')";
            da.ExecuteNonQuery(sql);
        }
        public void UpdateNv(string maNV, string ten, string diachi, string gioitinh, string sdt, string danhgia)
        {
            string sql = "Update nhanvien set maNV = N'" + maNV + "', tenNV = N'" + ten + "', diachi = N'" + diachi + "', gioitinh = N'" + gioitinh + "', sdt = N'" + sdt + "', danhgia = N'" + danhgia + "'where maNV = '" + maNV + "' ";
            da.ExecuteNonQuery(sql);
        }
        public void Xoanv(string maNV)
        {
            string sql = "Delete from nhanvien where maNV = '" + maNV + "' ";
            da.ExecuteNonQuery(sql);
        }
    }
}
