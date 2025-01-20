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

            (invalidIds, products) = await CheckProductIds(orderModel.Products);
            if (invalidIds.Count != 0)
                return (OrderPostResult.InvalidProducts, string.Join(',', invalidIds));

            insufficientStockIds = await UpdateProductStocks(products, orderModel.Products);
            if (insufficientStockIds.Count != 0)
				return (OrderPostResult.InsufficientStock, string.Join(',', invalidIds));

            Order order = new(orderModel, 0);
            await _orderRepository.Create(order);
            return (OrderPostResult.Success, "");
		}

        public async Task<(List<int>, List<Product>)> CheckProductIds(List<OrderedProductModel> productModels)
        {
            List<int> invalidIds = [];
            List<Product> products = [];
            foreach (var productModel in productModels)
            {
                var product = await _productRepository.ReadById(productModel.Id);
                if (product == null)
                    invalidIds.Add(productModel.Id);
                else
                    products.Add(product);
            }
            return (invalidIds, products);
        }

		public async Task<List<int>> UpdateProductStocks(List<Product> products, List<OrderedProductModel> productModels)
		{
			List<int> insufficientStockIds = [];
			for (int i = 0; i < products.Count; i++)
			{
                if (products[i].Stock < productModels[i].Quantity)
                    insufficientStockIds.Add(products[i].Id);
                else
                {
					products[i].Stock -= productModels[i].Quantity;
                    await _productRepository.Update(products[i]);
				}
			}
            return insufficientStockIds;
		}
	}
}
