using System;
using System.Collections.Generic;

#nullable disable

namespace projetAsp.Modelsmusic
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardExpirationDate { get; set; }
    }
}
