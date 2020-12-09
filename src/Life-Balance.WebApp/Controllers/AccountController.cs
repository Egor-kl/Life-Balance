using Life_Balance.BLL.Interfaces;
using Life_Balance.Common.Constants;
using Life_Balance.Common.Interfaces;
using Life_Balance.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Life_Balance.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;

        public AccountController(IIdentityService identityService, 
                                 IEmailService emailService, 
                                 ILogger<AccountController> logger)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        /// <summary>
        /// View form for registration profile.
        /// </summary>
        /// <returns>View form</returns>
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        /// <summary>
        /// Form for registration profile.
        /// </summary>
        /// <param name="model">Register view model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var (result, userId, code) = await _identityService.CreateUserAsync(model.Email, model.UserName, model.Password);

                if (result == null)
                {
                    ModelState.AddModelError(string.Empty, ErrorConstants.RegistrationEmailExist);
                    _logger.LogInformation($"Problem with registration {model.UserName}");

                    return View(model);
                }

                if (result.Succeeded)
                {
                    var callbackUrl = Url.Action("Index", "Home", new { userId, code }, protocol: HttpContext.Request.Scheme);

                    var body = $"Hello, {model.UserName}. Click for confirm email: <a href='{callbackUrl}'>CLICK ME!</a>";

                    await _emailService.SendEmailAsync(model.Email, ErrorConstants.AccountConfirm, body);
                    _logger.LogInformation($"New user {model.UserName}");

                    return View("RegistartionSucceeded");
                }

                return View(model);
            }

            return View(model);
        }

        /// <summary>
        /// View form for login in profile.
        /// </summary>
        /// <returns>View form</returns>
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            var viewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(viewModel);
        }

        /// <summary>
        /// Form for login in profile.
        /// </summary>
        /// <param name="model">Login view model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isSignIn = await _identityService.LoginUserAsync(model.UserName, model.Password, model.RememberMe, false);

                if (isSignIn.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, ErrorConstants.LoginIncorrectData);

            return View(model);
        }

        /// <summary>
        /// Logout.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _identityService.LogoutUserAsync();
            return RedirectToAction("", "");
        }
    }
}
