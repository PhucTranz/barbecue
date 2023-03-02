

create table MenuBar(
	idMenuBar int primary key,
	name nvarchar(100),
	link nvarchar(MAX),
	meta nvarchar(100),
	hide bit,
	[order] int,
	datebegin smalldatetime
)
INSERT INTO MenuBar
VALUES (1,N'HOME', '','',0,'1',2023/02/19)
INSERT INTO MenuBar
VALUES (2,N'MENU', '','',0,'2',2023/02/19)
INSERT INTO MenuBar
VALUES (3,N'ABOUT', '','',0,'3',2023/02/19)
INSERT INTO MenuBar
VALUES (4,N'BOOK TABLE', '','',0,'4',2023/02/19)



create table SlidesShow(
	idSlidesShow int primary key,
	title nvarchar(100),
	description nvarchar(300),
	link nvarchar(MAX),
	meta nvarchar(100),
	hide bit,
	[order] int,
	datebegin smalldatetime
)

INSERT INTO SlidesShow
VALUES (1,'Dinning & Drinking Restaurant', 'Doloremque, itaque aperiam facilis rerum, commodi, temporibus sapiente ad mollitia laborum quam quisquam esse error unde.', '','',0,'1',2023/02/19)
INSERT INTO SlidesShow
VALUES (2,'Fast Food Restaurant', 'Doloremque, itaque aperiam facilis rerum, commodi, temporibus sapiente ad mollitia laborum quam quisquam esse error unde. Tempora ex doloremque, labore, sunt repellat dolore, iste magni quos nihil ducimus libero ipsam.', '','',0,'2',2023/02/19)

create table Banner(
	idBanner int primary key,
	name nvarchar(100),
	meta nvarchar(100),
	hide bit,
	[order] int,
	datebegin smalldatetime
)

INSERT INTO Banner  values (1,'banner1','','','','')

create table Footer(
	idFooter int primary key,
	name nvarchar(100),
	intro nvarchar(1000),
	address nvarchar(1000),
	email nvarchar(100),
	sdt nvarchar(100),
	meta nvarchar(100),
	hide bit,
	[order] int,
	datebegin smalldatetime
)

Insert into Footer values (1,'','Tech4Life','So 28, duong 81, Quan 7, Tp HCM','tech4life@gmail.com', '0123456789','', '', '')

create table TypeFood(
	idTypeFood int primary key,
	name varchar(100),
	meta nvarchar(100),
	hide bit,
)

Insert into TypeFood values(1,'Food','',''),(2,'Drink','','')

create table Food(
	idFood int primary key,
	idTypeFood int,
	name nvarchar(100),
	price nvarchar(100),
	description nvarchar(1000),
	meta nvarchar(100),
	hide bit,
	
	foreign key (idTypeFood) references TypeFood(idTypeFood)

)




create table Account(
	idAcc int primary key,
	username nvarchar(100),
	password nvarchar(100),
)

insert into Account values(1,'admin','123456')

create table Tablee(
	idTable int primary key,
	name nvarchar(100),
)

insert into Tablee values (1,'Ban 1'), (2,'Ban 2'), (3,'Ban 3'), (4,'Ban 4')

create table Statuss(
	idStatus int primary key,
	timeBegin smalldatetime,
	timeFinish smalldatetime,
	statusDone nvarchar(100)
)
create table Bill(
	idBill int primary key,
	idAcc int,
	idTable int,
	idStatus int,

	total nvarchar(100),
	meta nvarchar(100),
	hide bit,

	foreign key (idAcc) references Account(idAcc),
	foreign key (idTable) references Tablee(idTable),
	foreign key (idStatus) references Statuss(idStatus)
)

create table DetailBill(
	idBill int primary key,
	idFood int,
	foreign key (idBill) references Bill(idBill),
	foreign key (idFood) references Food(idFood),
	quanlity nvarchar(100)

)
