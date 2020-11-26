
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
SoDTNV varchar(20),
QueQuan nvarchar(50),
CMND varchar(25),
NgaySinh datetime,
Hinhthuclam nvarchar(50),
MaChucVu int,
TrangThaiHienThi int ,
NgayTao datetime,
NgaySua datetime
);
go

create table ChucVu
(
MaChucVu int identity primary key,
TenChucVu nvarchar(50)
)


go
create table KhachHang
(
MaKH int not null identity primary key,
HoTenKH nvarchar(50),
SoDTKH varchar(20) not null,
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
SoDTGiaoHang varchar(20),
HinhThucTT nvarchar(50),
TrangThaiDonSanPham int,/*1 chờ xác nhận , 2 xác nhận ,3 thành công */
TrangThaiDonDichVu int,/*1 chờ xác nhận , 2 xác nhận ,3 thành công */
HoTenNguoiNhan nvarchar(50),
DiaChiNhanHang nvarchar(50),
TongTien float,
NgayTao datetime
);
go
create table LichHen
(
MaLichHen int identity primary key not null,
MaKH int not null,
MaNV int ,
SDTHen varchar(20),
NgayHen date not null,
GioHen time not null,
TrangThai int
);


create table ChiTietDonDat
(
MaDonDatHang int not null ,
MaSanPham int not null ,
Gia float not null,
Soluong int not null 
Primary key (MaDonDatHang,MaSanPham)
);

create table ChiTietDonDichVu
(
MaDonDatHang int not null,
MaDV int not null,
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
TrangThaiHienThi int,
NgayTao datetime,
NgaySua datetime
);

go
create table DanhMuc
(
MaDanhMuc int not null identity primary key,
TenDanhMuc nvarchar(50),
TrangThaiHienThi int,
NgayTao datetime,
NgaySua datetime
)
go
create table DichVu
(
MaDV int not null identity primary key,
TenDV ntext,
Gia float,
TrangThaiHienThi int,
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
)
;
go
create table ThuongHieu
(
MaThuongHieu int not null identity primary key, 
TenThuongHieu nvarchar(255),
TrangThaiHienThi int,
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
TrangThaiHienThi int,
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
TrangThaiHienThi int,
NgayTao datetime,
NgaySua datetime
)
go

/*Lien ket*/
alter table NhanVien
add constraint FK_NhanVien_ChucVu
foreign key(MaChucVu)
references ChucVu(MaChucVu)
go
alter table LichHen
add constraint FK_NhanVien_lichHen
foreign key (MaNV)
references NhanVien(MaNV)
go
alter table LichHen
add constraint FK_KhachHang_LichHen
foreign key(MaKH)
references KhachHang(MaKH)

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
add constraint FK_ChiTietDonDichVu_DonDatHang
foreign key (MaDonDatHang)
references  DonDatHang(MaDonDatHang)


go 
alter table ChiTietDonDichVu
add constraint FK_DichVu_ChiTietDonDichVu
foreign key (MaDV)
references DichVu(MaDV)


go
/*Reset identity*/
--DBCC CHECKIDENT ('SanPham', RESEED, 0)
create proc TimKiemTheoNgay
@NgayDat datetime
as 
begin
select * 
from LichHen

end

go


/*Bang Lich Hen*/
-- Trang Thai 1 :Chưa xác nhận , trạng thái 2 : đã xác nhận, trạng thái 3 : hủy, trạng thái 4 :Đã đến

create proc LichHen_TimKiemTheoThoiGian
@NgayHen datetime=''
as
begin
select MaLichHen,LichHen.MaKH,LichHen.MaNV,NgayHen,GioHen,TrangThai,HoTenKH,HoTenNV,SoDTKH from LichHen left join KhachHang on LichHen.MaKh=KhachHang.MaKH 
	left join NhanVien on LichHen.MaNV=NhanVien.MaNV  where (1=1) and @NgayHen=NgayHen

end

go
create proc Proc_LichHen_UpdateTT
@MaLichHen int='',
@TrangThai int=''
as
begin
update LichHen
set TrangThai=@TrangThai
where MaLichHen=@MaLichHen
end
go



create Proc Proc_LichHen_Insert
@MaKH int=null,
@MaNV int=null,
@NgayHen date=null,
@GioHen time =null,
@TrangThai int =''										
AS BEGIN 
if(@MaNV=0 or @MaNV='')
begin
select @MaNV=null
end

	INSERT INTO LichHen
	        ( 
			MaKH,
			MaNV,
			NgayHen,
			GioHen,
			TrangThai			  
	        )
	VALUES  ( 
	@MaKH,
	@MaNV,
	@NgayHen,
	@GioHen,
	@TrangThai		
	        )
END;
Go



create Proc Proc_LichHen_Update 
@MaLichHen int=null,
@MaNV int=null,
@NgayHen date=null,
@GioHen time =null								
AS BEGIN 
if(@MaNV=0 or @MaNV='')
begin
select @MaNV=null
end

	UPDATE LichHen SET		
	MaNV=@MaNV,
	NgayHen=@NgayHen,
	GioHen=@GioHen					
	WHERE MaLichHen=@MaLichHen
