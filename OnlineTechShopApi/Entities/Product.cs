using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineTechShopApi.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Sku { get; set; }

        public string ProductName { get; set; }

        public float Price { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }

        public string Specifications { get; set; }

        public Product() { }
    }
}
