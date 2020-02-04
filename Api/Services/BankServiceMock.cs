using Api.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public partial class BankServiceMock : IBankService
    {
        // Add persistent database instead making service as singleton with list of payments
        private readonly IList<Payments> _payments;

        public BankServiceMock()
        {
            _payments = new List<Payments>();
        }

        public Task<IBankServiceProcessResponse> Process(string cardNumber, string expiry, string ccv, int amount, int currency)
        {

            var newPaymentId = Guid.NewGuid();
            var payment = new Payments
            {
                Id = newPaymentId,
                CreatedAt = DateTime.UtcNow,
                CardNumber = cardNumber,
                Expiry = expiry,
                Ccv = ccv,
                Amount = amount,
                Currency = currency,
                Status = 1 // 1 - successful, 0 - unsuccessful
            };

            // Make processing invalid when first 5 digits of card number start...
            if (cardNumber.StartsWith("01234"))
            {
                payment.Status = 0;
            }

            _payments.Add(payment);
            
            return Task.FromResult(new IBankServiceProcessResponse
            {
                PaymentId = newPaymentId,
                Status = payment.Status
            });
        }

        public Task<IBankServiceGetPaymentResponse> GetPayment(Guid paymentId)
        {
            var payment = _payments.SingleOrDefault(s => s.Id == paymentId);
            return Task.FromResult(new IBankServiceGetPaymentResponse
            {
                Id = payment.Id,
                CreatedAt = payment.CreatedAt,
                CardNumber = payment.CardNumber,
                Expiry = payment.Expiry,
                Ccv = payment.Ccv,
                Amount = payment.Amount,
                Currency = payment.Currency,
                Status = payment.Status
            });
        }
    }
}
