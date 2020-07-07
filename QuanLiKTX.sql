CREATE DATABASE QLKTX
GO
USE QLKTX
GO
CREATE TABLE SINHVIEN(
MaSV NCHAR(15) PRIMARY KEY NOT NULL,
HoTen NVARCHAR(50)NOT NULL,
NgaySinh DATETIME,
GioiTinh NCHAR(4),
CMND INT NOT NULL,
QueQuan NVARCHAR(50),
Lop NVARCHAR(50)NOT NULL,
Khoa NVARCHAR(50)
)

CREATE TABLE PHONG(
MaPhong NCHAR(15) PRIMARY KEY NOT NULL,
SoCho INT CHECK(SoCho <= 8),
TinhTrang NVARCHAR(30),
MaCTD NCHAR(15)NOT NULL,
MaCTN NCHAR(15)NOT NULL
)

CREATE TABLE PHONGSV(
MaPhongSV INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
MaPhong NCHAR(15) NOT NULL,
MaSV NCHAR(15) NOT NULL,
ThoiGianBĐ DATETIME NOT NULL,
ThoiGianKT DATETIME NOT NULL,
FOREIGN KEY(MaPhong)REFERENCES dbo.PHONG(MaPhong),
FOREIGN KEY(MaSV)REFERENCES dbo.SINHVIEN(MaSV) 
ON DELETE CASCADE
ON UPDATE CASCADE
)

CREATE TABLE DIEN(
MaDien INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
MaPhong NCHAR(15) NOT NULL,
NgayGhi DATETIME NOT NULL,
CSD INT NOT NULL,
CSC INT NOT NULL,
DonGia FLOAT NOT NULL,
FOREIGN KEY(MaPhong)REFERENCES dbo.PHONG(MaPhong)
ON DELETE CASCADE
ON UPDATE CASCADE
)

CREATE TABLE NUOC(
MaNuoc INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
MaPhong NCHAR(15) NOT NULL,
NgayGhi DATETIME NOT NULL,
CSD INT NOT NULL,
CSC INT NOT NULL,
DonGia FLOAT NOT NULL,
FOREIGN KEY(MaPhong)REFERENCES dbo.PHONG(MaPhong)
ON DELETE CASCADE
ON UPDATE CASCADE
)

CREATE TABLE NGUOIDUNG(
TenDangNhap VARCHAR(20) ,
MatKhau VARCHAR(20) NOT NULL,
MaNV NCHAR(15) NOT NULL,
HoTenNV NVARCHAR(50) NOT NULL,
ChucVu INT,
CONSTRAINT nguoidung_pk PRIMARY KEY(MaNV),
UNIQUE(TenDangNhap)
)

CREATE TABLE HOADON(
MaHD INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
MaPhong NCHAR(15) NOT NULL,
NgayGhi DATETIME,
MaNV NCHAR(15) NOT NULL,
FOREIGN KEY(MaPhong) REFERENCES dbo.PHONG(MaPhong),
FOREIGN KEY(MaNV) REFERENCES dbo.NGUOIDUNG(MaNV)
ON DELETE CASCADE
ON UPDATE CASCADE
)


INSERT INTO dbo.NGUOIDUNG
        ( TenDangNhap ,
          MatKhau ,
          MaNV ,
          HoTenNV ,
          ChucVu
        )
VALUES  ( 'admin' , -- TenDangNhap - varchar(20)
          'admin' , -- MatKhau - varchar(20)
          N'GD' , -- MaNV - nchar(15)
          N'Nguyễn Văn Anh' , -- HoTenNV - nvarchar(50)
          1  -- ChucVu - int
        )
INSERT INTO dbo.NGUOIDUNG
        ( TenDangNhap ,
          MatKhau ,
          MaNV ,
          HoTenNV ,
          ChucVu
        )
VALUES  ( 'vothithao' , -- TenDangNhap - varchar(20)
          '123456' , -- MatKhau - varchar(20)
          N'QL01' , -- MaNV - nchar(15)
          N'Võ Thị Thao' , -- HoTenNV - nvarchar(50)
          0  -- ChucVu - int
        )


