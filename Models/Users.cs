using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Models
{
    public class Users
    {
        public string Id { get; set; } = "";
        public string Fname { get; set; } = "";
        public string Mname { get; set; } = "";
        public string Lname { get; set; } = "";
        public string Ext { get; set; } = "";
        public string Address { get; set; } = "";
        public string Contact { get; set; } = "";
        public string Role { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public string Token { get; set; } = "";
    }

}
