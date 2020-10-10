using System.ComponentModel.DataAnnotations;

namespace Life_Balance.WebApp.ViewModels
{
    public class ResetPasswordViewModel
    {
        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Confirm password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Verification code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        public string UserName { get; set; }
    }
}
