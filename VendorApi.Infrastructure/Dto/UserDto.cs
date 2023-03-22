
using System;

namespace VendorApi.Infrastructure.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public int Disabled { get; set; }
        public string EmailID { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime RegisterLoginDate { get; set; }
        public string Role { get; set; }
    }
}
