using ProjectFormOnsite.Models;

namespace ProjectFormOnsite.Repositories
{
    public interface IOnsiteRepo
    {
        public Task<List<OnsiteModel>> GetAllOnsiteAsync();
        public Task<InforOnsiteModel> GetOnsiteByIdAsync(int id);
        public Task<int> AddOnsiteAsync(OnsiteModel model);
        public Task UpdateOnsiteAsync(int id, OnsiteModel model);
        public Task DeleteOnsiteAsync(int id);
    }
}
