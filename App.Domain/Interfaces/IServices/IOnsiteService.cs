using App.Domain.Entities;
using App.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace App.Domain.Interfaces.IServices
{
    public interface IOnsiteService : IBaseService<Onsite, int>
    {
        public Task<List<OnsiteModel>> GetAllOnsiteAsync();
        public Task<InforOnsiteModel> GetOnsiteByIdAsync(int id);
        public Task<int> RegisterOnsiteAsync(RegisterOnsiteModel model);
        public Task ConfirmOnsiteAsync(int id,JsonPatchDocument<ConfirmModel> model);
    }
}
