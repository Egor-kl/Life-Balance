using System;
using Life_Balance.Common.Interfaces;

namespace Life_Balance.DAL.Models
{
    public class ToDo : IHasDbIdentity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of event.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Complete or not event.
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Time of event.
        /// </summary>
        public DateTime Time { get; set; }

        
        public string UserId { get; set; }

        public string ProfileId { get; set; }
    }
}