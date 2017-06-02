--Database Creation

Use master
Go

If Exists(Select * from sys.databases Where name = 'CarDealershipDB')
	Drop Database CarDealershipDB
Go

Create Database CarDealershipDB
Go

Use CarDealershipDB
Go

If Exists(Select * from sys.tables Where name = 'Transmissions')
	Drop Table Transmissions
Go

CREATE TABLE Transmissions (
	TransmissionID int identity(1,1) not null primary key,
	Name varchar(20) not null
)
Go

If Exists(Select * from sys.tables Where name = 'Makes')
	Drop Table Makes
Go

CREATE TABLE Makes (
	MakeID int identity(1,1) not null primary key,
	Name varchar(30) not null,
	[Date] datetime null,
	[User] varchar(50) null,
)

If Exists(Select * from sys.tables Where name = 'Models')
	Drop Table Models
Go

CREATE TABLE Models (
	ModelID int identity(1,1) not null primary key,
	Name varchar(30) not null,
	MakeID int null foreign key references Makes(MakeID),
	[Date] datetime null,
	[User] varchar(50) null,
)

If Exists(Select * from sys.tables Where name = 'Cars')
	Drop Table Cars
Go

CREATE TABLE Cars (
	CarID int identity(1,1) not null primary key,
	MakeID int not null foreign key references Makes(MakeID),
	ModelID int not null foreign key references Models(ModelID),
	Mileage int null,
	VIN varchar(17) null,
	Price decimal null,
	MSRP decimal,
	[Year] int null,
	Picture varchar(400),
	[Description] varchar(1000),
	Stock int null,
	TransmissionID int null foreign key references Transmissions(TransmissionID),
	Featured bit null
)
Go

If Exists(Select * from sys.tables Where name = 'BodyStyles')
	Drop Table BodyStyles
Go

CREATE TABLE BodyStyles (
	BodyStyleID int identity(1,1) not null primary key,
	Style varchar(15) null
)

If Exists(Select * from sys.tables Where name = 'Color')
	Drop Table Color
Go

CREATE TABLE Colors (
	ColorID int identity(1,1) not null primary key,
	Name varchar(20) not null
)
Go

If Exists(Select * from sys.tables Where name = 'Interiors')
	Drop Table Interiors
Go

CREATE TABLE Interiors (
	InteriorID int identity(1,1) not null primary key,
	Name varchar(20) not null
)
Go

If Exists(Select * from sys.tables Where name = 'Types')
	Drop Table [Types]
Go

CREATE TABLE [Types] (
	TypeID int identity(1,1) not null primary key,
	Name varchar(20) not null
)
Go

If Exists(Select * from sys.tables Where name = 'CarBodyStyles')
	Drop Table CarBodyStyles
Go

CREATE TABLE CarBodyStyles (
  CarID int not null foreign key references Cars(CarID),
  BodyStyleID int not null foreign key references BodyStyles(BodyStyleID),
  PRIMARY KEY (CarID, BodyStyleID)
);
Go

If Exists(Select * from sys.tables Where name = 'CarTypes')
	Drop Table CarTypes
Go

CREATE TABLE CarTypes (
  CarID int not null foreign key references Cars(CarID),
  TypeID int not null foreign key references [Types](TypeID),
  PRIMARY KEY (CarID, TypeID)
);
Go

If Exists(Select * from sys.tables Where name = 'CarColors')
	Drop Table CarColors
Go

CREATE TABLE CarColors (
  CarID int not null foreign key references Cars(CarID),
  ColorID int not null foreign key references Colors(ColorID),
  PRIMARY KEY (CarID, ColorID)
);
Go

If Exists(Select * from sys.tables Where name = 'CarInteriors')
	Drop Table CarInteriors
Go

CREATE TABLE CarInteriors (
  CarID int not null foreign key references Cars(CarID),
  InteriorID int not null foreign key references Interiors(InteriorID),
  PRIMARY KEY (CarID, InteriorID)
);
Go

If Exists(Select * from sys.tables Where name = 'Specials')
	Drop Table Specials
Go

CREATE TABLE Specials (
  SpecialID int identity(1,1) not null primary key,
  Title varchar(100) null,
  [Message] varchar(1000) null,
  ImagePath varchar(400) null
);
Go

If Exists(Select * from sys.tables Where name = 'Purchases')
	Drop Table Purchases
Go

CREATE TABLE Purchases(
	PurchaseID int identity(1,1) not null primary key,
	CarID int null foreign key references Cars(CarID),
	[Name] varchar(50) null,
	Phone int null,
	Email varchar(100) null,
	Street1 varchar(200) null,
	Street2 varchar(200) null,
	City varchar(50) null,
	[State] varchar(2) null,
	Zipcode int null,
	PurchasePrice decimal null,
	PurchaseType varchar(20),
	[Date] datetime,
	PiecesSold int,
	[User] varchar(50)
)

