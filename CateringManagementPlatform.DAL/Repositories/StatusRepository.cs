using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class StatusRepository : IRepository<Status>
    {
        private readonly ApplicationContext _context;

        public StatusRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Status item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Status item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Status>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Status> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Status item)
        {
            throw new NotImplementedException();
        }
    }
}
