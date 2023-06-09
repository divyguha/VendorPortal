﻿using System.ComponentModel.DataAnnotations;

namespace VendorApi.Domain.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
