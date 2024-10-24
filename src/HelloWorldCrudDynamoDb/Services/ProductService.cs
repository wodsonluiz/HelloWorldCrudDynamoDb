using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using HelloWorldCrudDynamoDb.Models;

namespace HelloWorldCrudDynamoDb.Services
{
    public class ProductService : IProductService
    {
        private readonly DynamoDBContext _dynamoDBContext;

        public ProductService(IAmazonDynamoDB amazonDynamoDB)
        {
            _dynamoDBContext = new DynamoDBContext(amazonDynamoDB);
        }

        public async Task<Product> GetProductByIdAsync(string productId)
        {
            return await _dynamoDBContext.LoadAsync<Product>(productId);
        }

        public async Task SaveProductAsync(Product product)
        {
            await _dynamoDBContext.SaveAsync(product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _dynamoDBContext.DeleteAsync<Product>(id);
        }
    }
}