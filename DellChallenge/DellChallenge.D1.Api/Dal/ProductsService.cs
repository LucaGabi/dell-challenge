using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DellChallenge.D1.Api.Dto;
using Microsoft.EntityFrameworkCore;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> GetAsync(string id, CancellationToken cancellationToken)
        {
            var dbProd = await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return MapToDto(dbProd);
        }

        public async Task<(IEnumerable<ProductDto> products, int totalPages)> GetAllAsync(int? page, int? pageSize, CancellationToken cancellationToken)
        {
            var data = _context.Products.AsQueryable();
            var totalPages = 0;
            if (pageSize.HasValue)
                totalPages = ((data.Count() - 1) / pageSize.Value) + 1;


            if (page != null && pageSize != null)
                data = data.Skip((page.Value - 1) * pageSize.Value)
                           .Take(pageSize.Value);

            if (cancellationToken.IsCancellationRequested)
                return (null,0);

            return ((await data.ToListAsync(cancellationToken)).Select(p => MapToDto(p)), totalPages);
        }

        public async Task<ProductDto> AddAsync(NewProductDto newProduct, CancellationToken cancellationToken)
        {
            var product = MapToData(newProduct);
            await _context.Products.AddAsync(product,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public async Task<ProductDto> UpdateAsync(ProductDto product, CancellationToken cancellationToken)
        {
            var updProduct = MapToData(product, product.Id);
            _context.Attach(updProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return MapToDto(updProduct);
        }

        public async Task<ProductDto> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var dbProd = await _context.Products.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
            if (dbProd == null) return null;
            _context.Products.Remove(dbProd);
            await _context.SaveChangesAsync(cancellationToken);
            return MapToDto(dbProd);
        }

        private Product MapToData(NewProductDto newProduct, string id = null)
        {
            if (newProduct == null) return null;

            return new Product
            {
                Id = id,
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }

    }
}
