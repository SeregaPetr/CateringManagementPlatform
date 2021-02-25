using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
               .Include(o => o.OrderLines)
                    .ThenInclude(ol => ol.Dish)
                 .Include(o => o.OrderLines)
                    .ThenInclude(ol => ol.StatusOrderLine)
                .Include(o => o.StatusOrder)
                .Include(o => o.Table)
                .Include(o => o.Guest)
                .Include(o => o.PaymentType)
                .Include(o => o.Waiter)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderLines)
                    .ThenInclude(ol => ol.Dish)
                 .Include(o => o.OrderLines)
                    .ThenInclude(ol => ol.StatusOrderLine)
                .Include(o => o.StatusOrder)
                .Include(o => o.Table)
                .Include(o => o.Guest)
                .Include(o => o.PaymentType)
                .Include(o => o.Waiter)
                .AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.Orders.Update(order);
        }
    }
}
