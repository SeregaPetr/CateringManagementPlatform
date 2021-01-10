using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly ApplicationContext _context;

        public DepartmentRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Department item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Department item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Department item)
        {
            throw new NotImplementedException();
        }
    }
}
