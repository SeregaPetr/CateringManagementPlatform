using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        private string _connectionString;
        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
            //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=cateringManagementPlatformDB;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(_connectionString);

        }
        public DbSet<Barman> Barmen { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Table> Tables { get; set; }

    }
}
