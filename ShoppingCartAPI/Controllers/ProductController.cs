using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShoppingCart.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCartAPI.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        //public Products objProducts { get; set; }
        private static List<Product> _products = new List<Product>();
        private static readonly IProductEntities productEntities = new ProductEntities();


        public ProductController()
        {
            //this.objProducts = new Products();
        }


        [HttpGet]
        [Route("AllProducts")]
        public IQueryable<Product> GetProduct()
        {

            try
            {
                return productEntities.GetAllProducts().ToList().AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetProductById/{ProductId}")]
        public IHttpActionResult GetProductById(string productId)
        {
            Product product;
            int ID = Convert.ToInt32(productId);
            try
            {
                product = productEntities.GetProduct(ID);
                if (product == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(product);
        }

        [HttpGet]
        [Route("GetShippingCost/{TotalCost}")]
        public IHttpActionResult GetShippingCost(double TotalCost)
        {
            int iShippingCost;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
              
                //Product _product;
                //foreach (CartDetails prod in items)
                //{
                //    _product = _products.FirstOrDefault(p => p.ID == prod.ID);
                //    iTotalCost += (_product.Price * prod.Quantity);
                //}

                if (TotalCost > 50)
                {
                    iShippingCost = 20;
                }
                else
                {
                    iShippingCost = 10;
                }
            }
            catch (Exception) { throw; }
            return Ok(iShippingCost);
        }

        [HttpPost]
        [Route("CheckOut")]
        public IHttpActionResult CheckOut([FromBody]List<CartDetails> lstCartDetails)
        {

            string strMsg = "";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Product _product;
                foreach (CartDetails item in lstCartDetails)
                {
                    _product = productEntities.GetProduct(item.ID);
                    _product.Quantity = _product.Quantity - item.Quantity;
                    productEntities.UpdateProduct(_product);
                }
                strMsg = "Success";
            }
            catch (Exception) { throw; }

            return Ok(strMsg);
        }
    }
}