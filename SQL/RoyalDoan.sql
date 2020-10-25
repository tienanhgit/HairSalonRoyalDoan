
create database HairSalonRoyalDoan
go
use HairSalonRoyalDoan


/*chuan*/

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
ChucVu int,/*Co 2 loai chuc vu : 1 :Admin , 2 :User*/
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
/*Bang San Pham*/
go
create Proc Proc_SanPham_Insert @MaDanhMuc int ='',
								@MaThuongHieu int='',
							   @TenSanPham nvarchar(50)='', 
							   @Gia float='', 
							  @HinhAnh NVARCHAR(255)='', 
							  @MoTa ntext='', 
							  @DanhGia ntext='',
							  @NgayTao DateTime=''
					
						
AS BEGIN 
	INSERT INTO dbo.SanPham
	        ( MaDanhMuc ,
			MaThuongHieu,
	          TenSanPham ,
	          Gia ,
	          HinhAnh ,
			  MoTa,
	          DanhGia ,
			  NgayTao
			  
	        )
	VALUES  ( @MaDanhMuc , 
				@MaThuongHieu,
	          @TenSanPham , 
	          @Gia , 
	          @HinhAnh , 
	          @MoTa, 
			  @DanhGia,
			  @NgayTao
		
	        )
END;
Go


create Proc Proc_SanPham_Update 
							@MaSanPham int, 
							@MaDanhMuc int='', 
							@TenSanPham nvarchar(50)='', 
							@Gia FLOAT='', 
							@HinhAnh NVARCHAR(255)='', 
							@MoTa ntext='', 
							@DanhGia ntext='' ,						
							@NgaySua datetime=''

							
AS BEGIN 
	UPDATE SanPham SET		MaDanhMuc = @MaDanhMuc,
							TenSanPham = @TenSanPham,
							HinhAnh = @HinhAnh,
							MoTa = @MoTa,
							DanhGia = @DanhGia,
							
							NgaySua=@NgaySua
							
	WHERE MaSanPham = @MaSanPham
END

GO

create Procedure Proc_SanPham_GetData 
							@MaSanPham INT = '',
							@MaDanhMuc INT='',
							@TenSanPham NVARCHAR(255)='',  
							@Gia FLOAT = ''
						
							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from SanPham where (1=1)'
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
	set @query +='order by MaSanPham';
	SET @ParamList =		'@MaSanPham int,
								@MaDanhMuc int,
								@TenSanPham NVARCHAR(255),
								@Gia FLOAT  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaSanPham,@MaDanhMuc,@TenSanPham,@Gia
END
exec Proc_SanPham_GetData  null

					
go
/*End*/

/*Bảng nhân viên*/
/*Proc login*/
Create Proc Proc_NhanVien_DangNhap
 @Email NVARCHAR(50), 
 @MatKhau NVARCHAR(255)
AS
BEGIN
	SELECT MaNV  FROM NhanVien WHERE Email = @Email AND MatKhau = @MatKhau
END;
go

/*END*/

create proc Nhanvien_GetChucVu @Email nvarchar(50)=''
as 
begin
select NhanVien.ChucVu from NhanVien where NhanVien.Email=@Email

end

go

create Proc Proc_NhanVien_Insert @HoTenNV nvarchar(50),
								@Email nvarchar(50)='',
								@MatKhau nvarchar(255)='',
								@SoDTNV INT='',
								@QueQuan nvarchar(50)='',
								@CMND int='',
								@NgaySinh datetime='',
								@HinhThucLam nvarchar(50)='',
								@ChucVu nvarchar(50)='',
								@NgayTao datetime=''
						

						
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
								NgayTao 
								
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
								@NgayTao 
							

	        )
				Select scope_identity()
END;


Go
----Trả ra 0: Thì thêm. Trả ra >0: Trùng -> k thêm
create  PROC Proc_NhanVien_CheckTK  @Email NVARCHAR(50)=''
AS 
BEGIN
	SELECT Count (MaNV) FROM NhanVien WHERE Email = @Email
END
go

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
								
								NgaySua=@NgaySua 
							
	WHERE MaNV = @MaNV
END

go

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
/*End*/

/*Bang dich vu*/

create Proc Proc_Dichvu_Insert @TenDV nvarchar(50),
								@Gia nvarchar(50)='',
								@HoatDong nvarchar(255)='',					
								@NgayTao datetime=''
						
						
AS BEGIN 
	INSERT INTO DichVu
	        (					TenDV ,
								Gia,
								HoatDong ,			
								NgayTao 
							
	        )
	VALUES  (					 @TenDV ,
								@Gia,
								@HoatDong,					
								@NgayTao
													
	        )
			Select scope_identity()
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
/*END*/


/*Bang thuong hiệu*/

