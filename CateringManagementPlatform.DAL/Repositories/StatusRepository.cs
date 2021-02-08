using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class StatusRepository //: IRepository<StatusOrder>
    {
        //private readonly ApplicationContext _context;

        //public StatusRepository(ApplicationContext context)
        //{
        //    _context = context ?? throw new ArgumentNullException(nameof(context));
        //}

        //public void Create(StatusOrder status)
        //{
        //    _context.Statuses.Add(status);
        //}

        //public void Delete(StatusOrder status)
        //{
        //    _context.Statuses.Remove(status);
        //}

        //public async Task<IEnumerable<StatusOrder>> GetAllAsync()
        //{
        //    return await _context.Statuses
        //         .Include(s => s.OrderLines)
        //         .Include(s => s.Orders)
        //         .AsNoTracking().ToListAsync();
        //}

        //public async Task<StatusOrder> GetByIdAsync(int id)
        //{
        //    return await _context.Statuses
        //         .Include(s => s.OrderLines)
        //         .Include(s => s.Orders)
        //         .AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        //}

        //public void Update(StatusOrder status)
        //{
        //    _context.Statuses.Update(status);
        //}
    }
}
