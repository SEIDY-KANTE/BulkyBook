using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
=======
>>>>>>> 3de820c21389c1c2b5f339a188b16277d9983ee0

namespace BulkyBook.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]

        //Special price on each product
        public double Price { get; set; }
        [Required]
        [Range(1, 10000)]

        //Admin can set different prices for one single book, 50 or more and 100 or more books
        public double Price50 { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price100 { get; set; }
<<<<<<< HEAD
        [ValidateNever]
=======
>>>>>>> 3de820c21389c1c2b5f339a188b16277d9983ee0
        public string ImageUrl { get; set; }

        //Foreign key relation
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
<<<<<<< HEAD
        [ValidateNever]
=======
>>>>>>> 3de820c21389c1c2b5f339a188b16277d9983ee0
        public Category Category { get; set; }

        [Required]
        public int CoverTypeId { get; set; }
<<<<<<< HEAD
        [ValidateNever]
=======
>>>>>>> 3de820c21389c1c2b5f339a188b16277d9983ee0
        public CoverType CoverType { get; set; }
    }
}
