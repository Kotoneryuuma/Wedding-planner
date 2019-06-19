using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace wedding.Models
{
    public class Associate
    {
        [Key]
        public int AssosiateID { get; set; }
        public int UserID {get;set;}

        public int WeddingID { get; set; }
        
        public User User { get; set; }
        public Wedding Wedding { get; set; }

    }
    
}