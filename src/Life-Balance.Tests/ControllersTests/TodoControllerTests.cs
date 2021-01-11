using System;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Life_Balance.WebApp.Controllers.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Life_Balance.Tests.ControllersTests
{
    public class TodoControllerTests
    {
        private static readonly Mock<IToDoService> ToDoServiceMock = new Mock<IToDoService>();
        private static readonly Mock<ILogger<TodoController>> LoggerMock = new Mock<ILogger<TodoController>>();
        private static readonly Mock<IIdentityService> IdentityMock = new Mock<IIdentityService>();
        private static readonly Mock<IProfileService> ProfileMock = new Mock<IProfileService>();
        private static readonly Mock<IRepository<ToDo>> RepositoryMock = new Mock<IRepository<ToDo>>();

        private readonly TodoController _controller = new TodoController(ToDoServiceMock.Object,
                                                                           LoggerMock.Object,
                                                                           IdentityMock.Object);
        
        [Fact]
        public async Task TodoUpdate_WithValidModel_Return_OkResult()
        {
            //Arrange
            var toDoDto = new ToDoDTO
            {
                Title = "FAKE",
                Description = "FAKE",
                IsComplete = false,
                Time = DateTime.Now.AddHours(2)
            };
            
            //Act
            var result = await _controller.Update(toDoDto);
            
            //Assert
            Assert.IsType<OkResult>(result);
        }
        
        [Fact]
        public async Task TodoDelete_WithValidModel_Return_NoContent()
        {
            //Arrange
            var id = 1;
            
            //Act
            var result = await _controller.DeleteById(id);
            
            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task TodoGetById_WithValidModel_Return_OkResult()
        {
            //Arrange
            var id = 1;
            
            //Act
            var result = await _controller.GetById(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]
        public async Task TodoGetAll_WithValidModel_Return_OkResult()
        {
            //Arrange
            
            //Act
            var result = await _controller.GetAll();
            
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]
        public async Task TodoGetUncompletedTask_WithValidModel_Return_OkResult()
        {
            //Arrange
            
            //Act
            var result = await _controller.GetUnCompleteTask();
            
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]
        public async Task TodoGetCompletedTask_WithValidModel_Return_OkResult()
        {
            //Arrange
            
            //Act
            var result = await _controller.GetCompleteTask();
            
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}