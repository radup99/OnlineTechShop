namespace OnlineTechShopApi.Repositories
{
    public interface IRepository<T>
    {
        public Task Create(T t);
        public Task<T> ReadById(int id);
        public Task Update(int id, T t);
        public Task DeleteById(int id);
    }
}
