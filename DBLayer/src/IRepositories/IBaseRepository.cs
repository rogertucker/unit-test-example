using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DBLayer.Repositories
{
    public interface IBaseRepository<K>
    {
        void Delete(int ID);
        IEnumerable<K> GetAll();
        K GetById(int ID);
        Task<int> CreateAsync(BaseModel model);
        void Create(BaseModel model);
        int Update(BaseModel model);
    }
}