using System.Runtime.InteropServices;
using CqrsExploration.Domain.Commands.Requests;
using CqrsExploration.Domain.Entities;
using CqrsExploration.Domain.Mapper;
using Xunit;

namespace CqrsExploration.Tests.Domain
{
    public class MapperTests
    {
        [Fact(DisplayName = "Map to response correctly")]
        public void CustomerMapper_OnMapToResponse_MapCorrectly()
        {
            //Arrange
            var customer = new Customer("customer", "name", "customer@customer.com");

            //Act
            var result = CustomerMapper.MapToResponse(customer);

            //Assert
            Assert.Equal($"{customer.FirstName} {customer.LastName} ({customer.Email})", result.FullName);
        }

        [Fact(DisplayName = "Map to entity correctly")]
        public void CustomerMapper_OnMapToEntity_MapCorrectly()
        {
            // Arrange
            var request = new CreateCustomerRequest();
            request.FirstName = "customer";
            request.LastName = "name";
            request.Email = "customer@customer.com";

            // Act
            var result = CustomerMapper.MapToEntity(request);

            // Assert
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
        }
    }
}