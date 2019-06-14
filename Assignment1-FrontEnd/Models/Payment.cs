using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1_FrontEnd.Models
{
    public class Payment
    {
        public string BrandCode { get; set; }
        public decimal Amount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCardNumber { get; set; }
        public string SecurityCode { get; set; }
        public string PaymentReferenceNumber { get; set; }
    }
}