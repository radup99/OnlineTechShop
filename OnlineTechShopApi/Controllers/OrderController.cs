using Microsoft.AspNetCore.Mvc;
using OnlineTechShopApi.Entities;
using OnlineTechShopApi.Enums;
using OnlineTechShopApi.Models;
using OnlineTechShopApi.Repositories;
using OnlineTechShopApi.Services;

namespace OnlineTechShopApi.Controllers
{
	[ApiController]
	[Route("orders")]
	public class OrderController(ILogger<OrderController> logger, OrderService orderService) : ControllerBase
	{
		private readonly ILogger<OrderController> _logger = logger;
		private readonly OrderService _orderService = orderService;

		[HttpPost]
		public async Task<IActionResult> PostOrder(OrderPostModel orderModel)
		{
			var result = await _orderService.CreateOrder(orderModel);
			switch (result.code)
			{
				case OrderPostResult.Success:
					return Ok();
				case OrderPostResult.InvalidProducts:
					return BadRequest($"Invalid product IDs: {string.Join(',', result.ids)}");
				case OrderPostResult.InsufficientStock:
					return BadRequest($"The following product IDs have insufficient stock: {string.Join(',', result.ids)}");
				default:
					return BadRequest("Unknown error");
			}
		}
	}
}
