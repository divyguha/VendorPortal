using System.ComponentModel.DataAnnotations;
namespace VendorApi.Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Orders { get; set; }
        public Product Product { get; set; }
    }
}