END

GO

go



create  proc proc_LichHen_get_all
as
begin

select MaLichHen,LichHen.MaKH,LichHen.MaNV,NgayHen,GioHen,TrangThai,HoTenKH,HoTenNV,SoDTKH from LichHen join KhachHang on LichHen.MaKh=KhachHang.MaKH 
join NhanVien on LichHen.MaNV=NhanVien.MaNV  where TrangThai=2 and YEAR(NgayHen)=YEAR(GETDATE()) and MONTH(NgayHen)=MONTH(GETDATE()) and DAY(NgayHen)>=Day(GetDate())
 
end

go




create  Procedure Proc_LichHen_GetData 
							@MaLichHen INT = '',
							@MaKH INT='',
							@MaNV int='',  
							@NgayHen DateTime = '',
							@GioHen Datetime='',
							@TrangThai int=''
										
	AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'select MaLichHen,LichHen.MaKH,LichHen.MaNV,NgayHen,GioHen,TrangThai,HoTenKH,HoTenNV,SoDTKH from LichHen left join KhachHang on LichHen.MaKh=KhachHang.MaKH 
	left join NhanVien on LichHen.MaNV=NhanVien.MaNV  where (1=1) and YEAR(NgayHen)=YEAR(GETDATE()) and MONTH(NgayHen)=MONTH(GETDATE()) and DAY(NgayHen)>=Day(GetDate())'

	IF(@MaLichHen !='')
	begin
		SET @Query += ' AND (MaLichHen = @MaLichHen) '
		end
		if(@MaKH!='')
		begin
		set @Query += ' AND (LichHen.MaKH = @MaKH) '
		end
	IF(@MaNV != '')
		BEGIN
			set @Query += ' AND (MaNV = @MaNV) '
		END
		
	IF (@NgayHen != '')
	begin
		SET @Query += ' AND (NgayHen = @NgayHen) '
	
	end
		IF (@GioHen != '')
	begin
		SET @Query += ' AND (GioHen = @GioHen) '
	
	end
		IF (@TrangThai != '')
	begin
		SET @Query += ' AND (TrangThai=@TrangThai) Order by NgayHen '
	
	end
	
	SET @ParamList =		' @MaLichHen INT,
							@MaKH INT,
							@MaNV int,  
							@NgayHen DateTime ,
							@GioHen DateTime,
							@TrangThai int
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaLichHen,@MaKH,@MaNV,@NgayHen,@GioHen,@TrangThai
END


					
go
/*End*/



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
							  @TrangThaiHienThi int =1,
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
			  TrangThaiHienThi,
			  NgayTao
			  
	        )
	VALUES  ( @MaDanhMuc , 
			  @MaThuongHieu,
	          @TenSanPham , 
	          @Gia , 
	          @HinhAnh , 
	          @MoTa, 
			  @DanhGia,
			  @TrangThaiHienThi,
			  @NgayTao
		
	        )
END;
Go



create Proc Proc_SanPham_Update 
							@MaSanPham int, 
							@MaDanhMuc int='', 
							@MaThuongHieu int='',
							@TenSanPham nvarchar(50)='', 
							@Gia float='',					
							@HinhAnh NVARCHAR(255)='', 
							@MoTa ntext='', 
							@DanhGia ntext='' ,
							@TrangThaiHienThi int='',						
							@NgaySua datetime=''
					

							
AS BEGIN 
	UPDATE SanPham SET		MaDanhMuc = @MaDanhMuc,
							MaThuongHieu=@MaThuongHieu,
							TenSanPham = @TenSanPham,
							Gia=@Gia,
							HinhAnh = @HinhAnh,
							MoTa = @MoTa,
							DanhGia = @DanhGia,
							TrangThaiHienThi=@TrangThaiHienThi,		
							NgaySua=@NgaySua
						
							
	WHERE MaSanPham = @MaSanPham
END

GO




create Procedure Proc_SanPham_GetData 
							@MaSanPham INT = '',					
							@MaDanhMuc INT='',
							@MaThuongHieu int='',
							@TenSanPham NVARCHAR(255)='', 
							@TrangThaiHienThi int=2, 
							@Gia FLOAT = ''
						
							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from SanPham where 1=1'
	IF(@MaSanPham !='')
	begin
		SET @Query += ' AND (MaSanPham = @MaSanPham) '
		end
		if(@MaDanhMuc!='')
		begin
		set @Query += ' AND (MaDanhMuc = @MaDanhMuc) '
		end
			if(@MaThuongHieu!='')
		begin
		set @Query += ' AND (MaThuongHieu=@MaThuongHieu) '
		end
			if(@TrangThaiHienThi!=2)
		begin
		set @Query += ' AND (TrangThaiHienThi=@TrangThaiHienThi) '
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
	SET @ParamList =		'  @MaSanPham int,
								@MaDanhMuc int,
								@MaThuongHieu int,
								@TrangThaiHienThi int,
								@TenSanPham NVARCHAR(255),
								@Gia FLOAT  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaSanPham,@MaDanhMuc,@MaThuongHieu,@TrangThaiHienThi,@TenSanPham,@Gia
