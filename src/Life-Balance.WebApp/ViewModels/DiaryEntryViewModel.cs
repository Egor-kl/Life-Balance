using System;

namespace Life_Balance.WebApp.ViewModels
{
    public class DiaryEntryViewModel
    {
        /// <summary>
        /// Title entry.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Entry in diary.
        /// </summary>
        public string Entry { get; set; }

        /// <summary>
        /// Date when the log entry was made.
        /// </summary>
        public DateTime Date { get; set; }
    }
}