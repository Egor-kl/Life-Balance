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
        /// Date entries.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Notes.
        /// </summary>
        public string Entries { get; set; }


        public int UserId { get; set; }
    }
}