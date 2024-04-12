using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.IRepositories
{
    public interface IUserRepo : IBaseRepository<User, int>
    {
    }
}
