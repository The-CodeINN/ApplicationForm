using Newtonsoft.Json;

namespace ApplicationForm.API.Data.DTO
{
    public class CreateQuestionOptionRequestDto
    {
        [JsonProperty("title")]
        public string Title { get; init; }
    }
}
