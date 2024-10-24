using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HelloWorldCrudDynamoDb.Models
{
    public class AwsOptions
    {
        public const string Prefix = "AWS";
        
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string Region { get; set; }
    }
}