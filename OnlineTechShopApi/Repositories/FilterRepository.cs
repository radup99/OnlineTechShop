using Microsoft.EntityFrameworkCore;
using OnlineTechShopApi.Database;
using OnlineTechShopApi.Entities;

namespace OnlineTechShopApi.Repositories
{
    public class FilterRepository(MainDbContext dbContext) : IRepository<Filter>
    {
        private readonly MainDbContext _dbContext = dbContext;
        private readonly DbSet<Filter> _dbSet = dbContext.Set<Filter>();

        public async Task Create(Filter filter)
        {
            await _dbSet.AddAsync(filter);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Filter?> ReadById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Filter>?> ReadByFilterValue(string name, string value)
        {
            return await _dbSet.Where(f => f.FilterName.ToLower() == name.ToLower() && f.Value.ToLower() == value.ToLower()).ToListAsync();
        }

        public async Task Update(int id, Filter filter)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            await _dbSet.Where(f => f.Id == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
        }
    }
}
