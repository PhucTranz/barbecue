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


insert into TypeFood (name,meta,hide) values 
	(N'Cơm','com',0),
	('Canh','canh',0),
	(N'Lẩu','lau',0),
	(N'Nước uống','nuoc_uong',0),
	(N'Thịt bò','thit_bo',0),
	(N'Thịt heo','thit_heo',0),
	(N'Hải sản','hai_san',0),
	(N'Món truyền thống','mon_truyen_thong',0),
	(N'Món tráng miệng','mon_trang_mieng',0),
	('Salad','salad',0)

delete from Food
delete from DetailBill
delete from Bill
delete from DetailCart
delete from Cart
insert into Food (idTypeFood,name,price,description,meta,hide,img) values 
	(1,N'Cơm Trắng',10000,N'Cơm được nấu từ gạo ST24 không phụ gia','com_trang',0,'2428_Com_trang_1_2.jpg'),
	(1,N'Cơm trộn bát đá Hàn Quốc sốt Gogi',49000,N'Cơm trộn trong bát đá để giữ được độ nóng mang đến trải nghiệm ấm áp','com_tron_bat_da_han_quoc_sot_gogi',0,'2643_Com_tron_bat_da_han_quoc_sot_gogi_1_2.jpg'),
	(1,N'Cơm trộn bát đá Hàn Quốc',39000,N'Cơm trộn trong bát đá để giữ được độ nóng mang đến trải nghiệm ấm áp','com_tron_bat_da_han_quoc',0,'2968_Com_tron_bat_da_han_quoc_1_2.jpg'),
	(1,N'Cơm cuộn',30000,N'Kimbap là món ăn truyền thống của xứ sở Kim Chi','kim_bap',0,'kimbap.jpg')

insert into Food (idTypeFood,name,price,description,meta,hide,img) values 
	(2,N'Canh kim chi',42000,N'Món canh kim chi đậm đà có độ cay cay từ ớt bột','canh_kim_chi',0,'1377_Canh_kim_chi.jpg'),
	(2,N'Súp nghêu wakame',420000,N'Súp nghêu bổ dưỡng, thơm ngon, màu sắc hấp dẫn','sup_ngheu_wakame',0,'2638_Sup_ngheu_wakame_1_2.jpg'),
	(2,N'Canh tương đậu',40000,N'Canh đậu tương hải sản Hàn Quốc là một món ăn cực kỳ thơm ngon và độc đáo','canh_tuong_dau',0,'canh-tuong-dau_1.jpg'),
	(2,N'Canh thịt bò Bulgogi',50000,N'Canh thịt bò Bulgogi là một ngón ăn đặc trưng của người Hàn Quốc cực kỳ thơm ngon và độc đáo','canh_thit_bo_bulgogi',0,'canh-thit-bo-bulgogi-new.jpg'),
	(2,N'Canh rong biển',30000,N'Canh rong biển truyền thống được sử dụng trong ngày sinh nhật, mang ý nghĩa của sự bình an và sung túc','canh_rong_bien',0,'4883_Canh_rong_bien_1_2.jpg')

insert into Food (idTypeFood,name,price,description,meta,hide,img) values 
	(3,N'Lẩu kim chi',210000,N'Lẩu kim chi Hàn Quốc có vị chua thanh cay nhẹ','lau_kim_chi',0,'4886_Lau_kim_chi_1_2.jpg'),
	(3,N'Lẩu Bulgog',300000,N'Thưởng thức lẩu bò Bulgogi cùng với cơm trắng và kim chi rất hợp vị','lau_bulgog',0,'4885_Lau_Bulgogi_1_2.jpg'),
	(3,N'Lẩu cay hải sản',250000,N'Lẩu Thái chua cay là một trong các món lẩu ngon và mang một hương vị đặc trưng của lẩu hải sản','lau_cay_hai_san',0,'lau-cay-hai-san.jpg'),
	(3,N'Lẩu quân đội',200000,N'Nồi lẩu quân đội Hàn Quốc mang đến sự ấm cúng cho gia đình trong những ngày thời tiết lạnh lẽo.','lau_quan_doi',0,'9760_Lau_quan_doi_1_2.jpg')

