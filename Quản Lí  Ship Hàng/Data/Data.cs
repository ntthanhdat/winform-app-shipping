using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Data
    {

        // xây dựng hàm trả về bảng
        DataTable dt;
        SqlConnection con;
        string getconnect = @"Data Source=DESKTOP-122A90T\SQLEXPRESS;  Initial Catalog=QuanLyShipHang;  Integrated Security=True";
        SqlDataAdapter adt;
        SqlCommand cmd;
        public DataTable GetTable(string sql)
        {
            try
            {
                con = new SqlConnection(getconnect);
                SqlDataAdapter adt = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public SqlConnection getconnect1()
        {
            return new SqlConnection(@"Data Source=DESKTOP-122A90T\SQLEXPRESS;Initial Catalog=QuanLyShipHang;Integrated Security=True");
        }

        public void ExecuteNonQuery(string sql)
        {
            try
            {
                con = new SqlConnection(getconnect);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Dispose();
                con.Close();
            }
            catch
            {
                throw; 
            }
        }
        public SqlConnection moketnoi()
        {
            con = new SqlConnection(getconnect);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public DataTable xuly(string sql)
        {
            moketnoi();
            dt = new DataTable();
            cmd = new SqlCommand(sql, con);
            adt = new SqlDataAdapter(cmd);
            adt.Fill(dt);
            dongketnoi();
            return dt;
        }


        public SqlConnection dongketnoi()
        {
            con = new SqlConnection(getconnect);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }
        public DataTable Kiemtra(string sql)
        {
            dt = new DataTable();
            moketnoi();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            adt = new SqlDataAdapter(cmd);
            adt.Fill(dt);
            dongketnoi();
            return dt;
        }
    }

}
