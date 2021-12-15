using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data;
using OnlineStore.Models;
using OnlineStore.Business.Implementations;
using System;

namespace OnlineStore.Controllers
{
  [Route("products")]
  public class ProductController : ControllerBase
  {
    private IProductBusiness _productBusiness;
    public ProductController(IProductBusiness productBusiness)
    {
            _productBusiness = productBusiness;
    }

    [HttpPost]
    public async Task<Product> Create([FromBody] Product _model)
    {
      var product = await _productBusiness.Create(_model);

      if (!(product is Product))
      {
        return BadRequest(product);
      }

      return Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
      var products = await _productBusiness.GetAll();

      return Ok(products);
    }


    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<Product>> GetById(Guid id, [FromServices] DataContext _context)
    {

      var product = await _productBusiness.GetByID(id);

      if (product == null)
      {
        return NotFound(new { message = "Produto não existente" });
      }

      return Ok(product);
    }


    [HttpPut("{id:Guid}")]
    public async Task<ActionResult<Product>> Update(Guid id, [FromBody] Product _model)
    {
     //if(ModelState.IsValid)
     //    return ModelState.

      var product = await _productBusiness.Update(id, _model);

      if (product == null)
      {
        return NotFound(new { message = "Product not found" });
      }

      return Ok(product);
    }
  }
}