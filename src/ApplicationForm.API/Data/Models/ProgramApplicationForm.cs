using Newtonsoft.Json;

namespace ApplicationForm.API.Data.Models
{
    public class ProgramApplicationForm
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<FormQuestion> Questions { get; set; } = new();
    }
}
