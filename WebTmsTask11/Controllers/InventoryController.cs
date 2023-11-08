using Microsoft.AspNetCore.Mvc;
using WebTmsTask11.Models;
using WebTmsTask11.Services;

namespace TmsWeb.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _service;

    public InventoryController(IInventoryService service)
    {
        _service = service;
    }

    [HttpPost]
    public ProductListModel GetProducts()
    {
        var reslut = _service.GetProducts();

        return reslut;
    }

    [HttpPost]
    public IActionResult AddProduct([FromBody] AddProductModel product)
    {
        var result = _service.AddProduct(product);

        if (!result.Success)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }

    [HttpPost]
    public IActionResult GetTotalCost()
    {
        var result = _service.GetTotalCost();

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult GetProductCost([FromBody] SelectProductModel product)
    {
        var result = _service.GetProductCost(product);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult DeleteProduct([FromBody] SelectProductModel product)
    {
        var result = _service.DeleteProduct(product);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult UpdateProduct([FromBody] UpdateProductModel updatedProduct)
    {
        var result = _service.UpdateProduct(updatedProduct);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

}
