using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CqrsExploration.Domain.Commands.Requests;
using MediatR;

namespace CqrsExploration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public Task<IActionResult> Post(
        [FromBody] CreateCustomerRequest request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return Task.FromResult<IActionResult>(BadRequest("Invalid request."));

            try
            {
                var result = mediator.Send(request, cancellationToken).Result;

                return Task.FromResult<IActionResult>(Created("Customer", result));
            }
            catch (Exception e)
            {
                return Task.FromResult<IActionResult>(BadRequest("Error: " + e.Message));
            }
            
        }
    }
}
