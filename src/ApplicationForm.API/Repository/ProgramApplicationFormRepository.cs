using ApplicationForm.API.Data.Models;

namespace ApplicationForm.API.Repository
{
    public class ProgramApplicationFormRepository : IProgramApplicationFormRepository
    {
        public Task<ProgramApplicationForm> CreateFormAsync(ProgramApplicationForm form)
        {
            throw new NotImplementedException();
        }

        public Task<ProgramApplicationForm> GetFormByIdAsync(string formId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CandidateResponse>> GetResponsesByFormIdAsync(string formId)
        {
            throw new NotImplementedException();
        }

        public Task SaveCandidateResponseAsync(CandidateResponse response)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFormAsync(ProgramApplicationForm form)
        {
            throw new NotImplementedException();
        }
    }
}
