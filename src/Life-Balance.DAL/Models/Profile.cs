using Life_Balance.Common.Interfaces;

namespace Life_Balance.DAL.Models
{
    class Profile : IHasDbIdentity
    {
        /// <summary>
        /// Profile Id.
        /// </summary>
        public int Id { get; set; }
    }
}
