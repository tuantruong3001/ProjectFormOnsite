using App.Domain.Models;
using App.Domain.Entities;

namespace App.Domain.Interfaces.IRepositories
{
    public interface IOnsiteRepo : IBaseRepository<Onsite, int>
    {
        Task<List<Onsite>> GetAllOnsiteAsync();
    }
}
