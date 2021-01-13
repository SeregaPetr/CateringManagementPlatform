using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class PaymentTypeRepository : IRepository<PaymentType>
    {
        private readonly ApplicationContext _context;

        public PaymentTypeRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(PaymentType paymentType)
        {
            _context.PaymentTypes.Add(paymentType);
        }

        public void Delete(PaymentType paymentType)
        {
            _context.PaymentTypes.Remove(paymentType);
        }

        public async Task<IEnumerable<PaymentType>> GetAllAsync()
        {
            return await _context.PaymentTypes
                .Include(p => p.Orders)
                .AsNoTracking().ToListAsync();
        }

        public async Task<PaymentType> GetByIdAsync(int id)
        {
            return await _context.PaymentTypes
               .Include(p => p.Orders)
               .AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(PaymentType paymentType)
        {
            _context.PaymentTypes.Update(paymentType);
        }
    }
}
