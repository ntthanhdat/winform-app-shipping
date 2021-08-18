create database baitaplon
go 
use baitaplon
go


create table nguoinhan
(
	maNN nvarchar(20)primary key,
	tenNN nvarchar(30),
	diachi nvarchar(30),
	sdt char(20)
);
go


create table mathang
(
	mahang nvarchar(30)primary key,
	tenhang nvarchar(30),
	kichthuoc nvarchar(20),
	gia float,
	ghichu nvarchar(30)
);
go

create table nhanvien
(
	maNV nvarchar(20)Primary key,
	tenNV nvarchar(30),
	diachi nvarchar(30),
	gioitinh nvarchar(20),
	sdt nvarchar(20),
	danhgia nvarchar(100)
);
go

create table dichvu
(
	maDV nvarchar(30)primary key,
	tenDV nvarchar(50),
	phiDV float
);
go

create table donhang
(
	maDH nvarchar(20)primary key,
	maNN nvarchar(20),
	maNV nvarchar(20),
	dichvu nvarchar(30),
	ngaygoihang datetime,
	ngaygiaohang nvarchar(20),
	trangthai nvarchar(20),
	foreign key(maNN)references nguoinhan(maNN),
	foreign key(maNV)references nhanvien(maNV),
	foreign key(dichvu)references dichvu(maDV),

);
go

create table chitietdonhang
(
	maDH nvarchar(20),
	maHang nvarchar(30),
	soluong int,
	ghichu nvarchar(100),
	primary key(maDH,maHang),
	foreign key(maDH)references donhang(maDH),
	foreign key(maHang)references mathang(maHang),

);
go

create table taikhoan 
(
	username nvarchar(30),
	password nvarchar(30),
	id int primary key,
	role nvarchar(20)
);
go

