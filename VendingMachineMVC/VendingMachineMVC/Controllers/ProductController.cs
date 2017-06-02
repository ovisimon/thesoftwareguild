using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VendingMachineMVC.Models;

namespace VendingMachineMVC.Controllers
{
    public class ProductController : ApiController
    {
        [Route("items")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(ProductRepository.GetAll());
        }

        [Route("money/{ammount}/item/{productId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(decimal ammount, int productId)
        {
            Product product = ProductRepository.Get(productId);
            Change change = new Change();
            change.Quarters = 0;
            change.Dimes = 0;
            change.Nickels = 0;
            change.Message = "Thank you! Please collect your change!";

            if (product.Quantity < 1)
            {
                change.Message = "Sold out!";
                return Ok(change);
            }

            if (product.Price > ammount)
            {
                decimal rest = product.Price - ammount;
                change.Message = $"Please add : ${rest}";
                return Ok(change);
            }
            else
            {
                ProductRepository.Get(productId).Quantity = ProductRepository.Get(productId).Quantity - 1 + 3;

                if ((ammount - product.Price) < 0.25M) 
                {
                    change.Nickels = (int)((ammount - product.Price) / 0.05M);
                    return Ok(change);
                }
                if ((ammount - product.Price) % 0.25M == 0)
                {
                    change.Quarters = (int)((ammount - product.Price) / 0.25M);
                    return Ok(change);
                }
                if((ammount - product.Price) > 0.25M)
                {
                    change.Quarters = (int)((ammount - product.Price) / 0.25M);
                    change.Dimes = (int)(((ammount - product.Price) % 0.25M) / 0.10M);
                    change.Nickels = (int)(((ammount - product.Price) % 0.10M) / 0.05M);
                    return Ok(change);
                }
                return Ok(change);
            }
        }
    }
}
