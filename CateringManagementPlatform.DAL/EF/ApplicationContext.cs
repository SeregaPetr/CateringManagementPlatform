using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
        {
            //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Barman> Barmen { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<StatusOrder> StatusOrders { get; set; }
        public DbSet<StatusOrderLine> StatusOrderLines { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
             .HasMany(p => p.UserRoles)
             .WithMany(p => p.Accounts)
             .UsingEntity(j => j.ToTable("AccountUserRole"));

            modelBuilder.Entity<UserRole>().HasData(
                    new UserRole { Id = 1, RoleName = "Admin" },
                    new UserRole { Id = 2, RoleName = "Barman" },
                    new UserRole { Id = 3, RoleName = "Chef" },
                    new UserRole { Id = 4, RoleName = "Waiter" },
                    new UserRole { Id = 5, RoleName = "User" }
                );

            modelBuilder.Entity<Account>().HasData(
                    new Account { Id = 1, Email = "admin@mail.com", Password = "admin" },
                    new Account { Id = 2, Email = "barman@mail.com", Password = "barman" },
                    new Account { Id = 3, Email = "chef@mail.com", Password = "chef" },
                    new Account { Id = 4, Email = "waiter1@mail.com", Password = "waiter1" },
                    new Account { Id = 5, Email = "waiter2@mail.com", Password = "waiter2" },
                    new Account { Id = 6, Email = "table1@mail.com", Password = "table1" },
                    new Account { Id = 7, Email = "table2@mail.com", Password = "table2" }
                );

            modelBuilder.Entity<Account>().HasMany(p => p.UserRoles).WithMany(p => p.Accounts)
               .UsingEntity(j => j.HasData(
                   new { AccountsId = 1, UserRolesId = 1 },
                   new { AccountsId = 2, UserRolesId = 2 },
                   new { AccountsId = 3, UserRolesId = 3 },
                   new { AccountsId = 4, UserRolesId = 4 },
                   new { AccountsId = 5, UserRolesId = 4 },
                   new { AccountsId = 6, UserRolesId = 5 },
                   new { AccountsId = 7, UserRolesId = 5 }
                ));

            modelBuilder.Entity<Manager>().HasData(
                    new Manager { Id = 1, FirstName = "Вася", LastName = "Пупкин", DepartmentId = (int)DepartmentName.Managers, AccountId = 1 }
                );

            modelBuilder.Entity<Barman>().HasData(
                    new Barman { Id = 2, FirstName = "Петя", LastName = "Шустрый", DepartmentId = (int)DepartmentName.Bar, AccountId = 2 }
                );

            modelBuilder.Entity<Chef>().HasData(
                   new Chef { Id = 3, FirstName = "Катя", LastName = "Воробей", DepartmentId = (int)DepartmentName.Kitchen, AccountId = 3 }
                );

            modelBuilder.Entity<Waiter>().HasData(
                    new Waiter { Id = 4, FirstName = "Настя", LastName = "Дудка", DepartmentId = (int)DepartmentName.Waiters, AccountId = 4, NumberTablesServed = 0 }
                );
            modelBuilder.Entity<Waiter>().HasData(
                   new Waiter { Id = 5, FirstName = "Ольга", LastName = "Коробочка", DepartmentId = (int)DepartmentName.Waiters, AccountId = 5, NumberTablesServed = 0 }
               );

            modelBuilder.Entity<Guest>().HasData(
                    new Guest { Id = 6, FirstName = "Стас", LastName = "Купыр", Phone = "0995553311", AccountId = 6 },
                    new Guest { Id = 7, FirstName = "Дима", LastName = "Жук", Phone = "0995553346", AccountId = 7 }
                );

            modelBuilder.Entity<Department>().HasData(
                        new Department { Id = 1, NameDepartment = "Управляющие" },
                        new Department { Id = 2, NameDepartment = "Бар" },
                        new Department { Id = 3, NameDepartment = "Кухня" },
                        new Department { Id = 4, NameDepartment = "Официанты" }
                    );

            modelBuilder.Entity<StatusOrder>().HasData(
                    new StatusOrder { Id = 1, NameStatus = "Счет открыт" },
                    new StatusOrder { Id = 2, NameStatus = "Оплата" },
                    new StatusOrder { Id = 3, NameStatus = "Счет закрыт" }
                );

            modelBuilder.Entity<StatusOrderLine>().HasData(
                    new StatusOrderLine { Id = 1, NameStatus = "новый заказ" },
                    new StatusOrderLine { Id = 2, NameStatus = "заказ в работе" },
                    new StatusOrderLine { Id = 3, NameStatus = "заказ готов" },
                    new StatusOrderLine { Id = 4, NameStatus = "подача заказа" },
                    new StatusOrderLine { Id = 5, NameStatus = "заказ подан" }
                );

            Dish shashlik = new Dish { Id = 1, NameDish = "Шашлык", CompositionDish = "Мясо", Weight = 150, Price = 150, IsArchive = false, DepartmentId = (int)DepartmentName.Kitchen };
            Dish lula = new Dish { Id = 2, NameDish = "Люля", CompositionDish = "Курица", Weight = 150, Price = 200, IsArchive = false, DepartmentId = (int)DepartmentName.Kitchen };
            Dish beer = new Dish { Id = 3, NameDish = "Пиво", CompositionDish = "Оболонь", Weight = 500, Price = 50, IsArchive = false, DepartmentId = (int)DepartmentName.Bar };
            Dish wine = new Dish { Id = 4, NameDish = "Вино", CompositionDish = "Крым", Weight = 750, Price = 350, IsArchive = false, DepartmentId = (int)DepartmentName.Bar };
            Dish rum = new Dish { Id = 5, NameDish = "Ром", CompositionDish = "Италия", Weight = 750, Price = 700, IsArchive = false, DepartmentId = (int)DepartmentName.Bar };
            Dish potato = new Dish { Id = 6, NameDish = "Картошка", CompositionDish = "Жаринная", Weight = 200, Price = 50, IsArchive = false, DepartmentId = (int)DepartmentName.Kitchen };
            Dish roast = new Dish { Id = 7, NameDish = "Поджарка", CompositionDish = "Мясо", Weight = 150, Price = 100, IsArchive = false, DepartmentId = (int)DepartmentName.Kitchen };

            MenuCategory grill = new MenuCategory { Id = 1, NameCategory = "Мангал" };
            MenuCategory alcohol = new MenuCategory { Id = 2, NameCategory = "Алкоголь" };
            MenuCategory garnish = new MenuCategory { Id = 3, NameCategory = "Гарнир" };

            Menu baseMenu = new Menu { Id = 1, IsActive = false, NameMenu = "Основное" };
            Menu resMenu = new Menu { Id = 2, IsActive = true, NameMenu = "Резервное" };

            modelBuilder.Entity<Dish>().HasData(shashlik, lula, beer, wine, rum, potato, roast);
            modelBuilder.Entity<MenuCategory>().HasData(grill, alcohol, garnish);
            modelBuilder.Entity<Menu>().HasData(baseMenu, resMenu);

            modelBuilder.Entity<Menu>()
              .HasMany(m => m.MenuCategories)
              .WithMany(mc => mc.Menus)
              .UsingEntity<MenuCategoryMenu>(
                   j => j
                      .HasOne(pt => pt.MenuCategory)
                      .WithMany(t => t.MenuCategoryMenus)
                      .HasForeignKey(pt => pt.MenuCategoryId),
                   j => j
                       .HasOne(pt => pt.Menu)
                       .WithMany(p => p.MenuCategoryMenus)
                       .HasForeignKey(pt => pt.MenuId),
                   j =>
                   {
                       j.ToTable("MenuCategoryMenus");
                   }
               );

            modelBuilder.Entity<Menu>().HasMany(p => p.MenuCategories).WithMany(p => p.Menus)
              .UsingEntity(j => j
              .HasData(
                  new { MenuId = baseMenu.Id, MenuCategoryId = grill.Id },
                  new { MenuId = baseMenu.Id, MenuCategoryId = alcohol.Id },
                  new { MenuId = baseMenu.Id, MenuCategoryId = garnish.Id },

                  new { MenuId = resMenu.Id, MenuCategoryId = grill.Id },
                  new { MenuId = resMenu.Id, MenuCategoryId = alcohol.Id }
              ));

            modelBuilder.Entity<Dish>().HasMany(d => d.MenuCategoryMenus).WithMany(m => m.Dishes)
                .UsingEntity(j => j
                .HasData(
                    new { MenuCategoryMenusMenuId = baseMenu.Id, MenuCategoryMenusMenuCategoryId = grill.Id, DishesId = shashlik.Id },
                    new { MenuCategoryMenusMenuId = baseMenu.Id, MenuCategoryMenusMenuCategoryId = grill.Id, DishesId = lula.Id },

                    new { MenuCategoryMenusMenuId = baseMenu.Id, MenuCategoryMenusMenuCategoryId = garnish.Id, DishesId = potato.Id },
                    new { MenuCategoryMenusMenuId = baseMenu.Id, MenuCategoryMenusMenuCategoryId = garnish.Id, DishesId = roast.Id },

                    new { MenuCategoryMenusMenuId = baseMenu.Id, MenuCategoryMenusMenuCategoryId = alcohol.Id, DishesId = beer.Id },
                    new { MenuCategoryMenusMenuId = baseMenu.Id, MenuCategoryMenusMenuCategoryId = alcohol.Id, DishesId = wine.Id },
                    new { MenuCategoryMenusMenuId = baseMenu.Id, MenuCategoryMenusMenuCategoryId = alcohol.Id, DishesId = rum.Id },


                    new { MenuCategoryMenusMenuId = resMenu.Id, MenuCategoryMenusMenuCategoryId = grill.Id, DishesId = shashlik.Id },
                    new { MenuCategoryMenusMenuId = resMenu.Id, MenuCategoryMenusMenuCategoryId = grill.Id, DishesId = lula.Id },

                    new { MenuCategoryMenusMenuId = resMenu.Id, MenuCategoryMenusMenuCategoryId = alcohol.Id, DishesId = beer.Id },
                    new { MenuCategoryMenusMenuId = resMenu.Id, MenuCategoryMenusMenuCategoryId = alcohol.Id, DishesId = wine.Id }
                    ));

            modelBuilder.Entity<Table>().HasData(
                 new Table { Id = 10, NumberTable = 1, IsReservation = false, CapacityTable = 10, NumberGuests = null, IsArchive = false },
                 new Table { Id = 20, NumberTable = 2, IsReservation = false, CapacityTable = 4, NumberGuests = null, IsArchive = false }
                 );

            modelBuilder.Entity<PaymentType>().HasData(
                new PaymentType { Id = 1, NamePaymentType = "Наличные" },
                new PaymentType { Id = 2, NamePaymentType = "Терминал" }
                );

        }

    }
}

