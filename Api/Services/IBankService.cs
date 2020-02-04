using Api.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Api.Services.BankServiceMock;

namespace Api.Services
{
    public interface IBankService
    {
        Task<IBankServiceProcessResponse> Process(string cardNumber, string expiry, string ccv, int amount, int currency);
        Task<IBankServiceGetPaymentResponse> GetPayment(Guid paymentId);
    }
}
