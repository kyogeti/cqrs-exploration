using System;

namespace CqrsExploration.Domain.Commands.Responses
{
    public class CreateCustomerResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}