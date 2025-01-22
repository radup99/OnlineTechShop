using OnlineTechShopApi.Enums;
using OnlineTechShopApi.Models;

namespace OnlineTechShopApi.Entities
{
    public class Order : EntityBase
    {
        public int UserId { get; set; }

        public OrderStatus Status { get; set; }

        public float TotalPrice { get; set; }

        public string ProductIds { get; set; }

        public string ProductQuantites { get; set; }

        public string ProductPrices { get; set; }

        public float ShippingCost { get; set; }

        public string ShippingMethod { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public Order() { }

        public Order(OrderPostModel orderModel, int userId)
        {
            UserId = userId;
            Status = OrderStatus.New;
            TotalPrice = orderModel.TotalPrice;
            ProductIds = string.Join(",", orderModel.Products.Select(p => p.Id).ToList());
            ProductQuantites = string.Join(",", orderModel.Products.Select(p => p.Quantity).ToList());
            ProductPrices = string.Join(",", orderModel.Products.Select(p => p.Price).ToList());
            ShippingCost = orderModel.ShippingCost;
            ShippingMethod = orderModel.ShippingMethod;
            FirstName = orderModel.FirstName;
            LastName = orderModel.LastName;
            Address = orderModel.Address;
            City = orderModel.City;
            ZipCode = orderModel.ZipCode;
            PhoneNumber = orderModel.PhoneNumber;
        }
    }
}
