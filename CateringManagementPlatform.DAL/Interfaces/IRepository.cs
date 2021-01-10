using System.Collections.Generic;
using System.Threading.Tasks;

namespace CateringManagementPlatform.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
