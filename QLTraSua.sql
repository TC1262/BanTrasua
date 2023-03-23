use master 
go
if exists (select name from sysdatabases where name = 'QLBanTraSua')
drop database QLBanTraSua
go
create database QLBanTraSua
go
use QLBanTraSua
go

-- Khách hàng ________________________________________________________________________________________________________
create table CUSTOMER
(
	userName char (50) not null primary key,
	pass char (50),
	hoTen nvarchar (max),
	soDT char (10),
	diaChi nvarchar (max),
	email char (90)
)

-- Thể loại __________________________________________________________________________________________________________
create table CATEGORY
(
	maLoai char (10) primary key,
	tenLoai nvarchar (max)
)

-- Sản phẩm __________________________________________________________________________________________________________
create table PRODUCTS
(
	maSP char (10) not null primary key,
	tenSP nvarchar (max),
	maLoai char (10),
	gia money,
	gioiThieu nvarchar (max),
	hinhAnh nvarchar(max),
	soLuongTon int,
	constraint fk_PRO_CATE foreign key (maLoai) references CATEGORY (maLoai)
)

-- Hóa đơn ___________________________________________________________________________________________________________
create table BILL
(
	maHD int identity (1, 1) primary key,
	userName char (50),
	ngayMua date,
	tongTien money,
	ngayHenGiao date,
	ngayThanhToan date,
	ngayGiaoHang date,
	constraint fk_BILL_USER foreign key (userName) references CUSTOMER (userName)
)

-- Chi tiết hóa đơn __________________________________________________________________________________________________
create table BILLDETAILS
(
	maHD int,
	maSP char (10) not null,
	soLuong int,
	primary key (maHD, maSP),
	constraint fk_BD_B foreign key (maHD) references BILL (maHD),
	constraint fk_BD_PRO foreign key (maSP) references PRODUCTS (maSP)
)

-- Liên hệ ___________________________________________________________________________________________________________
create table CONTACT
(
	userName char (50) not null primary key,
	mess nvarchar (max),
	constraint fk_CON_AU foreign key (userName) references CUSTOMER (userName)
)

create trigger tinhTongTien
on BILL
after INSERT AS
BEGIN
	UPDATE BILL
	SET	tongTien = (select sum(PRODUCTS.gia * soLuong) 
					from BILLDETAILS, BILL, PRODUCTS 
					where BILLDETAILS.maHD = BILL.maHD and PRODUCTS.maSP = BILLDETAILS.maSP)
	FROM BILL JOIN inserted on BILL.maHD = inserted.maHD
end

-- DATA --------------------------------------------------------------------------------------------------------------
insert into CUSTOMER values ('An', '123', N'Trần Văn An', '0938592019', N'TP. Hồ Chí Minh', 'an123@gmail.com')
insert into CUSTOMER values ('Binh', '123', N'Lê Quý Bình', '0938591002', N'Long An', 'binh123@gmail.com')
insert into CUSTOMER values ('Duyen', '123', N'Nguyễn Cao Kỳ Duyên', '0395839501', N'TP. Hồ Chí Minh', 'kyduyen123@gmail.com')
insert into CUSTOMER values ('Dung', '123', N'Trần Ngọc Dung', '0938593951', N'TP. Hồ Chí Minh', 'dung123@gmail.com')
insert into CUSTOMER values ('Chi', '123', N'Phương Mỹ Chi', '0192959395', N'TP. Hồ Chí Minh', 'mychi123@gmail.com')
insert into CUSTOMER values ('Bich', '123', N'Ba Bích', '0938593891', N'Hà Nội', 'bich123@gmail.com')
insert into CUSTOMER values ('Hung', '123', N'Lý Hùng', '0395839102', N'TP. Hồ Chí Minh', 'lyhung123@gmail.com')
insert into CUSTOMER values ('Admin', '123', N'Administrator', '0395839102', N'TP. Hồ Chí Minh', 'admin777@gmail.com')
select * from CUSTOMER

insert into CATEGORY values ('TS', N'Trà Sữa')
insert into CATEGORY values ('soda', 'Soda')
insert into CATEGORY values ('Binsu', 'Binsu')
select * from CATEGORY 

