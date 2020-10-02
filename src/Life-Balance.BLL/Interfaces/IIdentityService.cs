using Life_Balance.BLL.Models;
using System.Threading.Tasks;

namespace Life_Balance.BLL.Interfaces
{
    public interface IIdentityService
    {
        /// <summary>
        /// Get Id user.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <returns>Id user.</returns>
        Task<string> GetUserIdByNameAsync(string userName);

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="userName">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Result of operation, Id user and confirmation Token.</returns>
        Task<(Result result, string userId, string code)> CreateUserAsync(string email, string userName, string password);

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="userId">Id user.</param>
        /// <returns>Result operation.</returns>
        Task<Result> DeleteUserAsync(string userId);

        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="isPersistent">Remember me.</param>
        /// <param name="lockoutOnFailure">Blocked.</param>
        /// <returns>Result of operation.</returns>
        Task<Result> LoginUserAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);

        /// <summary>
        /// Logout.
        /// </summary>
        Task LogoutUserAsync();

        /// <summary>
        /// Check confirm email.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <returns>Result and message.</returns>
        Task<(bool result, string message)> EmailConfirmCheckerAsync(string userName);

        /// <summary>
        /// Confirm email.
        /// </summary>
        /// <param name="userId">Id user.</param>
        /// <param name="code">Confirmation Token.</param>
        /// <returns>Result operation and message.</returns>
        Task<(Result result, string message)> ConfirmEmail(string userId, string code);

        /// <summary>
        /// Restore password.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <returns>Result of operation, Id user, username and confirmation Token.</returns>
        Task<(bool result, string userId, string userName, string code)> ForgotPassword(string email);

        /// <summary>
        /// Reset password.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="code">Confirmation Token.</param>
        /// <returns>Result of operation.</returns>
        Task<Result> ResetPassword(string userName, string password, string code);
    }
}