using ApplicationForm.API.Controllers;
using ApplicationForm.API.Data.DTO;
using ApplicationForm.API.Data.Models;
using ApplicationForm.API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApplicationForm.API.Test
{
    public class EmployerControllerTests
    {
        private readonly Mock<IProgramApplicationFormRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly EmployerController _controller;

        public EmployerControllerTests()
        {
            _mockRepo = new Mock<IProgramApplicationFormRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();

            _controller = new EmployerController(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task CreateForm_ReturnsCreatedAtAction_WhenFormIsCreated()
        {
            // Arrange
            var createDto = new CreateProgramApplicationFormRequestDto
            {
                Title = "New Form",
                Description = "Form Description",
                Questions = new List<CreateFormQuestionRequestDto>
                {
                    new CreateFormQuestionRequestDto
                    {
                        Title = "Question 1",
                        Type = Data.Models.Enums.QuestionType.Text,
                        Group = Data.Models.Enums.QuestionGroup.CustomQuestions,
                        Options = new List<CreateQuestionOptionRequestDto>()
                    }
                }
            };

            var createdForm = _mapper.Map<ProgramApplicationForm>(createDto);
            createdForm.Id = "formId";

            _mockRepo.Setup(repo => repo.CreateFormAsync(It.IsAny<ProgramApplicationForm>()))
                     .ReturnsAsync(createdForm);

            // Act
            var result = await _controller.CreateForm(createDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnDto = Assert.IsType<CreateProgramApplicationFormRequestDto>(createdAtActionResult.Value);
            Assert.Equal("New Form", returnDto.Title);
            Assert.Equal("GetFormById", createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task GetFormById_ReturnsForm_WhenFormExists()
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
            var result = await _controller.GetFormById("formId");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnForm = Assert.IsType<CreateProgramApplicationFormRequestDto>(okResult.Value);
            Assert.Equal("Sample Form", returnForm.Title);
        }

        [Fact]
        public async Task GetFormById_ReturnsNotFound_WhenFormDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetFormByIdAsync(It.IsAny<string>()))
                     .ReturnsAsync((ProgramApplicationForm)null);

            // Act
            var result = await _controller.GetFormById("invalidFormId");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateForm_ReturnsNoContent_WhenFormIsUpdated()
        {
            // Arrange
            var existingForm = new ProgramApplicationForm
            {
                Id = "formId",
                Title = "Existing Form",
                Description = "Existing Description",
                Questions = new List<FormQuestion>()
            };

            var updateDto = new CreateProgramApplicationFormRequestDto
            {
                Title = "Updated Form",
                Description = "Updated Description",
                Questions = new List<CreateFormQuestionRequestDto>
                {
                    new CreateFormQuestionRequestDto
                    {
                        Title = "Updated Question",
                        Type = Data.Models.Enums.QuestionType.Text,
                        Group = Data.Models.Enums.QuestionGroup.CustomQuestions,
                        Options = new List<CreateQuestionOptionRequestDto>()
                    }
                }
            };

            _mockRepo.Setup(repo => repo.GetFormByIdAsync(It.IsAny<string>()))
                     .ReturnsAsync(existingForm);

            // Act
            var result = await _controller.UpdateForm("formId", updateDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateForm_ReturnsNotFound_WhenFormDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetFormByIdAsync(It.IsAny<string>()))
                     .ReturnsAsync((ProgramApplicationForm)null);

            var updateDto = new CreateProgramApplicationFormRequestDto();

            // Act
            var result = await _controller.UpdateForm("invalidFormId", updateDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
