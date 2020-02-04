using Api.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Requests
{
    public class ProcessPaymentRequest
    {
        // Add more robust validation of the request
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string Expiry { get; set; }
        [Required]
        public string Ccv { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public CurrencyEnum Currency { get; set; }
    }
}