END


					
go
/*End*/
/*Bảng Chuc Vu*/

create proc Proc_ChucVu_GetData
						@MaChucVu INT = ''
							 
													
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from ChucVu where (1=1)'
	IF(@MaChucVu !='')
	begin
		SET @Query += ' AND (MaChucVu = @MaChucVu) '
		end

	SET @ParamList =		'@MaChucVu int
								  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaChucVu
END
/*End*/
go

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




create proc Nhanvien_GetChucVu @Email nvarchar(50)=''
as 
begin
select NhanVien.MaChucVu from NhanVien 
where NhanVien.Email=@Email

end

go


create Proc Proc_NhanVien_Insert @HoTenNV nvarchar(50),
								@Email nvarchar(50)='',
								@MatKhau nvarchar(255)='',
								@SoDTNV varchar(50),
								@QueQuan nvarchar(50)='',
								@CMND int='',
								@NgaySinh datetime='',
								@HinhThucLam nvarchar(50)='',
								@MaChucVu int='',
								@TrangThaiHienThi int='',
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
								MaChucVu ,
								TrangThaiHienThi,
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
								@MaChucVu ,
								@TrangThaiHienThi,
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
								@SoDTNV int,
								@QueQuan nvarchar(50),
								@CMND int,
								@NgaySinh datetime,
								@HinhThucLam nvarchar(50),
								@MaChucVu nvarchar(50),
								@TrangThaiHienThi int,		
								@NgaySua datetime

							
AS BEGIN 
	UPDATE NhanVien SET			HoTenNV=@HoTenNV ,
								Email=@Email,
								MatKhau=@MatKhau ,
								SoDTNV=@SoDTNV ,
								QueQuan=@QueQuan ,
								CMND=@CMND ,
								NgaySinh =@NgaySinh,
								HinhThucLam=@HinhThucLam ,
								MaChucVu=@MaChucVu ,
								TrangThaiHienThi=@TrangThaiHienThi,					
								NgaySua=@NgaySua 
							
	WHERE MaNV = @MaNV
END

go

create Procedure Proc_NhanVien_GetData 
								@MaNV int='',
								@HoTenNV nvarchar(50)='',
								@Email nvarchar(50)='',
								@MatKhau nvarchar(255)='',
								@SoDTNV INT='',
								@QueQuan nvarchar(50)='',
								@CMND int='',
								@NgaySinh datetime='',
								@HinhThucLam nvarchar(50)='',
								@MaChucVu nvarchar(50)='',
								@TrangThaiHienThi int='',
								@NgayTao datetime='',
								@NgaySua datetime=''
							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from NhanVien where (1=1) '
	IF(@MaNV!='')
	begin
		SET @Query += ' AND (MaNV= @MaNV) '
		end
		IF(@Email!='')
	begin
		SET @Query += ' AND (Email=@Email) '
		end
			IF(@TrangThaiHienThi!='')
	begin
		SET @Query += ' AND (TrangThaiHienThi= @TrangThaiHienThi) '
		end
		SET @ParamList =		'@MaNV int,
								@TrangThaiHienThi int,
								@Email nvarchar(50)						
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaNV,@TrangThaiHienThi,@Email
END
go
/*End*/


/*Bang Chi Tiet Don Dich Vu*/

create Proc Proc_ChiTietDonDichVu_Insert
@MaDonDatHang int='',
@MaDV int=''			
AS BEGIN 
	INSERT INTO ChiTietDonDichVu
	        (			
			MaDonDatHang,
			MaDV								  
	        )
	VALUES  ( 
	@MaDonDatHang,
	@MaDV
	        )
Select scope_identity()
END;
Go

create Procedure Proc_ChiTietDonDichVu_GetData 
@MaDonDatHang int='',
@MaDV int='',
@MaNV int='',
@NgayDat datetime='',
@GioDat int=''							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from ChiTietDonDichVu where (1=1)'
	IF(@MaDonDatHang!='')
	begin
		SET @Query += ' AND (MaChiTietDonDichVu= @MaDonDatHang) '
		end

	SET @ParamList =		'@MaDonDatHang int
							  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaDonDatHang
END
				
go
/*End*/



/*Bang chi tiet dich vu*/

create Proc Proc_ChiTietDichVu_Insert
								 @MaDV nvarchar(50),
								@Buoc nvarchar(50)='',
								@ChiTietBuoc nvarchar(255)=''				
																
AS BEGIN 
	INSERT INTO Chitietdichvu
	        (					
			MaDV,
			Buoc
		
								
	        )
	VALUES  (					@MaDV,
								@Buoc
							
													
	        )
			Select scope_identity()
