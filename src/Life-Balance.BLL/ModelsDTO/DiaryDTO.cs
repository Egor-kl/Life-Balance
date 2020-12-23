using System;

namespace Life_Balance.BLL.ModelsDTO
{
    /// <summary>
    /// Mapping for Diary.
    /// </summary>
    public class DiaryDTO
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
        /// Start date entries.
        /// </summary>
        public string StartDate { get; set; }
        
        /// <summary>
        /// End date entries.
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// Notes.
        /// </summary>
        public string Entries { get; set; }


        public string UserId { get; set; }
    }
}