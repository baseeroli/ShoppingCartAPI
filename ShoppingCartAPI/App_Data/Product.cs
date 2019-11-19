using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.AppData
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "ProductName")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "ProductPrice")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string ImagePath { get; set; }

    }
}
