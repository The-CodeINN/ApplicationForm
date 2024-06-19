using Newtonsoft.Json;

namespace ApplicationForm.API.Data.DTO
{
    public class CreateProgramApplicationFormRequestDto
    {
        [JsonProperty("title")]
        public string Title { get; init; }
        [JsonProperty("description")]
        public string Description { get; init; }
        [JsonProperty("questions")]
        public List<CreateFormQuestionRequestDto> Questions { get; set; } = new();
    }
}
