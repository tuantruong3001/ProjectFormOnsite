using App.DAL.Data;
using App.Domain.Entities;
using App.Domain.Enum;
using App.Domain.Interfaces.IServices;
using App.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Services
{
    public class OnsiteService : BaseService<Onsite, int>, IOnsiteService
    {
        public OnsiteService(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }

        public async Task<List<OnsiteModel>> GetAllOnsiteAsync()
        {
            var onsite = await _dataContext.Onsites
                .ToListAsync();
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

        public async Task ConfirmOnsiteAsync(int id, JsonPatchDocument<ConfirmModel> patchDocument)
        {
            var onsite = await _dataContext.Onsites.FindAsync(id);
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

                await _dataContext.SaveChangesAsync();
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
            _dataContext.Onsites!.Add(newOnsite);

            newOnsite.Status = confirmModel.Status;
            newOnsite.EmployeeID = confirmModel.EmployeeID;
            newOnsite.Destination = confirmModel.Destination;
            newOnsite.StartDate = confirmModel.StartDate;
            newOnsite.EndDate = confirmModel.EndDate;
            newOnsite.Detail = confirmModel.Detail;

            await _dataContext.SaveChangesAsync();

            return newOnsite.OnsiteID;
        }
    }
}
