using Microsoft.EntityFrameworkCore;
using OnlineTechShopApi.Database;
using OnlineTechShopApi.Entities;

namespace OnlineTechShopApi.Repositories
{
    public class UserRepository(MainDbContext dbContext) : RepositoryBase<User>(dbContext)
    {
        private readonly MainDbContext _dbContext = dbContext;
        private readonly DbSet<User> _dbSet = dbContext.Set<User>();

        public async Task<User?> ReadByUsername(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<User?> ReadByEmailAddress(string emailAddress)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.EmailAddress.ToLower() == emailAddress.ToLower());
        }
    }
}
