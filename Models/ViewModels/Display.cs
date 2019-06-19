using System;
using System.Collections.Generic;

namespace wedding.Models
{
    public class Display
    {
        public int DisplayID {get;set;}
        public string Couple {get;set;}
        public DateTime Date {get;set;}

        public string　Address {get;set;}
        public List<User> Guests {get;set;}

        public bool IsHosting {get;set;}
        public bool IsAttending {get;set;}
        

    }
}