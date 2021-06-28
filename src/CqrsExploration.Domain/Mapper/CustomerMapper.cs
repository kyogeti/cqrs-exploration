using CqrsExploration.Domain.Commands.Requests;
using CqrsExploration.Domain.Commands.Responses;
using CqrsExploration.Domain.Entities;

namespace CqrsExploration.Domain.Mapper
{
    public static class CustomerMapper
    {
        public static CreateCustomerResponse MapToResponse(Customer customer) => new()
        {
            CreatedAt = customer.CreatedAt,
            FullName = customer.ToString(),
            Id = customer.Id
        };

        public static Customer MapToEntity(CreateCustomerRequest request) => new(request.FirstName, request.LastName, request.Email);
    }
}