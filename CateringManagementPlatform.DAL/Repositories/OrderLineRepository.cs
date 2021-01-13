using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class OrderLineRepository : IRepository<OrderLine>
    {
        private readonly ApplicationContext _context;

        public OrderLineRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(OrderLine orderLine)
        {
            _context.OrderLines.Add(orderLine);
        }

        public void Delete(OrderLine orderLine)
        {
            _context.OrderLines.Remove(orderLine);
        }

        public async Task<IEnumerable<OrderLine>> GetAllAsync()
        {
            return await _context.OrderLines.AsNoTracking().ToListAsync();
        }

        public async Task<OrderLine> GetByIdAsync(int id)
        {
            return await _context.OrderLines.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public void Update(OrderLine orderLine)
        {
            _context.OrderLines.Update(orderLine);
        }
    }
}
