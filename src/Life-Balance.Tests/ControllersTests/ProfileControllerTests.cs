using System.Collections.Generic;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.WebApp.Controllers.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Life_Balance.Tests.ControllersTests
{
    public class ProfileControllerTests
    {
        private static readonly Mock<IProfileService> ProfileServiceMock = new Mock<IProfileService>();
        private static readonly Mock<ILogger<ProfileController>> LoggerMock = new Mock<ILogger<ProfileController>>();
        private static readonly Mock<IIdentityService> IdentityMock = new Mock<IIdentityService>();

        private readonly ProfileController _controller = new ProfileController(LoggerMock.Object,
                                                                                IdentityMock.Object,
                                                                                ProfileServiceMock.Object);

        [Fact]
        public async Task ProfileGetProfile_WithValidModel_Return_Dictionary()
        {
            //Arrange
            
            //Act
            var result = await _controller.GetProfile();
            //Assert
            Assert.IsType<Dictionary<int, object>>(result);
        }
    }
}