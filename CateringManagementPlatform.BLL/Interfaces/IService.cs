using System.Collections.Generic;
using System.Threading.Tasks;

namespace CateringManagementPlatform.BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        void Dispose();
    }
}
