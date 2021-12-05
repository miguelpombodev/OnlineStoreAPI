using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
  [Route("products")]
  public class ProductController : ControllerBase
  {
    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext _context)
    {
      var products = await _context.Product.ToListAsync();

      return Ok(products);
    }
  }
}