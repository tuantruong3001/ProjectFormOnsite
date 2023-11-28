﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using App.Domain.Entities;
using App.Domain.Models;
using App.DAL.Data;
using App.Domain.Enum;
using App.Domain.Interfaces.IRepositories;

namespace App.DAL.Repositories
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
            var newOnsite = _mapper.Map<Onsite>(model);
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
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<OnsiteModel>> GetAllOnsiteAsync()
        {
            var onsite = await _context.Onsites.ToListAsync();
            return _mapper.Map<List<OnsiteModel>>(onsite);
        }

        public async Task<InforOnsiteModel> GetOnsiteByIdAsync(int id)
        {
            var onsite = await _context.Onsites
                .Include(o => o.Employee!.Department)
                .Include(a => a.Approver!.Department)
                .FirstOrDefaultAsync(o => o.OnsiteID == id);
            var onsiteModel = _mapper.Map<InforOnsiteModel>(onsite);

            return onsiteModel;
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

        public async Task ConfirmOnsiteAsync(int id, JsonPatchDocument<ConfirmModel> patchDocument)
        {
            var onsite = await _context.Onsites.FindAsync(id);
            if (onsite != null)
            {
                var confirmModel = new ConfirmModel
                {
                    OnsiteID = onsite.OnsiteID,
                    Status = onsite.Status,
                    Detail = onsite.Detail,
                    Reason = onsite.Reason
                };
                patchDocument.ApplyTo(confirmModel);
                onsite.Status = confirmModel.Status;
                onsite.Detail = confirmModel.Detail;
                onsite.Reason = confirmModel.Reason;

                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> RegisterOnsiteAsync(RegisterOnsiteModel model)
        {
            var newOnsite = _mapper.Map<Onsite>(model);
            var confirmModel = new RegisterOnsiteModel
            {
                Status = (int)StatusEnum.Progressing,
                EmployeeID = model.EmployeeID,
                Destination = model.Destination,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Detail = model.Detail
            };
            _context.Onsites!.Add(newOnsite);

            newOnsite.Status = confirmModel.Status;
            newOnsite.EmployeeID = confirmModel.EmployeeID;
            newOnsite.Destination = confirmModel.Destination;
            newOnsite.StartDate = confirmModel.StartDate;
            newOnsite.EndDate = confirmModel.EndDate;
            newOnsite.Detail = confirmModel.Detail;

            await _context.SaveChangesAsync();

            return newOnsite.OnsiteID;
        }
    }
}