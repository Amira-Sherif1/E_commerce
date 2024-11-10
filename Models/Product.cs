using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Product
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string ImgUrl { get; set; }
            public double Rate { get; set; }

            [Required]
            public int CategoryId { get; set; }

            [ValidateNever]
             public Category Category { get; set; }






    }
}
