USE master
GO
 
CREATE LOGIN CarDealer WITH PASSWORD='cardealer123'
GO

USE CarDealershipDB
GO
 
CREATE USER CarDealer FOR LOGIN CarDealer
GO

Grant Execute On GetAllCars To CarDealer
Grant Execute On GetFeaturedCars To CarDealer
Grant Execute On SelectAllCars To CarDealer
Grant Execute On SelectNewCars To CarDealer
Grant Execute On SelectUsedCars To CarDealer
Grant Execute On GetCarByID To CarDealer
Grant Execute On GetSpecials To CarDealer
Grant Execute On PurchaseEntry To CarDealer
Grant Execute On CarEntry To CarDealer
Grant Execute On CarEdit To CarDealer
Grant Execute On CreateMake To CarDealer
Grant Execute On CreateModel To CarDealer
Grant Execute On CreateSpecial To CarDealer
Grant Execute On SalesReport To CarDealer
Grant Execute On NewInventoryReport To CarDealer
Grant Execute On UsedInventoryReport To CarDealer
Grant Execute On DeleteCar To CarDealer
Grant Execute On UpdateCarInventory To CarDealer
Grant Execute On GetMakes To CarDealer
Grant Execute On GetModels To CarDealer
Grant Execute On InsertCarBodyStyle To CarDealer
Grant Execute On InsertCarType To CarDealer
Grant Execute On InsertCarColor To CarDealer
Grant Execute On InsertCarInterior To CarDealer
Grant Execute On GetMdls To CarDealer
Grant Execute On DeleteCarBodyStyle To CarDealer
Grant Execute On DeleteCarType To CarDealer
Grant Execute On DeleteCarColor To CarDealer
Grant Execute On DeleteCarInterior To CarDealer
Grant Execute On MakeReport To CarDealer
Grant Execute On ModelReport To CarDealer
Grant Execute On DeleteSpecial To CarDealer
