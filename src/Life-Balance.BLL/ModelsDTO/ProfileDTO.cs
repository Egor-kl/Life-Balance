namespace Life_Balance.BLL.ModelsDTO
{
    public class ProfileDTO
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
    }
}