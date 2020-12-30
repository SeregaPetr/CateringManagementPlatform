using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class PaymentTypeRepository : IRepository<PaymentType>
    {
        private ApplicationContext db;

        public PaymentTypeRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(PaymentType item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentType> Find(Func<PaymentType, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public PaymentType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentType> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(PaymentType item)
        {
            throw new NotImplementedException();
        }
    }
}