insert into Food (idTypeFood,name,price,description,meta,hide,img) values 
	(4,N'Nước dưa hấu',40000,N'Nước được ép từ dưa hấu tươi ngon nhất Việt Nam','nuoc_dua_hau',0,'nuoc_dua_hau.jpg'),
	(4,N'Mocktail táo',50000,N'Mocktail táo là sự bổ sung hoàn hảo cho bất kỳ chế độ ăn kiêng nào, nó siêu sảng khoái và ngon','mocktail_tao',0,'mocktail_tao.jpg'),
	(4,N'Dasani',20000,N'Nước khoáng tinh khiết','nuoc_dasani',0,'989_Dasani_Purified_PET_500ml_1_1.jpg'),
	(4,N'Rượu Vodka',55000,N'Rượu được mệnh danh là nước giải khát ở đất nước ti tỉ dân - Nga','ruou_volka_lg',0,'1014_Ruou_Vodka_Ca_sau_xanh_1_2.jpg'),
	(4,N'Rượu gạo Makgealli Chuối',50000,N'Rượu gạo có màu trắng đục giống nước gạo','ruou_gao_makgealli',0,'1014_Ruou_Vodka_Ca_sau_xanh_1_2.jpg'),
	(4,N'Nước chanh tuoi',30000,N'Được chế biến từ batender với những lát chanh tươi','nuoc_chanh_tuoi',0,'1359_Nuoc_chanh_tuoi_1_1.jpg'),
	(4,N'Nước carot',23000,N'Được chế biến từ batender với những lát cà rốt tươi ','nuoc_ca_rot',0,'1365_Nuoc_ca_rot_1_2.jpg'),
	(4,N'Coca-cola +',210000,N'Thêm một ly coca cho một bữa ăn thêm ngon','nuoc_cocacola_plus',0,'5762_Coca_Cola_Plus_Sleek_Can_320ml_1_1.jpg'),
	(4,N'Coca-cola Light',25000,N'Thêm một ly coca cho một bữa ăn thêm ngon','nuoc_cocacola_light',0,'5766_Coca_Cola_Light_sleek_Can_320ml_1_2.jpg'),
	(4,N'Fanta',210000,N'Nước có ga vị trái cây từ thương hiệu Nhật Fanta','nuoc_fanta',0,'5768_Fanta_Sleek_can_320ml_1_1.jpg'),
	(4,N'Rượu mơ Haruka',800000,N'Được chiết xuất từ những trái mơ chín mọng trên đỉnh núi Phú Sĩ','ruou_haruka',0,'7062_Ruou_mo_Haruka_180_1_1.jpg'),
	(4,N'Rượu HIM Soju vải',500000,N'Sochu được làm từ ngũ cốc như gạo hay các loại bột mì khác như khoai, sắn.','ruou_soju_vai',0,'18026_Ruou_Him_Soju_vai_1_1.png'),
	(4,N'Rượu HIM Soju dưa hấu',500000,N'Sochu được làm từ ngũ cốc như gạo hay các loại bột mì khác như khoai, sắn. Và có hương vị êm dịu, dễ uống.','ruou_soju_dua_hau',0,'18103_Ruou_Him_Soju_dua_hau_1_1.png'),
	(4,	N'Rượu HIM Soju nho',500000,N'Sochu được làm từ ngũ cốc như gạo hay các loại bột mì khác như khoai, sắn','ruou_soju_nho',0,'18104_Ruou_Him_Soju_nho_1_1.png'),
	(4,N'Rượu HIM Soju đào',500000,N'Sochu được làm từ ngũ cốc như gạo hay các loại bột mì khác như khoai, sắn.','ruou_soju_dao',0,'18105_ruou_Him_soju_dao_1_1.png'),
	(4,N'Rượu HIM Soju classic',48000,N'Sochu được làm từ ngũ cốc như gạo hay các loại bột mì khác như khoai, sắn.','ruou_soju_classic',0,'18106_Ruou_Him_soju_classic_1_1.png'),
	(4,N'Heniken',25000,N'Được chiết xuất từng những mẻ lúa mạch nguyên cám trực tiếp từ Đức cho một ly bia mát lạnh.','bia_heniken',0,'bia_heineken_lon_330ml.png'),
	(4,N'Heniken Silver',30000,N'Được chiết xuất từng những mẻ lúa mạch nguyên cám từ Đức cho một ly bia mát lạnh.','bia_heniken',0,'bia_heineken_silver_330ml_1.png'),
	(4,N'Tiger',25000,N'Được lên men trực tiếp từ nhà máy bia số một Việt Nam, hứa hẹn hương vị khó quên.','bia_tiger',0,'bia_tiger_platinum_wheat_lager.png'),
	(4,N'Gogogogi',30000,N'Một dòng sản phẩm mới nhất đến từ thương hiệu Gogi sau bảy bảy bốn tám ngày nghiên cứu.','bia_gogogogi',0,'bia-gogogogi.jpg'),
	(4,N'Xoài mojito',40000,N'Từ dòng nước mojito giải khát nổi tiếng nước mặt trời mọc, kết hợp với những lát xoài','mojito_xoai',0,'xoai-mojito.jpg'),
	(4,N'Phúc bồn tử mojito',40000,N'Từ dòng nước mojito giải khát nổi tiếng nước mặt trời mọc, kết hợp với những quả phúc bồn tử','mojito_phuc_bon_tu',0,'phuc-bon-tu-mojito.jpg'),
	(4,N'Kiwi mojito',40000,N'Từ dòng nước mojito giải khát nổi tiếng nước mặt trời mọc, kết hợp với những miếng kiwi','mojito_kiwi',0,'kiwi-mojito.jpg'),
	(4,N'Mocktail chanh dây',50000,N'Dòng nước siêu giải khát, siêu ngốn thực phẩm với những lát chanh dây','mocktail_chanh_day',0,'mocktail_chanh_day.jpg'),
	(4,N'Mocktail dâu',50000,N'Dòng nước siêu giải khát, siêu ngốn thực phẩm với những quả dâu','mocktail_dau',0,'mocktail_dau.jpg'),
	(4,N'Mocktail táo',50000,N'Dòng nước siêu giải khát, siêu ngốn thực phẩm với những lát táo','mocktail_tao',0,'mocktail_tao.jpg'),
	(4,N'Strongbow dark',30000,N'Với nguyên liệu được giữ trọn độ ngọt, giòn, thơm và sự tươi mới ','strongbow_dark',0,'strongbow-dark-fruit-can-330ml.png'),
	(4,N'Strongbow apple',30000,N'Với nguyên liệu được giữ trọn độ ngọt, giòn, thơm và sự tươi mới ','strongbow_apple',0,'strongbow-gold-apple-can-330ml.png'),
	(4,N'Strongbow peach',30000,N'Với nguyên liệu được giữ trọn độ ngọt, giòn, thơm và sự tươi mới ','strongbow_red_peach',0,'strongbow-peach-can-330ml.png'),
	(4,N'Strongbow red berries',30000,N'Với nguyên liệu giữ trọn độ ngọt, giòn, thơm và sự tươi mới ','strongbow_red_berries',0,'strongbow-red-berries-can-330ml.png')