--Data Insertion

Insert into Transmissions(Name)
Values ('Manual')
Go
Insert into Transmissions(Name)
Values ('Automatic')
Go

Insert into Makes(Name, [Date], [User])
Values('Audi', '1/1/2017', 'Ovi')
Go
Insert into Makes(Name, [Date], [User])
Values('Ford', '1/1/2017', 'Ovi')
Go
Insert into Makes(Name, [Date], [User])
Values('Mercedes', '1/1/2017', 'Ovi')
Go

Insert into Models(Name, MakeID, [Date], [User])
Values('A4', 1, '1/1/2017', 'Ovi')
Go
Insert into Models(Name, MakeID, [Date], [User])
Values('A6', 1, '1/1/2017', 'Ovi')
Go
Insert into Models(Name, MakeID, [Date], [User])
Values('A7', 1, '1/1/2017', 'Ovi')
Go
Insert into Models(Name, MakeID, [Date], [User])
Values('A8', 1, '1/1/2017', 'Ovi')
Go
Insert into Models(Name, MakeID, [Date], [User])
Values('Q7', 1, '1/1/2017', 'Ovi')
Go
Insert into Models(Name, MakeID, [Date], [User])
Values('Fusion', 2, '1/1/2017', 'Ovi')
Go
Insert into Models(Name, MakeID, [Date], [User])
Values('F-150', 2, '1/1/2017', 'Ovi')
Go
Insert into Models(Name, MakeID, [Date], [User])
Values('Transit', 2, '1/1/2017', 'Ovi')
Go
Insert into Models(Name, MakeID, [Date], [User])
Values('S-Class', 3, '1/1/2017', 'Ovi')
Go
Insert into Models(Name, MakeID, [Date], [User])
Values('ML', 3, '1/1/2017', 'Ovi')
Go

