using Microsoft.AspNetCore.Mvc;
using OnlineTechShopApi.Services;

namespace OnlineTechShopApi.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController(ILogger<ProductController> logger, ProductService productService, FilterService filterService) : ControllerBase
    {

        private readonly ILogger<ProductController> _logger = logger;
        private readonly ProductService _productService = productService;
		private readonly FilterService _filterService = filterService;

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound($"No product found with ID: {id}");
            return Ok(product);
        }

        [HttpGet("url-path/{urlPath}")]
        public async Task<IActionResult> GetByUrlPath(string urlPath)
        {
            var product = await _productService.GetByUrlPath(urlPath);
            if (product == null)
                return NotFound($"No product found at URL path: {urlPath}");
            return Ok(product);
        }

        [HttpGet("category-name/{name}")]
        public async Task<IActionResult> GetByCategoryName(string name)
        {
            var products = await _productService.GetByCategoryName(name);
            if (products.Count == 0)
                return NotFound($"No products found with category name: {name}");
            return Ok(products);
        }

        [HttpGet("category-id/{id}")]
        public async Task<IActionResult> GetByCategoryId(int id)
        {
            var products = await _productService.GetByCategoryId(id);
            if (products.Count == 0)
                return NotFound($"No products found with category ID: {id}");
            return Ok(products);
        }

		[HttpGet("category-id/{id}/filters/{filterList}")]
		public async Task<IActionResult> GetByFilters(string filterList, int id)
		{
            var filters = filterList.Split(',').ToList().ConvertAll(f => f.Trim());
            var invalidFilters = _filterService.ValidateFilterParams([.. filters]);
            if (invalidFilters.Count > 0)
                return BadRequest($"Invalid filters: {String.Join("; ", invalidFilters)}");

            var products = await _productService.GetByFilters(filters, id);
			if (products.Count == 0)
				return NotFound($"No filtered products found.");
			return Ok(products);
		}
	}
}
