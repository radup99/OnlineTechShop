using Microsoft.EntityFrameworkCore;
using OnlineTechShopApi.Database;
using OnlineTechShopApi.Entities;

namespace OnlineTechShopApi.Repositories
{
    public class CategoryRepository(MainDbContext dbContext) : IRepository<Category>
    {
        private readonly MainDbContext _dbContext = dbContext;
        private readonly DbSet<Category> _dbSet = dbContext.Set<Category>();

        public async Task Create(Category category)
        {
            await _dbSet.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Category?> ReadById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Update(int id, Category category)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(int id)
        {
            await _dbSet.Where(p => p.Id == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
        }
    }
}
