using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Job.Cart.Services
{
    public interface ISaveDataToSource
    {
        /// <summary>
        /// Сохранение txt файла
        /// </summary>
        Task SafeDataToTxtFile(string path, string name, List<string> data);
    }
}