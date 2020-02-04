using Api.Entities.Enums;
using Api.Messages.Commands;
using Api.Responses;
using Api.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Handlers.Commands
{
    public class ProcessPaymentHandler : IRequestHandler<ProcessPaymentCommand, ProcessPaymentResponse>
    {
        private readonly IBankService bankService;

        public ProcessPaymentHandler(IBankService bankService)
        {
            this.bankService = bankService;
        }
        public async Task<ProcessPaymentResponse> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
        {
            var result = await bankService.Process(request.CardNumber, request.Expiry, request.Ccv, request.Amount, (int)request.Currency);
            
            return new ProcessPaymentResponse
                {
                    PaymentId = result.PaymentId,
                    Message = ((PaymentStatus)result.Status).ToString()
                };
        }
    }
}