Insert into Cars(MakeID, ModelID, Mileage, VIN, Price, MSRP, [Year], [Picture], [Description], Stock, TransmissionID, Featured)
Values (1, 1, 50000, '19UYA31581L000000', 20000, 18000, 2013, 'http://media.caranddriver.com/images/media/331369/sorta-a4ordable-all-new-2017-audi-a4-still-starts-under-40000-photo-665220-s-450x274.jpg', 'Most definitions of the term specify that cars are designed to run primarily on roads, to have seating for one to eight people, to typically have four wheels with tyres, and to be constructed principally for the transport of people rather than goods. The year 1886 is regarded as the birth year of the modern car.', 1, 1, 1)
Go
Insert into Cars(MakeID, ModelID, Mileage, VIN, Price, MSRP, [Year], [Picture], [Description], Stock, TransmissionID, Featured)
Values (1, 2, 60000, '19UYA31581L000001', 30000, 28000, 2014, 'http://cdcssl.ibsrv.net/autodata/images/?IMG=USC70AUC021A01300.JPG', 'Most definitions of the term specify that cars are designed to run primarily on roads, to have seating for one to eight people, to typically have four wheels with tyres, and to be constructed principally for the transport of people rather than goods. The year 1886 is regarded as the birth year of the modern car.', 1, 2, 0)
Go
Insert into Cars(MakeID, ModelID, Mileage, VIN, Price, MSRP, [Year], [Picture], [Description], Stock, TransmissionID, Featured)
Values (1, 3, 0, '19UYA31581L000002', 50000, 50000, 2017, 'https://carsintrend.com/wp-content/uploads/2016/01/2017-Audi-A7-facelift-1.jpg', 'Most definitions of the term specify that cars are designed to run primarily on roads, to have seating for one to eight people, to typically have four wheels with tyres, and to be constructed principally for the transport of people rather than goods. The year 1886 is regarded as the birth year of the modern car.', 2, 2, 1)
Go
Insert into Cars(MakeID, ModelID, Mileage, VIN, Price, MSRP, [Year], [Picture], [Description], Stock, TransmissionID, Featured)
Values (1, 4, 0, '19UYA31581L000003', 80000, 80000, 2017, 'https://2.bp.blogspot.com/-EWIjoatnkdw/V1oc0-4JR0I/AAAAAAASK2E/5hyuVSzVoBoMWQ1qnX_5TcVjgyUA05rkACLcB/w800/2018-Audi-A8-Saloon-Carscoops2.jpg', 'Most definitions of the term specify that cars are designed to run primarily on roads, to have seating for one to eight people, to typically have four wheels with tyres, and to be constructed principally for the transport of people rather than goods. The year 1886 is regarded as the birth year of the modern car.', 3, 2, 0)
Go
Insert into Cars(MakeID, ModelID, Mileage, VIN, Price, MSRP, [Year], [Picture], [Description], Stock, TransmissionID, Featured)
Values (1, 5, 100000, '19UYA31581L000004', 90000, 78000, 2013, 'http://media.caranddriver.com/images/06q4/267361/2007-audi-q7-v-12-tdi-photo-8867-s-450x274.jpg', 'Most definitions of the term specify that cars are designed to run primarily on roads, to have seating for one to eight people, to typically have four wheels with tyres, and to be constructed principally for the transport of people rather than goods. The year 1886 is regarded as the birth year of the modern car.', 2, 2, 1)
Go
Insert into Cars(MakeID, ModelID, Mileage, VIN, Price, MSRP, [Year], [Picture], [Description], Stock, TransmissionID, Featured)
Values (2, 6, 0, '19UYA31581L000005', 20000, 20000, 2017, 'http://st.motortrend.com/uploads/sites/5/2016/01/2017-Ford-Fusion-front-three-quarter-021.jpg', 'Most definitions of the term specify that cars are designed to run primarily on roads, to have seating for one to eight people, to typically have four wheels with tyres, and to be constructed principally for the transport of people rather than goods. The year 1886 is regarded as the birth year of the modern car.', 5, 1, 0)
Go
Insert into Cars(MakeID, ModelID, Mileage, VIN, Price, MSRP, [Year], [Picture], [Description], Stock, TransmissionID, Featured)
Values (2, 7, 75000, '19UYA31581L000006', 15000, 12000, 2010, 'http://st.motortrend.com/uploads/sites/10/2016/08/2017-Ford-F-150-STX-front-three-quarter.jpg', 'Most definitions of the term specify that cars are designed to run primarily on roads, to have seating for one to eight people, to typically have four wheels with tyres, and to be constructed principally for the transport of people rather than goods. The year 1886 is regarded as the birth year of the modern car.', 1, 2, 1)
Go
Insert into Cars(MakeID, ModelID, Mileage, VIN, Price, MSRP, [Year], [Picture], [Description], Stock, TransmissionID, Featured)
Values (2, 8, 0, '19UYA31581L000007', 25000, 25000, 2017, 'http://www.ford.com/cmslibs/content/dam/vdm_ford/live/en_us/ford/nameplate/transitcommercial/2017/collections/AddPlanners/17_trn_van_rwb_lr_3qtr_oxwh_356.png/_jcr_content/renditions/cq5dam.web.1280.1280.png', 'Most definitions of the term specify that cars are designed to run primarily on roads, to have seating for one to eight people, to typically have four wheels with tyres, and to be constructed principally for the transport of people rather than goods. The year 1886 is regarded as the birth year of the modern car.', 4, 1, 0)
Go
Insert into Cars(MakeID, ModelID, Mileage, VIN, Price, MSRP, [Year], [Picture], [Description], Stock, TransmissionID, Featured)
Values (3, 9, 0, '19UYA31581L000008', 150000, 150000, 2017, 'https://assets.mbusa.com/vcm/MB/DigitalAssets/Vehicles/ClassLanding/2014/S/Features/2014-S-CLASS-SEDAN-092-CCF-D.jpg', 'Most definitions of the term specify that cars are designed to run primarily on roads, to have seating for one to eight people, to typically have four wheels with tyres, and to be constructed principally for the transport of people rather than goods. The year 1886 is regarded as the birth year of the modern car.', 3, 2, 1)
Go
Insert into Cars(MakeID, ModelID, Mileage, VIN, Price, MSRP, [Year], [Picture], [Description], Stock, TransmissionID, Featured)
Values (3, 10, 150000, '19UYA31581L000009', 80000, 75000, 2009, 'http://www.conceptcarz.com/images/Mercedes-Benz/mercedes-Benz-M_Class-2009-Image-013-1024.jpg', 'Most definitions of the term specify that cars are designed to run primarily on roads, to have seating for one to eight people, to typically have four wheels with tyres, and to be constructed principally for the transport of people rather than goods. The year 1886 is regarded as the birth year of the modern car.', 1, 2, 0)
Go

Insert into BodyStyles(Style)
Values('Sedan')
Go
Insert into BodyStyles(Style)
Values('Hatchback')
Go
Insert into BodyStyles(Style)
Values('SUV')
Go
Insert into BodyStyles(Style)
Values('Van')
Go
Insert into BodyStyles(Style)
Values('Pickup Truck')
Go
Insert into BodyStyles(Style)
Values('Coupe')
Go

Insert into CarBodyStyles(CarID, BodyStyleID)
Values(1,1)
Go
Insert into CarBodyStyles(CarID, BodyStyleID)
Values(2,1)
Go
Insert into CarBodyStyles(CarID, BodyStyleID)
Values(3,2)
Go
Insert into CarBodyStyles(CarID, BodyStyleID)
Values(4,1)
Go
Insert into CarBodyStyles(CarID, BodyStyleID)
Values(5,3)
Go
Insert into CarBodyStyles(CarID, BodyStyleID)
Values(6,1)
Go
Insert into CarBodyStyles(CarID, BodyStyleID)
Values(7,5)
Go
Insert into CarBodyStyles(CarID, BodyStyleID)
Values(8,4)
Go
Insert into CarBodyStyles(CarID, BodyStyleID)
Values(9,1)
Go
Insert into CarBodyStyles(CarID, BodyStyleID)
Values(10,3)
Go

