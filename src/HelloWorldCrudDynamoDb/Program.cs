using Amazon.DynamoDBv2;
using Amazon.Runtime;
using HelloWorldCrudDynamoDb.Models;
using HelloWorldCrudDynamoDb.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloWorldCrudDynamoDb;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        var options = new AwsOptions();
        builder.Configuration.GetSection(AwsOptions.Prefix).Bind(options);

        var credentials = new BasicAWSCredentials(options.AccessKey, options.SecretKey);
        var config = new AmazonDynamoDBConfig
        {
            RegionEndpoint = Amazon.RegionEndpoint.USEast1
        };
        var clientAWS = new AmazonDynamoDBClient(credentials, config);

        builder.Services.AddSingleton<IAmazonDynamoDB>(sp => clientAWS);
        builder.Services.AddScoped<IProductService, ProductService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
