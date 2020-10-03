using System.ComponentModel.DataAnnotations;

namespace Life_Balance.WebApp.Models
{
    public class LoginViewModel
    {
        /// <summary>
        /// Username.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Remember user.
        /// </summary>
        public bool RememberMe { get; set; }

        /// <summary>
        /// Return url.
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