Insert into Colors(Name)
Values('Black')
Go
Insert into Colors(Name)
Values('White')
Go
Insert into Colors(Name)
Values('Red')
Go
Insert into Colors(Name)
Values('Blue')
Go
Insert into Colors(Name)
Values('Silver')
Go

Insert into CarColors(CarID, ColorID)
Values(1,5)
Go
Insert into CarColors(CarID, ColorID)
Values(2,4)
Go
Insert into CarColors(CarID, ColorID)
Values(3,4)
Go
Insert into CarColors(CarID, ColorID)
Values(4,1)
Go
Insert into CarColors(CarID, ColorID)
Values(5,2)
Go
Insert into CarColors(CarID, ColorID)
Values(6,5)
Go
Insert into CarColors(CarID, ColorID)
Values(7,5)
Go
Insert into CarColors(CarID, ColorID)
Values(8,2)
Go
Insert into CarColors(CarID, ColorID)
Values(9,1)
Go
Insert into CarColors(CarID, ColorID)
Values(10,3)
Go

Insert into Interiors(Name)
Values('Black')
Go
Insert into Interiors(Name)
Values('Red')
Go
Insert into Interiors(Name)
Values('Brown')
Go

Insert into CarInteriors(CarID, InteriorID)
Values(1,3)
Go
Insert into CarInteriors(CarID, InteriorID)
Values(2,3)
Go
Insert into CarInteriors(CarID, InteriorID)
Values(3,3)
Go
Insert into CarInteriors(CarID, InteriorID)
Values(4,1)
Go
Insert into CarInteriors(CarID, InteriorID)
Values(5,2)
Go
Insert into CarInteriors(CarID, InteriorID)
Values(6,1)
Go
Insert into CarInteriors(CarID, InteriorID)
Values(7,1)
Go
Insert into CarInteriors(CarID, InteriorID)
Values(8,2)
Go
Insert into CarInteriors(CarID, InteriorID)
Values(9,1)
Go
Insert into CarInteriors(CarID, InteriorID)
Values(10,3)
Go

Insert into [Types](Name)
Values('New')
Go
Insert into [Types](Name)
Values('Used')
Go

Insert into CarTypes(CarID, TypeID)
Values(1,2)
Go
Insert into CarTypes(CarID, TypeID)
Values(2,2)
Go
Insert into CarTypes(CarID, TypeID)
Values(3,1)
Go
Insert into CarTypes(CarID, TypeID)
Values(4,1)
Go
Insert into CarTypes(CarID, TypeID)
Values(5,2)
Go
Insert into CarTypes(CarID, TypeID)
Values(6,1)
Go
Insert into CarTypes(CarID, TypeID)
Values(7,2)
Go
Insert into CarTypes(CarID, TypeID)
Values(8,1)
Go
Insert into CarTypes(CarID, TypeID)
Values(9,1)
Go
Insert into CarTypes(CarID, TypeID)
Values(10,2)
Go

Insert into Specials(Title, [Message], ImagePath)
Values('This is the title','Lorem ipsum dolor sit amet, lorem legendos accusata eum ad, ut mel diam vocent, eu nam semper sententiae. Duo conceptam signiferumque ne, ad tantas volumus mel, ex mutat posse tantas vis. Vel quis accusam periculis an, ei iisque suavitate maiestatis qui. Omnis dicam voluptua mea id. In est affert recteque. Ex nec liber inermis omittantur.', 'http://i2.cdn.cnn.com/cnnnext/dam/assets/160125090613-acura-nsx-super-169.jpg')
Go
Insert into Specials(Title, [Message], ImagePath)
Values('This is the title','Lorem ipsum dolor sit amet, lorem legendos accusata eum ad, ut mel diam vocent, eu nam semper sententiae. Duo conceptam signiferumque ne, ad tantas volumus mel, ex mutat posse tantas vis. Vel quis accusam periculis an, ei iisque suavitate maiestatis qui. Omnis dicam voluptua mea id. In est affert recteque. Ex nec liber inermis omittantur.', 'http://i2.cdn.cnn.com/cnnnext/dam/assets/160125090613-acura-nsx-super-169.jpg')
Go
Insert into Specials(Title, [Message], ImagePath)
Values('This is the title','Lorem ipsum dolor sit amet, lorem legendos accusata eum ad, ut mel diam vocent, eu nam semper sententiae. Duo conceptam signiferumque ne, ad tantas volumus mel, ex mutat posse tantas vis. Vel quis accusam periculis an, ei iisque suavitate maiestatis qui. Omnis dicam voluptua mea id. In est affert recteque. Ex nec liber inermis omittantur.', 'http://i2.cdn.cnn.com/cnnnext/dam/assets/160125090613-acura-nsx-super-169.jpg')
Go
Insert into Specials(Title, [Message], ImagePath)
Values('This is the title','Lorem ipsum dolor sit amet, lorem legendos accusata eum ad, ut mel diam vocent, eu nam semper sententiae. Duo conceptam signiferumque ne, ad tantas volumus mel, ex mutat posse tantas vis. Vel quis accusam periculis an, ei iisque suavitate maiestatis qui. Omnis dicam voluptua mea id. In est affert recteque. Ex nec liber inermis omittantur.', 'http://i2.cdn.cnn.com/cnnnext/dam/assets/160125090613-acura-nsx-super-169.jpg')
Go

