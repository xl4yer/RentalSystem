using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Models
{
    public class Users
    {
        public string Id { get; set; } = string.Empty;
        public string Fname { get; set; } = string.Empty;
        public string Mname { get; set; } = string.Empty;
        public string Lname { get; set; } = string.Empty;
        public string Ext { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }

}
