using ProjectFormOnsite.Models;

namespace ProjectFormOnsite.Repositories
{
    public interface IOnsiteRepo
    {
        public Task<List<OnsiteModel>> GetAllOnsite();
        public Task<OnsiteModel> GetOnsite(int id);
        public Task<int> AddOnsite(OnsiteModel model);
        //public Task<int> UpdateOnsite(int id, OnsiteModel model);
        //public Task DeleteOnsite(int id);
    }
}
