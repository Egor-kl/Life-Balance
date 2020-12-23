using System;

namespace Life_Balance.WebApp.ViewModels
{
    public class EventViewModel
    {
        /// <summary>
        /// Title of event.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Some notes.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Event start date.
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// Event end date.
        /// </summary>
        public string End { get; set; }
    }
}
