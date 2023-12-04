using Microsoft.EntityFrameworkCore;
using App.Domain.Entities;
using App.DAL.Data;
using App.Domain.Interfaces.IRepositories;

namespace App.DAL.Repositories
{
    public class OnsiteRepo : BaseRepository<Onsite, int>, IOnsiteRepo
    {
        public OnsiteRepo(DataContext dataContext) : base(dataContext)
        {

        }
        public async Task<List<Onsite>> GetAllOnsiteAsync()
        {
            var onsite = await _dataContext.Onsites
                .ToListAsync();
            return onsite;
        }
    }
}
