using Microsoft.AspNetCore.Identity;

namespace SalesEstimate.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StreetAddress { get; set; }
        public Gender? Gender { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
    }
    public enum Gender
    {
        Male=1,
        Female=2,
        Other=3
    }
}
