using Microsoft.EntityFrameworkCore;
using OnlineTechShopApi.Database;
using OnlineTechShopApi.Entities;

namespace OnlineTechShopApi.Repositories
{
    public class CategoryRepository(MainDbContext dbContext) : RepositoryBase<Category>(dbContext)
    {
        private readonly MainDbContext _dbContext = dbContext;
        private readonly DbSet<Category> _dbSet = dbContext.Set<Category>();

        public async Task<Category?> ReadByName(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.CategoryName.ToLower() == name.ToLower());
        }
    }
}
