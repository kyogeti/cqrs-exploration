using System;
using System.Collections.Generic;
using CqrsExploration.Domain.Commands.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CqrsExploration.Domain.Commands.Responses;
using CqrsExploration.Domain.Mapper;
using CqrsExploration.Domain.Validations;
using FluentValidation;
using FluentValidation.Results;

namespace CqrsExploration.Domain.Commands.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        public Task<CreateCustomerResponse> Handle(
            CreateCustomerRequest request,
            CancellationToken cancellationToken)
        {
            // Validate request
            var reqValidator = new CreateCustomerRequestValidator();
            if (!reqValidator.Validate(request).IsValid)
                throw new ValidationException("Invalid request.", new List<ValidationFailure>());

            // Map customer
            var result = CustomerMapper.MapToEntity(request);

            // Validate Customer
            var customerValidator = new CustomerValidator();

            if (!customerValidator.Validate(result).IsValid)
                throw new ValidationException("Invalid mapping", new List<ValidationFailure>());

            return Task
                .FromResult(CustomerMapper
                    .MapToResponse(result));

        }

    }
}