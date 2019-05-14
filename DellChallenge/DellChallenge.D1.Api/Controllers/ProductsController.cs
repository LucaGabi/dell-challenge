using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<string> Get(string id)
        {
            if (id?.Length == 0) return BadRequest();

            var product = _productsService.Get(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Post([FromBody] NewProductDto newProduct)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);
            var addedProduct = _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Delete(string id)
        {
            if (id?.Length == 0) return BadRequest();
            
            var prod2Rem = _productsService.Delete(id);
            if (prod2Rem == null) return NotFound();
            return Ok(prod2Rem);
        }

        [HttpPut]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Put([FromBody] ProductDto product)
        {
            if (product.Id?.Length == 0) return BadRequest();

            if (!ModelState.IsValid) BadRequest(ModelState);
            var prod2Upd = _productsService.Update(product);
            if (prod2Upd == null) return NotFound();
            return Ok(prod2Upd);
        }
    }
}
