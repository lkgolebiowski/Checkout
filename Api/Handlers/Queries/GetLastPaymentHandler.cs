using Api.Entities.Enums;
using Api.Messages.Queries;
using Api.Responses;
using Api.Services;
using Api.Services.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Handlers.Queries
{
    public class GetLastPaymentHandler : IRequestHandler<GetLastPaymentQuery, GetLastPaymentResponse>
    {
        private readonly IBankService bankService;

        public GetLastPaymentHandler(IBankService bankService)
        {
            this.bankService = bankService;
        }
        public async Task<GetLastPaymentResponse> Handle(GetLastPaymentQuery request, CancellationToken cancellationToken)
        {
            var result = await bankService.GetPayment(request.PaymentId);
            if (result is null)
            {
                // Add Exception handling inside handlers for responses instead internal error.
                throw new Exception("Invalid payment id");
            }

            return new GetLastPaymentResponse
            {
                CardNumber = MaskCardNumber(result),
                Expiry = result.Expiry,
                Ccv = result.Ccv,
                Amount = ConvertAmount(result.Amount, result.Currency),
                Status = ((PaymentStatus)result.Status).ToString(),
                CreatedAt = result.CreatedAt,
            };
        }

        private static string ConvertAmount(int amount,  int currency)
        {
            //convert from penny
            var convertedAmount = (float)amount / 100;
            var convertedCurrency = ((CurrencyEnum)currency).ToString();
            return string.Format("{0} | {1}", convertedAmount, convertedCurrency);
        }

        private static string MaskCardNumber(IBankServiceGetPaymentResponse result)
        {
            var last4Numbers = result.CardNumber.Substring(12,4);
            return $"************{last4Numbers}";
        }
    }
}
