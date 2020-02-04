using Api.Entities.Enums;
using Api.Responses;
using MediatR;

namespace Api.Messages.Commands
{
    public class ProcessPaymentCommand :  IRequest<ProcessPaymentResponse>
    {
        // We can add here additional validation for fields to make creation of command more robust
        public string CardNumber { get; }
        public string Expiry { get; }
        public string Ccv { get; }
        public int Amount { get; }
        public CurrencyEnum Currency { get; }
        public ProcessPaymentCommand(string cardNumber, string expiry, string ccv, int amount, CurrencyEnum currency)
        {
            CardNumber = cardNumber;
            Expiry = expiry;
            Ccv = ccv;
            Amount = amount;
            Currency = currency;
        }
    }
}
