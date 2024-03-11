use FA23_ksemaswad
go

DROP TABLE IF EXISTS SimpleIcecream
go
DROP TABLE IF EXISTS IcecreamSize
go
DROP TABLE IF EXISTS Specials
go
DROP TABLE IF EXISTS PrimaryFlavours
go
DROP TABLE IF EXISTS IcecreamFlavour
go
DROP TABLE IF EXISTS Nutfree
go



Create table Nutfree
(
	NutfreeID int Identity (1,1) Constraint pkNutfreeID primary key,
	Nutfreename varchar(30) not null
)

Insert into Nutfree
(Nutfreename)
values
('Yes'),('No')

CREATE TABLE IcecreamSize
(
	IcecreamSizeID int Identity(1,1) not null Constraint pkIcecreamStyleID primary key,
	IcecreamSizename varchar(30) not null,
	price decimal (6,2) not null
)

Insert into IcecreamSize
(IcecreamSizename, price)
Values
('Pint', '5.99'), ('Quart','11.99'), ('Gallon','22.99')

CREATE TABLE PrimaryFlavours
(
	PrimaryFlavoursID int Identity(1,1) not null Constraint pkPrimaryFlavours primary key,
	PrimaryFlavoursname varchar(30) not null
)

Insert into PrimaryFlavours
(PrimaryFlavoursname)
Values
('Vanilla'), ('Chocolate'), ('Strawberry'), ('Raspberyy'), ('Fruit')

CREATE TABLE Specials
(
	SpecialsID int Identity(1,1) Constraint pkSpecialsID primary key,
	SpecialDay varchar(30) not null
)

Insert into Specials
(SpecialDay)
Values
('Monday'), ('Tuesday'), ('Wednesday'), ('Thursday'), ('Friday'), ('Saturday'), ('Sunday'),('Not special')

CREATE TABLE SimpleIcecream
(
	IcecreamID int Identity(1,1) not null Constraint pkSimpleIcecreamID primary key,
	Icecreamname varchar(30) not null,
	Descriptions varchar(100),
	Imagepath varchar(200) not null,
	IcecreamSizeID int not null Constraint fkSimpleIcecreamID_IcecreamSize foreign key
		references IcecreamSize(IcecreamSizeID),
	PrimaryFlavoursID int not null Constraint fkSimpleIcecreamID_PrimaryFlavours foreign key
		references PrimaryFlavours(PrimaryFlavoursID),
	SpecialsID int Constraint fkSimpleIcecreamID_Specials foreign key
		references Specials(SpecialsID),
	NutfreeID int Constraint fkSimpleIcecreamID_Nutfree foreign key
		references Nutfree(NutfreeID) not null
)


--select * from IcecreamSize
select * from PrimaryFlavours
--select * from Specials
select * from SimpleIcecream
--select * from Nutfree

Drop view if exists viewSimpleIcecream
go
 
CREATE VIEW viewSimpleIcecream as
select IcecreamID,Icecreamname,Descriptions,Imagepath,si.IcecreamSizeID,si.PrimaryFlavoursID,si.SpecialsID,si.NutfreeID,IcecreamSizename,price,PrimaryFlavoursname,Nutfreename,SpecialDay
from SimpleIcecream si JOIN IcecreamSize ics ON  si.IcecreamSizeID = ics.IcecreamSizeID
					   JOIN PrimaryFlavours pf ON  si.PrimaryFlavoursID = pf.PrimaryFlavoursID
					   JOIN Nutfree nf ON si.NutfreeID = nf.NutfreeID
					   LEFT JOIN Specials sp ON si.SpecialsID = sp.SpecialsID			
					   
go

Select * from viewSimpleIcecream
go

Insert into SimpleIcecream
(Icecreamname,Descriptions,Imagepath,IcecreamSizeID,PrimaryFlavoursID,SpecialsID,NutfreeID)
Values
('Chocolate','A rich and dark choclate','/images/choclate ice cream.jpg','2','2','8','1'),
('Rasberry', 'A rich raspberry flavour with chocolate chunks', '/images/raspberry_choclate.jpg' , '2', '4', '8','1'),
('Vanilla','A creamy vanilla ice cream','images\vanilla-ice-cream-cone-glass-sq.jpeg','1','1','2','1'),
('Cookies and creame', 'A mix of vanilla and cookie flavoured ice cream', 'images\cookies-and-cream-ice-cream.jpg' , '3', '1', '1','1'),
('Double Choclate','A rich blend of dark chocolate and milk chocolate','images\choclate_icecream resized.jpg','1','2','5','2')

Select * from viewSimpleIcecream
go

--delete from SimpleIcecream
--where IcecreamID = 1
--go