END;

Go

create Proc Proc_ChiTietDichVu_Update 
@MaCTDV int='',
@MaDV nvarchar(50)='',
@Buoc nvarchar(50)=''
																				
AS BEGIN 
	UPDATE Chitietdichvu SET 
MaDV=@MaDV,
Buoc=@Buoc
						
	WHERE MaCTDV=@MaCTDV
END

GO

create Procedure Proc_ChiTietDichVu_GetData						
@MaDV int=''							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from ChiTietDichVu where (1=1)'
	IF(@MaDV!='')
	begin
		SET @Query += ' AND (MaDV = @MaDV) '
		end

	SET @ParamList =		'@MaDV int
							  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaDV
END
go

/*END*/


/*Bang dich vu*/
/*Lay data toan bo dich vu*/

create proc proc_GetData_DichVu_ChiTietDichVu

as
begin

select Dichvu.MaDV,TenDV,Gia,Buoc
 from DichVu join Chitietdichvu
on DichVu.MaDV=Chitietdichvu.MaDV




end

go

create Proc Proc_Dichvu_Insert @TenDV nvarchar(50),
								@Gia nvarchar(50)='',
								@TrangThaiHienThi int='',				
								@NgayTao datetime=''
						
						
AS BEGIN 
	INSERT INTO DichVu
	        (					TenDV ,
								Gia,
								TrangThaiHienThi,	
								NgayTao 
							
	        )
	VALUES  (					 @TenDV ,
								@Gia,
									@TrangThaiHienThi,				
								@NgayTao
													
	        )
			Select scope_identity()
END;

Go


create Proc Proc_DichVu_Update 
								@MaDV int='',
							
								@TrangThaiHienThi int='',											
								@NgaySua datetime=''
														
AS BEGIN 
	UPDATE DichVu SET 
	TrangThaiHienThi=@TrangThaiHienThi,
	NgaySua=@NgaySua							
	WHERE MaDV = @MaDV
END

GO


create Procedure Proc_DichVu_GetData 	
@MaDV int='',
@TrangThaiHienThi int=2					
AS 
BEGIN
DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from DichVu where (1=1)'
	IF(@MaDV!='')
	begin
		SET @Query += ' AND (MaDV = @MaDV) '
		end
			IF(@TrangThaiHienThi!=2)
		begin
		SET @Query += ' AND (TrangThaiHienThi = @TrangThaiHienThi) '
		end
	SET @ParamList =		'@MaDV int,
							@TrangThaiHienThi int
							  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaDV,@TrangThaiHienThi

END
go

/*END*/


/*Bang thuong hiệu*/


create proc Proc_ThuongHieu_GetData						
@MaThuongHieu INT = '',						
@TenThuongHieu nvarchar(50)='',
@TrangThaiHienThi int=2								
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from ThuongHieu where (1=1)'
	IF(@MaThuongHieu !='')
	begin	
		set @Query += ' AND (MaThuongHieu = @MaThuongHieu) '
		end
			IF(@TrangThaiHienThi !=2)
	begin	
		set @Query += ' AND (TrangThaiHienThi = @TrangThaiHienThi) '
		end
	IF(@TenThuongHieu != '')
		BEGIN
			SET @TenThuongHieu = '%'+@TenThuongHieu+'%'
			SET @Query += ' AND (TenThuongHieu like @TenThuongHieu) '
		END	
	
	set @query +='order by MaThuongHieu';
	SET @ParamList =		'
							@MaThuongHieu int,
								@TenThuongHieu NVARCHAR(50),
								@TrangThaiHienThi int
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaThuongHieu,@TenThuongHieu,@TrangThaiHienThi
END

go

create Proc Proc_ThuongHieu_Insert
 @TenThuongHieu nvarchar(255),
 @TrangThaiHienThi int ,
@NgayTao datetime
						
AS BEGIN 
	INSERT INTO ThuongHieu
	        (				TenThuongHieu,
			TrangThaiHienThi,
							 NgayTao
	        )
	VALUES  (					@TenThuongHieu,
							@TrangThaiHienThi,
									@NgayTao
	        )
END;


Go

create Proc Proc_ThuongHieu_Update 
@MaThuongHieu int,
@TenThuongHieu nvarchar(255),
@TrangThaiHienThi int,
@NgaySua datetime						
AS BEGIN 

	UPDATE ThuongHieu SET 
	TenThuongHieu=@TenThuongHieu,
	TrangThaiHienThi=@TrangThaiHienThi,
	NgaySua=@NgaySua		
							
	WHERE MaThuongHieu = @MaThuongHieu
END
GO
/*End*/


