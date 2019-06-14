using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1_FrontEnd.Models
{
    public class PaymentResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string PaymentReferenceNumber { get; set; }
    }
}