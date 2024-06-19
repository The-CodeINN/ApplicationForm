using ApplicationForm.API.Controllers;
using ApplicationForm.API.Data.DTO;
using ApplicationForm.API.Data.Models;
using ApplicationForm.API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApplicationForm.API.Test
{
    public class CandidateControllerTests
    {
        private readonly Mock<IProgramApplicationFormRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly CandidateController _controller;

        public CandidateControllerTests()
        {
            _mockRepo = new Mock<IProgramApplicationFormRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();

            _controller = new CandidateController(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetFormQuestions_ReturnsForm_WhenFormExists()
        {
            // Arrange
            var form = new ProgramApplicationForm
            {
                Id = "formId",
                Title = "Sample Form",
                Description = "Sample Description",
                Questions = new List<FormQuestion>()
            };

            _mockRepo.Setup(repo => repo.GetFormByIdAsync(It.IsAny<string>()))
                     .ReturnsAsync(form);

            // Act
            var result = await _controller.GetFormQuestions("formId");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnForm = Assert.IsType<FormResponseDto>(okResult.Value);
            Assert.Equal("Sample Form", returnForm.Title);
        }

        [Fact]
        public async Task SubmitResponse_ReturnsNotFound_WhenFormDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetFormByIdAsync(It.IsAny<string>()))
                     .ReturnsAsync((ProgramApplicationForm)null);

            var responseDto = new CandidateResponseDto();

            // Act
            var result = await _controller.SubmitResponse("invalidFormId", responseDto);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Form with ID invalidFormId does not exist.", notFoundResult.Value);
        }

        [Fact]
        public async Task SubmitResponse_ReturnsBadRequest_WhenResponseIsEmpty()
        {
            // Arrange
            var form = new ProgramApplicationForm();
            _mockRepo.Setup(repo => repo.GetFormByIdAsync(It.IsAny<string>()))
                     .ReturnsAsync(form);

            var responseDto = new CandidateResponseDto
            {
                Responses = new List<QuestionResponseDto>
                {
                    new QuestionResponseDto { QuestionId = "q1", Response = "" }
                }
            };

            // Act
            var result = await _controller.SubmitResponse("formId", responseDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Response to question q1 cannot be empty.", badRequestResult.Value);
        }

        [Fact]
        public async Task SubmitResponse_ReturnsOk_WhenValidResponse()
        {
            // Arrange
            var form = new ProgramApplicationForm();
            _mockRepo.Setup(repo => repo.GetFormByIdAsync(It.IsAny<string>()))
                     .ReturnsAsync(form);

            var responseDto = new CandidateResponseDto
            {
                Responses = new List<QuestionResponseDto>
                {
                    new QuestionResponseDto { QuestionId = "q1", Response = "Answer" }
                }
            };

            // Act
            var result = await _controller.SubmitResponse("formId", responseDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Successfully submitted response.", okResult.Value);
        }
    }
}
