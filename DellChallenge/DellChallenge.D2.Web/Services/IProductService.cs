using DellChallenge.D2.Web.Models;
using System.Collections.Generic;

namespace DellChallenge.D2.Web.Services
{
    public interface IProductService
    {
        ProductModel Add(NewProductModel newProduct);
        ProductModel Get(string id);
        IEnumerable<ProductModel> GetAll();
        ProductModel Update(ProductModel product);
        ProductModel Delete(string id);
    }
}