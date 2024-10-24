using System.Threading.Tasks;
using HelloWorldCrudDynamoDb.Models;

namespace HelloWorldCrudDynamoDb.Services
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(string productId);

        Task SaveProductAsync(Product product);

        Task DeleteProductAsync(string id);
    }
}