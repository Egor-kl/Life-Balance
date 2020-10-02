namespace Life_Balance.Common.Constants
{
    public static class ErrorConstants
    {
        /// <summary>
        /// Email is register.
        /// </summary>
        public const string RegistrationEmailExist = "Email is already existed.";

        /// <summary>
        /// Incorrect input.
        /// </summary>
        public const string LoginIncorrectData = "Incorrect username and / or password";

        /// <summary>
        /// Account confirm.
        /// </summary>
        public const string AccountConfirm = "Confirm your account";

        /// <summary>
        /// Password reset.
        /// </summary>
        public const string AccountResetPassword = "Reset password";

        /// <summary>
        /// User not verified email.
        /// </summary>
        public const string UserNotVerifiedEmail = "You have not verified your email.";

        /// <summary>
        /// User not found.
        /// </summary>
        public const string UserNotFound = "User is not found.";

        /// <summary>
        /// Error token.
        /// </summary>
        public const string TokenIssues = "Unexpected token issues..";

        /// <summary>
        /// Successfully.
        /// </summary>
        public const string Successfully = nameof(Successfully);
    }
}
