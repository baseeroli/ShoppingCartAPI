using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.AppData
{
    interface IProductEntities
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        Product AddProduct(Product product);
        bool UpdateProduct(Product product);
        void Delete(int id);
    }
}
