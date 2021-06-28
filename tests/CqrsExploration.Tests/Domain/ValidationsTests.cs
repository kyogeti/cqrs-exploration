using System;
using System.Linq;
using System.Numerics;
using System.Reflection;
using CqrsExploration.Domain.Commands.Requests;
using CqrsExploration.Domain.Entities;
using CqrsExploration.Domain.Validations;
using Xunit;

namespace CqrsExploration.Tests.Domain
{
    public class ValidationsTests
    {
        [Fact(DisplayName = "Customer: Verify if all properties are being validated.")]
        public void CustomerValidator_OnValidate_MustValidateAllProperties()
        {
            // Arrange
            var validator = new CustomerValidator();

            // Act
            var rules = validator.Count();
            var quant = typeof(Customer).GetProperties().Length;

            // Assert
            Assert.Equal(quant, rules);
        }

        [Fact(DisplayName = "CreateCustomerRequest: Verify if all properties are being validated.")]
        public void CreateCustomerRequestValidator_OnValidate_MustValidateAllProperties()
        {
            // Arrange

            var validator = new CreateCustomerRequestValidator();

            // Act
            var rules = validator.Count();
            var quant = typeof(CreateCustomerRequest).GetProperties().Length;

            // Assert
            Assert.Equal(quant, rules);
        }
    }
}