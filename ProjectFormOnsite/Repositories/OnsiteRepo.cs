using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectFormOnsite.Data;
using ProjectFormOnsite.Models;

namespace ProjectFormOnsite.Repositories
{
    public class OnsiteRepo : IOnsiteRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OnsiteRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddOnsite(OnsiteModel model)
        {
            var newOnsite =  _mapper.Map<Onsite>(model);
            _context.Onsites!.Add(newOnsite);
            await _context.SaveChangesAsync();

            return newOnsite.OnsiteID;
        }

       /* public Task DeleteOnsite(int id)
        {
            
        }*/

        public async Task<List<OnsiteModel>> GetAllOnsite()
        {
            var onsite = await _context.Onsites.ToListAsync();
            return _mapper.Map<List<OnsiteModel>>(onsite);
        }

        public async Task<OnsiteModel> GetOnsite(int id)
        {
            var onsite = await _context.Onsites.FindAsync(id);
            return _mapper.Map<OnsiteModel>(onsite);
        }

       /* public async Task<int> UpdateOnsite(int id, OnsiteModel model)
        {
            if (id == model.OnsiteID)
            {
                var updateOnsite = _mapper.Map<Onsite>(model);
                _context.Onsites!.Update(updateOnsite);
                await _context.SaveChangesAsync();
            }
             
        }*/
    }
}
