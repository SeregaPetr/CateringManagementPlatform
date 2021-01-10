using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class GuestRepository : IRepository<Guest>
    {
        private readonly ApplicationContext _context;

        public GuestRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Guest item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guest item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guest>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Guest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Guest item)
        {
            throw new NotImplementedException();
        }
    }
}
