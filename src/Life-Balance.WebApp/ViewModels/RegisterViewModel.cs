using System.ComponentModel.DataAnnotations;

namespace Life_Balance.WebApp.Models
{
    /// <summary>
    /// ViewModel for registration new user.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// User name.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Confirm password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }
    }
}
