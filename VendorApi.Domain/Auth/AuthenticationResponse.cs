using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VendorApi.Domain.Auth
{
    public class AuthenticationResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public int Disabled { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public string JWToken { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime? RegisterLoginDate { get; set; }
    }
}
