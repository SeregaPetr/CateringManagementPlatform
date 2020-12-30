using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Barman> Barmen { get; }
        public IRepository<Chef> Chefs { get; }
        public IRepository<Department> Departments { get; }
        public IRepository<Dish> Dishes { get; }
        public IRepository<Guest> Guests { get; }
        public IRepository<Manager> Managers { get; }
        public IRepository<MenuCategory> MenuCategories { get; }
        public IRepository<OrderLine> OrderLines { get; }
        public IRepository<Order> Orders { get; }
        public IRepository<PaymentType> PaymentTypes { get; }
        //public IRepository<Person> People { get; }
        public IRepository<Status> Statuses { get; }
        public IRepository<Table> Tables { get; }
        public IRepository<Waiter> Waiters { get; }
        void Save();
    }
}
