using System;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Barman> Barmen { get; }
        public IRepository<Chef> Chefs { get; }
        //    public IRepository<Manager> Managers { get; }
        public IRepository<Waiter> Waiters { get; }
        public IRepository<Account> Accounts { get; }
        public IRepository<Guest> Guests { get; }
        public IRepository<UserRole> UserRoles { get; }
        public IRepository<Department> Departments { get; }
        public IRepository<Dish> Dishes { get; }
        public IRepository<Menu> Menu { get; }
        public IRepository<MenuCategory> MenuCategories { get; }
        public IRepository<Order> Orders { get; }
        public IRepository<OrderLine> OrderLines { get; }
        public IRepository<PaymentType> PaymentTypes { get; }
        //  public IRepository<StatusOrder> Statuses { get; }
        public IRepository<Table> Tables { get; }

        Task SaveAsync();

        //public void Commit()
        //public void Rollback()
    }
}
