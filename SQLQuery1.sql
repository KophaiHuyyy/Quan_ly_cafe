CREATE DATABASE caphe;
GO

USE caphe;
GO

CREATE TABLE nguoidung (
    id_nguoidung INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255),
    sdt VARCHAR(20),
    email VARCHAR(250),
    password VARCHAR(50)
);

CREATE TABLE sanpham (
    id_sanpham INT PRIMARY KEY IDENTITY(1,1),
	ma_sp VARCHAR(50) ,
    id_nguoidung INT,
    tensp NVARCHAR(255),
    sl_sp INT,
    gia_sp DECIMAL(10, 2),
    phanloai NVARCHAR(50),
    FOREIGN KEY (id_nguoidung) REFERENCES nguoidung(id_nguoidung)
);

CREATE TABLE khachhang (
    id_khachhang INT PRIMARY KEY IDENTITY(1,1),
	ma_khachhang VARCHAR(50) ,
    ten_khachhang NVARCHAR(100),
    sdt VARCHAR(20),
    email VARCHAR(255),
    diachi NVARCHAR(255)
);

CREATE TABLE ban (
id_ban INT PRIMARY KEY IDENTITY(1,1),
name NVARCHAR(50),
status NVARCHAR(100)NOT NULL DEFAULT N'Trống'
);

CREATE TABLE hoadon (
    id_hoadon INT PRIMARY KEY IDENTITY(1,1),
	ma_hoadon VARCHAR(50) ,
    id_khachhang INT,
	id_ban int ,
	id_sanpham int  , 
    ngaymua DATETIME,
	so_luong int , 
    tongtien_hoadon DECIMAL(10, 2),
    FOREIGN KEY (id_khachhang) REFERENCES khachhang(id_khachhang) , 
	FOREIGN KEY (id_ban) REFERENCES ban(id_ban),
	FOREIGN KEY (id_sanpham) REFERENCES sanpham(id_sanpham)
);
CREATE TABLE chi_tiet_hoa_don (
    id_chi_tiet INT PRIMARY KEY IDENTITY(1,1),
    id_hoa_don INT,
    id_sanpham INT,
    so_luong INT,
    gia_ban DECIMAL(10, 2),
    FOREIGN KEY (id_hoa_don) REFERENCES hoadon(id_hoadon),
    FOREIGN KEY (id_sanpham) REFERENCES sanpham(id_sanpham)
);


DECLARE @i INT =1 WHILE @i<=12
BEGIN
     INSERT ban (name)VALUES ( N'Bàn ' + CAST(@i AS nvarchar(50)))
	 SET @i = @i + 1
END

GO
CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.ban
GO

EXEC dbo.USP_GetTableList