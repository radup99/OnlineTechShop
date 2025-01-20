using OnlineTechShopApi.Enums;

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
	}
}
