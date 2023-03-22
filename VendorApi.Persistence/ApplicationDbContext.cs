using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VendorApi.Domain.Entities;

namespace VendorApi.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        // This constructor is used of runit testing
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public DbSet<Vendor> VendorMaster { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<POMain> POMain { get; set; }
        public DbSet<PODetail> PODetail { get; set; }
        public DbSet<DeliveryScheduleMain> DeliveryScheduleMain { get ; set ; }
        public DbSet<DeliveryScheduleDetail> DeliveryScheduleDetail { get ; set ; }
        public DbSet<InvoiceMain> InvoiceMain { get ; set ; }
        public DbSet<InvoiceDetail> InvoiceDetail { get ; set ; }
        public DbSet<Circular> Circulars { get ; set ; }
        public DbSet<CircularDetail> CircularDetails { get ; set ; }
        public DbSet<GRNMain> GRNMains { get; set; }
        public DbSet<GRNDetail> GRNDetails { get; set; }

        public DbSet<TaxPercentage> TaxPercentages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<POMain>().HasKey(o => new { o.VendorId });
            //modelBuilder.Entity<PODetail>().HasForeignKey(o => new { o.POMainId });

            //modelBuilder.Entity<PODetail>().has
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("DataSource=app.db");
            }

        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