Insert into Purchases(CarID, Name, Phone, Email, Street1, City, [State], Zipcode, PurchasePrice, PurchaseType, [Date], PiecesSold, [User])
Values (1, 'Smith', 1234567890, 'smith@car.com', '111 Market Street', 'Louisville', 'KY', 12345, 20000, 'Dealer Finance', '4/11/2017', 1, 'Ovi')
Go
Insert into Purchases(CarID, Name, Phone, Email, Street1, City, [State], Zipcode, PurchasePrice, PurchaseType, [Date], PiecesSold, [User])
Values (3, 'Jones', 1234567890, 'jones@car.com', '111 Main Street', 'Louisville', 'KY', 12345, 30000, 'Dealer Finance', '4/9/2017', 1, 'Simon')
Go
Insert into Purchases(CarID, Name, Phone, Email, Street1, City, [State], Zipcode, PurchasePrice, PurchaseType, [Date], PiecesSold, [User])
Values (1, 'Thompson', 1234567890, 'smith@car.com', '111 Market Street', 'Louisville', 'KY', 12345, 20000, 'Dealer Finance', '4/2/2017', 1, 'John')
Go

--Stored Procedures

Use CarDealershipDB
Go

If Exists(Select * from sys.objects Where name = 'GetAllCars')
Drop Procedure GetAllCars
Go

Create Procedure GetAllCars
As
Select c.CarID, mk.Name as Make, md.Name as Model, c.Mileage, c.Vin, c.Price, c.MSRP, c.[Year], c.[Picture], c.[Description], c.Stock, c.TransmissionID, t.Name as Transmission, bs.BodyStyleID, bs.Style as BodyStyle, cl.ColorID, cl.Name as Color, i.InteriorID, i.Name as Interior
from Cars c
Join CarBodyStyles cbs on c.CarID = cbs.CarID
Join BodyStyles bs on cbs.BodyStyleId = bs.BodyStyleID
Join CarColors cc on c.CarID = cc.CarID
Join Colors cl on cl.ColorID = cc.ColorID
Join CarInteriors ci on ci.CarID = c.CarID
Join Interiors i on i.InteriorID = ci.InteriorID
Join Transmissions t on t.TransmissionID = c.TransmissionID
Join Makes mk on c.MakeID = mk.MakeID
Join Models md on c.ModelID = md.ModelID
Go

If Exists(Select * from sys.objects Where name = 'GetFeaturedCars')
Drop Procedure GetFeaturedCars
Go

Create Procedure GetFeaturedCars
As
Select c.CarID, mk.Name as Make, md.Name as Model, c.Mileage, c.Vin, c.Price, c.MSRP, c.[Year], c.[Picture], c.[Description], c.Stock, c.TransmissionID, t.Name as Transmission, bs.BodyStyleID, bs.Style as BodyStyle, cl.ColorID, cl.Name as Color, i.InteriorID, i.Name as Interior
from Cars c
Join CarBodyStyles cbs on c.CarID = cbs.CarID
Join BodyStyles bs on cbs.BodyStyleId = bs.BodyStyleID
Join CarColors cc on c.CarID = cc.CarID
Join Colors cl on cl.ColorID = cc.ColorID
Join CarInteriors ci on ci.CarID = c.CarID
Join Interiors i on i.InteriorID = ci.InteriorID
Join Transmissions t on t.TransmissionID = c.TransmissionID
Join Makes mk on c.MakeID = mk.MakeID
Join Models md on c.ModelID = md.ModelID
Where c.Featured = 1 and c.Stock > 0
Go

If Exists(Select * from sys.objects Where name = 'SelectAllCars')
Drop Procedure SelectAllCars
Go

Create Procedure SelectAllCars
	@Term varchar(40), @MinPrice decimal, @MaxPrice decimal, @MinYear int, @MaxYear int
