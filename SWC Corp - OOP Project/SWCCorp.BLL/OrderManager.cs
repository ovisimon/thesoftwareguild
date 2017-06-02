using SWCCorp.Data;
using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using SWCCorp.Models.Responses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorp.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private ProductInformationRepository _productInformationRepository;
        private TaxInformationRepository _taxInformationRepository;


        public OrderManager(IOrderRepository orderRepository, ProductInformationRepository productInformationRepository, TaxInformationRepository taxInformationRepository)
        {
            _orderRepository = orderRepository;
            _productInformationRepository = productInformationRepository;
            _taxInformationRepository = taxInformationRepository;
        }

        public void AddOrder(Order order, string path)
        {
            ProductionRepository repo = new ProductionRepository();
            var productInfo = _productInformationRepository.GetProducts().Where(x => x.ProductType.ToLower() == order.ProductType.ToLower()).First();
            var taxInfo = _taxInformationRepository.GetRates().Where(x => x.StateShort.ToLower() == order.State.ToLower()).First();
            
            order.CostPerSquareFoot = productInfo.CostPerSquareFoot;
            order.LaborCostPerSquareFoot = productInfo.LaborCostPerSquareFoot;
            order.TaxRate = taxInfo.Rate;

            var filename = FileName(order.Date);

            int currentIndex = repo.GetCurrentIndex(filename);

            if (!DoesFileExist(filename))
            {
                currentIndex = 1;
            }
            else
            {
                currentIndex = repo.GetCurrentIndex(filename);
                order.OrderNumber = currentIndex;
            }

            _orderRepository.AddOrder(order, filename);
        }

        public string FileName(DateTime date)
        {
            return $".\\Repositories\\Orders_{date.Month}{date.Day}{date.Year}.txt";
        }

        public DisplayOrderResponse DisplayOrder(string path, int orderNumber)
        {
            DisplayOrderResponse response = new DisplayOrderResponse();

            response.Order = _orderRepository.LoadOrder(path ,orderNumber);

            if(response.Order == null)
            {
                response.Success = false;
                response.Message = $"{orderNumber.ToString()} is not a valid number";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public EditOrderResponse EditOrder(Order order, int orderNumber, string path)
        {
            EditOrderResponse response = new EditOrderResponse();

            try
            {
                response.Order = _orderRepository.EditOrder(order, orderNumber, path);
                return response;
            }

            catch
            {
                response.Success = false;
                return response;
            }
            
        }

        public RemoveOrderResponse RemoveOrder(int orderNumber, string path)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();

            try
            {
                _orderRepository.RemoveOrder(response.Order, orderNumber - 1, path);
                return response;
            }

            catch
            {
                response.Success = false;
                return response;
            }
           
            
        }

        public IEnumerable<TaxRate> GetStates()
        {
            TaxInformationRepository taxRepo = new TaxInformationRepository();
            var states = taxRepo.GetRates().Where(x => x.StateShort.Count() > 0);
            return states;
        }

        public bool DoesFileExist(string path)
        {
            if (File.Exists(path))
                return true;
            else
                return false;
        }
    }
}
