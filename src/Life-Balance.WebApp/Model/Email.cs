namespace Life_Balance.WebApp.Model
{
    /// <summary>
    /// Email for confirm.
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Return url.
        /// </summary>
        public string Code { get; set; }
    }
}