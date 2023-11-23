using Microsoft.EntityFrameworkCore;

namespace ProjectFormOnsite.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }
        #region DbSet
       
        #endregion
    }
}
