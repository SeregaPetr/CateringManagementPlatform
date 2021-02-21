using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class TableRepository : IRepository<Table>
    {
        private readonly ApplicationContext _context;

        public TableRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Table table)
        {
            _context.Tables.Add(table);
        }

        public void Delete(Table table)
        {
            _context.Tables.Remove(table);
        }

        public async Task<IEnumerable<Table>> GetAllAsync()
        {
            return await _context.Tables
                .AsNoTracking().ToListAsync();
        }

        public async Task<Table> GetByIdAsync(int id)
        {
            return await _context.Tables
                .AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Update(Table table)
        {
            _context.Tables.Update(table);
        }
    }
}
