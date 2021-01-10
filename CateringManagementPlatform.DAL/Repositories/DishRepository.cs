using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class DishRepository : IRepository<Dish>
    {
        private readonly ApplicationContext _context;

        public DishRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Dish item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Dish item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Dish>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dish> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Dish item)
        {
            throw new NotImplementedException();
        }
    }
}
