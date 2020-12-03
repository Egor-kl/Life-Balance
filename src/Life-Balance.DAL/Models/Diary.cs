using System;
using Life_Balance.Common.Interfaces;

namespace Life_Balance.DAL.Models
{
    public class Diary : IHasDbIdentity
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title entries.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Date entries.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Notes.
        /// </summary>
        public string Entries { get; set; }


        public string UserId { get; set; }
    }
}