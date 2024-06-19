using ApplicationForm.API.Data.DTO;
using ApplicationForm.API.Data.Models;
using AutoMapper;

namespace ApplicationForm.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProgramApplicationFormRequestDto, ProgramApplicationForm>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions))
                .ReverseMap();

            CreateMap<CreateFormQuestionRequestDto, FormQuestion>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                .ReverseMap();

            CreateMap<CreateQuestionOptionRequestDto, QuestionOption>()
                .ReverseMap();

            CreateMap<CandidateResponseDto, CandidateResponse>()
                .ReverseMap();

            CreateMap<QuestionResponseDto, QuestionResponse>()
                .ReverseMap();
        }

    }
}
