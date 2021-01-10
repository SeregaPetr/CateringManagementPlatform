using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class TableRepository : IRepository<Table>
    {
        private readonly ApplicationContext _context;

        public TableRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Table item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Table item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Table>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Table> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Table item)
        {
            throw new NotImplementedException();
        }
    }
}
