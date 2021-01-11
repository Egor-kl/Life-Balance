using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.ModelsDTO;
using Life_Balance.Common.Interfaces;
using Life_Balance.DAL.Models;
using Life_Balance.WebApp.Controllers.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace Life_Balance.Tests.ControllersTests
{
    public class DiaryControllerTests
    {
        private static readonly Mock<IDiaryService> DiaryServiceMock = new Mock<IDiaryService>();
        private static readonly Mock<ILogger<DiaryController>> LoggerMock = new Mock<ILogger<DiaryController>>();
        private static readonly Mock<IIdentityService> IdentityMock = new Mock<IIdentityService>();
        private static readonly Mock<IProfileService> ProfileMock = new Mock<IProfileService>();
        private static readonly Mock<IRepository<Diary>> RepositoryMock = new Mock<IRepository<Diary>>();

        private readonly DiaryController _controller = new DiaryController(DiaryServiceMock.Object, 
                                                                           RepositoryMock.Object,
                                                                           LoggerMock.Object,
                                                                           IdentityMock.Object,
                                                                           ProfileMock.Object);

        [Fact]
        public async Task DiaryUpdate_WithValidModel_Return_OkResult()
        {
            //Arrange
            var diaryDto = new DiaryDTO
            {
                Entries = "Fake",
                Title = "Fake",
                Date = DateTime.Now
            };
            
            //Act
            var result = await _controller.Update(diaryDto);
            
            //Assert
            Assert.IsType<OkResult>(result);
        }
        
        [Fact]
        public async Task DiaryDelete_WithValidModel_Return_NoContent()
        {
            //Arrange
            var id = 1;
            
            //Act
            var result = await _controller.DeleteById(id);
            
            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DiaryGetById_WithValidModel_Return_OkResult()
        {
            //Arrange
            var id = 1;
            
            //Act
            var result = await _controller.GetById(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]
        public async Task DiaryGetAll_WithValidModel_Return_OkResult()
        {
            //Arrange
            
            //Act
            var result = await _controller.GetAll();
            
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}