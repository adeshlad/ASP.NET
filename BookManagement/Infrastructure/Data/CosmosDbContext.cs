using Microsoft.Azure.Cosmos;

namespace BookManagement.Infrastructure.Data
{
    public class CosmosDbContext
    {
        public Container Container { get; }

        public CosmosDbContext(IConfiguration configuration)
        {
            string endpointUri = configuration["CosmosDb:EndpointUri"];
            string primaryKey = configuration["CosmosDb:PrimaryKey"];
            string databaseName = configuration["CosmosDb:DatabaseName"];
            string containerName = configuration["CosmosDb:ContainerName"];

            var cosmosClient = new CosmosClient(endpointUri, primaryKey);
            var database = cosmosClient.GetDatabase(databaseName);
            Container = database.GetContainer(containerName);
        }
    }
}
