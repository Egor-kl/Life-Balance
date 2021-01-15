using System;
using System.Linq;
using System.Threading.Tasks;
using Life_Balance.BLL.Interfaces;
using Life_Balance.Common.Constants;
using Life_Balance.Common.Interfaces;
using Life_Balance.WebApp.Model;
using Life_Balance.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Life_Balance.WebApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;
        private readonly IRazorViewToString _razorViewToString;
        private readonly IProfileService _profileService; 

        public AccountController(IIdentityService identityService, 
                                IEmailService emailService, 
                                ILogger<AccountController> logger, 
                                IRazorViewToString razorViewToString, 
                                IProfileService profileService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _razorViewToString = razorViewToString ?? throw new ArgumentNullException(nameof(razorViewToString));
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
        }

        /// <summary>
        /// Registration new account.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var (result, userId, code) = await _identityService.CreateUserAsync(model.Email, model.UserName, model.Password);

                    if (result == null)
                    {
                        ModelState.AddModelError(string.Empty, ErrorConstants.RegistrationEmailExist);
                        _logger.LogInformation($"Problem with registration {model.UserName} on the server side.");

                        return BadRequest(model);
                    }

                    if (result.Succeeded)
                    {
                        await _profileService.AddNewProfile(model.UserName, userId);
                    
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId, code }, protocol: HttpContext.Request.Scheme);

                        var email = new Email
                        {
                            UserName = model.UserName,
                            Code = callbackUrl
                        };
                    
                        var body = await _razorViewToString.RenderViewToStringAsync("Views/Email/Confirm.cshtml", email);

                        await _emailService.SendEmailAsync(model.Email, ErrorConstants.AccountConfirm, body);
                        _logger.LogInformation($"New user {model.UserName}");

                        return Ok();
                    }
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"{e.Message} when user registration");
                }

                return BadRequest(model);
            }

            return BadRequest(model);
        }
        
        /// <summary>
        /// Form for login in profile.
        /// </summary>
        /// <param name="model">Login view model</param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var (result, message) = await _identityService.EmailConfirmCheckerAsync(model.UserName);

                    if (!result)
                    {
                        ModelState.AddModelError(string.Empty, message);
                        _logger.LogInformation($"{model.UserName} is not confirm email and have error.");

                        return BadRequest(model);
                    }
            
                    if (ModelState.IsValid)
                    {
                        var isSignIn = await _identityService.LoginUserAsync(model.UserName, model.Password, model.RememberMe, false);

                        if (isSignIn.Succeeded)
                        {
                            _logger.LogInformation($"{model.UserName} is login.");
                            return Ok();
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"{e.Message} when user login");
                }
            }

            ModelState.AddModelError(string.Empty, ErrorConstants.LoginIncorrectData);

            return BadRequest(model);
        }

        /// <summary>
        /// Logout.
        /// </summary>
        /// <returns></returns>
        [Route("logout")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _identityService.LogoutUserAsync();
            _logger.LogInformation($"{User.Identity.Name} is logout.");
            return Ok();
        }
        
        /// <summary>
        /// Confirm email.
        /// </summary>
        /// <param name="userId">Id.</param>
        /// <param name="code">Confirmation usl.</param>
        /// <returns>View.</returns>
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId != null && code != null)
            {
                var (result, _) = await _identityService.ConfirmEmail(userId, code);

                if (result.Succeeded)
                {
                    _logger.LogInformation($"{userId} confirm email");
                    return Ok();
                }
            }

            _logger.LogInformation($"{userId} don't confirm email. Error on server side.");
            return Ok();
        }
    }
}