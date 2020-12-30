using System;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
        private BarmanRepository barmenRepository;
        private ChefRepository chefRepository;
        private DepartmentRepository departmentRepository;
        private DishRepository dishRepository;
        private GuestRepository guestRepository;
        private ManagerRepository managerRepository;
        private MenuCategoryRepository menuCategoryRepository;
        private OrderLineRepository orderLineRepository;
        private OrderRepository orderRepository;
        private PaymentTypeRepository paymentTypeRepository;
       // private PersonRepository personRepository;
        private StatusRepository statusRepository;
        private TableRepository tableRepository;
        private WaiterRepository waiterRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
        }

        public IRepository<Barman> Barmen
        {
            get
            {
                if (barmenRepository == null)
                {
                    barmenRepository = new BarmanRepository(db);
                }
                return barmenRepository;
            }
        }

        public IRepository<Chef> Chefs
        {
            get
            {
                if (chefRepository == null)
                {
                    chefRepository = new ChefRepository(db);
                }
                return chefRepository;
            }
        }

        public IRepository<Department> Departments
        {
            get
            {
                if (departmentRepository == null)
                {
                    departmentRepository = new DepartmentRepository(db);
                }
                return departmentRepository;
            }
        }

        public IRepository<Dish> Dishes
        {
            get
            {
                if (dishRepository == null)
                {
                    dishRepository = new DishRepository(db);
                }
                return dishRepository;
            }
        }

        public IRepository<Guest> Guests
        {
            get
            {
                if (guestRepository == null)
                {
                    guestRepository = new GuestRepository(db);
                }
                return guestRepository;
            }
        }

        public IRepository<Manager> Managers
        {
            get
            {
                if (managerRepository == null)
                {
                    managerRepository = new ManagerRepository(db);
                }
                return managerRepository;
            }
        }

        public IRepository<MenuCategory> MenuCategories
        {
            get
            {
                if (menuCategoryRepository == null)
                {
                    menuCategoryRepository = new MenuCategoryRepository(db);
                }
                return menuCategoryRepository;
            }
        }

        public IRepository<OrderLine> OrderLines
        {
            get
            {
                if (orderLineRepository == null)
                {
                    orderLineRepository = new OrderLineRepository(db);
                }
                return orderLineRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(db);
                }
                return orderRepository;
            }
        }

        public IRepository<PaymentType> PaymentTypes
        {
            get
            {
                if (paymentTypeRepository == null)
                {
                    paymentTypeRepository = new PaymentTypeRepository(db);
                }
                return paymentTypeRepository;
            }
        }

        //public IRepository<Person> People
        //{
        //    get
        //    {
        //        if (personRepository == null)
        //        {
        //            personRepository = new PersonRepository(db);
        //        }
        //        return personRepository;
        //    }
        //}

        public IRepository<Status> Statuses
        {
            get
            {
                if (statusRepository == null)
                {
                    statusRepository = new StatusRepository(db);
                }
                return statusRepository;
            }
        }

        public IRepository<Table> Tables
        {
            get
            {
                if (tableRepository == null)
                {
                    tableRepository = new TableRepository(db);
                }
                return tableRepository;
            }
        }

        public IRepository<Waiter> Waiters
        {
            get
            {
                if (waiterRepository == null)
                {
                    waiterRepository = new WaiterRepository(db);
                }
                return waiterRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
