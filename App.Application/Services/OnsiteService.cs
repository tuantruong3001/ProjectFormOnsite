﻿using App.DAL.Data;
using App.Domain.Entities;
using App.Domain.Enum;
using App.Domain.Interfaces.IRepositories;
using App.Domain.Interfaces.IServices;
using App.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Services
{
    public class OnsiteService : BaseService<Onsite, int>, IOnsiteService
    {
        private readonly IOnsiteRepo _onsiteRepo;
        public OnsiteService(DataContext dataContext, IMapper mapper,
            IOnsiteRepo onsiteRepo) : base(dataContext, mapper, onsiteRepo)
        {
            _onsiteRepo = onsiteRepo;
        }

        public async Task<List<OnsiteModel>> GetAllOnsiteAsync()
        {
            var onsite = await _onsiteRepo.GetAllOnsiteAsync();
            return _mapper.Map<List<OnsiteModel>>(onsite);
        }

        public async Task<InforOnsiteModel> GetOnsiteByIdAsync(int id)
        {
            var onsite = await _dataContext.Onsites
                
                .Include(o => o.Employee!.Department)
                .Include(a => a.Approver!.Department)
                .FirstOrDefaultAsync(o => o.OnsiteID == id);
            var onsiteModel = _mapper.Map<InforOnsiteModel>(onsite);

            return onsiteModel;
        }

        public async Task<Onsite> ConfirmOnsiteAsync(int id, ConfirmModel model)
        {
            var onsite = await _dataContext.Onsites.FirstOrDefaultAsync(o => o.OnsiteID == id);
            if (onsite != null)
            {               
                onsite.Status = model.Status;
                onsite.Detail = model.Detail;
                onsite.Reason = model.Reason;

                await _dataContext.SaveChangesAsync();
            }
            return onsite!;
        }
        public async Task<int> RegisterOnsiteAsync(RegisterOnsiteModel model)
        {
            var newOnsite = _mapper.Map<Onsite>(model);
            var confirmModel = new RegisterOnsiteModel
            {
                EmployeeID = model.EmployeeID,
                Destination = model.Destination,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Detail = model.Detail
            };
            _dataContext.Onsites!.Add(newOnsite);

            newOnsite.Status = (int)StatusEnum.Progressing;
            newOnsite.EmployeeID = confirmModel.EmployeeID;
            newOnsite.Destination = confirmModel.Destination;
            newOnsite.StartDate = confirmModel.StartDate;
            newOnsite.EndDate = confirmModel.EndDate;
            newOnsite.Detail = confirmModel.Detail;

            await _dataContext.SaveChangesAsync();

            return newOnsite.OnsiteID;
        }

        public async Task<Onsite> CreateOnsiteAsync(OnsiteModel model)
        {
            var onsite = _mapper.Map<Onsite>(model);
            return await _onsiteRepo.CreateAsync(onsite);
        }

        public async Task<Onsite> UpdateOnsiteAsync(OnsiteModel model)
        {
            var onsite = _mapper.Map<Onsite>(model);
            return await _onsiteRepo.UpdateAsync(onsite);
        }
    }
}