/*Bang danh muc*/
create proc Proc_DanhMuc_GetData
							@MaDanhMuc INT = '',
							@TenDanhMuc nvarchar(50)='',
							@TrangThaiHienThi int=2 ,
							@NgayTao datetime ='',
							@NgaySua datetime= ''
						
						
							
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
		IF(@TrangThaiHienThi !=2)
	begin	
		set @Query += ' AND (TrangThaiHienThi = @TrangThaiHienThi) '
		end

	set @query +='order by MaDanhMuc';
	SET @ParamList =		'
							@MaDanhMuc int,
								@TenDanhMuc NVARCHAR(50),
								@TrangThaiHienThi int
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaDanhMuc,@TenDanhMuc,@TrangThaiHienThi
END

go
create Proc Proc_DanhMuc_Insert
 @TenDanhMuc nvarchar(255),
 @TrangThaiHienThi int=0,
@NgayTao datetime
						
AS BEGIN 
	INSERT INTO DanhMuc
	        (				TenDanhMuc,
			TrangThaiHienThi,
							 NgayTao
	        )
	VALUES  (					@TenDanhMuc,
	@TrangThaiHienThi,
									@NgayTao
	        )
END;


Go

create Proc Proc_DanhMuc_Update 
@MaDanhMuc int,
@TenDanhMuc nvarchar(255),
@TrangThaiHienThi int,
@NgaySua datetime						
AS BEGIN 

	UPDATE DanhMuc SET
	 TenDanhMuc=@TenDanhMuc,
	 TrangThaiHienThi=@TrangThaiHienThi,
		NgaySua=@NgaySua		
							
	WHERE MaDanhMuc=@MaDanhMuc
END
GO
/*End*/




/*Bang Bai Viet*/

create proc Proc_BaiViet_GetData
							@MaBaiViet INT = '',
							@TenBaiViet nvarchar(255)=''
																
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from BaiViet where (1=1)'
	IF(@MaBaiViet !='')
	begin	
		set @Query += ' AND (MaBaiViet = @MaBaiViet) '
		end
	
	SET @ParamList =		'
							@MaBaiViet int,
							@TenBaiViet nvarchar
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaBaiViet,@TenBaiViet
END
go

create Proc Proc_BaiViet_Insert 
@MaNV int,
@TenBaiViet nvarchar(255),
@NoiDung ntext,
@TrangThaiHienThi int=1,
@NgayTao datetime
						
AS BEGIN 
	INSERT INTO BaiViet
	        (	
			MaNV,
			TenBaiViet,
			NoiDung,
			TrangThaiHienThi,
		    NgayTao
	        )
	VALUES  (					@MaNV,
							 @TenBaiViet,
							 @NoiDung,
							 @TrangThaiHienThi,
							 @NgayTao
	        )
END;


Go

create Proc Proc_BaiViet_Update 
@MaBaiViet int,
	@MaNV int,
@TenBaiViet nvarchar(255),
@NoiDung ntext,
@TrangThaiHienThi int,
@NgaySua datetime				
AS BEGIN 
	UPDATE BaiViet SET 
	MaNV=@MaNV,
	TenBaiViet=@TenBaiViet,
	NoiDung=@NoiDung,
	NgaySua=@NgaySua,
	TrangThaiHienThi=@TrangThaiHienThi
							
	WHERE MaBaiViet = @MaBaiViet
END
GO




/*Bang khach hang*/
 
create proc Proc_KhachHang_CheckTk @SDT int
as
begin
select COUNT(MaKH) from KhachHang where KhachHang.SoDTKH=@SDT
end
go
create Proc Proc_KhachHang_Insert
 @HoTenKH nvarchar(50)='',
@SoDTKH varchar(50)='',
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

create proc Proc_KhachHang_GetData
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

create proc BieuDo
@Thang int='',
@TrangThaiDonSanPham int='',
@TrangThaiDonDichVu int=''
as
begin
DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'select Month(NgayTao) as NgayTao,Sum(TongTien) as TongTien
from DonDatHang where (Year(NgayTao)=Year(GetDate()))'
IF(@TrangThaiDonDichVu !='')
	begin	
		set @Query += ' AND (TrangThaiDonDichVu=@TrangThaiDonDichVu)'
		end
		IF(@TrangThaiDonSanPham !='')
	begin	
		set @Query += ' AND (TrangThaiDonSanPham=@TrangThaiDonSanPham)'
		end
			IF(@TrangThaiDonSanPham =''and @TrangThaiDonDichVu='')
	begin	
		set @Query += ' AND (TrangThaiDonSanPham=4 or TrangThaiDonDichVu=4)'
		end
				IF(@Thang!='')
	begin	
		set @Query += 'AND (Month(NgayTao)=@Thang)'
		end
		set @Query+='group by MONTH(NgayTao),YEAR(NgayTao)'

	SET @ParamList =		'@Thang int,
								
								@TrangThaiDonSanPham int,
								@TrangThaiDonDichVu int	
													
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@Thang,@TrangThaiDonSanPham,@TrangThaiDonDichVu

	end

go

/*Bang Đơn đặt hàng*/