create proc Proc_ThuongHieu_GetData
							@MaThuongHieu INT = '',
							@TenThuongHieu nvarchar(50)=''
						
						
					
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from ThuongHieu where (1=1)'
	IF(@MaThuongHieu !='')
	begin	
		set @Query += ' AND (MaThuongHieu = @MaThuongHieu) '
		end
	IF(@TenThuongHieu != '')
		BEGIN
			SET @TenThuongHieu = '%'+@TenThuongHieu+'%'
			SET @Query += ' AND (TenThuongHieu like @TenThuongHieu) '
		END	
	set @query +='order by MaThuongHieu';
	SET @ParamList =		'
							@MaThuongHieu int,
								@TenThuongHieu NVARCHAR(50)
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaThuongHieu,@TenThuongHieu
END

go

create Proc Proc_ThuongHieu_Insert @TenThuongHieu nvarchar(255),
@NgayTao datetime
						
AS BEGIN 
	INSERT INTO ThuongHieu
	        (				TenThuongHieu,
							 NgayTao
	        )
	VALUES  (					@TenThuongHieu,
									@NgayTao
	        )
END;


Go

create Proc Proc_ThuongHieu_Update 
@MaThuongHieu int,
@TenThuongHieu nvarchar(255),
@NgaySua datetime						
AS BEGIN 
	UPDATE ThuongHieu SET TenThuongHieu=@TenThuongHieu,
	NgaySua=@NgaySua		
							
	WHERE MaThuongHieu = @MaThuongHieu
END
GO
/*End*/

/*Bang danh muc*/
create proc Proc_DanhMuc_GetData
							@MaDanhMuc INT = '',
							@TenDanhMuc nvarchar(50)=''
						
						
							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from DanhMuc where (1=1)'
	IF(@MaDanhMuc !='')
	begin	
		set @Query += ' AND (MaDanhMuc = @MaDanhMuc) '
		end
	IF(@TenDanhMuc != '')
		BEGIN
			SET @TenDanhMuc = '%'+@TenDanhMuc+'%'
			SET @Query += ' AND (TenDanhMuc like @TenDanhMuc) '
		END	
	set @query +='order by MaDanhMuc';
	SET @ParamList =		'
							@MaDanhMuc int,
								@TenDanhMuc NVARCHAR(50)
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaDanhMuc,@TenDanhMuc
END

go

/*End*/




/*Bang Bai Viet*/
create proc Proc_BaiViet_Get
as
begin 
select * from BaiViet
end
go

create Proc Proc_BaiViet_Insert 
@MaNV int,
@TenBaiViet nvarchar(255),
@NoiDung ntext,
@NgayTao datetime
						
AS BEGIN 
	INSERT INTO BaiViet
	        (	
			MaNV,
			TenBaiViet,
			NoiDung,
							 NgayTao
	        )
	VALUES  (					@MaNV,
							 @TenBaiViet,
							 @NoiDung,
							 @NgayTao
	        )
END;


Go

create Proc Proc_BaiViet_Update 
@MaBaiViet int,
	@MaNV int,
@TenBaiViet nvarchar(255),
@NoiDung ntext,
@NgayTao datetime				
AS BEGIN 
	UPDATE BaiViet SET 
	MaNV=@MaNV,
	TenBaiViet=@TenBaiViet,
	NoiDung=@NoiDung,
	NgayTao=@NgayTao
	
							
	WHERE MaBaiViet = @MaBaiViet
END
GO


/*Bang Luong*/


/*Bang khach hang*/
 
create proc Proc_KhachHang_CheckTk @SDT int
as
begin
select COUNT(MaKH) from KhachHang where KhachHang.SoDTKH=@SDT
end
go


create Proc Proc_KhachHang_Insert
 @HoTenKH nvarchar(50)='',
@SoDTKH nvarchar(50)='',
@Email nvarchar(50)='',
@DiaChi ntext='',
@MatKhau nvarchar(50)=''
						
AS BEGIN 
	INSERT INTO KhachHang
	        (
			HoTenKH,
			SoDTKH,
			Email,
			DiaChi,
			MatKhau						
	        )
	VALUES  (
	@HoTenKH,
	@SoDTKH,
	@Email,
	@DiaChi,
	@MatKhau
							        )
END;


Go

create Proc Proc_KhachHang_Update @MaKH int,
	 @HoTenKH nvarchar(50),
	@Email nvarchar(50),
	@DiaChi ntext,
	@MatKhau nvarchar(50)
							
AS BEGIN 
	UPDATE KhachHang SET 
	HoTenKH=@HoTenKH,
	Email=@Email,
	DiaChi=@DiaChi,
	MatKhau=MatKhau		
							
	WHERE MaKH = @MaKH
END

go


create   proc Proc_KhachHang_GetData
@MaKH int='',
@HoTenKH int='',
@SoDTKH nvarchar(50)='',
@Email nvarchar(50)='',
@DiaChi ntext='',
@MatKhau nvarchar(50)=''
								
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from KhachHang where (1=1) '
	
	IF(@MaKH !='')
	begin	
		set @Query += ' AND (MaKH=@MaKH) '
		end
	

	IF(@SoDTKH !='')
	begin	
		set @Query += ' AND (SoDTKH = @SoDTKH) '
		end
	

	SET @ParamList =		'@MaKH int,
					@HoTenKH nvarchar(50),
								@SoDTKH int	
													
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaKH,@HoTenKH,@SoDTKH
END
go
Create Proc Proc_KhachHang_DangNhap
 @SDTKH NVARCHAR(50), 
 @MatKhau NVARCHAR(255)
