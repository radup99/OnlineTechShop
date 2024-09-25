﻿using Microsoft.EntityFrameworkCore;
using OnlineTechShopApi.Database;
using OnlineTechShopApi.Entities;

namespace OnlineTechShopApi.Repositories
{
    public class FilterRepository(MainDbContext dbContext) : RepositoryBase<Filter>(dbContext)
    {
        private readonly MainDbContext _dbContext = dbContext;
        private readonly DbSet<Filter> _dbSet = dbContext.Set<Filter>();

        public async Task<List<Filter>?> ReadByFilterValue(string name, string value)
        {
            return await _dbSet.Where(f => f.FilterName.ToLower() == name.ToLower() && f.Value.ToLower() == value.ToLower()).ToListAsync();
        }
    }
}
