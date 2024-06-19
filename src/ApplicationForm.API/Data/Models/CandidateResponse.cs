using Newtonsoft.Json;

namespace ApplicationForm.API.Data.Models
{
    public class CandidateResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string FormId { get; set; }
        public List<QuestionResponse> Responses { get; set; } = new();
    }
}
