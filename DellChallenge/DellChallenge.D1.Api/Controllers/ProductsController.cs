using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAsync([FromHeader(Name = "Page")] int? page, [FromHeader(Name = "Page-Size")] int? pageSize, CancellationToken cancellationToken)
        {
            if (!(page.HasValue && pageSize.HasValue) &&
                !(page.HasValue == false == pageSize.HasValue == false))
                return BadRequest("incompleate pagination header parameters");

            if (page != null && page <= 0) return BadRequest("invalid page number");
            if (pageSize != null && pageSize <= 0) return BadRequest("invalid page size");

            var (responseData, totalPages) = await _productsService.GetAllAsync(page, pageSize, cancellationToken);

            if (page > totalPages)
                return NotFound();

            Response.Headers.Add("Total-Pages", totalPages.ToString());

            return Ok(responseData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetAsync(string id, CancellationToken cancellationToken)
        {
            if (id == null || id?.Length == 0) return BadRequest();

            var product = await _productsService.GetAsync(id, cancellationToken);
            if (product == null) return NotFound();
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostAsync(NewProductDto newProduct, CancellationToken cancellationToken)
        {
            var addedProduct = await _productsService.AddAsync(newProduct,cancellationToken );
            return addedProduct;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDto>> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            if (id == null || id?.Length == 0) return BadRequest();

            var prod2Rem = await _productsService.DeleteAsync(id, cancellationToken);
            if (prod2Rem == null) return NotFound();
            return prod2Rem;
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> PutAsync(ProductDto product, CancellationToken cancellationToken)
        {
            var prod2Upd = await _productsService.UpdateAsync(product, cancellationToken);
            if (prod2Upd == null) return NotFound();
            return prod2Upd;
        }
    }
}
