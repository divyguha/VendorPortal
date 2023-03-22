using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;

namespace VendorApi.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<Vendor> VendorMaster { get; set; }
        DbSet<POMain> POMain { get; set; }

        DbSet<Customer> Customers { get; set; }
        DbSet<PODetail> PODetail { get; set; }
        DbSet<DeliveryScheduleMain> DeliveryScheduleMain { get; set; }
        DbSet<DeliveryScheduleDetail> DeliveryScheduleDetail { get; set; }
        DbSet<InvoiceMain> InvoiceMain { get; set; }
        DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        DbSet<Circular> Circulars { get; set; }
        DbSet<CircularDetail> CircularDetails { get; set; }
        DbSet<GRNMain> GRNMains { get; set; }
        DbSet<GRNDetail> GRNDetails { get; set; }

        DbSet<TaxPercentage> TaxPercentages { get; set; }
        //object User { get; }

        Task<int> SaveChangesAsync();
    }
}
