﻿using Life_Balance.BLL.Interfaces;

namespace Life_Balance.BLL.Models
{
    public class MailSettings : IMailSettings
    {
        /// <summary>
        /// Server.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}