INSERT INTO dbo.SINHVIEN
        ( MaSV ,
          HoTen ,
          NgaySinh ,
          GioiTinh ,
          CMND ,
          QueQuan ,
          Lop ,
          Khoa
        )
VALUES  ( N'4051050084' , -- MaSV - nchar(15)
          N'Võ Thị Thao' , -- HoTen - nvarchar(50)
          '19990306' , -- NgaySinh - datetime
          N'Nữ' , -- GioiTinh - nchar(4)
          255483525 , -- CMND - int
          N'Bình Định' , -- QueQuan - nvarchar(50)
          N'CNTT K40B' , -- Lop - nvarchar(50)
          N'CNTT'  -- Khoa - nvarchar(50)
        )
INSERT INTO dbo.SINHVIEN
        ( MaSV ,
          HoTen ,
          NgaySinh ,
          GioiTinh ,
          CMND ,
          QueQuan ,
          Lop ,
          Khoa
        )
VALUES  ( N'405104101' , -- MaSV - nchar(15)
          N'Trần Thái Nguyên' , -- HoTen - nvarchar(50)
          '19991012' , -- NgaySinh - datetime
          N'Nam' , -- GioiTinh - nchar(4)
          255483115, -- CMND - int
          N'Bình Định' , -- QueQuan - nvarchar(50)
          N'CNTT K40B' , -- Lop - nvarchar(50)
          N'CNTT'  -- Khoa - nvarchar(50)
        ),
		( N'405104901' , -- MaSV - nchar(15)
          N'Mai Thanh Phong' , -- HoTen - nvarchar(50)
          '19990112' , -- NgaySinh - datetime
          N'Nam' , -- GioiTinh - nchar(4)
          255452155 , -- CMND - int
          N'Bình Định' , -- QueQuan - nvarchar(50)
          N'CNTT K40B' , -- Lop - nvarchar(50)
          N'CNTT'  -- Khoa - nvarchar(50)
        ),
		( N'405104401' , -- MaSV - nchar(15)
          N'Trần Duy Phương' , -- HoTen - nvarchar(50)
          '19981012' , -- NgaySinh - datetime
          N'Nam' , -- GioiTinh - nchar(4)
          259793315 , -- CMND - int
          N'Bình Định' , -- QueQuan - nvarchar(50)
          N'SP Hoá' , -- Lop - nvarchar(50)
          N'Hoá'  -- Khoa - nvarchar(50)
        ),
		( N'405104211' , -- MaSV - nchar(15)
          N'Trịnh Ngọc Hiếu' , -- HoTen - nvarchar(50)
          '19980121' , -- NgaySinh - datetime
          N'Nam' , -- GioiTinh - nchar(4)
          255473155 , -- CMND - int
          N'Bình Định' , -- QueQuan - nvarchar(50)
          N'CNTT K40B' , -- Lop - nvarchar(50)
          N'CNTT'  -- Khoa - nvarchar(50)
        )


INSERT INTO dbo.PHONG
        ( MaPhong ,
          SoCho ,
          TinhTrang ,
          MaCTD ,
          MaCTN
        )
VALUES  ( N'C1.101' , -- MaPhong - nchar(15)
          8 , -- SoCho - int
          N'Ổn định' , -- TinhTrang - nvarchar(30)
          N'C1.101' , -- MaCTD - nchar(15)
          N'C1.101'  -- MaCTN - nchar(15)
        )
INSERT INTO dbo.PHONG
        ( MaPhong ,
          SoCho ,
          TinhTrang ,
          MaCTD ,
          MaCTN
        )
