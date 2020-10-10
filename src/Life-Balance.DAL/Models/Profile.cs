using Life_Balance.Common.Interfaces;

namespace Life_Balance.DAL.Models
{
    public class Profile : IHasDbIdentity
    {
        /// <summary>
        /// Profile Id.
        /// </summary>
        public int Id { get; set; }
    }
}
