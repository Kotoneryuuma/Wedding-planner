using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace wedding.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingID {get;set;}
        [Required]

        public string WedderOne {get;set;}
        public string WedderTwo {get;set;}
        public DateTime Date {get;set;}

        public string Address {get;set;}
        public DateTime CreatedAt {get;set;}
         public DateTime UpdatedAt {get;set;}

        public int AssociateID {get;set;}

        public List<Associate> Guests {get;set;}
        public int UserID {get;set;}
        public User Creator {get;set;}

    }
    
}