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
    public class CalendarControllerTests
    {
        private static readonly Mock<IEventService> EventServiceMock = new Mock<IEventService>();
        private static readonly Mock<ILogger<CalendarController>> LoggerMock = new Mock<ILogger<CalendarController>>();
        private static readonly Mock<IIdentityService> IdentityMock = new Mock<IIdentityService>();

        private readonly CalendarController _controller = new CalendarController(EventServiceMock.Object,
                                                                                LoggerMock.Object,
                                                                                IdentityMock.Object);

        [Fact]
        public async Task EventCreate_WithValidModel_Return_OkResult()
        {
            //Arrange
            var eventDto = new EventDTO
            {
                Title = "FAKE",
                Note = "FAKE",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1)
            };

            //Act
            var result = await _controller.Create(eventDto);
            
            //Assert
            Assert.IsType<OkResult>(result);
        }
        
        [Fact]
        public async Task EventUpdate_WithValidModel_Return_OkResult()
        {
            //Arrange
            var eventDto = new EventDTO
            {
                Title = "FAKE",
                Note = "FAKE",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1)
            };

            //Act
            var result = await _controller.Update(eventDto);
            
            //Assert
            Assert.IsType<OkResult>(result);
        }
        
        [Fact]
        public async Task EventDelete_WithValidModel_Return_NoContent()
        {
            //Arrange
            var id = 1;
            
            //Act
            var result = await _controller.DeleteById(id);
            
            //Assert
            Assert.IsType<OkResult>(result);
        }
        
        [Fact]
        public async Task EventGetById_WithValidModel_Return_OkResult()
        {
            //Arrange
            var id = 1;
            
            //Act
            var result = await _controller.GetById(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]
        public async Task EventGetAll_WithValidModel_Return_OkResult()
        {
            //Arrange
            
            //Act
            var result = await _controller.GetAll();
            
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}