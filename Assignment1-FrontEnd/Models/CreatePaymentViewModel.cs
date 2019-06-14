using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1_FrontEnd.Models
{
    public class CreatePaymentViewModel
    {
        public string BrandCode { get; set; }
        public decimal Amount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCardNumber { get; set; }
        public string SecurityCode { get; set; }

        public CreatePaymentViewModel()
        {

        }

        public CreatePaymentViewModel(Payment payment)
        {
            BrandCode = payment.BrandCode;
            Amount = payment.Amount;
            FirstName = payment.FirstName;
            LastName = payment.LastName;
            CreditCardNumber = payment.CreditCardNumber;
            SecurityCode = payment.SecurityCode;
        }
    }
}