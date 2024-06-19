using ApplicationForm.API.Data.DTO;
using ApplicationForm.API.Data.Models;
using ApplicationForm.API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationForm.API.Controllers
{
    [Route("api/employer")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IProgramApplicationFormRepository _applicationFormRepository;
        private readonly IMapper _mapper;

        public EmployerController(IProgramApplicationFormRepository applicationFormRepository, IMapper mapper)
        {
            _applicationFormRepository = applicationFormRepository;
            _mapper = mapper;
        }

        [HttpPost("create-form")]
        public async Task<IActionResult> CreateForm([FromBody] CreateProgramApplicationFormRequestDto createDto)
        {
            var applicationForm = _mapper.Map<ProgramApplicationForm>(createDto);
            applicationForm.Id = Guid.NewGuid().ToString();

            foreach (var question in applicationForm.Questions)
            {
                question.Id = Guid.NewGuid().ToString();
                foreach (var option in question.Options)
                {
                    option.Id = Guid.NewGuid().ToString();
                }
            }

            var createdApplicationForm = await _applicationFormRepository.CreateFormAsync(applicationForm);
            var applicationFormDto = _mapper.Map<CreateProgramApplicationFormRequestDto>(createdApplicationForm);
            return CreatedAtAction(nameof(GetFormById), new { formId = createdApplicationForm.Id }, applicationFormDto);
        }

        [HttpGet("{formId}")]
        public async Task<IActionResult> GetFormById(string formId)
        {
            var form = await _applicationFormRepository.GetFormByIdAsync(formId);
            if (form == null)
            {
                return NotFound();
            }

            var formDto = _mapper.Map<CreateProgramApplicationFormRequestDto>(form);
            return Ok(formDto);
        }

        [HttpPut("{formId}")]
        public async Task<IActionResult> UpdateForm(string formId, [FromBody] CreateProgramApplicationFormRequestDto updateDto)
        {
            var form = await _applicationFormRepository.GetFormByIdAsync(formId);
            if (form == null)
            {
                return NotFound();
            }

            // Manually map updated properties from DTO to the existing form
            form.Title = updateDto.Title;
            form.Description = updateDto.Description;

            foreach (var updatedQuestionDto in updateDto.Questions)
            {
                var existingQuestion = form.Questions.FirstOrDefault(q => q.Title == updatedQuestionDto.Title);
                if (existingQuestion != null)
                {
                    // Update existing question properties
                    _mapper.Map(updatedQuestionDto, existingQuestion);
                }
                else
                {
                    // Add new question with generated ID
                    var newQuestion = _mapper.Map<FormQuestion>(updatedQuestionDto);
                    newQuestion.Id = Guid.NewGuid().ToString();
                    foreach (var option in newQuestion.Options)
                    {
                        option.Id = Guid.NewGuid().ToString();
                    }
                    form.Questions.Add(newQuestion);
                }
            }

            await _applicationFormRepository.UpdateFormAsync(form);
            return NoContent();
        }
    }
}
