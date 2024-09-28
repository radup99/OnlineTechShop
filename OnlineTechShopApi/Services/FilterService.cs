using OnlineTechShopApi.Repositories;
using OnlineTechShopApi.Models;

namespace OnlineTechShopApi.Services
{
    public class FilterService(FilterRepository fRep)
    {
        private readonly FilterRepository _filterRepository = fRep;

        public async Task<List<FilterGetModel>> GetAllFiltersByCategory(int categoryId)
        {
            var filters = await _filterRepository.ReadByCategoryId(categoryId);
            if (filters == null)
                return [];

            var filterDict = new Dictionary<string, List<string>>();
            foreach(var f in filters)
            {
                if (filterDict.ContainsKey(f.FilterName))
                {
                    if (!filterDict[f.FilterName].Contains(f.Value))
                        filterDict[f.FilterName].Add(f.Value);
                }
                else
                {
                    filterDict.Add(f.FilterName, [f.Value]);
                }
            }
            return filterDict.Select(fd => new FilterGetModel(fd.Key, fd.Value)).ToList();
        }
    }
}
