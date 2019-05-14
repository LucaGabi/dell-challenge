using System.Collections.Generic;
using DellChallenge.D2.Web.Models;
using RestSharp;

namespace DellChallenge.D2.Web.Services
{
    public class ProductService : IProductService
    {
        private RestClient apiClient;
        private string action = "products";

        public ProductService()
        {
            apiClient = new RestClient("http://localhost:5000/api");
        }

        private IRestResponse<TResult> apiCall<TResult>(Method method, string action, object body = null, Dictionary<string, object> parametters = null) where TResult : new()
        {
            
            var apiRequest = new RestRequest(action, method, body==null? DataFormat.None:DataFormat.Json);
            if (parametters?.Count > 0)
            {
                foreach (var p in parametters)
                {
                    apiRequest.AddParameter(p.Key, p.Value);
                }
            }
            if (body != null)
            {
                apiRequest.AddJsonBody(body);
            }
            
            try
            {
                var apiResponse = apiClient.Execute<TResult>(apiRequest);
                if ((int)apiResponse.StatusCode / 100 != 2)
                {
                    //log...
                    return apiResponse;
                }
                return apiResponse;
            }
            catch (System.Exception)
            {
                //log ...
                return null;
            }
        }

        public ProductModel Add(NewProductModel newProduct)
        {

            var apiResponse = apiCall<ProductModel>(Method.POST, action, newProduct);

            return apiResponse.Data;
        }

        public IEnumerable<ProductModel> GetAll()
        {

            var apiResponse = apiCall<List<ProductModel>>(Method.GET,action);

            return apiResponse.Data;
        }

        public ProductModel Get(string id)
        {

            var apiResponse = apiCall<ProductModel>(Method.GET, action+"/"+id);

            return apiResponse.Data;
        }

        public ProductModel Update(ProductModel product)
        {
            
            var apiResponse = apiCall<ProductModel>(Method.PUT,action,product);

            return apiResponse.Data;
        }

        public ProductModel Delete(string id)
        {
            var apiResponse = apiCall<ProductModel>(Method.DELETE, action + "/" + id);
            return apiResponse.Data;
        }
    }
}
