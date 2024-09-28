namespace OnlineTechShopApi.Models
{
    public class FilterGetModel
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }

        public FilterGetModel(string name, List<string> values)
        {
            Name = name;
            Values = values;
        }
    }
}
