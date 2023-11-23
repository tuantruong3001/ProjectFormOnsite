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
    }
}