AS
BEGIN
	SELECT MaKH  FROM KhachHang WHERE  SoDTKH= @SDTKH AND MatKhau = @MatKhau
END;
go

/*end*/

/*Bang Đơn đặt hàng*/
go

create proc Proc_DonDatHang_Insert
 @MaNV int =null,
 @MaKH int=null,
 @SoDTGiaoHang int='',
 @HinhThucTT nvarchar(50)='',
 @TrangThaiDonSanPham int='',
 @TrangThaiDonDichVu int='',
 @HoTenNguoiNhan nvarchar(50)='',
 @DiaChiNhanHang nvarchar(50)='',
 @NgayTao datetime=''						
AS BEGIN 
IF(@MaNV ='')
	begin
		SET @MaNV=NULL
		end
		IF(@MaKH ='')
	begin
		SET @MaKH=NULL
		end
			IF(@MaKH ='')
	begin
		SET @MaKH=NULL
		end

	INSERT INTO DonDatHang
	        ( MaNV,
			MaKH,
			SoDTGiaoHang,
			HinhThucTT,
			TrangThaiDonSanPham,
			TrangThaiDonDichVu,
			HoTenNguoiNhan,
			DiaChiNhanHang,
			NgayTao				  
	        )
	VALUES  ( 
	 @MaNV ,
 @MaKH ,
 @SoDTGiaoHang ,
 @HinhThucTT ,
 @TrangThaiDonSanPham ,
 @TrangThaiDonDichVu ,
 @HoTenNguoiNhan ,
 @DiaChiNhanHang ,
 @NgayTao 
 )
Select scope_identity()
END
Go


create Proc Proc_DonDatHang_Update 
	@MaDonDatHang int='',
	@MaNV int ='',
 @MaKH int='',
 @SoDTGiaoHang int='',
 @HinhThucTT nvarchar(50)='',
 @TrangThaiDonSanPham int='',
 @TrangThaiDonDichVu int='',
 @HoTenNguoiNhan nvarchar(50)='',
 @DiaChiNhanHang nvarchar(50)='',
 @NgayTao datetime=''

							
AS BEGIN 
	UPDATE DonDatHang SET
			 MaNV=@MaNV,
			MaKH=@MaKH,
			SoDTGiaoHang=@SoDTGiaoHang,
			HinhThucTT=@HinhThucTT,
			TrangThaiDonSanPham=@TrangThaiDonSanPham,
			TrangThaiDonDichVu=@TrangThaiDonDichVu,
			HoTenNguoiNhan=@HoTenNguoiNhan,
			DiaChiNhanHang=@DiaChiNhanHang,
			NgayTao=@NgayTao		
	WHERE MaDonDatHang = @MaDonDatHang
	Select scope_identity()

END

GO

create Procedure Proc_DonDatHang_GetData 
@MaDonDatHang int='',
@MaNV int ='',
 @MaKH int='',
 @SoDTGiaoHang int='',
 @HinhThucTT nvarchar(50)='',
 @TrangThaiDonSanPham int='',
 @TrangThaiDonDichVu int='',
 @HoTenNguoiNhan nvarchar(50)='',
 @DiaChiNhanHang nvarchar(50)='',
 @NgayTao datetime='',
 @NgaySua datetime=''
						
							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from DonDatHang where (1=1)'
	IF(@MaDonDatHang !='')
	begin
		SET @Query += ' AND (MaDonDatHang = @MaDonDatHang) '
		end

	SET @ParamList =		'@MaDonDatHang int
							  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaDonDatHang
END
				
go
/*End*/


/*Bang Chi Tiet Don Dat*/
go
create Proc Proc_ChiTietDonDat_Insert
@MaDonDatHang int='',
@MaSanPham int='',
@Soluong int=''					
AS BEGIN 
	INSERT INTO ChiTietDonDat
	        (			
			MaDonDatHang,
			MaSanPham,
			Soluong					  
	        )
	VALUES  ( 
@MaDonDatHang,
@MaSanPham,
@Soluong
	        )
Select scope_identity()
END;
Go




GO

create Procedure Proc_ChiTietDonDat_GetData 
@MaDonDatHang int=''							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from ChiTietDonDat where (1=1)'
	IF(@MaDonDatHang!='')
	begin
		SET @Query += ' AND (M = @MaDonDatHang) '
		end

	SET @ParamList =		'@MaDonDatHang int
							  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaDonDatHang
END
				
go
/*End*/





/*Them du lieu demo*/
insert into NhanVien 
values (N'Đoàn Minh Ngọc','ngocdoan@gmail.com','123456','0902087097',N'Hải Dương',142987653,'09/02/1978','Fulltime',1,'10/7/2020','10/7/2020')
go
insert into ThuongHieu
values ('Enchenter','','')
go


























