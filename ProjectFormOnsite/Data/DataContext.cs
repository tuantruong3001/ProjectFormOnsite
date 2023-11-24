using Microsoft.EntityFrameworkCore;

namespace ProjectFormOnsite.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }
        #region DbSet
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Onsite> Onsites { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Onsite>()
                .HasOne(o => o.Employee)
                .WithMany()
                .HasForeignKey(o => o.EmployeeID);

            modelBuilder.Entity<Onsite>()
                .HasOne(o => o.Approver)
                .WithMany()
                .HasForeignKey(o => o.ApproverID);
            modelBuilder.Entity<Employee>()
                .HasOne(b => b.Department)
                .WithMany()
                .HasForeignKey(b => b.DepartmentID);
        }
    }
}
