using System.Text.Json.Serialization;

namespace ApplicationForm.API.Data.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QuestionGroup
    {
        PersonalInformation,
        CustomQuestions
    }
}
