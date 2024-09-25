using Microsoft.EntityFrameworkCore;
using OnlineTechShopApi.Database;
using OnlineTechShopApi.Entities;

namespace OnlineTechShopApi.Repositories
{
    public class ProductRepository(MainDbContext dbContext) : RepositoryBase<Product>(dbContext)
    {
        private readonly MainDbContext _dbContext = dbContext;
        private readonly DbSet<Product> _dbSet = dbContext.Set<Product>();

        public async Task<List<Product>?> ReadByCategoryId(int categoryId)
        {
            return await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
        }
    }
}
