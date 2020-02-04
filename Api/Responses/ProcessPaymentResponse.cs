using System;

namespace Api.Responses
{
    public class ProcessPaymentResponse
    {
        public Guid? PaymentId { get; set; }
        public string Message { get; set; }
    }
}
