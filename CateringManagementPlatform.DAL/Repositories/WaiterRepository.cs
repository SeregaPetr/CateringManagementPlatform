using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class WaiterRepository : IRepository<Waiter>
    {
        private readonly ApplicationContext _context;

        public WaiterRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Waiter item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Waiter item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Waiter>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Waiter> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Waiter item)
        {
            throw new NotImplementedException();
        }
    }
}
