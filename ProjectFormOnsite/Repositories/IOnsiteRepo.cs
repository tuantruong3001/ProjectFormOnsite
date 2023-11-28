using Microsoft.AspNetCore.JsonPatch;
using App.API.Models;

namespace App.API.Repositories
{
    public interface IOnsiteRepo
    {
        public Task<List<OnsiteModel>> GetAllOnsiteAsync();
        public Task<InforOnsiteModel> GetOnsiteByIdAsync(int id);
        public Task<int> AddOnsiteAsync(OnsiteModel model);
        public Task<int> RegisterOnsiteAsync(OnsiteModel model);
        public Task UpdateOnsiteAsync(int id, OnsiteModel model);
        public Task DeleteOnsiteAsync(int id);
        public Task ConfirmOnsiteAsync(int id, JsonPatchDocument<ConfirmModel> model);
    }
}
