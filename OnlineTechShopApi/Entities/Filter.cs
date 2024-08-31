using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineTechShopApi.Entities
{
    public class Filter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FilterName { get; set; }

        public string Value { get; set; }

        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public Filter() { }
    }
}
