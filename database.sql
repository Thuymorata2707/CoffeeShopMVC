create database theCoffee
use theCoffee



create table TaiKhoan (
	username char(30) primary key,
	passwords char(20)
)

create table NhanVien (
	MaNV int IDENTITY(1,1) primary key,
	TenNV nvarchar(30),
	Avt nvarchar(100),
	NgaySinh date,
	sdt char(10),
	Mail nvarchar(40),
	Luong float,
	ChucVu nvarchar(20)
)

create table KhachHang (
	MaKH int IDENTITY(1,1) primary key,
	TenKH nvarchar(30),
	Anh nvarchar(100),
	Email nvarchar(50),
	sdt char(10),
	DiaChi nvarchar(40)
)

create table NCC (
	MaNCC int IDENTITY(1,1) primary key,
	TenNCC nvarchar(80),
	sdt char(12),
	DiaChi nvarchar(80)
)

create table DanhMucSP (
	MaDanhMuc int IDENTITY(1,1) primary key,
	TenDanhMuc nvarchar(40)
)

create table menu (
	MaSP int IDENTITY(1,1) primary key,
	MaDanhMuc int foreign key references DanhMucSP(MaDanhMuc),
	TenSP nvarchar(40),
	HinhAnh nvarchar(300),
	GiaBan float,
	MoTa nvarchar(200)
)

create table PhieuNhap (
	MaPN int IDENTITY(1,1) primary key,
	MaNCC int foreign key references NCC(MaNCC),
	MaNV int foreign key references NhanVien(MaNV),
	NgayNhap date,
	TongTienNhap float
)



create table CTPhieuNhap (
	MaCTPN int IDENTITY(1,1),
	MaPN int foreign key references PhieuNhap(MaPN),
	TenHang nvarchar(60),
	DonViTinh nvarchar(30),
	SoLuong bigint,
	Gia float,
	TongGia float,
	primary key(MaCTPN)
)

/*
create proc TinhTongGia
as update CTPhieuNhap set TongGia = SoLuong * Gia
go 
exec TinhTongGia

create proc TinhTongTienNhap
as update PhieuNhap set TongTienNhap = (select sum(SoLuong * Gia) from CTPhieuNhap 
										where CTPhieuNhap.MaPN = PhieuNhap.MaPN
										group by CTPhieuNhap.MaPN)
go 
exec TinhTongTienNhap
*/



create table HoaDon (
	MaHD int IDENTITY(1,1) primary key,
	MaKH int foreign key references KhachHang(MaKH),
	NgayMua date,
	TongTien float,
	TrangThai bit
)

create table CTHoaDon (
	MaCTHD int IDENTITY(1,1),
	MaHD int foreign key references HoaDon(MaHD),
	MaSP int foreign key references menu(MaSP),
	SoLuong bigint,
	TienBan float,
	primary key(MaCTHD)
)

create trigger cn_tienban on CTHoaDon
for insert, update, delete
as
	update CTHoaDon
	set TienBan = SoLuong * GiaBan from Menu where menu.MaSP = CTHoaDon.MaSP


create trigger cn_TongTien on CTHoaDon
for insert, update, delete
as 
	update HoaDon
	set TongTien = (select sum(TienBan) from CTHoaDon where CTHoaDon.MaHD = HoaDon.MaHD group by CTHoaDon.MaHD)


	select * from KhachHang
insert into TaiKhoan values
('admin1','1234'),
('admin2','2222')
--('nv01','4444'),
--('nv02','5555'),
--('nv03','6666')

insert into NhanVien values
('1',N'Vũ Thị Hoài Thu','10/03/2003','0945678311','vuthihoaithu031003@gmail.com',5.3,N'Quản lý'),
('2',N'Lê Thành Kiệt','2/7/2000','0903355657','lethanhkiet@gmail.com',6,N'Quản lý')
--('nv01','Nguyễn Thị Trang','11/03/2004','0343994509','nguyenthitrang@gmail.com',3.3,'Nhân viên'),
--('nv02','Trần Văn Đức','11/05/2002','0923826465','tranvanduc@gmail.com',3,'Nhân viên'),
--('nv03','Phạm Thị Hoa','9/03/2003','0945543215','phamthihoa@gmail.com',3,'Nhân viên')

insert into NCC values
('1',N'Cửa hàng phân phối cafe Drai Farm','0919891992',N'xã Quảng Hiệp, huyện Cư M’gar, DakLak'),
('2',N'Công ti phân phối trà Sơn Chính','0919991999',N'257 Quan Nhân, P. Nhân Chính, Thanh Xuân, Hà Nội'),
('3',N'Cửa hàng sữa Vinamilk','02437917943',N'34 Hoàng Quốc Việt, P. Nghĩa Đô, Cầu Giấy, Hà Nội'),
('4',N'Cửa hàng bánh Fresh Garden','0246554666',N'46 phố An Dương, P. Yên Phụ, Tây Hồ, Hà Nội.'),
('5',N'Công ty sản xuất Coffee Chồn Vàng Coffee','0907330022',N'Số 3, Ấp 1, Xã Tân Bửu, Huyện Bến Lức, Long An')