insert into Food (idTypeFood,name,price,description,meta,hide,img) values 
	(5,N'Ba chỉ bò mật ong',210000,N'Ba chỉ bò trong ngày, tươi mới','thit_bo_ba_chi_mat_ong',0,'2506_Ba_Chi_Bo_My_Sot_Mat_Ong_1_2.jpg'),
	(5,N'Dẻ sườn bỏ đặc biệt',180000,N'Dẻ sườn bò trong ngày, tươi mới','thit_de_suon_bo_dac_biet',0,'2514_De_suon_bo_My_sot_dac_biet_1_1.jpg'),
	(5,N'Dẻ sườn bỏ dầu mè',230000,N'Dẻ sườn bò trong ngày, tươi mới','thit_de_suon_bo_dau_me',0,'2515_De_suon_bo_My_sot_dau_me_1_1.jpg'),
	(5,N'Gầu bò sốt mật ong',320000,N'Gầu bò bò trong ngày, tươi mới','thit_bo_gau_bo_mat_ong',0,'2518_Gau_bo_My_sot_mat_ong_1_1.jpg'),
	(5,N'Thăn vai bò sốt Galbi',250000,N'Thăn vai bò trong ngày, tươi mới','thit_bo_than_vai_bo_galbi',0,'2524_Than_vai_bo_My_sot_Galbi_1_2.jpg'),
	(5,N'Ba chỉ bò cuộn',1900000,N'Ba chỉ bò trong ngày, tươi mới','thit_bo_ba_chi_bo_cuon',0,'2525_Ba_chi_bo_my_cuon_1_2.jpg'),
	(5,N'Nậm bò Mỹ',200000,N'Nậm bò trong ngày, tươi mới','thit_bo_nam_bo_my',0,'5085_Nam_bo_My_1_2.jpg'),
	(5,N'Combo A lớn',590000,N'Thịt bò trong ngày, tươi mới','thit_bo_combo_a_lon',0,'combo_hao_hang_than_ngoai_mong_bo_angus_lon.jpg'),
	(5,N'Combo A nhỏ',300000,N'Thịt bò trong ngày, tươi mới','thit_bo_combo_a_nho',0,'combo_hao_hang_than_ngoai_mong_bo_angus_nho.jpg'),
	(5,N'Combo B lớn',590000,N'Thịt bò trong ngày, tươi mới','thit_bo_combo_B_nho',0,'combo_thuong_hang_nac_lung_than_ngoai_bo_angus_lon.jpg'),
	(5,N'Combo B nhỏ',300000,N'Thịt bò trong ngày, tươi mới','thit_bo_combo_B_nho',0,'combo_thuong_hang_nac_lung_than_ngoai_bo_angus_nho.jpg')

