using Newtonsoft.Json;

namespace ApplicationForm.API.Data.DTO
{
    public class CandidateResponseDto
    {
        [JsonProperty("responses")]
        public List<QuestionResponseDto> Responses { get; set; } = new();
    }
}