-- Trạng thái đơn đặt hàng :Trạng thái 1 :Chờ xác nhận, trạng thái 2 :Đã xác nhận, trạng thái 3: đang giao hàng
--Trạng thái 4: Hoàn thành, trạng thái 5 : Hủy

--Proc thống kê doanh thu theo tháng


create proc Proc_DonDatHang_UpdateTT
@MaDonDatHang int='',
@TrangThaiDonSanPham int=0,
@TrangThaiDonDichVu int=0
as
begin
if(@TrangThaiDonSanPham!=0)
begin 
update DonDatHang
set 
TrangThaiDonSanPham=@TrangThaiDonSanPham
where MaDonDatHang=@MaDonDatHang
end
if(@TrangThaiDonDichVu!=0)
begin 
update DonDatHang
set 
TrangThaiDonDichVu=@TrangThaiDonDichVu
where MaDonDatHang=@MaDonDatHang
end

end
go

create proc Proc_DonDatHang_Insert
 @MaNV int =null,
 @MaKH int=null,
 @SoDTGiaoHang varchar(50),
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

GO

create Procedure Proc_DonDatHang_GetData 
@MaDonDatHang int='',
@MaNV int ='',
 @MaKH int='',
 @SoDTGiaoHang varchar='',
 @HinhThucTT nvarchar(50)='',
 @TrangThaiDonSanPham int='',
 @TrangThaiDonDichVu int='',
 @HoTenNguoiNhan nvarchar(50)='',
 @DiaChiNhanHang nvarchar(50)='',
 @NgayTao datetime=''
												
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from DonDatHang where (1=1)'
	IF(@MaDonDatHang !='')
	begin
		SET @Query += ' AND (MaDonDatHang = @MaDonDatHang) '
		end
		IF(@MaNV !='')
	begin
		SET @Query += ' AND (MaNV = @MaNV) '
		end
		IF(@SoDTGiaoHang !='')
	begin
		SET @Query += ' AND (SoDTGiaoHang = @SoDTGiaoHang)'
		end
			IF(@NgayTao !='')
	begin
		SET @Query += ' AND (NgayTao = @NgayTao) '
		end
				IF(@TrangThaiDonSanPham !='')
	begin
		SET @Query += ' AND (TrangThaiDonSanPham = @TrangThaiDonSanPham) '
		end
						IF(@TrangThaiDonDichVu !='')
	begin
		SET @Query += ' AND (TrangThaiDonDichVu = @TrangThaiDonDichVu) '
		end
		IF(@MaKH !='')
	begin
		SET @Query += ' AND (MaKH = @MaKH) '
		end

	SET @ParamList =		'@MaDonDatHang int,
							@MaKH int,
							@MaNV int,
							@SoDTGiaoHang varchar, 
							@NgayTao datetime,
							@TrangThaiDonSanPham int,
							@TrangThaiDonDichVu int
							  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaDonDatHang,@MaKH,@MaNV,@SoDTGiaoHang,@NgayTao,@TrangThaiDonSanPham,@TrangThaiDonDichVu
END				
go



/*End*/


/*Bang Chi Tiet Don Dat*/
go
create Proc Proc_ChiTietDonDat_Insert
@MaDonDatHang int='',
@MaSanPham int='',
@Gia float='',
@Soluong int=''					
AS BEGIN 
	INSERT INTO ChiTietDonDat
	        (			
			MaDonDatHang,
			MaSanPham,
			Gia,
			Soluong					  
	        )
	VALUES  ( 
@MaDonDatHang,
@MaSanPham,
@Gia,
@Soluong
	        )
Select scope_identity()
END;
Go


create Procedure Proc_ChiTietDonDat_GetData 
@MaDonDatHang int=''							
AS BEGIN
	DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from ChiTietDonDat where (1=1)'
	IF(@MaDonDatHang!='')
	begin
		SET @Query += ' AND (MaDonDatHang = @MaDonDatHang) '
		end

	SET @ParamList =		'@MaDonDatHang int
							  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaDonDatHang
END
				
go
/*End*/

/*Bang Banner*/
create proc Proc_Banner_GetData
@MaBanner int=''
as
begin 
DECLARE @Query AS NVARCHAR(MAX)
	DECLARE @ParamList AS NVARCHAR(max)
	SET @Query = 'Select * from Banner where (1=1)'
	IF(@MaBanner!='')
	begin
		SET @Query += ' AND (MaBanner = @MaBanner) '
		end

	SET @ParamList =		'@MaBanner int
							  
							 '
	EXEC SP_EXECUTESQL @Query, @ParamList ,@MaBanner

end
go

create Proc Proc_Banner_Insert 
@MaNV int=null,
@ViTri int='',
@TrangThaiHienThi int=1,
@AnhBanner nvarchar(255)='',
@NgayTao datetime=''					
AS BEGIN 
	INSERT INTO Banner
	        (	
			MaNV,
			ViTri,
			TrangThaiHienThi,
			AnhBanner,
			NgayTao					
	        )
	VALUES  (				@MaNV,
	@ViTri,
	@TrangThaiHienThi,
	@AnhBanner,
	@NgayTao
		        )