insert into Food (idTypeFood,name,price,description,meta,hide,img) values 
	(6,N'Sườn heo nướng Galbi',150000,N'Thịt nóng từ nông dân miền Tây','thit_heo_suong_heo_galbi',0,'2403_Suon_heo_sot_Galbi_1_2.jpg'),
	(6,N'Nạt vai heo nướng Galbi',150000,N'Thịt nóng từ nông dân miền Tây','thit_heo_nat_vai_heo_galbi',0,'2404_Nac_vai_heo_sot_Galbi_1_2.jpg'),
	(6,N'Xương sụn heo Obathan',1900000,N'Thịt nóng từ nông dân miền Tây','thit_heo_xuong_suon_heo_galbi',0,'2416_Suon_sun_heo_sot_Obathan_1_1.jpg'),
	(6,N'Ba chi heo tươi',200000,N'Thịt nóng từ nông dân miền Tây','thit_heo_ba_chi_heo_tuoi',0,'2521_Ba_chi_heo_tuoi_1_2.jpg'),
	(6,N'Nạc vai heo sốt tương đậu',230000,N'Thịt nóng từ nông dân miền Tây','thit_heo_nac_vai_heo_tuong_dau',0,'nac_vai_heo_u_sot_tuong_dau.jpg'),
	(6,N'Nạc vai heo sốt daualc',230000,N'Thịt nóng từ nông dân miền Tây','thit_heo_nac_vai_heo_daualc',0,'nac-vai-heo-tuong-daualc_3.jpg'),
	(6,N'Thịt heo đặc biệt',300000,N'Thịt nóng từ nông dân miền Tây','thit_heo_dac_biet',0,'thit_heo_dac_biet_1.jpg')


insert into Food (idTypeFood,name,price,description,meta,hide,img) values 
	(7,N'Bạch tuộc Karubi',200000,N'Những mẻ hải sản tươi từ ban mai vùng vịnh miền Trung','hai_san_bach_tuoc_baby',0,'bach-tuoc-baby-sot-karubi-cay.jpg'),
	(7,N'Bạch tuộc sốt cay',200000,N'Những mẻ hải sản tươi từ ban mai vùng vịnh miền Trung','hai_san_bach_tuoc_cay',0,'bach-tuoc-dai-duong-sot-cay-dac-biet.jpg')
	
	
