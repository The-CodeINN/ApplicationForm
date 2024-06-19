using Newtonsoft.Json;

namespace ApplicationForm.API.Data.DTO
{
    public class CreateProgramApplicationFormRequestDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("questions")]
        public List<CreateFormQuestionRequestDto> Questions { get; set; } = new();
    }
}
