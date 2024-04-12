using App.Domain.Entities;
using App.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace App.Domain.Interfaces.IServices
{
    public interface IOnsiteService : IBaseService<Onsite, int>
    {
        Task<List<OnsiteModel>> GetAllOnsiteAsync();
        Task<InforOnsiteModel> GetOnsiteByIdAsync(int id);
        Task<int> RegisterOnsiteAsync(RegisterOnsiteModel model);
        Task<Onsite> ConfirmOnsiteAsync(int id,ConfirmModel model);
        Task<Onsite> CreateOnsiteAsync(OnsiteModel model);
        Task<Onsite> UpdateOnsiteAsync(OnsiteModel model);
    }
}