As
Select c.CarID, mk.Name as Make, md.Name as Model, c.Mileage, c.Vin, c.Price, c.MSRP, c.[Year], c.[Picture], c.[Description], c.Stock, c.TransmissionID, t.Name as Transmission, bs.BodyStyleID, bs.Style as BodyStyle, cl.ColorID, cl.Name as Color, i.InteriorID, i.Name as Interior
from Cars c
Join CarBodyStyles cbs on c.CarID = cbs.CarID
Join BodyStyles bs on cbs.BodyStyleId = bs.BodyStyleID
Join CarColors cc on c.CarID = cc.CarID
Join Colors cl on cl.ColorID = cc.ColorID
Join CarInteriors ci on ci.CarID = c.CarID
Join Interiors i on i.InteriorID = ci.InteriorID
Join Transmissions t on t.TransmissionID = c.TransmissionID
Join Makes mk on c.MakeID = mk.MakeID
Join Models md on c.ModelID = md.ModelID
Where (mk.Name like '%' + @Term + '%' or md.Name like '%' + @Term + '%' or c.[Year] like '%' + @Term + '%') and (c.Price between @MinPrice and @MaxPrice) and (c.[Year] between @MinYear and @MaxYear) and (c.Stock > 0)
Go

If Exists(Select * from sys.objects Where name = 'SelectNewCars')
Drop Procedure SelectNewCars
Go

Create Procedure SelectNewCars
	@Term varchar(40), @MinPrice decimal, @MaxPrice decimal, @MinYear int, @MaxYear int
As
Select c.CarID, mk.Name as Make, md.Name as Model, c.Mileage, c.Vin, c.Price, c.MSRP, c.[Year], c.[Picture], c.[Description], c.Stock, c.TransmissionID, t.Name as Transmission, bs.BodyStyleID, bs.Style as BodyStyle, cl.ColorID, cl.Name as Color, i.InteriorID, i.Name as Interior
from Cars c
Join CarBodyStyles cbs on c.CarID = cbs.CarID
Join BodyStyles bs on cbs.BodyStyleId = bs.BodyStyleID
Join CarColors cc on c.CarID = cc.CarID
Join Colors cl on cl.ColorID = cc.ColorID
Join CarInteriors ci on ci.CarID = c.CarID
Join Interiors i on i.InteriorID = ci.InteriorID
Join Transmissions t on t.TransmissionID = c.TransmissionID
Join Makes mk on c.MakeID = mk.MakeID
Join Models md on c.ModelID = md.ModelID
Where (mk.Name like '%' + @Term + '%' or md.Name like '%' + @Term + '%' or c.[Year] like '%' + @Term + '%') and (c.Price between @MinPrice and @MaxPrice) and (c.[Year] between @MinYear and @MaxYear) and (c.Mileage = 0) and (c.Stock > 0)
Go

If Exists(Select * from sys.objects Where name = 'SelectUsedCars')
Drop Procedure SelectUsedCars
Go

Create Procedure SelectUsedCars
	@Term varchar(40), @MinPrice decimal, @MaxPrice decimal, @MinYear int, @MaxYear int
As
Select c.CarID, mk.Name as Make, md.Name as Model, c.Mileage, c.Vin, c.Price, c.MSRP, c.[Year], c.[Picture], c.[Description], c.Stock, c.TransmissionID, t.Name as Transmission, bs.BodyStyleID, bs.Style as BodyStyle, cl.ColorID, cl.Name as Color, i.InteriorID, i.Name as Interior
from Cars c
Join CarBodyStyles cbs on c.CarID = cbs.CarID
Join BodyStyles bs on cbs.BodyStyleId = bs.BodyStyleID
Join CarColors cc on c.CarID = cc.CarID
Join Colors cl on cl.ColorID = cc.ColorID
Join CarInteriors ci on ci.CarID = c.CarID
Join Interiors i on i.InteriorID = ci.InteriorID
Join Transmissions t on t.TransmissionID = c.TransmissionID
Join Makes mk on c.MakeID = mk.MakeID
Join Models md on c.ModelID = md.ModelID
Where (mk.Name like '%' + @Term + '%' or md.Name like '%' + @Term + '%' or c.[Year] like '%' + @Term + '%') and (c.Price between @MinPrice and @MaxPrice) and (c.[Year] between @MinYear and @MaxYear) and (c.Mileage > 0) and (c.Stock > 0)
Go

If Exists(Select * from sys.objects Where name = 'GetCarByID')
Drop Procedure GetCarByID
Go

Create Procedure GetCarByID
	@CarID int
