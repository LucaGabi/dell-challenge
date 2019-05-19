using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        Task<ProductDto> AddAsync(NewProductDto newProduct, CancellationToken cancellationToken);
        Task<ProductDto> GetAsync(string id, CancellationToken cancellationToken);
        Task<(IEnumerable<ProductDto> products, int totalPages)> GetAllAsync(int? page, int? pageSize, CancellationToken cancellationToken);
        Task<ProductDto> UpdateAsync(ProductDto product, CancellationToken cancellationToken);
        Task<ProductDto> DeleteAsync(string id, CancellationToken cancellationToken);
    }
}
