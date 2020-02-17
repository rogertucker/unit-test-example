using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DBLayer.Repositories
{
    public class BaseRepository<K> : IBaseRepository<K>
        where K: BaseModel
    {
        protected DbSet<K> DataSet { get; set; }
        protected ExampleDbContext Context{get; }
        public BaseRepository(ExampleDbContext context, DbSet<K> dataset)
        {
            Context = context;
            DataSet = dataset;
        }

        public virtual void Delete(int ID)
        {
            K model = GetById(ID);
            Context.Remove(model);
            SaveChanges();
        }


        public virtual async Task<K> GetByIdAsync(int ID)
        {
            K result;
            result = await DataSet.SingleOrDefaultAsync(x => x.ID == ID);
            return result;
        }

        public virtual K GetById(int ID)
        {
            return DataSet.Single(x => x.ID == ID);
        }


        public virtual IEnumerable<K> GetAll()
        {
            return DataSet;
        }
        

        public virtual async Task<int> CreateAsync(BaseModel model)
        {
            int result;

            Context.Add(model);
            result = await SaveChangesAsync();
            return result;
        }

        public virtual void Create(BaseModel model)
        {
                Context.Add(model);
                SaveChanges();
        }


        private async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        public int Update(BaseModel model)
        {
            SaveChanges();
            return model.ID;
        }

    }
}