
using ApplicationForm.API.Repository;
using Microsoft.Azure.Cosmos;
using System.Text.Json.Serialization;

namespace ApplicationForm.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            var configuration = builder.Configuration;

            builder.Services.AddSingleton((provider) =>
            {
                var endpointUri = configuration["CosmosDb:EndpointUri"];
                var primaryKey = configuration["CosmosDb:PrimaryKey"];
                var databaseName = configuration["CosmosDb:DatabaseName"];

                var cosmosClientOptions = new CosmosClientOptions
                {
                    ApplicationName = databaseName
                };

                var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

                var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);

                cosmosClient.ClientOptions.ConnectionMode = ConnectionMode.Direct;

                return cosmosClient;
            });


            builder.Services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                            });
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IProgramApplicationFormRepository, ProgramApplicationFormRepository>();


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
}
