using System.ComponentModel.DataAnnotations;

namespace VendorApi.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
