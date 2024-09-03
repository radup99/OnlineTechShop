using Microsoft.EntityFrameworkCore;
using OnlineTechShopApi.Database;
using OnlineTechShopApi.Entities;

namespace OnlineTechShopApi.Repositories
{
    public class ProductRepository(MainDbContext dbContext) : IRepository<Product>
    {
        private readonly MainDbContext _dbContext = dbContext;
        private readonly DbSet<Product> _dbSet = dbContext.Set<Product>();

        public async Task Create(Product product)
        {
            await _dbSet.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product?> ReadById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Product>?> ReadByCategoryId(int categoryId)
        {
            return await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task Update(int id, Product product)
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
