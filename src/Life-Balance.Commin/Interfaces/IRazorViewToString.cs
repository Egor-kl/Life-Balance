using System.Threading.Tasks;

namespace Life_Balance.Common.Interfaces
{
    public interface IRazorViewToString
    {
        /// <summary>
        /// Generate html document
        /// </summary>
        /// <param name="viewName">View model</param>
        /// <param name="model">model</param>
        /// <typeparam name="TModel">Return model</typeparam>
        /// <returns>View to string</returns>
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}