VALUES  ( N'C1.102' , -- MaPhong - nchar(15)
          7 , -- SoCho - int
          N'Hư hỏng 1 bóng đèn' , -- TinhTrang - nvarchar(30)
          N'C1.102' , -- MaCTD - nchar(15)
          N'C1.102'  -- MaCTN - nchar(15)
        ),
		( N'C1.103' , -- MaPhong - nchar(15)
          8 , -- SoCho - int
          N'Tốt' , -- TinhTrang - nvarchar(30)
          N'C1.103' , -- MaCTD - nchar(15)
          N'C1.103'  -- MaCTN - nchar(15)
        ),
		( N'C1.104' , -- MaPhong - nchar(15)
          8 , -- SoCho - int
          N'Tốt' , -- TinhTrang - nvarchar(30)
          N'C1.104' , -- MaCTD - nchar(15)
          N'C1.104'  -- MaCTN - nchar(15)
        )

INSERT INTO dbo.PHONGSV
        ( MaPhongSV ,
		MaPhong,
          MaSV ,
          ThoiGianBĐ ,
          ThoiGianKT
        )
VALUES  (	N'1',
			N'C1.101' , -- MaPhong - nchar(15)
          N'4051050084' , -- MaSV - nchar(15)
          '20190915' , -- ThoiGianBĐ - datetime
          '20200715' -- ThoiGianKT - datetime
        ),
		( N'2',
		N'C1.101' , -- MaPhong - nchar(15)
          N'4051050057' , -- MaSV - nchar(15)
          '20190915' , -- ThoiGianBĐ - datetime
          '20200715' -- ThoiGianKT - datetime
        ),
		(	N'3',
			 N'C1.101' , -- MaPhong - nchar(15)
          N'4051050001' , -- MaSV - nchar(15)
          '20190915' , -- ThoiGianBĐ - datetime
          '20200715' -- ThoiGianKT - datetime
        )

INSERT INTO dbo.DIEN
        ( 
          MaPhong ,
          NgayGhi ,
          CSD ,
          CSC ,
          DonGia
        )
VALUES  ( 
          N'C1.101' , -- MaPhong - nchar(15)
          '20191015' , -- NgayGhi - datetime
          15 , -- CSD - int
          20 , -- CSC - int
          3000.0  -- DonGia - float
        )
INSERT INTO dbo.DIEN
        ( 
          MaPhong ,
          NgayGhi ,
          CSD ,
          CSC ,
          DonGia
        )
VALUES  ( 
          N'C1.102' , -- MaPhong - nchar(15)
          '20191015' , -- NgayGhi - datetime
          15 , -- CSD - int
          22 , -- CSC - int
          3000.0  -- DonGia - float
        ),
		( 
          N'C1.103' , -- MaPhong - nchar(15)
          '20191015' , -- NgayGhi - datetime
          10 , -- CSD - int
          26 , -- CSC - int
          3000.0  -- DonGia - float
        )
INSERT INTO dbo.NUOC
        ( 
          MaPhong ,
          NgayGhi ,
          CSD ,
          CSC ,
          DonGia
        )
VALUES  ( 
          N'C1.101' , -- MaPhong - nchar(15)
          '20191015' , -- NgayGhi - datetime
          15 , -- CSD - int
          25 , -- CSC - int
          11000.0  -- DonGia - float
        ),
		( 
          N'C1.102' , -- MaPhong - nchar(15)
          '20191015' , -- NgayGhi - datetime
          15 , -- CSD - int
          20 , -- CSC - int
          11000.0  -- DonGia - float
        ),
		( 
          N'C1.103' , -- MaPhong - nchar(15)
          '20191015' , -- NgayGhi - datetime
          10 , -- CSD - int
          20 , -- CSC - int
          11000.0  -- DonGia - float
        )
INSERT INTO dbo.HOADON
        ( MaPhong, NgayGhi, MaNV )
VALUES  ( 
          N'C1.101', -- MaPhong - nchar(15)
          '20191020', -- NgayGhi - datetime
          N'QL01'  -- MaNV - nchar(15)
          ),
		  ( 
          N'C1.102', -- MaPhong - nchar(15)
          '20191020', -- NgayGhi - datetime
          N'QL01'  -- MaNV - nchar(15)
          ),
		  ( 
          N'C1.103', -- MaPhong - nchar(15)
          '20191020', -- NgayGhi - datetime
          N'QL01'  -- MaNV - nchar(15)
          )
