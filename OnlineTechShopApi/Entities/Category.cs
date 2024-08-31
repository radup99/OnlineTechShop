using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineTechShopApi.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string CategoryName { get; set; }

        public string ValidFilters { get; set; }

        public Category() { }
    }
}
