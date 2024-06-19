using ApplicationForm.API.Data.Models.Enums;
using Newtonsoft.Json;

namespace ApplicationForm.API.Data.DTO
{
    public class CreateFormQuestionRequestDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("mandatory")]
        public bool Mandatory { get; set; } = true;
        [JsonProperty("internal")]
        public bool Internal { get; set; } = false;
        [JsonProperty("hidden")]
        public bool Hidden { get; set; } = false;
        [JsonProperty("enableOthers")]
        public bool EnableOthers { get; set; } = false;
        [JsonProperty("maxChoiceAllowed")]
        public int? MaxChoiceAllowed { get; set; }
        [JsonProperty("type")]
        public QuestionType Type { get; set; }
        [JsonProperty("group")]
        public QuestionGroup Group { get; set; }
        [JsonProperty("options")]
        public List<CreateQuestionOptionRequestDto> Options { get; set; } = new();
    }
}
