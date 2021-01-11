using System.Collections.Generic;
using Life_Balance.Common.Interfaces;

namespace Life_Balance.DAL.Models
{
    public class Profile : IHasDbIdentity
    {
        /// <summary>
        /// Profile Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User avatar.
        /// </summary>
        public byte[] Avatar { get; set; }


        public string UserId { get; set; }
        
        public ICollection<Diary> Diaries { get; set; }
        
        public ICollection<Event> Events { get; set; }
        
        public ICollection<ToDo> ToDo { get; set; }
    }
}
