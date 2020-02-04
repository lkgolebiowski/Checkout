using System;
using System.Threading.Tasks;
using Api.Messages.Commands;
using Api.Messages.Queries;
using Api.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Process(ProcessPaymentRequest request)
        {
            var command = new ProcessPaymentCommand(
                request.CardNumber,
                request.Expiry,
                request.Ccv,
                request.Amount,
                request.Currency);

            var result = await _mediator.Send(command);
            if(result.PaymentId is null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        [Route(":id")]
        public async Task<IActionResult> GetLastPayment(Guid id)
        {
            var query = new GetLastPaymentQuery(id);

            var result = await _mediator.Send(query);            
            return Ok(result);
        }

    }
}