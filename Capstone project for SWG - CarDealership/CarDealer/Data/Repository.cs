using CarDealer.Controllers;
using CarDealer.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarDealer.Data
{
    public class Repository
    {
        public List<Car> GetFeaturedCars()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                return cn.Query<Car>("GetFeaturedCars", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Car> SelectNewCars(CarSearchModel car)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@Term", car.Term);
                parameters.Add("@MinPrice", car.MinPrice);
                parameters.Add("@MaxPrice", car.MaxPrice);
                parameters.Add("@MinYear", car.MinYear);
                parameters.Add("@MaxYear", car.MaxYear);

                return cn.Query<Car>("SelectNewCars", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Car> SelectUsedCars(CarSearchModel car)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@Term", car.Term);
                parameters.Add("@MinPrice", car.MinPrice);
                parameters.Add("@MaxPrice", car.MaxPrice);
                parameters.Add("@MinYear", car.MinYear);
                parameters.Add("@MaxYear", car.MaxYear);

                return cn.Query<Car>("SelectUsedCars", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Car> SelectAllCars(CarSearchModel car)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@Term", car.Term);
                parameters.Add("@MinPrice", car.MinPrice);
                parameters.Add("@MaxPrice", car.MaxPrice);
                parameters.Add("@MinYear", car.MinYear);
                parameters.Add("@MaxYear", car.MaxYear);

                return cn.Query<Car>("SelectAllCars", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Car GetCarByID(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", id);

                return cn.Query<Car>("GetCarByID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Special> GetSpecials()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                return cn.Query<Special>("GetSpecials", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void PurchaseEntry(Purchase purchase)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", purchase.CarID);
                parameters.Add("@Name", purchase.Name);
                parameters.Add("@Phone", purchase.Phone);
                parameters.Add("@Email", purchase.Email);
                parameters.Add("@Street1", purchase.Street1);
                parameters.Add("@Street2", purchase.Street2);
                parameters.Add("@City", purchase.City);
                parameters.Add("@State", purchase.State);
                parameters.Add("@Zipcode", purchase.Zipcode);
                parameters.Add("@PurchasePrice", purchase.PurchasePrice);
                parameters.Add("@PurchaseType", purchase.PurchaseType);
                parameters.Add("@Date", purchase.Date);
                parameters.Add("@PiecesSold", purchase.PiecesSold);
                parameters.Add("@User", purchase.User);

                cn.Execute("PurchaseEntry", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateCarInventory(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", id);

                cn.Execute("UpdateCarInventory", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int CarEntry(Car car)
        {
            int carId;

            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();
                
                parameters.Add("@MakeID", car.MakeID);
                parameters.Add("@ModelID", car.ModelID);
                parameters.Add("@Mileage", car.Mileage);
                parameters.Add("@VIN", car.VIN);
                parameters.Add("@Price", car.Price);
                parameters.Add("@MSRP", car.MSRP);
                parameters.Add("@Year", car.Year);
                parameters.Add("@Picture", car.Picture);
                parameters.Add("@Description", car.Description);
                parameters.Add("@Stock", car.Stock);
                parameters.Add("@TransmissionID", car.TransmissionID);
                parameters.Add("@Featured", car.Featured);

                carId = cn.Query<int>("CarEntry", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return carId;
        }

        public List<MakeModel> GetMakes()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                return cn.Query<MakeModel>("GetMakes", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ModelModel> GetModels(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@MakeID", id);

                return cn.Query<ModelModel>("GetModels", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ModelModel> GetMdls(string id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@Model", id);

                return cn.Query<ModelModel>("GetMdls", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void InsertCarBodyStyle(int carID, int bodyStyleID)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", carID);

                parameters.Add("@BodyStyleID", bodyStyleID);

                cn.Execute("InsertCarBodyStyle", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertCarType(int carID, int typeID)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", carID);

                parameters.Add("@TypeID", typeID);

                cn.Execute("InsertCarType", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertCarColor(int carID, int colorID)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", carID);

                parameters.Add("@ColorID", colorID);

                cn.Execute("InsertCarColor", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertCarInterior(int carID, int interiorID)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", carID);

                parameters.Add("@InteriorID", interiorID);

                cn.Execute("InsertCarInterior", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCarBodyStyle(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", id);

                cn.Execute("DeleteCarBodyStyle", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCarType(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", id);

                cn.Execute("DeleteCarType", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCarColor(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", id);

                cn.Execute("DeleteCarColor", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCarInterior(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", id);

                cn.Execute("DeleteCarInterior", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void CarEdit(Car car)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", car.CarID);
                parameters.Add("@MakeID", car.MakeID);
                parameters.Add("@ModelID", car.ModelID);
                parameters.Add("@Mileage", car.Mileage);
                parameters.Add("@VIN", car.VIN);
                parameters.Add("@Price", car.Price);
                parameters.Add("@MSRP", car.MSRP);
                parameters.Add("@Year", car.Year);
                parameters.Add("@Picture", car.Picture);
                parameters.Add("@Description", car.Description);
                parameters.Add("@Stock", car.Stock);
                parameters.Add("@TransmissionID", car.TransmissionID);
                parameters.Add("@Featured", car.Featured);

                cn.Execute("CarEdit", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCar(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@CarID", id);

                cn.Execute("DeleteCar", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<MakeModel> MakeReport()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                return cn.Query<MakeModel>("MakeReport", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ModelModel> ModelReport()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                return cn.Query<ModelModel>("ModelReport", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void CreateMake(MakeModel make)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@Name", make.Name);
                parameters.Add("@Date", make.Date);
                parameters.Add("@User", make.User);

                cn.Execute("CreateMake", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void CreateModel(ModelModel model)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@Name", model.Name);
                parameters.Add("@Date", model.Date);
                parameters.Add("@User", model.User);
                parameters.Add("@MakeID", model.MakeID);

                cn.Execute("CreateModel", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void CreateSpecial(Special special)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@Title", special.Title);
                parameters.Add("@Message", special.Message);
                parameters.Add("@ImagePath", special.ImagePath);

                cn.Execute("CreateSpecial", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteSpecial(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@SpecialID", id);

                cn.Execute("DeleteSpecial", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Report> NewInventoryReport()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                return cn.Query<Report>("NewInventoryReport", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Report> UsedInventoryReport()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                return cn.Query<Report>("UsedInventoryReport", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<SalesReport> SalesReport(SalesReport rep)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@User", rep.User);
                parameters.Add("@StartDate", rep.StartDate);
                parameters.Add("@EndDate", rep.EndDate);

                return cn.Query<SalesReport>("SalesReport", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}