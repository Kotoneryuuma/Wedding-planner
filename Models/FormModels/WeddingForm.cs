using System;
using System.ComponentModel.DataAnnotations;

namespace wedding.Models
{
    public class WeddingForm
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "Wedder One")]
        public string WedderOne {get;set;}

        [Required]
        [MinLength(2)]
        [Display(Name = "Wedder Two")]
        public string WedderTwo {get;set;}

        [Required]
        [DataType(DataType.Date)]
         public DateTime Date {get;set;}

        [Required]
        [MinLength(2)]
         public string Address {get;set;}





    }
}