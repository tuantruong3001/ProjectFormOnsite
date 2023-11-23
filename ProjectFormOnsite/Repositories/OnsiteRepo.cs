﻿using AutoMapper;
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

        public async Task<int> AddOnsiteAsync(OnsiteModel model)
        {
            var newOnsite =  _mapper.Map<Onsite>(model);
            _context.Onsites!.Add(newOnsite);
            await _context.SaveChangesAsync();

            return newOnsite.OnsiteID;
        }

        public async Task DeleteOnsiteAsync(int id)
        {
            var deleteOnsite = _context.Onsites!.FirstOrDefault(a => a.OnsiteID == id);
            if (deleteOnsite != null)
            {
                _context.Onsites!.Remove(deleteOnsite);
                await _context.SaveChangesAsync() ;
            }
        }

        public async Task<List<OnsiteModel>> GetAllOnsiteAsync()
        {
            var onsite = await _context.Onsites.ToListAsync();
            return _mapper.Map<List<OnsiteModel>>(onsite);
        }

        public async Task<OnsiteModel> GetOnsiteAsync(int id)
        {
            var onsite = await _context.Onsites.FindAsync(id);
            return _mapper.Map<OnsiteModel>(onsite);
        }

        public async Task UpdateOnsiteAsync(int id, OnsiteModel model)
        {
            if (id == model.OnsiteID)
            {
                var updateOnsite = _mapper.Map<Onsite>(model);
                _context.Onsites!.Update(updateOnsite);
                await _context.SaveChangesAsync();
            }

        }
    }
}