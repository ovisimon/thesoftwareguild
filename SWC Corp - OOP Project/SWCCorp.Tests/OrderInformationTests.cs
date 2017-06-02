using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWCCorp.Models;
using SWCCorp.Data;
using System.IO;

namespace SWCCorp.Tests
{
    [TestFixture]
    class OrderInformationTests
    {
        private Order order;
        private string path = "C:\\Users\\Ovi\\Documents\\the software guild\\c sharp\bitbucket\\ovi-simon-individual-work\\SWC Corp\\Repositories\\Orders_612013.txt";

        [SetUp]
        public void SetupOrder()
        {
            order = new Order()
            {
                CostumerName = "ovi",
                State = "MI",
                ProductType = "Wood",
                Area = 100
            };
        }

        [Test]
        public void CanReadProductInformation()
        {
            TaxInformationRepository taxRepo = new TaxInformationRepository();
            ProductInformationRepository prodRepo = new ProductInformationRepository();

            var productInfo = prodRepo.GetProducts().Where(x => x.ProductType.ToLower() == order.ProductType.ToLower()).FirstOrDefault();
            order.LaborCostPerSquareFoot = productInfo.LaborCostPerSquareFoot;
            order.CostPerSquareFoot = productInfo.CostPerSquareFoot;

            var taxInfo = taxRepo.GetRates().Where(x => x.StateShort.ToLower() == order.State.ToLower()).First();

            order.TaxRate = taxInfo.Rate;

            Assert.AreEqual(order.TaxRate, 5.75m);
            Assert.AreEqual(order.CostPerSquareFoot, 5.15m);
            Assert.AreEqual(order.LaborCostPerSquareFoot, 4.75m);
        }

        [Test]
        public void CanLoadOrder()
        {
            TestRepository repo = new TestRepository();

            Order orderToLoad = repo.LoadOrder(path, 12345);

            Assert.AreEqual(orderToLoad.CostumerName, "Ovi Simon");
            Assert.AreEqual(orderToLoad.OrderNumber, 12345);
        }

        [Test]
        public void CanAddOrder()
        {
            TestRepository repo = new TestRepository();
            repo.AddOrder(order, path);

            Assert.AreEqual(repo.GetAllOrders().Count, 5);

        }

        [Test]
        public void CanEditOrder()
        {
            TaxInformationRepository taxRepo = new TaxInformationRepository();
            ProductInformationRepository prodRepo = new ProductInformationRepository();
            TestRepository repo = new TestRepository();

            Order orderToEdit = new Order()
            {
                CostumerName = "Johnny",
                State = "PA",
                ProductType = "Tile",
                Area = 100
            };

            repo.EditOrder(orderToEdit, 23456, path);

            Assert.AreEqual(orderToEdit.CostumerName, repo.LoadOrder(path, 23456).CostumerName);
        }

        [Test]
        public void CanRemoveOrder()
        {
            TestRepository repo = new TestRepository();

            repo.RemoveOrder(order, 34567, path);

            Assert.IsNull(repo.LoadOrder(path, 34567));
        }
    }
}
