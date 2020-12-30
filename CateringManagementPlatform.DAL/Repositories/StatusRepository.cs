using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class StatusRepository : IRepository<Status>
    {
        private ApplicationContext db;

        public StatusRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(Status item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> Find(Func<Status, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Status GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Status item)
        {
            throw new NotImplementedException();
        }
    }
}
