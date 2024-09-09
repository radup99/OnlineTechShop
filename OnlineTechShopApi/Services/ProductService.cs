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

        public async Task<List<Product>> GetByCategoryId(int categoryId)
        {
            var productList = await _productRepository.ReadByCategoryId(categoryId);
            return (productList != null) ? productList : [];
        }

        public async Task<List<Product>> GetByCategoryName(string categoryName)
        {
            var category = await _categoryRepository.ReadByName(categoryName);
            if (category == null)
                return [];
            var productList = await _productRepository.ReadByCategoryId(category.Id);
            return (productList != null) ? productList : [];
        }
    }
}
