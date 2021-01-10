using System.Collections.Generic;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.Common.Interfaces;
using Life_Balance.WebApp.Controllers.API;
using Life_Balance.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Life_Balance.Tests.ControllersTests
{
    public class AccountControllerTests
    {
        private static readonly Mock<IProfileService> ProfileServiceMock = new Mock<IProfileService>();
        private static readonly Mock<IRazorViewToString> RazorViewToStringMock = new Mock<IRazorViewToString>();
        private static readonly Mock<ILogger<AccountController>> LoggerMock = new Mock<ILogger<AccountController>>();
        private static readonly Mock<IIdentityService> IdentityMock = new Mock<IIdentityService>();
        private static readonly Mock<IEmailService> EmailServiceMock = new Mock<IEmailService>();

        private readonly AccountController _controller = new AccountController(IdentityMock.Object,
                                                                                EmailServiceMock.Object,
                                                                                LoggerMock.Object,
                                                                                RazorViewToStringMock.Object,
                                                                                ProfileServiceMock.Object);

        [Fact] 
        public async Task AccountRegister_WithNotValidModel_Return_BadRequestObjectResult()
        {
            //Arrange
            var model = new RegisterViewModel
            {
                UserName = "Fake",
                Email = "fake@fake.fake",
                Password = "Fake1!",
                PasswordConfirm = "Fake1!"
            };
            //Act
            var result = await _controller.Registration(model);
            
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}