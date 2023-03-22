using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorApi.Domain.Entities
{
    /// <summary>
    /// Data inserted in to table 'User' from API
    /// </summary>
    public class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int  UserType { get; set; }
        public int Disabled { get; set; }
        public string UserEmail { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? RegisterLoginDate { get; set; }
        public string Role { get; set; }
    }
}