insert into PRODUCTS values ('SP001', N'Sữa tươi trân châu đường đen', 'TS', '30000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'STTranChauDuongDen.jpg', '53')
insert into PRODUCTS values ('SP002', N'Trà sữa truyền thống', 'TS', '27000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'TraSuaTruyenThong.jpg', '32')
insert into PRODUCTS values ('SP003', N'Trà sữa khoai môn', 'TS', '35000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'TSKhoaiMon.jpg', '54')
insert into PRODUCTS values ('SP004', N'Trà sữa Machiato', 'TS', '37000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'TSMacchiato.jpg', '53')
insert into PRODUCTS values ('SP005', N'Trà sữa Socola', 'TS', '35000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'TSChocolate.jpg', '53')
insert into PRODUCTS values ('SP006', N'Trà sữa thái xanh', 'TS', '30000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'TSThaiXanh.jpg', '32')
insert into PRODUCTS values ('SP007', N'Trà sữa thái đỏ', 'TS', '30000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'TSThaiDo.jpg', '12')
insert into PRODUCTS values ('SP008', N'Trà sữa dâu', 'TS', '35000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'TSDau.jpg', '36')
insert into PRODUCTS values ('SP009', N'Trà sữa hoa đậu biếc', 'TS', '33000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'TSHoaDauBiec.jpg', '12')
insert into PRODUCTS values ('SP010', N'Trà sữa kiwi', 'TS', '33000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'TSKiwi.jpg', '43')
insert into PRODUCTS values ('SP011', N'Trà sữa đào', 'TS', '33000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'TSDao.jpg', '12')
insert into PRODUCTS values ('SP012', N'Trà sữa bạc hà', 'TS', '34000', N'Trà sữa được pha chế từ trà kết hợp với các phụ gia nguyên liệu khác như sữa, bột sữa, đường, các loại siro, topping để tạo thành. Hương vị các loại trà sữa khác nhau tuỳ thuộc vào lượng thành phần chính, phương pháp pha chế và các phụ gia bổ sung.', N'TSBacHa.jpg', '13')
insert into PRODUCTS values ('SP013', N'Soda dâu', 'soda', '31000', N'Loại thức uống được ưa thích nhất thế giới này lại thực sự nổi tiếng và gắn liền với nền văn hóa Mỹ. Soda là loại nước tinh khiết giàu khoáng chất, chứa nhiều nguyên tố có lợi cho sức khỏe như Kali, Magie hay Canxi giúp xương chắc khỏe. Hỗ trợ tiêu hóa tốt.', N'SodaDau.jpg', '43')
insert into PRODUCTS values ('SP014', N'Soda chanh bạc hà', 'soda', '32000', N'Loại thức uống được ưa thích nhất thế giới này lại thực sự nổi tiếng và gắn liền với nền văn hóa Mỹ. Soda là loại nước tinh khiết giàu khoáng chất, chứa nhiều nguyên tố có lợi cho sức khỏe như Kali, Magie hay Canxi giúp xương chắc khỏe. Hỗ trợ tiêu hóa tốt.', N'SodaChanhBacHa.jpg', '11')
insert into PRODUCTS values ('SP015', N'Soda đào', 'soda', '31000', N'Loại thức uống được ưa thích nhất thế giới này lại thực sự nổi tiếng và gắn liền với nền văn hóa Mỹ. Soda là loại nước tinh khiết giàu khoáng chất, chứa nhiều nguyên tố có lợi cho sức khỏe như Kali, Magie hay Canxi giúp xương chắc khỏe. Hỗ trợ tiêu hóa tốt.', N'SodaDao.jpg', '16')
insert into PRODUCTS values ('SP016', N'Soda đậu biếc', 'soda', '35000', N'Loại thức uống được ưa thích nhất thế giới này lại thực sự nổi tiếng và gắn liền với nền văn hóa Mỹ. Soda là loại nước tinh khiết giàu khoáng chất, chứa nhiều nguyên tố có lợi cho sức khỏe như Kali, Magie hay Canxi giúp xương chắc khỏe. Hỗ trợ tiêu hóa tốt.', N'SodaDauBiec.jpg', '64')
insert into PRODUCTS values ('SP017', N'Soda nho', 'soda', '32000', N'Loại thức uống được ưa thích nhất thế giới này lại thực sự nổi tiếng và gắn liền với nền văn hóa Mỹ. Soda là loại nước tinh khiết giàu khoáng chất, chứa nhiều nguyên tố có lợi cho sức khỏe như Kali, Magie hay Canxi giúp xương chắc khỏe. Hỗ trợ tiêu hóa tốt.', N'SodaNho.jpg', '23')
insert into PRODUCTS values ('SP018', N'Soda kiwi', 'soda', '32000', N'Loại thức uống được ưa thích nhất thế giới này lại thực sự nổi tiếng và gắn liền với nền văn hóa Mỹ. Soda là loại nước tinh khiết giàu khoáng chất, chứa nhiều nguyên tố có lợi cho sức khỏe như Kali, Magie hay Canxi giúp xương chắc khỏe. Hỗ trợ tiêu hóa tốt.', N'SodaKiwi.jpg', '65')
insert into PRODUCTS values ('SP019', N'Soda việt quất', 'soda', '35000', N'Loại thức uống được ưa thích nhất thế giới này lại thực sự nổi tiếng và gắn liền với nền văn hóa Mỹ. Soda là loại nước tinh khiết giàu khoáng chất, chứa nhiều nguyên tố có lợi cho sức khỏe như Kali, Magie hay Canxi giúp xương chắc khỏe. Hỗ trợ tiêu hóa tốt.', N'SodaVietQuat.jpg', '26')
insert into PRODUCTS values ('SP020', N'Kem tuyết socola', 'Binsu', '95000', N'Một trong số những món ăn từ Hàn Quốc được thích thú nhất trên thị trường bây giờ là món Kem bingsu Hàn. Kem tuyết bingsu Hàn Quốc là món kem tuyết được phủ các loại kem, trái cây, mứt, kẹo,… lên phía trên. Kem tuyết Hàn Quốc Bingsu là 1 thức ăn tráng miệng vô cùng thông dụng tại Hàn Quốc và nó hiện giờ cũng được yêu thích thực sự nhiều tại các lãnh thổ khác trên thế giới.', N'KemTuyetSocola.jpg', '43')
insert into PRODUCTS values ('SP021', N'Kem tuyết matcha', 'Binsu', '97000', N'Một trong số những món ăn từ Hàn Quốc được thích thú nhất trên thị trường bây giờ là món Kem bingsu Hàn. Kem tuyết bingsu Hàn Quốc là món kem tuyết được phủ các loại kem, trái cây, mứt, kẹo,… lên phía trên. Kem tuyết Hàn Quốc Bingsu là 1 thức ăn tráng miệng vô cùng thông dụng tại Hàn Quốc và nó hiện giờ cũng được yêu thích thực sự nhiều tại các lãnh thổ khác trên thế giới.', N'BinsuMatcha.jpg', '21')
insert into PRODUCTS values ('SP022', N'Kem tuyết bơ', 'Binsu', '95000', N'Một trong số những món ăn từ Hàn Quốc được thích thú nhất trên thị trường bây giờ là món Kem bingsu Hàn. Kem tuyết bingsu Hàn Quốc là món kem tuyết được phủ các loại kem, trái cây, mứt, kẹo,… lên phía trên. Kem tuyết Hàn Quốc Bingsu là 1 thức ăn tráng miệng vô cùng thông dụng tại Hàn Quốc và nó hiện giờ cũng được yêu thích thực sự nhiều tại các lãnh thổ khác trên thế giới.', N'BinsuBo.jpg', '11')
insert into PRODUCTS values ('SP023', N'Kem tuyết đào', 'Binsu', '92000', N'Một trong số những món ăn từ Hàn Quốc được thích thú nhất trên thị trường bây giờ là món Kem bingsu Hàn. Kem tuyết bingsu Hàn Quốc là món kem tuyết được phủ các loại kem, trái cây, mứt, kẹo,… lên phía trên. Kem tuyết Hàn Quốc Bingsu là 1 thức ăn tráng miệng vô cùng thông dụng tại Hàn Quốc và nó hiện giờ cũng được yêu thích thực sự nhiều tại các lãnh thổ khác trên thế giới.', N'BinsuDao.jpg', '43')
insert into PRODUCTS values ('SP024', N'Kem tuyết dâu', 'Binsu', '92000', N'Một trong số những món ăn từ Hàn Quốc được thích thú nhất trên thị trường bây giờ là món Kem bingsu Hàn. Kem tuyết bingsu Hàn Quốc là món kem tuyết được phủ các loại kem, trái cây, mứt, kẹo,… lên phía trên. Kem tuyết Hàn Quốc Bingsu là 1 thức ăn tráng miệng vô cùng thông dụng tại Hàn Quốc và nó hiện giờ cũng được yêu thích thực sự nhiều tại các lãnh thổ khác trên thế giới.', N'BinsuDau.jpg', '43')
insert into PRODUCTS values ('SP025', N'Kem tuyết xoài', 'Binsu', '90000', N'Một trong số những món ăn từ Hàn Quốc được thích thú nhất trên thị trường bây giờ là món Kem bingsu Hàn. Kem tuyết bingsu Hàn Quốc là món kem tuyết được phủ các loại kem, trái cây, mứt, kẹo,… lên phía trên. Kem tuyết Hàn Quốc Bingsu là 1 thức ăn tráng miệng vô cùng thông dụng tại Hàn Quốc và nó hiện giờ cũng được yêu thích thực sự nhiều tại các lãnh thổ khác trên thế giới.', N'BinsuXoai.jpg', '64')
insert into PRODUCTS values ('SP026', N'Kem tuyết dưa lưới', 'Binsu', '90000', N'Một trong số những món ăn từ Hàn Quốc được thích thú nhất trên thị trường bây giờ là món Kem bingsu Hàn. Kem tuyết bingsu Hàn Quốc là món kem tuyết được phủ các loại kem, trái cây, mứt, kẹo,… lên phía trên. Kem tuyết Hàn Quốc Bingsu là 1 thức ăn tráng miệng vô cùng thông dụng tại Hàn Quốc và nó hiện giờ cũng được yêu thích thực sự nhiều tại các lãnh thổ khác trên thế giới.', N'BinsuDuaLuoi.jpg', '12')
select * from PRODUCTS

select * from BILLDETAILS
select * from BILL
select * from CONTACT