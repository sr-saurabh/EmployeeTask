using Domain.DbModels;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // You can add custom configurations here if needed.
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);

            modelBuilder.Entity<Salary>().HasKey(e => e.SalaryId);

            modelBuilder.Entity<Salary>()
                .HasOne(s => s.Employee)
                .WithMany(e => e.Salaries)
                .HasForeignKey(s => s.EmployeeId);
        }
    }
}
