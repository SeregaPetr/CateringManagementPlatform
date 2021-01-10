using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class PaymentTypeRepository : IRepository<PaymentType>
    {
        private readonly ApplicationContext _context;

        public PaymentTypeRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(PaymentType item)
        {
            throw new NotImplementedException();
        }

        public void Delete(PaymentType item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentType>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PaymentType item)
        {
            throw new NotImplementedException();
        }
    }
}
