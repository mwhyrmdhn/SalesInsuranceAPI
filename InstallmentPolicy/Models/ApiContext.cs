using Microsoft.EntityFrameworkCore;
using Policy.Models;

namespace InstallmentPolicy.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) 
            : base(options)
        {
        }
        public DbSet<Installment> InstallmentPolicy { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterPolicy>().HasKey(x => x.PID);
            base.OnModelCreating(modelBuilder);
        }
    }

}
