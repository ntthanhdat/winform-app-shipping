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
    public class login
    {
        Data da = new Data();
        //xay dung ham kiem tra tai khoan
        public string KiemTraTK(string username, string password)
        {
            string quyen = "";
            try
            {
                
                string sql = "select role from TaiKhoan where username = N'" + username + "' and password = N'" + password + "'";
                SqlConnection conn = da.getconnect1();
                SqlDataReader dr;
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    quyen = dr[0].ToString();
                }
                conn.Close();
            }
            catch
            {
                return null;
            }
            
            return quyen;
        }
    }
}
