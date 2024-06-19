using ApplicationForm.API.Data.Models;

namespace ApplicationForm.API.Repository
{
    public interface IProgramApplicationFormRepository
    {
        Task<ProgramApplicationForm> CreateFormAsync(ProgramApplicationForm form);
        Task<ProgramApplicationForm> GetFormByIdAsync(string formId);
        Task UpdateFormAsync(ProgramApplicationForm form);
        Task SaveCandidateResponseAsync(CandidateResponse response);
        Task<IEnumerable<CandidateResponse>> GetResponsesByFormIdAsync(string formId);
    }
}
