using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowReactCors")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(string id)
        {
            if (id == null || id?.Length == 0) return BadRequest();

            var product = _productsService.Get(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpPost]
        public ActionResult<ProductDto> Post(NewProductDto newProduct)
        {
            var addedProduct = _productsService.Add(newProduct);
            return addedProduct;
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDto> Delete(string id)
        {
            if (id == null || id?.Length == 0) return BadRequest();

            var prod2Rem = _productsService.Delete(id);
            if (prod2Rem == null) return NotFound();
            return prod2Rem;
        }

        [HttpPut]
        public ActionResult<ProductDto> Put(ProductDto product)
        {
            var prod2Upd = _productsService.Update(product);
            if (prod2Upd == null) return NotFound();
            return prod2Upd;
        }
    }
}
