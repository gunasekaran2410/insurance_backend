using Insurance.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Master tables
            builder.Entity<CustomerModel>().Property(x => x.customerId).HasDefaultValueSql("NEWID()");
            builder.Entity<CompanyModel>().Property(x => x.companyId).HasDefaultValueSql("NEWID()");
            builder.Entity<PolicyModel>().Property(x => x.policyId).HasDefaultValueSql("NEWID()");
            builder.Entity<RenewalModel>().Property(x => x.renewalId).HasDefaultValueSql("NEWID()");
            builder.Entity<UploadModel>().Property(x => x.imgId).HasDefaultValueSql("NEWID()");
            builder.Entity<RenewvalUploads>().Property(x => x.imgId).HasDefaultValueSql("NEWID()");
        }

        public DbSet<CustomerModel> Customers { get; set; } = default!;
        public DbSet<CompanyModel> Companies { get; set; } = default!;
        public DbSet<PolicyModel> Policies { get; set; } = default!;
        public DbSet<RenewalModel> renewals { get; set; } = default!;
        public DbSet<UploadModel> uploads { get; set; } = default!;
       public DbSet<RenewvalUploads> renewvalUploads { get; set; } = default!;
        public DbSet<Insurance.Models.RenewalModel> RenewalModel { get; set; } = default!;
    }
}