insert into Food (idTypeFood,name,price,description,meta,hide,img) values 
	(8,N'Mỳ lạnh trộn',49000,N'Từ những nguyên liệu truyền thống Hàn Quốc','mtt_my_tron',0,'2419_My_lanh_tron_cay_1_1.jpg'),
	(8,N'Tokboki',29000,N'Từ những nguyên liệu truyền thống Hàn Quốc','mtt_tokboki_hai_san',0,'2421_Tokboki_xao_hai_san_1_1.jpg'),
	(8,N'Há cảo',39000,N'Từ những nguyên liệu truyền thống Hàn Quốc','mtt_ha_cao',0,'2424_Ha_cao_truyen_thong_han_quoc_1_1.jpg'),
	(8,N'Bánh xèo hải sản',60000,N'Từ những nguyên liệu truyền thống Việt Nam','mtt_banh_xeo',0,'2630_Banh_xeo_hai_san_Gogi_1_2.jpg'),
	(8,N'Mỳ Jajang',59000,N'Từ những nguyên liệu truyền thống Nhật Bản','mtt_my_jajang',0,'2969_Mi_Jajang_1_2.jpg'),
	(8,N'Kimbap chiên',21000,N'Từ những nguyên liệu truyền thống Hàn Quốc','mtt_kimbap_chien',0,'4606_Kimbap_chien_1_2.jpg'),
	(8,N'Mỳ lạnh nước',500000,N'Từ những nguyên liệu truyền thống Hàn Quốc','mtt_my_lanh_nuoc',0,'my_lanh_nuoc.jpg'),
	(8,N'Tokpokki phô mai',29000,N'Từ những nguyên liệu truyền thống Hàn Quốc','mtt_tokpokki',0,'tokpokki-nhan-pho-mai.jpg')
	

insert into Food (idTypeFood,name,price,description,meta,hide,img) values 
	(9,N'Bánh Caremal',39000,N'Sự hoà hợp khẩu vị Á và Âu','mtm_banh_caremal',0,'2567_Banh_caramel_1_2.jpg'),
	(9,N'Dưa hấu',40000,N'Vua nhiệt đới, ông trùm của giải khát trái cây','mtm_dua_hau',0,'dua_hau.jpg'),
	(9,N'Kem',20000,N'Thanh nhiệt mùa hè, giải nhiệt mùa đông','mtm_kem_vani',0,'kem_vani_2.jpg'),
	(9,N'Kem vani',20000,N'Thanh nhiệt mùa hè, giải nhiệt mùa đông','mtm_kem_vani',0,'kem_vien_dau_sua.jpg'),
	(9,N'Kem socola',20000,N'Thanh nhiệt mùa hè, giải nhiệt mùa đông','mtm_kem_vani',0,'kem_vien_so_co_la.jpg'),
	(9,N'Kem dừa',20000,N'Thanh nhiệt mùa hè, giải nhiệt mùa đông','mtm_kem_vani',0,'kem_vien_sua_dua.jpg'),
	(9,N'Khăn lạnh',20000,N'Khăn lạnh Babercue','khan_lanh',0,'khan_lanh_golden_gate.jpg'),
	(9,N'Panna chanh dây',39000,N'Món tráng miệng tuyệt ngon từ nhà hàng chúng tôi','mtm_panna_',0,'panna_cotta_chanh_day_2.jpg'),
	(9,N'Panna dâu',39000,N'Món tráng miệng tuyệt ngon từ nhà hàng chúng tôi','mtm_panna_',0,'panna_cotta_dau_2.jpg'),
	(9,N'Panna đậu',39000,N'Món tráng miệng tuyệt ngon từ nhà hàng chúng tôi','mtm_panna_',0,'panna_cotta_dau_rung_2.jpg'),
	(9,N'Panna kiwi',39000,N'Món tráng miệng tuyệt ngon từ nhà hàng chúng tôi','mtm_panna_',0,'panna_cotta_kiwi_2.jpg')

insert into Food (idTypeFood,name,price,description,meta,hide,img) values 
	(10,N'Salad cá ngừ',100000,N'Từ những nguyên liệu tươi hằng tuần','salad_ca_ngu',0,'2620_Salad_ca_ngu_1_2.jpg'),
	(10,N'Salad hoa quả tươi',99000,N'Từ những nguyên liệu tươi hằng tuần','salad_ca_ngu',0,'2621_Salad_hoa_qua_tuoi_1_2.jpg'),
	(10,N'Salad mùa xuân',99000,N'Từ những nguyên liệu tươi hằng tuần','salad_ca_ngu',0,'9788_Salad_mua_xuan_1_2.jpg'),
	(10,N'Salad tổng hợp',150000,N'Từ những nguyên liệu tươi hằng tuần','salad_ca_ngu',0,'salad_tong_hop.jpg'),
	(10,N'Salad củ sen',90000,N'Từ những nguyên liệu tươi hằng tuần','salad_ca_ngu',0,'salad-cu-sen-new.jpg'),
	(10,N'Salad Babercue',179000,N'Từ những nguyên liệu tươi hằng tuần','salad_ca_ngu',0,'salad-tong-hop-new.jpg')
	
