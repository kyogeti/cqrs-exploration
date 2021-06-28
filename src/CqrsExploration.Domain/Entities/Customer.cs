using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CqrsExploration.Domain.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; private set; }

        [NotNull, Required]
        [StringLength(1, ErrorMessage = "First Name must have at least one character.")]
        [MaxLength(50, ErrorMessage = "First Name must have less than 50 characters.")]
        public string FirstName { get; private set; }

        [NotNull, Required]
        [StringLength(1, ErrorMessage = "Last Name must have at least one character.")]
        [MaxLength(50, ErrorMessage = "Last Name must have less than 50 characters.")]
        public string LastName { get; private set; }

        [NotNull, Required]
        [EmailAddress(ErrorMessage = "Invalid e-mail address.")]
        public string Email { get; private set; }

        [NotNull, Required]
        public DateTime CreatedAt { get; private set; }

        public Customer(string firstName, string lastName, string email)
        {

            if (string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email))
                throw new ArgumentException("firstName, lastName and email are required.");

            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedAt = DateTime.UtcNow;

        }

        public override string ToString() => $"{FirstName} {LastName} ({Email})";
    }
}