END;

Go

create Proc Proc_Banner_Update 
@MaBanner int,
@MaNV int='',
@ViTri int='',
@TrangThaiHienThi int='',
@AnhBanner nvarchar(255)='',
@NgaySua datetime=''				
AS BEGIN 
	UPDATE Banner SET 

	MaNV=@MaNV,
	ViTri=@ViTri,
	TrangThaiHienThi=@TrangThaiHienThi,
	NgaySua=@NgaySua
WHERE MaBanner=@MaBanner
END
GO
/*End*/



/*Them data demo*/

go
insert into DanhMuc(TenDanhMuc,TrangThaiHienThi)
values (N'Chăm sóc tóc',1),
(N'Chăm sóc da',1),
(N'Chăm sóc cơ thể',1),
(N'Chăm sóc râu',1)
go
insert into SanPham(MaDanhMuc,TenSanPham,Gia,HinhAnh,MoTa,DanhGia,TrangThaiHienThi)
values (2,N'Xịt dưỡng khóa biểu bì tóc',450000,'/Content/Images/ImagesProduct/dauduongtocdiva.jpg',N'Sản phẩm chính hãng',N'Uu diem :tốt , nhược :giá cao',1),
(2,N'Dầu dưỡng spa Aura',450000,'/Content/images/ImagesProduct/dau_duong_spa_aura.jpg',N'Sp mới 2020',N'Uu diem :tốt , nhược :giá cao',1),
(3,N'Dầu gội aurane',460000,'/Content/images/ImagesProduct/dau_goi_aurane.jpg',N'Sản phẩm độc quyền',N'Uu diem :tốt , nhược :giá cao',1),
(4,N'Dầu gội tăng phồng tóc',440000,'/Content/images/ImagesProduct/dau_goi_tang_phong_toc.jpg',N'Sp mới 2020',N'Uu diem :tốt , nhược :giá cao',1),
(2,N'Dầu hấp deangello',450000,'/Content/images/ImagesProduct/dau_hap_dangello.jpg',N'Sp mới 2020',N'Uu diem :tốt , nhược :giá cao',1),
(4,N'Dầu xả phục hồi prosee',435000,'/Content/images/ImagesProduct/dau_xa_phuc_hoi_prosee.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao',1),
(3,N'Dầu gội dưỡng tóc',250000,'/Content/Images/ImagesProduct/dauduongtocp&m.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao',1),
(3,N'Dầu hấp oil hair',150000,'/Content/images/ImagesProduct/hap_dau_oil_hair_butter.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao',1),
(3,N'Dầu hấp oil hair',150000,'/Content/images/ImagesProduct/hap_dau_oil_hair_butter.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao',1),
(3,N'Wax tạo kiểu tóc',150000,'/Content/images/ImagesProduct/wax_tao_kieu_aurane.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao',1),
(3,N'Wax tạo kiểu tóc',150000,'/Content/images/ImagesProduct/wax_tao_kieu_aurane.jpg',N'Sp oke',N'Uu diem :tốt , nhược :giá cao',0)
insert into ThuongHieu
values
('Aurane',1,'',''),
('L.oreal',1,'',''),
('Posay',1,'',''),
('Avène',1,'','')

insert into ChucVu
values
('Admin'),
(N'Nhân viên quầy'),
(N'Nhân viên cắt tóc'),
(N'Nhân viên gội đầu')


insert into NhanVien 
values 
(N'Đoàn Minh Ngọc','ngocdoan@gmail.com','FEC9D37358838A72AE49C15A4373A9B4','090208707',N'Hải Dương',142987653,'09/02/1978','Fulltime',1,1,'10/7/2020','10/7/2020'),
(N'Đoàn Ngọc Giàu','ngocgiaudoan@gmail.com','123456','0902084027',N'Hải Dương',142911153,'09/02/1980','Fulltime',3,1,'10/7/2020','10/7/2020'),
(N'Vũ Văn Quân','quanvu@gmail.com','123456','0902047097',N'Hải Dương',142987634,'09/02/1990','Fulltime',3,1,'10/7/2020','10/7/2020'),
(N'Nguyễn Quang Ninh','ninhquang@gmail.com','123456','0902187097',N'Hải Dương',142987611,'09/02/1991','Fulltime',3,1,'10/7/2020','10/7/2020'),
(N'Nguyễn Anh Vũ','anhvu@gmail.com','123456','090202707',N'Hải Dương',142987655,'09/02/1997','Fulltime',3,1,'10/7/2020','10/7/2020'),
(N'Nguyễn Hoàng Giang','gianghoang@gmail.com','FEC9D37358838A72AE49C15A4373A9B4','0902087017',N'Hải Dương',142987666,'09/02/1998','Fulltime',2,1,'10/7/2020','10/7/2020'),

