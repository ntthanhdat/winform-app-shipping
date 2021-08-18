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
    public class chitiet
    {
        Data da = new Data();
        //xây dựng hàm hiển thị dữ liệu lên datagrit
        public DataTable ShowChiTiet()
        {
            string sql = "select ChiTietDonHang.maDH as [Mã đơn hàng] , ChiTietDonHang.maHang as[Mã hàng], soluong as [Số lượng], ChiTietDonHang.ghichu as [Ghi chú], sum(ChiTietDonHang.soluong * MatHang.gia + DichVu.phiDV) as [Tổng tiền] from ChiTietDonHang, MatHang, DichVu, DonHang where ChiTietDonHang.mahang = MatHang.mahang and DichVu.maDV = DonHang.maDV and DonHang.maDH = ChiTietDonHang.maDH group by ChiTietDonHang.maDH,ChiTietDonHang.mahang,soluong, ChiTietDonHang.ghichu";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ShowTim(string maDH)
        {
            string sql = "select ChiTietDonHang.maDH as [Mã đơn hàng] , ChiTietDonHang.maHang as[Mã hàng], soluong as [Số lượng], ChiTietDonHang.ghichu as [Ghi chú], sum(ChiTietDonHang.soluong * MatHang.gia + DichVu.phiDV) as [Tổng tiền] from ChiTietDonHang, MatHang, DichVu, DonHang where ChiTietDonHang.mahang = MatHang.mahang and DichVu.maDV = DonHang.maDV and DonHang.maDH = ChiTietDonHang.maDH and ChiTietDonHang.maDH =N'" + maDH + "' group by ChiTietDonHang.maDH,ChiTietDonHang.mahang,soluong, ChiTietDonHang.ghichu";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ShowTim1(string mahang)
        {
            //string sql = "select ChiTietDonHang.maDH as [Mã đơn hàng] , ChiTietDonHang.mahang as[Mã hàng], soluong as [Số lượng], ChiTietDonHang.ghichu as [Ghi chú], sum(ChiTietDonHang.soluong * MatHang.gia + DichVu.phiDV) as [Tổng tiền] from ChiTietDonHang, MatHang, DichVu, DonHang where ChiTietDonHang.mahang = MatHang.mahang and DichVu.maDV = DonHang.maDV and DonHang.maDH = ChiTietDonHang.maDH and ChiTietDonHang.mahang =N'" + mahang + "' group by ChiTietDonHang.maDH,ChiTietDonHang.mahang,soluong, ChiTietDonHang.ghichu";
            string sql = "select ChiTietDonHang.maDH as [Mã đơn hàng] , ChiTietDonHang.mahang as[Mã hàng], soluong as [Số lượng], ChiTietDonHang.ghichu as [Ghi chú], sum(ChiTietDonHang.soluong * MatHang.gia + DichVu.phiDV) as [Tổng tiền] from ChiTietDonHang, MatHang, DichVu, DonHang where ChiTietDonHang.mahang = MatHang.mahang and DichVu.maDV = DonHang.maDV and DonHang.maDH = ChiTietDonHang.maDH and ChiTietDonHang.mahang =N'" + mahang + "' group by ChiTietDonHang.maDH,ChiTietDonHang.mahang,soluong, ChiTietDonHang.ghichu";

            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }

        public void InsertChiTiet(string maDH, string mahang, string soluong, string ghichu)
        {
            string sql = "Insert into ChiTietDonHang values(N'" + maDH + "',N'" + mahang + "','" + soluong + "',N'" + ghichu+ "')";
            da.ExecuteNonQuery(sql);
        }
        public void UpdateChiTiet(string maDH, string mahang, string soluong, string ghichu)
        {
            string sql = "Update ChiTietDonHang set mahang = N'" + mahang + "', soluong = N'" + soluong + "', ghichu = N'" + ghichu + "' where maDH = N'" + maDH + "' ";
            da.ExecuteNonQuery(sql);
        }
        public void XoaChiTiet(string maDH)
        {
            string sql = "Delete from ChiTietDonHang where maDH = '" + maDH + "' ";
            da.ExecuteNonQuery(sql);
        }
        public DataTable CtietHang(string mahang)
        {
            string sql = "select mahang as [Mã hàng], tenhang as [Tên hàng], kichthuoc as [Kích thước], gia as [Giá], ghichu as [Ghi chú] from MatHang  where mahang = N'" + mahang + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
    }
}
