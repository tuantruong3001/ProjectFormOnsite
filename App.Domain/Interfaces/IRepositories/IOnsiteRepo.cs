using Microsoft.AspNetCore.JsonPatch;
using App.Domain.Models;
using App.Domain.Entities;

namespace App.Domain.Interfaces.IRepositories
{
    public interface IOnsiteRepo : IBaseRepository<Onsite, int>
    {
        public Task<List<OnsiteModel>> GetAllOnsiteAsync();
        public Task<InforOnsiteModel> GetOnsiteByIdAsync(int id);
        public Task<int> RegisterOnsiteAsync(RegisterOnsiteModel model);
        public Task ConfirmOnsiteAsync(int id, JsonPatchDocument<ConfirmModel> model);
    }
}
