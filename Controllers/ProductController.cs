using GamersChat.Models;
using GamersChat.Services;
using GamersChatAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GamersChat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(Guid id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            Console.WriteLine("AddProduct method fired!");
            if (!ModelState.IsValid)
            {
                // Return a 400 Bad Request response with validation errors
                return BadRequest(ModelState);
            }
            _productService.AddProduct(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public Product EditProduct(Guid id, [FromBody]Product product)
        {
            var productToEdit = _productService.GetProduct(id);
            productToEdit.Title = product.Title;
            productToEdit.Description = product.Description;
            productToEdit.Category = product.Category;
            productToEdit.Price = product.Price;
            productToEdit.City = product.City;
            productToEdit.Email = product.Email;
            productToEdit.CanDeliver = product.CanDeliver;
            productToEdit.ImageUrl = product.ImageUrl;
            productToEdit.IsNew= product.IsNew;
            productToEdit.PhoneNumber = product.PhoneNumber;
            return this._productService.EditProduct(productToEdit);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
