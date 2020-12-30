using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class OrderLineRepository : IRepository<OrderLine>
    {
        private ApplicationContext db;

        public OrderLineRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(OrderLine item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderLine> Find(Func<OrderLine, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public OrderLine GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderLine> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderLine item)
        {
            throw new NotImplementedException();
        }
    }
}
