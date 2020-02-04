using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Responses
{
    public class GetLastPaymentResponse
    {
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string Ccv { get; set; }        
        public string Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
