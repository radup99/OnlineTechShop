namespace OnlineTechShopApi.Models
{
    public class OrderPostModel
    {
        public float TotalPrice { get; set; }

        public List<OrderedProductModel> Products { get; set; }

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
