using System;
using System.Collections.Generic;
using System.Text;

namespace Life_Balance.BLL.ModelsDTO
{
    public class EventDTO
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
        /// Meetings start date.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Meetings end date.
        /// </summary>
        public DateTime End { get; set; }


        public string UserId { get; set; }
    }
}
