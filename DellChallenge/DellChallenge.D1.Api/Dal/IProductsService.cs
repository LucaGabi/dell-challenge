using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        ProductDto Add(NewProductDto newProduct);
        ProductDto Get(string id);
        IEnumerable<ProductDto> GetAll(int? page, int? pageSize,out int totalPages);
        ProductDto Update(ProductDto product);
        ProductDto Delete(string id);
    }
}
