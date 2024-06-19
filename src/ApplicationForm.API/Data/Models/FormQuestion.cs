using ApplicationForm.API.Data.Models.Enums;
using Newtonsoft.Json;

namespace ApplicationForm.API.Data.Models
{
    public class FormQuestion
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Title { get; set; }
        public bool Mandatory { get; set; } = true;
        public bool Internal { get; set; } = false;
        public bool Hidden { get; set; } = false;
        public bool EnableOthers { get; set; } = false;
        public int? MaxChoiceAllowed { get; set; }
        public QuestionType Type { get; set; }
        public QuestionGroup Group { get; set; }
        public List<QuestionOption> Options { get; set; } = new();
    }
}
