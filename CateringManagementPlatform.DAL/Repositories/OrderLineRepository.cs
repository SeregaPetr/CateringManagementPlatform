using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class OrderLineRepository : IRepository<OrderLine>
    {
        private readonly ApplicationContext _context;

        public OrderLineRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(OrderLine item)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderLine item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderLine>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderLine> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderLine item)
        {
            throw new NotImplementedException();
        }
    }
}
