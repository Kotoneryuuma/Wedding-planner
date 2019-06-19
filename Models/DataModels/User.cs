using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace wedding.Models
{
    public class User
    {
        [Key]
        public int UserID {get;set;}
        [Required]

         public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public List<Associate> WeddingstoAttend {get;set;}
        // user が いく　ウェディング
        

    }
    
}