(N'Nguyễn Thị Ánh Ngọc','anhngoc@gmail.com','123456','0902087017',N'Hải Dương',142987677,'09/02/2000','Fulltime',4,1,'10/7/2020','10/7/2020'),
(N'Nguyễn Thủy Tiên','tiennguyen@gmail.com','123456','0902087027',N'Hải Dương',142987632,'09/02/1999','PartTime',4,1,'10/7/2020','10/7/2020'),
(N'Dương Thị Phương','phuongthanh@gmail.com','123456','0902087397',N'Hải Dương',142983453,'09/02/1999','PartTime',4,1,'10/7/2020','10/7/2020')



go
INSERT INTO dichvu 
 VALUES
( N'Combo cắt 7 bước', 70000, 1,'',''),
( N'Combo cắt 12 bước', 100000, 1,'',''),
( N'Uốn Xoăn', 250000, 1,'',''),
( N'Tẩy màu tóc', 100000,1, '',''),
( N'Nhuộm tóc', 200000, 1,'',''),
(N'Uốn phồng', 300000, 1,'','')
;


go

INSERT INTO Chitietdichvu
values
(4,N'Thay đổi phong cách của bạn với mái tóc xoăn bồng bềnh.'),
( 2, N'Hỗ trợ cho những bạn muốn nhuộm mái tóc sáng màu.'),
(3,N'Thay đổi diện mạo với hàng trăm màu tóc thời trang với mức giá khó tin chỉ 200000. Sử dụng màu nhuộm cao cấp, tư vấn giữ màu tốt nhất.'),
(1, N'Bước 1: Massage chân muối Himalaya -Cải thiện sức khỏe'),
(1, N'Bước 2: Rửa mặt -Tút lại vẻ đẹp trai của bạn'),
(1, N'Bước 3: Đắp Mặt Nạ Dưỡng Da, Sạch Mụn -Mặt nạ tinh chất than hoạt tính giúp sạch sâu từng lỗ chân lông'),
(1, N'Bước 4: Gội đầu bấm huyệt -Một cảm giác sảng khoái nhất mà bạn từng biết đến'),
(1, N'Bước 5: Massage Thư Giãn Da Mặt, Vai Gáy - Cảm nhận sự thư thái từ đôi bàn tay mướt mịn của các Spa Girl'),
(1, N'Bước 6: Chăm sóc da mặt bằng công nghệ cao - Hút sạch bã nhờn, mụn đầu đen, xịt khoáng chất'),
(1, N'Bước 7: Massage Vitamin E & Đá cẩm thạch - Trắng da, mờ nếp nhăn')

go





--create proc proc_getdata_dondathang_sanpham

select * from DonDatHang
select DonDatHang.MaDonDatHang from DonDatHang 
join ChiTietDonDat on 
ChiTietDonDat.MaDonDatHang=DonDatHang.MaDonDatHang
join SanPham on ChiTietDonDat.MaSanPham=SanPham.MaSanPham 
group by(DonDatHang.MaDonDatHang)

go

create proc proc_getdata_chitietdondat_sanpham
@MaDonDatHang int=''
as
begin
select ChiTietDonDat.MaDonDatHang,ChiTietDonDat.MaSanPham,ChiTietDonDat.Soluong,SanPham.TenSanPham,SanPham.HinhAnh,ChiTietDonDat.Gia
from SanPham join ChiTietDonDat on ChiTietDonDat.MaSanPham=SanPham.MaSanPham


where ChiTietDonDat.MaDonDatHang=@MaDonDatHang
end
go
-- proc-dondathang-dichvu
create proc proc_getdata_chitietdondat_dichvu
@MaDonDatHang int=''
as
begin
select ChiTietDonDichVu.MaDV,TenDV,Gia,MaDonDatHang
from DichVu join ChiTietDonDichVu on ChiTietDonDichVu.MaDV=DichVu.MaDV
where ChiTietDonDichVu.MaDonDatHang=@MaDonDatHang
end
go


 /*end*/

/*update tong tien cho sản phẩm*/

create proc proc_getdata_tongtien
@MaDonDatHang int=''
as
begin
update DonDatHang
set TongTien=(
select SUM(ChiTietDonDat.Soluong*ChiTietDonDat.Gia)
from ChiTietDonDat 
where MaDonDatHang=@MaDonDatHang
)
where MaDonDatHang=@MaDonDatHang
end

go


/*update tong tien cho dịch vụ*/
create proc proc_getadata_tongtien_dichvu
@MaDonDatHang int=''
as
begin
update DonDatHang
set TongTien=(
select SUM(DichVu.Gia)
from DonDatHang join ChiTietDonDichVu on DonDatHang.MaDonDatHang=ChiTietDonDichVu.MaDonDatHang
join DichVu on DichVu.MaDV=ChiTietDonDichVu.MaDV
where DonDatHang.MaDonDatHang=@MaDonDatHang
)
where DonDatHang.MaDonDatHang=@MaDonDatHang

end


















