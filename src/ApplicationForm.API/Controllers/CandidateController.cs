using ApplicationForm.API.Data.DTO;
using ApplicationForm.API.Data.Models;
using ApplicationForm.API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationForm.API.Controllers
{
    [Route("api/candidate")]
    [ApiController]
    public class CandidateController(IProgramApplicationFormRepository _formRepository, IMapper _mapper) : ControllerBase
    {
        [HttpGet("form/{formId}")]
        public async Task<IActionResult> GetFormQuestions(string formId)
        {
            var form = await _formRepository.GetFormByIdAsync(formId);
            if (form == null)
            {
                return NotFound();
            }

            var formDto = _mapper.Map<FormResponseDto>(form);
            return Ok(formDto);
        }

        [HttpPost("response/{formId}")]
        public async Task<IActionResult> SubmitResponse(string formId, [FromBody] CandidateResponseDto responseDto)
        {
            var form = await _formRepository.GetFormByIdAsync(formId);
            if (form == null)
            {
                return NotFound($"Form with ID {formId} does not exist.");
            }

            // Validate responses
            foreach (var resp in responseDto.Responses)
            {
                if (string.IsNullOrWhiteSpace(resp.Response))
                {
                    return BadRequest($"Response to question {resp.QuestionId} cannot be empty.");
                }
            }

            var response = _mapper.Map<CandidateResponse>(responseDto);
            response.Id = Guid.NewGuid().ToString(); // Generate new ID
            response.FormId = formId; // Set formId
            await _formRepository.SaveCandidateResponseAsync(response);
            return Ok("Successfully submitted response.");
        }
    }
}
