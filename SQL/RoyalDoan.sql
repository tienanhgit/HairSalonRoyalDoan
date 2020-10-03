create database HairSalonRoyalDoan
go
use HairSalonRoyalDoan




go
create table NhanVien
(
MaNV int Identity primary key,
HoTenNV nvarchar(50),
Email nvarchar(50),
SoDTNV int,
QueQuan nvarchar(50),
CMND int,
NgaySinh datetime,
Hinhthuclam nvarchar(50),
ChucVu nvarchar(50),/*Co 2 loai chuc vu : Nhan vien quan ly, Nhan vien quay*/
);
go
create table Luong
(
MaLuong int not null Identity primary key,
MaNV int not null,
LuongCoBanTrenCa float,
ThoiGianTinh datetime,
SoCaLam int,
)
go
create table KhachHang
(
MaKH int not null identity primary key,
HoTenKH nvarchar(50),
SoDTKH int not null,
Email nvarchar(50),
DiaChi ntext,
MatKhau nvarchar(50),
);

go

create table DonDatHang
(
MaDonDatHang int not null identity primary key,
MaNV int,
MaKH int,
SoDTGiaoHang int,
HinhThucTT nvarchar(50),
TrangThai nvarchar(50),
HoTenNguoiNhan nvarchar(50),
DiaChiNhanHang nvarchar(50),
ThoiGianLapDon datetime,
);
go


create table ChiTietDonDat
(
MaDonDatHang int not null ,
MaSanPham int not null ,
Soluong int 
Primary key (MaDonDatHang,MaSanPham)
);

create table ChiTietDonDichVu
(
MaDonDatHang int not null,
MaDV int not null,
NgayDat datetime ,
GioDat datetime ,
Primary key(MaDonDatHang,MaDV)
);

go

create table SanPham
(
MaSanPham int not null identity primary key,
MaDanhMuc int,
TenSanPham nvarchar(50),
Gia float,
HinhAnh nvarchar(255),
MoTa ntext ,
DanhGia ntext,
);

go
create table DanhMuc
(
MaDanhMuc int not null identity primary key,
TenDanhMuc nvarchar(50),
)


go
create table DichVu
(
MaDV int not null identity primary key,
TenDV ntext,
Gia float,
HoatDong ntext,
);
go
create table Chitietdichvu
(
MaCTDV int not null identity primary key,
MaDV int ,
Buoc ntext,
ChiTietBuoc ntext

)
;
/*Lien ket*/
go
alter table ChiTietDichVu
add constraint FK_ChiTietDichVu_DichVu
foreign key(MaDV)
references DichVu(MaDV)

alter table DonDatHang
add constraint FK_DonDatHang_KhachHang
foreign key (MaKH)
references KhachHang(MaKH)
go
alter table ChiTietDonDat
add constraint FK_ChiTietDonDat_DonDatHang
foreign key (MaDonDatHang)
references DonDatHang(MaDonDatHang)
go
alter table ChiTietDonDat
add constraint FK_ChiTietDonDat_SanPham
foreign key (MaSanPham)
references SanPham(MaSanPham)


go

alter table SanPham
add constraint FK_SanPham_DanhMuc
foreign key (MaDanhMuc)
references DanhMuc(MaDanhMuc)
go
alter table DonDatHang
add constraint FK_DonDatHang_NhanVien
foreign key (MaNV)
references NhanVien(MaNV)
go


alter table ChiTietDonDichVu
add constraint FK_ChiTietDonDichVu_DonDatHang
foreign key (MaDonDatHang)
references  DonDatHang(MaDonDatHang)


go 
alter table ChiTietDonDichVu
add constraint FK_DichVu_ChiTietDonDichVu
foreign key (MaDV)
references DichVu(MaDV)



go
alter table Luong
add constraint FK_Luong_NhanVien
foreign key (MaNV)
references NhanVien(MaNV)

