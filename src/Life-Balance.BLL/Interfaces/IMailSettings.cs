using System;
using System.Collections.Generic;
using System.Text;

namespace Life_Balance.BLL.Interfaces
{
    public interface IMailSettings
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
