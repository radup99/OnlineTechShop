using OnlineTechShopApi.Entities;
using OnlineTechShopApi.Repositories;

namespace OnlineTechShopApi.Services
{
    public class ProductService(ProductRepository prodRep, CategoryRepository catRep, FilterRepository fRep)
    {
        private readonly ProductRepository _productRepository = prodRep;
        private readonly CategoryRepository _categoryRepository = catRep;
        private readonly FilterRepository _filterRepository = fRep;

        public async Task<Product?> GetById(int id)
        {
            return await _productRepository.ReadById(id);
        }

        public async Task<Product?> GetByUrlPath(string urlPath)
        {
            return await _productRepository.ReadByUrlPath(urlPath);
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

        public async Task<List<Product>> GetByFilterValue(string filterName, string filterValues, int categoryId)
        {
            List<string> filterValueList = [.. filterValues.Split(',')];
            var filters = await _filterRepository.ReadByFilterValue(filterName, filterValueList, categoryId);
            if (filters == null)
                return [];
            var productIds = filters.Select(f => f.ProductId).ToList();
            var productList = await _productRepository.ReadByIdList(productIds);
            return (productList != null) ? productList : [];
        }
    }
}
