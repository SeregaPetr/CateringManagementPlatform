using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class GuestRepository : IRepository<Guest>
    {
        private ApplicationContext db;

        public GuestRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(Guest item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Guest> Find(Func<Guest, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Guest GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Guest> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Guest item)
        {
            throw new NotImplementedException();
        }
    }
}
