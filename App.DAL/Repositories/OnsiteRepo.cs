using AutoMapper;
using Microsoft.EntityFrameworkCore;
using App.Domain.Entities;
using App.Domain.Models;
using App.DAL.Data;
using App.Domain.Interfaces.IRepositories;

namespace App.DAL.Repositories
{
    public class OnsiteRepo : BaseRepository<Onsite, int>, IOnsiteRepo
    {
        public OnsiteRepo(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }
        public async Task<List<OnsiteModel>> GetAllOnsiteAsync()
        {
            var onsite = await _dataContext.Onsites
                .ToListAsync();
            return _mapper.Map<List<OnsiteModel>>(onsite);
        }
    }
}
