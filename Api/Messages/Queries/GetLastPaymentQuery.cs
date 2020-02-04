using Api.Responses;
using MediatR;
using System;

namespace Api.Messages.Queries
{
    public class GetLastPaymentQuery : IRequest<GetLastPaymentResponse>
    {
        public Guid PaymentId { get; }
        public GetLastPaymentQuery(Guid paymentId)
        {
            PaymentId = paymentId;
        }

    }
}
