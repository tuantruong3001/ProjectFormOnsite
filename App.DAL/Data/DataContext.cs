using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Data
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
