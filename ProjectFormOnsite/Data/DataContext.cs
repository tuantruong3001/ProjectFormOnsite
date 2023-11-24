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
<<<<<<< HEAD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Onsite>()
                .HasOne(o => o.Employee)
                .WithMany()
=======
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Onsite>()
                .HasOne(o => o.Employee)
                .WithMany(e => e.OnsitesAsEmployee)
>>>>>>> d044544857ee7f92a98cede580844aeaa1d15e28
                .HasForeignKey(o => o.EmployeeID);

            modelBuilder.Entity<Onsite>()
                .HasOne(o => o.Approver)
<<<<<<< HEAD
                .WithMany()
                .HasForeignKey(o => o.ApproverID);
            modelBuilder.Entity<Employee>()
                .HasOne(b => b.Department)
                .WithMany()
                .HasForeignKey(b => b.DepartmentID);
        }
=======
                .WithMany(e => e.OnsitesAsApprover)
                .HasForeignKey(o => o.ApproverID);
             modelBuilder.Entity<Employee>()
                 .HasOne(b => b.Department)
                 .WithMany()
                 .HasForeignKey(b => b.DepartmentID);
        }*/
>>>>>>> d044544857ee7f92a98cede580844aeaa1d15e28
    }
}
