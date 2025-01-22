using Microsoft.EntityFrameworkCore;
using OnlineTechShopApi.Database;
using OnlineTechShopApi.Entities;

namespace OnlineTechShopApi.Repositories
{
    public class FilterRepository(MainDbContext dbContext) : RepositoryBase<Filter>(dbContext)
    {
        private readonly MainDbContext _dbContext = dbContext;
        private readonly DbSet<Filter> _dbSet = dbContext.Set<Filter>();

        public async Task<List<Filter>?> ReadByFilterValue(string name, List<string> values, int categoryId)
        {
            values = values.ConvertAll(v => v.ToLower());
            return await _dbSet.Where(
                f => f.FilterName.ToLower() == name.ToLower() &&
                values.Contains(f.Value.ToLower()) &&
                f.CategoryId == categoryId
                ).ToListAsync();
        }

        public async Task<List<Filter>?> ReadByFilterValue(string name, List<string> values, int categoryId, List<int> productIds)
        {
            values = values.ConvertAll(v => v.ToLower());
            return await _dbSet.Where(
                f => f.FilterName.ToLower() == name.ToLower() &&
                values.Contains(f.Value.ToLower()) &&
                f.CategoryId == categoryId &&
                productIds.Contains(f.ProductId)
                ).ToListAsync();
        }

        public async Task<List<Filter>?> ReadByCategoryId(int categoryId)
        {
            return await _dbSet.Where(f => f.CategoryId == categoryId).ToListAsync();
        }
    }
}
