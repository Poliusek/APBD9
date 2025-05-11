using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial9.Model;
using Tutorial9.Services;

namespace Tutorial9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
        
        [HttpPost]
        public IActionResult Get([FromBody] Product? product)
        {
            if (product is null)
                return BadRequest("Product cannot be null");
            
            if (_warehouseService.ProductExistsAsync(product.IdProduct).Result == false)
                return NotFound($"Product with ID {product.IdProduct} does not exist");
            
            if (_warehouseService.WarehouseExistsAsync(product.IdWarehouse).Result == false)
                return NotFound($"Warehouse with ID {product.IdWarehouse} does not exist");
            Order? order = _warehouseService.GetOrderAsync(product.IdProduct, product.Amount, product.CreatedAt).Result;
            if (order is null)
                return NotFound("Order does not exist");
            
            if (_warehouseService.WasRealizedAsync(order.IdOrder).Result)
                return NotFound($"Order with ID {order.IdOrder} was realized");
            
            int id = _warehouseService.UpdateOrderAsync(product.IdWarehouse, order.IdProduct, order.IdOrder, order.Amount).Result;
            
            
            return Created("Created ",new { Id = id });
        }
    }
}
