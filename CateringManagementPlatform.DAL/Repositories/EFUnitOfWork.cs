using System;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        private BarmanRepository _barmenRepository;
        private ChefRepository _chefRepository;
        //  private ManagerRepository _managerRepository;
        private WaiterRepository _waiterRepository;
        private AccountRepository _accountRepository;
        private GuestRepository _guestRepository;
        private RoleRepository _userRoleRepository;
        private DepartmentRepository _departmentRepository;
        private DishRepository _dishRepository;
        private MenuRepository _menuRepository;
        private MenuCategoryRepository _menuCategoryRepository;
        private OrderRepository _orderRepository;
        private OrderLineRepository _orderLineRepository;
        private PaymentTypeRepository _paymentTypeRepository;
        //  private StatusRepository _statusRepository;
        private TableRepository _tableRepository;

        public EFUnitOfWork(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<Barman> Barmen
        {
            get
            {
                if (_barmenRepository == null)
                {
                    _barmenRepository = new BarmanRepository(_context);
                }
                return _barmenRepository;
            }
        }

        public IRepository<Chef> Chefs
        {
            get
            {
                if (_chefRepository == null)
                {
                    _chefRepository = new ChefRepository(_context);
                }
                return _chefRepository;
            }
        }

        public IRepository<Waiter> Waiters
        {
            get
            {
                if (_waiterRepository == null)
                {
                    _waiterRepository = new WaiterRepository(_context);
                }
                return _waiterRepository;
            }
        }

        public IRepository<Account> Accounts
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_context);
                }
                return _accountRepository;
            }
        }

        public IRepository<Guest> Guests
        {
            get
            {
                if (_accountRepository == null)
                {
                    _guestRepository = new GuestRepository(_context);
                }
                return _guestRepository;
            }
        }

        public IRepository<UserRole> UserRoles
        {
            get
            {
                if (_userRoleRepository == null)
                {
                    _userRoleRepository = new RoleRepository(_context);
                }
                return _userRoleRepository;
            }
        }

        public IRepository<Department> Departments
        {
            get
            {
                if (_departmentRepository == null)
                {
                    _departmentRepository = new DepartmentRepository(_context);
                }
                return _departmentRepository;
            }
        }

        public IRepository<Dish> Dishes
        {
            get
            {
                if (_dishRepository == null)
                {
                    _dishRepository = new DishRepository(_context);
                }
                return _dishRepository;
            }
        }

        public IRepository<Menu> Menu
        {
            get
            {
                if (_menuRepository == null)
                {
                    _menuRepository = new MenuRepository(_context);
                }
                return _menuRepository;
            }
        }

        //public IRepository<Manager> Managers
        //{
        //    get
        //    {
        //        if (_managerRepository == null)
        //        {
        //            _managerRepository = new ManagerRepository(_context);
        //        }
        //        return _managerRepository;
        //    }
        //}

        public IRepository<MenuCategory> MenuCategories
        {
            get
            {
                if (_menuCategoryRepository == null)
                {
                    _menuCategoryRepository = new MenuCategoryRepository(_context);
                }
                return _menuCategoryRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_context);
                }
                return _orderRepository;
            }
        }

        public IRepository<OrderLine> OrderLines
        {
            get
            {
                if (_orderLineRepository == null)
                {
                    _orderLineRepository = new OrderLineRepository(_context);
                }
                return _orderLineRepository;
            }
        }


        public IRepository<PaymentType> PaymentTypes
        {
            get
            {
                if (_paymentTypeRepository == null)
                {
                    _paymentTypeRepository = new PaymentTypeRepository(_context);
                }
                return _paymentTypeRepository;
            }
        }

        //public IRepository<StatusOrder> Statuses
        //{
        //    get
        //    {
        //        if (_statusRepository == null)
        //        {
        //            _statusRepository = new StatusRepository(_context);
        //        }
        //        return _statusRepository;
        //    }
        //}

        public IRepository<Table> Tables
        {
            get
            {
                if (_tableRepository == null)
                {
                    _tableRepository = new TableRepository(_context);
                }
                return _tableRepository;
            }
        }


        //public void Commit()
        //{
        //    _context.SaveChanges();
        //}

        //public void Rollback()
        //{
        //    _context.Dispose();
        //}

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
