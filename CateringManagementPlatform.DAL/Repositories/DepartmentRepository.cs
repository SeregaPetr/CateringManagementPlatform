using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private ApplicationContext db;

        public DepartmentRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(Department item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> Find(Func<Department, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Department item)
        {
            throw new NotImplementedException();
        }
    }
}
