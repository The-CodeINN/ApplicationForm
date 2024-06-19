using Newtonsoft.Json;

namespace ApplicationForm.API.Data.DTO
{
    public class FormResponseDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("questions")]
        public List<FormQuestionResponseDto> Questions { get; set; } = new();
    }

    public class FormQuestionResponseDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("mandatory")]
        public bool Mandatory { get; set; }

        [JsonProperty("internal")]
        public bool Internal { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("enableOthers")]
        public bool EnableOthers { get; set; }

        [JsonProperty("maxChoiceAllowed")]
        public int? MaxChoiceAllowed { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("options")]
        public List<QuestionOptionResponseDto> Options { get; set; } = new();
    }

    public class QuestionOptionResponseDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
