using App.DAL.Data;
using App.Domain.Entities;
using App.Domain.Interfaces.IRepositories;

namespace App.DAL.Repositories
{
    public class UserRepo : BaseRepository<User, int>, IUserRepo
    {
        public UserRepo(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
