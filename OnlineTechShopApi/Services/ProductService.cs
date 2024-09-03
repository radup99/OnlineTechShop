using OnlineTechShopApi.Entities;
using OnlineTechShopApi.Repositories;

namespace OnlineTechShopApi.Services
{
    public class ProductService(ProductRepository productRepository, CategoryRepository categoryRepository)
    {
        private readonly ProductRepository _productRepository = productRepository;
        private readonly CategoryRepository _categoryRepository = categoryRepository;

        public async Task<Product?> GetById(int id)
        {
            return await _productRepository.ReadById(id);
        }

        public async Task<List<Product>?> GetByCategoryId(int categoryId)
        {
            return await _productRepository.ReadByCategoryId(categoryId);
        }

        public async Task<List<Product>?> GetByCategoryName(string categoryName)
        {
            var category = await _categoryRepository.ReadByName(categoryName);
            var categoryId = category != null ? category.Id : 0;
            return await _productRepository.ReadByCategoryId(categoryId);
        }
    }
}
