using Life_Balance.Common.Interfaces;
using System;

namespace Life_Balance.DAL.Models
{
    public class Event : IHasDbIdentity
    {
        /// <summary>
        /// ID Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of meeting.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Write some notes.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Event start date.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Event end date.
        /// </summary>
        public DateTime End { get; set; }


        public string UserId { get; set; }
    }
}
