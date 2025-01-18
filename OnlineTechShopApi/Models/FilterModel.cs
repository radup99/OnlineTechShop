namespace OnlineTechShopApi.Models
{
    public class FilterModel
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }

        public FilterModel(string name, List<string> values)
        {
            Name = name;
            Values = values;
        }
    }
}
