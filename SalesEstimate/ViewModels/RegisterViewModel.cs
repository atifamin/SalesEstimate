using System.ComponentModel.DataAnnotations; // Ensure to include this for validation attributes
using SalesEstimate.Identity;

namespace SalesEstimate.ViewModels
{
    public class RegisterViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public Gender Gender { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? RoleName { get; set; }
        public string? UserName { get; set; }
    }


    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }
}
