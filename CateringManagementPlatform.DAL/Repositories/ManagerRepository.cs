using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class ManagerRepository : IRepository<Manager>
    {
        private readonly ApplicationContext _context;

        public ManagerRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Manager item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Manager item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Manager>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Manager> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Manager item)
        {
            throw new NotImplementedException();
        }
    }
}
