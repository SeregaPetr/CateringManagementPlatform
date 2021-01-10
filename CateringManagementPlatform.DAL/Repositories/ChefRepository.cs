using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class ChefRepository : IRepository<Chef>
    {
        private readonly ApplicationContext _context;

        public ChefRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Chef item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Chef item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Chef>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Chef> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Chef item)
        {
            throw new NotImplementedException();
        }
    }
}
