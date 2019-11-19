using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.AppData
{
    public class ProductEntities : IProductEntities
    {
    //    public List<Product> Product { get; set; }
        public static List<Product> Products { get; private set; }


        public ProductEntities()
        {
            if (Products == null || Products.Count == 0)
            {
                InitializeProduct();
            }
        }

        public void InitializeProduct()
        {
            Products = new List<Product>();
            var data = new List<Product>
            {
                new Product{ ID= 1, Name="Faber-Castell Connector Pen Cube - 48 Pack", Price=12.0, Description="Connector Pens have unique child safe caps that are air tight and clip pens together for easy storage and creative play." , Quantity=210, ImagePath="shopping.jpg"},
                new Product{ ID= 2, Name="Esselte - System card", Price=25.08, Description="Esselte system cards are ideal for use in card boxes or on their own. Perfect system cards to compliment the Esselte card file boxes and index cards.", Quantity=110 , ImagePath="noImage.jpg"},
                new Product{ ID=3, Name="Unicorn Stationery Multipack", Price=5.0, Description="The unicorn stationery multipack includes 5 notebooks, 5 sharpeners, 5 highlighters and 5 pencils.", Quantity=224, ImagePath="unicorn.jpg" },
                new Product{ ID= 4, Name="Personalised Stationery Set 145 Piece Stationery Pack Blue", Price=34.99, Description="The perfect value pack of stationery for school kids of all ages, with most items personalised with their name to make sure nothing is lost.", Quantity=245, ImagePath="stationery.jpg" },
                new Product{ ID= 5, Name="Yoobi Fun Mini Stationery Kits Pink", Price=14.67, Description="This Yoobi Mini Stationery Set comes with all of the stationery essentials you'll need for a day at school or work.", Quantity=140, ImagePath="yobbi.jpg" },
                new Product{ ID=6, Name="Pencil Case", Price=22.80, Description="NICE SHAPE: This high quality pen case opens like a book, unzipping on 3 of 4 sides with double sturdy zippers." , Quantity=120, ImagePath="pencilcase.jpg"},
                new Product{ ID= 7, Name="Personalised Pencil Cases by Bright Star Kids", Price=14.95, Description="Personalised Pencil Case | Custom pencil case zip bag for school kids Stimulate creativity and organisation with our custom pencil cases for young kids in school or even adults " , Quantity=110, ImagePath="noImage.jpg"},
                new Product{ ID=8, Name="Set of 3 Ballpoint Pens", Price=59.95, Description="Inside are three separate pens. A lovely white pen that reads ‘Look Sharp,’ a shimmering rose-gold pen that reads ‘Let’s Twist Again,’ and a beautiful soft pink pen" , Quantity=170, ImagePath="Pens.jpg"},
                new Product{ ID= 9, Name="Studymate Twin Zip Double Decker Pencil Case EVA Teal", Price=16.98, Description="description goes here..." , Quantity=130, ImagePath="eva.jpg"},
                new Product{ ID= 10, Name="Product 10", Price=20.0, Description="description goes here..." , Quantity=210, ImagePath="noImage.jpg"},
                new Product{ ID=11, Name="Product 11", Price=4.0, Description="description goes here..." , Quantity=140, ImagePath="noImage.jpg"},
                new Product{ ID= 12, Name="Product 12", Price=2.0, Description="description goes here..." , Quantity=130, ImagePath="noImage.jpg"},
                new Product{ ID=13, Name="Product 13", Price=12.0, Description="description goes here..." , Quantity=120, ImagePath="noImage.jpg"},
                new Product{ ID= 14, Name="Product 14", Price=10.0, Description="description goes here..." , Quantity=110, ImagePath="noImage.jpg"},
                new Product{ ID=15, Name="Product 15", Price=7.0, Description="description goes here..." , Quantity=110, ImagePath="noImage.jpg"},
                new Product{ ID=16, Name="Product 16", Price=1.0, Description="description goes here..." , Quantity=130, ImagePath="noImage.jpg"},
                new Product{ ID= 17, Name="Product 17", Price=23.0, Description="description goes here..." , Quantity=120, ImagePath="noImage.jpg"},
                new Product{ ID=18, Name="Product 18", Price=29.0, Description="description goes here..." , Quantity=10, ImagePath="noImage.jpg"},
                new Product{ ID= 19, Name="Product 19", Price=17.0, Description="description goes here..." , Quantity=110, ImagePath="noImage.jpg"},
                new Product{ ID= 20, Name="Product 20", Price=28.0, Description="description goes here..." , Quantity=140, ImagePath="noImage.jpg"},
                new Product{ ID=21, Name="Product 21", Price=26.0, Description="description goes here..." , Quantity=100, ImagePath="noImage.jpg"},
            };

            Products.AddRange(data);

          //  Product = Products.ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return Products;
        }

        public Product GetProduct(int id)
        {
            return Products.FirstOrDefault(p => p.ID.Equals(id));
        }

        public Product AddProduct(Product product)
        {
            product.ID = Products.Count;

            Products.Add(product);

            return product;
        }

        public bool UpdateProduct(Product product)
        {
            var _productIndex = Products.FindIndex(p => p.ID.Equals(product.ID));

            if (_productIndex == -1 )
            {
                return false;
            }
            else
            {
                Products[_productIndex] = product;
            }

            return true;
        }

        public void Delete(int id)
        {
            Products.RemoveAll(p => p.ID.Equals(id));
        }
    }

}
