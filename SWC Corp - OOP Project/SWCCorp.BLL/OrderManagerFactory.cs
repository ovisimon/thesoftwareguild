using SWCCorp.Data;
using SWCCorp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestRepository(), new ProductInformationRepository(), new TaxInformationRepository());

                case "Prod":
                    return new OrderManager(new ProductionRepository(), new ProductInformationRepository(), new TaxInformationRepository());

                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
