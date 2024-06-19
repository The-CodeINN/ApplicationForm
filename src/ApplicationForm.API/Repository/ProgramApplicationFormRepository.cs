using ApplicationForm.API.Data.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace ApplicationForm.API.Repository
{
    public class ProgramApplicationFormRepository : IProgramApplicationFormRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _configuration;
        private readonly Container _formContainer;
        private readonly Container _responseContainer;

        public ProgramApplicationFormRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _cosmosClient = cosmosClient;
            _configuration = configuration;
            var databaseName = _configuration["CosmosDb:DatabaseName"];
            _formContainer = _cosmosClient.GetContainer(databaseName, "Forms");
            _responseContainer = _cosmosClient.GetContainer(databaseName, "Responses");
        }

        public async Task<ProgramApplicationForm> CreateFormAsync(ProgramApplicationForm form)
        {
            var response = await _formContainer.CreateItemAsync(form);
            return response.Resource;
        }

        public async Task<ProgramApplicationForm> GetFormByIdAsync(string formId)
        {
            var query = _formContainer.GetItemLinqQueryable<ProgramApplicationForm>()
                                                   .Where(a => a.Id == formId)
                                                   .AsQueryable();

            var iterator = query.ToFeedIterator();
            var results = await iterator.ReadNextAsync();
            return results.FirstOrDefault();
        }

        public async Task<IEnumerable<CandidateResponse>> GetResponsesByFormIdAsync(string formId)
        {
            var query = _responseContainer.GetItemLinqQueryable<CandidateResponse>()
                                                      .Where(r => r.FormId == formId)
                                                      .AsQueryable();

            var iterator = query.ToFeedIterator();
            var results = new List<CandidateResponse>();

            while (iterator.HasMoreResults)
            {
                var currentResultSet = await iterator.ReadNextAsync();
                results.AddRange(currentResultSet);
            }

            return results;
        }

        public async Task SaveCandidateResponseAsync(CandidateResponse response)
        {
            await _responseContainer.CreateItemAsync(response);
        }

        public async Task UpdateFormAsync(ProgramApplicationForm form)
        {
            await _formContainer.UpsertItemAsync(form);
        }
    }
}
