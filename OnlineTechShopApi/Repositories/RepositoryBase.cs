using Microsoft.EntityFrameworkCore;
using OnlineTechShopApi.Database;
using OnlineTechShopApi.Entities;

namespace OnlineTechShopApi.Repositories
{
    public abstract class RepositoryBase<T>(MainDbContext dbContext) where T: EntityBase
    {
        private readonly MainDbContext _dbContext = dbContext;
        private readonly DbSet<T> _dbSet = dbContext.Set<T>();

        public async Task Create(T t)
        {
            _dbSet.Add(t);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>?> ReadAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> ReadById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>?> ReadByIdList(List<int> idList)
        {
            return await _dbSet.Where(t => idList.Contains(t.Id)).ToListAsync();
        }

        public async Task Update(T t)
        {
            _dbSet.Update(t);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            _dbSet.Where(p => p.Id == id).ExecuteDelete();
            await _dbContext.SaveChangesAsync();
        }
    }
}
