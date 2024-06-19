using ApplicationForm.API.Data.DTO;
using ApplicationForm.API.Data.Models;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProgramApplicationForm, FormResponseDto>();
        CreateMap<FormQuestion, FormQuestionResponseDto>();
        CreateMap<QuestionOption, QuestionOptionResponseDto>();

        CreateMap<CreateProgramApplicationFormRequestDto, ProgramApplicationForm>()
            .ForMember(dest => dest.Questions, opt => opt.Ignore());
        CreateMap<CreateFormQuestionRequestDto, FormQuestion>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Options, opt => opt.Ignore());
        CreateMap<CreateQuestionOptionRequestDto, QuestionOption>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<ProgramApplicationForm, CreateProgramApplicationFormRequestDto>();
        CreateMap<FormQuestion, CreateFormQuestionRequestDto>();
        CreateMap<QuestionOption, CreateQuestionOptionRequestDto>();

        CreateMap<CandidateResponseDto, CandidateResponse>();
        CreateMap<QuestionResponseDto, QuestionResponse>();
    }
}
