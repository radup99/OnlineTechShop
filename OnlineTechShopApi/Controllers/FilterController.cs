using Microsoft.AspNetCore.Mvc;
using OnlineTechShopApi.Entities;
using OnlineTechShopApi.Repositories;
using OnlineTechShopApi.Services;

namespace OnlineTechShopApi.Controllers
{
    [ApiController]
    [Route("filters")]
    public class FilterController(ILogger<FilterController> logger, FilterService filterService) : ControllerBase
    {
        private readonly ILogger<FilterController> _logger = logger;
        private readonly FilterService _filterService = filterService;

        [HttpGet("category-id/{id}")]
        public async Task<IActionResult> GetByCategoryId(int id)
        {
            var filters = await _filterService.GetAllFiltersByCategory(id);
            if (filters.Count == 0)
                return NotFound($"No filters found with Category ID: {id}");
            return Ok(filters);
        }
    }
}
