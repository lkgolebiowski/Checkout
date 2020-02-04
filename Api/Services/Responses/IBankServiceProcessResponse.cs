using System;

namespace Api.Services.Responses
{
    public class IBankServiceProcessResponse
    {
        public Guid? PaymentId { get; set; }
        public int Status { get; set; }
    }
}
