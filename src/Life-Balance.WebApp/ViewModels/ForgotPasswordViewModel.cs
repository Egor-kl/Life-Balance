using System.ComponentModel.DataAnnotations;

namespace Life_Balance.WebApp.ViewModels
{
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
