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
    public class taikhoann
    {
        Data da = new Data();
        //xây dựng hàm hiển thị dữ liệu lên datagrit
        public DataTable ShowTK()
        {
            string sql = "select * from taikhoan";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }

        public DataTable ShowTK1(string key)
        {
            string sql = "select * from taikhoan where username = N'" + key + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertTK(string username, string password, string role)
        {
            string sql = "Insert into taikhoan(username,password,role) values(N'" + username + "',N'" + password + "',N'" + role + "')";
            da.ExecuteNonQuery(sql);
        }
        public void UpdateTK(string username, string password, string role,string name)
        {
            string sql = "Update taikhoan set username = N'" + username + "', password = N'" + password + "', role = N'" + role + "' where username = '" + name + "' ";
            da.ExecuteNonQuery(sql);
        }
        public void XoaTK(string username)
        {
            string sql = "Delete from taikhoan where username = '" + username + "' ";
            da.ExecuteNonQuery(sql);
        }
    }
}
