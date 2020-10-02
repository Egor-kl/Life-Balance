using Life_Balance.BLL.Extencions;
using Life_Balance.BLL.Interfaces;
using Life_Balance.BLL.Models;
using Life_Balance.Common.Constants;
using Life_Balance.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life_Balance.BLL.Services
{
    class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="userManager">User manager.</param>
        /// <param name="signInManager">Sign in manager.</param>
        public IdentityService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        /// <inheritdoc />
        public async Task<string> GetUserIdByNameAsync(string userName)
        {
            var user = await _userManager.Users.FirstAsync(u => u.UserName == userName);

            return user.Id;
        }

        /// <inheritdoc />
        public async Task<(Result result, string userId, string code)> CreateUserAsync(string email, string userName, string password)
        {
            var user = new User
            {
                Email = email,
                UserName = userName
            };

            var isExist = await _userManager.FindByEmailAsync(email);

            if (isExist != null)
            {
                return (null, null, null);
            }

            IdentityResult result = await _userManager.CreateAsync(user, password);
            var code = string.Empty;

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            }

            return (result.ToApplicationResult(), user.Id, code);
        }

        /// <inheritdoc />
        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return Result.Success();
            }

            return await DeleteUserAsync(user);
        }

        /// <inheritdoc />
        public async Task<Result> LoginUserAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);

            return result.ToApplicationResult();
        }

        /// <inheritdoc />
        public async Task LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }

        /// <inheritdoc />
        public async Task<(bool result, string message)> EmailConfirmCheckerAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return (false, ErrorConstants.UserNotFound);
            }

            var isConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            if (isConfirmed)
            {
                return (true, null);
            }

            return (false, ErrorConstants.UserNotVerifiedEmail);
        }

        /// <inheritdoc />
        public async Task<(Result result, string message)> ConfirmEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return (null, ErrorConstants.UserNotFound);
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                await SignInUserAsync(user.Email, user.UserName);

                return (result.ToApplicationResult(), ErrorConstants.Successfully);
            }

            return (result.ToApplicationResult(), ErrorConstants.TokenIssues);
        }

        /// <inheritdoc />
        public async Task<(bool result, string userId, string userName, string code)> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return (false, null, null, null);
            }

            var result = await _userManager.IsEmailConfirmedAsync(user);

            if (!result)
            {
                return (false, null, null, null);
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            return (true, user.Id, user.UserName, code);
        }

        /// <inheritdoc />
        public async Task<Result> ResetPassword(string userName, string password, string code)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return null;
            }

            var result = await _userManager.ResetPasswordAsync(user, code, password);

            return result.ToApplicationResult();
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>Result of operation.</returns>
        private async Task<Result> DeleteUserAsync(User user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        /// <summary>
        /// Sign in.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="userName">Username.</param>
        private async Task SignInUserAsync(string email, string userName)
        {
            var user = new User
            {
                Email = email,
                UserName = userName
            };

            await _signInManager.SignInAsync(user, false);
        }
    }
}
