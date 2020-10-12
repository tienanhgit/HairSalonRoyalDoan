﻿create database HairSalonRoyalDoan
go
use HairSalonRoyalDoan





 


/*chuan*/
go
create table NhanVien
(
MaNV int Identity primary key,
HoTenNV nvarchar(50),
Email nvarchar(50),
MatKhau nvarchar(255),
SoDTNV int,
QueQuan nvarchar(50),
CMND int,
NgaySinh datetime,
Hinhthuclam nvarchar(50),
ChucVu nvarchar(50),/*Co 2 loai chuc vu : Nhan vien quan ly, Nhan vien quay*/
NgayTao datetime,
NgaySua datetime
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
TrangThaiDonSanPham int ,/*1 chờ xác nhận , 2 xác nhận ,3 thành công */
TrangThaiDonDichVu int,/*1 chờ xác nhận , 2 xác nhận ,3 thành công */
HoTenNguoiNhan nvarchar(50),
DiaChiNhanHang nvarchar(50),
NgayTao datetime,
NgaySua datetime
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
MaNV int,
NgayDat datetime ,
GioDat datetime ,
Primary key(MaDonDatHang,MaDV)
);

go

create table SanPham
(
MaSanPham int not null identity primary key,
MaDanhMuc int,
MaThuongHieu int,
TenSanPham nvarchar(50),
Gia float,
HinhAnh nvarchar(255),
MoTa ntext ,
DanhGia ntext,
NgayTao datetime,
NgaySua datetime
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
NgayTao datetime,
NgaySua datetime
)
go


go
create table Chitietdichvu
(
MaCTDV int not null identity primary key,
MaDV int ,
Buoc ntext,
ChiTietBuoc ntext
)
;
go
create table ThuongHieu
(
MaThuongHieu int not null identity primary key, 
TenThuongHieu nvarchar(255),
NgayTao datetime,
NgaySua datetime
);
go
create table BaiViet
(
MaBaiViet int not null identity primary key,
MaNV int,
TenBaiViet nvarchar(255),
NoiDung ntext,
NgayTao datetime,
NgaySua datetime

);
go
create table Banner
(
MaBanner int not null identity primary key,
MaNV int,
AnhBanner nvarchar(255),
ViTri int,
NgayTao datetime,
NgaySua datetime
)
go

/*Lien ket*/
alter table SanPham
add constraint FK_SanPham_ThuongHieu
foreign key (MaThuongHieu)
references ThuongHieu(MaThuongHieu)
go
alter table BaiViet
add constraint FK_NhanVien_BaiViet
foreign key(MaNV)
references NhanVien(MaNV)

go
alter table Banner
add constraint FK_NhanVien_Banner
foreign key(MaNV)
references NhanVien(MaNV) 
go
alter table ChiTietDichVu
add constraint FK_ChiTietDichVu_DichVu
foreign key(MaDV)
references DichVu(MaDV)
go


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
add constraint FK_ChitietDonDichVu_NhanVien
foreign key (MaNV)
references NhanVien(MaNV)


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
/*Thêm sản phẩm */
create Proc Proc_SanPham_Insert @MaDanhMuc int,
							@TenSanPham DATETIME, 
							@Gia float, 
							@HinhAnh NVARCHAR(255), 
							@MoTa ntext, 
							@DanhGia ntext,
							@NgayTao DateTime,
							@NgaySua datetime
						
AS BEGIN 
	INSERT INTO dbo.SanPham
	        ( MaDanhMuc ,
	          TenSanPham ,
	          Gia ,
	          HinhAnh ,
			  MoTa,
	          DanhGia ,
			  NgayTao,
			  NgaySua    
	        )
	VALUES  ( @MaDanhMuc , 
	          @TenSanPham , 
	          @Gia , 
	          @HinhAnh , 
	          @MoTa, 
			  @DanhGia,
			  @NgayTao,
			  @NgaySua
	        )
END;
Go

/*Sửa sản phẩm*/
create Proc Proc_SanPham_Update @MaSanPham int, 
							@MaDanhMuc int, 
							@TenSanPham nvarchar(50), 
							@Gia FLOAT, 
							@HinhAnh NVARCHAR(255), 
							@MoTa ntext, 
							@DanhGia ntext ,
							@NgayTao DateTime,
							@NgaySua datetime

							
AS BEGIN 
	UPDATE SanPham SET		MaDanhMuc = @MaDanhMuc,
							TenSanPham = @TenSanPham,
							HinhAnh = @HinhAnh,
							MoTa = @MoTa,
							DanhGia = @DanhGia,
							NgayTao=@NgayTao,
							NgaySua=@NgaySua
							
	WHERE MaSanPham = @MaSanPham
END

GO

/* Get data Sản Phẩm */
create Procedure Proc_SanPham_GetData 
							@MaSanPham INT = '',
							@MaDanhMuc INT='',
							@TenSanPham NVARCHAR(255)='',  
							@Gia FLOAT = ''
						
							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from SanPham where (1=1) '
	IF(@MaSanPham !='')
	begin
		SET @Query += ' AND (MaSanPham = @MaSanPham) '
		end
		if(@MaDanhMuc!='')
		begin
		set @Query += ' AND (MaDanhMuc = @MaDanhMuc) '
		end
	IF(@TenSanPham != '')
		BEGIN
			SET @TenSanPham = '%'+@TenSanPham+'%'
			SET @Query += ' AND (TenSanPham like @TenSanPham) '
		END
		
	IF (@Gia != '')
	begin
		SET @Query += ' AND (Gia = @Gia) '
	end
	SET @ParamList =		'@MaSanPham int,
								@MaDanhMuc int,
								@TenSanPham NVARCHAR(255),
								@Gia FLOAT  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaSanPham,@MaDanhMuc,@TenSanPham,@Gia
