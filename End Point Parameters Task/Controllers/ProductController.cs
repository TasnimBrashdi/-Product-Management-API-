using End_Point_Parameters_Task.Models;
using End_Point_Parameters_Task.Sevices;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace End_Point_Parameters_Task.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAllProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var products = _productService.GetAllProducts(pageNumber, pageSize);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
         
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductInputDTO inputDto)
        {
            //hecks if the data received in the HTTP request is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _productService.AddProduct(inputDto);
            return CreatedAtAction(nameof(GetProductById), new { id = result.Name }, result);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductInputDTO inputDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedProduct = _productService.UpdateProduct(id, inputDto);
                return Ok(updatedProduct);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

    }
}
