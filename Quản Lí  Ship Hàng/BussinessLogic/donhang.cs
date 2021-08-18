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
    public class donhang
    {
        Data da = new Data();
        //xây dựng hàm hiển thị dữ liệu lên datagrit
        public DataTable ShowDh()
        {
            //string sql = "select maDH as [Mã đơn hàng], maNN as [Mã Khách hàng], maNV as [Mã nhân viên],maDV as [Mã dịch vụ],ngaygoihang as [Ngày gói hàng], ngaygiaohang as [Ngày dự kiến giao], trangthai as [Trạng thái] from DonHang";
            string sql = "select * from DonHang";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ShowHd1(string maDH)
        {
            //string sql = "select DonHang.maDH as [Mã đơn hàng], maNN as [Mã Khách hàng], maNV as [Mã nhân viên],DonHang.maDV as [Mã dịch vụ],ngaygoihang as [Ngày gói hàng], ngaygiaohang as [Ngày dự kiến giao], trangthai as [Trạng thái] from Donhang where maDH = N'" + maDH + "'";
            string sql = "select * from Donhang where maDH = N'" + maDH + "'";

            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ShowHd2(string maKH)
        {
            //string sql = "select DonHang.maDH as [Mã đơn hàng], maNN as [Mã Khách hàng], maNV as [Mã nhân viên],DonHang.maDV as [Mã dịch vụ],ngaygoihang as [Ngày gói hàng], ngaygiaohang as [Ngày dự kiến giao], trangthai as [Trạng thái] from Donhang where maNN = N'" + maKH + "'";
            string sql = "select * from Donhang where maNN = N'" + maKH + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ShowHd3(string maNV)
        {
            //string sql = "select DonHang.maDH as [Mã đơn hàng], maNN as [Mã Khách hàng], maNV as [Mã nhân viên],DonHang.maDV as [Mã dịch vụ],ngaygoihang as [Ngày gói hàng], ngaygiaohang as [Ngày dự kiến giao], trangthai as [Trạng thái] from Donhang where maNV = N'" + maNV + "'";
            string sql = "select * from Donhang where maNV = N'" + maNV + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ShowHd4(string maDV)
        {
            //string sql = "select DonHang.maDH as [Mã đơn hàng], maNN as [Mã Khách hàng], maNV as [Mã nhân viên],DonHang.maDV as [Mã dịch vụ],ngaygoihang as [Ngày gói hàng], ngaygiaohang as [Ngày dự kiến giao], trangthai as [Trạng thái] from Donhang where maDV = N'" + maDV + "'";
            string sql = "select * from Donhang where maDV = N'" + maDV + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ShowHd5(string trangthai)
        {
            //string sql = "select DonHang.maDH as [Mã đơn hàng], maNN as [Mã Khách hàng], maNV as [Mã nhân viên],DonHang.maDV as [Mã dịch vụ],ngaygoihang as [Ngày gói hàng], ngaygiaohang as [Ngày dự kiến giao], trangthai as [Trạng thái] from Donhang where trangthai = N'" + trangthai + "'";
            string sql = "select * from Donhang where trangthai = N'" + trangthai + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }

        public void InsertDh(string maHD, string maNN, string maNV, string maDV, string ngaygoi, string ngaynhan, string trangthai)
        {
            try
            {
                string sql = "Insert into DonHang values(N'" + maHD + "',N'" + maNN + "',N'" + maNV + "',N'" + maDV + "', '" + ngaygoi + "', '" + ngaynhan + "',N'" + trangthai + "')";
                da.ExecuteNonQuery(sql);
            }
            catch
            {
                throw;
            }
           
        }
        public void UpdateHd(string maHD, string maNN, string maNV, string maDV, string ngaygoi, string ngaygiao, string trangthai)
        {
            string sql = "Update DonHang set maNN = N'" + maNN + "', maNV = N'" + maNV + "',maDV = N'" + maDV + "', ngaygoihang ='" + ngaygoi + "',ngaygiaohang = '" + ngaygiao + "', trangthai = N'" + trangthai + "' where maDH = N'" + maHD + "' ";
            da.ExecuteNonQuery(sql);
        }
        public void XoaHd(string maHD)
        {
            string sql = "Delete from DonHang where maDH = '" + maHD + "' ";
            da.ExecuteNonQuery(sql);
        }
        public DataTable ctietDon(string maDh)
        {
            string sql = "select ChiTietDonHang.maDH as [Mã đơn hàng] , ChiTietDonHang.mahang as[Mã hàng], soluong as [Số lượng], ChiTietDonHang.ghichu as [Ghi chú], sum(ChiTietDonHang.soluong * MatHang.gia + DichVu.phiDV) as [Tổng tiền] from ChiTietDonHang, MatHang, DichVu, DonHang where ChiTietDonHang.mahang = MatHang.mahang and DichVu.maDV = DonHang.maDV and DonHang.maDH = ChiTietDonHang.maDH group by ChiTietDonHang.maDH,ChiTietDonHang.mahang,soluong, ChiTietDonHang.ghichu";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ctietKh(string makh)
        {
            string sql = "select maNN as [Mã khách hàng], hoten as [Tên khách hàng], diachi as [Địa chỉ], sdt as [Số điện thoại] from NguoiNhan where maNN = N'" + makh + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ctietNv(string manv)
        {
            string sql = "select maNV as [Mã Nhân viên], ten as [Họ tên], diachi as [Địa chỉ], gioitinh as [Giới tính], sdt as [Số điện thoại], danhgia as [Đánh giá] from NhanVien where maNV = N'" + manv + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public DataTable ctietDv(string madv)
        {
            string sql = "select maDV as [Mã dịch vụ], tenDV as [Tên dịch vụ], phiDV as [Phí dịch vụ] from DichVu where maDV = N'" + madv + "'";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
    }
}
