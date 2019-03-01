CREATE DATABASE QuanLyCoffee
GO

USE QuanLyCoffee
GO

CREATE TABLE thucdon(
	Ten NVARCHAR(100) PRIMARY KEY NOT NULL,
	DVT NVARCHAR(10) NOT NULL,
	DonGia DECIMAL NOT NULL,
	idLoai INT NOT NULL
)
GO

CREATE TABLE Loai(
	id INT PRIMARY KEY NOT NULL,
	Ten NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE BanAn(
	idBan INT PRIMARY KEY NOT NULL,
	TenBan NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE HoaDon(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	NgayXuat DATETIME NOT NULL,
	TenBan NVARCHAR(100) NOT NULL,
	GiamGia DECIMAL NOT NULL,
	ThanhTien DECIMAL NOT NULL
)
GO

CREATE TABLE ChiTietHoaDon(
	id INT IDENTITY PRIMARY KEY NOT NULL,
	idHoaDon INT NOT NULL,
	TenMon NVARCHAR(100) NOT NULL,
	SoLuong INT NOT NULL,
	DonGia DECIMAL NOT NULL
)
GO

CREATE TABLE account(
	TK VARCHAR(100) PRIMARY KEY NOT NULL,
	MK VARCHAR(100) NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	TruyCap INT NOT NULL
)
GO


------------------------------------------------------------
ALTER TABLE dbo.thucdon ADD FOREIGN KEY(idLoai) REFERENCES dbo.Loai(id)
ALTER TABLE dbo.ChiTietHoaDon ADD FOREIGN KEY(idHoaDon) REFERENCES dbo.HoaDon(id)


------------------------------------------------------------
INSERT dbo.Loai(id,Ten) VALUES(110,N'Tất cả')
INSERT dbo.Loai(id,Ten) VALUES(111,N'Cà phê')
INSERT dbo.Loai(id,Ten) VALUES(112,N'Trà')
INSERT dbo.Loai(id,Ten) VALUES(113,N'Chocolate')
INSERT dbo.Loai(id,Ten) VALUES(114,N'Đồ uống đóng chai')
INSERT dbo.Loai(id,Ten) VALUES(115,N'Thức ăn')
INSERT dbo.Loai(id,Ten) VALUES(116,N'Trái cây')



INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'Cà phê đen',N'ly',10000,111)
INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'Cà phê sữa',N'ly',10000,111)
INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'Cà phê dừa',N'ly',18000,111)
INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'Trà đào',N'ly',15000,112)
INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'Trà bí đao',N'ly',15000,112)
INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'Oreo đá xay',N'ly',28000,113)
INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'Chocolate đá xay',N'ly',25000,113)
INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'Bò húc',N'lon',12000,114)
INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'C2',N'chai',8000,114)
INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'Mì trứng',N'dĩa',20000,115)
INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'Mì Spagetti',N'dĩa',30000,115)
INSERT dbo.thucdon(Ten,DVT,DonGia,idLoai) VALUES(N'Dừa xiêm',N'trái',18000,116)



DECLARE @i INT=0
WHILE @i<10
BEGIN
	INSERT dbo.BanAn(idBan,TenBan) VALUES(@i,N'Bàn '+CAST(@i+1 AS NVARCHAR(10)))
	SET @i=@i+1
END



INSERT dbo.account(TK,MK,FullName,TruyCap) VALUES('admin','123456',N'Nguyễn Phan Tấn Ngọc',1)
INSERT dbo.account(TK,MK,FullName,TruyCap) VALUES('nhanvien','123456',N'Nguyễn Vương Hoàng Mai',2)