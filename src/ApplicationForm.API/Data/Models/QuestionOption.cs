using Newtonsoft.Json;

namespace ApplicationForm.API.Data.Models
{
    public class QuestionOption
    {

        [JsonProperty("id")]
        public string Id { get; set; }
        public string Title { get; init; }
    }
}
