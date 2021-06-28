using CqrsExploration.Domain.Commands.Responses;
using MediatR;

namespace CqrsExploration.Domain.Commands.Requests
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}