using Microsoft.AspNetCore.JsonPatch;
using App.Domain.Models;

namespace App.Domain.Interfaces.IRepositories
{
    public interface IOnsiteRepo
    {
        public Task<List<OnsiteModel>> GetAllOnsiteAsync();
        public Task<InforOnsiteModel> GetOnsiteByIdAsync(int id);
        public Task<int> CreateOnsiteAsync(OnsiteModel model);
        public Task<int> RegisterOnsiteAsync(RegisterOnsiteModel model);
        public Task UpdateOnsiteAsync(int id, OnsiteModel model);
        public Task DeleteOnsiteAsync(int id);
        public Task ConfirmOnsiteAsync(int id, JsonPatchDocument<ConfirmModel> model);
    }
}
