using System.Collections.Generic;
using System.Threading.Tasks;
using Life_Balance.BLL.ModelsDTO;

namespace Life_Balance.BLL.Interfaces
{
    public interface IProfileService
    {
        /// <summary>
        /// Get profile diary.
        /// </summary>
        /// <returns></returns>
        public List<DiaryDTO> GetAllDiary(string userId);
    }
}