END
exec Proc_SanPham_GetData  null

					
go


/*Bảng nhân viên*/

/*Thêm Nhan Vien */
create Proc Proc_NhanVien_Insert @HoTenNV nvarchar(50),
								@Email nvarchar(50)='',
								@MatKhau nvarchar(255)='',
								@SoDTNV INT='',
								@QueQuan nvarchar(50)='',
								@CMND int='',
								@NgaySinh datetime='',
								@HinhThucLam nvarchar(50)='',
								@ChucVu nvarchar(50)='',
								@NgayTao datetime='',
								@NgaySua datetime=''

						
AS BEGIN 
	INSERT INTO NhanVien
	        (				HoTenNV ,
								Email,
								MatKhau ,
								SoDTNV ,
								QueQuan ,
								CMND ,
								NgaySinh ,
								HinhThucLam ,
								ChucVu ,
								NgayTao ,
								NgaySua 
	        )
	VALUES  (					@HoTenNV ,
								@Email ,
								@MatKhau ,
								@SoDTNV ,
								@QueQuan ,
								@CMND ,
								@NgaySinh ,
								@HinhThucLam ,
								@ChucVu ,
								@NgayTao ,
								@NgaySua 

	        )
END;


Go

/*Sửa Nhan Vien*/
create Proc Proc_NhanVien_Update @MaNV int,
								@HoTenNV nvarchar(50),
								@Email nvarchar(50),
								@MatKhau nvarchar(255),
								@SoDTNV INT,
								@QueQuan nvarchar(50),
								@CMND int,
								@NgaySinh datetime,
								@HinhThucLam nvarchar(50),
								@ChucVu nvarchar(50),
								@NgayTao datetime,
								@NgaySua datetime

							
AS BEGIN 
	UPDATE NhanVien SET		HoTenNV=@HoTenNV ,
								Email=@Email,
								MatKhau=@MatKhau ,
								SoDTNV=@SoDTNV ,
								QueQuan=@QueQuan ,
								CMND=@CMND ,
								NgaySinh =@NgaySinh,
								HinhThucLam=@HinhThucLam ,
								ChucVu=@ChucVu ,
								NgayTao=@NgayTao ,
								NgaySua=@NgaySua 
							
	WHERE MaNV = @MaNV
END

GO

/* Get data Nhan Vien */
create Procedure Proc_NhanVien_GetData 
								@MaNV int ='' ,
								@HoTenNV nvarchar(50)='',
								@Email nvarchar(50)='',
								@MatKhau nvarchar(255)='',
								@SoDTNV INT='',
								@QueQuan nvarchar(50)='',
								@CMND int='',
								@NgaySinh datetime='',
								@HinhThucLam nvarchar(50)='',
								@ChucVu nvarchar(50)='',
								@NgayTao datetime='',
								@NgaySua datetime=''
							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from NhanVien where (1=1) '
	
	SET @ParamList =		'@MaNV int
								
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaNV
END
go
/*Bang dich vu*/
/*Thêm Dich vu */

create Proc Proc_Dichvu_Insert @TenDV nvarchar(50),
								@Gia nvarchar(50)='',
								@HoatDong nvarchar(255)='',					
								@NgayTao datetime='',
								@NgaySua datetime=''
						
AS BEGIN 
	INSERT INTO DichVu
	        (					TenDV ,
								Gia,
								HoatDong ,			
								NgayTao ,
								NgaySua 
	        )
	VALUES  (					 @TenDV ,
								@Gia,
								@HoatDong,					
								@NgayTao,
								@NgaySua							

	        )
END;

Go

create Proc Proc_DichVu_Update @MaDV int,
								@TenDV nvarchar(50),
								@Gia nvarchar(50)='',
								@HoatDong nvarchar(255)='',											
								@NgaySua datetime=''
							

							
AS BEGIN 
	UPDATE DichVu SET TenDV=@TenDV,
	Gia=@Gia,
	HoatDong=@HoatDong,

	NgaySua=@NgaySua	
							
	WHERE MaDV = @MaDV
END

GO

create Procedure Proc_DichVu_GetData 						
AS BEGIN
select * from DichVu where 1=1
END

go


/*Proc login*/
Create Proc Proc_NhanVien_DangNhap
 @Email NVARCHAR(50), 
 @MatKhau NVARCHAR(255)
AS
BEGIN
	SELECT MaNV  FROM NhanVien WHERE Email = @Email AND MatKhau = @MatKhau
END;


/*Them du lieu demo*/
insert into NhanVien 
values (N'Đoàn Minh Ngọc','ngocdoan@gmail.com','123456','0902087097',N'Hải Dương',142987653,'09/02/1978','Fulltime','Chủ cửa hàng','10/7/2020','10/7/2020')

insert into ThuongHieu
values ('L’Oréal','','')

select * from ThuongHieu



/*Bang thuong hiệu*/

create proc Proc_ThuongHieu_Get
as
begin 

select * from ThuongHieu

end

/*Bang danh muc*/

create proc Proc_DanhMuc_Get
as
begin 

select * from DanhMuc

end