go
insert into DanhMuc(TenDanhMuc)
values (N'Chăm sóc tóc'),
(N'Chăm sóc da'),
(N'Chăm sóc cơ thể'),
(N'Chăm sóc râu')
go
insert into SanPham(MaDanhMuc,TenSanPham,Gia,HinhAnh,MoTa,DanhGia)
values (2,N'Xịt dưỡng khóa biểu bì tóc',450000,'/Content/Images/ImagesProduct/dauduongtocdiva.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao'),
(2,N'Xịt dưỡng khóa biểu bì tóc 1',450000,'/Content/Images/ImagesProduct/dauduongtoctigi.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao'),
(3,N'Xịt dưỡng khóa biểu bì tóc2',460000,'/Content/Images/ImagesProduct/dauduongtoctigi.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao'),
(4,N'Xịt dưỡng khóa biểu bì tóc 3',440000,'/Content/Images/ImagesProduct/dauduongtocp&m.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao'),
(2,N'Xịt dưỡng khóa biểu bì tóc 4',450000,'/Content/Images/ImagesProduct/dauduongtocp&m.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao'),
(4,N'Xịt dưỡng khóa biểu bì tóc 5',435000,'/Content/Images/ImagesProduct/dauduongtocp&m.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao'),
(3,N'Xịt dưỡng khóa biểu bì tóc 6',250000,'/Content/Images/ImagesProduct/dauduongtocp&m.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao'),
(3,N'Xịt dưỡng khóa biểu bì tóc 7',150000,'/Content/Images/ImagesProduct/anhsanpham1.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao')


/*Reset identity*/
--DBCC CHECKIDENT ('SanPham', RESEED, 0)



/*Proceduce */
go
Create Proc Proc_SanPham_Insert @MaDanhMuc int,
							@TenSanPham DATETIME, 
							@Gia float, 
							@HinhAnh NVARCHAR(255), 
							@MoTa ntext, 
							@DanhGia ntext
						
AS BEGIN 
	INSERT INTO dbo.SanPham
	        ( MaDanhMuc ,
	          TenSanPham ,
	          Gia ,
	          HinhAnh ,
			  MoTa,
	          DanhGia     
	        )
	VALUES  ( @MaDanhMuc , 
	          @TenSanPham , 
	          @Gia , 
	          @HinhAnh , 
	          @MoTa, 
			  @DanhGia
			
	        )
	Select scope_identity()
END;
Go

Create Proc Proc_SanPham_Update @MaSanPham int, 
							@MaDanhMuc int, 
							@TenSanPham nvarchar(50), 
							@Gia FLOAT, 
							@HinhAnh NVARCHAR(255), 
							@MoTa ntext, 
							@DanhGia ntext 
							
AS BEGIN 
	UPDATE SanPham SET		MaDanhMuc = @MaDanhMuc,
							TenSanPham = @TenSanPham,
							HinhAnh = @HinhAnh,
							MoTa = @MoTa,
							DanhGia = @DanhGia
							
	WHERE MaSanPham = @MaSanPham
END

GO

Create Procedure Proc_SanPham_GetData 
							@MaSanPham INT = -1,
							@MaDanhMuc INT=-1, 
							@TenSanPham NVARCHAR(255)='' , 
							@Gia FLOAT = -1, 
							@HinhAnh NVARCHAR(255) = '', 
							@MoTa ntext = '', 
							@DanhGia ntext = ''
							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from SanPham where (1=1) '
	IF(@MaSanPham !=-1)
		SET @Query += ' AND (MaSanPham = @MaSanPham) '
	IF(@TenSanPham != '')
		BEGIN
			SET @TenSanPham = '%'+@TenSanPham+'%'
			SET @Query += ' AND (TenSanPham like @TenSanPham) '
		END
		
	IF (@Gia != '')
		SET @Query += ' AND (Gia = @Gia) '
	
	SET @ParamList =		'@MaSanPham int,
							@MaDanhMuc int , 
							@TenSanPham NVARCHAR(255) , 
							@Gia FLOAT , 
							@HinhAnh NVARCHAR(255) , 
							@MoTa ntext , 
							@DanhGia ntext '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaSanPham,@MaDanhMuc,@TenSanPham,@Gia,@HinhAnh,@MoTa,@DanhGia
END
go

create proc Proc_SanPham_GetData1
as 
begin
select * from SanPham
end



