As
Select c.CarID, mk.Name as Make, md.Name as Model, c.Mileage, c.Vin, c.Price, c.MSRP, c.[Year], c.[Picture], c.[Description], c.Stock, c.TransmissionID, t.Name as Transmission, bs.BodyStyleID, bs.Style as BodyStyle, cl.ColorID, cl.Name as Color, i.InteriorID, i.Name as Interior
from Cars c
Join CarBodyStyles cbs on c.CarID = cbs.CarID
Join BodyStyles bs on cbs.BodyStyleId = bs.BodyStyleID
Join CarColors cc on c.CarID = cc.CarID
Join Colors cl on cl.ColorID = cc.ColorID
Join CarInteriors ci on ci.CarID = c.CarID
Join Interiors i on i.InteriorID = ci.InteriorID
Join Transmissions t on t.TransmissionID = c.TransmissionID
Join Makes mk on c.MakeID = mk.MakeID
Join Models md on c.ModelID = md.ModelID
Where c.CarID = @CarID
Go

If Exists(Select * from sys.objects Where name = 'GetSpecials')
Drop Procedure GetSpecials
Go

Create Procedure GetSpecials
As
Select * from Specials
Go

If Exists(Select * from sys.objects Where name = 'PurchaseEntry')
Drop Procedure PurchaseEntry
Go

Create procedure PurchaseEntry
	@CarID int, @Name varchar(50), @Phone int, @Email varchar(100), @Street1 varchar(200), @Street2 varchar(200), @City varchar(50), @State varchar(2), @Zipcode int, @PurchasePrice decimal, @PurchaseType varchar(20), @Date datetime, @PiecesSold int, @User varchar(50)
As
Insert into Purchases (CarID, Name, Phone, Email, Street1, Street2, City, [State], Zipcode, PurchasePrice, PurchaseType, [Date], PiecesSold, [User])
Values(@CarID, @Name, @Phone, @Email, @Street1, @Street2, @City, @State, @Zipcode, @PurchasePrice, @PurchaseType, @Date, @PiecesSold, @User)
Go

If Exists(Select * from sys.objects Where name = 'CarEntry')
Drop Procedure CarEntry
Go

Create Procedure CarEntry
	@MakeID int, @ModelID int, @Mileage int, @VIN varchar(17), @Price decimal, @MSRP decimal, @Year int, @Picture varchar(400), @Description varchar(1000), @Stock int, @TransmissionID int, @Featured bit
As
Insert into Cars(MakeID, ModelID, Mileage, VIN, Price, MSRP, [Year], Picture, [Description], Stock, TransmissionID, Featured)
Values (@MakeID, @ModelID, @Mileage, @VIN, @Price, @MSRP, @Year, @Picture, @Description, @Stock, @TransmissionID, @Featured);

SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY];
Go

If Exists(Select * from sys.objects Where name = 'CarEdit')
Drop Procedure CarEdit
Go

Create Procedure CarEdit
	@CarID int, @MakeID int, @ModelID int, @Mileage int, @VIN varchar(17), @Price decimal, @MSRP decimal, @Year int, @Picture varchar(400), @Description varchar(1000), @Stock int, @TransmissionID int, @Featured bit
As
Update Cars
Set MakeID = @MakeID, ModelID = @ModelID, Mileage = @Mileage, VIN = @VIN, Price = @Price, MSRP = @MSRP, [Year] = @Year, Picture = @Picture, [Description] = @Description, Stock = @Stock, TransmissionID = @TransmissionID, Featured = @Featured Where CarID = @CarID
Go

If Exists(Select * from sys.objects Where name = 'CreateMake')
Drop Procedure CreateMake
Go

Create Procedure CreateMake
	@Name varchar(50), @Date datetime, @User varchar(50) 
As
Insert into Makes(Name, [Date], [User])
Values(@Name, @Date, @User)
Go

If Exists(Select * from sys.objects Where name = 'CreateModel')
Drop Procedure CreateModel
Go

Create Procedure CreateModel
	@Name varchar(50), @Date datetime, @User varchar(50), @MakeID int
As
Insert into Models(Name, [Date], [User], MakeID)
Values(@Name, @Date, @User, @MakeID)
Go

If Exists(Select * from sys.objects Where name = 'CreateSpecial')
Drop Procedure CreateSpecial
Go

Create Procedure CreateSpecial
	@Title varchar(50), @Message varchar(1000), @ImagePath varchar(400)
As
Insert into Specials([Message], ImagePath)
Values(@Message, @ImagePath)
Go

If Exists(Select * from sys.objects Where name = 'SalesReport')
Drop Procedure SalesReport
Go

Create Procedure SalesReport
	@User varchar(50), @StartDate datetime, @EndDate datetime
As
Select [User], Sum(PurchasePrice) as TotalSales, Count(CarID) as TotalVehicles from Purchases
Where [User] = @User and [Date] between @StartDate and @EndDate
Group by [User]
Go

If Exists(Select * from sys.objects Where name = 'NewInventoryReport')
Drop Procedure NewInventoryReport
Go

