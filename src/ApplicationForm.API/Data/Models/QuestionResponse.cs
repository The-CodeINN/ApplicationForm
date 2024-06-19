using Newtonsoft.Json;

namespace ApplicationForm.API.Data.Models
{
    public class QuestionResponse
    {
        [JsonProperty("questionId")]
        public string QuestionId { get; set; }
        public string Response { get; set; }
    }
}