insert into KhachHang values 
('1',N'Nguyễn Thị Thu Hương','0337744967','Phú Đô, Nam Từ Liêm'),
('2',N'Nguyễn Xuân Thủy','0998803434','Mễ Trì, Nam Từ Liêm'),
('3',N'Lê Thanh Bình','0993257455','Sóc Sơn, Hà Nội')

insert into DanhMucSP values
('1',N'Cà Phê'),
('2',N'Trà'),
('3',N'Bánh và Snack'),
('4',N'CloudTee and CloudFee')

insert into menu values
('1','cafe',N'Cà phê sữa đá',30,N'Cà phê Đắk Lắk kết hợp với sữa đặc'),
('2','cafe',N'Đường đen sữa đá',45,N'Cà phê đậm đà, bùng nổ và đường đen ngọt thơm'),
('3','cafe',N'Cà phê sữa nóng',40,N'Cà phê được pha phin truyền thống kết hợp với sữa đặc'),
('4','cafe',N'Cà phê đen đá',30,N'Cà phê đen mang trong mình phong vị trầm lắng, thi vị hơn'),
('5','cafe',N'Cappuccino đá',60,N'Capuchino hòa quyện giữa hương thơm của sữa, kem cùng vị cà phê Espresso'),
('6','cafe',N'Espresso Nóng',40,N'Espresso cho ra vị ngọt caramel, vị chua dịu và sánh đặc.'),
('7','tea',N'Trà long nhãn hạt sen',50,N'Thức uống mang hương vị của nhãn, của sen, của trà Oolong'),
('8','tea',N'Trà đào cam sả',50,N'Vị thanh của đào, vị chua dịu của Cam Vàng nguyên vỏ, vị chát của trà đen tươi'),
('9','tea',N'Trà sữa mắc ca trân châu',55,N'Nền trà olong cho vị cân bằng, ngọt dịu cùng Trân châu trắng giòn dai'),
('10','tea',N'Trà hạt sen',40,N'Nền trà oolong hảo hạng kết hợp cùng hạt sen tươi, bùi bùi thơm ngon.'),
('11','cloud',N'CloudTea Olong nướng kem dừa',55,N'Trà Olong nướng đậm đà, hòa cùng sữa dừa ngọt dịu'),
('12','cloud',N'CloudTea Olong nướng kem cheese',55,N'Quyện kem sữa thơm béo cùng lớp phô mai mềm tan mằn mặn'),
('13','cloud',N'CloudFee Caramel',50,N'Vị đắng nhẹ từ cà phê phin pha trộn với Espresso'),
('14','cloud',N'CloudFee Hà Nội',50,N'Đậm vị cà phê nhưng không quá đắng, ngậy nhưng không hề ngấy.'),
('15','snack',N'Mochi Kem Phúc Bồn Tử',20,N'Lớp Mochi dẻo thơm, bên trong là lớp kem lạnh cùng nhân phúc bồn tử.'),
('16','snack',N'Mousse Red Velvet',35,N'Bánh nhiều lớp được phủ kem bên trên bằng Cream cheese.'),
('17','snack',N'Mít sấy',25,N'Mít sấy khô vàng ươm, giòn rụm, giữ nguyên được vị ngọt lịm của mít tươi.'),
('18','snack',N'Bánh mì que Bate',15,N'Vỏ bánh mì giòn tan, kết hợp với lớp nhân pate béo béo đậm'),
('19','cafe',N'Frosty Cà Phê Đường Đen',60,N'Sự kết hợp giữa Espresso đậm đà và Đường Đen ngọt thơm'),
('20','tea',N'Hi Tea Vải',50,N'Ngọt ngào của Vải, mix cùng vị chua thanh tao từ trà hoa Hibiscus'),
('21','cafe',N'Cold Brew sữa tươi',60,N'Thanh mát và cân bằng với vị cà phê Arabica Cầu Đất cùng sữa tươi')


insert into PhieuNhap values
('1','1','1','4/4/2023',5),
('2','2','1','5/4/2023',2),
('3','3','2','6/7/2023',1),
('4','4','2','7/4/2023',2)

insert into CTPhieuNhap values
('1','1',N'cafe hạt',N'Túi',10,150000,1500000),
('2','1',N'cafe xay',N'Túi',10,150000,1500000),
('3','2',N'Trà đen',N'Túi',10,110000,1000000),
('4','2',N'Trà xanh',N'Túi',10,150000,1000000),
('5','3',N'Sữa đặc',N'Hộp',5,50000,250000),
('6','3',N'Sữa tươi',N'Hộp',10,75000,750000),
('7','4',N'Bánh mì',N'Cái',100,10000,1000000),
('8','4',N'Mochi',N'Hộp',50,15000,750000),
('9','4',N'Bánh kem',N'Cái',10,120000,1200000)

insert into HoaDon values
('1','1','5/5/2023',50000),
('2','2','5/5/2023',200000),
('3','3','7/5/2023',700000),
('4','3','7/7/2023',100000),
('5','1','5/3/2023',550000),
('6','3','6/5/2023',50000)

insert into CTHoaDon values
('1','1','7',1,50000),
('2','2','5',2,120000),
('3','2','16',2,70000),
('4','3','13',2,100000),
('5','5','11',8,440000),
('6','5','15',5,100000),
('7','6','01',1,30000),
('8','6','15',1,20000)