Create Procedure NewInventoryReport
As
Select [Year], mk.Name as Make, md.Name as Model, c.Stock as [Count], Sum(c.Price) as StockValue from Cars c
Join Makes mk on mk.MakeID = c.MakeID
Join Models md on md.ModelID = c.ModelID
Where c.Mileage = 0
Group by [Year], mk.Name, md.Name, c.Stock
Go

If Exists(Select * from sys.objects Where name = 'UsedInventoryReport')
Drop Procedure UsedInventoryReport
Go

Create Procedure UsedInventoryReport
As
Select [Year], mk.Name as Make, md.Name as Model, c.Stock as [Count], Sum(c.Price) as StockValue from Cars c
Join Makes mk on mk.MakeID = c.MakeID
Join Models md on md.ModelID = c.ModelID
Where c.Mileage > 0
Group by [Year], mk.Name, md.Name, c.Stock
Go

If Exists(Select * from sys.objects Where name = 'DeleteCar')
Drop Procedure DeleteCar
Go

Create procedure DeleteCar
	@CarID int
As
Delete from Cars Where CarID = @CarID
Go

If Exists(Select * from sys.objects Where name = 'UpdateCarInventory')
Drop Procedure UpdateCarInventory
Go

Create procedure UpdateCarInventory
	@CarID int
As
Update Cars
Set Stock = Stock - 1 Where CarID = @CarID
Go

If Exists(Select * from sys.objects Where name = 'GetMakes')
Drop Procedure GetMakes
Go

Create Procedure GetMakes
As
Select * from Makes
Go

If Exists(Select * from sys.objects Where name = 'GetModels')
Drop Procedure GetModels
Go

Create Procedure GetModels
	@MakeID int
As
Select * from Models Where MakeID = @MakeID
Go

If Exists(Select * from sys.objects Where name = 'GetMdls')
Drop Procedure GetMdls
Go

Create Procedure GetMdls
	@Model varchar(50)
As
Select md.Name, md.ModelID from Models md
Join Makes mk on mk.MakeID = md.MakeID
Where mk.Name = 'Audi'
Go

If Exists(Select * from sys.objects Where name = 'InsertCarBodyStyle')
Drop Procedure InsertCarBodyStyle
Go

Create Procedure InsertCarBodyStyle
	@CarID int, @BodyStyleID int
As
Insert into CarBodyStyles(CarID, BodyStyleID)
Values(@CarID, @BodyStyleID)
Go

If Exists(Select * from sys.objects Where name = 'InsertCarType')
Drop Procedure InsertCarType
Go

Create Procedure InsertCarType
	@CarID int, @TypeID int
As
Insert into CarTypes(CarID, TypeID)
Values(@CarID, @TypeID)
Go

If Exists(Select * from sys.objects Where name = 'InsertCarColor')
Drop Procedure InsertCarColor
Go

Create Procedure InsertCarColor
	@CarID int, @ColorID int
As
Insert into CarColors(CarID, ColorID)
Values(@CarID, @ColorID)
Go

If Exists(Select * from sys.objects Where name = 'InsertCarInterior')
Drop Procedure InsertCarInterior
Go

Create Procedure InsertCarInterior
	@CarID int, @InteriorID int
As
Insert into CarInteriors(CarID, InteriorID)
Values(@CarID, @InteriorID)
Go

If Exists(Select * from sys.objects Where name = 'DeleteCarBodyStyle')
Drop Procedure DeleteCarBodyStyle
Go

Create Procedure DeleteCarBodyStyle
	@CarID int
As
Delete from CarBodyStyles Where CarID = @CarID
Go

If Exists(Select * from sys.objects Where name = 'DeleteCarType')
Drop Procedure DeleteCarType
Go

Create Procedure DeleteCarType
	@CarID int
As
Delete from CarTypes Where CarID = @CarID
Go

If Exists(Select * from sys.objects Where name = 'DeleteCarColor')
Drop Procedure DeleteCarColor
Go

Create Procedure DeleteCarColor
	@CarID int
As
Delete from CarColors Where CarID = @CarID
Go

If Exists(Select * from sys.objects Where name = 'DeleteCarInterior')
Drop Procedure DeleteCarInterior
Go

Create Procedure DeleteCarInterior
	@CarID int
As
Delete from CarInteriors Where CarID = @CarID
Go

If Exists(Select * from sys.objects Where name = 'MakeReport')
Drop Procedure MakeReport
Go

Create Procedure MakeReport
As
Select * from Makes
Go

If Exists(Select * from sys.objects Where name = 'ModelReport')
Drop Procedure ModelReport
Go

Create Procedure ModelReport
As
Select md.Name, md.[Date], md.[User], mk.Name as Make from Models md
Join Makes mk on mk.MakeID = md.MakeID
Go

If Exists(Select * from sys.objects Where name = 'DeleteSpecial')
Drop Procedure DeleteSpecial
Go

Create Procedure DeleteSpecial
	@SpecialID int
As
Delete from Specials where SpecialID = @SpecialID
Go

