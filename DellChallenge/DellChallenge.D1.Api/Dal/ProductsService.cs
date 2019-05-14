using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public ProductDto Update(ProductDto product)
        {
            var updProduct = MapToData(product,product.Id);
            _context.Attach(updProduct).State=EntityState.Modified;
            _context.SaveChanges();
            return MapToDto(updProduct);
        }

        public ProductDto Delete(string id)
        {
            var dbProd = _context.Products.FirstOrDefault(x => x.Id == id);
            if (dbProd == null) return null;
            _context.Products.Remove(dbProd);
            _context.SaveChanges();
            return MapToDto(dbProd);
        }

        private Product MapToData(NewProductDto newProduct, string id=null)
        {
            return new Product
            {
                Id=id,
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }

        public ProductDto Get(string id)
        {
            var dbProd = _context.Products.FirstOrDefault(x => x.Id == id);
            if (dbProd == null) return null;
            return MapToDto(dbProd);
        }
    }
}
