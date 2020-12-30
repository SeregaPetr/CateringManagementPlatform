using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class TableRepository : IRepository<Table>
    {
        private ApplicationContext db;

        public TableRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(Table item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Table> Find(Func<Table, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Table GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Table> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Table item)
        {
            throw new NotImplementedException();
        }
    }
}
