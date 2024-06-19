using Newtonsoft.Json;

namespace ApplicationForm.API.Data.DTO
{
    public class QuestionResponseDto
    {
        [JsonProperty("questionId")]
        public string QuestionId { get; set; }
        [JsonProperty("response")]
        public string Response { get; set; }
    }
}
