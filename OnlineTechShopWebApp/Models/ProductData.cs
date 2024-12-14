namespace OnlineTechShopWebApp.Models
{
    public class ProductData
    {
        public int CategoryId { get; set; }

        public string Sku { get; set; }

        public string UrlPath { get; set; }

        public string ProductName { get; set; }

        public float Price { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }

        public string Specifications { get; set; }

        public int Id { get; set; }

        public ProductData() { }
    }
}
