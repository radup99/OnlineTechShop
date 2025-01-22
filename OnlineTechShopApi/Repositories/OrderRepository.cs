using Microsoft.EntityFrameworkCore;
using OnlineTechShopApi.Database;
using OnlineTechShopApi.Entities;

namespace OnlineTechShopApi.Repositories
{
    public class OrderRepository(MainDbContext dbContext) : RepositoryBase<Order>(dbContext)
    {
        private readonly MainDbContext _dbContext = dbContext;
        private readonly DbSet<Order> _dbSet = dbContext.Set<Order>();

        public async Task<List<Order>?> ReadByUserId(int userId)
        {
            return await _dbSet.Where(o => o.UserId == userId).ToListAsync();
        }
    }
}
