using OnlineTechShopApi.Repositories;
using OnlineTechShopApi.Models;
using OnlineTechShopApi.Enums;
using System.Security.Cryptography;
using OnlineTechShopApi.Entities;
using System.Text;

namespace OnlineTechShopApi.Services
{
    public class OrderService(OrderRepository oRep, ProductRepository pRep)
    {
        private readonly OrderRepository _orderRepository = oRep;
        private readonly ProductRepository _productRepository = pRep;

        public async Task<(OrderPostResult code, string ids)> CreateOrder(OrderPostModel orderModel)
        {
            List<int> invalidIds;
            List<int> insufficientStockIds;
            List<Product> products;

            invalidIds = await CheckProductIds(orderModel.Products);
            if (invalidIds.Count != 0)
                return (OrderPostResult.InvalidProducts, string.Join(',', invalidIds));

            insufficientStockIds = await UpdateProductStocks(orderModel.Products);
            if (insufficientStockIds.Count != 0)
                return (OrderPostResult.InsufficientStock, string.Join(',', insufficientStockIds));

            Order order = new(orderModel, 0);
            await _orderRepository.Create(order);
            return (OrderPostResult.Success, "");
        }

        public async Task<List<int>> CheckProductIds(List<OrderedProductModel> productModels)
        {
            List<int> invalidIds = [];
            foreach (var productModel in productModels)
            {
                var product = await _productRepository.ReadById(productModel.Id);
                if (product == null)
                    invalidIds.Add(productModel.Id);
            }
            return invalidIds.Distinct().ToList();
        }

        public async Task<List<int>> UpdateProductStocks(List<OrderedProductModel> productModels)
        {
            List<int> insufficientStockIds = [];
            foreach (var productModel in productModels)
            {
                var product = await _productRepository.ReadById(productModel.Id);
                int totalQuantity = productModels.Where(pm => pm.Id == productModel.Id).Select(pm => pm.Quantity).Sum();
                if (product.Stock < totalQuantity)
                    insufficientStockIds.Add(productModel.Id);
            }
            if (insufficientStockIds.Count() == 0)
            {
                foreach (var productModel in productModels)
                {
                    var product = await _productRepository.ReadById(productModel.Id);
                    product.Stock -= productModel.Quantity;
                    await _productRepository.Update(product);
                }
            }
            return insufficientStockIds.Distinct().ToList();
        }
    }
}
