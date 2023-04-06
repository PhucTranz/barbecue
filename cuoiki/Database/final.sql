create database barbecue
create table MenuBar(
	idMenuBar int primary key IDENTITY(1,1),
	name nvarchar(100),
	link nvarchar(MAX),
	meta varchar(100),
	hide bit,
	[order] int,
	datebegin datetime default getdate()
)



create table SlidesShow(
	idSlidesShow int primary key IDENTITY(1,1),
	title nvarchar(100),
	description nvarchar(300),
	link nvarchar(MAX),
	meta varchar(100),
	hide bit,
	[order] int,
	datebegin datetime default getdate()
)

create table Banner(
	idBanner int primary key  IDENTITY(1,1),
	name nvarchar(100),
	meta varchar(100),
	hide bit,
	[order] int,
	datebegin datetime default getdate()
)



create table Footer(
	idFooter int primary key  IDENTITY(1,1),
	name nvarchar(100),
	intro nvarchar(1000),
	address nvarchar(1000),
	email varchar(100),
	sdt varchar(100),
	meta varchar(100),
	hide bit,
	[order] int,
	datebegin datetime default getdate()
)



create table TypeFood(
	idTypeFood int primary key IDENTITY(1,1),
	name nvarchar(max),
	meta varchar(100),
	hide bit,
	datebegin datetime default getdate()
)



create table Food(
	idFood int primary key IDENTITY(1,1),
	idTypeFood int,
	name nvarchar(100),
	price int,
	description nvarchar(255),
	meta varchar(100),
	hide bit,
	img nvarchar(MAX),
	datebegin datetime default getdate()
	foreign key (idTypeFood) references TypeFood(idTypeFood)

)




create table Account(
	idAcc int primary key IDENTITY(1,1),
	TenBan nvarchar(100),
	username nvarchar(100),
	password nvarchar(100),
	datebegin datetime default getdate()
)




create table Bill(
	idBill int primary key IDENTITY(1,1),
	idAcc int,
	total int,
	timeBegin datetime default getdate(),
	timeFinish datetime default getdate(),
	status bit,
	foreign key (idAcc) references Account(idAcc)
)

create table DetailBill(
	idBill int,
	idFood int,
	foreign key (idBill) references Bill(idBill),
	foreign key (idFood) references Food(idFood),
	quanlity int,
	primary key(idBill,idFood)
)

create table Cart(
	idCart int primary key IDENTITY(1,1),
	tongtien int,
	idAcc int FOREIGN key REFERENCES Account(idAcc),
	status int
)
create table DetailCart(
	idCart int FOREIGN key REFERENCES Cart(idCart),
	idFood int FOREIGN key REFERENCES Food(idFood),
	soluong int,
	primary key(idCart, idFood)
)

INSERT INTO MenuBar (name,link,meta,hide,[order])
VALUES (N'Trang chủ', 'default','trang_chu',0,'1')
INSERT INTO MenuBar (name,link,meta,hide,[order])
VALUES (N'Thực đơn', 'thuc_don','thuc_don',0,'2')
INSERT INTO MenuBar (name,link,meta,hide,[order])
VALUES (N'Đặt bàn', 'booktable','dat_ban',0,'4')


insert into Account (TenBan,username,password) values (N'admin','admin','E10ADC3949BA59ABBE56E057F20F883E')



INSERT INTO SlidesShow (title,description,link,meta,hide,[order])
VALUES ('Discount 20% in 30/4 & 1/5', N'Barbecue khuyến mãi cho mỗi đơn hóa đơn 20% tối đa 100.000đ trong 2 ngày 30/4 và 1/5', '','',0,'1')
INSERT INTO SlidesShow (title,description,link,meta,hide,[order])
VALUES ('VEGGIE PIZZA', N'Giảm sốc 50% VEGGIE PIZZA với size L', '','',0,'2')


insert into TypeFood (name,meta,hide) values (N'Cơm','com',0),('Canh','canh',0),(N'Lẩu','lau',0),
(N'Nước uống','nuoc_uong',0),(N'Thịt bò','thit_bo',0),(N'Thịt heo','thit_heo',0)
,(N'Hải sản','hai_san',0),(N'Món truyền thống','mon_truyen_thong',0)
,(N'Món tráng miệng','mon_trang_mieng',0),('Salad','salad',0)


insert into Food (idTypeFood,name,price,description,meta,hide,img) values (1,N'Cơm Trắng',10000,N'Cơm được nấu từ gạo tẻ không phụ gia','com_trang',0,'2428_Com_trang_1_2.jpg')
,(1,N'Cơm trộn bát đá Hàn Quốc',10000,N'Cơm trộn trong bát đá để giữ được độ nóng mang đến trải nghiệm ấm áp','com_tron_bat_da_han_quoc',0,'2643_Com_tron_bat_da_han_quoc_sot_gogi_1_2.jpg')
,(1,N'Kim bap',10000,N'Kimbap là món ăn truyền thống của xứ sở Kim Chi','kim_bap',0,'kimbap.jpg')

insert into Food (idTypeFood,name,price,description,meta,hide,img) values (2,N'Canh kim chi',10000,N'Món canh kim chi đậm đà có độ cay cay từ ớt bột','canh_kim_chi',0,'1377_Canh_kim_chi.jpg')
,(2,N'Súp nghêu wakame',10000,N'Súp nghêu bổ dưỡng, thơm ngon, màu sắc hấp dẫn','sup_ngheu_wakame',0,'2638_Sup_ngheu_wakame_1_2.jpg')
,(2,N'Canh tương đậu',10000,N'Canh đậu tương hải sản Hàn Quốc là một món ăn cực kỳ thơm ngon và độc đáo','canh_tuong_dau',0,'canh-tuong-dau_1.jpg')

insert into Food (idTypeFood,name,price,description,meta,hide,img) values (3,N'Lẩu kim chi',10000,N'Lẩu kim chi Hàn Quốc có vị chua thanh cay nhẹ','lau_kim_chi',0,'4886_Lau_kim_chi_1_2.jpg')
,(3,N'Lẩu Bulgog',10000,N'Thưởng thức lẩu bò Bulgogi cùng với cơm trắng và kim chi rất hợp vị','lau_bulgog',0,'4885_Lau_Bulgogi_1_2.jpg')
,(3,N'Lẩu cay hải sản',10000,N'Lẩu Thái chua cay là một trong các món lẩu ngon và mang một hương vị đặc trưng của lẩu hải sản','lau_cay_hai_san',0,'lau-cay-hai-san.jpg')

insert into Food (idTypeFood,name,price,description,meta,hide,img) values (4,N'Nước dưa hấu',10000,N'Nước được ép từ dưa hấu tươi ngon nhất Việt Nam','nuoc_dua_hau',0,'nuoc_dua_hau.jpg')
,(4,N'Rượu Him Soju nho',10000,N'Rượu Soju Jinro Nho Xanh không chỉ là đồ uống giải khát ngon mát, nhẹ nhàng','Ruou_Him_Soju_nho',0,'18104_Ruou_Him_Soju_nho_1_1.png')
,(4,N'Mocktail táo',10000,N'Mocktail táo là sự bổ sung hoàn hảo cho bất kỳ chế độ ăn kiêng nào, nó siêu sảng khoái và ngon','mocktail_tao',0,'mocktail_tao.jpg')
