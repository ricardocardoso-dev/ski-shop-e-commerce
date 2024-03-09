using System.Text.Json;
using api.Data;
using api.Entities;
using api.Extensions;
using api.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

public class ProductsController : BaseApiController
{
	private readonly StoreContext _context;

	public ProductsController(StoreContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<PagedList<Product>>> GetProducts(
		[FromQuery] ProductParams productParams
	)
	{
		var query = _context.Products
			.Filter(productParams.Brands, productParams.Types)
			.Search(productParams.SearchTerm)
			.Sort(productParams.OrderBy)
			.AsQueryable();

		var products = await PagedList<Product>.ToPagedList(
			query,
			productParams.PageNumber,
			productParams.PageSize
		);

		Response.AddPaginationHeader(products.MetaData);

		return products;
	}

	[HttpGet("{id}")] // api/products/3
	public async Task<ActionResult<Product>> GetProduct(int id)
	{
		var products = await _context.Products.FindAsync(id);

		if (products == null)
			return NotFound();

		return products;
	}

	[HttpGet("filters")]
	public async Task<IActionResult> GetFilters()
	{
		var brands = await _context.Products.Select(p => p.Brand).Distinct().ToListAsync();
		var types = await _context.Products.Select(t => t.Type).Distinct().ToListAsync();

		return Ok(new { brands, types });
	}
}
